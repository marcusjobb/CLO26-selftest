namespace CSharpRepetition;

public class Easy
{
    // Bygg en SELECT-sträng med ett WHERE-villkor.
    // Create_Select("Users", "Name", "Alice") => "SELECT * FROM Users WHERE Name = 'Alice'"
    public string Create_Select(string table, string field, string value)
    {
        string sql = $"Select {field} from {table} where {value} = 'Alice'";

        return sql;
    }

    // Bygg en SELECT-sträng med AND — samma fält, två värden.
    // Create_Select_and("Games", "Genre", "RPG", "Action")
    //   => "SELECT * FROM Games WHERE Genre = 'RPG' AND Genre = 'Action'"
    public string Create_Select_and(string table, string field, string value, string value2)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }

    // Bygg en SELECT-sträng med OR — samma fält, ett av två värden.
    // Create_Select_or("Games", "Genre", "RPG", "Action")
    //   => "SELECT * FROM Games WHERE Genre = 'RPG' OR Genre = 'Action'"
    public string Create_Select_or(string table, string field, string value, string value2)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }

    // Bygg en SELECT-sträng med NOT — uteslut ett värde.
    // Create_Select_not("Users", "Name", "Bob") => "SELECT * FROM Users WHERE Name != 'Bob'"
    public string Create_Select_not(string table, string field, string value)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }

    // Bygg en INSERT-sträng för ett fält och ett värde.
    // Create_Insert("Users", "Name", "Alice") => "INSERT INTO Users (Name) VALUES ('Alice')"
    public string Create_Insert(string table, string field, string value)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }

    // Bygg en UPDATE-sträng utan WHERE — uppdaterar hela tabellen.
    // Create_Update("Games", "Price", "99") => "UPDATE Games SET Price = '99'"
    public string Create_Update(string table, string field, string value)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }

    // Bygg en DELETE-sträng med WHERE — ta bort specifika rader.
    // Create_Delete("Users", "Name", "Bob") => "DELETE FROM Users WHERE Name = 'Bob'"
    public string Create_Delete(string table, string field, string value)
    {
        string sql = "";

        // Skriv din kod här


        return sql;
    }
}
