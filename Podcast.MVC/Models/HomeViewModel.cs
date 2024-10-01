using Podcast.DAL.DataContext.Entities;

namespace Podcast.MVC.Models;

public class HomeViewModel
{
    public List<Speaker> Speakers { get; set; } = [];
    public List<Profession> Professions { get; set; } = [];
}
