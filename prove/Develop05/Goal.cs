public abstract class Goal{
    private string _name;
    public string name { get{return _name;} set{_name = value;} }
    private string _description;
    public string description { get{return _description;} set{_description = value;} }
    private string _points;
    public string points { get{return _points;} set{_points=value;} }

    public Goal(string name, string description, string points){
        _name = name;
        _description = description;
        _points = points;
    }

    public virtual string GetDetailsString(){
        string check = " ";
        if(IsComplete()){
            check = "X";
        }
        return $"[{check}] {name} ({description})";
    }

    public abstract bool IsComplete();

    public abstract void RecordEvent();

    public abstract string GetStringRepresentation();
}