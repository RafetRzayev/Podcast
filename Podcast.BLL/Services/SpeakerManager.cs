using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Podcast.BLL.Services;

public class SpeakerManager : CrudManager<Speaker, SpeakerViewModel>, ISpeakerService
{
    private readonly ISpeakerRepository _repository;

    public SpeakerManager(ISpeakerRepository repository, IRepositoryAsync<Speaker> repository1, IMapper mapper) : base(repository1, mapper)
    {
        _repository = repository;
    }

    public async Task<SpeakerViewModel?> GetSpeakerAsync(Expression<Func<Speaker, bool>>? predicate = null, Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null, Func<IQueryable<Speaker>, IOrderedQueryable<Speaker>>? orderBy = null)
    {
        var speakerEntity = await _repository.GetAsync(predicate, include, orderBy);

        if (speakerEntity == null) throw new Exception("Not found");

        var speakerViewModel = new SpeakerViewModel
        {
            Id = speakerEntity.Id,
            Name = speakerEntity.Name,
            ImageUrl = speakerEntity.ImageUrl,
        };

        var professions = new List<ProfessionViewModel>();

        foreach (var speakerProfession in speakerEntity.SpeakerProfessions ?? [])
        {
            professions.Add(new ProfessionViewModel
            {
                Id = speakerProfession.ProfessionId,
                Name = speakerProfession.Profession?.Name
            });
        }

        speakerViewModel.Professions = professions;
        
        return speakerViewModel;
    }

    public async Task<IEnumerable<SpeakerViewModel>> GetSpeakerListAsync(Expression<Func<Speaker, bool>>? predicate = null, Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null, Func<IQueryable<Speaker>, IOrderedQueryable<Speaker>>? orderBy = null)
    {
        var speakerEntityList = await _repository.GetListAsync(predicate, include, orderBy);
        var speakerViewModelList = new List<SpeakerViewModel>();

        foreach (var speakerEntity in speakerEntityList)
        {
            var speakerViewModel = new SpeakerViewModel
            {
                Id = speakerEntity.Id,
                Name = speakerEntity.Name,
                ImageUrl = speakerEntity.ImageUrl,
            };

            var professions = new List<ProfessionViewModel>();

            foreach (var speakerProfession in speakerEntity.SpeakerProfessions ?? [])
            {
                professions.Add(new ProfessionViewModel
                {
                    Id = speakerProfession.ProfessionId,
                    Name = speakerProfession.Profession?.Name
                });
            }

            speakerViewModel.Professions = professions;
            speakerViewModelList.Add(speakerViewModel);
        }

        return speakerViewModelList;
    }

    public Task<SpeakerViewModel> CreateAsync(Speaker entity)
    {
        throw new NotImplementedException();
    }

    public Task<SpeakerViewModel> RemoveAsync(Speaker entity)
    {
        throw new NotImplementedException();
    }

    public Task<SpeakerViewModel> UpdateAsync(Speaker entity)
    {
        throw new NotImplementedException();
    }
}
