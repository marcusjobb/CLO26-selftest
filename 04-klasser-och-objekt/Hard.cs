namespace CSharpRepetition;

// Implementera en Kö-klass (Queue) utan att använda Queue<T> från biblioteket.
// Internt ska du lagra elementen i en List<string>.
// En kö är FIFO: det som lades in först plockas ut först.
public class Kö
{
    // Skriv din kod här (fält)


    // Lägg till ett element sist i kön.
    // Enqueue("A") → kö: ["A"]   Enqueue("B") → kö: ["A","B"]
    public void Enqueue(string element)
    {
        // Skriv din kod här
    }

    // Ta bort och returnera det första elementet i kön (FIFO).
    // Kasta InvalidOperationException om kön är tom.
    // kö(["A","B"]).Dequeue() => "A"  → kö: ["B"]
    public string Dequeue()
    {
        // Skriv din kod här

        return "";
    }

    // Returnera det första elementet utan att ta bort det.
    // Kasta InvalidOperationException om kön är tom.
    // kö(["A","B"]).Peek() => "A"  → kö fortfarande: ["A","B"]
    public string Peek()
    {
        // Skriv din kod här

        return "";
    }

    // Returnera hur många element kön innehåller.
    // kö(["A","B","C"]).Count() => 3
    public int Count()
    {
        // Skriv din kod här

        return 0;
    }

    // Returnera true om kön är tom.
    // tom kö: ÄrTom() => true   efter Enqueue: ÄrTom() => false
    public bool ÄrTom()
    {
        // Skriv din kod här

        return true;
    }
}

// -----------------------------------------------------------------------
// Avancerat — slå samman listor
// -----------------------------------------------------------------------

// En tävlingsdeltagare med id, namn och e-post.
public class Deltagare
{
    public int    Id    { get; set; }
    public string Namn  { get; set; }
    public string Email { get; set; }

    public Deltagare(int id, string namn, string email)
    {
        Id    = id;
        Namn  = namn;
        Email = email;
    }
}

// Poängresultat kopplat till ett deltagar-id.
public class TävlingsPoäng
{
    public int Id    { get; set; }
    public int Poäng { get; set; }

    public TävlingsPoäng(int id, int poäng) { Id = id; Poäng = poäng; }
}

// Det sammanslagna resultatet — namn, e-post och poäng.
public class Resultat
{
    public string Namn  { get; set; }
    public string Email { get; set; }
    public int    Poäng { get; set; }

    public Resultat(string namn, string email, int poäng)
    {
        Namn  = namn;
        Email = email;
        Poäng = poäng;
    }
}

public class TurneringsLogik
{
    // Slå ihop deltagare och poäng på Id-fältet.
    // Skapa ett Resultat-objekt för varje match.
    // Deltagare utan matchande TävlingsPoäng inkluderas INTE.
    // Returnera listan sorterad fallande på Poäng (högst poäng först).
    //
    // Deltagare: [{1,"Marcus","m@t.com"}, {2,"James","j@t.com"}, {3,"Evelyn","e@t.com"}]
    // Poäng:     [{1, 85}, {3, 92}]   ← James har inget resultat
    // Returnerar: [Resultat("Evelyn","e@t.com",92), Resultat("Marcus","m@t.com",85)]
    public List<Resultat> SlåSamman(List<Deltagare> deltagare, List<TävlingsPoäng> poäng)
    {
        List<Resultat> resultat = [];

        // Skriv din kod här
        // Tips 1: Loopa igenom poäng-listan, hitta matchande deltagare på Id
        // Tips 2: Sortera listan på Poäng i fallande ordning


        return resultat;
    }

    // Returnera deltagaren med högst poäng ur resultatlistan.
    // Returnera null om listan är tom.
    // HämtaVinnare([Resultat("Evelyn",92), Resultat("Marcus",85)]) => Resultat("Evelyn",92)
    public Resultat? HämtaVinnare(List<Resultat> resultat)
    {
        // Skriv din kod här

        return null;
    }
}
