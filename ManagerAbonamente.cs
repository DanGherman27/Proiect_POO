namespace ProiectPOO;

public class Manager_Abonamente
{
    private List<Abonament> abonamente = new  ();

    public void AdaugaAbonamente(Abonament abonament)
    {
        abonamente.Add(abonament);
    }

    public void AfiseazAbonamente(Abonament abonament)
    {
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
}