using System;
using Smarthome1._0;

namespace Smarthome1._0
{
    public class Geräte
    {
        public required int ModelName{get;init;}


    }
    public class SmartLampe : Geräte
    {
        public int Helligkeit {get;private set;}
        public List<string> Farbpalette {get;} = new();
        public SmartLampe(string Name) : base()
        {
            ModelName = Name;
            Console.WriteLine($"Geräte {ModelName} wurde erstellt");
        }

        public void SetztFarben(params string[]farben)
        {
            Farbpalette.AddRange(farben);
            Console.WriteLine($"Farben {farben.Length} wurden zur Farbpalette hinzugefügt");
        }

        public bool VersucheHelligkeitEinstellen(int wert,out string status)
        {
            if(wert >=0 && wert <=100)
            {
                Helligkeit=wert;
                status = "Helligkeit wurde erfolgreich eingestellt";
                return true;
            }
            status = "Ungültiger Wert. Helligkeit muss zwischen 0 und 100 liegen";
            return false;
        }
    


    public static void Main(string[]args)
        {
            SmartLampe lampe = new("Philips Hue");
            lampe.SetztFarben("Rot","Grün","Blau");
        if (lampe.VersucheHelligkeitEinstellen(150,out string status))
        {
            Console.WriteLine(status);
        }
        else
        {
            lampe.VersucheHelligkeitEinstellen(50,out status);
            Console.WriteLine($"Korrekturversuch: {status}");
        }
            Console.WriteLine($"Aktuelle Helligkeit: {lampe.Helligkeit}%");
        }
    }
}

    
       



