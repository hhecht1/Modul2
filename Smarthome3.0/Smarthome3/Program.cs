using System;

namespace Smarthome3
{
    public enum Gerätetyp
    {
        Licht,Heizung,Sicherheit,Energie
    }

    public struct StatusInfo
    {
        public double Wert;
        public string Einheit;
        public StatusInfo(double wert,string einheit)
        {
            Wert = wert;
            Einheit = einheit;

        }
        public override string ToString() => $"{Wert} {Einheit}";
        
    }

    public interface Controller
    {
        public void TurnOn();
        public void TurnOff();
    }
    public abstract class SmartGerät : Controller
    {
        public string Name {get;set;}
        public Gerätetyp Typ {get;set;}

        public abstract string GetStatus();
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Gerät: {Name} und {Typ} | Status: {GetStatus()}");
        }

        public abstract void TurnOn();
        public abstract void TurnOff();
    }

    public class SmartLamp :SmartGerät
    {
        public bool iSoN {get; private set;}

        public int Helligkeit {get; set;}

        public override void TurnOn()
        {
            Console.WriteLine("Die Lampe ist jetzt an.");
            iSoN = true;    
        }
        public override void TurnOff()
        {
            Console.WriteLine("Die Lampe ist jetzt aus.");
            iSoN = false;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        public override string GetStatus() => iSoN ? $"Lampe ist an und bei ({Helligkeit}%) Helligkeit" : " Lampe ist Aus";

        public void Dimmen(int wert )=> Helligkeit = wert;

    }

    public class SmartThermostat : SmartGerät
    {
        public bool heatingIsOn {get; private set;}

        public int Temperature {get; set;}

        public override void TurnOn()
        {
            Console.WriteLine("Die Heizung ist jetzt an.");
            heatingIsOn = true;
        }

        public override void TurnOff()
        {
            Console.WriteLine("Die Heizung ist jetzt aus.");
            heatingIsOn = false;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        public override string GetStatus() => heatingIsOn ? $"Heizung ist an und bei ({Temperature}°C)" : "Heizung ist aus";
    }

    public class SmartSecurity : SmartGerät
    {
        public bool SecurityIsOn {get; private set;}
        public int CameraCount {get; set;}

        public override void TurnOn()
        {
            Console.WriteLine("Die Sicherheit ist jetzt an.");
            SecurityIsOn = true;
        }

        public override void TurnOff()
        {
            Console.WriteLine("Die Sicherheit ist jetzt aus.");
            SecurityIsOn = false;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }
        public override string GetStatus() => SecurityIsOn ? $"Im Moment laufen  ({CameraCount} Kameras)" : "Sicherheit ist aus";

       
    }

    public class Smartenergy : SmartGerät
    {
        public bool EnergyIsOn {get; private set;}
        public int EnergyUsage {get; set;}

        public override void TurnOn()
        {
            Console.WriteLine("Die Energie ist jetzt an.");
            EnergyIsOn = true;
        }
        public override void TurnOff()
        {
            Console.WriteLine("Die Energie ist jetzt aus.");
            EnergyIsOn = false;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
        }
         public override string GetStatus() => EnergyIsOn ? $"Energiegewinnung ist an und bei ({EnergyUsage} kWh)" : "Energiegewinnung ist aus";
    }
}