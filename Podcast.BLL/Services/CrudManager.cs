using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Podcast.BLL.Services;

public class CrudManager<TEntity, TViewModel> : ICrudService<TEntity, TViewModel> where TEntity : Entity
    where TViewModel : IViewModel
{
    private readonly IRepositoryAsync<TEntity> _repository;
    private readonly IMapper _mapper;

    public CrudManager(IRepositoryAsync<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TViewModel?> GetAsync(int id)
    {
        var entity = await _repository.GetAsync(id);

        var viewModel = _mapper.Map<TViewModel>(entity);

        return viewModel;
    }

    public Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        throw new NotImplementedException();
    }
}
