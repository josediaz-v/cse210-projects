using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

public class Scripture{    
    private List<Word> _words = new List<Word>(){
    };

    public Scripture(Reference reference, string text){
        foreach(string word in text.Split(" ")){
            Word myWord = new Word(word);
            _words.Add(myWord);
        }
    }

    private void HideRandomWords(int numberToHide){
        for(int i=0; i<numberToHide;){
            Random randomGenerator = new Random();
            int random_number = randomGenerator.Next(0, _words.Count);
            if(!_words[random_number].IsHidden()){
                i++;
               _words[random_number].Hide();
            }
            else if(IsCompletelyHidden()){
                i = numberToHide;                
            }
        }
    }
    
    public string GetDisplayText(){

        string displayText = " ";
        foreach (Word word in _words){
            displayText += word.GetDisplayText()+" ";
        }

        HideRandomWords(1);
        IsCompletelyHidden();
        return displayText;
    }

    public bool IsCompletelyHidden(){

        bool isCompletelyHidden = true;
        int i=0;
        foreach(Word word in _words){
            if(word.IsHidden()){
                i++;
            }
            if(i >= _words.Count){
               isCompletelyHidden = true;
            }
            else{
                isCompletelyHidden = false;
            }
        }
        return isCompletelyHidden;
    }
}