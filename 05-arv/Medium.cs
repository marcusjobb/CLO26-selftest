namespace CSharpRepetition;

// Implementera geometriska figurer med arv.
// Figur är abstrakt — Cirkel, Rektangel och Triangel ärver från den.

public abstract class Figur
{
    // Varje figur har ett namn, t.ex. "Cirkel".
    public abstract string Namn { get; }

    // Beräkna figurens area — implementeras i subklassen.
    public abstract double BeräknaArea();

    // Returnera en beskrivning: "Cirkel med area 78,54"
    // Implementera här i basklassen.
    public string Beskriv()
    {
        // Skriv din kod här
        // Tips: Math.Round(BeräknaArea(), 2) för avrundning

        return "";
    }
}

public class Cirkel : Figur
{
    public override string Namn => "Cirkel";

    // Konstruktorn tar radien.
    public Cirkel(double radie)
    {
        // Skriv din kod här
    }

    // Area = π × r²
    public override double BeräknaArea()
    {
        // Skriv din kod här
        // Tips: Math.PI

        return 0;
    }
}

public class Rektangel : Figur
{
    public override string Namn => "Rektangel";

    // Konstruktorn tar bredd och höjd.
    public Rektangel(double bredd, double höjd)
    {
        // Skriv din kod här
    }

    // Area = bredd × höjd
    public override double BeräknaArea()
    {
        // Skriv din kod här

        return 0;
    }
}

public class Triangel : Figur
{
    public override string Namn => "Triangel";

    // Konstruktorn tar bas och höjd.
    public Triangel(double bas, double höjd)
    {
        // Skriv din kod här
    }

    // Area = (bas × höjd) / 2
    public override double BeräknaArea()
    {
        // Skriv din kod här

        return 0;
    }
}
