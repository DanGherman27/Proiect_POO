namespace Proiect_POO;

public class ManagerAbonamente
{
    private List<Abonament> abonamente = new();
    
    public void AdaugaAbonament(Abonament abonament)
    {
        abonamente.Add(abonament);
        Console.WriteLine("Abonamentul a fost creat!");
    }
    
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
    
    public Abonament CautaAbonament(int id)
    {
        return abonamente.FirstOrDefault(a => a.Id == id);
    }
    
    public void CumparaAbonament(Client client, int idAbonament)
    {
        Abonament ab = CautaAbonament(idAbonament);

        if (ab == null)
            throw new Exception("Abonament inexistent!");

        client.AdaugaAbonament(new AbonamentClient(ab));
    }
    
    public bool ExistaAbonamente()
    {
        return abonamente.Count > 0;
    }
}