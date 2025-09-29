import { useState } from "react";
import type { Venue, VenueEvent } from "./models";
import EventCard from "./EventCard";
import { API_URL } from "./config";

function Venues({ venues }: { venues: Venue[] }) {
    const [selectedVenue, setSelectedVenue] = useState<Venue | null>(null);
    const [events, setEvents] = useState<VenueEvent[] | null>(null);
    const [selectedEvent, setSelectedEvent] = useState<VenueEvent | null>(null);

    const handleVenueClick = (venue: Venue) => {
        fetch(API_URL + "/api/venueevents?venueId=" + venue.id)
              .then(res => res.json())
              .then(data => setEvents(data))
              .catch(err => console.error(err));
        setSelectedVenue(venue);
        setSelectedEvent(null);
    };

    return (
        <div className="flex flex-1">
            <aside className="w-40 bg-gray-800 text-white p-4">
                <ul>
                    {venues.map((venue) => (
                        <li key={venue.id}>
                            <button className="block hover:bg-gray-700 p-2 rounded" onClick={() => handleVenueClick(venue)}>
                                {(venue.id === selectedVenue?.id) && "➤ "}
                                {venue.name}
                            </button>
                        </li>
                    ))}
                </ul>
            </aside>

            <main className="flex-1 p-6 bg-gray-100">
                <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
                    {events && events.map((event) =>
                        (<EventCard key={event.id} event={event} handleEventClick={() => setSelectedEvent(event)} />))}
                </div>
            </main>

            {selectedEvent && (
                <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white rounded-lg shadow-lg p-6 w-80">
                        <h2 className="text-xl font-bold mb-4">{selectedEvent.name}</h2>
                        <p className="text-gray-600 mb-6">
                            Date: {(new Date(selectedEvent.startDate!)).toLocaleDateString()}
                        </p>
                        <p className="text-gray-600 mb-6">
                            Venue: {selectedVenue?.name}
                        </p>
                        <p className="text-gray-600 mb-6">
                            Address: {selectedVenue?.location}
                        </p>
                        <p className="text-gray-600 mb-6">
                            Description: {selectedEvent?.description || "No description available."}
                        </p>
                        <div className="flex justify-end space-x-2">
                            <button
                                onClick={() => setSelectedEvent(null)}
                                className="px-4 py-2 bg-gray-300 rounded"
                            >
                                Close
                            </button>
                        </div>
                    </div>
                </div>
            )}

        </div>);
}

export default Venues;