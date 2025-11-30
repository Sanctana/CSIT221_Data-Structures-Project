using Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PassengerSeatService : IEnumerable<PassengerSeat>
    {
        // Internal storage
        private readonly List<PassengerSeat> _passengerSeats = new();

        // Initialize / Reset
        public void Initialize(IEnumerable<PassengerSeat>? passengerSeats)
        {
            _passengerSeats.Clear();
            if (passengerSeats != null)
                _passengerSeats.AddRange(passengerSeats);
        }

        // Query by flight
        public IEnumerable<PassengerSeat> GetPassengerSeatsByFlightId(int flightId) =>
            _passengerSeats.Where(ps => ps.FlightId == flightId);

        // Add
        public void AddPassengerSeat(PassengerSeat seat) => _passengerSeats.Add(seat);
        public void AddLast(PassengerSeat seat) => _passengerSeats.Add(seat);

        // Count
        public int Count => _passengerSeats.Count;

        // Indexer
        public PassengerSeat this[int index]
        {
            get => _passengerSeats[index];
            set => _passengerSeats[index] = value;
        }

        // Remove by index
        public void RemoveAt(int index) => _passengerSeats.RemoveAt(index);

        // Convert to list
        public List<PassengerSeat> ToList() => new(_passengerSeats);

        // Find index
        public int IndexOf(Func<PassengerSeat, bool> predicate) =>
            _passengerSeats.FindIndex(ps => predicate(ps));

        public void RemoveWhere(Func<PassengerSeat, bool> predicate)
        {
            _passengerSeats.RemoveAll(ps => predicate(ps));
        }

        public void Update(PassengerSeat updatedSeat)
        {
            int index = _passengerSeats.FindIndex(ps => ps.Id == updatedSeat.Id);

            if (index >= 0)
                _passengerSeats[index] = updatedSeat;
        }
        
        public IEnumerator<PassengerSeat> GetEnumerator() => _passengerSeats.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _passengerSeats.GetEnumerator();
    }
}
