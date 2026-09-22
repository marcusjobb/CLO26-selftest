namespace CSharpRepetition;

// Implementera Topplista-klassen nedan.
// Klassen håller koll på spelares namn och poäng.
public class Topplista
{
    // Skriv din kod här (fält, konstruktor om du vill)


    // Lägg till en spelare med poäng.
    // Om spelaren redan finns — uppdatera poängen om den nya är högre.
    // LäggTill("Alice", 100) → Alice har 100p
    // LäggTill("Alice", 50)  → Alice behåller 100p (lägre poäng ignoreras)
    public void LäggTill(string namn, int poäng)
    {
        // Skriv din kod här
    }

    // Returnera namnet på spelaren med högst poäng.
    // Returnera "" om listan är tom.
    // Etta() => "Carol" (om Carol har flest poäng)
    public string Etta()
    {
        // Skriv din kod här

        return "";
    }

    // Returnera poängen för en spelare med givet namn.
    // Returnera -1 om spelaren inte finns.
    // HämtaPoäng("Alice") => 100   HämtaPoäng("Zlatan") => -1
    public int HämtaPoäng(string namn)
    {
        // Skriv din kod här

        return -1;
    }

    // Returnera antal spelare i topplistan.
    // AntalSpelare() => 3 (om Alice, Bob och Carol är tillagda)
    public int AntalSpelare()
    {
        // Skriv din kod här

        return 0;
    }
}

// -----------------------------------------------------------------------
// Klassmanipulering
// -----------------------------------------------------------------------

// En vara i ett sortiment.
// Observera att Valuta är static — den delas av ALLA instanser av Vara.
public class Vara
{
    public string Namn     { get; set; }
    public double Pris     { get; set; }
    public string Kategori { get; set; }

    // Klassvariabel — ändras du den syns ändringen på alla Vara-objekt.
    public static string Valuta { get; set; } = "SEK";

    public Vara(string namn, double pris, string kategori)
    {
        Namn     = namn;
        Pris     = pris;
        Kategori = kategori;
    }
}

// -----------------------------------------------------------------------
// DateTime-övningar
// -----------------------------------------------------------------------

// En person med namn och födelsedag.
public class Person
{
    public string   Namn    { get; set; }
    public DateTime FöddDen { get; set; }

    public Person(string namn, DateTime föddDen)
    {
        Namn    = namn;
        FöddDen = föddDen;
    }
}

public class DatumÖvningar
{
    // Returnera den äldste av två personer (den med det tidigaste födelsedatumet).
    // ÄldstAv(far(1945), son(1975)) => far
    public Person ÄldstAv(Person a, Person b)
    {
        // Skriv din kod här

        return a;
    }

    // Returnera vilken veckodag personen föddes, på svenska.
    // FödelsedagsVeckodag(Person(_, 1970-01-01)) => "Torsdag"
    public string FödelsedagsVeckodag(Person person)
    {
        // Skriv din kod här
        // Tips: person.FöddDen.DayOfWeek ger DayOfWeek.Thursday osv.

        return "";
    }

    // Returnera hur många dagar som passerade från nyårsdagen till
    // personens födelsedag det år personen föddes (0 om född 1 jan).
    // DagarFrånNyår(Person(_, 1990-03-15)) => 73
    public int DagarFrånNyår(Person person)
    {
        // Skriv din kod här
        // Tips: person.FöddDen.DayOfYear ger dagsiffran (1 jan = 1)

        return 0;
    }

    // Returnera true om personen föddes under ett skottår.
    // ÄrSkottår(Person(_, 1988-06-10)) => true
    // ÄrSkottår(Person(_, 1990-06-10)) => false
    public bool ÄrSkottår(Person person)
    {
        // Skriv din kod här
        // Tips: DateTime.IsLeapYear(år) finns inbyggt

        return false;
    }

    // Returnera antal dagar tills personens nästa födelsedag.
    // Om födelsedagen redan passerat i år räknas nästa år (+365 eller +366).
    // Jämför mot DateTime.Now.Date — testet gör samma beräkning för att verifiera.
    public int DagarTillFödelsedag(Person person)
    {
        // Skriv din kod här
        // Tips: skapa ett DateTime för årets födelsedag och jämför med idag

        return 0;
    }

    // Returnera personens astrologiska tecken baserat på födelsedag.
    // AstrologisktTecken(Person(_, 1990-03-25)) => "Väduren"
    // Använd switch-uttryck på (Month, Day).
    public string AstrologisktTecken(Person person)
    {
        // Skriv din kod här
        // Tecknen och deras datum:
        // Väduren 21/3–19/4 | Oxen 20/4–20/5 | Tvillingarna 21/5–20/6
        // Kräftan 21/6–22/7 | Lejonet 23/7–22/8 | Jungfrun 23/8–22/9
        // Vågen 23/9–22/10 | Skorpionen 23/10–21/11 | Skytten 22/11–21/12
        // Stenbocken 22/12–19/1 | Vattumannen 20/1–18/2 | Fiskarna 19/2–20/3

        return "";
    }
}

// -----------------------------------------------------------------------
// Klassmanipulering
// -----------------------------------------------------------------------

public class KlassÖvningar
{
    // Sätt Vara.Valuta till det angivna värdet.
    // Ändringen ska synas på ALLA instanser — det är poängen med static.
    // SättValuta("EUR") → Vara.Valuta == "EUR" för alla Vara-objekt
    public void SättValuta(string valuta)
    {
        // Skriv din kod här
    }

    // Höj priset på alla varor i listan vars Kategori matchar.
    // Ändra Pris direkt i varje matchande Vara-objekt och returnera listan.
    // HöjPrisIKategori(varor, "Dryck", 10.0) => varor med Kategori=="Dryck" får Pris += 10.0
    public List<Vara> HöjPrisIKategori(List<Vara> varor, string kategori, double ökning)
    {
        // Skriv din kod här


        return varor;
    }

    // Ta bort duplikat ur listan. Två varor är lika om Namn, Pris OCH Kategori är identiska.
    // Behåll den första förekomsten, ta bort resten.
    // [Kaffe 50, Kaffe 50, Te 30] => [Kaffe 50, Te 30]
    public List<Vara> TaBortDuplikat(List<Vara> varor)
    {
        List<Vara> unika = [];

        // Skriv din kod här


        return unika;
    }

    // Klona en vara — returnera en ny Vara med exakt samma Namn, Pris och Kategori.
    // Det ska vara ett nytt objekt, inte samma referens.
    // KlonaVara(vara) => new Vara med samma värden, !ReferenceEquals(original, klon)
    public Vara KlonaVara(Vara vara)
    {
        // Skriv din kod här

        return vara;
    }
}
