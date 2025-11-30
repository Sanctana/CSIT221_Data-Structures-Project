
namespace Utilities;

public class LinkedList<T>
{
    private class Node(T value)
    {
        public T Value = value;
        public Node? Next = null;
    }

    private Node? head = null;
    private Node? tail = null;
    private int count = 0;

    public void AddLast(T value)
    {
        Node newNode = new(value);
        tail?.Next = newNode;
        tail = newNode;
        head ??= newNode;
        count++;
    }

    public T? RemoveFirst()
    {
        if (head == null)
            throw new InvalidOperationException("The list is empty.");

        T value = head.Value;
        head = head.Next;
        if (head == null)
        {
            tail = null;
        }
        count--;
        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node current = head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }
            return current.Value;
        }
    }

    public int Count => count;
}