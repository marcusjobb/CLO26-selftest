namespace CSharpRepetition;

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

        Σ(EasyResultat, "Chans", ref p, ref max,
            _e.Chans([1, 0b10, 3, 0b100, 5]) == 0xF  &&
            _e.Chans([6, 6, 6, 6, 6])         == 0x1E &&
            _e.Chans([1, 1, 1, 1, 1])         == 0b101);

        Σ(EasyResultat, "ÖverDel", ref p, ref max,
            _e.ÖverDel([1, 1, 0b10, 3, 1], 1)      == 0b11  &&
            _e.ÖverDel([6, 6, 6, 5, 0b100], 0b110) == 0x12  &&
            _e.ÖverDel([1, 0b10, 3, 0b100, 5], 6)  == 0);

        Σ(EasyResultat, "HarPar", ref p, ref max,
            _e.HarPar([1, 1, 3, 0b100, 5])     &&
            _e.HarPar([6, 6, 6, 6, 6])         &&
            !_e.HarPar([1, 0b10, 3, 0b100, 5]));

        Σ(EasyResultat, "HarTrio", ref p, ref max,
            _e.HarTrio([0b10, 0b10, 0b10, 4, 5]) &&
            !_e.HarTrio([1, 1, 0b10, 3, 0b100]));

        Σ(EasyResultat, "HarFyrkind", ref p, ref max,
            _e.HarFyrkind([6, 6, 6, 6, 1])         &&
            !_e.HarFyrkind([6, 6, 6, 1, 1]));

        Σ(EasyResultat, "HarYatzy", ref p, ref max,
            _e.HarYatzy([0b100, 0b100, 0b100, 0b100, 0b100]) &&
            !_e.HarYatzy([0b100, 0b100, 0b100, 0b100, 0b101]));

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörMedium()
    {
        MediumResultat.Clear();
        int p = 0, max = 0;

        Σ(MediumResultat, "Par", ref p, ref max,
            _m.Par([5, 5, 3, 0b10, 1])         == 0xA  &&
            _m.Par([6, 6, 5, 5, 1])             == 0xC  &&
            _m.Par([1, 0b10, 3, 0b100, 5])      == 0);

        Σ(MediumResultat, "TvåPar", ref p, ref max,
            _m.TvåPar([6, 6, 0b100, 0b100, 1]) == 0x14 &&
            _m.TvåPar([5, 5, 3, 0b10, 1])       == 0);

        Σ(MediumResultat, "Trekind", ref p, ref max,
            _m.Trekind([3, 3, 3, 1, 0b10])     == 0b1001 &&
            _m.Trekind([0b10, 0b10, 3, 4, 5])  == 0);

        Σ(MediumResultat, "Fyrkind", ref p, ref max,
            _m.Fyrkind([6, 6, 6, 6, 1])         == 0x18 &&
            _m.Fyrkind([6, 6, 6, 1, 1])         == 0);

        Σ(MediumResultat, "Kåk", ref p, ref max,
            _m.Kåk([3, 3, 3, 5, 5])             == 0x13 &&
            _m.Kåk([3, 3, 3, 3, 5])             == 0    &&
            _m.Kåk([1, 0b10, 3, 0b100, 5])      == 0);

        Σ(MediumResultat, "Yatzy", ref p, ref max,
            _m.Yatzy([0b100, 0b100, 0b100, 0b100, 0b100]) == 0x32 &&
            _m.Yatzy([0b100, 0b100, 0b100, 0b100, 0b101]) == 0);

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörHard()
    {
        HardResultat.Clear();
        int p = 0, max = 0;

        Σ(HardResultat, "LitenStege", ref p, ref max,
            _h.LitenStege([1, 0b10, 3, 0b100, 5])  == 0xF  &&
            _h.LitenStege([1, 0b10, 3, 0b100, 6])  == 0    &&
            _h.LitenStege([1, 1, 3, 0b100, 5])     == 0);

        Σ(HardResultat, "StorStege", ref p, ref max,
            _h.StorStege([0b10, 3, 0b100, 5, 6])   == 0x14 &&
            _h.StorStege([1, 0b10, 3, 0b100, 5])   == 0);

        {
            int[] Λ = [6, 6, 5, 5, 6];
            int[] Ω = [3, 3, 3, 3, 3];
            Σ(HardResultat, "BästaÖverDel", ref p, ref max,
                _h.BästaÖverDel(Λ) == 0b110  &&
                _h.BästaÖverDel(Ω) == 0b11);
        }

        {
            var κ1 = new Dictionary<string, int>
            {
                ["1"] = 0b11,  ["2"] = 0b110, ["3"] = 0b1001,
                ["4"] = 0xC,   ["5"] = 0xF,   ["6"] = 0x12,
                ["Yatzy"] = 0x32,
            };
            var κ2 = new Dictionary<string, int>
            {
                ["1"] = 1, ["2"] = 0b100, ["3"] = 0b110,
                ["4"] = 8, ["5"] = 0xA,   ["6"] = 0xC,
                ["Kåk"] = 0x14,
            };
            Σ(HardResultat, "TotalPoäng", ref p, ref max,
                _h.TotalPoäng(κ1) == 0x94 &&
                _h.TotalPoäng(κ2) == 0x3D);
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
