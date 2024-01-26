public class Reference{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

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
        string endVerse = GetEndVerse().ToString();;
        //Removes the 0 from a single verse Reference
        if(endVerse == "0"){
            endVerse = "";
        }
        else{
            endVerse = "-"+endVerse;
        }
        string displayText = GetBook() + " " + GetChapter() + ":" + GetStartVerse() + endVerse + " ";
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
    private string GetBook(){
        return _book;
    }

    private int GetChapter(){
        return _chapter;
    }

    private int GetStartVerse(){
        return _verse;
    }

    private int GetEndVerse(){
        return _endVerse;
    }
}