import { useEffect, useState } from "react";
import Venues from "./Venues";
import { API_URL } from "./config";


function App() {

  const [venues, setEvents] = useState([]);

  useEffect(() => {
    console.log(venues);
    fetch(API_URL + "/api/venues")
      .then(res => res.json())
      .then(data => setEvents(data))
      .catch(err => console.error(err));
    
  }, []);

  return (
    <div className="flex flex-col mx-1">
      <header className="bg-white shadow-xs sticky top-0 min-h-50 mb-10 flex items-center justify-center border-b border-gray-200">
        <strong>Events Listings</strong>
      </header>
      <Venues venues={venues} />
    </div>
  );
}

export default App
