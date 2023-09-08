namespace UiS.Dat240.Lab1.Queues;

public interface IObjectQueue
{
    int Length { get; }
    void Enqueue(object value);
    object Dequeue();
}

public class ObjectQueue : IObjectQueue 
{
    private GenericQueue<object> internalQueue = new GenericQueue<object>();
    public int Length
    {
    //    get {return size;}
    get {return internalQueue.Length;}
    }

    public void Enqueue(object value)
    {
        // if (size == queue.Length)
        // {
        //     Grow();
        // }
        // queue[size] = value;
        // size++;
        internalQueue.Enqueue(value);
    }
    public object Dequeue()
    {
        // if (size == 0)
        // {
        //     throw new InvalidOperationException("Queue is empty");
        // }

        // // Using Array.Copy(FromArray, FromElement, ToArray, ToElement, LengthOfArray)
        // object first_element = queue[0];

        // // Make a temporary array to copy the old array minus the deleted element into.
        // object[] newQueue = new object[queue.Length-1];
        // Array.Copy(queue, 1, newQueue, 0, queue.Length-1);

        // // Overwrite the old array with the new one
        // queue = newQueue;
        // size--;
        // return first_element;
        object element = internalQueue.Dequeue();
        return element;
    }
    // private void Grow()
    // {
    //     // Overwrite the old array with a new one with double the length
    //     object[] newQueue = new object[size*2];
    //     Array.Copy(queue, 0, newQueue, 0, size);
    //     queue = newQueue;
    // }
}