// using System;
// using System.Net.Mail;
// using System.Text.RegularExpressions;

// public class Person
// {
//     private string name
//     {
//         get => _name;
//         set
//         {
//             if(string.IsNullOrEmpty(value))
//             {
//                 throw new ArgumentException("Name darf nicht leer sein.", nameof(name));
//             }
//             _name = value;

//         }
//     }
//     private int _alter;
//     public int alter
//     {
//         get => _alter;
//         set
//     {
//         if (value < 0 || value > 120)
//         {
//             throw new ArgumentException("Alter muss zwischen 0 und 120 liegen.", nameof(alter));
//         }
//         _alter = value;
//     }
//     }
//     public string Geschlecht
//     {
//         get => _geschlecht;
//         set
//         {
//             if(value != "männlich" && value != "weiblich" && value != "divers")
//             {
//                 throw new ArgumentException("Geschlecht muss 'männlich', 'weiblich' oder 'divers' sein.", nameof(Geschlecht));
//             }
//             _geschlecht = value;
//         }
//     }
//     public Person(string name, int alter, string geschlecht)
//     {
//         Name = name;
//         Alter = alter;
//         Geschlecht = geschlecht;
//     }

// public class Bankkonto
//     {
//         public string Kontonummer{get;}
//         public double Kontostand{
//           get => _kontostand;
//           set
//             {
//                 if(value <0)
//                 {
//                     throw new ArgumentException("Kontostand darf nicht negativ sein.", nameof(Kontostand));
//                      _kontostand = value;
//         }
//                 }
//             }

//         public string Inhaber{get;}

//         public Bankkonto(string kontonummer, string inhaber, double kontostand)
//         {
//             Kontonummer = kontonummer;
//             Inhaber = inhaber;
//             Kontostand = kontostand;
//         }
//         public Bankkonto(string kontonummer, string inhaber) 
//         {
//             Kontonummer = kontonummer;
//             Inhaber = inhaber;
//             Kontostand = 0.0;

//         }
//     }

//     public class Schüler
//     {
//         private string _name;
//         private int _alter;
//         private string _geschlecht;
//         private string _klasse;
//         private int _note;
//         public  string Name
//         {
//             get => _name;
//             set
//             {
//                 if(string.IsNullOrEmpty(value))
//                 {
//                     throw new ArgumentException("Name darf nicht leer sein.", nameof(Name));
//                 }
//                 _name = value;

//             }
//         }
//         public int _alter
//         {
//             get => _alter;
//             set
//             {
//                 if(value < 0 || value > 120)
//                 {
//                     throw new ArgumentException("Alter muss zwischen 0 und 120 liegen.", nameof(Alter));
//                 }
//                 _alter = value;
//             }
//         }
//         public string _geschlecht
//         {
//             get => _geschlecht;
//             set
//             {
//                 if(value != "männlich" && value != "weiblich" && value != "divers")
//                 {
//                     throw new ArgumentException("Geschlecht muss 'männlich', 'weiblich' oder 'divers' sein.", nameof(Geschlecht));
//                 }
//                 _geschlecht = value;
//             }
//         }
//         public int _note
//         {
//             get => _note;
//             set
//             {
//                 if(value <1 || value > 6)
//                 {
//                     throw new ArgumentException("Note muss zwischen 1 und 6 liegen.", nameof(Note));
//                 }
//                 _note = value;
//             }
//         }

//         public string Klasse
//         {
//             get => _klasse;
//             set
//             {
//                 if(string.IsNullOrEmpty(value))
//                 {
//                     throw new ArgumentException("Klasse darf nicht leer sein.", nameof(Klasse));
//                 }
//                 _klasse = value;
//                 if(!Regex.IsMatch(value, @"^[7-9]1[0-2]?[a-d]$"))
//                 {
//                     throw new ArgumentException("Klasse muss im Format '7a', '8b', '9c', '10a', '11b' oder '12c' sein.", nameof(Klasse));
//                 }
//             }
//         }

//         public int Note
//         {
//             get => _note;
//             set
//             {
//                 if(value <1 || value > 6)
//                 {
//                     throw new ArgumentException("Note muss zwischen 1 und 6 liegen.", nameof(Note));
//                 }
//                 _note = value;
//             }
//         }

//         public Schüler(string name, int alter,string geschlecht)
//         {
//             Name = name;
//             Alter = alter;
//             Geschlecht = geschlecht;
//             Klasse = _klasse;
//             Note = _note;
//         }
//         public Schüler() : this("Unbekannt", 0, "Unbekannt")
//         {}
//         public Schüler(string name, string klasse): this(name,klasse,5.0){}
//         public Schüler(string name,string klasse,double note)
//         {
//             Name = name;
//             Klasse = klasse;
//             Note = (int)note;
//         }
//         public Schüler() : this("Max Mustermann", "10a", 5.0)
//         {}

