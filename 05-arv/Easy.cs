namespace CSharpRepetition;

// Implementera djurhierarkin nedan.
// Djur är abstrakt — Hund, Katt och Papegoja ärver från den.

public abstract class Djur
{
    // Djurets namn, sätts via konstruktorn.
    public string Namn { get; set; }

    public Djur(string namn)
    {
        Namn = namn;
    }

    // Varje djur har ett eget läte — implementeras i subklassen.
    public abstract string LåtSom();

    // Returnerar en hälsningsfras: "Bella säger Vov!"
    // Implementera här i basklassen — använd Namn och LåtSom().
    public string HälsaPå()
    {
        // Skriv din kod här

        return "";
    }
}

public class Hund : Djur
{
    public Hund(string namn) : base(namn) { }

    // Hundar låter "Vov!"
    public override string LåtSom()
    {
        // Skriv din kod här

        return "";
    }
}

public class Katt : Djur
{
    public Katt(string namn) : base(namn) { }

    // Katter låter "Mjau!"
    public override string LåtSom()
    {
        // Skriv din kod här

        return "";
    }
}

public class Papegoja : Djur
{
    // En papegoja härmar — vad den säger bestäms av konstruktorn.
    public Papegoja(string namn, string läte) : base(namn)
    {
        // Skriv din kod här — spara 'läte' så LåtSom kan använda det
    }

    public override string LåtSom()
    {
        // Skriv din kod här

        return "";
    }
}
