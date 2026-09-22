using Figgle;
using Figgle.Fonts;
using System.Text;

namespace CSharpRepetition;

// ┌──────────────────────────────────────────────────────────────────────────┐
// │ Implementera metoderna i Easy.cs, Medium.cs och Hard.cs.                │
// │ Kör programmet för att se hur långt du kommit.                          │
// │ Gott råd: tänk själv — googla dokumentation, inte svar.                 │
// └──────────────────────────────────────────────────────────────────────────┘

internal static class Program
{
    // === Per projekt — ändra dessa två rader ===
    private const string Tema     = "STRANGAR";           // ASCII, renderas som Figlet
    private const string TemaFull = "Strängar";   // Visas under Figlet
    // ===========================================

    private const int W = 160;   // total fönsterbredd
    private const int H = 32;    // total fönsterhöjd
    private const int C = 52;    // inre kolumnbredd  (W-2-2)/3 = 52

    private const int X1 = 1;           // vänsterkant kolumn 1
    private const int X2 = X1 + C + 1;  // = 54
    private const int X3 = X2 + C + 1;  // = 107

    // Rader
    private const int FigletRad    = 2;   // första figlet-raden (rad 1 är tom)
    private const int SubtitelRad  = 9;   // undertitel under figlet
    private const int KolSepRad    = 10;  // ╠═══╦═══╦═══╣
    private const int KolRubrikRad = 11;  // LÄTT / MEDEL / SVÅR
    private const int ProcentRad   = 12;  // procent per kolumn
    private const int MetodSepRad  = 13;  // ╠═══╬═══╬═══╣
    private const int MetodRad     = 14;  // första metodrad
    private const int TotalRad     = 28;  // TOTALT-raden

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        InitKonsol();
        RitaGränssnitt();

        SkrivPå(X1 + 1, MetodRad,     "[ beräknar... ]");
        SkrivPå(X2 + 1, MetodRad,     "[ beräknar... ]");
        SkrivPå(X3 + 1, MetodRad,     "[ beräknar... ]");
        Thread.Sleep(600);

        double easy   = MarcusPlayground.KörEasy();
        double medium = MarcusPlayground.KörMedium();
        double hard   = MarcusPlayground.KörHard();

        SkrivPå(X1 + 1, MetodRad, new string(' ', 16));
        SkrivPå(X2 + 1, MetodRad, new string(' ', 16));
        SkrivPå(X3 + 1, MetodRad, new string(' ', 16));

        VisaKolumn(X1, MarcusPlayground.EasyResultat);
        VisaKolumn(X2, MarcusPlayground.MediumResultat);
        VisaKolumn(X3, MarcusPlayground.HardResultat);

        VisaProcent(X1 + 11, ProcentRad, easy);
        VisaProcent(X2 + 11, ProcentRad, medium);
        VisaProcent(X3 + 11, ProcentRad, hard);

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
        if (OperatingSystem.IsWindows())
        {
            try { Console.WindowHeight = H; Console.WindowWidth = W; }
            catch { }
        }
        else
        {
            // Linux/macOS: xterm-kompatibel ANSI-escape för fönsterstorlek
            Console.Write($"\x1b[8;{H};{W}t");
            Thread.Sleep(150);
        }

        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.CursorVisible   = false;
        Console.Clear();

        if (Console.WindowWidth < W)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"  Terminalen är {Console.WindowWidth} kolumner bred — programmet behöver {W}.");
            Console.WriteLine($"  Gör terminalfönstret bredare och tryck Enter.");
            Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
        }
    }

    private static void RitaGränssnitt()
    {
        var bred    = new string('═', W - 2);
        var kolBred = new string('═', C);
        var tomRad  = "║" + new string(' ', W - 2) + "║";
        var kolTom  = new string(' ', C);

        // Topp
        SkrivPå(0, 0, $"╔{bred}╗");

        // Figlet-header: fyll alla header-rader med ram, lägg sedan figlet ovanpå
        for (int y = 1; y < KolSepRad; y++)
            SkrivPå(0, y, tomRad);
        RitaFiglet();
        Console.ForegroundColor = ConsoleColor.Yellow;
        SkrivCentrerad(SubtitelRad, $"★   {TemaFull}   ★");
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Kolumnseparator
        SkrivPå(0, KolSepRad, $"╠{kolBred}╦{kolBred}╦{kolBred}╣");

        // Kolumnrubriker
        SkrivPå(0, KolRubrikRad, $"║{kolTom}║{kolTom}║{kolTom}║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        SkrivPå(X1 + 3, KolRubrikRad, "L Ä T T");
        SkrivPå(X2 + 3, KolRubrikRad, "M E D E L");
        SkrivPå(X3 + 3, KolRubrikRad, "S V Å R");
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Procentrad
        SkrivPå(0, ProcentRad, $"║{kolTom}║{kolTom}║{kolTom}║");
        Console.ForegroundColor = ConsoleColor.White;
        SkrivPå(X1 + 11, ProcentRad, "0%");
        SkrivPå(X2 + 11, ProcentRad, "0%");
        SkrivPå(X3 + 11, ProcentRad, "0%");
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Separator före metodrader
        SkrivPå(0, MetodSepRad, $"╠{kolBred}╬{kolBred}╬{kolBred}╣");

        // Metodrader (tomma)
        for (int y = MetodRad; y < TotalRad - 1; y++)
            SkrivPå(0, y, $"║{kolTom}║{kolTom}║{kolTom}║");

        // Separator före total
        SkrivPå(0, TotalRad - 1, $"╠{bred}╣");
        SkrivPå(0, TotalRad,     $"║{new string(' ', W - 2)}║");
        SkrivPå(0, TotalRad + 1, $"╚{bred}╝");
    }

    private static void RitaFiglet()
    {
        var figletText = FiggleFonts.Rectangles.Render(Tema);
        var rader = figletText.Split('\n')
                              .Select(r => r.TrimEnd())
                              .Where(r => r.Length > 0)
                              .ToArray();

        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < rader.Length && i < 7; i++)
        {
            string rad     = rader[i];
            int padLeft    = Math.Max(0, (W - 2 - rad.Length) / 2);
            int padRight   = Math.Max(0, W - 2 - padLeft - rad.Length);
            SkrivPå(0, FigletRad + i,
                "║" + new string(' ', padLeft) + rad + new string(' ', padRight) + "║");
        }
    }

    private static void VisaKolumn(int x, List<(string namn, bool ok)> resultat)
    {
        int y = MetodRad;
        foreach (var (namn, ok) in resultat)
        {
            Thread.Sleep(70);
            string kortNamn = namn.Length > 38 ? namn[..38] : namn;
            Console.ForegroundColor = ConsoleColor.White;
            SkrivPå(x + 1, y, kortNamn.PadRight(38));
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
        => SkrivPå((W - text.Length) / 2, y, text);

    private static void SkrivPå(int x, int y, string text)
    {
        try { Console.SetCursorPosition(x, y); Console.Write(text); }
        catch { }
    }
}
