
using UiS.Dat240.Lab1.Commands;
using Microsoft.Extensions.DependencyInjection;

var provider = UiS.Dat240.Lab1.TestSubmissions.CreateServiceProvider();
var handlers = provider.GetServices<ICommandHandler>();

var addCmd = handlers.FirstOrDefault(a => a.Name.Equals("add"));
var remCmd = handlers.FirstOrDefault(a => a.Name.Equals("rem"));
var sizeCmd = handlers.FirstOrDefault(a => a.Name.Equals("size"));

bool exit = false;
while(!exit)
{
    Console.Write(">");
    string input = Console.ReadLine();
    string[] inputList = input.Split(" ", 2);
    if (inputList[0] == "add")
    {
        addCmd.Handle(inputList[1]);
        continue;
    };
    if(inputList[0] == "rem")
    {
        remCmd.Handle("someinput");
        continue;
    };
    if(inputList[0] == "size")
    {
        sizeCmd.Handle("someinput");
        continue;
    };
    if(inputList[0] == "exit")
    { 
        Console.WriteLine("You wrote the exit command");
        exit = true;
    };
}

