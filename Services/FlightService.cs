using Models;
using Utilities;

namespace Services;

using System.Collections;
public class FlightService : IEnumerable<Flight>
{
    private readonly ArrayList<Flight> _flights = new();

    public void Initialize(IEnumerable<Flight>? flights)
    {
        if (flights == null) return;

        foreach (var flight in flights)
        {
            _flights.AddLast(flight);
        }
    }

    public Flight GetFlightById(int id)
    {
        foreach (var flight in _flights)
        {
            if (flight.Id == id)
            {
                return flight;
            }
        }

        throw new KeyNotFoundException($"Flight with ID {id} not found.");
    }

    public IEnumerable<string> SuggestTo(string from, string prefix) =>
        _flights
            .Where(f => f.From.Equals(from, StringComparison.OrdinalIgnoreCase))
            .Select(f => f.To)
            .Where(t => t.StartsWith(prefix ?? string.Empty, StringComparison.OrdinalIgnoreCase))
            .Distinct(StringComparer.OrdinalIgnoreCase);

    public IEnumerable<string> SuggestFrom(string prefix) =>
        _flights
            .Select(f => f.From)
            .Where(t => t.StartsWith(prefix ?? string.Empty, StringComparison.OrdinalIgnoreCase))
            .Distinct(StringComparer.OrdinalIgnoreCase);

    IEnumerator<Flight> IEnumerable<Flight>.GetEnumerator() => _flights.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _flights.GetEnumerator();

    public IEnumerable<Flight> SearchFlights(string from, string to, DateTime travelDate, int passengerCount) =>
        _flights.Where(f =>
            f.From.Equals(from, StringComparison.OrdinalIgnoreCase) &&
            f.To.Equals(to, StringComparison.OrdinalIgnoreCase) &&
            f.Departure.Date == travelDate.Date &&
            f.SeatsAvailable >= passengerCount);
    
}