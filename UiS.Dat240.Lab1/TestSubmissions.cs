using System;
using Microsoft.Extensions.DependencyInjection;
using UiS.Dat240.Lab1.Commands;
using UiS.Dat240.Lab1.Queues;

namespace UiS.Dat240.Lab1;

/// <summary>
/// This is a holder class which holds
/// the submissions for the different tasks
/// </summary>
public static class TestSubmissions
{
    // This is a test endpoint, make this function
    // return an instance of your implementation
    public static IStringQueue CreateStringQueue()
    {
        return new StringQueue();
    }

    public static IObjectQueue CreateObjectQueue()
    {
        return new ObjectQueue();
    }

    public static IGenericQueue<T> CreateGenericQueue<T>()
    {
        return new GenericQueue<T>();
    }

    public static IServiceProvider CreateServiceProvider()
    {
        var collection = new ServiceCollection();

        // Singleton for the queue such that every command acts with the same queue each time the command is called.
        collection.AddSingleton<IStringQueue, StringQueue>();
        collection.AddSingleton<IObjectQueue, ObjectQueue>();
        collection.AddSingleton<IGenericQueue<string>, GenericQueue<string>>();

        //Transient to create a new handler for each request, but we only request once, so we could use singleton
        collection.AddTransient<ICommandHandler, AddHandler>();
        collection.AddTransient<ICommandHandler, RemHandler>();
        collection.AddTransient<ICommandHandler, SizeHandler>();

        var provider = collection.BuildServiceProvider();

        return provider;

    }
}
