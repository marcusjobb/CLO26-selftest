namespace CSharpRepetition;

public class Medium
{
    // Summera alla siffror (0–9) i en sträng. Övriga tecken ignoreras.
    // SummeraText("a1b2c3") => 6
    // SummeraText("marcus1970@mail4ever.com") => 21
    public int SummeraText(string text)
    {
        int summa = 0;

        // Skriv din kod här


        return summa;
    }

    // Fläta ihop två strängar varannan bokstav.
    // Om en sträng är kortare fortsätter den längre direkt.
    // FlätaSamman("ABC", "XY") => "AXBYC"
    public string FlätaSamman(string a, string b)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Blanda ihop två strängar varannan bokstav (börja med a[0], sedan b[0], a[1], b[1] ...).
    // VarannanBokstav("Nelson", "Mandela") => "NMealnsdoenla"
    public string VarannanBokstav(string a, string b)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Vänd ordningen på orden i en mening (inte bokstäverna i varje ord).
    // VändOrdning("hej du där") => "där du hej"
    public string VändOrdning(string mening)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Sortera bokstäverna i ett ord (ta bort mellanslag, sedan sortera).
    // SorteraBokstäver("marcus") => "acmrsu"
    // SorteraBokstäver("min katt") => "aikmntt"
    public string SorteraBokstäver(string text)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Extrahera en del av texten med start och längd.
    // Extrahera("min katt sover", 4, 4) => "katt"
    public string Extrahera(string text, int start, int längd)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Växla versaler i alternerande mönster: varannan stor, varannan liten (börja med stor).
    // VäxlaVersaler("katt") => "KaTt"
    // VäxlaVersaler("hund") => "HuNd"
    public string VäxlaVersaler(string text)
    {
        string resultat = "";

        // Skriv din kod här


        return resultat;
    }

    // Dela texten i bitar om x tecken och returnera som lista.
    // Den sista biten kan vara kortare om texten inte går jämnt upp.
    // DelaIBitar("Min katt är svart", 4) => ["Min ", "katt", " är ", "svar", "t"]
    public List<string> DelaIBitar(string text, int bitlängd)
    {
        List<string> bitar = [];

        // Skriv din kod här


        return bitar;
    }

    // Returnera tecknet som följer direkt efter det givna tecknet (första förekomsten).
    // Returnera null om tecknet inte finns eller är sist i strängen.
    // NästaBokstav("Taylor Swift", 'S') => 'w'
    // NästaBokstav("hund", 'd') => null
    public char? NästaBokstav(string text, char tecken)
    {
        char? nästa = null;

        // Skriv din kod här


        return nästa;
    }

    // Returnera tecknet som föregår det givna tecknet (första förekomsten).
    // Returnera null om tecknet inte finns eller är det första i strängen.
    // FöregångandeBokstav("Taylor Swift", 'S') => ' '
    // FöregångandeBokstav("hund", 'h') => null
    public char? FöregångandeBokstav(string text, char tecken)
    {
        char? föregående = null;

        // Skriv din kod här


        return föregående;
    }
}
