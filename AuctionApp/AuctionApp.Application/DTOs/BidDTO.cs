namespace AuctionApp.Application.DTOs
{
    public class BidDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal StartingPrice { get; set; }
        public int AuctionDuration { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal BidAmount { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
