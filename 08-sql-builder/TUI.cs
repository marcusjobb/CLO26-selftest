using Spectre.Console;
using Spectre.Console.Rendering;

namespace CSharpRepetition;

internal static class TUI
{
    private static string _tema     = "";
    private static string _temaFull = "";

    internal static void Start(string tema, string temaFull)
    {
        _tema     = tema;
        _temaFull = temaFull;

        AnsiConsole.Clear();

        double easy   = MarcusPlayground.KörEasy();
        double medium = MarcusPlayground.KörMedium();
        double hard   = MarcusPlayground.KörHard();

        double total = Math.Round((easy + medium + hard) / 3, 1);

        var layout = new Rows(
            RitaTitel(),
            new Markup($"[yellow]★   {Markup.Escape(_temaFull)}   ★[/]").Centered(),
            new Text(""),
            RitaResultatTabell(easy, medium, hard),
            new Text(""),
            RitaTotal(total)
        );

        AnsiConsole.Write(new Panel(layout)
            .Header($"[bold cyan] {Markup.Escape(_tema)} [/]")
            .BorderColor(Color.Cyan1)
            .Expand());

        Console.ReadLine();
    }

    // -----------------------------------------------------------------------

    private static IRenderable RitaTitel()
        => new FigletText(_tema)
            .Centered()
            .Color(Color.Cyan1);

    private static IRenderable RitaResultatTabell(double easy, double medium, double hard)
    {
        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Cyan1)
            .Expand();

        table.AddColumn(new TableColumn(Kolumnrubrik("L Ä T T", easy)).Centered());
        table.AddColumn(new TableColumn(Kolumnrubrik("M E D E L", medium)).Centered());
        table.AddColumn(new TableColumn(Kolumnrubrik("S V Å R", hard)).Centered());

        int rader = Math.Max(
            MarcusPlayground.EasyResultat.Count,
            Math.Max(MarcusPlayground.MediumResultat.Count, MarcusPlayground.HardResultat.Count));

        for (int i = 0; i < rader; i++)
        {
            table.AddRow(
                Rad(MarcusPlayground.EasyResultat, i),
                Rad(MarcusPlayground.MediumResultat, i),
                Rad(MarcusPlayground.HardResultat, i));
        }

        return table;
    }

    private static string Kolumnrubrik(string namn, double procent)
    {
        string färg = procent >= 100 ? "green" : procent >= 50 ? "yellow" : "red";
        return $"[bold yellow]{namn}[/]\n[{färg}]{procent}%[/]";
    }

    private static string Rad(List<(string namn, bool ok)> resultat, int i)
    {
        if (i >= resultat.Count) return "";
        var (namn, ok) = resultat[i];
        string bock = ok ? "[green]✓[/]" : "[red]✗[/]";
        return $"{Markup.Escape(namn)}  {bock}";
    }

    private static IRenderable RitaTotal(double total)
    {
        string färg = total >= 100 ? "green" : "yellow";
        return new Markup($"[bold {färg}]T O T A L T :   {total} %[/]").Centered();
    }
}
