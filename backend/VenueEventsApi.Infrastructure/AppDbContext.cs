using Microsoft.EntityFrameworkCore;
using VenueEventsApi.Domain.Entities;

namespace VenueEventsApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Venue>? Venues { get; set; }
        public DbSet<VenueEvent>? Events { get; set; }
    }
}
