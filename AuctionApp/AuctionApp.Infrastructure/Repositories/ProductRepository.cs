using AuctionApp.Domain.IRepositories;
using AuctionApp.Domain.Models;
using AuctionApp.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AuctionDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductRepository(AuctionDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();  
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllBuyProductAsync(string userId)
        {
            var products = await _context.Products
                                            .Where(x => x.BoughtByUserId == userId)
                                            .ToListAsync();      
            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _context.Products
                                .Include(c => c.Category)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllSellProductAsync(string userId)
        {
            var sellProducts = await _context.Products
                                            .Include(c => c.Category)       
                                            .Where(c => c.UserId == userId) 
                                            .ToListAsync();
            return sellProducts;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products
                                     .Include(c => c.Category)       
                                    .FirstOrDefaultAsync(x => x.Id ==  productId);    
            
        }

        public async Task<IEnumerable<Product>> ProductsAvailableAsync(string userId)
        {
            var products = await _context.Products
                                .Where(p => p.UserId != userId)
                                .Include(c => c.Category)
                                .ToListAsync();
            return products;
        }

        public async Task UpdateProduct(int id, Product product)
        {
            var model = await _context.Products.FindAsync(id);
            if (model != null)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
