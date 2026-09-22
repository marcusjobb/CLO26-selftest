namespace CSharpRepetition;

public class Hard
{
    // Simulerar dealerns tur: dealern drar kort ur kortleken tills summan >= 17.
    // Returnerar dealerns slutsumma (kan vara bust > 21).
    // DealerSpelar(["9","7"],       new Queue(["5"]))      => 16 → drar "5" → 21
    // DealerSpelar(["T","7"],       new Queue(["K","2"])) => 17 → stannar
    // DealerSpelar(["T","5"],       new Queue(["8","4"])) => 15 → drar "8" → 23 (bust)
    public int DealerSpelar(List<string> hand, Queue<string> kortlek)
    {
        // Skriv din kod här
        // Tips: använd BästaHandSumma-logiken (A=11 om möjligt) och dra tills summan >= 17

        return 0;
    }

    // Returnerar spelarens rekommenderade drag enligt förenklad strategi:
    // "Stå"    — om Blackjack, eller BästaHandSumma >= 17
    // "Dubbla" — om exakt 2 kort och BästaHandSumma är 10 eller 11
    // "Dra"    — annars
    // BestämDrag(["T", "8"])       => "Stå"      (18 >= 17)
    // BestämDrag(["A", "K"])       => "Stå"      (Blackjack)
    // BestämDrag(["7", "4"])       => "Dubbla"   (11, 2 kort)
    // BestämDrag(["5", "3", "2"])  => "Dra"      (10, men 3 kort)
    // BestämDrag(["5", "3"])       => "Dra"      (8 < 10)
    public string BestämDrag(string[] hand)
    {
        // Skriv din kod här

        return "";
    }

    // Returnerar kortets Hi-Lo-räkningsvärde.
    // 2–6 => +1, 7–9 => 0, T/J/Q/K/A => -1
    // HiLoVärde("5") => 1
    // HiLoVärde("9") => 0
    // HiLoVärde("K") => -1
    // HiLoVärde("A") => -1
    public int HiLoVärde(string kort)
    {
        // Skriv din kod här

        return 0;
    }

    // Returnerar det löpande räknartalet för en sekvens av visade kort.
    // LöpandeRäknare(["2","K","5","A","7"]) => 1 - 1 + 1 - 1 + 0 = 0
    // LöpandeRäknare(["3","4","5","6","2"]) => 5
    public int LöpandeRäknare(string[] kort)
    {
        // Skriv din kod här

        return 0;
    }
}
