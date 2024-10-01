using Podcast.DAL.DataContext.Entities;
using System.Linq.Expressions;

namespace Podcast.DAL.Repositories.Contracts;

public interface IRepositoryAsync<T> where T : Entity
{
    Task<T?> GetAsync(int id);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> RemoveAsync(T entity);
}
