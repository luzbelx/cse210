using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity and exceeding core requirements:
         *
         * In addition to the basic requirements, this program contains
         * multiple scriptures that are randomly selected when the program
         * starts. This gives the user a different scripture memorization
         * experience each time they run the program.
         *
         * The program also hides three words at a time instead of only one,
         * making the memorization process faster.
         */

        List<Scripture> scriptures = new List<Scripture>();

        scriptures.Add(
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whoever believes in him should not perish but have eternal life"
            )
        );

        scriptures.Add(
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding in all your ways acknowledge him and he will make your paths straight"
            )
        );

        scriptures.Add(
            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ who strengthens me"
            )
        );

        Random random = new Random();
        int scriptureIndex = random.Next(scriptures.Count);

        Scripture scripture = scriptures[scriptureIndex];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine();
            Console.WriteLine("Great job! You memorized the scripture!");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Program ended.");
        }
    }
}
