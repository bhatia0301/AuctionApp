namespace AuctionApp.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public int AuctionDuration { get; set; }
        public string CategoryName { get; set; }
        public decimal ReservedPrice { get; set; }
        public string ProductImage { get; set; }
        public string BoughtByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
