public class Fraction{
    private int _top;
    private int _bottom;

    public Fraction(){
        SetTop(1);
        SetBottom(1);
    }

    public Fraction(int wholeNumber){
        SetTop(wholeNumber);
        SetBottom(1);
    }

    public Fraction(int top, int bottom){
        SetTop(top);
        SetBottom(bottom);
    }

    private int GetTop(){
        return _top;
    }

    private void SetTop(int top){
        _top = top;
    }

    private int GetBottom(){
        return _bottom;
    }

    private void SetBottom(int bottom){
        _bottom = bottom;
    }

    public void GetFractionString(){
        int top = GetTop();
        int bottom = GetBottom();
        Console.WriteLine($"{top}/{bottom}");
    }

    public void GetDecimalValue(){
        Console.WriteLine((float)GetTop()/GetBottom());
    }
}