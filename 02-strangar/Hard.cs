namespace CSharpRepetition;

public class Hard
{
    // Caesar-chiffer: förskjut varje bokstav med 'nyckel' steg i alfabetet.
    // Bevara stora/små bokstäver. Icke-bokstäver ändras inte. Wrapping hanteras.
    // CaesarChiffer("Abc", 3) => "Def"
    // CaesarChiffer("Xyz", 3) => "Abc"
    public string CaesarChiffer(string text, int nyckel)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Kontrollera om de två orden är anagram (samma bokstäver, annan ordning).
    // Ignorera mellanslag och skiftläge.
    // ÄrAnagram("lyssna", "nyassl") => true
    // ÄrAnagram("Astronomer", "Moon starer") => true
    public bool ÄrAnagram(string ord1, string ord2)
    {
        bool svar = false;

        // Skriv din kod här


        return svar;
    }

    // Ta de första 'antal' värdena ur params-listan och sätt ihop dem till en sträng.
    // FörstaVärden(3, "A", "B", "C", "D", "E") => "ABC"
    // FörstaVärden(9, "R","A","M","M","S","T","E","I","N","Du Hast") => "RAMMSTEIN"
    public string FörstaVärden(int antal, params string[] värden)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Run-length encoding: komprimera upprepade tecken.
    // KomprimeraText("aaabbc") => "a3b2c1"
    // KomprimeraText("abcd") => "a1b1c1d1"
    public string KomprimeraText(string text)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }
}
