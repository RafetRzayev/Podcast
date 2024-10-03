using Microsoft.AspNetCore.Mvc;
using Podcast.BLL.UI.Services.Contracts;

namespace Podcast.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _homeService.GetHomeViewModel();

            return  View(viewModel);
        }
    }
}
