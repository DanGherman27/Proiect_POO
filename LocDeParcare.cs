namespace Parcare_1;

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

public class LocStandard : LocDeParcare
{
    public LocStandard(int idLocStandard) : base(idLocStandard)
    {
        TipLoc = TipLocParcare.Standard;
    }
}

public class LocPremium : LocDeParcare
{
    public LocPremium(int idLocPremium) : base(idLocPremium)
    {
        TipLoc = TipLocParcare.Premium;
    }
}

public enum TipLocParcare
{
    Standard,
    Premium
} 