using Microsoft.EntityFrameworkCore;
using VenueEventsApi.Application.Interfaces;
using VenueEventsApi.Domain.Entities;
using VenueEventsApi.Infrastructure;

namespace VenueEventsApi.Application.Services
{
    public class VenueEventsService : IVenueEventsService
    {
        private readonly AppDbContext _dbContext;

        public VenueEventsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VenueEvent>> GetAllAsync()
        {
            return await _dbContext.Events!.ToListAsync();
        }

        public async Task<List<VenueEvent>> GetByVenue(int venueId)
        {
            return await _dbContext.Events!
                .Where(e => e.VenueId == venueId)
                .ToListAsync();
        }
    }
}
