namespace Proiect_POO;

public class ParcareManager
{
    private List<Parcare> _istoricParcari = new();

    public void AfiseazaIstoric()
    {
        Console.WriteLine("=== ISTORIC PARCARI ===");

        if (_istoricParcari.Count == 0)
        {
            Console.WriteLine("Nu exista parcari in istoric.");
            return;
        }

        foreach (var parcare in _istoricParcari)
        {
            Console.WriteLine(parcare);
        }
    }
}
