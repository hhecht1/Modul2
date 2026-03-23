using System;

namespace Wiederholungen
{
    public enum VersandStatus
    {
        Eingegangen,InBearbeitung,Verandt,Geliefert
    }

    public struct PaketMaße
    {
        public double Länge;
        public double Breite;
        public double Höhe;

        public double BerrechneVolumen()
        {
            return Länge * Breite * Höhe;
        }
    }

    public interface Versandfähig
    {
        public void GenriereVersandLabel();
        public double VersandGewicht{get;}
    }

    public abstract class Produkt
    {
        public string StockKeepingUnit {get;set;}
        public string Name {get;set;}
        public decimal BasisPreis {get;set;}
        protected Produkt(string name, string sku, decimal basisPreis)
        {
            Name = name;
            StockKeepingUnit = sku;
            BasisPreis = basisPreis;
        }

        public abstract decimal BerechneEndpreis();
        public virtual void PrintProduktDetails()
        {
            Console.WriteLine($"Produkt: {Name} (SKU: {StockKeepingUnit})");
        }
    }
    public class PhysischesPrdoukt : Produkt,Versandfähig
    {
        
        public PaketMaße Maße {get;set;}
        public double Versandgewicht {get;set;}

        public PhysischesPrdoukt(string sku,string name,decimal peis, double gewicht, PaketMaße maße)
        {
            Name = name;
            StockKeepingUnit = sku;
            BasisPreis = peis;
            Versandgewicht = gewicht;
            Maße = maße;
        }

        public override decimal BerechneEndpreis() => BasisPreis * 1.19m; // Beispiel Mehrwertsteuer
         public void GernerierVersandLabel();
    }

    public class DigitalesProdukt : Produkt 
    {
        public string DownloadLink {get;set;}
        public override decimal BerechneEndpreis() => BasisPreis;
        public DigitalesProdukt(string sku, string name, decimal preis, string link)
        {
            Name = name;
            StockKeepingUnit = sku;
            BasisPreis = preis;
            DownloadLink = link;
        }
        public override void PrintProduktDetails()
        {
            base.PrintProduktDetails();
            Console.WriteLine($" Download: {DownloadLink}");
        }
    }

    public  class Programm
    {
        public static void Maiin(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("----------------Logistik System--------------");
            List<Produkt> produkte = new List<Produkt>
            {
                new PhysischesPrdoukt("SKU123","Laptop",999.99m,2.5,new PaketMaße{Länge=30,Breite=20,Höhe=5}),
                new DigitalesProdukt("SKU456","E-Book",19.99m,"https://example.com/ebook-download")
                
            };
            foreach (var artikel in lager)
            {       //is prüft ob artikel vom typ Versandfähig ist, wenn ja wird es in versandObjekt gecastet
                artikel.PrintProduktDetails();
                if(artikel is Versandfähig versdObjekt)
                {
                    versandObjekt.GernerierVersandLabel();
                }
                // as versucht artikel in PhysischesProdukt zu casten, wenn es nicht geht wird physisch null
                PhysischesPrdoukt physisch = artikel as PhysischesPrdoukt;
                if(physisch != null)
                {
                    Console.WriteLine($"Volumen: {physisch.Maße.BerrechneVolumen()} cm³");
                }
                Console.WriteLine(new string('-',40));
            }
            Console.WriteLine("Logistik System abgeschlossen.");
            Console.ReadKey();
        }
    }
} 