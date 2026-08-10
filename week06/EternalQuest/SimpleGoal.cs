public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(
        string shortName,
        string description,
        int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(
        string shortName,
        string description,
        int points,
        bool isComplete)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{Clean(GetShortName())}|{Clean(GetDescription())}|{GetPoints()}|{_isComplete}";
    }

    private string Clean(string text)
    {
        return text.Replace("|", "/");
    }
}