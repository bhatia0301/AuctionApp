using AuctionApp.Application.DTOs;
using AuctionApp.Application.Services;
using AuctionApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private ResponseDTO response;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            response = new ResponseDTO();
        }

        [HttpGet("Get-All")]
        public async Task<ResponseDTO> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();
                var categoriesDTO = new List<CategoryDTO>();
                foreach (var category in categories)
                {
                    categoriesDTO.Add(new CategoryDTO
                    {
                        Id = category.Id,   
                        Name = category.Name,
                        CreatedAt = category.CreatedAt
                    });                    
                }
                response.Result = categoriesDTO;    
                response.Message = "Success";  
            }
            catch(Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;    
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add-Category")]
        public async Task<ResponseDTO> CreateCategory(AddCategoryDTO addCategoryDTO)
        {
            try
            {
                var category = new Category
                {
                    Name = addCategoryDTO.Name,
                    CreatedAt = DateTime.Now.Date,
                };
                var createdCategory = await _categoryService.CreateCategory(category);
                var categoryDTO = new CategoryDTO
                {
                    Id = createdCategory.Id,
                    Name = createdCategory.Name,
                    CreatedAt = createdCategory.CreatedAt
                };
                response.Result = categoryDTO;
                response.Message = "Category created successfully!";
            }
            catch(Exception ex) 
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }
            return response;    
        }
    }
}
