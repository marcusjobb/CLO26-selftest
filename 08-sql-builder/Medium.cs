namespace CSharpRepetition;

public class Medium
{
    // Lägg till ett parameter-par i ett CommandObject.
    // Parametern sparas utan @-prefix som nyckel.
    // WithValue(cmd, "name", "Alice") => cmd.Parameters["name"] == "Alice"
    public CommandObject WithValue(CommandObject cmd, string field, object value)
    {
        // Skriv din kod här


        return cmd;
    }

    // Lägg till två parameter-par i ett CommandObject.
    // WithValues(cmd, "name", "Alice", "age", 30)
    //   => cmd.Parameters["name"] == "Alice" && cmd.Parameters["age"] == 30
    public CommandObject WithValues(CommandObject cmd,
        string field, object value,
        string field2, object value2)
    {
        // Skriv din kod här


        return cmd;
    }
}
