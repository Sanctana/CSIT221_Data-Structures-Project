namespace Models;

public class Ticket
{
    public int Id { get; set; }
    public string seatId { get; set; }
    public string? HolderName { get; set; }
    public DateTime IssueTime { get; set; }
}

