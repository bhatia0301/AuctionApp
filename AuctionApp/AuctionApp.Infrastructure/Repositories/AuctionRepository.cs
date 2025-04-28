using AuctionApp.Domain.IRepositories;
using AuctionApp.Domain.Models;
using AuctionApp.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Infrastructure.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _context;
        public AuctionRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<Auction> AddAuctionAsync(Auction auction)
        {
            await _context.Auctions.AddAsync(auction);
            await _context.SaveChangesAsync();
            return auction;
        }

        public async Task<bool> DeleteAuctionAsync(int auctionId)
        {
            var auction = await _context.Auctions
                                        .Include(b => b.Bids)
                                        .FirstOrDefaultAsync(x => x.Id == auctionId);

            if (auction == null) return false;

            await DeleteAuctionBidsAsync(auction);
            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task DeleteAuctionBidsAsync(Auction auction)
        {
            if (auction.Bids?.Any() == true)
            {
                _context.Bids.RemoveRange(auction.Bids);
            }
        }

        public async Task<IEnumerable<Auction>> GetAllAuctionsAsync()
        {
            return await _context.Auctions
                                 .Include(b => b.Bids)
                                 .ToListAsync();
        }

        public async Task<Auction> GetAuctionById(int auctionId)
        {
            return await _context.Auctions
                                 .Include(b => b.Bids)
                                 .FirstOrDefaultAsync(x => x.Id == auctionId);
        }

        public async Task<Auction> GetAuctionByProductId(int productId)
        {
            return await _context.Auctions
                                 .Include(b => b.Bids)
                                 .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<IEnumerable<Auction>> GetAuctionsByUserIdAsync(string userId)
        {
            return await _context.Auctions
                                 .Where(a => a.HighestBidUserId == userId)
                                 .Include(a => a.Bids)
                                 .ToListAsync();
        }

        public async Task<bool> UpdateAuction(int id, Auction auction)
        {
            if (await _context.Auctions.AnyAsync(a => a.Id == id))
            {
                _context.Auctions.Update(auction);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
