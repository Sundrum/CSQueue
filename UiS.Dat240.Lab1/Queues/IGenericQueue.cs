namespace UiS.Dat240.Lab1.Queues;
using System.Collections;

public interface IGenericQueue<T>
{
    int Length { get; }
    void Enqueue(T value);
    T Dequeue();
}
public class GenericQueue<T> : IGenericQueue<T>, IEnumerable<T>
{
        private T[] queue = new T[2];
    private int size = 0;
    public int Length
    {
        get {return size;}
    }

    public void Enqueue(T value)
    {
        if (size == queue.Length)
        {
            Grow();
        }
        queue[size] = value;
        size++;
    }
    public T Dequeue()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        // Using Array.Copy(FromArray, FromElement, ToArray, ToElement, LengthOfArray)
        T first_element = queue[0];

        // Make a temporary array to copy the old array minus the deleted element into.
        T[] newQueue = new T[queue.Length-1];
        Array.Copy(queue, 1, newQueue, 0, queue.Length-1);

        // Overwrite the old array with the new one
        queue = newQueue;
        size--;
        return first_element;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < size; i++)
        {
            yield return queue[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    private void Grow()
    {
        // Overwrite the old array with a new one with double the length
        T[] newQueue = new T[size*2];
        Array.Copy(queue, 0, newQueue, 0, size);
        queue = newQueue;
    }
}