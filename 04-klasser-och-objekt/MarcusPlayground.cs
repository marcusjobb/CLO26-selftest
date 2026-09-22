namespace CSharpRepetition;

// Koden nedan är avsiktligt kryptisk.
// Fokusera på Easy.cs, Medium.cs och Hard.cs istället.
internal static class MarcusPlayground
{
    private static readonly RecordÖvningar  _r  = new();
    private static readonly KlassÖvningar   _k  = new();
    private static readonly TurneringsLogik _t  = new();
    private static readonly DatumÖvningar   _du = new();

    internal static List<(string namn, bool ok)> EasyResultat   { get; } = [];
    internal static List<(string namn, bool ok)> MediumResultat { get; } = [];
    internal static List<(string namn, bool ok)> HardResultat   { get; } = [];


    internal static double KörEasy()
    {
        EasyResultat.Clear();
        int p = 0, max = 0;

        {
            var κ = new BankKonto(0x3E8);
            Σ(EasyResultat, "BankKonto — startsaldo", ref p, ref max,
                κ.HämtaSaldo() == 0x3E8);
        }

        {
            var κ = new BankKonto(0x64);
            κ.SättIn(0x32);
            κ.SättIn(0b10);
            Σ(EasyResultat, "BankKonto — SättIn", ref p, ref max,
                κ.HämtaSaldo() == 0x64 + 0x32 + 0b10);
        }

        {
            var κ = new BankKonto(1 << 9);
            bool ok = κ.TaUt(1 << 7);
            Σ(EasyResultat, "BankKonto — TaUt lyckat", ref p, ref max,
                ok && κ.HämtaSaldo() == (1 << 9) - (1 << 7));
        }

        {
            var κ = new BankKonto(0x32);
            bool ok = κ.TaUt(0x3E8);
            Σ(EasyResultat, "BankKonto — TaUt nekas", ref p, ref max,
                !ok && κ.HämtaSaldo() == 0x32);
        }

        {
            var k = _r.SkapaKontakt("Marcus", "Medina", "m@t.com");
            Σ(EasyResultat, "SkapaKontakt", ref p, ref max,
                k.Förnamn == "Marcus" && k.Efternamn == "Medina" && k.Email == "m@t.com");
        }

        {
            var k1 = new Kontakt("Pelle", "Svensson", "pelle@old.com");
            var k2 = _r.ÄndraEmail(k1, "pelle@ny.com");
            Σ(EasyResultat, "ÄndraEmail", ref p, ref max,
                k2.Email == "pelle@ny.com"  &&
                k1.Email == "pelle@old.com" &&
                !ReferenceEquals(k1, k2));
        }

        {
            var orig = new Kontakt("Anna", "Karlsson", "anna@t.com");
            var klon = _r.KlonaKontakt(orig);
            Σ(EasyResultat, "KlonaKontakt", ref p, ref max,
                klon.Förnamn    == orig.Förnamn    &&
                klon.Efternamn  == orig.Efternamn  &&
                klon.Email      == orig.Email);
        }

        {
            var lista = _r.ParseNamnlista(["Marcus|Medina", "James|Bond"]);
            Σ(EasyResultat, "ParseNamnlista", ref p, ref max,
                lista.Count         == 0b10       &&
                lista[0].Förnamn    == "Marcus"   &&
                lista[0].Efternamn  == "Medina"   &&
                lista[1].Efternamn  == "Bond"     &&
                lista[0].Email      == "");
        }

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }


