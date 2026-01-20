namespace Proiect_POO;

public class AbonamentPremium:Abonament
{
    public static float pretPremium =200;
    public static int durataPremium = 30;
    public static string reguliPremium ="Acces extins+prioritate";
    public AbonamentPremium(int id) : base(id, "Premium", pretPremium, durataPremium,reguliPremium )
    {
    }

    public override void AfiseazaDetalii()
    {
        base.AfiseazaDetalii();
        Console.WriteLine("Beneficiile suplimentare incluse.");
    }
    
    public override string ToString()
    {
        return $"Nume: {Nume} , ID: {Id} , Pret: {pretPremium} , Durata:  {durataPremium} , Reguli: {reguliPremium}";
    }
}