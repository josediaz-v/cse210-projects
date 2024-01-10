using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep2 World!");

        Console.Write("What is your grade percentage? ");
        int percentage = int.Parse(Console.ReadLine());
        string letter  = "";
        string status = "";
        string sign = "";

        if(percentage >= 90){
            letter  = "A";
            status = "passed";
        }
        else if(percentage >= 80){
            letter  = "B";
            status = "passed";
        }
        else if(percentage >= 70){
            letter  = "C";
            status = "passed";
        }
        else if(percentage >= 60){
            letter  = "D";
            status = "failed";
        }
        else if(percentage < 60){
            letter  = "F";
            status = "failed";
        }

        if(percentage < 97 && percentage >= 60){
            if(percentage%10 >= 7){
                sign = "+";
            }
            else{
                sign = "-";
            }
        }

        Console.WriteLine("");
        Console.WriteLine($"Your grade is {letter}{sign}");
        
        if(status == "passed"){
            Console.WriteLine("Congratulations, you passed!");
        }
        else{
            Console.WriteLine("You can do better next time...");
        }
    }
}