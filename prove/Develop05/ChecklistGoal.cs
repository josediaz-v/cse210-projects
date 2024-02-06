public class ChecklistGoal : Goal{
    int _amountCompleted = 0;
    public int amountCompleted { get{return _amountCompleted;} set{_amountCompleted = value;} }
    int _target;
    public int target { get{return _target;} set{_target = value;} }
    int _bonus;
    public int bonus { get{return _bonus;} set{_bonus = value;} }
    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points){
        _target = target;
        _bonus = bonus;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {amountCompleted}/{target}";
    }

    public override bool IsComplete()
    {
        if(amountCompleted == target){
            return true;
        }
        else{
            return false;
        }
    }

    public override void RecordEvent()
    {
        if(amountCompleted<target){
            amountCompleted++;
            if(IsComplete()){
                int total = bonus + int.Parse(points);                
                points = total.ToString();
            }
        } 
    }

    public override string GetStringRepresentation()
    {
        return $"{name}|{description}|{points}|{bonus}|{amountCompleted}|{target}";
    }
}