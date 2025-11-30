namespace Utilities;


public class Stack<T>
{
    private readonly ArrayList<T> _list = new();

    public void Push(T item) => _list.AddLast(item);

    public T? Pop() => _list.RemoveLast();

    public T? Peek() => _list[^1];

    public int Count => _list.Count;

    public bool IsEmpty => Count == 0;

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
}