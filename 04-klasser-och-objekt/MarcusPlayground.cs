namespace CSharpRepetition;

// Koden nedan är avsiktligt kryptisk.
// Fokusera på Easy.cs, Medium.cs och Hard.cs istället.
internal static class MarcusPlayground
{
    internal static List<(string namn, bool ok)> EasyResultat   { get; } = [];
    internal static List<(string namn, bool ok)> MediumResultat { get; } = [];
    internal static List<(string namn, bool ok)> HardResultat   { get; } = [];

    // -----------------------------------------------------------------------

    internal static double KörEasy()
    {
        EasyResultat.Clear();
        int p = 0, max = 0;

        // BankKonto — konstruktor och startsaldo
        {
            var κ = new BankKonto(0x3E8);
            Σ(EasyResultat, "BankKonto — startsaldo", ref p, ref max,
                κ.HämtaSaldo() == 0x3E8);
        }

        // SättIn
        {
            var κ = new BankKonto(0x64);
            κ.SättIn(0x32);
            κ.SättIn(0b10);
            Σ(EasyResultat, "BankKonto — SättIn", ref p, ref max,
                κ.HämtaSaldo() == 0x64 + 0x32 + 0b10);
        }

        // TaUt lyckat
        {
            var κ = new BankKonto(1 << 9);
            bool ok = κ.TaUt(1 << 7);
            Σ(EasyResultat, "BankKonto — TaUt lyckat", ref p, ref max,
                ok && κ.HämtaSaldo() == (1 << 9) - (1 << 7));
        }

        // TaUt misslyckat (för lite pengar)
        {
            var κ = new BankKonto(0x32);
            bool ok = κ.TaUt(0x3E8);
            Σ(EasyResultat, "BankKonto — TaUt nekas", ref p, ref max,
                !ok && κ.HämtaSaldo() == 0x32);
        }

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörMedium()
    {
        MediumResultat.Clear();
        int p = 0, max = 0;

        // LäggTill och AntalSpelare
        {
            var τ = new Topplista();
            τ.LäggTill("Alice", 0x3E8);
            τ.LäggTill("Bob", 0x1F4);
            τ.LäggTill("Carol", 0x5DC);
            Σ(MediumResultat, "Topplista — LäggTill", ref p, ref max,
                τ.AntalSpelare() == 0b11);
        }

        // Etta
        {
            var τ = new Topplista();
            τ.LäggTill("Alice", 0x3E8);
            τ.LäggTill("Bob", 0x1F4);
            τ.LäggTill("Carol", 0x5DC);
            Σ(MediumResultat, "Topplista — Etta", ref p, ref max,
                τ.Etta() == "Carol");
        }

        // HämtaPoäng
        {
            var τ = new Topplista();
            τ.LäggTill("Zlatan", 1 << 10);
            Σ(MediumResultat, "Topplista — HämtaPoäng", ref p, ref max,
                τ.HämtaPoäng("Zlatan")  == 1 << 10 &&
                τ.HämtaPoäng("Marcus")  == -1);
        }

        // Uppdatera poäng om högre
        {
            var τ = new Topplista();
            τ.LäggTill("Ali", 0x64);
            τ.LäggTill("Ali", 0x3E8);
            τ.LäggTill("Ali", 0x32);
            Σ(MediumResultat, "Topplista — uppdatera poäng", ref p, ref max,
                τ.HämtaPoäng("Ali") == 0x3E8 &&
                τ.AntalSpelare()    == 1);
        }

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörHard()
    {
        HardResultat.Clear();
        int p = 0, max = 0;

        // Enqueue och Count
        {
            var q = new Kö();
            q.Enqueue("A");
            q.Enqueue("B");
            q.Enqueue("C");
            Σ(HardResultat, "Kö — Enqueue/Count", ref p, ref max,
                q.Count() == 0b11 && !q.ÄrTom());
        }

        // FIFO-ordning via Dequeue
        {
            var q = new Kö();
            q.Enqueue("ett");
            q.Enqueue("två");
            q.Enqueue("tre");
            Σ(HardResultat, "Kö — Dequeue FIFO", ref p, ref max,
                q.Dequeue() == "ett" &&
                q.Dequeue() == "två" &&
                q.Count()   == 1);
        }

        // Peek påverkar inte kön
        {
            var q = new Kö();
            q.Enqueue("x");
            Σ(HardResultat, "Kö — Peek", ref p, ref max,
                q.Peek()   == "x" &&
                q.Count()  == 1   &&
                q.Dequeue() == "x");
        }

        // ÄrTom
        {
            var q = new Kö();
            bool tomFörut = q.ÄrTom();
            q.Enqueue("Y");
            bool inteNu = q.ÄrTom();
            q.Dequeue();
            bool tomIgen = q.ÄrTom();
            Σ(HardResultat, "Kö — ÄrTom", ref p, ref max,
                tomFörut && !inteNu && tomIgen);
        }

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    private static void Σ(List<(string, bool)> lista, string namn,
                          ref int poäng, ref int max, bool resultat)
    {
        max++;
        if (resultat) poäng++;
        lista.Add((namn, resultat));
    }
}
