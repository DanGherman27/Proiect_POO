namespace Proiect_POO;
public class Parcare
{
    public int IdParcare { get; set; }
    public string AdresaParcare { get; set; }
    public List<ZonaParcare> ListZoneParcare { get; set; }
    public bool EsteStearsa { get; private set; }
    public DateTime? DataStergere { get; private set; }
    
    public int NrZoneParcare { get; set; }
    public ReguliParcare Reguli { get; set; }

    public Parcare(int idParcare, string adresaParcare, int nrZoneParcare)
    {
        IdParcare = idParcare;
        AdresaParcare = adresaParcare;
        NrZoneParcare = nrZoneParcare;
        ListZoneParcare = new List<ZonaParcare>();
    }
    
    public void CreareLocParcare(ZonaParcare zona, int idLoc, TipLocParcare tipLoc)
    {
        LocDeParcare loc;

        if (tipLoc == TipLocParcare.Standard)
        {
            loc = new LocStandard(idLoc);
        }
        else
        {
            loc = new LocPremium(idLoc);
        }

        loc.Ocupat = false;
        zona.ListLocDeParcare.Add(loc);

        Console.WriteLine("Loc de parcare creat cu succes!");
    }
    
    public void ModificareTipLocParcare(ZonaParcare zona, int idLoc, TipLocParcare tipNou)
    {
        var loc = zona.ListLocDeParcare.FirstOrDefault(l => l.IdLocDeParcare == idLoc);

        if (loc == null)
        {
            Console.WriteLine("Locul nu exista!");
            return;
        }

        if (loc.TipLoc == tipNou)
        {
            Console.WriteLine("Locul are deja acest tip!");
            return;
        }

        LocDeParcare locNou = tipNou switch
        {
            TipLocParcare.Standard => new LocStandard(idLoc),
            TipLocParcare.Premium => new LocPremium(idLoc)
        };

        locNou.Ocupat = loc.Ocupat;

        zona.ListLocDeParcare.Remove(loc);
        zona.ListLocDeParcare.Add(locNou);

        Console.WriteLine("Tipul locului a fost modificat!");
    }
    
    public void StergereLocParcare(ZonaParcare zona, int idLoc)
    {
        var loc = zona.ListLocDeParcare.FirstOrDefault(l => l.IdLocDeParcare == idLoc);

        if (loc == null)
        {
            Console.WriteLine("Locul de parcare nu exista!");
            return;
        }

        zona.ListLocDeParcare.Remove(loc);
        Console.WriteLine("Locul de parcare a fost sters!");
    }
    public void Sterge()
    {
        EsteStearsa = true;
        DataStergere = DateTime.Now;
    }

    public override string ToString()
    {
        return $"ID: {IdParcare}, Adresa: {AdresaParcare}, " +
               $"Status: {(EsteStearsa ? "Stearsa" : "Activa")}";
    }
}