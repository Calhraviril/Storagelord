using Storagelord;

Console.WriteLine($"- - STORAGELORD - -\n 1 - Lisää uusi tuote\n 2 - Poista tuote\n 3 - Tulosta eri tuotteiden määrät\n 4 - Muokkaa tuotenimeä\n 0 - Lopeta sovellus");
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