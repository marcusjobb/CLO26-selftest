namespace CSharpRepetition;

public class Hard
{
    // Caesar-chiffer: förskjut varje bokstav med 'nyckel' steg i alfabetet.
    // Bevara stora/små bokstäver. Icke-bokstäver ändras inte.
    // CaesarChiffer("Abc", 3) => "Def"
    // CaesarChiffer("Xyz", 3) => "Abc"  (wrapping!)
    public string CaesarChiffer(string text, int nyckel)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Sortera arrayen med bubble sort. Inte Linq.Sort eller Array.Sort — det är fusk.
    // Returnera en ny sorterad array (ändra inte originalet).
    public int[] BubbelSortera(int[] tal)
    {
        int[] kopia = (int[])tal.Clone();

        // Skriv din kod här


        return kopia;
    }

    // Kontrollera om de två orden är anagram av varandra.
    // Anagram = samma bokstäver i annan ordning. Ignorera mellanslag och skiftläge.
    // ÄrAnagram("lyssna", "nyassl") => true
    public bool ÄrAnagram(string ord1, string ord2)
    {
        bool svar = false;

        // Skriv din kod här


        return svar;
    }

    // Returnera det n:te Fibonacci-talet (0-indexerat).
    // F(0)=0, F(1)=1, F(2)=1, F(3)=2, F(4)=3, F(5)=5 ...
    // Implementera med loop — inte rekursion.
    public int Fibonacci(int n)
    {
        int resultat = 0;

        // Skriv din kod här


        return resultat;
    }

    // Returnera sant om n är ett primtal. 0 och 1 är inte primtal.
    // ÄrPrimtal(7) => true    ÄrPrimtal(9) => false
    public bool ÄrPrimtal(int n)
    {
        bool svar = false;

        // Skriv din kod här


        return svar;
    }

    // Beräkna bas upphöjt till exp utan att använda Math.Pow.
    // Potens(2, 10) => 1024    Potens(3, 0) => 1
    public long Potens(int bas, int exp)
    {
        long resultat = 1;

        // Skriv din kod här


        return resultat;
    }

    // Run-length encoding: komprimera upprepade tecken.
    // RunLängd("aabbb") => "a2b3"    RunLängd("abc") => "a1b1c1"
    public string RunLängd(string text)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }
}
