namespace CSharpRepetition;

// Koden nedan är avsiktligt kryptisk.
// Fokusera på Easy.cs, Medium.cs och Hard.cs istället.
internal static class MarcusPlayground
{
    private static readonly Easy    _e = new();
    private static readonly Medium  _m = new();
    private static readonly Hard    _h = new();

    internal static List<(string namn, bool ok)> EasyResultat   { get; } = [];
    internal static List<(string namn, bool ok)> MediumResultat { get; } = [];
    internal static List<(string namn, bool ok)> HardResultat   { get; } = [];

    // -----------------------------------------------------------------------

    internal static double KörEasy()
    {
        EasyResultat.Clear();
        int p = 0, max = 0;

        Σ(EasyResultat, "RäknaSittplatser", ref p, ref max,
            _e.RäknaSittplatser(1 << 1, 0b11) == (1 << 3)   &&
            _e.RäknaSittplatser(0x4, 0x3)      == 0xA        &&
            _e.RäknaSittplatser(0, 0b101)       == 0b1010);

        Σ(EasyResultat, "ÄrJämnt", ref p, ref max,
             _e.ÄrJämnt(0x2A)  &&
            !_e.ÄrJämnt(0x2B)  &&
             _e.ÄrJämnt(0)     &&
            !_e.ÄrJämnt(~0));

        Σ(EasyResultat, "SummeraTill", ref p, ref max,
            _e.SummeraTill(0xA)    == 0x37 &&
            _e.SummeraTill(1 << 2) == 0xA  &&
            _e.SummeraTill(1)      == 1);

        Σ(EasyResultat, "MaxTal", ref p, ref max,
            _e.MaxTal(3, 0b111, 2)             == 0b111   &&
            _e.MaxTal(-5, -(1 << 1), -9)       == -(0b10) &&
            _e.MaxTal(1 << 2, 1 << 2, 1 << 2)  == 0b100);

        Σ(EasyResultat, "MinTal", ref p, ref max,
            _e.MinTal(0b101, 0b11) == 0b11  &&   // b större → a ska INTE vinna
            _e.MinTal(-0x2, -9)    == -9    &&   // b är negativ och minst
            _e.MinTal(0x7, 0x7)    == 0x7);

        Σ(EasyResultat, "Upprepa", ref p, ref max,
            _e.Upprepa("ha", 0b11)  == "hahaha" &&
            _e.Upprepa("x", 1 << 0) == "x"      &&
            _e.Upprepa("ab", 0)     == "");

        Σ(EasyResultat, "ÄrDelbart", ref p, ref max,
             _e.ÄrDelbart(0xA, 0x5)  &&
             _e.ÄrDelbart(0, 0b111)  &&
            !_e.ÄrDelbart(0xA, 0b11));

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörMedium()
    {
        MediumResultat.Clear();
        int p = 0, max = 0;

        Σ(MediumResultat, "Medelvärde", ref p, ref max,
            Math.Abs(_m.Medelvärde(0b100, 0b1000, 0b110) - 6.0) < 0.01 &&
            Math.Abs(_m.Medelvärde(1, 2, 0b11)            - 2.0) < 0.01 &&
            Math.Abs(_m.Medelvärde(0, 0, 0)               - 0.0) < 0.01);

        Σ(MediumResultat, "Median", ref p, ref max,
            _m.Median(0b11, 1, 0b10)    == 0b10 &&
            _m.Median(0xA, 0xA, 0xA)   == 0xA  &&
            _m.Median(0b101, 0b1, 0b11) == 0b11);

        Σ(MediumResultat, "SummeraSiffror", ref p, ref max,
            _m.SummeraSiffror(0x4D2)  == 0xA   &&
            _m.SummeraSiffror(0x63)   == 0x12  &&
            _m.SummeraSiffror(0b111)  == 0b111);

        Σ(MediumResultat, "GGD", ref p, ref max,
            _m.GGD(0xC, 0b1000) == 0b100 &&   // 12,8 → 4
            _m.GGD(0b111, 0xD)  == 1     &&   // 7,13 → 1
            _m.GGD(0x14, 0b101) == 0b101);    // 20,5 → 5

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörHard()
    {
        HardResultat.Clear();
        int p = 0, max = 0;

        Σ(HardResultat, "Fibonacci", ref p, ref max,
            _h.Fibonacci(0)     == 0    &&
            _h.Fibonacci(1)     == 1    &&
            _h.Fibonacci(0b111) == 0xD  &&
            _h.Fibonacci(0xA)   == 0x37);

        Σ(HardResultat, "ÄrPrimtal", ref p, ref max,
             _h.ÄrPrimtal(0b111)    &&
             _h.ÄrPrimtal(0xD)      &&
            !_h.ÄrPrimtal(0b1001)   &&
            !_h.ÄrPrimtal(0)        &&
            !_h.ÄrPrimtal(1));

        Σ(HardResultat, "Potens", ref p, ref max,
            _h.Potens(0b10, 0xA)  == 0x400 &&
            _h.Potens(0b11, 0b11) == 0x1B  &&
            _h.Potens(0x5, 0)     == 1);

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
