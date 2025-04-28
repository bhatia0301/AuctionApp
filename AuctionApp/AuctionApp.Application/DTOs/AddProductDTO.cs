using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Application.DTOs
{
    public class AddProductDTO
    {
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(100, ErrorMessage = "Product Name can't be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Starting Price is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Starting Price must be a positive value")]
        public decimal StartingPrice { get; set; }

        [Required(ErrorMessage = "Auction Duration is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Auction Duration must be at least 1 hour")]
        public int AuctionDuration { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Reserved Price is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Reserved Price must be a positive value")]
        public decimal ReservedPrice { get; set; }

        [Required(ErrorMessage = "Product Image is required")]
        public IFormFile ProductImage { get; set; }
    }

}
