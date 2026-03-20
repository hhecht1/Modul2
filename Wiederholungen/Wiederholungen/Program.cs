using System;
using System.Runtime.CompilerServices;

namespace Wiederholungen
{
    public enum Gerätetyp
    {
        Licht,Heizung,Sicherheit,Unterhaltung
    }

    public struct StatusInfo
    {
        public double Wert;
        public string Einheit;
    }

    public interface Controller
    {
        public void Einschalten();
        public void Ausschalten();

    }
    public abstract class SmartGerät : Controller
    {
        public string Name {get;set;}
        public Gerätetyp Typ {get;set;}

        public abstract  string GetStatus();
        public virtual void ZeigeInfo()
        {
            Console.WriteLine($"Gerät: {Name} und {Typ}");
        }
        public abstract void Einschalten();
        public abstract void Ausschalten();


    }

    public class SmartLamp : SmartGerät
    {
        public bool IsOn {get; private set;}
        public abstract void Einschalten() 
        {
            Console.WriteLine("Die Lampe ist jetzt an.");
            IsOn = true;
        }
        public abstract void Ausschalten() 
        {
            Console.WriteLine("Die Lampe ist jetzt aus.");
            IsOn = false;
        }

        public SmartLamp(string name ): base(name,Gerätetyp.Licht)
        {
        }

        public override string GetStatus() => IsOn ? $"An ({Helligkeit}%)" : "Aus";

        public override void ZeigeInfo()
        {
            base.ZeigeInfo();

        }

        public void Dimmen(int wert)
        {
            if(IsOn)
            {
                Console.WriteLine($"Die Lampe wird auf {wert}% gedimmt.");
            }
            else
            {
                Console.WriteLine("Die Lampe ist aus. Bitte zuerst einschalten.");
            }
        }

    }
    public class Smartthermostat : SmartGerät
    {

        public bool Heizen {get; private set;}

        public StatusInfo Temperatur {get;  set;}
        public abstract void Einschalten() 
        {
            Console.WriteLine("Das Thermostat ist jetzt an.");
            Heizen = true;
        }
        public abstract void Ausschalten() 
        {
            Console.WriteLine("Das Thermostat ist jetzt aus.");
            Heizen = false;
        }

        public struct StatusInfo
        {
            public double Temperatur;
            public string Einheit;
        }

        public override string GetStatus()=> Heizen ? $"Heizt bei {Temperatur.Temperatur} {Temperatur.Einheit}" : "Aus"; 

        public Thermostat(string name) : base(name, Gerätetyp.Heizung)
        {
            Temperatur = new StatusInfo { Temperatur = 22.0, Einheit = "°C" };
        }
    }

    public class Programm
    {
        public static void Main(string[] args)
        {
            List<SmartGerät> MeineGeräte = new List<SmartGerät>
            {
                new SmartLamp("Wohnzimmer Lampe"),
                new Smartthermostat("Wohnzimmer Thermostat")
            };
            Console.WriteLine("Willkommen zum Smart Home System!");
            foreach(var geräte in MeineGeräte)
            {
                geräte.Einschalten();
                geräte.ZeigeInfo();
                Console.WriteLine($"Status: {geräte.GetStatus()}");
                Console.WriteLine();
                if(geräte is Smartthermostat thermostat)
                {
                    thermostat.Temperatur = new StatusInfo { Temperatur = 24.0, Einheit = "°C" };
                    Console.WriteLine($"Aktualisierter Status: {thermostat.GetStatus()}");
                }
            }
            SmartLamp lampe = Gerätetyp as SmartLamp;
            if(lampe != null)
            {
                lampe.Dimmen(50);
                Console.WriteLine($"Aktualisierter Status: {lampe.GetStatus()}");
            }
            Console.WriteLine("Vielen Dank für die Nutzung des Smart Home Systems!");

        }
    }

    
}