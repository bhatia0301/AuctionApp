using AuctionApp.Application.DTOs;
using AuctionApp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;
        private readonly IAuthService _authService;
        private readonly IProductService _productService;  
        private readonly ICategoryService _categoryService; 
        private ResponseDTO response;

        public AuctionController(IAuthService authService, IProductService productService, 
            IAuctionService auctionService, ICategoryService categoryService)
        {
            _authService = authService;
            _auctionService = auctionService;
            _productService = productService;
            _categoryService = categoryService;
            response = new ResponseDTO();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Get-All-Auctions")]
        public async Task<ResponseDTO> GetAllAuctions()
        {
            try
            {
                var auctions = await _auctionService.GetAllAuctionsAsync();
                var auctionsDTO = new List<AuctionDTO>();
                
                foreach(var auction in auctions)
                {
                    var user = await _authService.GetUserByIdAsync(auction.HighestBidUserId);
                    var product = await _productService.GetProductByIdAsync(auction.ProductId);
                    var category = await _categoryService.GetCategoryById(product.CategoryId);
                    var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                    var productImageUrl = $"{baseUrl}/images/{product.ProductImage}";
                    auctionsDTO.Add(new AuctionDTO
                    {
                        Id = auction.Id,
                        FullName = user.FullName,
                        CurrentHighestBid = auction.CurrentHighestBid,
                        ProductName = product.Name, 
                        ProductDescription = product.Description,
                        AuctionDuration = product.AuctionDuration,
                        CategoryName = category.Name,   
                        ProductImage = productImageUrl,
                        BidCount = auction.BidCount,    
                        CreatedAt = product.CreatedAt
                    });
                    response.Result = auctionsDTO;
                    response.Message = "Success";
                }
            }
            catch(Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{auctionId:int}")]
        public async Task<ResponseDTO> GetAuctionById(int auctionId)
        {
            try
            {
                var auction = await _auctionService.GetAuctionByIdAsync(auctionId);
                if (auction == null)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "Auction not found!";
                    return response;
                }
                var user = await _authService.GetUserByIdAsync(auction.HighestBidUserId);
                var product = await _productService.GetProductByIdAsync(auction.ProductId);
                var category = await _categoryService.GetCategoryById(auction.Product.CategoryId);
                var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                var productImageUrl = $"{baseUrl}/images/{product.ProductImage}";
                var auctionDTO = new AuctionDTO
                {
                    Id = auction.Id,
                    FullName = user.FullName,
                    CurrentHighestBid = auction.CurrentHighestBid,
                    ProductName = product.Name,
                    ProductDescription = product.Description,
                    AuctionDuration = product.AuctionDuration,
                    CategoryName = category.Name,
                    ProductImage = productImageUrl,
                    BidCount = auction.BidCount,
                    CreatedAt = product.CreatedAt
                };
                response.Result = auctionDTO;
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
        [HttpDelete("Delete-Auction/{auctionId:int}")]
        public async Task<ResponseDTO> DeleteAuction(int auctionId)
        {
            try
            {
                var auction = await _auctionService.GetAuctionByIdAsync(auctionId);
                if (auction == null)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "Auction not found!";
                    return response;
                }
                var status = await _auctionService.DeleteAuctionAsync(auctionId);
               
                if (status)
                {
                    response.Result = status;
                    response.Message = "Auction deleted successfully!";
                }
                else
                {
                    throw new Exception("Error in deleting the auction");
                }
            }
            catch (Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;    
        }
    }
}
