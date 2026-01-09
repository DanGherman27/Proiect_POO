namespace Proiect_POO;

public class AbonamentClient
{
    public Abonament Abonament{get; private set;}
    public DateTime DateStart{get; private set;}
    public bool Anulat{get; private set;}

    public AbonamentClient(Abonament abonament)
    {
        Abonament = abonament;
        DateStart = DateTime.Now;
        Anulat = false;
    }

    public bool EsteActiv()
    {
        if (Anulat) return false;
        return DateTime.Now<=DateStart.AddDays(Abonament.DurataZile);
    }
    public void Anuleaza()
    {
        Anulat = true;
    }
}