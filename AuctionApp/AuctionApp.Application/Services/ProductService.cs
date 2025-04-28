using AuctionApp.Domain.IRepositories;
using AuctionApp.Domain.Models;


namespace AuctionApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productRepository.AddProductAsync(product);
        }

        public async Task<IEnumerable<Product>> GetSellProductByUserId(string userId)
        {
            return await _productRepository.GetAllSellProductAsync(userId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductAsync();
        }

        public async Task<IEnumerable<Product>> GetAvailableProductsAsync(string userId)
        {
            return await _productRepository.ProductsAvailableAsync(userId);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetBuyProductByUserId(string userId)
        {
            return await _productRepository.GetAllBuyProductAsync(userId);
        }

        public async Task UpdateProductAsync(int id, Product product)
        {
           await _productRepository.UpdateProduct(id, product); 
        }
    }
}
