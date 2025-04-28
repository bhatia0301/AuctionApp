using AuctionApp.Domain.Models;

namespace AuctionApp.Domain.IRepositories
{
    public interface IAuctionRepository
    {
        Task<Auction> AddAuctionAsync(Auction auction);
        Task<Auction> GetAuctionByProductId(int productId);
        Task<IEnumerable<Auction>> GetAllAuctionsAsync();
        Task<IEnumerable<Auction>> GetAuctionsByUserIdAsync(string userId);
        Task<bool> UpdateAuction(int id, Auction auction); // Changed to return bool for consistency
        Task<Auction> GetAuctionById(int auctionId);
        Task<bool> DeleteAuctionAsync(int auctionId);
    }

}
