namespace Utilities;

public class Queue<T>
{
    private readonly LinkedList<T> _list = new();

    public void Enqueue(T item) => _list.AddLast(item);

    public T? Dequeue() => _list.RemoveFirst();

    public T? Peek() => _list[0];

    public int Count => _list.Count;

    public bool IsEmpty => Count == 0;

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
}