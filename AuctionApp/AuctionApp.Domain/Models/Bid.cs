using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionApp.Domain.Models
{
    public class Bid
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AuctionId")]
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
