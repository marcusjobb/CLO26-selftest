namespace CSharpRepetition;

public class Medium
{
    // Sortera arrayen med bubble sort. Använd inte Array.Sort, List.Sort eller Linq.
    // Returnera en ny sorterad array — ändra inte originalet.
    // BubbelSortera([5, 2, 8, 1]) => [1, 2, 5, 8]
    public int[] BubbelSortera(int[] tal)
    {
        int[] kopia = (int[])tal.Clone();

        // Skriv din kod här


        return kopia;
    }

    // Ta bort alla duplikat och returnera en ny array med unika värden.
    // Behåll den ordning de först dök upp.
    // TaBortDuplikat([1, 2, 2, 3, 1]) => [1, 2, 3]
    public int[] TaBortDuplikat(int[] tal)
    {
        // Tips: bygg upp resultatet i en List<int> och konvertera till array
        List<int> resultat = [];

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
        List<int> resultat = [];

        // Skriv din kod här


        return resultat;
    }

    // Räkna hur många gånger varje sträng förekommer i listan.
    // Returnera som Dictionary där nyckeln är ordet och värdet är antalet.
    // ListaTillDictionary(["hund", "katt", "hund"]) => {"hund": 2, "katt": 1}
    public Dictionary<string, int> ListaTillDictionary(List<string> ord)
    {
        Dictionary<string, int> frekvens = [];

        // Skriv din kod här


        return frekvens;
    }

    // Returnera de namn ur listan som innehåller den givna bokstaven (skiftlägesokänsligt).
    // FiltreraNamnMedBokstav(["Marcus", "James", "Evelyn"], 's') => ["Marcus", "James"]
    public List<string> FiltreraNamnMedBokstav(List<string> namn, char bokstav)
    {
        List<string> resultat = [];

        // Skriv din kod här


        return resultat;
    }

    // Dela arrayen i mitten och returnera de två halvorna som en tuple.
    // Om arrayen har ojämnt antal får andra halvan det extra elementet.
    // DelaIMitten([1, 2, 3, 4, 5, 6]) => ([1, 2, 3], [4, 5, 6])
    // DelaIMitten([1, 2, 3, 4, 5])    => ([1, 2], [3, 4, 5])
    public (int[] förstaHälft, int[] andraHälft) DelaIMitten(int[] tal)
    {
        // Skriv din kod här


        return ([], []);
    }

    // Konvertera en kö till en lista. Ordningen bevaras (första in = första ut).
    // QueueTillLista(Queue["a", "b", "c"]) => ["a", "b", "c"]
    public List<string> QueueTillLista(Queue<string> kö)
    {
        List<string> resultat = [];

        // Skriv din kod här


        return resultat;
    }

    // Konvertera en lista till en kö. Första elementet i listan hamnar först i kön.
    // ListaTillQueue(["a", "b", "c"]) => Queue["a", "b", "c"]
    public Queue<string> ListaTillQueue(List<string> lista)
    {
        Queue<string> kö = new();

        // Skriv din kod här


        return kö;
    }

    // Konvertera en stack till en lista. Toppelementet hamnar först i listan.
    // StackTillLista(Stack med "c" överst, "b" i mitten, "a" underst) => ["c", "b", "a"]
    public List<string> StackTillLista(Stack<string> stack)
    {
        List<string> resultat = [];

        // Skriv din kod här


        return resultat;
    }

    // Konvertera en lista till en stack. Sista elementet i listan hamnar överst.
    // ListaTillStack(["a", "b", "c"]) => Stack med "c" överst
    public Stack<string> ListaTillStack(List<string> lista)
    {
        Stack<string> stack = new();

        // Skriv din kod här


        return stack;
    }
}
