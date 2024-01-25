public class Reference{
    string _book;
    int _chapter;
    int _verse;
    int _endVerse;

    public Reference(string book, int chapter, int verse){
        SetBook(book);
        SetChapter(chapter);
        SetStartVerse(verse);
    }

    public Reference(string book, int chapter, int startVerse, int endVerse){
        SetBook(book);
        SetChapter(chapter);
        SetStartVerse(startVerse);
        SetEndVerse(endVerse);
    }

    public string GetDisplayText(){
        string displayText = "";
        return displayText;
    }

    //Setters
    private string SetBook(string book){
        _book = book;
        return book;
    }

    private int SetChapter(int chapter){
        _chapter = chapter;
        return chapter;
    }

    private int SetStartVerse(int verse){
        _verse = verse;
        return verse;
    }

    private int SetEndVerse(int endVerse){
        _endVerse = endVerse;
        return endVerse;
    }

    //Getters
    public string GetBook(){
        return _book;
    }

    public int GetChapter(){
        return _chapter;
    }

    public int GetStartVerse(){
        return _verse;
    }

    public int GetEndVerse(){
        return _endVerse;
    }
}