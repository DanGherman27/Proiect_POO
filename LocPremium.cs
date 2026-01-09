namespace Proiect_POO;

public class LocPremium : LocDeParcare
{
    public LocPremium(int idLocPremium) : base(idLocPremium)
    {
        TipLoc = TipLocParcare.Premium;
    }
}