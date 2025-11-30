using Models;
using System.Collections.Generic;
using System.Linq;

namespace Services;

public class AirportService
{
    private readonly List<Airport> _airports = new();

    // === FIX: Add Initialize() ===
    public void Initialize(IEnumerable<Airport>? airports)
    {
        _airports.Clear();
        if (airports != null)
            _airports.AddRange(airports);
    }

    public IEnumerable<Airport> GetAllAirports() => _airports;

    public Airport? GetAirportByCode(string code) =>
        _airports.FirstOrDefault(a =>
            a.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Airport> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return _airports;

        query = query.Trim().ToLower();

        return _airports.Where(a =>
            a.Code.ToLower().Contains(query) ||
            a.City.ToLower().Contains(query) ||
            a.Country.ToLower().Contains(query) ||
            a.Name.ToLower().Contains(query)
        );
    }
}
