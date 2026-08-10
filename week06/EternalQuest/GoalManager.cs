using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            DisplayHeader();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Statistics");
            Console.WriteLine("7. Quit");
            Console.Write("\nSelect a choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    Pause();
                    break;

                case "2":
                    ListGoals();
                    Pause();
                    break;

                case "3":
                    SaveGoals();
                    Pause();
                    break;

                case "4":
                    LoadGoals();
                    Pause();
                    break;

                case "5":
                    RecordEvent();
                    Pause();
                    break;

                case "6":
                    ShowStatistics();
                    Pause();
                    break;

                case "7":
                    running = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid choice.");
                    Pause();
                    break;
            }
        }

        Console.WriteLine("\nThank you for using Eternal Quest!");
    }

    private void DisplayHeader()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("             ETERNAL QUEST");
        Console.WriteLine("========================================");
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine($"Level: {GetLevel()}");
        Console.WriteLine($"Rank: {GetRank()}");
        Console.WriteLine("========================================\n");
    }

    private void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("CREATE NEW GOAL");
        Console.WriteLine("----------------");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("\nWhich type of goal would you like to create? ");
        string type = Console.ReadLine() ?? "";

        Console.Write("Short name: ");
        string shortName = Console.ReadLine() ?? "";

        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        int points = ReadPositiveInt("Points: ");

        switch (type)
        {
            case "1":
                _goals.Add(
                    new SimpleGoal(
                        shortName,
                        description,
                        points));

                Console.WriteLine("\nSimple goal created!");
                break;

            case "2":
                _goals.Add(
                    new EternalGoal(
                        shortName,
                        description,
                        points));

                Console.WriteLine("\nEternal goal created!");
                break;

            case "3":
                int target = ReadPositiveInt("How many times must it be completed? ");
                int bonus = ReadPositiveInt("Bonus points when completed: ");

                _goals.Add(
                    new ChecklistGoal(
                        shortName,
                        description,
                        points,
                        target,
                        bonus));

                Console.WriteLine("\nChecklist goal created!");
                break;

            default:
                Console.WriteLine("\nInvalid goal type.");
                break;
        }
    }

    private void ListGoals()
    {
        Console.Clear();

        Console.WriteLine("YOUR GOALS");
        Console.WriteLine("----------");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals.");
            return;
        }

        Console.WriteLine("RECORD EVENT");
        Console.WriteLine("------------");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("\nWhich goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[choice - 1];

        if (goal is SimpleGoal && goal.IsComplete())
        {
            Console.WriteLine("\nThis Simple Goal has already been completed.");
            return;
        }

        if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
        {
            Console.WriteLine("\nThis Checklist Goal has already been completed.");
            return;
        }

        int pointsEarned = goal.GetPoints();

        bool wasChecklist = goal is ChecklistGoal;
        bool wasCompleteBefore = goal.IsComplete();

        goal.RecordEvent();

        _score += pointsEarned;

        if (wasChecklist && !wasCompleteBefore && goal.IsComplete())
        {
            ChecklistGoal checklist = (ChecklistGoal)goal;

            _score += checklist.GetBonus();

            Console.WriteLine(
                $"\nCongratulations! You completed the checklist goal!");

            Console.WriteLine(
                $"Bonus earned: {checklist.GetBonus()} points!");
        }

        Console.WriteLine($"\nYou earned {pointsEarned} points!");

        Console.WriteLine($"Total score: {_score}");
    }

    private void SaveGoals()
    {
        Console.Clear();

        Console.Write("Enter the filename to save: ");
        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        try
        {
            List<string> lines = new List<string>();

            lines.Add(_score.ToString());

            foreach (Goal goal in _goals)
            {
                lines.Add(goal.GetStringRepresentation());
            }

            File.WriteAllLines(filename, lines);

            Console.WriteLine("\nGoals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving file: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        Console.Clear();

        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine() ?? "";

        if (!File.Exists(filename))
        {
            Console.WriteLine("\nFile not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            if (!int.TryParse(lines[0], out _score))
            {
                Console.WriteLine("Invalid score in file.");
                return;
            }

            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                Goal goal = CreateGoalFromString(lines[i]);

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

            Console.WriteLine("\nGoals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading file: {ex.Message}");
        }
    }

    private Goal? CreateGoalFromString(string line)
    {
        string[] parts = line.Split('|');

        if (parts.Length == 0)
        {
            return null;
        }

        switch (parts[0])
        {
            case "SimpleGoal":

                if (parts.Length >= 5)
                {
                    string shortName = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    return new SimpleGoal(
                        shortName,
                        description,
                        points,
                        isComplete);
                }

                break;

            case "EternalGoal":

                if (parts.Length >= 4)
                {
                    string shortName = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    return new EternalGoal(
                        shortName,
                        description,
                        points);
                }

                break;

            case "ChecklistGoal":

                if (parts.Length >= 7)
                {
                    string shortName = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);

                    return new ChecklistGoal(
                        shortName,
                        description,
                        points,
                        target,
                        bonus,
                        amountCompleted);
                }

                break;
        }

        return null;
    }

    private void ShowStatistics()
    {
        Console.Clear();

        Console.WriteLine("STATISTICS");
        Console.WriteLine("----------");

        Console.WriteLine($"Total score: {_score}");
        Console.WriteLine($"Current level: {GetLevel()}");
        Console.WriteLine($"Current rank: {GetRank()}");
        Console.WriteLine($"Total goals: {_goals.Count}");

        int completedGoals = 0;

        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                completedGoals++;
            }
        }

        Console.WriteLine($"Completed goals: {completedGoals}");
        Console.WriteLine($"Remaining goals: {_goals.Count - completedGoals}");
    }

    private int GetLevel()
    {
        return (_score / 500) + 1;
    }

    private string GetRank()
    {
        if (_score >= 5000)
        {
            return "Legend";
        }

        if (_score >= 3000)
        {
            return "Master";
        }

        if (_score >= 1500)
        {
            return "Expert";
        }

        if (_score >= 500)
        {
            return "Adventurer";
        }

        return "Beginner";
    }

    private int ReadPositiveInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a positive number.");
        }
    }

    private void Pause()
    {
        Console.WriteLine("\nPress ENTER to continue...");
        Console.ReadLine();
    }
}