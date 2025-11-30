using Models;
using System.Collections.Generic;
using System.Linq;

namespace Services;

public class AirportService

    private readonly List<Airport> _airports = new();

    public void Initialize(IEnumerable<Airport>? airports)
    {
        _airports.Clear();

        if (airports != null)
            _airports.AddRange(airports);
    }

    public IEnumerable<Airport> GetAllAirports() => _airports;

    public IEnumerable<Airport> Search(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Enumerable.Empty<Airport>();

        input = input.Trim().ToLower();

        return _airports.Where(a =>
           a.Code.ToLower().Contains(input) ||
           a.City.ToLower().Contains(input) ||
           a.Name.ToLower().Contains(input) ||
           a.Country.ToLower().Contains(input)
        );
    }

    public Airport? Find(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        input = input.Trim().ToLower();

        return _airports.FirstOrDefault(a =>
            a.Code.ToLower() == input ||
            a.City.ToLower() == input ||
            a.Name.ToLower() == input
        );
    }
}
