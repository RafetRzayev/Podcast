using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podcast.BLL.ViewModels.ProfessionViewModels;

namespace Podcast.BLL.ViewModels.SpeakerViewModels
{
    public class SpeakerViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }

        public List<ProfessionViewModel>? Professions { get; set; }
    }

    public class SpeakerCreateViewModel : IViewModel
    {
        public required string Name { get; set; }
        public required IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }
        public List<SelectListItem>? Professions { get; set; }
        public int[]? ProfessionIds { get; set; }
    }

    public class SpeakerUpdateViewModel : IViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }
        public List<SelectListItem>? Professions { get; set; }
        public int[]? ProfessionIds { get; set; }

    }
}
