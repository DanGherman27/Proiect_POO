namespace Parcare_1;

public class LocPremium : LocDeParcare
    {
    public LocPremium(int idLocPremium) : base(idLocPremium)
    {
        TipLoc = TipLocParcare.Premium;
    }
}
