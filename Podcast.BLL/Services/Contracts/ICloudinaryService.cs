using Microsoft.AspNetCore.Http;

namespace Podcast.BLL.Services.Contracts
{
    public interface ICloudinaryService
    {
        Task<string> FileCreateAsync(IFormFile file);
    }
}
