using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Application.DTOs
{
    public class PlaceBidDTO
    {
        [Required(ErrorMessage = "Bid amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Bid amount must be greater than zero.")]
        public decimal BidAmount { get; set; }
    }
}
