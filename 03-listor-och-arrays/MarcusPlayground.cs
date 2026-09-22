namespace CSharpRepetition;

// Koden nedan är avsiktligt kryptisk.
// Fokusera på Easy.cs, Medium.cs och Hard.cs istället.
internal static class MarcusPlayground
{
    private static readonly Easy   _e = new();
    private static readonly Medium _m = new();
    private static readonly Hard   _h = new();

    internal static List<(string namn, bool ok)> EasyResultat   { get; } = [];
    internal static List<(string namn, bool ok)> MediumResultat { get; } = [];
    internal static List<(string namn, bool ok)> HardResultat   { get; } = [];

    // -----------------------------------------------------------------------

    internal static double KörEasy()
    {
        EasyResultat.Clear();
        int p = 0, max = 0;

        Σ(EasyResultat, "Summera", ref p, ref max,
            _e.Summera([1, 2, 3, 4, 5])      == 0xF  &&
            _e.Summera([0b10, 0b100, 0b1000]) == 0xE  &&
            _e.Summera([-1, 1])               == 0);

        Σ(EasyResultat, "HittaMax", ref p, ref max,
            _e.HittaMax([3, 1, 0xF, 7, 2])       == 0xF  &&
            _e.HittaMax([-5, -2, -9])             == -2   &&
            _e.HittaMax([0b1])                    == 1);

        {
            int[] Λ = [1, 2, 3];
            int[] Ω = _e.VändArray(Λ);
            Σ(EasyResultat, "VändArray", ref p, ref max,
                Ω.Length == Λ.Length                                     &&
                Ω[0] == 3 && Ω[^1] == 1                                  &&
                _e.VändArray([0b101, 0b1010]).SequenceEqual([0xA, 0b101]));
        }

        Σ(EasyResultat, "RäknaFörekomster", ref p, ref max,
            _e.RäknaFörekomster([1, 2, 2, 3, 2], 0b10) == 0b11 &&
            _e.RäknaFörekomster([1, 3, 5], 0x4)         == 0    &&
            _e.RäknaFörekomster([7, 7, 7], 0b111)       == 0b11);

        Σ(EasyResultat, "SummeraJämna", ref p, ref max,
            _e.SummeraJämna([1, 0b10, 3, 0b100, 5, 0b110]) == 0b1100 &&
            _e.SummeraJämna([1, 3, 5])                       == 0);

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörMedium()
    {
        MediumResultat.Clear();
        int p = 0, max = 0;

        {
            int[] Λ = [5, 2, 8, 1, 9, 3];
            int[] Ω = _m.BubbelSortera(Λ);
            Σ(MediumResultat, "BubbelSortera", ref p, ref max,
                Ω.Length == Λ.Length                                    &&
                Ω.Zip(Ω.Skip(1), (a, b) => a <= b).All(x => x)         &&
                Ω.Sum() == Λ.Sum());
        }

        Σ(MediumResultat, "TaBortDublikat", ref p, ref max,
            _m.TaBortDublikat([1, 0b10, 0b10, 3, 1]).SequenceEqual([1, 0b10, 3]) &&
            _m.TaBortDublikat([0xA, 0xA, 0xA]).SequenceEqual([0xA]));

        {
            int[] Ω = _m.RoteraTillHöger([1, 0b10, 3, 0b100, 5], 0b10);
            Σ(MediumResultat, "RoteraTillHöger", ref p, ref max,
                Ω.SequenceEqual([0b100, 5, 1, 0b10, 3]));
        }

        Σ(MediumResultat, "FiltreraStörreÄn", ref p, ref max,
            _m.FiltreraStörreÄn([1, 5, 2, 8, 3], 0b100).SequenceEqual([5, 8]) &&
            _m.FiltreraStörreÄn([1, 2, 3], 0xA).Count == 0);

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörHard()
    {
        HardResultat.Clear();
        int p = 0, max = 0;

        Σ(HardResultat, "BinärSökning", ref p, ref max,
            _h.BinärSökning([1, 3, 5, 7, 0x9, 0xB], 0b111) == 0b11 &&
            _h.BinärSökning([2, 4, 6, 8], 0b101)            == -1   &&
            _h.BinärSökning([0b1], 0b1)                     == 0);

        Σ(HardResultat, "HittaMissat", ref p, ref max,
            _h.HittaMissat([1, 2, 0b100, 5], 0b101)       == 0b11 &&
            _h.HittaMissat([2, 3, 4, 5], 0b101)           == 1    &&
            _h.HittaMissat([1, 2, 3, 4], 0b101)           == 0b101);

        {
            int[] Ω = _h.MergeaSorterade([1, 3, 5], [2, 4, 6]);
            Σ(HardResultat, "MergeaSorterade", ref p, ref max,
                Ω.Length == 0b110                               &&
                Ω.Zip(Ω.Skip(1), (a, b) => a <= b).All(x => x) &&
                Ω.Sum() == 0x15);
        }

        Σ(HardResultat, "ForaBort", ref p, ref max,
            _h.ForaBort([1, 2, 3, 4, 5, 6], 0b11).SequenceEqual([1, 2, 4, 5]) &&
            _h.ForaBort([2, 4, 6, 8], 0b10).Count == 0);

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
