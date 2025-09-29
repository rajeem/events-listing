import type { VenueEvent } from "./models";

function EventCard({ event, handleEventClick }: { event: VenueEvent, handleEventClick: (event: VenueEvent) => void }) {
    return <div className="bg-white p-4 rounded-lg shadow">
        <h2 className="font-semibold mb-2">{event.name}</h2>
        <p className="text-gray-600">{(new Date(event.startDate!)).toLocaleDateString()}</p>
        <button onClick={() => handleEventClick(event)} className="bg-blue-500 text-white px-3 py-1 mt-4 rounded">
            View Details
        </button>
    </div>;
}

export default EventCard;