using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionApp.Domain.Models
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string FullName { get; set; }
        public decimal CurrentHighestBid { get; set; } = 0;

        [ForeignKey("HighestBidUserId")]
        public string HighestBidUserId { get; set; }
        public ApplicationUser HighestBidUser { get; set; }
        public int BidCount { get; set; } = 0;
        public ICollection<Bid> Bids { get; set; }
    }
}
