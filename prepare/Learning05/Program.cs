using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning05 World!");
        List<Shape> myList = new List<Shape>();

        Square square = new Square("Red", 4);
        Rectangle rectangle = new Rectangle("Blue", 4, 2);
        Circle circle = new Circle("Green", 3);

        myList.Add(square);
        myList.Add(rectangle);
        myList.Add(circle);

        foreach(Shape shape in myList){
            Console.WriteLine($"The {shape.color} shape has an area of {shape.GetArea()}.");
        }
    }
}