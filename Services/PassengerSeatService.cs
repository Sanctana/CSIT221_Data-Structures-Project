using Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services;

public class PassengerSeatService : IEnumerable<PassengerSeat>
{
    // switched from Utilities.ArrayList to a generic List for ease of use
    private readonly List<PassengerSeat> _passengerSeats = new();

    public void Initialize(IEnumerable<PassengerSeat>? passengerSeats)
    {
        _passengerSeats.Clear();
        if (passengerSeats == null) return;

        _passengerSeats.AddRange(passengerSeats);
    }

    public IEnumerable<PassengerSeat> GetPassengerSeatsByFlightId(int flightId) =>
        _passengerSeats.Where(ps => ps.FlightId == flightId);

    IEnumerator<PassengerSeat> IEnumerable<PassengerSeat>.GetEnumerator() => _passengerSeats.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _passengerSeats.GetEnumerator();

    public void AddPassengerSeat(PassengerSeat passengerSeat)
    {
        _passengerSeats.Add(passengerSeat);
    }

    public int Count => _passengerSeats.Count;

    public void AddLast(PassengerSeat passengerSeat)
    {
        _passengerSeats.Add(passengerSeat);
    }

    public PassengerSeat this[int index]
    {
        get => _passengerSeats[index];
        set => _passengerSeats[index] = value;
    }

    // New helpers used by the UI
    public void RemoveAt(int index) => _passengerSeats.RemoveAt(index);

    public List<PassengerSeat> ToList() => new List<PassengerSeat>(_passengerSeats);

    // Returns index of first matching item or -1
    public int IndexOf(Func<PassengerSeat, bool> predicate) =>
        _passengerSeats.FindIndex(ps => predicate(ps));
}