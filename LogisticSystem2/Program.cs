using System;
using LogisticSystem;

namespace LogisticSystem
{
    public enum VersandStatus
    {
        Eingegangen,InBearbeitung,Verandt,Geliefert
    }
    public struct PaketMaße
    {
        public double Länge,Breite,Höhe;
        // Konstruktor und Methode BerrechneVolumen

        public PaketMaße(double länge, double breite, double höhe)
        {
            Länge = länge;
            Breite = breite;
            Höhe = höhe;
        }

        public double BerechneVolumen()
        {
            return Länge * Breite * Höhe;
        }

        public override string ToString() => $"Länge: {Länge} cm, Breite: {Breite} cm, Höhe: {Höhe} cm";

    }

    public interface Versandfähig
    {
        double VersandGewicht { get; }
        public void GenerierenVersandetikett();
        void GenerierenVersandEtikett();
    }

    public abstract class Produkt
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal BasisPreis { get; set; }
        protected Produkt(string sku,string name,decimal preis)
        {
            SKU = sku;
            Name = name;
            BasisPreis = preis;
        }
        public abstract decimal BerechneEndPreis();
        public virtual void PrintProduktDetails()
        {
            Console.WriteLine($"Produkt: {Name} (SKU: {SKU})");
        }
    }
    public class PhysischesProdukt : Produkt, Versandfähig
    {
        public PaketMaße Maße { get; set; }
        public double Versandgewicht { get; set; }

        public double VersandGewicht => throw new NotImplementedException();

        public PhysischesProdukt(string sku, string name, decimal preis, PaketMaße maße, double versandgewicht) : base(sku, name, preis)
        {
            Maße = maße;    
            Versandgewicht = versandgewicht;
        }
        //TODO BerechneEndpreis (PReis +19% MST)

        public override decimal BerechneEndPreis() => BasisPreis * 1.19m;

        //TODO: GenerierenVersandetikett

        public virtual void GenerierenVersandEtikett()
        {
            Console.WriteLine($"Versandetikett für {Name} (SKU: {SKU})");
            Console.WriteLine($"Maße: {Maße}");
            Console.WriteLine($"Versandgewicht: {Versandgewicht} kg");
        }

        public void GenerierenVersandetikett()
        {
            throw new NotImplementedException();
        }
    }

    public class DigitalesProdukt : Produkt
    {
        public string Downloadlink { get; set; }

        public DigitalesProdukt(string sku, string name, decimal preis, string downloadlink) : base(sku, name, preis)
        {
            Downloadlink = downloadlink;
        }

            //ToDO BerechneEndpreis (Festpreis ohne Steuer)
            public override decimal BerechneEndPreis() => BasisPreis;

        public override void PrintProduktDetails()
        {
            base.PrintProduktDetails();
            Console.WriteLine($"Downloadlink: {Downloadlink}");
        }



        }
    }

    public class HandleWithCare :PhysischesProdukt
{
        public HandleWithCare(string sku, string name, decimal preis, PaketMaße maße, double versandgewicht) : base(sku, name, preis, maße, versandgewicht)
        {
        }

        public override void GenerierenVersandEtikett()
        {
            base.GenerierenVersandEtikett();
            Console.WriteLine("Achtung: Zerbrechlich! Bitte vorsichtig behandeln.");
        }
}

    class Programm
    {
        public static void Main(string[] args)
        {
            //Produkte hinzufügen(Pyshisch ,Digital und Zerbrechlich)

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Logistiksystem - Produktverwaltung");

            List<Produkt> produkte = new List<Produkt>()
            {
                new PhysischesProdukt("SKU123", "Laptop", 999.99m, new PaketMaße(30, 20, 5), 2.5),
                new DigitalesProdukt("SKU456", "E-Book", 19.99m, "https://example.com/download/ebook"),
                new HandleWithCare("SKU789", "Glasvase", 49.99m, new PaketMaße(15, 15, 30), 1.0)
             };
       
         // Schleife mit is/as logik

         foreach (var artikel in produkte)
         {
             artikel.PrintProduktDetails();
             Console.WriteLine($"Endpreis: {artikel.BerechneEndPreis():C}");
             if (artikel is Versandfähig versandArtikel)
             {
                 versandArtikel.GenerierenVersandEtikett();
             }
             Console.WriteLine(new string('-', 40));

             PhysischesProdukt? physischesProdukt = artikel as PhysischesProdukt;
             if (physischesProdukt != null)
             {
                 Console.WriteLine($" Paket: Maße: {physischesProdukt.Maße}, Versandgewicht: {physischesProdukt.Versandgewicht} kg");
             }
             Console.WriteLine(new string('-', 40));
         }
         Console.WriteLine("Programmende. Drücken Sie eine Taste zum Beenden.");
         Console.ReadKey();
        }

}
