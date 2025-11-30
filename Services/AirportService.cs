using Models;
using Utilities;
using System.Text.Json;

namespace Services;

public class AirportService : IEnumerable<Airport>
{
    private readonly ArrayList<Airport> _airports = new();

    public void Initialize(List<Airport>? list)
    {
        if (list == null) return;
        foreach (var a in list)
        {
            _airports.AddLast(a);
        }
    }

    public IEnumerable<Airport> Search(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) 
            return _airports;

        input = input.ToLower();

        return _airports.Where(a =>
            a.Code.ToLower().Contains(input) ||
            a.City.ToLower().Contains(input) ||
            a.Name.ToLower().Contains(input)
        );
    }

    public Airport? GetByCode(string code) =>
        _airports.FirstOrDefault(a => a.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

    public IEnumerator<Airport> GetEnumerator() => _airports.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
