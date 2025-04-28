using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionApp.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public int AuctionDuration { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal ReservedPrice { get; set; }
        public string ProductImage { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string BoughtByUserId { get; set; } = "";
        public DateTime CreatedAt { get; set; }

    }
}
