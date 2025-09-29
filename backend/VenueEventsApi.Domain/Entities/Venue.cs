using System.Text.Json.Serialization;

namespace VenueEventsApi.Domain.Entities
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Capacity { get; set; }
        public string Location { get; set; } = "";
        [JsonIgnore]
        public ICollection<VenueEvent>? Events { get; set; }
    }
}
