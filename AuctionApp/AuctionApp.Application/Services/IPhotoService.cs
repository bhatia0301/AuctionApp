using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace AuctionApp.Application.Services
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> UploadPhotoAsync(IFormFile file);
    }
}
