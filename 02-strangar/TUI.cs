using Figgle;
using Figgle.Fonts;

namespace CSharpRepetition;

internal static class TUI
{
    internal const int W = 160;
    internal const int H = 32;
    private const int C = 52;

    private const int X1 = 1;
    private const int X2 = X1 + C + 1;
    private const int X3 = X2 + C + 1;

    private const int FigletRad    = 2;
    private const int SubtitelRad  = 9;
    private const int KolSepRad    = 10;
    private const int KolRubrikRad = 11;
    private const int ProcentRad   = 12;
    private const int MetodSepRad  = 13;
    private const int MetodRad     = 14;
    private const int TotalRad     = 28;

    private static string _tema     = "";
    private static string _temaFull = "";

    internal static void Start(string tema, string temaFull)
    {
        _tema     = tema;
        _temaFull = temaFull;

        InitKonsol();
        RitaGränssnitt();
        RitaAsciiKonst();

        SkrivPå(X1 + 1, MetodRad, "[ beräknar... ]");
        SkrivPå(X2 + 1, MetodRad, "[ beräknar... ]");
        SkrivPå(X3 + 1, MetodRad, "[ beräknar... ]");
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

    private static void RitaAsciiKonst()
    {
        // Gummianka (vänster om titeln)
        string[] anka =
        [
            "      ,~~.",
            " ,   (  - )>",
            " )`~~'   (",
            "(  .__)   )",
            " `-.____,' hjw",
        ];
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < anka.Length; i++)
            SkrivPå(2, 3 + i, anka[i]);

        // Programmerare (höger om titeln)
        string[] gubbe =
        [
            "///-\\\\\\",
            "|^   ^|",
            "|O   O|",
            "|  ~ *slap*!",
            " \\ O /",
            "  | |",
        ];
        Console.ForegroundColor = ConsoleColor.White;
        int x = W - 2 - 12;   // högerpassad mot inner-kanten
        for (int i = 0; i < gubbe.Length; i++)
            SkrivPå(x, 2 + i, gubbe[i]);

        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    private static void InitKonsol()
    {
        if (OperatingSystem.IsWindows())
        {
            try { Console.WindowHeight = H; Console.WindowWidth = W; }
            catch { }
        }
        else
        {
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

        SkrivPå(0, 0, $"╔{bred}╗");

        for (int y = 1; y < KolSepRad; y++)
            SkrivPå(0, y, tomRad);
        RitaFiglet();
        Console.ForegroundColor = ConsoleColor.Yellow;
        SkrivCentrerad(SubtitelRad, $"★   {_temaFull}   ★");
        Console.ForegroundColor = ConsoleColor.Cyan;

        SkrivPå(0, KolSepRad, $"╠{kolBred}╦{kolBred}╦{kolBred}╣");

        SkrivPå(0, KolRubrikRad, $"║{kolTom}║{kolTom}║{kolTom}║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        SkrivPå(X1 + 3, KolRubrikRad, "L Ä T T");
        SkrivPå(X2 + 3, KolRubrikRad, "M E D E L");
        SkrivPå(X3 + 3, KolRubrikRad, "S V Å R");
        Console.ForegroundColor = ConsoleColor.Cyan;

        SkrivPå(0, ProcentRad, $"║{kolTom}║{kolTom}║{kolTom}║");
        Console.ForegroundColor = ConsoleColor.White;
        SkrivPå(X1 + 11, ProcentRad, "0%");
        SkrivPå(X2 + 11, ProcentRad, "0%");
        SkrivPå(X3 + 11, ProcentRad, "0%");
        Console.ForegroundColor = ConsoleColor.Cyan;

        SkrivPå(0, MetodSepRad, $"╠{kolBred}╬{kolBred}╬{kolBred}╣");

        for (int y = MetodRad; y < TotalRad - 1; y++)
            SkrivPå(0, y, $"║{kolTom}║{kolTom}║{kolTom}║");

        SkrivPå(0, TotalRad - 1, $"╠{bred}╣");
        SkrivPå(0, TotalRad,     $"║{new string(' ', W - 2)}║");
        SkrivPå(0, TotalRad + 1, $"╚{bred}╝");
    }

    private static void RitaFiglet()
    {
        var figletText = FiggleFonts.Rectangles.Render(_tema);
        var rader = figletText.Split('\n')
                              .Select(r => r.TrimEnd())
                              .Where(r => r.Length > 0)
                              .ToArray();

        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < rader.Length && i < 7; i++)
        {
            string rad   = rader[i];
            int padLeft  = Math.Max(0, (W - 2 - rad.Length) / 2);
            int padRight = Math.Max(0, W - 2 - padLeft - rad.Length);
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
