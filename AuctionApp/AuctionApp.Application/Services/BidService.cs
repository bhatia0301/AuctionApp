using AuctionApp.Domain.IRepositories;
using AuctionApp.Domain.Models;

namespace AuctionApp.Application.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;
        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        public async Task<IEnumerable<Bid>> GetAllBidsAsync()
        {
            var bids = await _bidRepository.GetAllBidsAsync();
            return bids;
        }

        public async Task<IEnumerable<Bid>> GetBidsByUserId(string userId)
        {
            var userBids = await _bidRepository.GetBidsByUserId(userId);
            return userBids;    
        }

      

        public async Task<Bid> PlaceBid(Bid bid)
        {
            var createdBid = await _bidRepository.AddBid(bid);
            return createdBid;
        }
    }
}
