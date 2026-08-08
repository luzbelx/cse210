using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
private List<string> _prompts;

public ListingActivity()
    : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    )
{
    _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "What are some things you are grateful for?",
        "What are some things you are looking forward to?",
        "What are some good memories you have?",
        "What are some things that make you happy?"
    };
}

public void Run()
{
    DisplayStartingMessage();

    Console.WriteLine(
        "List as many responses as you can to the following prompt:"
    );
    Console.WriteLine();

    Random random = new Random();
    string prompt = _prompts[random.Next(_prompts.Count)];

    Console.WriteLine($"--- {prompt} ---");
    Console.WriteLine();

    Console.Write("You may begin in: ");
    ShowCountDown(5);
    Console.WriteLine();
    Console.WriteLine();

    int count = 0;
    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(GetDuration());

    while (DateTime.Now < endTime)
    {
        Console.Write("> ");
        string answer = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(answer))
        {
            count++;
        }
    }

    Console.WriteLine();
    Console.WriteLine($"You listed {count} items!");

    PauseWithMessage("Great job! ", 2);

    DisplayEndingMessage();
}

}
