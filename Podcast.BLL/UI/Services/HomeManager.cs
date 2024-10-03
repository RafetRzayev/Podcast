using Microsoft.EntityFrameworkCore;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.UI.Services.Contracts;
using Podcast.BLL.UI.ViewModels;

namespace Podcast.BLL.UI.Services
{
    public class HomeManager : IHomeService
    {
        private readonly ISpeakerService _speakerService;

        public HomeManager(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        public async Task<HomeViewModel> GetHomeViewModel()
        {
            var speakerList = await _speakerService.GetListAsync(include: x => x.Include(y => y.SpeakerProfessions!).ThenInclude(z => z.Profession!));

            var viewModel = new HomeViewModel
            {
                Speakers = speakerList.ToList(),
            };

            return viewModel;
        }
    }
}