//     }
// }
using System.Text.RegularExpressions;
using system;

public class Person


{

    private string _name;
    private int _alter;
    private string _geschlecht;
    public string Name
    {
        get => _name;
        set
        {
            _name = value ?? throw new ArgumentException("Name darf nicht null sein.", nameof(Name));
        }
    }
    public int Alter
    {
        get => _alter;
        set
        {
           if(value <0 || value >120)
            {
                throw new ArgumentException("Alter muss zwischen 0 und 120 liegen.", nameof(Alter));
            }
            _alter = value;
        }
    }

    public string Geschlecht
    {
        get => _geschlecht;
        set
        {
            if(value != "männlich" && value != "weiblich" && value != "divers")
            {
                throw new ArgumentException("Geschlecht muss 'männlich', 'weiblich' oder 'divers' sein.", nameof(Geschlecht));
            }
            _geschlecht = value;
        }
    }

    public Person(string name, int alter, string geschlecht)
    {
        Name = name;
        Alter = alter;
        Geschlecht = geschlecht;
    }
}

public class Bankkonto
{
    private double _kontostand;

    public string Inhaber { get; }
    public string Kontonummer { get; }

    public double Kontostand
    {
        get => _kontostand;
        set
        {
            if (value < 0)
                throw new ArgumentException("Kontostand darf nicht negativ sein.", nameof(Kontostand));

            _kontostand = value;
        }
    }

    public Bankkonto(string kontonummer, string inhaber, double kontostand)
    {
       

        Kontonummer = kontonummer;
        Inhaber = inhaber;
        Kontostand = kontostand;  
    }

    public Bankkonto(string kontonummer, string inhaber)
       
    {
        Kontonummer = _kontonummer;
        Inhaber = _inhaber;
        Kontostand = 0.0;
    }
}

public class Schüler


{
    private string _name;
    private string _klasse;
    private double _note;

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentException("Name darf nicht null sein.", nameof(Name));
    }

    public string Klasse
    {
        get => _klasse;
        set
        {
            if(!Regex.IsMatch(value, @"^[7-9]1[0-2]?[a-d]$"))
            {
                throw new ArgumentException("Klasse muss im Format z.B. '7a', '8b', '9c', '10a', '11b' oder '12c' sein.", nameof(Klasse));
                _klasse =value;
            }
            _klasse = value;
        }
    }
    public double Note
    {
        get => _note;
        set
        {
            if(value <1.0 || value >6.0)
            {
                throw new ArgumentException("Note muss zwischen 1.0 und 6.0 liegen.", nameof(Note));
            }
            _note = value;
        }
    }
    public Schüler() : this("Unbekannt","Unbekannt",5.0){}
    public Schüler(string name, string klasse) :this (name,klasse,5.0){}
    public Schüler(string name, string klasse, double note)
    {
        Name = name;
        Klasse = klasse;
        Note = note;
    }
    
    
}

public class Buch
{
    private string _title;
    private string _autor;
    private int _seitenzahl;
    private int _erscheinungsjahr;

    public string Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentException("Titel darf nicht null sein.", nameof(Title));
    }
    public string Autor
    {
        get => _autor;
        set => _autor = value ?? throw new ArgumentException("Autor darf nicht null sein.", nameof(Autor));
    }

    public int Seitenanzahl
    {
        get => __seitenanzahl;
        set
        {
            if(value <=0)
            {
                throw new ArgumentException("Seitenanzahl muss positiv sein.", nameof(Seitenanzahl));
            }
            _seitenanzahl = value;
        }
    }
    public int Erscheinungsjahr
    {
        get => _erscheinungsjahr;
        set
        {
            if (value < 1000 || value > DateTime.Now.Year)
            {
                throw new ArgumentException($"Erscheinungsjahr muss zwischen 1000 und {DateTime.Now.Year} liegen.", nameof(Erscheinungsjahr));
            }
            _erscheinungsjahr = value;

        }
    }

    public Buch(string title,string autor, int seitenanzahl)
    {
        Title = title;
        Autor = autor;
        Seitenanzahl = seitenanzahl;
        Erscheinungsjahr = DateTime.Now.Year;
    }
    public Buch (string title,string autor,int seitenanzahl,int erscheinungsjahr)
    {
        Title = title;
        Autor = autor;
        Seitenanzahl = seitenanzahl;
        Erscheinungsjahr = erscheinungsjahr;
    }
}

