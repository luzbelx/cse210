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


    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }


        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }


    public void SaveToFile(string fileName)
    {
        List<string> lines = new List<string>();

        foreach (Entry entry in _entries)
        {
            lines.Add(entry.SaveFormat());
        }


        File.WriteAllLines(fileName, lines);

        Console.WriteLine("Journal saved successfully.");
    }


    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }


        string[] lines = File.ReadAllLines(fileName);

        _entries.Clear();


        foreach (string line in lines)
        {
            string[] parts = line.Split("|");


            if (parts.Length == 3)
            {
                Entry entry = new Entry(
                    parts[0],
                    parts[1],
                    parts[2]
                );


                _entries.Add(entry);
            }
        }


        Console.WriteLine("Journal loaded successfully.");
    }
}
