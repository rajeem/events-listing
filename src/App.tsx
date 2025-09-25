import Venues from "./Venues";
import data from "./data.json"

const formattedData = data.venues.map(venue => ({
  ...venue,
  events: data.events.filter(event => event.venueId === venue.id)
}));


function App() {
  return (
    <div className="flex flex-col mx-1">
      <header className="bg-white shadow-xs sticky top-0 min-h-50 mb-10 flex items-center justify-center border-b border-gray-200">
        <strong>Events Listings</strong>
      </header>
      <Venues venues={formattedData} />
    </div>
  );
}

export default App
