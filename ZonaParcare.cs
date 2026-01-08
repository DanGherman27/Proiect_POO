namespace Parcare_1;

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
    
    public static void ModificareCapacitateZona(
        ZonaParcare zona,
        int capacitateNoua)
    {
        if (capacitateNoua < zona.ListLocDeParcare.Count)
        {
            Console.WriteLine(
                "Capacitatea noua nu poate fi mai mica decat numarul actual de locuri!");
            return;
        }

        zona.Capacitate = capacitateNoua;
        Console.WriteLine("Capacitatea zonei a fost modificata!");
    }
    
    public static void ModificareReguliParcare(
        Parcare parcare,
        int maximDurataAbonamenteNou)
    {
        parcare.Reguli = new ReguliParcare(maximDurataAbonamenteNou);
        Console.WriteLine("Regulile parcarii au fost modificate!");
    }
}
public record ReguliParcare
(
    int Capacitate
);