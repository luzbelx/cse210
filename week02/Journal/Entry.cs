using System;

public class Entry
{
    // Member variables use _underscoreCamelCase as required.
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetResponse()
    {
        return _response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');

        if (parts.Length >= 3)
        {
            string date = parts[0];
            string prompt = parts[1];
            string response = string.Join("|", parts, 2, parts.Length - 2);

            return new Entry(date, prompt, response);
        }

        return null;
    }
}
