using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Podcast.BLL.Services;

public class ProfessionManager : IProfessionService
{
    private readonly IRepositoryAsync<Profession> _professionRepository;

    public ProfessionManager(IRepositoryAsync<Profession> professionRepository)
    {
        _professionRepository = professionRepository;
    }

    public async Task<ProfessionViewModel?> GetProfessionAsync(int id)
    {
        var professionEntity = await _professionRepository.GetAsync(id);

        if (professionEntity == null) throw new Exception("Not found");

        var professionViewModel = new ProfessionViewModel
        {
            Id = professionEntity.Id,
            Name = professionEntity.Name,
        };

        return professionViewModel;
    }

    public Task<ProfessionViewModel?> GetProfessionAsync(Expression<Func<Profession, bool>>? predicate = null, Func<IQueryable<Profession>, IIncludableQueryable<Profession, object>>? include = null, Func<IQueryable<Profession>, IOrderedQueryable<Profession>>? orderBy = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProfessionViewModel>> GetProfessionListAsync(Expression<Func<Profession, bool>>? predicate = null, Func<IQueryable<Profession>, IIncludableQueryable<Profession, object>>? include = null, Func<IQueryable<Profession>, IOrderedQueryable<Profession>>? orderBy = null)
    {
        throw new NotImplementedException();
    }
}
