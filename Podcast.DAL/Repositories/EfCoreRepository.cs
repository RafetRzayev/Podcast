using Microsoft.EntityFrameworkCore;
using Podcast.DAL.DataContext;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Podcast.DAL.Repositories;

public class EfCoreRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : Entity
{
    private readonly AppDbContext _dbContext;

    public EfCoreRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<TEntity?> GetAsync(int id)
    {
       var result = await _dbContext.Set<TEntity>().FindAsync(id);

        return result;
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
       var result = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);

        return result;
    }

    public virtual async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (predicate == null)
            return await _dbContext.Set<TEntity>().ToListAsync();

        var result = await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();

        return result;
    }

    public virtual Task<TEntity> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity> RemoveAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
