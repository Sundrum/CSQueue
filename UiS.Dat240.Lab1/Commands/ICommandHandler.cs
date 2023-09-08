namespace UiS.Dat240.Lab1.Commands;
using UiS.Dat240.Lab1.Queues;

public interface ICommandHandler
{
    string Name { get; }
    void Handle(string args);
}


// ------- ENQUEUE --------
public class AddHandler : ICommandHandler
{
  // The name of the command
  public string Name => "add";

  private readonly IStringQueue stringQueue;
  // Since we are going to register the AddHandler in the dependency injection, 
  // then we can request other service from DI as constructor parameters.
  // This is the constructor of the class
  public AddHandler(IStringQueue stringQueue)
  {
    // The request service should also be stored and used later in the class
    this.stringQueue = stringQueue;
  }

  // The function to be executed when the user write the command name
  public void Handle(string args)
  {
    stringQueue.Enqueue(args);
  }
}

// ------ DEQUEUE ---------
public class RemHandler : ICommandHandler
{
  public string Name => "rem";

  private readonly IStringQueue stringQueue;

  public RemHandler(IStringQueue stringQueue)
  {
    this.stringQueue = stringQueue;
  }

  public void Handle(string args)
  {
    try
    {
        Console.WriteLine(stringQueue.Dequeue());
    }
    catch(Exception)
    {
        Console.WriteLine("Queue is empty");
    }

  }
}

// ----- SIZE -------
public class SizeHandler : ICommandHandler
{
  public string Name => "size";
  private readonly IStringQueue stringQueue;
  public SizeHandler(IStringQueue stringQueue)
  {
    this.stringQueue = stringQueue;
  }

  public void Handle(string args)
  {
    Console.WriteLine(stringQueue.Length);
  }
}