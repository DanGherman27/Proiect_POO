namespace Proiect_POO;

public class LocStandard : LocDeParcare
{
    public LocStandard(int idLocStandard) : base(idLocStandard)
    {
        TipLoc = TipLocParcare.Standard;
    }
}