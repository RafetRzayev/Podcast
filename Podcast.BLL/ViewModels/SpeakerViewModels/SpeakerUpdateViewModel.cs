using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Podcast.BLL.ViewModels.SpeakerViewModels;

public class SpeakerUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ImageUrl { get; set; }
    public List<SelectListItem>? Professions { get; set; }
    public int[]? ProfessionIds { get; set; }

}
