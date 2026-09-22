namespace CSharpRepetition;

// Implementera en Kö-klass (Queue) utan att använda Queue<T> från biblioteket.
// Internt ska du lagra elementen i en List<string>.
// En kö är FIFO: det som lades in först plockas ut först.
public class Kö
{
    // Skriv din kod här (fält)


    // Lägg till ett element sist i kön.
    public void Enqueue(string element)
    {
        // Skriv din kod här
    }

    // Ta bort och returnera det första elementet i kön.
    // Kasta InvalidOperationException om kön är tom.
    public string Dequeue()
    {
        // Skriv din kod här

        return "";
    }

    // Returnera det första elementet utan att ta bort det.
    // Kasta InvalidOperationException om kön är tom.
    public string Peek()
    {
        // Skriv din kod här

        return "";
    }

    // Returnera hur många element kön innehåller.
    public int Count()
    {
        // Skriv din kod här

        return 0;
    }

    // Returnera true om kön är tom.
    public bool ÄrTom()
    {
        // Skriv din kod här

        return true;
    }
}
