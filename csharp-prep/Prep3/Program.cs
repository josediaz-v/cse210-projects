using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep3 World!");

        /*Console.Write("What is the magic number? ");
        int random_number = int.Parse(Console.ReadLine());*/

        string play = "yes";

        while(play == "yes"){
        Random randomGenerator = new Random();
        int random_number = randomGenerator.Next(1, 101);

        bool control = false;
        int guesses = 0;

            while(control == false){
                Console.Write($"What is your guess? ");
                int guess_number = int.Parse(Console.ReadLine());
                guesses+=1;
                
                if(guess_number > random_number){
                    Console.WriteLine("Lower");
                }
                else if(guess_number < random_number){
                    Console.WriteLine("Higher");
                }
                else{
                    Console.WriteLine($"You guessed it! it took you {guesses} guesses.");
                    control = true;
                }
            }

            Console.WriteLine("");
            Console.Write("Would you like to keep playing? ");
            play = Console.ReadLine();
        }
    }
}