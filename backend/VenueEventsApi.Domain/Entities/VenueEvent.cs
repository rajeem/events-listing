namespace VenueEventsApi.Domain.Entities
{
    public class VenueEvent
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime StartDate { get; set; }
        public int VenueId { get; set; }
        public Venue? Venue { get; set; }
        public string Description { get; set; } = "";
    }
}
