using Storagelord;

Console.WriteLine($"- - STORAGELORD - -\n 1 - Lisää uusi tuote\n 2 - Poista tuote\n 3 - Tulosta eri tuotteiden määrät\n 4 - Muokkaa tuotenimeä\n 0 - Lopeta sovellus");
bool deadProtocol = false;
while (true)
{
    int command = Convert.ToInt32(Console.ReadLine());
    switch (command)
    {
        case 0:
            Console.WriteLine("Bye bye =)");
            deadProtocol = true;
            break;
        case 1:
            Console.WriteLine("Kirjoita:ID Nimi Hinta Saldo");
            string masterLine = Console.ReadLine();
            string[] separLine = masterLine.Split(' ');
            if (separLine.Length == 4)
            {
                AddTuote(Convert.ToInt32(separLine[0]), separLine[1], (float)Convert.ToDouble(separLine[2]), Convert.ToInt32(separLine[3]));
            }
            else
            {
                Console.WriteLine("Et kirjoittanut oikean määrän tietoa");
            }
            break;
        case 2:
            Console.WriteLine("Kirjoita poistettavan ID");
            int delID = Convert.ToInt32(Console.ReadLine());
            DeleteTuote(delID);
            break;
        case 3:
            Console.WriteLine("Tulostetaan...");
            EtsiTuotteet();
            break;
        case 4:
            Console.WriteLine("Kirjoita:'Uusi nimi' 'Muutettavan ID'");
            string masterLine2 = Console.ReadLine();
            string[] separLine2 = masterLine2.Split(' ');
            ChangeProductName(separLine2[0], Convert.ToInt32(separLine2[1]));
            break;
        default: Console.WriteLine("Komentoa ei ole olemassa"); break;
    }
    if (deadProtocol)
    {
        break;
    }
}
static bool AddTuote(int uusiID, string uusiNimi, float uusiHinta, int uusiSaldo)
{
    using (Varastohallinta varastohallinta = new())
    {
        Tuote tuote = new()
        {
            ID = uusiID,
            TUOTENIMI = uusiNimi,
            TUOTEHINTA = uusiHinta,
            VARASTOSALDO = uusiSaldo
        };
        varastohallinta.tuotteet?.Add(tuote);
        int affected = varastohallinta.SaveChanges();
        return (affected == 1);
    }
}
static int DeleteTuote(int ID)
{
    using (Varastohallinta varastohallinta = new())
    {
        Tuote tuoteToDelete = varastohallinta.tuotteet.Find(ID);
        if (tuoteToDelete is null)
        {
            Console.WriteLine("Ei löydy!");
            return 0;
        }
        else
        {
            varastohallinta.Remove(tuoteToDelete);
            int affected = varastohallinta.SaveChanges();
            return affected;
        }
    }
}
static void EtsiTuotteet()
{
    using (Varastohallinta varastohallinta = new())
    {
        Console.WriteLine("Käyttäjien tiedot");
        IQueryable<Tuote>? tuotteet = varastohallinta.tuotteet;

        if (tuotteet == null)
        {
            Console.WriteLine("Ei käyttäjiä rekisteröitynä");
            return;
        }

        foreach (Tuote tuote in tuotteet)
        {
            Console.WriteLine("Varastossa on " + tuote.TUOTENIMI + " tuotetta " + tuote.VARASTOSALDO + " kpl.");
        }
    }
}
static bool ChangeProductName(string newName, int ID)
{
    using (Varastohallinta varastohallinta = new Varastohallinta())
    {
        Tuote tuoteToUpdate = varastohallinta.tuotteet.Find(ID);
        if (tuoteToUpdate == null)
        {
            Console.WriteLine("Change Failed");
            return false;
        }
        else
        {
            tuoteToUpdate.TUOTENIMI = newName;
            int affected = varastohallinta.SaveChanges();
            return (affected == 1);
        }
    }
}