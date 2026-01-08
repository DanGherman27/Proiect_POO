namespace ProiectPOO;

public class Manager_Abonamente
{
    private List<Abonament> abonamente = new();

    // ================= ADMIN =================

    // Creare tip abonament
    public void AdaugaAbonament(Abonament abonament)
    {
        abonamente.Add(abonament);
    }

    // ================= CLIENT =================

    // 1) Cautarea ofertelor de abonament
    public void AfiseazaAbonamente()
    {
        if (abonamente.Count == 0)
        {
            Console.WriteLine("Nu exista abonamente disponibile.");
            return;
        }

        foreach (var a in abonamente)
        {
            a.AfiseazaDetalii();
            Console.WriteLine();
        }
    }

    // 2) Vizualizarea detaliilor unui abonament
    public Abonament CautaAbonament(int id)
    {
        return abonamente.FirstOrDefault(a => a.Id == id);
    }

    // 3) Cumpararea unui abonament
    public void CumparaAbonament(Client client, int idAbonament)
    {
        Abonament ab = CautaAbonament(idAbonament);

        if (ab == null)
            throw new Exception("Abonament inexistent!");

        client.AdaugaAbonament(new Abonament_Client(ab));
    }

    // ================= ADMIN / CLIENT =================

    // Folositor pentru verificari sau debug
    public bool ExistaAbonamente()
    {
        return abonamente.Count > 0;
    }
}
