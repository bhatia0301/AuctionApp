using AuctionApp.Domain.Models;

namespace AuctionApp.Application.Services
{
    public interface IAuctionService
    {
        Task<Auction> CreateAuctionAsync(Auction auction);
        Task<Auction> GetAuctionByProductIdAsync(int productId);
        Task<Auction> GetAuctionByIdAsync(int auctionId);
        Task<IEnumerable<Auction>> GetAllAuctionsAsync();
        Task<IEnumerable<Auction>> GetAuctionsByUserIdAsync(string userId);
        Task UpdateAuctionAsync(int id, Auction auction);
        Task<bool> DeleteAuctionAsync(int auctionId); 

    }
}
