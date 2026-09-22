namespace CSharpRepetition;

public class Medium
{
    // Returnerar handens bästa möjliga summa.
    // Ess räknas som 11 om det inte leder till bust (> 21). Annars 1.
    // BästaHandSumma(["A", "K"])        => 21   (11 + 10)
    // BästaHandSumma(["A", "9", "5"])   => 15   (1 + 9 + 5, annars 25 = bust)
    // BästaHandSumma(["A", "A", "9"])   => 21   (11 + 1 + 9)
    // BästaHandSumma(["A", "A", "A"])   => 13   (11 + 1 + 1)
    public int BästaHandSumma(string[] kort)
    {
        // Skriv din kod här
        // Tips: börja med alla Ess som 1 och uppgradera ett åt gången till 11

        return 0;
    }

    // Returnerar true om spelaren vinner mot dealern.
    // Jämför BästaHandSumma — den närmast 21 (utan bust) vinner.
    // Blackjack (21 på 2 kort) slår vanlig 21.
    // Vid lika summa vinner dealern.
    // SpelarVinner(["A","K"],  ["T","9"])  => true   (BJ 21 vs 19)
    // SpelarVinner(["T","9"],  ["T","9"])  => false  (lika → dealer)
    // SpelarVinner(["T","9"],  ["A","K"])  => false  (19 vs BJ)
    // SpelarVinner(["T","Q"],  ["6","9","6"]) => false  (20 vs 21)
    public bool SpelarVinner(string[] spelare, string[] dealer)
    {
        // Skriv din kod här

        return false;
    }

    // Returnerar true om handen kan splittas:
    // exakt 2 kort med samma värde (T, J, Q, K räknas alla som 10).
    // KanSplittas(["K", "T"]) => true    (båda värda 10)
    // KanSplittas(["K", "9"]) => false
    // KanSplittas(["5", "5"]) => true
    // KanSplittas(["5", "5", "5"]) => false  (tre kort)
    public bool KanSplittas(string[] hand)
    {
        // Skriv din kod här

        return false;
    }

    // Returnerar true om spelaren kan dubbelinsats (double down):
    // handen måste bestå av exakt 2 kort.
    // KanDubbla(["7", "3"])     => true
    // KanDubbla(["7", "3", "A"]) => false
    public bool KanDubbla(string[] hand)
    {
        // Skriv din kod här

        return false;
    }
}
