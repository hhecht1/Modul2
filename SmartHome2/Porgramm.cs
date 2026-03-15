using System;
using System.Security.Cryptography.X509Certificates;

namespace SmartHome
{
    public enum DeviceType
    {
        Light,Heating,security
    }


public struct StatusInfo
{
    public double Wert;
    public string Einheit;
}

public interface Controll
{
    void TurnOn();
    void TurnOff();


}

public abstract class SmartDevice : Controll
{
    public string Name {get; set; }
    public DeviceType Typ { get; set; }
    public abstract string GetStatus();
    public abstract void TurnOn();
    public abstract void TurnOff();
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Device: {Name}, Type: {Typ}");
    }


}

public class SmartLamp : SmartDevice
{
    public override void TurnOn() => IsOn = true;
    public override void TurnOff() => IsOn = false;

    public override void ShowInfo()
    {
        base.ShowInfo();
        Brightness = 100;
    }
    public override string GetStatus() => IsOn ? "On" : "Off";
    public bool IsOn { get; private set; }

    public int Brightness { get; set; }

    public void Dim(int value) => Brightness = value;
}

public class Thermostat : SmartDevice
{
    public override void TurnOn() => heating = true;
    public override void TurnOff() => heating = false;

    public override string GetStatus() => heating ? "Heating is on " : " Heating is off";
    private bool heating { get; set; }

    public StatusInfo Temperature { get; set; }

}

public class AlarmSystem: SmartDevice
    {
        public override void TurnOn() => armed = true;
        public override void TurnOff() => armed = false;

        public override string GetStatus() => armed ? "System Armed" : "System Disarmed";
        private bool armed { get; set; }


    }

class Programm
{
    public static void Main (string[] args)
    {
        List<SmartDevice> devices = new List<SmartDevice>
        {
            new SmartLamp { Name = "Living Room Lamp"  },
            new Thermostat { Name = "Main Thermostat"},
            new AlarmSystem { Name = "Home Security System" }
            
        };

        Console.WriteLine("----------------Smart Home Devices----------------");
        foreach (var device in devices)
        {
            device.TurnOn();
            Console.WriteLine($"{device.Name} Status: {device.GetStatus()}");
            device.ShowInfo();
            if (device is SmartLamp lamp)
            {
                Console.WriteLine($"Brightness: {lamp.Brightness}%");
                Console.WriteLine($" We will dim the lamp now ");
                lamp.Dim(50);
                Console.WriteLine($"Brightness after dimming: {lamp.Brightness}%");
            }
            else if (device is Thermostat thermostat)            {
                Console.WriteLine($"Temperature: {thermostat.Temperature.Wert} {thermostat.Temperature.Einheit}");
            }
            else if (device is AlarmSystem alarm)
            {
                Console.WriteLine($"Status: {alarm.GetStatus()}");
            }
            Console.WriteLine();
        }



    }
}
}