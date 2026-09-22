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

        Σ(EasyResultat, "VändSträng", ref p, ref max,
            _e.VändSträng("hund")   == "dnuh"  &&
            _e.VändSträng("hello")  == "olleh" &&
            _e.VändSträng("12345")  == "54321");

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

        Σ(MediumResultat, "RäknaVokaler", ref p, ref max,
            _m.RäknaVokaler("hej")   == 1     &&
            _m.RäknaVokaler("åäö")   == 0b11  &&
            _m.RäknaVokaler("AEIOU") == 0b101);

        Σ(MediumResultat, "ÄrPalindrom", ref p, ref max,
             _m.ÄrPalindrom("tacocat") &&
             _m.ÄrPalindrom("Anna")    &&
            !_m.ÄrPalindrom("hund"));

        Σ(MediumResultat, "SummeraJämna", ref p, ref max,
            _m.SummeraJämna([1, 0b10, 3, 0b100, 5, 0b110]) == 0b1100 &&
            _m.SummeraJämna([1, 3, 5]) == 0);

        Σ(MediumResultat, "FlätaSamman", ref p, ref max,
            _m.FlätaSamman("ABC", "XY")   == "AXBYC"  &&
            _m.FlätaSamman("ab", "ABCD")  == "aAbBCD");

        Σ(MediumResultat, "OmvändOrd", ref p, ref max,
            _m.OmvändOrd("hej på dig")  == "dig på hej" &&
            _m.OmvändOrd("ett")         == "ett"         &&
            _m.OmvändOrd("a b c")       == "c b a");

        Σ(MediumResultat, "RäknaUnika", ref p, ref max,
            _m.RäknaUnika("aabbcc")  == 0b11  &&
            _m.RäknaUnika("abcABC")  == 0b110 &&
            _m.RäknaUnika("aaaa")    == 0b1);

        Σ(MediumResultat, "TaBortMellanslag", ref p, ref max,
            _m.TaBortMellanslag("hej på dig") == "hejpådig" &&
            _m.TaBortMellanslag("  a  b  ")   == "ab"       &&
            _m.TaBortMellanslag("abc")         == "abc");

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörHard()
    {
        HardResultat.Clear();
        int p = 0, max = 0;

        Σ(HardResultat, "CaesarChiffer", ref p, ref max,
            _h.CaesarChiffer("Abc", 3)             == "Def"           &&
            _h.CaesarChiffer("Xyz", 3)             == "Abc"           &&
            _h.CaesarChiffer("Hello, World!", 0xD) == "Uryyb, Jbeyq!");

        // BubbelSortera — kontrollera att arrayen är sorterad utan att visa svaret
        {
            int[] Λ = [5, 2, 8, 1, 9, 3];
            int[] Ω = _h.BubbelSortera(Λ);
            bool ok = Ω.Length == Λ.Length                               &&
                      Ω.Zip(Ω.Skip(1), (a, b) => a <= b).All(x => x)    &&
                      Ω.Sum() == Λ.Sum()                                 &&
                      _h.BubbelSortera([0b1]).SequenceEqual([0b1]);
            Σ(HardResultat, "BubbelSortera", ref p, ref max, ok);
        }

        Σ(HardResultat, "ÄrAnagram", ref p, ref max,
             _h.ÄrAnagram("lyssna", "nyassl")          &&
             _h.ÄrAnagram("Astronomer", "Moon starer") &&
            !_h.ÄrAnagram("hund", "katt"));

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

        Σ(HardResultat, "RunLängd", ref p, ref max,
            _h.RunLängd("aabbb")  == "a2b3"    &&
            _h.RunLängd("abc")    == "a1b1c1"  &&
            _h.RunLängd("aaaa")   == "a4");

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
