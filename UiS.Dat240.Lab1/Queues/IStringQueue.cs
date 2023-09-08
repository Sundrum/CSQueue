namespace UiS.Dat240.Lab1.Queues;

public interface IStringQueue
{
    int Length { get; }
    void Enqueue(string value);
    string Dequeue();
}

public class StringQueue : IStringQueue 
{
    private GenericQueue<string> internalQueue = new GenericQueue<string>();
    public int Length
    {
    //    get {return size;}
    get {return internalQueue.Length;}
    }

    public void Enqueue(string value)
    {
    //     if (size == queue.Length)
    //     {
    //         Grow();
    //     }
    //     queue[size] = value;
    //     size++;
        internalQueue.Enqueue(value);
    }
    public string Dequeue()
    {
        // if (size == 0)
        // {
        //     throw new InvalidOperationException("Queue is empty");
        // }

        // // Using Array.Copy(FromArray, FromElement, ToArray, ToElement, LengthOfArray)
        // string first_element = queue[0];

        // // Make a temporary array to copy the old array minus the deleted element into.
        // string[] newQueue = new string[queue.Length-1];
        // Array.Copy(queue, 1, newQueue, 0, queue.Length-1);

        // // Overwrite the old array with the new one
        // queue = newQueue;
        // size--;
        // return first_element;
        string element = internalQueue.Dequeue();
        return element;
    }
    // private void Grow()
    // {
    //     // Overwrite the old array with a new one with double the length
    //     string[] newQueue = new string[size*2];
    //     Array.Copy(queue, 0, newQueue, 0, size);
    //     queue = newQueue;
    // }
}