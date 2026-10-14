namespace CSharpRepetition;

// Koden nedan är avsiktligt kryptisk.
// Fokusera på Medium.cs och Hard.cs istället.
public class CommandObject
{
    public string Sql { get; set; } = "";
    public Dictionary<string, object> Parameters { get; } = new();

    public CommandObject() { }
    public CommandObject(string sql) { Sql = sql; }
}
