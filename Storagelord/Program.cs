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