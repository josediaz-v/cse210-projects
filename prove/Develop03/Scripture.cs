public class Scripture{
    Reference _reference = new Reference();

    List<string> _words = new List<string>(){
        "In the beginning God created the heaven and the earth",
        "And the earth was without form, and void; and darkness was upon the face of the deep. And the Spirit of God dmoved upon the face of the waters."
    };

    public Scripture(Reference reference, string text){

    }

    private void HideRandomWords(int numberToHide){

    }
    
    public string GetDisplayText(){
        string displayText = "";
        return displayText;
    }

    private bool IsCompletelyHidden(){
        bool isHidden = false;
        return isHidden;
    }
}