    internal static double KörMedium()
    {
        MediumResultat.Clear();
        int p = 0, max = 0;

        {
            var τ = new Topplista();
            τ.LäggTill("Alice", 0x3E8);
            τ.LäggTill("Bob", 0x1F4);
            τ.LäggTill("Carol", 0x5DC);
            Σ(MediumResultat, "Topplista — LäggTill", ref p, ref max,
                τ.AntalSpelare() == 0b11);
        }

        {
            var τ = new Topplista();
            τ.LäggTill("Alice", 0x3E8);
            τ.LäggTill("Bob", 0x1F4);
            τ.LäggTill("Carol", 0x5DC);
            Σ(MediumResultat, "Topplista — Etta", ref p, ref max,
                τ.Etta() == "Carol");
        }

        {
            var τ = new Topplista();
            τ.LäggTill("Zlatan", 1 << 10);
            Σ(MediumResultat, "Topplista — HämtaPoäng", ref p, ref max,
                τ.HämtaPoäng("Zlatan") == 1 << 10 &&
                τ.HämtaPoäng("Marcus") == -1);
        }

        {
            var τ = new Topplista();
            τ.LäggTill("Ali", 0x64);
            τ.LäggTill("Ali", 0x3E8);
            τ.LäggTill("Ali", 0x32);
            Σ(MediumResultat, "Topplista — uppdatera poäng", ref p, ref max,
                τ.HämtaPoäng("Ali") == 0x3E8 &&
                τ.AntalSpelare()    == 1);
        }

        {
            _k.SättValuta("EUR");
            bool ok = Vara.Valuta == "EUR";
            Vara.Valuta = "SEK";
            Σ(MediumResultat, "SättValuta", ref p, ref max, ok);
        }

        {
            var varor = new List<Vara>
            {
                new("Kaffe", 0x32, "Dryck"),
                new("Te",    0x1E, "Dryck"),
                new("Smör",  0x28, "Mejeri"),
            };
            _k.HöjPrisIKategori(varor, "Dryck", 0xA);
            Σ(MediumResultat, "HöjPrisIKategori", ref p, ref max,
                Math.Abs(varor[0].Pris - 0x3C) < 0.01 &&
                Math.Abs(varor[1].Pris - 0x28) < 0.01 &&
                Math.Abs(varor[2].Pris - 0x28) < 0.01);
        }

        {
            var varor = new List<Vara>
            {
                new("Kaffe", 0x32, "Dryck"),
                new("Kaffe", 0x32, "Dryck"),
                new("Te",    0x1E, "Dryck"),
            };
            var unika = _k.TaBortDuplikat(varor);
            Σ(MediumResultat, "TaBortDuplikat", ref p, ref max,
                unika.Count == 0b10                         &&
                unika.Any(v => v.Namn == "Kaffe")           &&
                unika.Any(v => v.Namn == "Te"));
        }

        {
            var v    = new Vara("Mjölk", 0xF, "Mejeri");
            var klon = _k.KlonaVara(v);
            Σ(MediumResultat, "KlonaVara", ref p, ref max,
                klon.Namn     == v.Namn               &&
                Math.Abs(klon.Pris - v.Pris) < 0.01  &&
                klon.Kategori == v.Kategori            &&
                !ReferenceEquals(v, klon));
        }

        {
            var far = new Person("far", new DateTime(0x79A, 6, 0xF));
            var son = new Person("son", new DateTime(0x7BB, 3, 0x14));
            Σ(MediumResultat, "ÄldstAv", ref p, ref max,
                _du.ÄldstAv(far, son).Namn == "far" &&
                _du.ÄldstAv(son, far).Namn == "far");
        }

        {
            var p1 = new Person("X", new DateTime(0x7B2, 1, 1));
            Σ(MediumResultat, "FödelsedagsVeckodag", ref p, ref max,
                _du.FödelsedagsVeckodag(p1) == "Torsdag");
        }

        {
            var p1 = new Person("X", new DateTime(0x7C6, 3, 0xF));
            var p2 = new Person("Y", new DateTime(0x7C6, 1, 1));
            Σ(MediumResultat, "DagarFrånNyår", ref p, ref max,
                _du.DagarFrånNyår(p1) == 0x49 &&
                _du.DagarFrånNyår(p2) == 0);
        }

        {
            var p1 = new Person("A", new DateTime(0x7C4, 6, 0xA));
            var p2 = new Person("B", new DateTime(0x7C6, 6, 0xA));
            var p3 = new Person("C", new DateTime(0x76C, 6, 0xA));
            var p4 = new Person("D", new DateTime(0x7D0, 6, 0xA));
            Σ(MediumResultat, "ÄrSkottår", ref p, ref max,
                 _du.ÄrSkottår(p1)  &&
                !_du.ÄrSkottår(p2)  &&
                !_du.ÄrSkottår(p3)  &&
                 _du.ÄrSkottår(p4));
        }

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }


