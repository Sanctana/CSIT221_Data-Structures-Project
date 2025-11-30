namespace Models;

public class PassengerSeat
{
    public required string Name { get; set; }
    public required int Age { get; set; }
    public required string Gender { get; set; }
    public required string SeatNumber { get; set; }
    public required int FlightId { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
}