using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.ViewModels;
using Podcast.DAL.DataContext.Entities;
using System.Linq.Expressions;

namespace Podcast.BLL.Services.Contracts;

public interface ICrudService<TEntity, TViewModel> 
    where TEntity : Entity 
    where TViewModel : IViewModel
{
    Task<TViewModel?> GetAsync(int id);

    Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>>? predicate = null,
                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
}
