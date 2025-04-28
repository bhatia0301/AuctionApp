using AuctionApp.Domain.IRepositories;
using AuctionApp.Domain.Models;
using AuctionApp.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Infrastructure.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AuctionDbContext _context;
        public BidRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<Bid> AddBid(Bid bid)
        {
            await _context.Bids.AddAsync(bid);      
            await _context.SaveChangesAsync();
            return bid;
            
        }

        public async Task<IEnumerable<Bid>> GetAllBidsAsync()
        {
            return await _context.Bids
                        .Include(a => a.Auction)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetBidsByUserId(string userId)
        {
            return await _context.Bids.Where(x => x.UserId == userId)
                .Include(a => a.Auction)
                .ToListAsync();    
        }

     
    }
}
