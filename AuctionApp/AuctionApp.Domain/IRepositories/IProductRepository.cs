using AuctionApp.Domain.Models;

namespace AuctionApp.Domain.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<IEnumerable<Product>> ProductsAvailableAsync(string userId);
        Task<IEnumerable<Product>> GetAllSellProductAsync(string userId);
        Task<IEnumerable<Product>> GetAllBuyProductAsync(string userId);
        Task UpdateProduct(int id, Product product);
    }
}
