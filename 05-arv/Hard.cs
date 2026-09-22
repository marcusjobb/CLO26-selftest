namespace CSharpRepetition;

// Implementera ett fordonshierarki med multi-nivå arv.
// Fordon (abstrakt) → Bil → Hyrbil

public abstract class Fordon
{
    public string Märke  { get; set; }
    public string Modell { get; set; }

    public Fordon(string märke, string modell)
    {
        Märke  = märke;
        Modell = modell;
    }

    // Beräkna kostnaden för att köra 'km' kilometer.
    // Varje subklass beräknar på sitt sätt.
    public abstract double BeräknaKostnad(int km);

    // Returnerar en presentation: "Volvo V70"
    public string Presentation() => $"{Märke} {Modell}";
}

public class Bil : Fordon
{
    // Bensinkostnad: (km / 10.0) × litrePerMil × 18.0 kr/liter
    public Bil(string märke, string modell, double litrePerMil)
        : base(märke, modell)
    {
        // Skriv din kod här
    }

    public override double BeräknaKostnad(int km)
    {
        // Skriv din kod här

        return 0;
    }
}

public class Elfordon : Fordon
{
    // Elkostnad: (km / 10.0) × kwhPerMil × 1.5 kr/kWh
    public Elfordon(string märke, string modell, double kwhPerMil)
        : base(märke, modell)
    {
        // Skriv din kod här
    }

    public override double BeräknaKostnad(int km)
    {
        // Skriv din kod här

        return 0;
    }
}

public class Hyrbil : Bil
{
    // En hyrbil är en Bil PLUS en fast dagskostnad.
    // Total kostnad = Bil.BeräknaKostnad(km) + dagsPris
    public Hyrbil(string märke, string modell, double litrePerMil, double dagsPris)
        : base(märke, modell, litrePerMil)
    {
        // Skriv din kod här
    }

    public override double BeräknaKostnad(int km)
    {
        // Skriv din kod här
        // Tips: anropa base.BeräknaKostnad(km) och lägg till dagsPris

        return 0;
    }
}
