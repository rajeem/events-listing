using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenueEventsApi.Application.Interfaces;
using VenueEventsApi.Domain.Entities;
using VenueEventsApi.Infrastructure;

namespace VenueEventsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly IVenuesService _venuesSvc;

        public VenuesController(IVenuesService venuesSvc)
        {
            _venuesSvc = venuesSvc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
        {
            return Ok(await _venuesSvc.GetAllAsync());
        }
    }
}
