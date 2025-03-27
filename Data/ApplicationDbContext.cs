using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripOrganization.Models;

namespace TripOrganization.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<TripOrganization.Models.Trip> Trip { get; set; } = default!;
public DbSet<TripOrganization.Models.TripUser> TripUser {get;set;} = default!;

protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite key for the join entity
            modelBuilder.Entity<TripUser>()
                .HasKey(tu => new { tu.TripId, tu.UserId });
        }
}

