namespace Models;

public class Ticket
{
    public required string Id { get; set; }
    public required string SeatId { get; set; }
    public required string From { get; set; }
    public required string To { get; set; }
    public required string HolderName { get; set; }
    public required DateTime IssueTime { get; set; }
    public required DateTime TravelTime { get; set; }
    public required int PassengerCount { get; set; }
}

