using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
private List<string> _prompts;
private List<string> _questions;

public ReflectingActivity()
    : base(
        "Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    )
{
    _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you overcame a difficult challenge.",
        "Think of a time when you learned something important from a mistake."
    };

    _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How did you feel during this experience?",
        "How can you use what you learned in the future?",
        "What personal strength did you discover?",
        "Who helped you during this experience?",
        "How did this experience change you?",
        "What would you do differently next time?"
    };
}

public void Run()
{
    DisplayStartingMessage();

    Console.Clear();

    Console.WriteLine("Consider the following prompt:");
    Console.WriteLine();

    Random random = new Random();
    string prompt = _prompts[random.Next(_prompts.Count)];

    Console.WriteLine($"--- {prompt} ---");
    Console.WriteLine();

    PauseWithMessage("When you have something in mind, ", 3);

    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(GetDuration());

    Console.Clear();

    while (DateTime.Now < endTime)
    {
        string question = _questions[random.Next(_questions.Count)];

        Console.WriteLine(question);
        Console.WriteLine();

        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine();

        if (DateTime.Now >= endTime)
        {
            break;
        }
    }

    DisplayEndingMessage();
}

}
