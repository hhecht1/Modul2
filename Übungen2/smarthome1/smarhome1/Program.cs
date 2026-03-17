using System;
using System.ComponentModel;
using System.Dynamic;


public class Geräte
{
    public required string ModelName { get; init; }
    
    }
public class SmartLampe :Geräte
{
    public int Helligkeit {get;private set;}
    public List<string> Farbpalette {get;} = new();

    public SmartLampe(string name ): base () {}

    void SetzeFarben(params string[] farben)
    {
        Farbpalette.AddRange(farben);
        Console.WriteLine($"{farben.Length} Farben wurden hinzugefügt.");
    }

    public bool HelligkeitSteuerung(int wert, out string status)
    {
        if(wert >= 0 && wert <=100)
        {
            Helligkeit = wert;
            status = "Helligkeit auf {Helligkeit}% eingestellt.";
            return true;
        }
        status = "Ungültiger Wert. Bitte zwischen 0 und 100 eingeben.";
        return false;
    }



}

public class Program
{
    static void Main(string[] args)
    {
        SmartLampe lampe = new SmartLampe("Philips Hue");
        lampe.SetzeFarben("Rot", "Grün", "Blau");
        
        if(lampe.HelligkeitSteuerung(75, out string status))
        {
            Console.WriteLine(status);
        }
        else
        {
            Console.WriteLine(status);
        }
    }
}
