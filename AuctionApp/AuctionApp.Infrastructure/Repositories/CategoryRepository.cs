using AuctionApp.Domain.IRepositories;
using AuctionApp.Domain.Models;
using AuctionApp.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AuctionDbContext _context;
        public CategoryRepository(AuctionDbContext context)
        {
            _context = context;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);       
            await _context.SaveChangesAsync();  
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories
                                  .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories
                                 .FirstOrDefaultAsync(x => x.Id == categoryId);      
        }

        public async Task<Category> GetCategoryByName(string categoryName)
        {
            return await _context.Categories
                            .FirstOrDefaultAsync(x => x.Name == categoryName);      
        }
    }
}
