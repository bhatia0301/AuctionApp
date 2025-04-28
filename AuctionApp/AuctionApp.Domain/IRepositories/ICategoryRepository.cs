using AuctionApp.Domain.Models;

namespace AuctionApp.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByName(string categoryName);
    }
}
