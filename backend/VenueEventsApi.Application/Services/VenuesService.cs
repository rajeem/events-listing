using Microsoft.EntityFrameworkCore;
using VenueEventsApi.Application.Interfaces;
using VenueEventsApi.Domain.Entities;
using VenueEventsApi.Infrastructure;

namespace VenueEventsApi.Application.Services
{
    public class VenuesService : IVenuesService
    {
        private readonly AppDbContext _dbContext;

        public VenuesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Venue>> GetAllAsync()
        {
            return await _dbContext.Venues!.ToListAsync();
        }
    }
}
