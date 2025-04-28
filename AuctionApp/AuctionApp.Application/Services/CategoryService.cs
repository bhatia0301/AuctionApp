using AuctionApp.Domain.IRepositories;
using AuctionApp.Domain.Models;

namespace AuctionApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            return await _categoryRepository.AddCategoryAsync(category);    
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategoryAsync();
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(categoryId);  
        }

        public async Task<Category> GetCategoryByName(string categoryName)
        {
            return await _categoryRepository.GetCategoryByName(categoryName);   
        }
    }
}
