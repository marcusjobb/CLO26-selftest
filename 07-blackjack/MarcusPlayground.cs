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

        Σ(EasyResultat, "KortVärde", ref p, ref max,
            _e.KortVärde("7") == 0b111 &&
            _e.KortVärde("K") == 0xA   &&
            _e.KortVärde("Q") == 0xA   &&
            _e.KortVärde("T") == 0xA   &&
            _e.KortVärde("A") == 0b1);

        Σ(EasyResultat, "HandSumma", ref p, ref max,
            _e.HandSumma(["T", "K"])      == 0x14 &&
            _e.HandSumma(["A", "5"])      == 0b110 &&
            _e.HandSumma(["3", "4", "7"]) == 0xE);

        Σ(EasyResultat, "ÄrBust", ref p, ref max,
            _e.ÄrBust(0x16)  &&
            !_e.ÄrBust(0x15) &&
            !_e.ÄrBust(0x14));

        Σ(EasyResultat, "ÄrBlackjack", ref p, ref max,
            _e.ÄrBlackjack(["A", "K"])      &&
            _e.ÄrBlackjack(["A", "T"])      &&
            !_e.ÄrBlackjack(["T", "K"])     &&
            !_e.ÄrBlackjack(["A", "5", "5"]));

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörMedium()
    {
        MediumResultat.Clear();
        int p = 0, max = 0;

        Σ(MediumResultat, "BästaHandSumma", ref p, ref max,
            _m.BästaHandSumma(["A", "K"])      == 0x15 &&
            _m.BästaHandSumma(["A", "9", "5"]) == 0xF  &&
            _m.BästaHandSumma(["A", "A", "9"]) == 0x15 &&
            _m.BästaHandSumma(["A", "A", "A"]) == 0xD);

        Σ(MediumResultat, "SpelarVinner", ref p, ref max,
            _m.SpelarVinner(["A", "K"],  ["T", "9"])       &&
            !_m.SpelarVinner(["T", "9"], ["T", "9"])       &&
            !_m.SpelarVinner(["T", "9"], ["A", "K"])       &&
            !_m.SpelarVinner(["T", "Q"], ["6", "9", "6"]));

        Σ(MediumResultat, "KanSplittas", ref p, ref max,
            _m.KanSplittas(["K", "T"])        &&
            _m.KanSplittas(["5", "5"])        &&
            !_m.KanSplittas(["K", "9"])       &&
            !_m.KanSplittas(["5", "5", "5"]));

        Σ(MediumResultat, "KanDubbla", ref p, ref max,
            _m.KanDubbla(["7", "3"])         &&
            !_m.KanDubbla(["7", "3", "A"]));

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörHard()
    {
        HardResultat.Clear();
        int p = 0, max = 0;

        {
            var h1 = new List<string> { "9", "7" };
            var h2 = new List<string> { "T", "7" };
            var h3 = new List<string> { "T", "5" };
            Σ(HardResultat, "DealerSpelar", ref p, ref max,
                _h.DealerSpelar(h1, new Queue<string>(["5"]))     == 0x15 &&
                _h.DealerSpelar(h2, new Queue<string>(["K", "2"])) == 0x11 &&
                _h.DealerSpelar(h3, new Queue<string>(["8", "4"])) == 0x17);
        }

        Σ(HardResultat, "BestämDrag", ref p, ref max,
            _h.BestämDrag(["T", "8"])      == "Stå"    &&
            _h.BestämDrag(["A", "K"])      == "Stå"    &&
            _h.BestämDrag(["7", "4"])      == "Dubbla" &&
            _h.BestämDrag(["5", "3", "2"]) == "Dra"    &&
            _h.BestämDrag(["5", "3"])      == "Dra");

        Σ(HardResultat, "HiLoVärde", ref p, ref max,
            _h.HiLoVärde("2") ==  0b1 &&
            _h.HiLoVärde("6") ==  0b1 &&
            _h.HiLoVärde("7") ==  0   &&
            _h.HiLoVärde("9") ==  0   &&
            _h.HiLoVärde("T") == -0b1 &&
            _h.HiLoVärde("K") == -0b1 &&
            _h.HiLoVärde("A") == -0b1);

        Σ(HardResultat, "LöpandeRäknare", ref p, ref max,
            _h.LöpandeRäknare(["2", "K", "5", "A", "7"]) == 0    &&
            _h.LöpandeRäknare(["3", "4", "5", "6", "2"]) == 0b101);

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
