using Proiect_POO;
/*
 * Gherman Dan
 * Galati David
 * Han Beniamin
 */

/*Zone initiale*/
Parcare p0 = new Parcare(0, "Simion Popa", 3);
List<Parcare> parcari = new List<Parcare> { p0 };

ZonaParcare z0, z1, z2;
p0.ListZoneParcare.Add(z0 = new ZonaParcare(0, 3));
p0.ListZoneParcare.Add(z1 = new ZonaParcare(1, 4));
p0.ListZoneParcare.Add(z2 = new ZonaParcare(2, 4));

z0.ListLocDeParcare.Add(new LocStandard(0));
z0.ListLocDeParcare.Add(new LocStandard(1));
z0.ListLocDeParcare.Add(new LocPremium(0));

z1.ListLocDeParcare.Add(new LocStandard(0));
z1.ListLocDeParcare.Add(new LocStandard(1));
z1.ListLocDeParcare.Add(new LocPremium(0));
z1.ListLocDeParcare.Add(new LocPremium(1));

z2.ListLocDeParcare.Add(new LocStandard(0));
z2.ListLocDeParcare.Add(new LocStandard(1));
z2.ListLocDeParcare.Add(new LocPremium(0));
z2.ListLocDeParcare.Add(new LocPremium(1));

AbonamentStandard abonamentStandard = new AbonamentStandard(1);
AbonamentPremium abonamentPremium = new AbonamentPremium(1);
ManagerAbonamente managerAbonamente = new ManagerAbonamente();
managerAbonamente.AdaugaAbonament(abonamentStandard);
managerAbonamente.AdaugaAbonament(abonamentPremium);

ParcareManager parcareManager = new ParcareManager();

/*Program*/
bool running = true;
bool runningAdmin = true;
bool runningClient = true;

while (running)
{
    int obt1;
    runningClient = true;
    runningAdmin = true;
    
    Console.WriteLine("Buna ziua, ce tip de cont doriti sa accesati?\n" +
                      "1.Admin\n" +
                      "2.Client\n" +
                      "0.Iesire\n");
    Console.Write("Optiunea dvs: ");
    obt1 = Optiuni.Citeste();

    switch (obt1)
    {
        case 1:
            MeniuAdmin();
            break;
        
        case 2:
            MeniuClient();
            break;

        case 0:
            running = false;
            break;

        default:
            Console.WriteLine("Optiune invalida!");
            break;
    }
}


void AlegereParcare(out Parcare parcareGasita, out ZonaParcare zonaGasita)
{
    parcareGasita = null;
    zonaGasita = null;

    if (parcari.Count == 0)
    {
        Console.WriteLine("Nu exista parcari in sistem.");
        return;
    }

    Console.WriteLine("In ce parcare doriti sa lucrati:");
    foreach (var p in parcari)
        Console.WriteLine($"Parcare ID: {p.IdParcare} - {p.AdresaParcare}");

    Console.Write("ID Parcare: ");
    int parcarea_aleasa = Optiuni.Citeste();

    foreach (var p in parcari)
    {
        if (p.IdParcare == parcarea_aleasa)
        {
            parcareGasita = p;
            break;
        }
    }

    if (parcareGasita == null)
    {
        Console.WriteLine("Parcarea nu a fost gasita!");
        return;
    }

    if (parcareGasita.ListZoneParcare == null || parcareGasita.ListZoneParcare.Count == 0)
    {
        Console.WriteLine("Parcarea selectata nu are zone.");
        return;
    }

    Console.WriteLine("In ce zona doriti sa lucrati:");
    foreach (var z in parcareGasita.ListZoneParcare)
        Console.WriteLine($"Zona ID: {z.IdZonaParcare}");

    Console.Write("ID Zona: ");
    int zonaAleasa = Optiuni.Citeste();

    foreach (var z in parcareGasita.ListZoneParcare)
    {
        if (z.IdZonaParcare == zonaAleasa)
        {
            zonaGasita = z;
            break;
        }
    }

    if (zonaGasita == null)
    {
        Console.WriteLine("Zona nu a fost gasita!");
        return;
    }
}

void AfiseazaLocuri(ZonaParcare zona)
{
    if (zona == null)
    {
        Console.WriteLine("Zona este nula.");
        return;
    }

    if (zona.ListLocDeParcare == null || zona.ListLocDeParcare.Count == 0)
    {
        Console.WriteLine("Nu exista locuri in aceasta zona.");
        return;
    }

    Console.WriteLine($"Locuri in zona {zona.IdZonaParcare}:");
    foreach (var l in zona.ListLocDeParcare)
    {
        string tip = l.TipLoc.ToString();
        string ocupat = l.Ocupat ? "Ocupat" : "Liber";
        Console.WriteLine($"ID Loc: {l.IdLocDeParcare} | Tip: {tip} | Stare: {ocupat}");
    }
}

TipLocParcare CitesteTipLocDinOptiune(int opt)
{
    return opt == 2 ? TipLocParcare.Premium : TipLocParcare.Standard;
}

