using VenueEventsApi.Domain.Entities;

namespace VenueEventsApi.Application.Interfaces
{
    public interface IVenuesService
    {
        Task<List<Venue>> GetAllAsync();
    }
}
