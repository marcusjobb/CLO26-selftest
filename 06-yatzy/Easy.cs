namespace CSharpRepetition;

public class Easy
{
    // Returnerar summan av alla fem tärningar.
    // Chans([1, 2, 3, 4, 5]) => 15
    // Chans([6, 6, 6, 6, 6]) => 30
    public int Chans(int[] tärningar)
    {
        // Skriv din kod här

        return 0;
    }

    // Returnerar summan av alla tärningar vars värde matchar parametern.
    // Används för överdelen (Ettor, Tvåor ... Sexor).
    // ÖverDel([1, 1, 2, 3, 1], 1) => 3
    // ÖverDel([6, 6, 6, 5, 4], 6) => 18
    // ÖverDel([1, 2, 3, 4, 5], 6) => 0
    public int ÖverDel(int[] tärningar, int värde)
    {
        // Skriv din kod här

        return 0;
    }

    // Returnerar true om det finns minst ett par (två tärningar med samma värde).
    // HarPar([1, 1, 3, 4, 5]) => true
    // HarPar([1, 2, 3, 4, 5]) => false
    public bool HarPar(int[] tärningar)
    {
        // Skriv din kod här
        // Tips: räkna hur många gånger varje värde förekommer

        return false;
    }

    // Returnerar true om det finns minst tre tärningar med samma värde.
    // HarTrio([2, 2, 2, 4, 5]) => true
    // HarTrio([2, 2, 3, 4, 5]) => false
    public bool HarTrio(int[] tärningar)
    {
        // Skriv din kod här

        return false;
    }

    // Returnerar true om det finns minst fyra tärningar med samma värde.
    // HarFyrkind([6, 6, 6, 6, 1]) => true
    // HarFyrkind([6, 6, 6, 1, 1]) => false
    public bool HarFyrkind(int[] tärningar)
    {
        // Skriv din kod här

        return false;
    }

    // Returnerar true om alla fem tärningar är likadana.
    // HarYatzy([4, 4, 4, 4, 4]) => true
    // HarYatzy([4, 4, 4, 4, 5]) => false
    public bool HarYatzy(int[] tärningar)
    {
        // Skriv din kod här

        return false;
    }
}
