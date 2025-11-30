using Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services;

public class TicketService : IEnumerable<Ticket>
{
    private readonly List<Ticket> _tickets = new();

    public void Initialize(IEnumerable<Ticket>? tickets)
    {
        _tickets.Clear();
        if (tickets == null) return;
        _tickets.AddRange(tickets);
    }

    public void AddTicket(Ticket ticket) => _tickets.Add(ticket);

    public Ticket? GetById(string id) =>
        _tickets.FirstOrDefault(t => t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

    public List<Ticket> ToList() => new(_tickets);

    public int Count => _tickets.Count;

    public IEnumerator<Ticket> GetEnumerator() => _tickets.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _tickets.GetEnumerator();
}
v
