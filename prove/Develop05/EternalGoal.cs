public class EternalGoal : Goal{
    public EternalGoal(string name, string description, string points) : base(name, description, points){
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override void RecordEvent()
    {
        IsComplete();
    }
    
    public override string GetStringRepresentation()
    {
        return $"{name}|{description}|{points}";
    }
}