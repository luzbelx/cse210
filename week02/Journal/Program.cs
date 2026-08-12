using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        string[] prompts =
        {
            "What was the best part of my day?",
            "Who was the most interesting person I interacted with today?",
            "What was something I learned today?",
            "What is something I am grateful for today?",
            "What was the strongest emotion I felt today?",
            "What is one thing I could improve tomorrow?",
            "What was something that made me smile today?"
        };

        Random random = new Random();

        bool running = true;

        // Creativity / Exceeding Requirements:
        // In addition to the required journal functionality, this program
        // includes two extra features. The user can view journal statistics,
        // including total entries, total words, and average words per entry.
        // The user can also search the journal for a specific word or phrase.
        // These features make the journal more useful for tracking writing
        // habits and finding previous thoughts.

        while (running)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("       JOURNAL PROGRAM");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. View statistics");
            Console.WriteLine("6. Search journal");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[random.Next(prompts.Length)];

                    Console.WriteLine("\nPrompt:");
                    Console.WriteLine(prompt);
                    Console.Write("\nYour response: ");

                    string response = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(
                        date,
                        prompt,
                        response
                    );

                    journal.AddEntry(newEntry);

                    Console.WriteLine("\nYour entry has been saved in the journal.");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("\nEnter the filename to save to: ");
                    string saveFilename = Console.ReadLine();

                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("\nEnter the filename to load from: ");
                    string loadFilename = Console.ReadLine();

                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    journal.DisplayStatistics();
                    break;

                case "6":
                    Console.Write("\nEnter a word or phrase to search for: ");
                    string searchTerm = Console.ReadLine();

                    journal.SearchEntries(searchTerm);
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("\nThank you for using the Journal Program!");
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please choose a number from 1 to 7.");
                    break;
            }
        }
    }
}