void MeniuAdmin()
{
    Console.WriteLine("Pentru a intra pe contul de admin trebuie sa bagati parola!\n" +
                      "Parola: ");
    Admin a1 = new Admin(Console.ReadLine());
    
    while (runningAdmin)
    {

        if (a1.MatchPassword())
        {
            Console.WriteLine("\n=== MENIU ADMIN ===");
            Console.WriteLine("1. Creare loc parcare");
            Console.WriteLine("2. Modificare tip loc");
            Console.WriteLine("3. Stergere loc");
            Console.WriteLine("4. Sterge parcare (marcheaza stearsa)");
            Console.WriteLine("5. Afiseaza locuri intr-o zona");
            Console.WriteLine("6. Afiseaza istoricul parcari (daca exista)");
            Console.WriteLine("0. Iesire meniu admin");
            Console.Write("Optiunea dvs: ");

            int opt = Optiuni.Citeste();
            switch (opt)
            {
                case 1:
                {
                    AlegereParcare(out var p, out var z);
                    if (p == null || z == null) break;

                    Console.Write("ID loc nou: ");
                    int idLoc = Optiuni.Citeste();

                    Console.WriteLine("Tip loc: 1.Standard  2.Premium");
                    Console.Write("Optiunea dvs: ");
                    int tipOpt = Optiuni.Citeste();
                    var tip = CitesteTipLocDinOptiune(tipOpt);

                    p.CreareLocParcare(z, idLoc, tip);
                }
                    break;

                case 2:
                {
                    AlegereParcare(out var p, out var z);
                    if (p == null || z == null) break;

                    Console.Write("ID loc de modificat: ");
                    int idLoc = Optiuni.Citeste();

                    Console.WriteLine("Tip nou: 1.Standard  2.Premium");
                    Console.Write("Optiunea dvs: ");
                    int tipOpt = Optiuni.Citeste();
                    var tipNou = CitesteTipLocDinOptiune(tipOpt);

                    p.ModificareTipLocParcare(z, idLoc, tipNou);
                }
                    break;

                case 3:
                {
                    AlegereParcare(out var p, out var z);
                    if (p == null || z == null) break;

                    Console.Write("ID loc de sters: ");
                    int idLoc = Optiuni.Citeste();

                    p.StergereLocParcare(z, idLoc);
                }
                    break;

                case 4:
                {
                    Console.WriteLine("Selecteaza parcare de sters:");
                    foreach (var par in parcari)
                        Console.WriteLine($"Parcare ID: {par.IdParcare} - {par.AdresaParcare}");

                    Console.Write("ID Parcare: ");
                    int idPar = Optiuni.Citeste();
                    var parcare = parcari.FirstOrDefault(pr => pr.IdParcare == idPar);
                    if (parcare == null)
                    {
                        Console.WriteLine("Parcare inexistenta.");
                        break;
                    }

                    parcare.Sterge();
                    Console.WriteLine("Parcarea a fost marcata ca stearsa.");
                }
                    break;

                case 5:
                {
                    AlegereParcare(out var p, out var z);
                    if (p == null || z == null) break;
                    AfiseazaLocuri(z);
                }
                    break;

                case 6:
                {
                    parcareManager.AfiseazaIstoric();
                }
                    break;

                case 0:
                    runningAdmin = false;
                    break;

                default:
                    Console.WriteLine("Optiune invalida!");
                    break;
            }
        }
    }
}

void MeniuClient()
{
    Console.Write("Numarul masinii: ");
    Client c1 = new Client(Console.ReadLine());
    while (runningClient)
    {
        Console.WriteLine("\n=== MENIU CLIENT ===");
        Console.WriteLine("1. Vizualizeaza parcari si zone");
        Console.WriteLine("2. Vizualizeaza locuri intr-o zona");
        Console.WriteLine("3. Ocupa / Elibereaza un loc");
        Console.WriteLine("0. Iesire meniu client");
        Console.Write("Optiunea dvs: ");

        int opt = Optiuni.Citeste();
        switch (opt)
        {
            case 1:
                {
                    if (parcari.Count == 0)
                    {
                        Console.WriteLine("Nu exista parcari.");
                        break;
                    }

                    foreach (var p in parcari)
                    {
                        Console.WriteLine(p.ToString());
                        if (p.ListZoneParcare != null)
                        {
                            foreach (var z in p.ListZoneParcare)
                                Console.WriteLine($"\tZona ID: {z.IdZonaParcare} | Locuri: {z.ListLocDeParcare?.Count ?? 0}");
                        }
                    }
                }
                break;

            case 2:
                {
                    AlegereParcare(out var p, out var z);
                    if (p == null || z == null) 
                        break;
                    AfiseazaLocuri(z);
                }
                break;

            case 3:
                {
                    AlegereParcare(out var p, out var z);
                    if (p == null || z == null) 
                        break;

                    Console.Write("ID loc: ");
                    int idLoc = Optiuni.Citeste();

                    var loc = z.ListLocDeParcare.FirstOrDefault(l => l.IdLocDeParcare == idLoc);
                    if (loc == null)
                    {
                        Console.WriteLine("Locul nu exista.");
                        break;
                    }

                    Console.WriteLine($"Loc curent: {(loc.Ocupat ? "Ocupat" : "Liber")}");
                    Console.WriteLine("1. Marcheaza ocupat\n2. Marcheaza liber");
                    Console.Write("Optiunea dvs: ");
                    int aleg = Optiuni.Citeste();
                    if (aleg == 1)
                    {
                        loc.Ocupat = true;
                        Console.WriteLine("Loc marcat ca ocupat.");
                    }
                    else if (aleg == 2)
                    {
                        loc.Ocupat = false;
                        Console.WriteLine("Loc marcat ca liber.");
                    }
                    else
                    {
                        Console.WriteLine("Optiune invalida.");
                    }
                }
                break;

            case 0:
                runningClient = false;
                break;

            default:
                Console.WriteLine("Optiune invalida!");
                break;
        }
    }
}