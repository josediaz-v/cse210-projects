using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning03 World!")
        Fraction fraction = new Fraction();
        fraction.GetFractionString();
        fraction.GetDecimalValue();

        fraction = new Fraction(5);
        fraction.GetFractionString();
        fraction.GetDecimalValue();

        fraction = new Fraction(3, 4);
        fraction.GetFractionString();
        fraction.GetDecimalValue();
        
        fraction = new Fraction(1, 3);
        fraction.GetFractionString();
        fraction.GetDecimalValue();
    }
}