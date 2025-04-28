using AuctionApp.Domain.Models;

namespace AuctionApp.Application.Services
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetBuyProductByUserId(string userId);
        Task<IEnumerable<Product>> GetSellProductByUserId(string userId);
        Task<IEnumerable<Product>> GetAvailableProductsAsync(string userId);
        Task UpdateProductAsync(int id, Product product);
    }
}
