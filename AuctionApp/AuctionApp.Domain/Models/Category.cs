using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
