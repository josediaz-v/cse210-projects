public class SimpleGoal : Goal{
    bool _isComplete = false;
    public bool isComplete { get{return _isComplete;} set{_isComplete = value;} }
    public SimpleGoal(string name, string description, string points) : base(name, description, points){
    }

    public override bool IsComplete()
    {
        return isComplete;
    }

    public override void RecordEvent()
    {
        isComplete = true;
    }

    public override string GetStringRepresentation()
    {
        return $"{name}|{description}|{points}|{isComplete}";
    }
}