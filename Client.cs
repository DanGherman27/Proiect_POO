namespace Proiect_POO;

public class Client
{
    public string NumarMasina { get; }
    private List<AbonamentClient> abonamente = new();

    public Client(string numarMasina)
    {
        if (string.IsNullOrWhiteSpace(numarMasina))
            throw new ArgumentException("Numar masina invalid");

        NumarMasina = numarMasina;
    }
    
    public void AdaugaAbonament(AbonamentClient ab)
    {
        abonamente.Add(ab);
    }

    public IEnumerable<AbonamentClient> GetAbonamente()
    {
        return abonamente;
    }
}