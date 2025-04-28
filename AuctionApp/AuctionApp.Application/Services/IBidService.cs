using AuctionApp.Domain.Models;

namespace AuctionApp.Application.Services
{
    public interface IBidService
    {
        Task<Bid> PlaceBid(Bid bid);
        Task<IEnumerable<Bid>> GetAllBidsAsync();
        Task<IEnumerable<Bid>> GetBidsByUserId(string userId);
       
    }
}
