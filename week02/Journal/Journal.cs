using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nYour journal is empty.");
            return;
        }

        Console.WriteLine("\n===== YOUR JOURNAL =====");

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }

        Console.WriteLine($"\nJournal saved successfully to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("\nThe file was not found.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                Entry entry = Entry.FromFileString(line);

                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
        }

        Console.WriteLine($"\nJournal loaded successfully from {filename}");
        Console.WriteLine($"Entries loaded: {_entries.Count}");
    }

    // EXTRA FEATURE:
    // This method provides statistics about the journal.
    // It calculates the number of entries and the average number
    // of words written per entry.
    public void DisplayStatistics()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nThere are no entries to analyze.");
            return;
        }

        int totalWords = 0;

        foreach (Entry entry in _entries)
        {
            string response = entry.GetResponse();

            string[] words = response.Split(
                new char[] { ' ', '\t', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries
            );

            totalWords += words.Length;
        }

        double averageWords = (double)totalWords / _entries.Count;

        Console.WriteLine("\n===== JOURNAL STATISTICS =====");
        Console.WriteLine($"Total entries: {_entries.Count}");
        Console.WriteLine($"Total words: {totalWords}");
        Console.WriteLine($"Average words per entry: {averageWords:F1}");
    }

    // EXTRA FEATURE:
    // Allows the user to search for a word or phrase in the
    // responses and display matching journal entries.
    public void SearchEntries(string searchTerm)
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nYour journal is empty.");
            return;
        }

        bool found = false;

        Console.WriteLine($"\n===== SEARCH RESULTS FOR: {searchTerm} =====");

        foreach (Entry entry in _entries)
        {
            if (entry.GetResponse().Contains(
                searchTerm,
                StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No entries were found containing that word or phrase.");
        }
    }
}