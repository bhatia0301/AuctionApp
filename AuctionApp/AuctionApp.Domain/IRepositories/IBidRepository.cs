using AuctionApp.Domain.Models;

namespace AuctionApp.Domain.IRepositories
{
    public interface IBidRepository
    {
        Task<Bid> AddBid(Bid bid);
        Task<IEnumerable<Bid>> GetAllBidsAsync();
        Task<IEnumerable<Bid>> GetBidsByUserId(string userId);
      
    }
}
