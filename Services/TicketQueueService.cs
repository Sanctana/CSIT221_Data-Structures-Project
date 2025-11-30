using Models;

namespace Services;

public class TicketQueueService
{
    private readonly Utilities.Queue<Ticket> _queue = new();
    private bool _initialized = false;

    public void Enqueue(Ticket t)
    {
        lock (_queue) { _queue.Enqueue(t); }
    }

    public Ticket? Dequeue()
    {
        lock (_queue) { return _queue.Count > 0 ? _queue.Dequeue() : null; }
    }

    public IReadOnlyCollection<Ticket> GetAll()
    {
        lock (_queue) { return [.. _queue]; }
    }

    public int Count
    {
        get { lock (_queue) { return _queue.Count; } }
    }

    public void Initialize(IEnumerable<Ticket>? tickets)
    {
        if (tickets == null || _initialized) return;

        lock (_queue)
        {
            foreach (var t in tickets)
            {
                _queue.Enqueue(t);
            }

        }
        _initialized = true;
    }
}