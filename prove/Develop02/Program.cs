using System;
using System.IO;

/*In order to exceed the requirements I did the following:
(1) Entered a wrong input message that shows when the user enters a wrong value.
(2) In the Journal.cs class file the code was improved so when the file is loaded it doesn't add to what was already loaded, it only shows what was recently loaded and the new entries to the journal only intead of repeating them.*/
class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop02 World!");
        DateTime currentDate = DateTime.Now;

        Journal myJournal = new Journal();
        PromptGenerator myPrompt = new PromptGenerator();
        string userChoice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while(userChoice != "5"){
            Console.WriteLine("\nPlease select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            userChoice = (Console.ReadLine());

            switch(userChoice){
                case "1":
                    Entry myEntry = new Entry();

                    myEntry._promptText = myPrompt.GetRandomPrompt();
                    Console.WriteLine($"{myEntry._promptText}");
                    myEntry._entryText = Console.ReadLine();
                    myEntry._date = currentDate.ToShortDateString().ToString();
                    myJournal.AddEntry(myEntry);
                    break;
                case "2":
                    myJournal.DisplayAll();
                    break;
                case "3":
                    Console.WriteLine("What is the filename?");
                    myJournal.LoadFromFile(Console.ReadLine());
                    break;
                case "4":
                    Console.WriteLine("What is the filename?");
                    myJournal.SaveToFile(Console.ReadLine());
                    break;
                case "5":
                    break;
                default:
                    //(1)
                    Console.WriteLine("Wrong input, please enter a valid option.");
                    break;
            }
        }
    }
}
