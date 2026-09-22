using System.Text;

namespace CSharpRepetition;

// ┌──────────────────────────────────────────────────────────────────────────┐
// │ Implementera metoderna i Easy.cs, Medium.cs och Hard.cs.                │
// │ Kör programmet för att se hur långt du kommit.                          │
// │ Gott råd: tänk själv — googla dokumentation, inte svar.                 │
// └──────────────────────────────────────────────────────────────────────────┘

internal static class Program
{
    private const string Tema     = "LISTOR";  // ASCII, renderas som Figlet
    private const string TemaFull = "Listor & Arrays";  // Visas under Figlet

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        TUI.Start(Tema, TemaFull);
    }
}
