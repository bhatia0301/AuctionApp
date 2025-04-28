using AuctionApp.Application.DTOs;
using AuctionApp.Application.Services;
using AuctionApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuctionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthService _authService;
        private readonly IWebHostEnvironment _env;
        private ResponseDTO response;

        public ProductController(IProductService productService, IWebHostEnvironment env, 
            ICategoryService categoryService, IAuthService authService)
        {
            _productService = productService;
            response = new ResponseDTO();
            _env = env;
            _categoryService = categoryService;
            _authService = authService;

        }

        [Authorize(Roles = "User")]
        [HttpPost("Create-Product")]
        public async Task<ResponseDTO> AddProduct([FromForm] AddProductDTO addProductDTO)
        {
            try
            {
                if (addProductDTO.StartingPrice >= addProductDTO.ReservedPrice)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "Starting price must be less than reserved price.";
                    return response;
                }
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var category = await _categoryService.GetCategoryByName(addProductDTO.Category);
                if(category == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid category";
                    response.Result = null;
                    return response;
                }
                var product = new Product
                {
                    Name = addProductDTO.Name,
                    Description = addProductDTO.Description,
                    StartingPrice = addProductDTO.StartingPrice,
                    AuctionDuration = addProductDTO.AuctionDuration,
                    CategoryId = category.Id,
                    Category = category,
                    ReservedPrice = addProductDTO.ReservedPrice,
                    UserId = userId,
                    User = await _authService.GetUserByIdAsync(userId),
                    BoughtByUserId = null,
                    CreatedAt = DateTime.UtcNow
                };
                if(addProductDTO.ProductImage != null) 
                {
                    var fileExtension = Path.GetExtension(addProductDTO.ProductImage.FileName).ToLower();
                    if (fileExtension != ".jpg" && fileExtension != ".png")
                    {
                        response.IsSuccess = false;
                        response.Message = "Product image must be in JPG or PNG format.";
                        response.Result = null;
                        return response;
                    }
                    product.ProductImage = await UploadImageAsync(addProductDTO.ProductImage);
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Image file is required";
                    response.Result = null;
                    return response;
                }
                var createdProduct = await _productService.AddProductAsync(product);
                var productDTO = new ProductDTO
                {
                    Id = createdProduct.Id,
                    Name = createdProduct.Name,
                    Description = createdProduct.Description,
                    StartingPrice = createdProduct.StartingPrice,
                    AuctionDuration = createdProduct.AuctionDuration,
                    CategoryName = category.Name,
                    ReservedPrice = createdProduct.ReservedPrice,
                    BoughtByUserId = createdProduct.BoughtByUserId,
                    ProductImage = createdProduct.ProductImage,
                    CreatedAt = createdProduct.CreatedAt,
                };
                response.Result = productDTO;   
                response.Message = "Product created successfully";
                response.IsSuccess = true;
            }
            catch (Exception ex) 
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }
            return response;
        }

        private async Task<string> UploadImageAsync(IFormFile productImage)
        {
            try
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(productImage.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await productImage.CopyToAsync(fileStream);
                }

                return uniqueFileName;

            }
            catch (Exception ex)
            {
                throw new Exception("Image upload failed: " + ex.Message);

            }
        }

        [HttpGet("Get-All-Products")]
        public async Task<ResponseDTO> GetAllProduct()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                var productsDTO = new List<ProductDTO>();
                foreach (var product in products)
                {
                    var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                    var productImageUrl = $"{baseUrl}/images/{product.ProductImage}";
                    productsDTO.Add(new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        StartingPrice = product.StartingPrice,
                        AuctionDuration = product.AuctionDuration,
                        CategoryName = product.Category.Name,
                        ReservedPrice = product.ReservedPrice,
                        ProductImage = productImageUrl,
                        BoughtByUserId = product.BoughtByUserId,        
                        CreatedAt = product.CreatedAt
                    });
                }
                response.Result = productsDTO;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        [HttpGet("{productId:int}")]
        public async Task<ResponseDTO> GetProductById(int productId)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(productId); 
                if(product == null)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "Product not found!";
                    return response;
                }
                var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                var productImageUrl = $"{baseUrl}/images/{product.ProductImage}";
                var productDTO = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    StartingPrice = product.StartingPrice,
                    AuctionDuration = product.AuctionDuration,
                    CategoryName = product.Category.Name,
                    ReservedPrice = product.ReservedPrice,
                    ProductImage = productImageUrl,
                    BoughtByUserId = product.BoughtByUserId,
                    CreatedAt = product.CreatedAt
                };
                response.Result = productDTO;
                response.Message = "Success";
            }
            catch (Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        [Authorize(Roles = "User")]
        [HttpGet("Available-Products")]
        public async Task<ResponseDTO> GetAllAvailableProducts()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var products = await _productService.GetAvailableProductsAsync(userId); 
                if(products == null)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "Product not available for the bid!";
                    return response;
                }
                var productsDTO = new List<ProductDTO>();
                foreach (var product in products)
                {
                    var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                    var productImageUrl = $"{baseUrl}/images/{product.ProductImage}";
                    productsDTO.Add(new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        StartingPrice = product.StartingPrice,
                        AuctionDuration = product.AuctionDuration,
                        CategoryName = product.Category.Name,
                        ReservedPrice = product.ReservedPrice,
                        ProductImage = productImageUrl,
                        BoughtByUserId = product.BoughtByUserId,
                        CreatedAt = product.CreatedAt
                    });
                }
                response.Result = productsDTO;
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
        [HttpGet("Sell-Products/{userId:Guid}")]
        public async Task<ResponseDTO> GetProductSellByUserId(string userId)
        {
            try
            {
                var products = await _productService.GetSellProductByUserId(userId);
                if (products == null)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "No products are exist for sell";
                    return response;
                }
                var productsDTO = new List<ProductDTO>();
                foreach (var product in products)
                {
                    var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                    var productImageUrl = $"{baseUrl}/images/{product.ProductImage}";
                    productsDTO.Add(new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        StartingPrice = product.StartingPrice,
                        AuctionDuration = product.AuctionDuration,
                        CategoryName = product.Category.Name,
                        ReservedPrice = product.ReservedPrice,
                        ProductImage = productImageUrl,
                        BoughtByUserId = product.BoughtByUserId,    
                        CreatedAt = product.CreatedAt
                    });
                }
                response.Result = productsDTO;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Buy-Products/{userId:Guid}")]
        public async Task<ResponseDTO> GetProductBuyByUserId(string userId)
        {
            try
            {
                var products = await _productService.GetBuyProductByUserId(userId);
                if (products == null)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "No products are exist for buy";
                    return response;
                }
                var productsDTO = new List<ProductDTO>();
                foreach (var product in products)
                {
                    var user = await _authService.GetUserByIdAsync(product.UserId);
                    var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                    var category = await _categoryService.GetCategoryById(product.CategoryId);
                    var productImageUrl = $"{baseUrl}/images/{product.ProductImage}";
                    productsDTO.Add(new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        StartingPrice = product.StartingPrice,
                        AuctionDuration = product.AuctionDuration,
                        CategoryName = category.Name,
                        ReservedPrice = product.ReservedPrice,
                        ProductImage = productImageUrl,
                        BoughtByUserId = userId,
                        CreatedAt = product.CreatedAt
                    });
                }
                response.Result = productsDTO;
                response.Message = "Success";
            }
            catch(Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            } 
            return response;
        }

    }
}
