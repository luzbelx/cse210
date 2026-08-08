using System;
using System.Threading;

public class Activity
{
private string _name;
private string _description;
private int _duration;

public Activity(string name, string description)
{
    _name = name;
    _description = description;
    _duration = 0;
}

public void SetDuration(int duration)
{
    _duration = duration;
}

public int GetDuration()
{
    return _duration;
}

public void DisplayStartingMessage()
{
    Console.Clear();

    Console.WriteLine($"Welcome to the {_name}.");
    Console.WriteLine();
    Console.WriteLine(_description);
    Console.WriteLine();

    Console.Write("How long, in seconds, would you like for your session? ");
    _duration = int.Parse(Console.ReadLine());

    Console.Clear();
    Console.WriteLine("Get ready...");
    ShowSpinner(3);
    Console.WriteLine();
}

public void DisplayEndingMessage()
{
    Console.WriteLine();
    Console.WriteLine("Well done!!");
    Console.WriteLine();

    Console.WriteLine(
        $"You have completed another {_duration} seconds of the {_name}."
    );

    ShowSpinner(3);
    Console.Clear();
}

public void ShowSpinner(int seconds)
{
    string[] symbols = { "|", "/", "-", "\\" };

    DateTime startTime = DateTime.Now;
    int index = 0;

    while ((DateTime.Now - startTime).TotalSeconds < seconds)
    {
        Console.Write(symbols[index]);
        Thread.Sleep(200);
        Console.Write("\b \b");

        index++;

        if (index >= symbols.Length)
        {
            index = 0;
        }
    }
}

public void ShowCountDown(int seconds)
{
    for (int i = seconds; i > 0; i--)
    {
        Console.Write(i);
        Thread.Sleep(1000);
        Console.Write("\b \b");
    }
}

public void PauseWithMessage(string message, int seconds)
{
    Console.Write(message);
    ShowSpinner(seconds);
    Console.WriteLine();
}

}
