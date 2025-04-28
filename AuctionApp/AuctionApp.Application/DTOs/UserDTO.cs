namespace AuctionApp.Application.DTOs
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBanned { get; set; }
    }
}
