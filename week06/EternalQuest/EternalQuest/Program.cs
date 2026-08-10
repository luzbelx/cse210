/*
 * Eternal Quest Program
 *
 * Extra Creativity:
 * In addition to the required goal functionality, this program includes
 * a player level and rank system based on the user's score.
 *
 * The user can also view statistics showing completed and remaining goals.
 *
 * This extra functionality was added to make the program feel more like
 * a real quest/progression system while keeping the original requirements.
 */

public class Program
{
    public static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        goalManager.Run();
    }
}