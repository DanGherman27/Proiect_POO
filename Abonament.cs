namespace ProiectPOO;

public abstract class Abonament
{
    public int Id { get; protected set; }
    public string Nume { get; protected set; }
    public decimal Pret{get; protected set;}
    public int DurataZile{get; protected set;}
    public string Reguli{get; protected set;}
    
    protected  Abonament(int id,string nume,decimal pret, int duratazile,string reguli )
    {
        Id = id;
        Nume = nume;
        Pret = pret;
        DurataZile = duratazile;
        Reguli = reguli;
    }

    public virtual void AfiseazaDetalii()
    {
        Console.WriteLine($"{Nume}:{Pret}:{DurataZile}");
        Console.WriteLine($"{Reguli}:{Reguli}");
    }
}