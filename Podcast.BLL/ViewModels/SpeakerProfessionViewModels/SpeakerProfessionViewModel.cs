using Podcast.BLL.ViewModels.ProfessionViewModels;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Podcast.BLL.ViewModels.SpeakerProfessionViewModels
{
    public class SpeakerProfessionViewModel : IViewModel
    {
        public int Id { get; set; }
        public SpeakerViewModel? Speaker { get; set; }
        public ProfessionViewModel? Profession { get; set; }
    }

    public class SpeakerProfessionCreateViewModel : IViewModel
    {
        public List<SelectListItem>? Speakers { get; set; }
        public int SpeakerId { get; set; }
        public List<SelectListItem>? Professions { get; set; }
        public int ProfessionId {  get; set; }
    }

    public class SpeakerProfessionUpdateViewModel : IViewModel
    {
        public int Id { get; set; }
        public List<SelectListItem>? Speakers { get; set; }
        public int SpeakerId { get; set; }
        public List<SelectListItem>? Professions { get; set; }
        public int ProfessionId { get; set; }
    }
}
