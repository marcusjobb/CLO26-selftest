namespace CSharpRepetition;

public class Hard
{
    // Returnerar 15 om tärningarna innehåller alla värden 1, 2, 3, 4 och 5.
    // Annars 0. Ordning spelar ingen roll.
    // LitenStege([1, 2, 3, 4, 5]) => 15
    // LitenStege([1, 2, 3, 4, 6]) => 0
    // LitenStege([1, 1, 3, 4, 5]) => 0   (saknar tvåan)
    public int LitenStege(int[] tärningar)
    {
        // Skriv din kod här
        // Tips: kontrollera att varje värde 1–5 finns i arrayen

        return 0;
    }

    // Returnerar 20 om tärningarna innehåller alla värden 2, 3, 4, 5 och 6.
    // Annars 0.
    // StorStege([2, 3, 4, 5, 6]) => 20
    // StorStege([1, 2, 3, 4, 5]) => 0
    public int StorStege(int[] tärningar)
    {
        // Skriv din kod här

        return 0;
    }

    // Returnerar vilket tärningsvärde (1–6) som ger mest poäng i överdelen.
    // Vid lika antal poäng väljs det högre värdet.
    // BästaÖverDel([6, 6, 5, 5, 6]) => 6   (sexor ger 18, femmor ger 10)
    // BästaÖverDel([3, 3, 3, 3, 3]) => 3   (treor ger 15)
    // BästaÖverDel([1, 1, 1, 1, 1]) => 1
    public int BästaÖverDel(int[] tärningar)
    {
        // Skriv din kod här
        // Tips: räkna summan för varje möjligt värde 1–6 och returnera det bästa

        return 0;
    }

    // Räknar ut totalpoängen från ett ifyllt poängkort.
    // Summan av alla värden i scorecard.
    // Om summan av överdelen (nycklarna "1"–"6") är >= 63 läggs 35 bonuspoäng till.
    // Nycklar som inte finns i scorecard bidrar med 0.
    //
    // Exempel: {"1":3,"2":6,"3":9,"4":12,"5":15,"6":18,"Yatzy":50}
    //   Överdel: 3+6+9+12+15+18 = 63 → bonus!
    //   Total: 63 + 50 + 35 = 148
    //
    // Exempel: {"1":1,"2":4,"3":6,"4":8,"5":10,"6":12,"Kåk":20}
    //   Överdel: 41 → ingen bonus
    //   Total: 41 + 20 = 61
    public int TotalPoäng(Dictionary<string, int> scorecard)
    {
        // Skriv din kod här
        // Tips: summera alla värden, kolla sedan om nycklarna "1"–"6" summerar till >= 63

        return 0;
    }
}
