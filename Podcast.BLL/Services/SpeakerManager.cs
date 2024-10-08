using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Podcast.BLL.Services;

public class SpeakerManager : CrudManager<Speaker, SpeakerViewModel, SpeakerCreateViewModel, SpeakerUpdateViewModel>, ISpeakerService
{
    private readonly IRepositoryAsync<Speaker> _repository;
    private readonly IProfessionService _professionService;
    private readonly ICloudinaryService _cloudinaryService;

    private readonly IMapper _mapper;

    public SpeakerManager(IRepositoryAsync<Speaker> repository, IMapper mapper, IProfessionService professionService, ICloudinaryService cloudinaryService) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _professionService = professionService;
        _cloudinaryService = cloudinaryService;
    }

    public override Task<SpeakerViewModel?> GetAsync(Expression<Func<Speaker, bool>> predicate, Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null, Func<IQueryable<Speaker>, IOrderedQueryable<Speaker>>? orderBy = null)
    {
        return base.GetAsync(predicate, include, orderBy);
    }

    public async Task<SpeakerCreateViewModel> GetSpeakerCreateViewModelAsync(SpeakerCreateViewModel createModel)
    {
        var professionList = await _professionService.GetListAsync();
        var professionSelectListItems = new List<SelectListItem>();

        professionList.ToList().ForEach(x => professionSelectListItems.Add(new SelectListItem(x.Name, x.Id.ToString())));
        createModel.Professions = professionSelectListItems;
        
        return createModel;
    }


    public override async Task<SpeakerViewModel> CreateAsync(SpeakerCreateViewModel createViewModel)
    {
        var speakerEntity = _mapper.Map<Speaker>(createViewModel);

        var createImageUrl = await _cloudinaryService.FileCreateAsync(createViewModel.ImageFile);
        speakerEntity.ImageUrl = createImageUrl;

        var createdSpeaker = await _repository.CreateAsync(speakerEntity);

        return _mapper.Map<SpeakerViewModel>(createdSpeaker);
    }

    public async override Task<SpeakerViewModel> UpdateAsync(SpeakerUpdateViewModel updateViewModel)
    {
        var speakerEntity = _mapper.Map<Speaker>(updateViewModel);

        var speakerProfessions = new List<SpeakerProfession>();

        foreach (var professionId in updateViewModel.ProfessionIds ?? [])
        {
            speakerProfessions.Add(new SpeakerProfession { ProfessionId = professionId });
        }

        speakerEntity.SpeakerProfessions = speakerProfessions;

        var updatedSpeaker = await _repository.UpdateAsync(speakerEntity);

        return _mapper.Map<SpeakerViewModel>(updatedSpeaker);
    }
}