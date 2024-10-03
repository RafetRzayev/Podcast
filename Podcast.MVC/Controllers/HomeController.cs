using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Podcast.BLL.Services.Contracts;
using Podcast.DAL.Repositories.Contracts;
using Podcast.MVC.Models;

namespace Podcast.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpeakerRepository _speakerRepository;
        private readonly ISpeakerService _speakerService;

        public HomeController(ISpeakerRepository speakerRepository, ISpeakerService speakerService)
        {
            _speakerRepository = speakerRepository;
            _speakerService = speakerService;
        }

        public async Task<IActionResult> Index()
        {
            var speaker = await _speakerService.GetAsync(1);

            return Json(speaker);

            //var speakerList = await _speakerRepository.GetListAsync(include: x => x.Include(y => y.SpeakerProfessions!).ThenInclude(z => z.Profession!),
            //    orderBy: x => x.OrderBy(y => y.Name));

            var speakerList = await _speakerService.GetSpeakerListAsync(include: x => x.Include(y => y.SpeakerProfessions!).ThenInclude(z => z.Profession!),
                orderBy: x => x.OrderBy(y => y.Name));

            var homeViewModel = new HomeViewModel()
            {
                Speakers = speakerList.ToList()
            };

            return  View(homeViewModel);
        }
    }
}
