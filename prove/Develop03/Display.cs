using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Display{
    private string scripture = "In the beginning God created the heaven and the earth.";
    private string userInput = "";
    private bool complete = false;
    public void DisplayScreen(){
        Reference myReference = new Reference("Genesis",1,1);
        Scripture myScripture = new Scripture(myReference, scripture);
        Print();

        void Print(){
            while(userInput != "quit"){
                Console.Clear();
                Console.WriteLine(myReference.GetDisplayText() + myScripture.GetDisplayText());
                Console.WriteLine("Press enter to continue or type 'quit' to finish:");
                userInput = Console.ReadLine();
                if(complete==true){
                    break;
                }
                if(myScripture.IsCompletelyHidden()){
                    complete = true;
                    Print();
                    break;
                }
            }

            if(userInput == "quit"){
                System.Environment.Exit(0);
            }
        }
    }
}