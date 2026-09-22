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

        Σ(EasyResultat, "Hund — LåtSom", ref p, ref max,
            new Hund("Rex").LåtSom() == "Vov!");

        Σ(EasyResultat, "Katt — LåtSom", ref p, ref max,
            new Katt("Whiskers").LåtSom() == "Mjau!");

        Σ(EasyResultat, "Papegoja — LåtSom", ref p, ref max,
            new Papegoja("Polly", "Polly vill ha kex!").LåtSom() == "Polly vill ha kex!" &&
            new Papegoja("Piraten", "Skatt!").LåtSom() == "Skatt!");

        Σ(EasyResultat, "Djur — HälsaPå", ref p, ref max,
            new Hund("Bella").HälsaPå()           == "Bella säger Vov!"   &&
            new Katt("Missan").HälsaPå()           == "Missan säger Mjau!" &&
            new Papegoja("P", "Hej!").HälsaPå()   == "P säger Hej!");

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörMedium()
    {
        MediumResultat.Clear();
        int p = 0, max = 0;

        Σ(MediumResultat, "Cirkel — BeräknaArea", ref p, ref max,
            Math.Abs(new Cirkel(0b101).BeräknaArea() - Math.PI * 0x19) < 0.01 &&
            Math.Abs(new Cirkel(1).BeräknaArea()     - Math.PI)        < 0.01);

        Σ(MediumResultat, "Rektangel — BeräknaArea", ref p, ref max,
            new Rektangel(0b100, 0b110).BeräknaArea() == 0x18 &&
            new Rektangel(0xA, 0b101).BeräknaArea()   == 0x32);

        Σ(MediumResultat, "Triangel — BeräknaArea", ref p, ref max,
            new Triangel(0b110, 0b100).BeräknaArea() == 0b1100 &&
            new Triangel(0xA, 0b100).BeräknaArea()   == 0x14);

        Σ(MediumResultat, "Figur — Beskriv", ref p, ref max,
            new Rektangel(0b100, 0b101).Beskriv()  == "Rektangel med area 20" &&
            new Triangel(0b110, 0b100).Beskriv()   == "Triangel med area 12");

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörHard()
    {
        HardResultat.Clear();
        int p = 0, max = 0;

        Σ(HardResultat, "Bil — BeräknaKostnad", ref p, ref max,
            new Bil("Volvo", "V70", 0b111).BeräknaKostnad(0x64)    == 0x64 / 10.0 * 0b111 * 18 &&
            new Bil("Saab", "93", 0b1000).BeräknaKostnad(0x32)    == 0x32 / 10.0 * 0b1000 * 18);

        Σ(HardResultat, "Elfordon — BeräknaKostnad", ref p, ref max,
            Math.Abs(new Elfordon("Tesla", "3", 0b10100).BeräknaKostnad(0x64) -
                     (0x64 / 10.0 * 0b10100 * 1.5)) < 0.01);

        Σ(HardResultat, "Hyrbil — BeräknaKostnad", ref p, ref max,
            new Hyrbil("Ford", "Focus", 0b111, 0x1F4).BeräknaKostnad(0x64) ==
            (0x64 / 10.0 * 0b111 * 18) + 0x1F4);

        Σ(HardResultat, "Fordon — Presentation", ref p, ref max,
            new Bil("Volvo", "V70", 0b111).Presentation()   == "Volvo V70"  &&
            new Elfordon("Tesla", "3", 0xF).Presentation()  == "Tesla 3");

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
