using AuctionApp.Domain.Models;

namespace AuctionApp.Application.Services
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryById(int categoryId);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> CreateCategory(Category category);
        Task<Category> GetCategoryByName(string categoryName);
    }
}
