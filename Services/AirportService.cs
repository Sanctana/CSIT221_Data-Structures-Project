using System.Collections.Generic;
using Models;

namespace Services
{
    public class AirportService
    {
        private readonly List<Airport> _airports = new()
        {
            new Airport("LAX", "Los Angeles", "USA"),
            new Airport("JFK", "New York", "USA"),
            new Airport("SFO", "San Francisco", "USA"),
            new Airport("ORD", "Chicago", "USA"),
            new Airport("MNL", "Manila", "Philippines"),
            new Airport("CEB", "Cebu", "Philippines"),
            new Airport("DXB", "Dubai", "UAE"),
            new Airport("NRT", "Tokyo Narita", "Japan"),
            new Airport("HND", "Tokyo Haneda", "Japan"),
            new Airport("ICN", "Seoul Incheon", "South Korea")
        };

        public IEnumerable<Airport> GetAllAirports() => _airports;
    }
}
