using System.Text;

namespace CSharpRepetition;

// ┌─────────────────────────────────────────────────────────────────────────┐
// │  Programmet kör alla metoder i Easy, Medium och Hard via MarcusPlayground│
// │  och visar hur stor andel av dem som fungerar som de ska.               │
// │                                                                         │
// │  Gott råd: Undvik StackOverflow och AI — det löser problemet            │
// │  men du lär dig ingenting. Tänk själv, googla dokumentation.            │
// └─────────────────────────────────────────────────────────────────────────┘

internal static class Program
{
    // Layout-konstanter
    private const int W = 100;  // total fönsterbredd
    private const int H = 26;   // total fönsterhöjd
    private const int C = 32;   // inre kolumnbredd

    // Kolumnernas vänsterkant (inuti ram)
    private const int X1 = 1;
    private const int X2 = X1 + C + 1;  // 34
    private const int X3 = X2 + C + 1;  // 67

    // Rader
    private const int TitelRad    = 1;
    private const int KolRubrikRad = 3;
    private const int ProcentRad  = 4;
    private const int MetodRad    = 6;
    private const int TotalRad    = 22;

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        InitKonsol();
        RitaGränssnitt();

        // Liten dramatisk paus — C64-känsla
        SkrivPå(X1 + 1, MetodRad,     "[ beräknar... ]");
        SkrivPå(X2 + 1, MetodRad,     "[ beräknar... ]");
        SkrivPå(X3 + 1, MetodRad,     "[ beräknar... ]");
        Thread.Sleep(700);

        // Kör alla tester
        double easy   = MarcusPlayground.KörEasy();
        double medium = MarcusPlayground.KörMedium();
        double hard   = MarcusPlayground.KörHard();

        // Rensa "beräknar"
        SkrivPå(X1 + 1, MetodRad, new string(' ', 16));
        SkrivPå(X2 + 1, MetodRad, new string(' ', 16));
        SkrivPå(X3 + 1, MetodRad, new string(' ', 16));

        // Visa resultat per kolumn
        VisaKolumn(X1, MarcusPlayground.EasyResultat);
        VisaKolumn(X2, MarcusPlayground.MediumResultat);
        VisaKolumn(X3, MarcusPlayground.HardResultat);

        // Procent per kolumn
        VisaProcent(X1 + 11, ProcentRad, easy);
        VisaProcent(X2 + 11, ProcentRad, medium);
        VisaProcent(X3 + 11, ProcentRad, hard);

        // Total
        double total = Math.Round((easy + medium + hard) / 3, 1);
        Console.ForegroundColor = total >= 100 ? ConsoleColor.Green : ConsoleColor.Yellow;
        SkrivCentrerad(TotalRad, $"T O T A L T :   {total} %");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(0, H - 1);
        Console.CursorVisible = true;
        Console.ReadLine();
    }

    // -----------------------------------------------------------------------

    private static void InitKonsol()
    {
        try
        {
            if (OperatingSystem.IsWindows())
            {
                Console.WindowHeight = H;
                Console.WindowWidth  = W;
            }
        }
        catch { /* terminalen stöder kanske inte storleksändring */ }

        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.CursorVisible   = false;
        Console.Clear();
    }

    private static void RitaGränssnitt()
    {
        var bred    = new string('═', W - 2);
        var kolBred = new string('═', C);
        var tomRad  = new string(' ', W - 2);
        var kolTom  = new string(' ', C);

        // Topp (full bredd)
        SkrivPå(0, 0, $"╔{bred}╗");

        // Titelrad (full bredd)
        SkrivPå(0, TitelRad, $"║{tomRad}║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        SkrivCentrerad(TitelRad, "★   C # - R E P E T I T I O N   ★");
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Övergång till tre kolumner
        SkrivPå(0, 2, $"╠{kolBred}╦{kolBred}╦{kolBred}╣");

        // Kolumnrubriker
        SkrivPå(0, KolRubrikRad, $"║{kolTom}║{kolTom}║{kolTom}║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        SkrivPå(X1 + 3, KolRubrikRad, "L Ä T T");
        SkrivPå(X2 + 3, KolRubrikRad, "M E D E L");
        SkrivPå(X3 + 3, KolRubrikRad, "S V Å R");
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Procentrad (initialt 0%)
        SkrivPå(0, ProcentRad, $"║{kolTom}║{kolTom}║{kolTom}║");
        Console.ForegroundColor = ConsoleColor.White;
        SkrivPå(X1 + 11, ProcentRad, "0%");
        SkrivPå(X2 + 11, ProcentRad, "0%");
        SkrivPå(X3 + 11, ProcentRad, "0%");
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Separator efter header
        SkrivPå(0, 5, $"╠{kolBred}╬{kolBred}╬{kolBred}╣");

        // Metodrader (tomma)
        for (int y = MetodRad; y < TotalRad - 1; y++)
            SkrivPå(0, y, $"║{kolTom}║{kolTom}║{kolTom}║");

        // Separator före total (full bredd)
        SkrivPå(0, TotalRad - 1, $"╠{bred}╣");

        // Totalrad
        SkrivPå(0, TotalRad, $"║{tomRad}║");

        // Botten
        SkrivPå(0, TotalRad + 1, $"╚{bred}╝");
    }

    private static void VisaKolumn(int x, List<(string namn, bool ok)> resultat)
    {
        int y = MetodRad;
        foreach (var (namn, ok) in resultat)
        {
            Thread.Sleep(80);

            string kortNamn = namn.Length > 22 ? namn[..22] : namn;
            Console.ForegroundColor = ConsoleColor.White;
            SkrivPå(x + 1, y, kortNamn.PadRight(22));

            Console.ForegroundColor = ok ? ConsoleColor.Green : ConsoleColor.Red;
            SkrivPå(x + C - 5, y, ok ? "[✓]" : "[✗]");

            Console.ForegroundColor = ConsoleColor.Cyan;
            y++;
        }
    }

    private static void VisaProcent(int x, int y, double procent)
    {
        Console.ForegroundColor = procent >= 100 ? ConsoleColor.Green :
                                   procent >=  50 ? ConsoleColor.Yellow :
                                                    ConsoleColor.Red;
        SkrivPå(x, y, $"{procent}%    ");
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    private static void SkrivCentrerad(int y, string text)
    {
        SkrivPå((W - text.Length) / 2, y, text);
    }

    private static void SkrivPå(int x, int y, string text)
    {
        try
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
        catch { /* position utanför fönstret */ }
    }
}
