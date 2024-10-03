using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;
using System.Linq.Expressions;

namespace Podcast.BLL.Services.Contracts;

public interface ISpeakerService : ICrudService<Speaker, SpeakerViewModel>
{
    Task<SpeakerViewModel?> GetSpeakerAsync(
                      Expression<Func<Speaker, bool>>? predicate = null,
                      Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null,
                      Func<IQueryable<Speaker>, IOrderedQueryable<Speaker>>? orderBy = null);
    Task<IEnumerable<SpeakerViewModel>> GetSpeakerListAsync(
                                      Expression<Func<Speaker, bool>>? predicate = null,
                                      Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null,
                                      Func<IQueryable<Speaker>, IOrderedQueryable<Speaker>>? orderBy = null);
    Task<SpeakerViewModel> CreateAsync(Speaker entity);
    Task<SpeakerViewModel> UpdateAsync(Speaker entity);
    Task<SpeakerViewModel> RemoveAsync(Speaker entity);
}
