namespace CSharpRepetition;

public class Hard
{
    // Binär sökning: returnera index för 'mål' i den sorterade arrayen.
    // Returnera -1 om värdet inte finns. Loopa — använd inte Linq.
    // BinärSökning([1, 3, 5, 7, 9], 7) => 3
    // BinärSökning([1, 3, 5, 7, 9], 4) => -1
    public int BinärSökning(int[] sorterat, int mål)
    {
        int resultat = -1;

        // Skriv din kod här
        // Tips: håll koll på 'vänster' och 'höger' index, jämför mittpunkten


        return resultat;
    }

    // Arrayen innehåller alla heltal från 1 till n, men ett saknas.
    // Hitta och returnera det saknade talet.
    // HittaMissat([1, 2, 4, 5], 5) => 3
    public int HittaMissat(int[] tal, int n)
    {
        int missat = 0;

        // Skriv din kod här
        // Tips: summan av 1..n är n*(n+1)/2


        return missat;
    }

    // Slå ihop två redan sorterade arrayer till en sorterad array.
    // Använd inte sort-metoder — dra nytta av att båda är sorterade redan.
    // MergeaSorterade([1, 3, 5], [2, 4, 6]) => [1, 2, 3, 4, 5, 6]
    public int[] MergeaSorterade(int[] a, int[] b)
    {
        int[] resultat = new int[a.Length + b.Length];

        // Skriv din kod här


        return resultat;
    }

    // Returnera en ny lista utan de tal som är delbara med 'divisor'.
    // ForaBort([1, 2, 3, 4, 5, 6], 3) => [1, 2, 4, 5]
    public List<int> ForaBort(List<int> lista, int divisor)
    {
        List<int> resultat = [];

        // Skriv din kod här


        return resultat;
    }

    // Sök igenom en Dictionary<författare, böcker[]> och returnera författaren
    // till den bok som matchar titeln. Returnera "" om boken inte finns.
    // HittaFörfattare({"Tolkien": ["Ringarnas Herre", "Hobbiten"]}, "Hobbiten") => "Tolkien"
    public string HittaFörfattare(Dictionary<string, string[]> böcker, string titel)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Skapa en ny array med angiven storlek och kopiera in originalets innehåll.
    // Om nyStorlek är större fylls resten med 0. Om mindre trunkeras.
    // ÄndraStorlek([1, 2, 3], 5) => [1, 2, 3, 0, 0]
    // ÄndraStorlek([1, 2, 3, 4, 5], 3) => [1, 2, 3]
    public int[] ÄndraStorlek(int[] array, int nyStorlek)
    {
        int[] resultat = new int[nyStorlek];

        // Skriv din kod här


        return resultat;
    }
}
