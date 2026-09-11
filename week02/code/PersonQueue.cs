/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        // Add the new person to the back of the queue.
        // Add() places the person at the end of the list,
        // which follows FIFO (First In, First Out) behavior.
        _queue.Add(person);
    }

    public Person Dequeue()
    {
        // Get the person at the front of the queue.
        var person = _queue[0];

        // Remove the person from the front of the queue.
        _queue.RemoveAt(0);

        // Return the person that was removed.
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}