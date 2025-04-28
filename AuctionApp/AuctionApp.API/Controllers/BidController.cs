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
    public class BidController : ControllerBase
    {
        private readonly IAuctionService _auctionService;
        private readonly IAuthService _authService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBidService _bidService;   
        private ResponseDTO response;


        public BidController(IAuthService authService, IProductService productService,
            IAuctionService auctionService, ICategoryService categoryService, IBidService bidService)
        {
            _authService = authService;
            _productService = productService;
            _auctionService = auctionService;
            _categoryService = categoryService;
            _bidService = bidService;   
            response = new ResponseDTO();   
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Get-All-Bids")]
        public async Task<ResponseDTO> GetAllBids()
        {
            try
            {
                var bids = await _bidService.GetAllBidsAsync();
                if (bids == null)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "No Bids exist!";
                    return response;
                }
                var bidsDto = new List<BidDTO>();
                foreach (var bid in bids)
                {
                    var user = await _authService.GetUserByIdAsync(bid.UserId);
                    var product = await _productService.GetProductByIdAsync(bid.Auction.ProductId);
                    var category = await _categoryService.GetCategoryById(product.CategoryId);
                    bidsDto.Add(new BidDTO
                    {
                        Id = bid.Id,
                        FullName = user.FullName,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        AuctionDuration = product.AuctionDuration,
                        CategoryName = category.Name,
                        StartingPrice = product.StartingPrice,
                        BidAmount = bid.BidAmount,
                        CreatedAt = bid.CreatedAt       
                    });
                    response.Result = bidsDto;
                    response.Message = "Success";
                }
            }
            catch (Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;

        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ResponseDTO> GetAllBidsForUserId()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var userBids = await _bidService.GetBidsByUserId(userId);
                if (userBids == null)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "No Bids exist!";
                    return response;
                }
                var bidsDto = new List<BidDTO>();
                foreach (var bid in userBids)
                {
                    var user = await _authService.GetUserByIdAsync(userId);
                    var product = await _productService.GetProductByIdAsync(bid.Auction.ProductId);
                    var category = await _categoryService.GetCategoryById(bid.Auction.Product.CategoryId);  
                    bidsDto.Add(new BidDTO
                    {
                        Id = bid.Id,
                        FullName = user.FullName,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        AuctionDuration = product.AuctionDuration,
                        CategoryName = category.Name,   
                        StartingPrice = product.StartingPrice,  
                        BidAmount = bid.BidAmount,
                        CreatedAt = bid.CreatedAt
                    });
                    response.Result = bidsDto;
                    response.Message = "Success";
                }
            }
            catch (Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;
        }


        [Authorize(Roles ="User")]
        [HttpGet("Current-Highest/{productId:int}")]
        public async Task<ResponseDTO> GetCurrentHighestBid(int productId)
        {
            try
            {
                var auction = await _auctionService.GetAuctionByProductIdAsync(productId);
                if(auction != null)
                {
                    response.Result = new
                    {
                        ProductId = productId,
                        BidAmount = auction.CurrentHighestBid,
                        UserName = auction.FullName
                    };
                    response.Message = "Success";
                }
                else
                {
                    var product = await _productService.GetProductByIdAsync(productId);
                    response.Result = new
                    {
                        ProductId = productId,
                        BidAmount = product.StartingPrice,
                        UserName = ""
                    };
                    response.Message = "Current no higher bid exist.";
                }
            }
            catch (Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;
        }
     

        [Authorize(Roles = "User")]
        [HttpPost("Place-Bid/{productId:int}")]
        public async Task<ResponseDTO> PlaceBid(int productId,PlaceBidDTO placeBidDTO)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(productId);
                if (product == null) 
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "Product not exist for the bid";
                    return response;
                }
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var user = await _authService.GetUserByIdAsync(userId);
                if (user.IsBanned)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "The user has been suspended by the admin";
                    return response;
                }
                if(userId == product.UserId)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "You can't place a bid on your own product";
                    return response;
                }

                if(placeBidDTO.BidAmount <= product.StartingPrice)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.Message = "Bid must be greater than the starting price";
                    return response;
                }
                
                var auction = await _auctionService.GetAuctionByProductIdAsync(productId);
                
                if(auction == null)
                {
                    var newAuction = new Auction()
                    {
                        ProductId = productId,
                        Product = product,
                        FullName = user.FullName,
                        HighestBidUser = user,
                        HighestBidUserId = userId,
                        BidCount = 1,
                        CurrentHighestBid = placeBidDTO.BidAmount
                    };
                    var createdAuction = await _auctionService.CreateAuctionAsync(newAuction);
                    var bid = new Bid
                    {
                        Auction = createdAuction,
                        AuctionId = createdAuction.Id,
                        UserId = userId,
                        User = user,
                        BidAmount = placeBidDTO.BidAmount,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _bidService.PlaceBid(bid);
                    if(bid.BidAmount >= product.ReservedPrice)
                    {
                        product.BoughtByUserId = userId;
                        await _productService.UpdateProductAsync(product.Id, product);
                        response.Result = null;
                        response.Message = "Product purchased successfully";
                        return response;
                    }
                }
                else
                {
                    if(auction.CurrentHighestBid >= product.ReservedPrice)
                    {
                        response.Result = null;
                        response.Message = "Product has been sold";
                        return response;    
                    }
                    var bid = new Bid
                    {
                        Auction = auction,
                        AuctionId = auction.Id, 
                        UserId = userId,
                        User = user,
                        BidAmount = placeBidDTO.BidAmount,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _bidService.PlaceBid(bid);
                    if (bid.BidAmount >= product.ReservedPrice)
                    {
                        auction.CurrentHighestBid = bid.BidAmount;
                        auction.HighestBidUser = user;
                        auction.HighestBidUserId = userId;
                        product.BoughtByUserId = userId;
                        await _productService.UpdateProductAsync(product.Id, product);
                        auction.FullName = user.FullName;
                        auction.BidCount++;
                        await _auctionService.UpdateAuctionAsync(auction.Id, auction);
                        response.Result = null;
                        response.Message = "Product purchased successfully";
                        return response;
                    }
                    if(auction.CurrentHighestBid <  bid.BidAmount) 
                    {
                        auction.CurrentHighestBid = bid.BidAmount;  
                        auction.HighestBidUser = user;
                        auction.HighestBidUserId = userId;
                    }
                    auction.FullName = user.FullName;
                    auction.BidCount++;
                    await _auctionService.UpdateAuctionAsync(auction.Id, auction);
                }
                response.Result = true;
                response.Message = "Bid placed successfully";
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
