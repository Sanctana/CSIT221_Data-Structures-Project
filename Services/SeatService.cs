using Models;
using Utilities;

namespace Services;

using System.Collections;

public class SeatService : IEnumerable<Seat>
{
    private readonly ArrayList<Seat> _seats = new();

    public void Initialize(IEnumerable<Seat>? seats)
    {
        if (seats == null) return;

        foreach (var seat in seats)
        {
            _seats.AddLast(seat);
        }
    }

    public IEnumerable<Seat> GetSeatsByFlightId(int flightId) =>
        _seats.Where(s => s.FlightId == flightId);

    IEnumerator<Seat> IEnumerable<Seat>.GetEnumerator() => _seats.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _seats.GetEnumerator();

    public Seat GetSeat(int flightId, string seatNumber)
    {
        foreach (var seat in _seats)
        {
            if (seat.FlightId == flightId && seat.SeatNumber.Equals(seatNumber, StringComparison.OrdinalIgnoreCase))
            {
                return seat;
            }
        }

        throw new KeyNotFoundException($"Seat {seatNumber} for Flight ID {flightId} not found.");
    }

    public void UpdateSeatAvailability(int flightId, string seatNumber, bool isAvailable)
    {
        GetSeat(flightId, seatNumber).IsAvailable = isAvailable;
    }
}