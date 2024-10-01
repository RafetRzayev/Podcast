using Microsoft.AspNetCore.Mvc;
using Podcast.DAL.Repositories.Contracts;
using Podcast.MVC.Models;

namespace Podcast.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpeakerRepository _speakerRepository;

        public HomeController(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var speakerList = await _speakerRepository.GetListAsync();

            var homeViewModel = new HomeViewModel()
            {
                Speakers = speakerList.ToList()
            };

            return  View(homeViewModel);
        }
    }
}
