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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Speaker>().HasData(
        [
            new Speaker { Id = 1, Name = "Chan", ImageUrl = "1.jpg" },
            new Speaker { Id = 2, Name = "Elise", ImageUrl = "2.jpg" },
            new Speaker { Id = 3, Name = "William", ImageUrl = "3.jpg" },
            new Speaker { Id = 4, Name = "Aqil", ImageUrl = "4.jpg" },
            new Speaker { Id = 5, Name = "Sebuhi", ImageUrl = "5.jpg" },
            new Speaker { Id = 6, Name = "Rizvan", ImageUrl = "5.jpg" },
        ]);

        builder.Entity<Profession>().HasData(
        [
            new Profession { Id = 1, Name = "Education" },
            new Profession { Id = 2, Name = "Artist" },
            new Profession { Id = 3, Name = "Influencer" },
            new Profession { Id = 4, Name = "Makler" },
        ]);

        builder.Entity<SpeakerProfession>().HasData(
        [
            new SpeakerProfession { Id = 1, SpeakerId = 1, ProfessionId = 1 },
            new SpeakerProfession { Id = 2, SpeakerId = 2, ProfessionId = 2 },
            new SpeakerProfession { Id = 3, SpeakerId = 3, ProfessionId = 3 },
            new SpeakerProfession { Id = 4, SpeakerId = 4, ProfessionId = 4 },
            new SpeakerProfession { Id = 5, SpeakerId = 5, ProfessionId = 4 },
            new SpeakerProfession { Id = 6, SpeakerId = 1, ProfessionId = 3 },
        ]);

        base.OnModelCreating(builder);
    }
}