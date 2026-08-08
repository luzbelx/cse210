using System;

class Program
{
static void Main(string[] args)
{
int choice = 0;
int activitiesCompleted = 0;

    while (choice != 4)
    {
        Console.Clear();

        Console.WriteLine("Menu Options");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
        Console.WriteLine();
        Console.Write("Select a choice from the menu: ");

        string input = Console.ReadLine();

        if (!int.TryParse(input, out choice))
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a valid number.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            continue;
        }

        Console.WriteLine();

        switch (choice)
        {
            case 1:
                BreathingActivity breathingActivity =
                    new BreathingActivity();

                breathingActivity.Run();
                activitiesCompleted++;
                break;

            case 2:
                ReflectingActivity reflectingActivity =
                    new ReflectingActivity();

                reflectingActivity.Run();
                activitiesCompleted++;
                break;

            case 3:
                ListingActivity listingActivity =
                    new ListingActivity();

                listingActivity.Run();
                activitiesCompleted++;
                break;

            case 4:
                Console.WriteLine(
                    $"You completed {activitiesCompleted} mindfulness activities during this session."
                );

                Console.WriteLine();
                Console.WriteLine("Thank you for using the Mindfulness Program!");
                break;

            default:
                Console.WriteLine("Invalid choice.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                break;
        }
    }
}

}

/*

* Creativity / Exceeding Core Requirements:
*
* In addition to the required functionality, this program keeps track
* of how many mindfulness activities the user completes during the
* current program session.
*
* The program also includes:
*
* * Input validation for the main menu.
* * A reusable countdown method.
* * A reusable spinner animation using backspaces.
* * A reusable pause method.
* * Additional prompts and reflection questions.
*
* These additions improve the usability and experience of the program
* while keeping the responsibilities of each class separated.
  */
