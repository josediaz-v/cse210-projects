public class Word{
    private string _text;
    private bool _isHidden;

    public Word(string text){
        SetText(text);
        SetIsHidden(false);
    }

    public void Hide(){
        if(GetIsHidden() == false){
            SetIsHidden(true);
            SetText(new string('_', _text.Length));
        }
    }

    /*private void Show(){
        Console.WriteLine(_text);
    }*/

    public bool IsHidden(){
        bool isHidden = GetIsHidden();
        return isHidden;
    }

    public string GetDisplayText(){
        return GetText();
    }

    //(2)
    //Setters
    private string SetText(string text){
        _text = text;
        return text;
    }
    private bool SetIsHidden(bool isHidden){
        _isHidden = isHidden;
        return isHidden;
    }

    //Getters    
    private string GetText(){
        return _text;
    }
    private bool GetIsHidden(){
        return _isHidden;
    }
}