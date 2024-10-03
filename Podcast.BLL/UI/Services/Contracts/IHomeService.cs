using Podcast.BLL.UI.ViewModels;

namespace Podcast.BLL.UI.Services.Contracts;

public interface IHomeService
{
    Task<HomeViewModel> GetHomeViewModel();
}
