using VenueEventsApi.Domain.Entities;

namespace VenueEventsApi.Application.Interfaces
{
    public interface IVenueEventsService
    {
        Task<List<VenueEvent>> GetAllAsync();
        Task<List<VenueEvent>> GetByVenue(int venueId);
    }
}
