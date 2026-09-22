namespace CSharpRepetition;

// Implementera BankKonto-klassen nedan.
// Alla metoder och konstruktorn ska fungera enligt beskrivningarna.
public class BankKonto
{
    // Klassen ska hålla koll på saldot internt.
    // Skriv din kod här (fält, konstruktor, metoder)


    // Skapa ett konto med ett startsaldo.
    // new BankKonto(500) → konto med saldo 500
    public BankKonto(int startSaldo)
    {
        // Skriv din kod här
    }

    // Sätt in ett belopp på kontot. Beloppet måste vara positivt.
    // konto.SättIn(300) → saldo ökar med 300
    public void SättIn(int belopp)
    {
        // Skriv din kod här
    }

    // Ta ut ett belopp. Returnera true om uttaget lyckades.
    // Misslyckas om beloppet är negativt eller om saldot inte räcker.
    // konto(500).TaUt(200) => true → saldo = 300
    // konto(500).TaUt(999) => false → saldo oförändrat
    public bool TaUt(int belopp)
    {
        // Skriv din kod här

        return false;
    }

    // Returnera nuvarande saldo.
    // konto(500).SättIn(100).HämtaSaldo() => 600
    public int HämtaSaldo()
    {
        // Skriv din kod här

        return 0;
    }
}

// -----------------------------------------------------------------------
// Records
// -----------------------------------------------------------------------

// En kontakt med förnamn, efternamn och e-postadress.
// Records är oföränderliga — du kan inte ändra fält direkt.
// Använd `with`-syntax för att skapa en ny record med ändrade värden:
//   var kopia = original with { Email = "ny@adress.se" };
public record Kontakt(string Förnamn, string Efternamn, string Email);

public class RecordÖvningar
{
    // Skapa och returnera en ny Kontakt med de givna värdena.
    // SkapaKontakt("Marcus", "Medina", "m@test.com") => Kontakt { Förnamn="Marcus", ... }
    public Kontakt SkapaKontakt(string förnamn, string efternamn, string email)
    {
        // Skriv din kod här

        return new Kontakt("", "", "");
    }

    // Returnera en ny Kontakt med den uppdaterade e-postadressen.
    // Den ursprungliga kontakten ska inte ändras.
    // ÄndraEmail(kontakt, "ny@test.com") => new Kontakt with Email = "ny@test.com"
    public Kontakt ÄndraEmail(Kontakt kontakt, string nyEmail)
    {
        // Skriv din kod här

        return kontakt;
    }

    // Returnera en identisk kopia av kontakten.
    // KlonaKontakt(kontakt) => Kontakt med exakt samma värden
    public Kontakt KlonaKontakt(Kontakt kontakt)
    {
        // Skriv din kod här

        return kontakt;
    }

    // Tolka listan av "Förnamn|Efternamn"-strängar och returnera Kontakt-poster.
    // Email sätts till "" för alla.
    // ParseNamnlista(["Marcus|Medina", "James|Bond"]) => [Kontakt("Marcus","Medina",""), ...]
    public List<Kontakt> ParseNamnlista(List<string> namnlista)
    {
        List<Kontakt> kontakter = [];

        // Skriv din kod här


        return kontakter;
    }
}
