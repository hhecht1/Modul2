//using System;
//using System.Collections.Generic;
//using System.Xml.Serialization;
//
//// Namespace für die SmartHome-Anwendung
//namespace SmartHome
//{
//    // Enum für die verschiedenen Gerätetypen
//    public enum Gerätetyp
//    {
//        Licht,      // Lichter
//        Heizung,    // Heizmittel
//        Sicherheit  // Sicherheitsgeräte
//    }
//
//    // Struct für Statusinformationen (Wert und Einheit)
//    public struct StatusInfo
//    {
//        public double Wert;     // Der Messwert
//        public string Einheit;  // Die Maßeinheit (z.B. °C)
//    }
//
//    // Interface für steuerbare Geräte
//    public interface IsSteuerbar
//    {
//        void Einschalten();  // Gerät einschalten
//        void Ausschalten();  // Gerät ausschalten
//    }
//
//    // Abstrakte Basisklasse für Smart-Geräte
//    public abstract class SmartGerät : IsSteuerbar
//    {
//        public string Name { get; set; }           // Name des Geräts
//        public Gerätetyp Typ { get; set; }         // Gerätetyp
//        public abstract string GetStatus();         // Abstrakte Methode für Status
//        public abstract void Einschalten();         // Abstrakte Methode zum Einschalten
//        public abstract void Ausschalten();         // Abstrakte Methode zum Ausschalten
//        
//        // Virtuelle Methode, die Geräteinformationen anzeigt
//        public virtual void ZeigeInfo()
//        {
//            Console.WriteLine($"Gerät: {Name}, Typ: {Typ}");
//        }
//    }
//
//    // Klasse für Smart-Lampen
//    public class SmartLamp : SmartGerät
//    {
//        public override string GetStatus() => IstAn ? "An" : "Aus";  // Gibt Status zurück
//        public bool IstAn { get; private set; }                       // Property für An/Aus Status
//
//        // Überschreibt die ZeigeInfo Methode und setzt Helligkeit auf 100%
//        public override void ZeigeInfo()
//        {
//            base.ZeigeInfo();               // Ruft die Basisklassenmethode auf
//            Helligkeit = 100;
//        }
//        
//        public int Helligkeit { get; set; }  // Property für Helligkeit (0-100%)
//
//        // Implementierung der abstrakten Methoden
//        public override void Einschalten() => IstAn = true;
//        public override void Ausschalten() => IstAn = false;
//
//        // Methode zum Dimmen (Helligkeit ändern)
//        public void Dimmen(int Wert) => Helligkeit = Wert;
//    }
//
//    // Klasse für Smart-Thermostat
//    public class Thermostat : SmartGerät
//    {
//        public override string GetStatus() => heizt ? "Heizt" : "Aus";  // Gibt Status zurück
//        private bool heizt { get; set; }                                 // Property für Heizstatus
//
//        public StatusInfo Temperatur { get; set; }  // Aktuelle Temperatur mit Einheit
//
//        // Implementierung der abstrakten Methoden
//        public override void Einschalten() => heizt = true;
//        public override void Ausschalten() => heizt = false;
//    }
//
//    // Hauptprogramm
//    class Programm
//    {
//        public static void Main(string[] args)
//        {
//            // Erstellt eine Liste mit Smart-Geräten
//            List<SmartGerät> Geräte = new List<SmartGerät>
//            {
//                new SmartLamp { Name = "Wohnzimmer" },
//                new Thermostat { Name = "Schlafzimmer" }
//            };
//
//            Console.WriteLine("Smart Home Geräte:");
//            
//            // Iteriert über alle Geräte
//            foreach (var Gerät in Geräte)
//            {
//                Gerät.Einschalten();      // Schaltet Gerät ein
//                Gerät.ZeigeInfo();        // Zeigt Geräteinformationen
//
//                // Prüft, ob das Gerät eine Lampe ist
//                if (Gerät is SmartLamp lampe)
//                {
//                    // Gibt Status und Helligkeit aus
//                    Console.WriteLine($"Status: {lampe.GetStatus()}, Helligkeit: {lampe.Helligkeit}%");
//                    lampe.Dimmen(50);     // Dimmt Lampe auf 50%
//                    Console.WriteLine($" Lampe wurde Gedimmt auf: {lampe.Helligkeit}%");
//                }
//                // Prüft, ob das Gerät ein Thermostat ist
//                else if (Gerät is Thermostat thermostat)
//                {
//                    // Gibt Status und Temperatur aus
//                    Console.WriteLine($"Status: {thermostat.GetStatus()}, Temperatur: {thermostat.Temperatur.Wert} {thermostat.Temperatur.Einheit}");
//                }
//                Console.WriteLine();  // Leerzeile für bessere Lesbarkeit
//            }
//        }
//    }
//}