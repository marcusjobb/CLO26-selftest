namespace CSharpRepetition;

// Koden nedan är avsiktligt kryptisk.
// Fokusera på Easy.cs, Medium.cs och Hard.cs istället.
internal static class MarcusPlayground
{
    private static readonly Easy   _e = new();
    private static readonly Medium _m = new();
    private static readonly Hard   _h = new();

    internal static List<(string namn, bool ok)> EasyResultat   { get; } = [];
    internal static List<(string namn, bool ok)> MediumResultat { get; } = [];
    internal static List<(string namn, bool ok)> HardResultat   { get; } = [];

    // -----------------------------------------------------------------------

    internal static double KörEasy()
    {
        EasyResultat.Clear();
        int p = 0, max = 0;

        Σ(EasyResultat, "Create_Select", ref p, ref max,
            _e.Create_Select("Users",  "Name",  "Alice") == "SELECT * FROM Users WHERE Name = 'Alice'"  &&
            _e.Create_Select("Games",  "Genre", "RPG")   == "SELECT * FROM Games WHERE Genre = 'RPG'"  &&
            _e.Create_Select("Orders", "Id",    "42")    == "SELECT * FROM Orders WHERE Id = '42'");

        Σ(EasyResultat, "Create_Select_and", ref p, ref max,
            _e.Create_Select_and("Games", "Genre", "RPG",   "Action")
                == "SELECT * FROM Games WHERE Genre = 'RPG' AND Genre = 'Action'" &&
            _e.Create_Select_and("Users", "Name",  "Alice", "Bob")
                == "SELECT * FROM Users WHERE Name = 'Alice' AND Name = 'Bob'");

        Σ(EasyResultat, "Create_Select_or", ref p, ref max,
            _e.Create_Select_or("Games", "Genre", "RPG",   "Action")
                == "SELECT * FROM Games WHERE Genre = 'RPG' OR Genre = 'Action'" &&
            _e.Create_Select_or("Users", "Name",  "Alice", "Bob")
                == "SELECT * FROM Users WHERE Name = 'Alice' OR Name = 'Bob'");

        Σ(EasyResultat, "Create_Select_not", ref p, ref max,
            _e.Create_Select_not("Users",  "Name",  "Bob")     == "SELECT * FROM Users WHERE Name != 'Bob'"  &&
            _e.Create_Select_not("Games",  "Genre", "Horror")  == "SELECT * FROM Games WHERE Genre != 'Horror'" &&
            _e.Create_Select_not("Orders", "Id",    "0")       == "SELECT * FROM Orders WHERE Id != '0'");

        Σ(EasyResultat, "Create_Insert", ref p, ref max,
            _e.Create_Insert("Users", "Name",  "Alice") == "INSERT INTO Users (Name) VALUES ('Alice')"  &&
            _e.Create_Insert("Games", "Title", "Celeste") == "INSERT INTO Games (Title) VALUES ('Celeste')" &&
            _e.Create_Insert("Tags",  "Label", "RPG")   == "INSERT INTO Tags (Label) VALUES ('RPG')");

        Σ(EasyResultat, "Create_Update", ref p, ref max,
            _e.Create_Update("Games",  "Price", "99")   == "UPDATE Games SET Price = '99'"  &&
            _e.Create_Update("Users",  "Name",  "Bob")  == "UPDATE Users SET Name = 'Bob'"  &&
            _e.Create_Update("Config", "Theme", "dark") == "UPDATE Config SET Theme = 'dark'");

        Σ(EasyResultat, "Create_Delete", ref p, ref max,
            _e.Create_Delete("Users",  "Name",  "Bob")  == "DELETE FROM Users WHERE Name = 'Bob'"  &&
            _e.Create_Delete("Games",  "Genre", "Horror") == "DELETE FROM Games WHERE Genre = 'Horror'" &&
            _e.Create_Delete("Orders", "Id",    "42")   == "DELETE FROM Orders WHERE Id = '42'");

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    // -----------------------------------------------------------------------

    internal static double KörMedium()
    {
        MediumResultat.Clear();
        int p = 0, max = 0;

        Σ(MediumResultat, "WithValue", ref p, ref max,
            WithValueTest("name", "Alice") &&
            WithValueTest("age",  42)      &&
            WithValueTest("active", true));

        Σ(MediumResultat, "WithValues (x2)", ref p, ref max,
            WithValuesTest2("name", "Alice", "age", 30) &&
            WithValuesTest2("title", "Celeste", "price", 89));

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    private static bool WithValueTest(string field, object value)
    {
        var cmd = _m.WithValue(new CommandObject("SELECT 1"), field, value);
        return cmd.Parameters.ContainsKey(field) && cmd.Parameters[field].Equals(value);
    }

    private static bool WithValuesTest2(string f1, object v1, string f2, object v2)
    {
        var cmd = _m.WithValues(new CommandObject("SELECT 1"), f1, v1, f2, v2);
        return cmd.Parameters.ContainsKey(f1) && cmd.Parameters[f1].Equals(v1) &&
               cmd.Parameters.ContainsKey(f2) && cmd.Parameters[f2].Equals(v2);
    }

    // -----------------------------------------------------------------------

    internal static double KörHard()
    {
        HardResultat.Clear();
        int p = 0, max = 0;

        Σ(HardResultat, "WithValues (array)", ref p, ref max,
            WithValuesArrayTest(
                new[] { "name", "age", "active" },
                new object[] { "Alice", 30, true }));

        Σ(HardResultat, "Create_Select_and", ref p, ref max,
            _h.Create_Select_and("Users", new[] { "Name", "Age" }, new[] { "Alice", "30" })
                == "SELECT * FROM Users WHERE Name = 'Alice' AND Age = '30'" &&
            _h.Create_Select_and("Games", new[] { "Genre", "Price" }, new[] { "RPG", "299" })
                == "SELECT * FROM Games WHERE Genre = 'RPG' AND Price = '299'");

        Σ(HardResultat, "Create_Select_or", ref p, ref max,
            _h.Create_Select_or("Games", new[] { "Genre", "Price" }, new[] { "RPG", "299" })
                == "SELECT * FROM Games WHERE Genre = 'RPG' OR Price = '299'" &&
            _h.Create_Select_or("Users", new[] { "Name", "Role" }, new[] { "Alice", "admin" })
                == "SELECT * FROM Users WHERE Name = 'Alice' OR Role = 'admin'");

        Σ(HardResultat, "Create_Insert", ref p, ref max,
            _h.Create_Insert("Users", new[] { "Name", "Age" }, new[] { "Alice", "30" })
                == "INSERT INTO Users (Name, Age) VALUES ('Alice', '30')" &&
            _h.Create_Insert("Games", new[] { "Title", "Price", "Genre" }, new[] { "Celeste", "89", "Platformer" })
                == "INSERT INTO Games (Title, Price, Genre) VALUES ('Celeste', '89', 'Platformer')");

        Σ(HardResultat, "Create_Update", ref p, ref max,
            _h.Create_Update("Users", new[] { "Name", "Age" }, new[] { "Alice", "30" })
                == "UPDATE Users SET Name = 'Alice', Age = '30'" &&
            _h.Create_Update("Games", new[] { "Title", "Price" }, new[] { "Celeste", "89" })
                == "UPDATE Games SET Title = 'Celeste', Price = '89'");

        Σ(HardResultat, "Create_Delete", ref p, ref max,
            _h.Create_Delete("Users", new[] { "Name", "Age" }, new[] { "Alice", "30" })
                == "DELETE FROM Users WHERE Name = 'Alice' AND Age = '30'" &&
            _h.Create_Delete("Games", new[] { "Genre", "Price" }, new[] { "Horror", "0" })
                == "DELETE FROM Games WHERE Genre = 'Horror' AND Price = '0'");

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }

    private static bool WithValuesArrayTest(string[] fields, object[] values)
    {
        var cmd = _h.WithValues(new CommandObject("SELECT 1"), fields, values);
        for (int i = 0; i < fields.Length; i++)
            if (!cmd.Parameters.ContainsKey(fields[i]) || !cmd.Parameters[fields[i]].Equals(values[i]))
                return false;
        return true;
    }

    // -----------------------------------------------------------------------

    private static void Σ(List<(string, bool)> lista, string namn,
                          ref int poäng, ref int max, bool resultat)
    {
        max++;
        if (resultat) poäng++;
        lista.Add((namn, resultat));
    }
}
