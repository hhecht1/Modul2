using System;

static void BerechneRechteck(double länge, double breite)
{
    double fläche = länge *breite;
    Console.WriteLine($"Die Fläche des Rechtecks beträgt: {fläche}");
}
BerechneRechteck(5, 3);



static void Begrüßung(string name, string begrüßung = "Hallo")
{
    Console.WriteLine($"{begrüßung}, {name}!");
}
Begrüßung("Alice");
Begrüßung("Bob","Heloooooo");


static void PrintProfil(string vorname, string nachname, int alter =0, string stadt ="Unbekannt")
{
    Console.WriteLine($"{vorname} {nachname}, Alter : {alter}, Jahre, aus {stadt}");
}

PrintProfil("Alice","Müller", 30, "Berlin");
PrintProfil("Bob","Schmidt", 25);

static int SummiereZahlen(params int[] zahlen)
{
    int summe =0;
    foreach(int z in zahlen) summe += z;
    return summe;
}
int s1 = SummiereZahlen(1,2,3);
int s2 = SummiereZahlen(4,5);
Console.WriteLine($"Summe 1: {s1}");
Console.WriteLine($"Summe 2: {s2}");

static void LogNachrichten(string kategorie, string präfix ="LOG", params string[] nachtichten)
{
    Console.WriteLine($"[{präfix}] [{kategorie}]");
    Console.WriteLine(string.Join(", ", nachtichten));
}
LogNachrichten("System", "INFO", "System gestartet", "Keine Fehler erkannt");
LogNachrichten("Anwendung", "WARN", "Hohe Speicherauslastung", "Überprüfen Sie die Prozesse");


