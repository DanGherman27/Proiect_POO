namespace ProiectPOO;

public class Abonament_Premium:Abonament
{
    public Abonament_Premium(int id)
        : base(id, "Premium", 200, 30, "Acces extins+prioritate")
    {
    }

    public override void AfiseazaDetalii()
    {
        base.AfiseazaDetalii();
        Console.WriteLine("Beneficiile suplimentare incluse.");
    }
}