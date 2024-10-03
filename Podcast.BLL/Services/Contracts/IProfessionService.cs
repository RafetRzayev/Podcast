using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;
using System.Linq.Expressions;

namespace Podcast.BLL.Services.Contracts;

public interface IProfessionService
{
    Task<ProfessionViewModel?> GetProfessionAsync(int id);
    Task<ProfessionViewModel?> GetProfessionAsync(Expression<Func<Profession, bool>>? predicate = null,
                                                  Func<IQueryable<Profession>, IIncludableQueryable<Profession, object>>? include = null,
                                                  Func<IQueryable<Profession>, IOrderedQueryable<Profession>>? orderBy = null);
    Task<IEnumerable<ProfessionViewModel>> GetProfessionListAsync(Expression<Func<Profession, bool>>? predicate = null,
                                                                  Func<IQueryable<Profession>, IIncludableQueryable<Profession, object>>? include = null,
                                                                  Func<IQueryable<Profession>, IOrderedQueryable<Profession>>? orderBy = null);
}
