using AutoMapper;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Speaker, SpeakerViewModel>().ReverseMap();
    }
}
