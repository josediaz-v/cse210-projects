using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    /*In order to exceed the requirements I did the following:
    (1) Added a Display Class to better manage the input and output improving the encapsulation.
    (2) Added Getters and Setters.*/
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop03 World!");

        //(1)
        Display _display = new Display();
        _display.DisplayScreen();
    }
}