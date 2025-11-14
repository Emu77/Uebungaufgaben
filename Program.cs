// ==============================================
// C# Lösungen zu "50 C# Übungsaufgaben für absolute Anfänger"
// - Menü: Aufgabennummer wählen
// - Zeigt Level, Titel, Beschreibung
// - Zeigt den Lösungscode als Text
// - Führt die Lösung aus
// ==============================================
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Loesungen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("C# Lösungen – 50 Anfänger-Aufgaben");
            Console.WriteLine("Gib eine Aufgabennummer (1..50) ein oder 0 zum Beenden.");

            while (true)
            {
                Console.Write("\nAufgabe #: ");
                if (!int.TryParse(Console.ReadLine(), out int n) || n < 0 || n > 50)
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte 0 bis 50 eingeben.");
                    continue;
                }
                if (n == 0)
                    break;

                try
                {
                    ShowTaskInfo(n);

                    Console.WriteLine("Lösungscode:");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(GetSolutionCode(n));
                    Console.WriteLine("--------------------------------\n");

                    RunTask(n);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler bei der Ausführung: {ex.Message}");
                }
            }
        }

        // ----------------------------------------------------
        // Hilfsfunktionen
        // ----------------------------------------------------
        static CultureInfo DE = new CultureInfo("de-DE");

        static double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var d)) return d;
            if (double.TryParse(s, NumberStyles.Float, DE, out d)) return d;
            Console.WriteLine("(Ungültige Zahl → 0 angenommen)");
            return 0.0;
        }

        static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.TryParse(Console.ReadLine(), out var i) ? i : 0;
        }

        // ----------------------------------------------------
        // Aufgaben-Infos
        // ----------------------------------------------------
        static void ShowTaskInfo(int n)
        {
            int level = (n - 1) / 10 + 1;
            string thema = level switch
            {
                1 => "Grundlagen / Ausgabe",
                2 => "Variablen & Datentypen",
                3 => "Benutzereingaben",
                4 => "Bedingungen",
                5 => "Schleifen",
                _ => "Unbekannt"
            };

            string titel = "";
            string beschreibung = "";

            switch (n)
            {
                // Level 1
                case 1: titel = "Hallo Welt"; beschreibung = "Schreibe ein Programm, das \"Hallo Welt!\" auf der Konsole ausgibt."; break;
                case 2: titel = "Persönliche Begrüßung"; beschreibung = "Erstelle ein Programm, das deinen Namen ausgibt."; break;
                case 3: titel = "Mehrere Zeilen"; beschreibung = "Gib drei verschiedene Sätze in drei verschiedenen Zeilen aus."; break;
                case 4: titel = "Zahlen ausgeben"; beschreibung = "Gib die Zahlen von 1 bis 5 aus (jede in einer eigenen Zeile)."; break;
                case 5: titel = "Rechnung ausgeben"; beschreibung = "Gib die Rechnung \"5 + 3 = 8\" auf der Konsole aus."; break;
                case 6: titel = "ASCII-Kunst"; beschreibung = "Erstelle ein einfaches Bild mit Zeichen (z.B. ein Smiley)."; break;
                case 7: titel = "Zitat"; beschreibung = "Gib dein Lieblingszitat mit Autor aus."; break;
                case 8: titel = "Formular"; beschreibung = "Gib ein kleines Formular mit Name, Alter, Wohnort aus (feste Werte)."; break;
                case 9: titel = "Leerzeilen"; beschreibung = "Gib Text mit Leerzeilen dazwischen aus, um Abstände zu schaffen."; break;
                case 10: titel = "Kommentare"; beschreibung = "Schreibe ein Programm mit mindestens 3 Kommentaren, die erklären, was der Code macht."; break;

                // Level 2
                case 11: titel = "Integer-Variable"; beschreibung = "Erstelle eine Variable für dein Alter und gib sie aus."; break;
                case 12: titel = "String-Variable"; beschreibung = "Speichere deinen Namen in einer Variable und gib ihn aus."; break;
                case 13: titel = "Mehrere Variablen"; beschreibung = "Erstelle Variablen für Name, Alter und Stadt und gib alle aus."; break;
                case 14: titel = "Rechnen mit Variablen"; beschreibung = "Erstelle zwei Zahlen-Variablen und gib ihre Summe aus."; break;
                case 15: titel = "Variablen ändern"; beschreibung = "Erstelle eine Variable, weise ihr einen Wert zu, ändere den Wert und gib beide Werte aus."; break;
                case 16: titel = "Boolean-Variable"; beschreibung = "Erstelle eine bool-Variable (z.B. \"istSchüler\") und gib sie aus."; break;
                case 17: titel = "Double-Variable"; beschreibung = "Erstelle eine Variable für eine Kommazahl (z.B. Temperatur) und gib sie aus."; break;
                case 18: titel = "Konstante"; beschreibung = "Erstelle eine Konstante für Pi (3.14159) und verwende sie in einer Berechnung."; break;
                case 19: titel = "String-Verkettung"; beschreibung = "Kombiniere mehrere Strings zu einem Satz."; break;
                case 20: titel = "Grundrechenarten"; beschreibung = "Führe Addition, Subtraktion, Multiplikation und Division mit Variablen aus."; break;

                // Level 3
                case 21: titel = "Name eingeben"; beschreibung = "Frage den Benutzer nach seinem Namen und begrüße ihn."; break;
                case 22: titel = "Alter eingeben"; beschreibung = "Frage nach dem Alter und gib aus: \"Du bist X Jahre alt.\""; break;
                case 23: titel = "Zwei Zahlen addieren"; beschreibung = "Lass den Benutzer zwei Zahlen eingeben und gib die Summe aus."; break;
                case 24: titel = "Lieblingsfarbe"; beschreibung = "Frage nach der Lieblingsfarbe und gib einen Satz damit aus."; break;
                case 25: titel = "Geburtsjahrberechnung"; beschreibung = "Frage nach dem Alter und berechne das Geburtsjahr (ungefähr)."; break;
                case 26: titel = "Rechteck-Fläche"; beschreibung = "Lass Länge und Breite eingeben und berechne die Fläche."; break;
                case 27: titel = "Temperaturumrechnung"; beschreibung = "Rechne Celsius in Fahrenheit um (Formel: F = C * 9/5 + 32)."; break;
                case 28: titel = "Begrüßung personalisieren"; beschreibung = "Frage nach Vor- und Nachnamen und gib eine vollständige Begrüßung aus."; break;
                case 29: titel = "Einfacher Taschenrechner"; beschreibung = "Lass zwei Zahlen eingeben und zeige alle Grundrechenarten."; break;
                case 30: titel = "Kreis-Umfang"; beschreibung = "Berechne den Umfang eines Kreises aus dem eingegebenen Radius."; break;

                // Level 4
                case 31: titel = "Volljährigkeitsprüfung"; beschreibung = "Prüfe, ob jemand 18 oder älter ist."; break;
                case 32: titel = "Gerade oder ungerade"; beschreibung = "Prüfe, ob eine eingegebene Zahl gerade oder ungerade ist."; break;
                case 33: titel = "Positiv oder negativ"; beschreibung = "Prüfe, ob eine Zahl positiv, negativ oder null ist."; break;
                case 34: titel = "Maximum zweier Zahlen"; beschreibung = "Finde die größere von zwei eingegebenen Zahlen."; break;
                case 35: titel = "Notenberechnung"; beschreibung = "Gib bei Punktzahl (0-100) die entsprechende Note aus (z.B. 1–6)."; break;
                case 36: titel = "Schaltjahr"; beschreibung = "Prüfe, ob ein eingegebenes Jahr ein Schaltjahr ist."; break;
                case 37: titel = "Login-System"; beschreibung = "Prüfe Benutzername und Passwort (fest im Code) und gib \"Zugriff\" oder \"Verweigert\" aus."; break;
                case 38: titel = "Rabattrechner"; beschreibung = "Gib 10% Rabatt ab einem Einkaufswert von 50€."; break;
                case 39: titel = "BMI-Bewertung"; beschreibung = "Berechne den BMI und bewerte ihn (Untergewicht, Normalgewicht, Übergewicht)."; break;
                case 40: titel = "Temperatur-Warnung"; beschreibung = "Gib eine Warnung aus, wenn die Temperatur über 30°C oder unter 0°C ist."; break;

                // Level 5
                case 41: titel = "Zahlen 1–10"; beschreibung = "Gib die Zahlen von 1 bis 10 mit einer for-Schleife aus."; break;
                case 42: titel = "Countdown"; beschreibung = "Erstelle einen Countdown von 10 bis 0."; break;
                case 43: titel = "Gerade Zahlen"; beschreibung = "Gib alle geraden Zahlen von 2 bis 20 aus."; break;
                case 44: titel = "Einmaleins"; beschreibung = "Gib das kleine Einmaleins einer eingegebenen Zahl aus (1 bis 10)."; break;
                case 45: titel = "Summe berechnen"; beschreibung = "Berechne die Summe aller Zahlen von 1 bis 100."; break;
                case 46: titel = "Fakultät"; beschreibung = "Berechne die Fakultät einer eingegebenen Zahl (z.B. 5! = 120)."; break;
                case 47: titel = "Zahlenraten"; beschreibung = "Erstelle ein Zahlenratespiel mit fester Geheimzahl und mehreren Versuchen."; break;
                case 48: titel = "Durchschnitt"; beschreibung = "Lass 5 Zahlen eingeben und berechne den Durchschnitt."; break;
                case 49: titel = "Quadratzahlen"; beschreibung = "Gib die Quadratzahlen von 1 bis 10 aus (1, 4, 9, 16, ...)."; break;
                case 50: titel = "Passwort-Wiederholung"; beschreibung = "Frage so lange nach einem Passwort, bis es korrekt ist (while-Schleife)."; break;
            }

            Console.WriteLine("\n================================");
            Console.WriteLine($"Aufgabe {n} – Level {level} ({thema})");
            Console.WriteLine($"Titel: {titel}");
            Console.WriteLine("Beschreibung:");
            Console.WriteLine(beschreibung);
            Console.WriteLine("================================\n");
        }

        // ----------------------------------------------------
        // Lösungscode als Text
        // ----------------------------------------------------
        static string GetSolutionCode(int n)
        {
            if (SolutionCodes.TryGetValue(n, out var code))
                return code;
            return "// Kein Lösungscode hinterlegt.";
        }

        static readonly Dictionary<int, string> SolutionCodes = new Dictionary<int, string>
        {
            // Level 1
            { 1,  @"static void A1() {
    Console.WriteLine(""Hallo Welt!"");
}" },
            { 2,  @"static void A2() {
    Console.WriteLine(""Ich heiße Alex."");
}" },
            { 3,  @"static void A3() {
    Console.WriteLine(""Zeile 1"");
    Console.WriteLine(""Zeile 2"");
    Console.WriteLine(""Zeile 3"");
}" },
            { 4,  @"static void A4() {
    for (int i = 1; i <= 5; i++)
        Console.WriteLine(i);
}" },
            { 5,  @"static void A5() {
    Console.WriteLine(""5 + 3 = 8"");
}" },
            { 6,  @"static void A6() {
    Console.WriteLine(""  _____  "");
    Console.WriteLine("" /     \\"");
    Console.WriteLine(""|  o o  |"");
    Console.WriteLine(""|   ^   |"");
    Console.WriteLine(""| \\\\_/  |"");
    Console.WriteLine("" \\\\_____/"");
}" },
            { 7,  @"static void A7() {
    Console.WriteLine(""\""""Stay hungry, stay foolish.\"""" – Steve Jobs"");
}" },
            { 8,  @"static void A8() {
    Console.WriteLine(""Name: Alex Muster"");
    Console.WriteLine(""Alter: 25"");
    Console.WriteLine(""Wohnort: Berlin"");
}" },
            { 9,  @"static void A9() {
    Console.WriteLine(""Oben"");
    Console.WriteLine();
    Console.WriteLine(""Mitte"");
    Console.WriteLine();
    Console.WriteLine(""Unten"");
}" },
            { 10, @"static void A10() {
    // Kommentar 1: Demonstriert Kommentare.
    // Kommentar 2: Kommentare werden ignoriert.
    // Kommentar 3: Benutze sie für Erklärungen.
    Console.WriteLine(""Kommentare im Code – siehe Quelltext."");
}" },

            // Level 2
            { 11, @"static void A11() {
    int alter = 25;
    Console.WriteLine(alter);
}" },
            { 12, @"static void A12() {
    string name = ""Alex"";
    Console.WriteLine(name);
}" },
            { 13, @"static void A13() {
    string name = ""Alex"";
    int alter = 25;
    string stadt = ""Berlin"";
    Console.WriteLine($""{name}, {alter}, {stadt}"");
}" },
            { 14, @"static void A14() {
    int a = 7, b = 5;
    Console.WriteLine(a + b);
}" },
            { 15, @"static void A15() {
    int x = 10;
    Console.WriteLine(x);
    x = 20;
    Console.WriteLine(x);
}" },
            { 16, @"static void A16() {
    bool istSchueler = false;
    Console.WriteLine(istSchueler);
}" },
            { 17, @"static void A17() {
    double t = 21.5;
    Console.WriteLine($""{t} °C"");
}" },
            { 18, @"static void A18() {
    const double PI = 3.14159;
    double r = 2;
    Console.WriteLine(PI * r * r);
}" },
            { 19, @"static void A19() {
    string s = ""C# "" + ""macht "" + ""Spaß!"";
    Console.WriteLine(s);
}" },
            { 20, @"static void A20() {
    int x = 12, y = 4;
    Console.WriteLine($""Add:{x+y}, Sub:{x-y}, Mul:{x*y}, Div:{x/y}"");
}" },

            // Level 3
            { 21, @"static void A21() {
    Console.Write(""Name: "");
    var n = Console.ReadLine();
    Console.WriteLine($""Hallo, {n}!"");
}" },
            { 22, @"static void A22() {
    Console.Write(""Alter: "");
    if (int.TryParse(Console.ReadLine(), out int a))
        Console.WriteLine($""Du bist {a} Jahre alt."");
    else
        Console.WriteLine(""Ungültige Eingabe."");
}" },
            { 23, @"static void A23() {
    double a = ReadDouble(""Zahl 1: "");
    double b = ReadDouble(""Zahl 2: "");
    Console.WriteLine($""Summe: {a + b}"");
}" },
            { 24, @"static void A24() {
    Console.Write(""Lieblingsfarbe: "");
    var f = Console.ReadLine();
    Console.WriteLine($""Schöne Wahl: {f}!"");
}" },
            { 25, @"static void A25() {
    int alter = ReadInt(""Alter: "");
    int jahr = DateTime.Now.Year - Math.Max(0, alter);
    Console.WriteLine($""Geburtsjahr (ungefähr): {jahr}"");
}" },
            { 26, @"static void A26() {
    double l = ReadDouble(""Länge: "");
    double b = ReadDouble(""Breite: "");
    Console.WriteLine($""Fläche: {l * b}"");
}" },
            { 27, @"static void A27() {
    double c = ReadDouble(""°C: "");
    double f = c * 9 / 5 + 32;
    Console.WriteLine($""{c} °C = {f} °F"");
}" },
            { 28, @"static void A28() {
    Console.Write(""Vorname: "");
    var v = Console.ReadLine();
    Console.Write(""Nachname: "");
    var n = Console.ReadLine();
    Console.WriteLine($""Willkommen, {v} {n}!"");
}" },
            { 29, @"static void A29() {
    double A = ReadDouble(""A: "");
    double B = ReadDouble(""B: "");
    Console.WriteLine($""Add:{A+B}, Sub:{A-B}, Mul:{A*B}, Div:{(B!=0? (A/B).ToString() : ""nicht definiert"")}"");
}" },
            { 30, @"static void A30() {
    const double PI = 3.14159;
    double r = ReadDouble(""Radius: "");
    Console.WriteLine($""Umfang: {2 * PI * r}"");
}" },

            // Level 4
            { 31, @"static void A31() {
    int alter = ReadInt(""Alter: "");
    Console.WriteLine(alter >= 18 ? ""Volljährig"" : ""Nicht volljährig"");
}" },
            { 32, @"static void A32() {
    int z = ReadInt(""Zahl: "");
    Console.WriteLine(z % 2 == 0 ? ""Gerade"" : ""Ungerade"");
}" },
            { 33, @"static void A33() {
    int z = ReadInt(""Zahl: "");
    Console.WriteLine(z > 0 ? ""Positiv"" : (z < 0 ? ""Negativ"" : ""Null""));
}" },
            { 34, @"static void A34() {
    int a = ReadInt(""A: "");
    int b = ReadInt(""B: "");
    Console.WriteLine(a > b ? a : b);
}" },
            { 35, @"static void A35() {
    int p = ReadInt(""Punkte (0-100): "");
    string note = p >= 92 ? ""1"" :
                  p >= 81 ? ""2"" :
                  p >= 67 ? ""3"" :
                  p >= 50 ? ""4"" :
                  p >= 30 ? ""5"" : ""6"";
    Console.WriteLine($""Note: {note}"");
}" },
            { 36, @"static void A36() {
    int j = ReadInt(""Jahr: "");
    bool schalt = (j % 400 == 0) || (j % 4 == 0 && j % 100 != 0);
    Console.WriteLine(schalt ? ""Schaltjahr"" : ""Kein Schaltjahr"");
}" },
            { 37, @"static void A37() {
    const string USER = ""admin"", PASS = ""1234"";
    Console.Write(""Benutzername: "");
    var u = Console.ReadLine();
    Console.Write(""Passwort: "");
    var p = Console.ReadLine();
    Console.WriteLine(u == USER && p == PASS ? ""Zugriff"" : ""Verweigert"");
}" },
            { 38, @"static void A38() {
    double betrag = ReadDouble(""Einkauf (€): "");
    double zahlen = betrag >= 50 ? betrag * 0.9 : betrag;
    Console.WriteLine($""Zu zahlen: {zahlen:F2} €"");
}" },
            { 39, @"static void A39() {
    double kg = ReadDouble(""Gewicht (kg): "");
    double m = ReadDouble(""Größe (m): "");
    double bmi = m > 0 ? kg / (m * m) : 0;
    string kat = bmi < 18.5 ? ""Untergewicht"" :
                 bmi < 25   ? ""Normalgewicht"" :
                 bmi < 30   ? ""Übergewicht"" :
                              ""Adipositas"";
    Console.WriteLine($""BMI: {bmi:F1} – {kat}"");
}" },
            { 40, @"static void A40() {
    double t = ReadDouble(""Temperatur (°C): "");
    if (t > 30) Console.WriteLine(""Warnung: Sehr heiß!"");
    else if (t < 0) Console.WriteLine(""Warnung: Frost!"");
    else Console.WriteLine(""Normalbereich."");
}" },

            // Level 5
            { 41, @"static void A41() {
    for (int i = 1; i <= 10; i++)
        Console.Write(i + (i < 10 ? "", "" : ""\n""));
}" },
            { 42, @"static void A42() {
    for (int i = 10; i >= 0; i--)
        Console.Write(i + (i > 0 ? "", "" : ""\n""));
}" },
            { 43, @"static void A43() {
    for (int i = 2; i <= 20; i += 2)
        Console.Write(i + (i < 20 ? "", "" : ""\n""));
}" },
            { 44, @"static void A44() {
    int n = ReadInt(""Zahl: "");
    for (int i = 1; i <= 10; i++)
        Console.WriteLine($""{n} x {i} = {n*i}"");
}" },
            { 45, @"static void A45() {
    int sum = 0;
    for (int i = 1; i <= 100; i++)
        sum += i;
    Console.WriteLine(sum);
}" },
            { 46, @"static void A46() {
    int f = ReadInt(""n: "");
    long fak = 1;
    for (int i = 2; i <= f; i++)
        fak *= i;
    Console.WriteLine(fak);
}" },
            { 47, @"static void A47() {
    const int geheim = 17;
    Console.WriteLine(""Ratespiel (1..50), 5 Versuche"");
    for (int v = 1; v <= 5; v++)
    {
        int t = ReadInt($""Versuch {v}: "");
        if (t == geheim)
        {
            Console.WriteLine(""Richtig!"");
            return;
        }
        Console.WriteLine(t < geheim ? ""Zu klein."" : ""Zu groß."");
    }
    Console.WriteLine($""Leider nein. Die Zahl war {geheim}."");
}" },
            { 48, @"static void A48() {
    double sum = 0;
    for (int i = 1; i <= 5; i++)
        sum += ReadDouble($""Zahl {i}: "");
    Console.WriteLine($""Durchschnitt: {sum/5}"");
}" },
            { 49, @"static void A49() {
    for (int i = 1; i <= 10; i++)
        Console.Write((i*i) + (i < 10 ? "", "" : ""\n""));
}" },
            { 50, @"static void A50() {
    const string pw = ""geheim"";
    while (true)
    {
        Console.Write(""Passwort: "");
        var e = Console.ReadLine();
        if (e == pw)
        {
            Console.WriteLine(""Korrekt!"");
            break;
        }
        Console.WriteLine(""Falsch, erneut versuchen."");
    }
}" },
        };

        // ----------------------------------------------------
        // Dispatcher – echte Ausführung der Aufgaben
        // ----------------------------------------------------
        static void RunTask(int n)
        {
            switch (n)
            {
                // Level 1
                case 1: A1(); break;
                case 2: A2(); break;
                case 3: A3(); break;
                case 4: A4(); break;
                case 5: A5(); break;
                case 6: A6(); break;
                case 7: A7(); break;
                case 8: A8(); break;
                case 9: A9(); break;
                case 10: A10(); break;

                // Level 2
                case 11: A11(); break;
                case 12: A12(); break;
                case 13: A13(); break;
                case 14: A14(); break;
                case 15: A15(); break;
                case 16: A16(); break;
                case 17: A17(); break;
                case 18: A18(); break;
                case 19: A19(); break;
                case 20: A20(); break;

                // Level 3
                case 21: A21(); break;
                case 22: A22(); break;
                case 23: A23(); break;
                case 24: A24(); break;
                case 25: A25(); break;
                case 26: A26(); break;
                case 27: A27(); break;
                case 28: A28(); break;
                case 29: A29(); break;
                case 30: A30(); break;

                // Level 4
                case 31: A31(); break;
                case 32: A32(); break;
                case 33: A33(); break;
                case 34: A34(); break;
                case 35: A35(); break;
                case 36: A36(); break;
                case 37: A37(); break;
                case 38: A38(); break;
                case 39: A39(); break;
                case 40: A40(); break;

                // Level 5
                case 41: A41(); break;
                case 42: A42(); break;
                case 43: A43(); break;
                case 44: A44(); break;
                case 45: A45(); break;
                case 46: A46(); break;
                case 47: A47(); break;
                case 48: A48(); break;
                case 49: A49(); break;
                case 50: A50(); break;

                default:
                    Console.WriteLine("Aufgabe nicht implementiert.");
                    break;
            }
        }

        // ----------------------------------------------------
        // Echte Implementierungen A1..A50
        // ----------------------------------------------------
        // Level 1
        static void A1() { Console.WriteLine("Hallo Welt!"); }
        static void A2() { Console.WriteLine("Ich heiße Alex."); }
        static void A3() { Console.WriteLine("Zeile 1"); Console.WriteLine("Zeile 2"); Console.WriteLine("Zeile 3"); }
        static void A4() { for (int i = 1; i <= 5; i++) Console.WriteLine(i); }
        static void A5() { Console.WriteLine("5 + 3 = 8"); }
        static void A6()
        {
            Console.WriteLine("  _____  ");
            Console.WriteLine(" /     \\");
            Console.WriteLine("|  o o  |");
            Console.WriteLine("|   ^   |");
            Console.WriteLine("| \\_/  |".Replace("\\", "\\\\"));
            Console.WriteLine(" \\\\_____");
        }
        static void A7() { Console.WriteLine("\"Stay hungry, stay foolish.\" – Steve Jobs"); }
        static void A8() { Console.WriteLine("Name: Alex Muster"); Console.WriteLine("Alter: 25"); Console.WriteLine("Wohnort: Berlin"); }
        static void A9() { Console.WriteLine("Oben"); Console.WriteLine(); Console.WriteLine("Mitte"); Console.WriteLine(); Console.WriteLine("Unten"); }
        static void A10() { Console.WriteLine("Kommentare im Code – siehe Quelltext."); }

        // Level 2
        static void A11() { int alter = 25; Console.WriteLine(alter); }
        static void A12() { string name = "Alex"; Console.WriteLine(name); }
        static void A13() { string name = "Alex"; int alter = 25; string stadt = "Berlin"; Console.WriteLine($"{name}, {alter}, {stadt}"); }
        static void A14() { int a = 7, b = 5; Console.WriteLine(a + b); }
        static void A15() { int x = 10; Console.WriteLine(x); x = 20; Console.WriteLine(x); }
        static void A16() { bool istSchueler = false; Console.WriteLine(istSchueler); }
        static void A17() { double t = 21.5; Console.WriteLine($"{t} °C"); }
        static void A18() { const double PI = 3.14159; double r = 2; Console.WriteLine(PI * r * r); }
        static void A19() { string s = "C# " + "macht " + "Spaß!"; Console.WriteLine(s); }
        static void A20() { int x = 12, y = 4; Console.WriteLine($"Add:{x + y}, Sub:{x - y}, Mul:{x * y}, Div:{x / y}"); }

        // Level 3
        static void A21() { Console.Write("Name: "); var n = Console.ReadLine(); Console.WriteLine($"Hallo, {n}!"); }
        static void A22() { Console.Write("Alter: "); if (int.TryParse(Console.ReadLine(), out int a)) Console.WriteLine($"Du bist {a} Jahre alt."); else Console.WriteLine("Ungültige Eingabe."); }
        static void A23() { double a = ReadDouble("Zahl 1: "); double b = ReadDouble("Zahl 2: "); Console.WriteLine($"Summe: {a + b}"); }
        static void A24() { Console.Write("Lieblingsfarbe: "); var f = Console.ReadLine(); Console.WriteLine($"Schöne Wahl: {f}!"); }
        static void A25() { int alter = ReadInt("Alter: "); int jahr = DateTime.Now.Year - Math.Max(0, alter); Console.WriteLine($"Geburtsjahr (ungefähr): {jahr}"); }
        static void A26() { double l = ReadDouble("Länge: "); double b = ReadDouble("Breite: "); Console.WriteLine($"Fläche: {l * b}"); }
        static void A27() { double c = ReadDouble("°C: "); double f = c * 9 / 5 + 32; Console.WriteLine($"{c} °C = {f} °F"); }
        static void A28() { Console.Write("Vorname: "); var v = Console.ReadLine(); Console.Write("Nachname: "); var n = Console.ReadLine(); Console.WriteLine($"Willkommen, {v} {n}!"); }
        static void A29() { double A = ReadDouble("A: "); double B = ReadDouble("B: "); Console.WriteLine($"Add:{A + B}, Sub:{A - B}, Mul:{A * B}, Div:{(B != 0 ? (A / B).ToString() : "nicht definiert")}"); }
        static void A30() { const double PI = 3.14159; double r = ReadDouble("Radius: "); Console.WriteLine($"Umfang: {2 * PI * r}"); }

        // Level 4
        static void A31() { int alter = ReadInt("Alter: "); Console.WriteLine(alter >= 18 ? "Volljährig" : "Nicht volljährig"); }
        static void A32() { int z = ReadInt("Zahl: "); Console.WriteLine(z % 2 == 0 ? "Gerade" : "Ungerade"); }
        static void A33() { int z = ReadInt("Zahl: "); Console.WriteLine(z > 0 ? "Positiv" : (z < 0 ? "Negativ" : "Null")); }
        static void A34() { int a = ReadInt("A: "); int b = ReadInt("B: "); Console.WriteLine(a > b ? a : b); }
        static void A35() { int p = ReadInt("Punkte (0-100): "); string note = p >= 92 ? "1" : p >= 81 ? "2" : p >= 67 ? "3" : p >= 50 ? "4" : p >= 30 ? "5" : "6"; Console.WriteLine($"Note: {note}"); }
        static void A36() { int j = ReadInt("Jahr: "); bool schalt = (j % 400 == 0) || (j % 4 == 0 && j % 100 != 0); Console.WriteLine(schalt ? "Schaltjahr" : "Kein Schaltjahr"); }
        static void A37() { const string USER = "admin", PASS = "1234"; Console.Write("Benutzername: "); var u = Console.ReadLine(); Console.Write("Passwort: "); var p = Console.ReadLine(); Console.WriteLine(u == USER && p == PASS ? "Zugriff" : "Verweigert"); }
        static void A38() { double betrag = ReadDouble("Einkauf (€): "); double zahlen = betrag >= 50 ? betrag * 0.9 : betrag; Console.WriteLine($"Zu zahlen: {zahlen:F2} €"); }
        static void A39() { double kg = ReadDouble("Gewicht (kg): "); double m = ReadDouble("Größe (m): "); double bmi = m > 0 ? kg / (m * m) : 0; string kat = bmi < 18.5 ? "Untergewicht" : bmi < 25 ? "Normalgewicht" : bmi < 30 ? "Übergewicht" : "Adipositas"; Console.WriteLine($"BMI: {bmi:F1} – {kat}"); }
        static void A40() { double t = ReadDouble("Temperatur (°C): "); if (t > 30) Console.WriteLine("Warnung: Sehr heiß!"); else if (t < 0) Console.WriteLine("Warnung: Frost!"); else Console.WriteLine("Normalbereich."); }

        // Level 5
        static void A41() { for (int i = 1; i <= 10; i++) Console.Write(i + (i < 10 ? ", " : "\n")); }
        static void A42() { for (int i = 10; i >= 0; i--) Console.Write(i + (i > 0 ? ", " : "\n")); }
        static void A43() { for (int i = 2; i <= 20; i += 2) Console.Write(i + (i < 20 ? ", " : "\n")); }
        static void A44() { int n = ReadInt("Zahl: "); for (int i = 1; i <= 10; i++) Console.WriteLine($"{n} x {i} = {n * i}"); }
        static void A45() { int sum = 0; for (int i = 1; i <= 100; i++) sum += i; Console.WriteLine(sum); }
        static void A46() { int f = ReadInt("n: "); long fak = 1; for (int i = 2; i <= f; i++) fak *= i; Console.WriteLine(fak); }
        static void A47()
        {
            const int geheim = 17;
            Console.WriteLine("Ratespiel (1..50), 5 Versuche");
            for (int v = 1; v <= 5; v++)
            {
                int t = ReadInt($"Versuch {v}: ");
                if (t == geheim) { Console.WriteLine("Richtig!"); return; }
                Console.WriteLine(t < geheim ? "Zu klein." : "Zu groß.");
            }
            Console.WriteLine($"Leider nein. Die Zahl war {geheim}.");
        }
        static void A48() { double sum = 0; for (int i = 1; i <= 5; i++) sum += ReadDouble($"Zahl {i}: "); Console.WriteLine($"Durchschnitt: {sum / 5}"); }
        static void A49() { for (int i = 1; i <= 10; i++) Console.Write((i * i) + (i < 10 ? ", " : "\n")); }
        static void A50()
        {
            const string pw = "geheim";
            while (true)
            {
                Console.Write("Passwort: "); var e = Console.ReadLine();
                if (e == pw) { Console.WriteLine("Korrekt!"); break; }
                Console.WriteLine("Falsch, erneut versuchen.");
            }
        }
    }
}
