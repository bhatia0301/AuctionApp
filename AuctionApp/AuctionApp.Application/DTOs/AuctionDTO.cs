namespace AuctionApp.Application.DTOs
{
    public class AuctionDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal CurrentHighestBid { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int AuctionDuration { get; set; }
        public string CategoryName { get; set; }
        public string ProductImage { get; set; }
        public int BidCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
    }
}
