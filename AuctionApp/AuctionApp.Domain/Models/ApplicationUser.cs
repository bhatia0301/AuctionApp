using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsBanned { get; set; } = false;
        public string Role { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Bid> Bids { get; set; }
    }
}
