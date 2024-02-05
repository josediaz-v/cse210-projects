public abstract class Shape {
    private string _color;

    protected Shape(string color)
    {
        _color = color;
    }

    public string color { get{return _color;} set{_color = value;} }

    public abstract double GetArea();
}