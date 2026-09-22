namespace CSharpRepetition;

public class Easy
{
    // Summera alla tal i arrayen.
    // Summera([1, 2, 3, 4]) => 10
    public int Summera(int[] tal)
    {
        int summa = 0;

        // Skriv din kod här


        return summa;
    }

    // Returnera det största värdet i arrayen. Använd inte Linq eller Array.Max.
    // HittaMax([3, 1, 4, 1, 5, 9]) => 9
    public int HittaMax(int[] tal)
    {
        int max = tal[0];

        // Skriv din kod här


        return max;
    }

    // Vänd på arrayen och returnera en ny baklänges. Använd inte Array.Reverse.
    // VändArray([1, 2, 3]) => [3, 2, 1]
    public int[] VändArray(int[] tal)
    {
        int[] resultat = new int[tal.Length];

        // Skriv din kod här


        return resultat;
    }

    // Räkna hur många gånger 'sökvärde' förekommer i arrayen.
    // RäknaFörekomster([1, 2, 2, 3, 2], 2) => 3
    public int RäknaFörekomster(int[] tal, int sökvärde)
    {
        int antal = 0;

        // Skriv din kod här


        return antal;
    }

    // Returnera summan av alla JÄMNA tal i arrayen.
    // SummeraJämna([1, 2, 3, 4, 5, 6]) => 12
    public int SummeraJämna(int[] tal)
    {
        int summa = 0;

        // Skriv din kod här


        return summa;
    }

    // Dela texten i delar på ett givet tecken och returnera som array.
    // Använd inte string.Split — loopa igenom strängen.
    // SplittaPåToken("marcus|pelle|kalle", '|') => ["marcus", "pelle", "kalle"]
    public string[] SplittaPåToken(string text, char separator)
    {
        // Tips: bygg upp ord i en List<string> och konvertera till array
        List<string> delar = [];

        // Skriv din kod här


        return delar.ToArray();
    }

    // Konvertera en Dictionary till en lista med strängar på formen "nyckel: värde".
    // DictionaryTillLista({"Marcus": 85, "James": 72}) => ["Marcus: 85", "James: 72"]
    public List<string> DictionaryTillLista(Dictionary<string, int> dict)
    {
        List<string> resultat = [];

        // Skriv din kod här


        return resultat;
    }
}
