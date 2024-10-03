using AutoMapper;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Speaker, SpeakerViewModel>()
            .ForMember(dest => dest.Professions, 
            opt => opt.MapFrom(src => src.SpeakerProfessions!.Select(sp => sp.Profession)))
            .ReverseMap();

        CreateMap<Speaker, SpeakerCreateViewModel>().ReverseMap();
        CreateMap<Speaker, SpeakerUpdateViewModel>().ReverseMap();


        CreateMap<Profession, ProfessionViewModel>().ReverseMap();
    }
}
