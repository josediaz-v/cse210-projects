using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep4 World!");

        List<int> numbers = new List<int>();

        string input_number = "";
        int sum = 0;
        float avg = 0;
        int max = 0;
        int min = 0;
        int i = 0;
        bool found_min = false;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        //While the input number is different to 0 it is added to the numbers list
        while(input_number != "0"){  
            Console.Write("Enter number: ");
            input_number = Console.ReadLine();
            sum += int.Parse(input_number);
            if(input_number != "0"){
                numbers.Add(int.Parse(input_number));
            }
        }

        //Get numbers list average
        avg = (float)sum/(numbers.Count);

        //Sort numbers list
        numbers.Sort();

        
        foreach(int number in numbers){
            //Get numbers list largest number
            if(number > max){
                max = number;
            }
        }


        //Get the smallest positive number)
        while(found_min == false){
            if(numbers[i]>0){
                min = numbers[i];
                found_min = true;
            }
            i++;
        }

        //Output
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {min}");
        Console.WriteLine($"The sorted list is:");

        foreach(int number in numbers){
            Console.WriteLine(number);
        }
    }
}