using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);

        // If the list is empty, point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, only head will be affected.
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);

        // If the list is empty, head and tail are the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, connect the new node to the tail.
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item, make the list empty.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If there is more than one item, move head to the next node.
        else if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If there is only one node, make the list empty.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // Otherwise, move tail to the previous node.
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null;
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value'.
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If value is at the end, use InsertTail.
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // Otherwise, insert a new node in the middle.
                else
                {
                    Node newNode = new(newValue);

                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }

                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the value is at the head.
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If the value is at the tail.
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // Otherwise, remove it from the middle.
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }

                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        var curr = _tail;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}