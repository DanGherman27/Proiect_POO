namespace Proiect_POO;

public abstract class LocDeParcare
{
    public int IdLocDeParcare { get; set; }
    public bool Ocupat { get; set; }
    public TipLocParcare TipLoc { get; set; }
    public LocDeParcare(int idLocDeParcare)
    {
        IdLocDeParcare = idLocDeParcare;
    }
}
public enum TipLocParcare
{
    Standard,
    Premium
}