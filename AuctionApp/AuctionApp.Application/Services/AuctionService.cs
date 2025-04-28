using AuctionApp.Domain.IRepositories;
using AuctionApp.Domain.Models;

namespace AuctionApp.Application.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        public async Task<Auction> CreateAuctionAsync(Auction auction)
        {
            var createdAuction = await _auctionRepository.AddAuctionAsync(auction);
            return createdAuction;
        }

        public Task<bool> DeleteAuctionAsync(int auctionId)
        {
            return _auctionRepository.DeleteAuctionAsync(auctionId);        
        }

        public async Task<IEnumerable<Auction>> GetAllAuctionsAsync()
        {
            return await _auctionRepository.GetAllAuctionsAsync();  
        }

        public async Task<Auction> GetAuctionByIdAsync(int auctionId)
        {
            return await _auctionRepository.GetAuctionById(auctionId);
        }

        public async Task<Auction> GetAuctionByProductIdAsync(int productId)
        {
            return await _auctionRepository.GetAuctionByProductId(productId);
        }

        public async Task<IEnumerable<Auction>> GetAuctionsByUserIdAsync(string userId)
        {
            return await _auctionRepository.GetAuctionsByUserIdAsync(userId);
        }

        public async Task UpdateAuctionAsync(int id, Auction auction)
        {
            await _auctionRepository.UpdateAuction(id, auction);
        }
    }
}
