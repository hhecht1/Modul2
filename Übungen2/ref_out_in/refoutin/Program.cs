using System;



void Swap(ref int a, ref int b)
    {
        int zahl = a;
        a = b;
        b = zahl;
    }
    Swap(ref x, ref y);
    Console.WriteLine($"x: {x}, y: {y}");


     void GetCircleStats(double radius,out double area,out double circumference)
    {
        area = Math.PI * radius * radius;
        circumference = 2 * Math.PI * radius;
    }
    GetCircleStats(10, out double area, out double circumference);




class Program
{
    static void Main(string[] args)
    {
        int number= 5;
        Console.WriteLine($"Before: {number}");
        IncrementByRef(ref number);
        Console.WriteLine($"After: {number}");
    }

    static void IncrementByRef(ref int value)
    {
        value++;
    }

}