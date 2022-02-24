using System;

public class CircularBuffer<T>
{
    private readonly T[] buffer;
    private int readIndex;
    private int writeIndex;
    private int currentSize;

    public CircularBuffer(int capacity)
    {
        buffer = new T[capacity];
        Clear();
    }

    public T Read()
    {
        if (currentSize < 1)
        {
            throw new InvalidOperationException();
        }

        return RemoveItem();
    }

    public void Write(T value)
    {
        if (currentSize >= buffer.Length)
        {
            throw new InvalidOperationException();
        }

        AddItem(value);
    }

    public void Overwrite(T value)
    {
        if (currentSize >= buffer.Length)
        {
            RemoveItem();
        }

        AddItem(value);
    }

    public void Clear()
    {
        readIndex = 0;
        writeIndex = 0;
        currentSize = 0;
    }

    private T RemoveItem()
    {
        var item = buffer[readIndex];
        currentSize--;
        readIndex = Increment(readIndex);
        return item;
    }

    private void AddItem(T item)
    {
        buffer[writeIndex] = item;
        currentSize++;
        writeIndex = Increment(writeIndex);
    }

    private int Increment(int value)
    {
        if (value == buffer.Length - 1)
        {
            value = 0;
        }
        else
        {
            value++;
        }

        return value;
    }
}