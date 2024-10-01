using Microsoft.EntityFrameworkCore;
using Podcast.DAL.DataContext;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Podcast.DAL.Repositories;

public class SpeakerRepository : EfCoreRepository<Speaker>, ISpeakerRepository
{
    private readonly AppDbContext _dbContext;

    public SpeakerRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Speaker OnlySpeaker()
    {
        throw new NotImplementedException();
    }

    public override async Task<IEnumerable<Speaker>> GetListAsync(Expression<Func<Speaker, bool>>? predicate = null)
    {
        IEnumerable<Speaker> speakerList;

        if (predicate == null)
        {
            speakerList = await _dbContext.Speakers
                          .Include(x => x.SpeakerProfessions!)
                          .ThenInclude(x => x.Profession).ToListAsync();

            return speakerList;
        }

        speakerList = await _dbContext.Speakers
                      .Include(x => x.SpeakerProfessions!)
                      .ThenInclude(x => x.Profession).Where(predicate)
                      .ToListAsync();

        return speakerList;
    }
}
