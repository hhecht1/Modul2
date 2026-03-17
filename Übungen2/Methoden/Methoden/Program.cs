using System;

namespace Methoden
{
    static void BerechneRechteck(double leange,double breite)
    {
        double fläche = leange * breite;
        Console.WriteLine($"Die Fläche: {fläche}");
        BerechneRechteck(5.0, 3.0);
    }
    

     static void Begrüßung(string Name = "Gast", string anrede = "Hallo")
     {
        Console.WriteLine($"{anrede} {Name}!");
     }
        Begrüßung();
        

        public static void PrintProfil(string vorname,string nachname,int alter =0, string Stadt = "unbekannt")
        {
            Console.WriteLine($"Name: {vorname} {nachname}");
            Console.WriteLine($"Alter: {alter}");
            Console.WriteLine($"Stadt: {Stadt}");  
            PrintProfil("Helge", "Schneider", 65, "Berlin");
   
        }

        static internal int SummiereZahlen(params int[] zahlen)
        {
            int summe  = 0;
            foreach(int z in zahlen) summe += z;
            return summe;
        }

        static void LogNachrichten(string kategorie, string präfix = "LOG", params string[] nachrichten)
    {
        Console.Write($"[{präfix}] [{kategorie}]");
        Console.WriteLine(string.Join(", ", nachrichten));
        
        LogNachrichten("Fehler", "ERROR", "Datei nicht gefunden", "Zugriff verweigert");
    }

    public class Teilnehmer
    {
        public string Name { get; set; }
        public int Alter { get; set; }

        public Teilnehmer (string name, int alter)
        {
            Name = name;
            Alter = alter;
        }
    }
    public class EventPlaner
    {
        public void RegistriereTeilnehmer( string eventName,string kategorie ="Standard", bool Bestätigung =true,params Teilnehmer[] personen)
        {
            Console.WriteLine($"-----Registrierung für {eventName}-----");

            foreach (var teilnehmer in personen)
            {
                Console.WriteLine($"Name: {teilnehmer.Name}, Alter: {teilnehmer.Alter}");
            }
            if (Bestätigung)
            {
                foreach (var teilnehmer in personen)
                {
                    Console.WriteLine($"[{kategorie}] Teilnehmer: {teilnehmer.Name},{teilnehmer.Alter} wurde erfolgreich registriert.");
                }
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           EventPlaner planer = new EventPlaner();
              Teilnehmer t1 = new Teilnehmer("Anna", 28);
                Teilnehmer t2 = new Teilnehmer("Ben", 35);
                Teilnehmer t3 = new Teilnehmer("Clara", 22);
            planer.RegistriereTeilnehmer("Konferenz", "VIP", true, t1, t2, t3);
            planer.RegistriereTeilnehmer("Workshop", "Standard", false, t1, t2);
        }
        
    }
      
}
