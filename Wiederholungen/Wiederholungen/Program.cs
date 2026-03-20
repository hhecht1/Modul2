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
    }
}