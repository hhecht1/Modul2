using System;
using System.Text.RegularExpressions;

namespace GetterSetterKonstruktoren
{
    
public class Person
    {
        public string name {get; private set; }
        public int alter {get;  set; }
        public string Geschlecht {get;  set; }

        public Person(string name,int alter,string geschlecht)
        {
            if(alter <0 || alter >150)
            throw new ArgumentException("Alter muss zwischen 0 und 150 liegen");

            if (geschlecht != "männlich" && geschlecht != "weiblich" && geschlecht != "divers")
                throw new ArgumentException("Geschlecht muss 'männlich', 'weiblich' oder 'divers' sein");
        }
    }


    public class Schüler
    {
        public string Name {get;set;}
        public string Klasse {get;set;}
        public double Note {get;set;}
        public Schüler(): this("Unbekannt","Unbekannt",5.0)
        {
        }
        public Schüler(string name,string klasse) : this(name,klasse,5.0)
        {
        }
        public Schüler(string name,string klasse,double note)
        {
            Name = name;
            Klasse = klasse;
            Note = note;
        }

        public Schüler(string name,string klasse,int note)
        {
           if(note <1.0 || note >6.0)
            {
                throw new ArgumentException("Note muss zwischen 1.0 und 6.0 liegen");
            }

            if(name ==null )
            {
                throw new ArgumentException("Name darf nicht null sein");
            }
            if(!Regex.IsMatch(klasse, @"^[7-9]|1[0-2][a-d]$") )
            {
                throw new ArgumentException("Klasse muss z.B '7a', '10b' oder '12c' sein");
            }
        }

        public class Bankkonto
        {
            public string Konotnummer {get;set;}
            public double Kontostand{get;private set;}
            public string Inhaber {get;set;}
        }
        public  Bankkonto(string Kontonummer,double kontostand ,string Inhaber)
        {
            if (kontostand <0)
            {
                throw new ArgumentException("Kontostand darf nicht negativ sein");
            }
        }

        public Bankkonto(string Kontonummer,string Inhaber): this (Kontonummer,0.0,Inhaber)
        {
            
        }
        public Bankkonto(string Kontonummer,double kontostand,string Inhaber){}
    }

    
}