using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {

        Journal journal = new Journal();


        List<string> prompts = new List<string>()
        {
            "What was the best part of your day?",
            "What did you learn today?",
            "What made you happy today?",
            "What challenge did you overcome?",
            "Who helped you today?"
        };


        bool running = true;


        while (running)
        {

            Console.WriteLine();
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine();

            Console.WriteLine("Please select one:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");

            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();


            switch(choice)
            {

                case "1":

                    Random random = new Random();

                    int index = random.Next(prompts.Count);


                    string selectedPrompt = prompts[index];


                    Console.WriteLine();
                    Console.WriteLine(selectedPrompt);


                    Console.Write("> ");
                    string response = Console.ReadLine();


                    string date = DateTime.Now.ToShortDateString();


                    Entry newEntry = new Entry(
                        date,
                        selectedPrompt,
                        response
                    );


                    journal.AddEntry(newEntry);


                    Console.WriteLine("Entry added!");

                    break;



                case "2":

                    journal.DisplayEntries();

                    break;



                case "3":

                    Console.Write("Enter filename: ");

                    string saveFile = Console.ReadLine();


                    journal.SaveToFile(saveFile);

                    break;



                case "4":

                    Console.Write("Enter filename: ");

                    string loadFile = Console.ReadLine();


                    journal.LoadFromFile(loadFile);

                    break;



                case "5":

                    running = false;

                    Console.WriteLine("Goodbye!");

                    break;



                default:

                    Console.WriteLine("Invalid option.");

                    break;
            }

        }

    }
}


// Extra Feature:
// This program uses random prompts and allows users
// to save and load their journal entries.

#luzbelx
