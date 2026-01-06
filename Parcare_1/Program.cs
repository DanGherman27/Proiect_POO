class Parcare
{
    public int IdParcare { get; set; }
    public string AdresaParcare { get; set; }
    public List<ZonaParcare> ListZoneParcare { get; set; }
    
    public int NrZoneParcare { get; set; }
    public ReguliParcare Reguli { get; set; }

    public Parcare(int idParcare, string adresaParcare, int nrZoneParcare)
    {
        IdParcare = idParcare;
        AdresaParcare = adresaParcare;
        NrZoneParcare = nrZoneParcare;
        ListZoneParcare = new List<ZonaParcare>();
    }
}
public class ZonaParcare
{
    public int IdZonaParcare { get; set; }
    public int IdParcare {get; set;}
    public int Capacitate { get; set; }
    public List<LocDeParcare> ListLocDeParcare { get; set; }

    public ZonaParcare(int idZonaParcare, int capacitate)
    {
        IdZonaParcare = idZonaParcare;
        Capacitate = capacitate;
        ListLocDeParcare = new List<LocDeParcare>();
    }
    
}
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

public record ReguliParcare
(
    int MaximDurataAbonamente
);
public enum TipLocParcare
{
    Standard,
    Premium
}   