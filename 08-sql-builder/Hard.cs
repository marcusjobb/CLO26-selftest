namespace CSharpRepetition;

public class Hard
{
    // Lägg till n parameter-par i ett CommandObject från två arrayer av samma längd.
    // WithValues(cmd, ["name", "age"], ["Alice", 30])
    //   => cmd.Parameters["name"] == "Alice" && cmd.Parameters["age"] == 30
    public CommandObject WithValues(CommandObject cmd, string[] fields, object[] values)
    {
        // Skriv din kod här


        return cmd;
    }

    // Bygg en SELECT-sträng med AND från arrayer — ett villkor per fält.
    // Create_Select_and("Users", ["Name", "Age"], ["Alice", "30"])
    //   => "SELECT * FROM Users WHERE Name = 'Alice' AND Age = '30'"
    public string Create_Select_and(string table, string[] fields, string[] values)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }

    // Bygg en SELECT-sträng med OR från arrayer.
    // Create_Select_or("Games", ["Genre", "Price"], ["RPG", "299"])
    //   => "SELECT * FROM Games WHERE Genre = 'RPG' OR Price = '299'"
    public string Create_Select_or(string table, string[] fields, string[] values)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }

    // Bygg en INSERT-sträng från arrayer.
    // Create_Insert("Users", ["Name", "Age"], ["Alice", "30"])
    //   => "INSERT INTO Users (Name, Age) VALUES ('Alice', '30')"
    public string Create_Insert(string table, string[] fields, string[] values)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }

    // Bygg en UPDATE-sträng utan WHERE från arrayer.
    // Create_Update("Users", ["Name", "Age"], ["Alice", "30"])
    //   => "UPDATE Users SET Name = 'Alice', Age = '30'"
    public string Create_Update(string table, string[] fields, string[] values)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }

    // Bygg en DELETE-sträng med AND-villkor från arrayer.
    // Create_Delete("Users", ["Name", "Age"], ["Alice", "30"])
    //   => "DELETE FROM Users WHERE Name = 'Alice' AND Age = '30'"
    public string Create_Delete(string table, string[] fields, string[] values)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }
}
