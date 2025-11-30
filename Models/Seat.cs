namespace Models;

public class Seat
{
    public required int FlightId { get; set; }
    public required string SeatNumber { get; set; }
    public required string Class { get; set; }
    public bool IsAvailable { get; set; } = true;
}