namespace CSharpRepetition;

public class Easy
{
    // Returnerar kortets grundvärde.
    // "2"–"9" => siffrans värde, "T" / "J" / "Q" / "K" => 10, "A" => 1
    // (Ess räknas som 1 här — BästaHandSumma i Medium hanterar 11-alternativet)
    // KortVärde("7") => 7
    // KortVärde("K") => 10
    // KortVärde("A") => 1
    public int KortVärde(string kort)
    {
        // Skriv din kod här

        return 0;
    }

    // Returnerar summan av handen med Ess = 1.
    // HandSumma(["T", "K"])   => 20
    // HandSumma(["A", "5"])   => 6
    // HandSumma(["3", "4", "7"]) => 14
    public int HandSumma(string[] kort)
    {
        // Skriv din kod här

        return 0;
    }

    // Returnerar true om handsumman är över 21 (bust).
    // ÄrBust(22) => true
    // ÄrBust(21) => false
    public bool ÄrBust(int handVärde)
    {
        // Skriv din kod här

        return false;
    }

    // Returnerar true om handen är Blackjack:
    // exakt 2 kort, varav ett är Ess och ett har värde 10.
    // ÄrBlackjack(["A", "K"])     => true
    // ÄrBlackjack(["A", "T"])     => true
    // ÄrBlackjack(["T", "K"])     => false   (inget Ess)
    // ÄrBlackjack(["A", "5", "5"]) => false  (tre kort)
    public bool ÄrBlackjack(string[] kort)
    {
        // Skriv din kod här

        return false;
    }
}
