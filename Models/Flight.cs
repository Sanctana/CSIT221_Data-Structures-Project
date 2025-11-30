namespace Models;

public class Flight
{
    public required int Id { get; set; }
    public required string From { get; set; }
    public required string To { get; set; }
    public required DateTime Departure { get; set; }
    public required DateTime Arrival { get; set; }
    public required string Airline { get; set; }
    public required string FlightNumber { get; set; }
    public required decimal Price { get; set; }
    public required int DurationMinutes { get; set; }
    public required int SeatsAvailable { get; set; }
}