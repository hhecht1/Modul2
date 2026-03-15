using System;

namespace FinanzMonitor
{
    public enum TransAktionsTyp
    {
        Einzahlung,Auszahlung,Umbuchung
    }
    public struct WährungsBetrag
    {
        public decimal Betrag;
        public string Währung;
        public WährungsBetrag(decimal b, string w)
        {
            Betrag = b;
            Währung = w;
        }
        public override string ToString() => $"{Betrag} {Währung}";
    }

    public interface Auditierbar
    {
        DateTime Zeitstempel { get; }
        string CreatePrüfsumme();
    }

    public abstract record Transaktion(string ID,TransAktionsTyp Typ): Auditierbar
    {
        public DateTime Zeitsempel {get;} = DateTime.Now;

        public DateTime Zeitstempel => throw new NotImplementedException();

        public abstract void InProgress();
        public virtual string GetConfirmationText() => $"Transaktion {ID} vom Typ {Typ} ist in Bearbeitung.";
        public string CreatePrüfsumme() => $"{ID}-{Typ}-{Zeitsempel:yyyyMMddHHmmss}";
    }

    public record Überweisung(string ID,string IBAN,WährungsBetrag Betrag):
    Transaktion(ID,TransAktionsTyp.Umbuchung)
    {
        public override void InProgress()
        {
            Console.WriteLine($"Überweisung {ID} von {Betrag} an IBAN {IBAN} wird bearbeitet.");
        }
        public override string GetConfirmationText() => $"Überweisung {ID} von {Betrag} an IBAN {IBAN} ist in Bearbeitung.";
    }

    public record BarTransaktion(string ID,string Filialcode,decimal Betrag):
    Transaktion(ID,TransAktionsTyp.Einzahlung)
    {
        public override void InProgress() => Console.WriteLine($"Bartransaktion {ID} in Filiale {Filialcode} über {Betrag} wird bearbeitet.");
    }

    class Programm
    {
        private static object audit;
        private static Auditierbar tx;

        public static void Main (string[] args)
        {
            Console.WriteLine("-----FinazMonitor-----");
            var u1 = new Überweisung("T001","DE12345678901234567890",new WährungsBetrag(1000,"EUR"));
            var u2 = new Überweisung("T002","F001",new WährungsBetrag(500,"EUR"));
            Console.WriteLine($"Vergleiche u1 == u2: {u1 == u2}");
            Console.WriteLine($" -> Warum true? Record-Typen vergleichen standardmäßig alle Felder auf Gleichheit, nicht die Referenz.");

            List<Transaktion> Kassenbuch = new List<Transaktion>();
            {
                
                new BarTransaktion("T003","F002",200);
                new Überweisung("T004","DE09876543210987654321",new WährungsBetrag(750,"EUR"));
            }
            foreach(var tx in Kassenbuch)
            {
                Console.WriteLine(tx.GetConfirmationText());
                tx.InProgress();
            }
            if (tx is Auditierbar auditierbar)
            {
                Console.WriteLine($"Auditierbar: {auditierbar.CreatePrüfsumme()}");
            }

            var bar = tx as BarTransaktion;
            if(bar != null)
            {
                Console.WriteLine($"Bartransaktion {bar.ID} in Filiale {bar.Filialcode} über {bar.Betrag} erkannt.");
            }
            Console.WriteLine(new string ('-',30));

        }
    }
}