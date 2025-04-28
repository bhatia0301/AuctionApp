using AuctionApp.Domain.Models;

namespace AuctionApp.Domain.IRepositories
{
    public interface IAuthRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<bool> UpdateUserAsync(ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(string roleName);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}
