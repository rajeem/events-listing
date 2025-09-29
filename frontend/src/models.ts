export type Venue = {
    id?: number;
    name?: string;
    capacity?: number;
    location?: string;
    events: VenueEvent[];
}

export type VenueEvent = {
    id?: number;
    name?: string;
    startDate?: string;
    venueId?: number;
    description?: string;
}