    internal static double KörHard()
    {
        HardResultat.Clear();
        int p = 0, max = 0;

        {
            var q = new Kö();
            q.Enqueue("A");
            q.Enqueue("B");
            q.Enqueue("C");
            Σ(HardResultat, "Kö — Enqueue/Count", ref p, ref max,
                q.Count() == 0b11 && !q.ÄrTom());
        }

        {
            var q = new Kö();
            q.Enqueue("ett");
            q.Enqueue("två");
            q.Enqueue("tre");
            Σ(HardResultat, "Kö — Dequeue FIFO", ref p, ref max,
                q.Dequeue() == "ett" &&
                q.Dequeue() == "två" &&
                q.Count()   == 1);
        }

        {
            var q = new Kö();
            q.Enqueue("x");
            Σ(HardResultat, "Kö — Peek", ref p, ref max,
                q.Peek()    == "x" &&
                q.Count()   == 1   &&
                q.Dequeue() == "x");
        }

        {
            var q = new Kö();
            bool tomFörut = q.ÄrTom();
            q.Enqueue("Y");
            bool inteNu = q.ÄrTom();
            q.Dequeue();
            bool tomIgen = q.ÄrTom();
            Σ(HardResultat, "Kö — ÄrTom", ref p, ref max,
                tomFörut && !inteNu && tomIgen);
        }

        {
            var δ = new List<Deltagare>
            {
                new(1, "Marcus",  "m@t.com"),
                new(0b10, "James", "j@t.com"),
                new(0b11, "Evelyn", "e@t.com"),
            };
            var π = new List<TävlingsPoäng>
            {
                new(1, 0x55),
                new(0b11, 0x5C),
            };
            var res = _t.SlåSamman(δ, π);
            Σ(HardResultat, "SlåSamman", ref p, ref max,
                res.Count        == 0b10       &&
                res[0].Namn      == "Evelyn"   &&
                res[0].Poäng     == 0x5C       &&
                res[1].Namn      == "Marcus"   &&
                res[1].Poäng     == 0x55);
        }

        {
            var res = new List<Resultat>
            {
                new("Marcus",  "m@t.com", 0x55),
                new("Evelyn",  "e@t.com", 0x5C),
                new("James",   "j@t.com", 0x46),
            };
            var v = _t.HämtaVinnare(res);
            Σ(HardResultat, "HämtaVinnare", ref p, ref max,
                v?.Namn  == "Evelyn" &&
                v?.Poäng == 0x5C);
        }

        {
            var marcus = new Person("Marcus", new DateTime(0x7AA, 0xB, 0x14));
            int svar   = _du.DagarTillFödelsedag(marcus);
            DateTime idag = DateTime.Now.Date;
            DateTime nästa = new DateTime(idag.Year, marcus.FöddDen.Month, marcus.FöddDen.Day);
            if (nästa < idag) nästa = nästa.AddYears(1);
            int förväntad = (int)(nästa - idag).TotalDays;
            Σ(HardResultat, "DagarTillFödelsedag", ref p, ref max, svar == förväntad);
        }

        {
            var v1 = new Person("A", new DateTime(0x7C6, 3,  0x19));
            var v2 = new Person("B", new DateTime(0x785, 7,  0xF));
            var v3 = new Person("C", new DateTime(0x7D0, 12, 0x19));
            var v4 = new Person("D", new DateTime(0x7AF, 11, 0x19));
            Σ(HardResultat, "AstrologisktTecken", ref p, ref max,
                _du.AstrologisktTecken(v1) == "Väduren"    &&
                _du.AstrologisktTecken(v2) == "Kräftan"    &&
                _du.AstrologisktTecken(v3) == "Stenbocken" &&
                _du.AstrologisktTecken(v4) == "Skytten");
        }

        return max > 0 ? Math.Round((double)p / max * 100) : 0;
    }


    private static void Σ(List<(string, bool)> lista, string namn,
                          ref int poäng, ref int max, bool resultat)
    {
        max++;
        if (resultat) poäng++;
        lista.Add((namn, resultat));
    }
}
