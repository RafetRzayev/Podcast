using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.MVC.Models;

public class HomeViewModel
{
    public List<SpeakerViewModel> Speakers { get; set; } = [];
    public List<Profession> Professions { get; set; } = [];
}
