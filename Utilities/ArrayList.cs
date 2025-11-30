namespace Utilities;

public class ArrayList<T>
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

    public int Count => _count;
}