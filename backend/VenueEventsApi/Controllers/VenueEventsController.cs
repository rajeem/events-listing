using Microsoft.AspNetCore.Mvc;
using VenueEventsApi.Application.Interfaces;
using VenueEventsApi.Domain.Entities;

namespace VenueEventsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueEventsController : ControllerBase
    {
        private readonly IVenueEventsService _venueEventsSvc;

        public VenueEventsController(IVenueEventsService venueEventsService)
        {
            _venueEventsSvc = venueEventsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueEvent>>> GetEventByVenue(int venueId)
        {
            return Ok(await _venueEventsSvc.GetByVenue(venueId));
        }
    }
}
