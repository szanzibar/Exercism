using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    public SimpleLinkedList(T value)
    {
        Value = value;
        Next = null;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        Value = values.First();
        Next = (values.Count() > 1) ? new SimpleLinkedList<T>(values.Skip<T>(1)) : null;
    }

    public T Value { get; private set; }

    public SimpleLinkedList<T> Next { get; private set; }

    public SimpleLinkedList<T> Add(T value)
    {
        Next = new SimpleLinkedList<T>(value);
        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var item = this;
        do
        {
            yield return item.Value;
            item = item.Next;
        } while (item != null);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}