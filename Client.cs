namespace Proiect_POO;

public class Client
{
    public string NumarMasina { get; }

    public Client(string numarMasina)
    {
        if (string.IsNullOrWhiteSpace(numarMasina))
            throw new ArgumentException("Numar masina invalid");

        NumarMasina = numarMasina;
    }
}