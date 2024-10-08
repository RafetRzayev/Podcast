using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.SpeakerViewModels;

namespace Podcast.ADMIN.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly ISpeakerService _speakerService;
        private readonly IProfessionService _professionService;

        public SpeakerController(ISpeakerService speakerService, IProfessionService professionService)
        {
            _speakerService = speakerService;
            _professionService = professionService;
        }

        public async Task<IActionResult> Index()
        {
            var speakerList = await _speakerService.GetListAsync();

            return View(speakerList.ToList());
        }

        public async Task<IActionResult> Create()
        {
            var professionList = await _professionService.GetListAsync();
            var professionSelectListItems = new List<SelectListItem>();

            professionList.ToList().ForEach(x => professionSelectListItems.Add(new SelectListItem(x.Name, x.Id.ToString())));
            var createModel = new SpeakerCreateViewModel() { Name = "", ImageFile = null };
            createModel.Professions = professionSelectListItems;

            return View(createModel);            
        }
    }
}
