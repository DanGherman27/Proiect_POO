namespace Proiect_POO;

public class Optiuni
{
    // Metoda este statică pentru a putea fi apelată fără a crea un obiect nou: Optiuni.Citeste();
    public static int Citeste()
    {
        string input = Console.ReadLine();
        if (int.TryParse(input, out int rezultat))
        {
            return rezultat;
        }
        
        Console.WriteLine("Eroare: Te rugăm să introduci un număr valid.");
        return -1; // Returnăm o valoare santinelă pentru eroare
    }
}