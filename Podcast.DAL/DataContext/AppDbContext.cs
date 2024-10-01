using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.DAL.DataContext;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
    {
        
    }

    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<SpeakerProfession> SpeakerProfessions { get; set; }
}
