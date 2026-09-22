namespace CSharpRepetition;

public class Medium
{
    // Sortera arrayen med bubble sort.
    // Använd inte Array.Sort, List.Sort eller Linq. Loopa och jämför grannpar.
    // Returnera en ny sorterad array (ändra inte originalet).
    public int[] BubbelSortera(int[] tal)
    {
        int[] kopia = (int[])tal.Clone();

        // Skriv din kod här


        return kopia;
    }

    // Ta bort alla dubletter och returnera en ny array med unika värden.
    // Behåll den ordning de först dök upp.
    // TaBortDublikat([1, 2, 2, 3, 1]) => [1, 2, 3]
    public int[] TaBortDublikat(int[] tal)
    {
        // Tips: Bygg upp resultatet i en List<int> och konvertera till array
        List<int> resultat = new();

        // Skriv din kod här


        return resultat.ToArray();
    }

    // Rotera arrayen 'steg' steg åt höger.
    // RoteraTillHöger([1, 2, 3, 4, 5], 2) => [4, 5, 1, 2, 3]
    public int[] RoteraTillHöger(int[] tal, int steg)
    {
        int[] resultat = new int[tal.Length];

        // Skriv din kod här


        return resultat;
    }

    // Returnera en ny lista med alla tal som är STÖRRE ÄN 'gräns'.
    // FiltreraStörreÄn([1, 5, 2, 8, 3], 4) => [5, 8]
    public List<int> FiltreraStörreÄn(int[] tal, int gräns)
    {
        List<int> resultat = new();

        // Skriv din kod här


        return resultat;
    }
}
