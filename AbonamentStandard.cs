namespace Proiect_POO;

public class AbonamentStandard:Abonament
{
    public static float pretStandard =100;
    public static int durataStandard = 30;
    public static string reguliStandard ="Acces standard zona";
    public AbonamentStandard(int id) : base(id, "Standard", pretStandard, durataStandard, reguliStandard)
    {
    }

    public override string ToString()
    {
        return $"Nume: {Nume} , ID: {Id} , Pret: {pretStandard} , Durata:  {durataStandard} , Reguli: {reguliStandard}";
    }
}