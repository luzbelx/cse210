public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int target,
        int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int target,
        int bonus,
        int amountCompleted)
        : base(shortName, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "X" : " ";

        return $"[{status}] {GetShortName()} ({GetDescription()}) -- Progress: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Clean(GetShortName())}|{Clean(GetDescription())}|{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
    }

    private string Clean(string text)
    {
        return text.Replace("|", "/");
    }
}