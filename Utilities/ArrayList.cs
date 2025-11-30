using System.Collections;

namespace Utilities;

public class ArrayList<T> : IEnumerable<T>
{
    private T[] _items = new T[4];
    private int _count;

    public void AddLast(T item)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
        _items[_count++] = item;
    }

    public T RemoveLast() => RemoveAt(_count - 1);

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index));

        T removedItem = _items[index];

        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        _items[_count - 1] = default!;
        _count--;

        return removedItem;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));
            _items[index] = value;
        }
    }

    public void Clear()
    {
        _items = new T[4];
        _count = 0;
    }

    public int Count => _count;

    public int RemoveAll(Predicate<T> match)
    {
        int removedCount = 0;
        for (int i = 0; i < _count;)
        {
            if (match(_items[i]))
            {
                RemoveAt(i);
                removedCount++;
            }
            else
            {
                i++;
            }
        }
        return removedCount;
    }
}