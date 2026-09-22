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

        Σ(EasyResultat, "RäknaVokaler", ref p, ref max,
            _e.RäknaVokaler("hej")           == 1     &&
            _e.RäknaVokaler("åäö")           == 0b11  &&
            _e.RäknaVokaler("AEIOUYYÅÄÖ")    == 0b1010);

        Σ(EasyResultat, "VändSträng", ref p, ref max,
            _e.VändSträng("hund")   == "dnuh" &&
            _e.VändSträng("A")      == "A"    &&
            _e.VändSträng("abba")   == "abba" &&
            _e.VändSträng("")       == "");

        Σ(EasyResultat, "ÄrPalindrom", ref p, ref max,
             _e.ÄrPalindrom("tacocat") &&
             _e.ÄrPalindrom("Anna")    &&
             _e.ÄrPalindrom("A")       &&
            !_e.ÄrPalindrom("hund"));

        Σ(EasyResultat, "VäxlaSkiftläge", ref p, ref max,
            _e.VäxlaSkiftläge("Hej!") == "hEJ!" &&
            _e.VäxlaSkiftläge("abc")  == "ABC"  &&
            _e.VäxlaSkiftläge("123")  == "123");

        Σ(EasyResultat, "RäknaOrd", ref p, ref max,
            _e.RäknaOrd("hej du där")      == 0b11    &&
            _e.RäknaOrd("ett")             == 1       &&
            _e.RäknaOrd("  flera   blankt ") == 0b11);

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörMedium()
    {
        MediumResultat.Clear();
        int p = 0, max = 0;

        Σ(MediumResultat, "SummeraText", ref p, ref max,
            _m.SummeraText("a1b2c3")                      == 0b110  &&
            _m.SummeraText("112")                          == 0b100  &&
            _m.SummeraText("marcus1970@mail4ever.com")     == 0x15   &&
            _m.SummeraText("ingasifffror")                 == 0);

        Σ(MediumResultat, "FlätaSamman", ref p, ref max,
            _m.FlätaSamman("ABC", "XY")   == "AXBYC"  &&
            _m.FlätaSamman("ab", "ABCD")  == "aAbBCD" &&
            _m.FlätaSamman("", "xyz")     == "xyz");

        Σ(MediumResultat, "VarannanBokstav", ref p, ref max,
            _m.VarannanBokstav("Katt", "Hund")      == "KHautntd"     &&
            _m.VarannanBokstav("Nelson", "Mandela") == "NMealnsdoenla");

        Σ(MediumResultat, "VändOrdning", ref p, ref max,
            _m.VändOrdning("hej du där")  == "där du hej"    &&
            _m.VändOrdning("ett")         == "ett"           &&
            _m.VändOrdning("a b c d")     == "d c b a");

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

        Σ(HardResultat, "ÄrAnagram", ref p, ref max,
             _h.ÄrAnagram("lyssna", "nyassl")          &&
             _h.ÄrAnagram("Astronomer", "Moon starer") &&
            !_h.ÄrAnagram("hund", "katt"));

        Σ(HardResultat, "FörstaVärden", ref p, ref max,
            _h.FörstaVärden(3, "A", "B", "C", "D", "E")                          == "ABC"       &&
            _h.FörstaVärden(9, "R","A","M","M","S","T","E","I","N","Du Hast")    == "RAMMSTEIN" &&
            _h.FörstaVärden(1, "X", "Y", "Z")                                    == "X");

        Σ(HardResultat, "KomprimeraText", ref p, ref max,
            _h.KomprimeraText("aaabbc")  == "a3b2c1" &&
            _h.KomprimeraText("abcd")    == "a1b1c1d1" &&
            _h.KomprimeraText("aaa")     == "a3");

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
