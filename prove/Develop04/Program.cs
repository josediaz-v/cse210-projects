using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop04 World!");
        /*In order to exceed the requirements I did the following:
        (1) This will avoid the user from choosing a different option.
        (2) I modified the spinner to stop when the activity time ends if it does not reach the time of the spinner*/
        string userInput = "";

        while (userInput != "4"){
            Console.Clear();
            Console.Write("Menu Options\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. Quit\nSelect a choice from the menu: ");
            userInput = Console.ReadLine();
            switch (userInput){
                case "1":
                    BreathingActivity myBreathingActivity = new BreathingActivity();
                    break;
                case "2":
                    ReflectingActivity myReflectingActivity = new ReflectingActivity();
                    break;
                case "3":
                    ListingActivity myListingActivity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("\nThank you for using this program");
                    break;
                //(1)
                default:
                    break;
            }
        } 
    }
}