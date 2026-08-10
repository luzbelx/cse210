public class EternalGoal : Goal
{
    public EternalGoal(
        string shortName,
        string description,
        int points)
        : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals can be recorded repeatedly.
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Clean(GetShortName())}|{Clean(GetDescription())}|{GetPoints()}";
    }

    private string Clean(string text)
    {
        return text.Replace("|", "/");
    }
}
