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
p0.ListZoneParcare.Add(z0=new ZonaParcare(0, 3));
p0.ListZoneParcare.Add(z1=new ZonaParcare(1, 4));
p0.ListZoneParcare.Add(z2=new ZonaParcare(2, 4));

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
                      "2.Client\n");
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
        default:
            Console.WriteLine("Optiune invalida!");
            break;
    }
}


void AlegereParcare(out Parcare parcareGasita, out ZonaParcare zonaGasita)
{
    parcareGasita = null;
    zonaGasita = null;

    Console.WriteLine("In ce parcare doriti sa creati locul:");
    foreach (var p in parcari)
        Console.WriteLine($"Parcare ID: {p.IdParcare}");

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

    Console.WriteLine("In ce zona doriti sa creati locul:");
    foreach (var z in parcareGasita.ListZoneParcare)
        Console.WriteLine($"Zona ID: {z.IdZonaParcare}");

    int zona_aleasa = Optiuni.Citeste();

    foreach (var z in parcareGasita.ListZoneParcare)
    {
        if (z.IdZonaParcare == zona_aleasa)
        {
            zonaGasita = z;
            break;
        }
    }

    if (zonaGasita == null)
    {
        Console.WriteLine("Zona nu a fost gasita!");
    }
}

void MeniuAdmin()
{
    int incercari_parola = 3;
            Admin a1;
            
            Console.WriteLine("Pentru a intra pe contul de admin trebuie sa bagati parola!\n" +
                              "Parola: ");
            a1 = new Admin(Console.ReadLine());

            if (a1.MatchPassword())
            {
                while (runningAdmin)
                {


                    int obt_admin;
                    Console.WriteLine("Parola corecta!\n");
                    Console.WriteLine("Ce optiune doriti sa alegeti:\n" +
                                      "(1)\tAdministrarea parcarilor si zonelor\n" +
                                      "(2)\tDefinirea tipurilor de abonamente\n" +
                                      "(3)\tGestionarea abonamentelor active\n" +
                                      "(4)\tConfigurarea limitelor si regulilor\n" +
                                      "(5)\tIesire\n");

                    Console.WriteLine("Optiunea dvs: ");
                    obt_admin = Optiuni.Citeste();

                    switch (obt_admin)
                    {
                        case 1:
                            AdministrareaParcarilorSiZonelor();
                            break;

                        case 2:
                            DefinireaTipurilorDeAbonamente();
                            break;

                        case 3:
                            GestionareaAbonamentelorActive();
                            break;

                        case 4:
                            ConfigurareaLimitelorSiRegulilor();
                            break;

                        case 5:
                            runningAdmin = false;
                            break;
                        default:
                            Console.WriteLine("Optiune invalida!");
                            break;
                    }
                }
            }
}
//Proprietati meniu admin

void AdministrareaParcarilorSiZonelor()
{
    int obt_admin1;
    Console.WriteLine("(1)\tCreare loc parcare\n" + 
                      "(2)\tModificare loc parcare\n" + 
                      "(3)\tStergere loc parcare\n" + 
                      "(4)\tModificare capacitate/reguli\n");
    Console.WriteLine("Optiunea dvs: ");
    obt_admin1 = Optiuni.Citeste();
    
    switch (obt_admin1) {
        case 1: 
            Parcare parcareGasita1;
            ZonaParcare zonaGasita1;
            AlegereParcare(out parcareGasita1, out zonaGasita1); 
            if (parcareGasita1 != null && zonaGasita1 != null) 
            { 
                if(zonaGasita1.ListLocDeParcare.Count < zonaGasita1.Capacitate) 
                    parcareGasita1.CreareLocParcare(zonaGasita1, zonaGasita1.ListLocDeParcare.Count, TipLocParcare.Standard);
            }
            break;
                                
        case 2: 
            Parcare parcareGasita2; 
            ZonaParcare zonaGasita2;
            
            Console.WriteLine("Ce loc doriti sa modificati: "); 
            int loc2 = Optiuni.Citeste();
            
            AlegereParcare(out parcareGasita2, out zonaGasita2);

            if (parcareGasita2 != null && zonaGasita2 != null) 
            { 
                parcareGasita2.ModificareTipLocParcare(zonaGasita2,loc2 ,TipLocParcare.Standard);
            } 
            break;
                                
        case 3:
            Parcare parcareGasita3;
            ZonaParcare zonaGasita3;
                                    
            Console.WriteLine("Ce loc doriti sa modificati: ");
            AlegereParcare(out parcareGasita3, out zonaGasita3);
                                    
            Console.WriteLine("Ce loc doriti sa stergeti: ");
            int loc3 = Optiuni.Citeste();
                                   
            if (parcareGasita3 != null && zonaGasita3 != null)
            { 
                parcareGasita3.StergereLocParcare(zonaGasita3, loc3);
            }
            break;
                                
        case 4:
            Parcare parcareGasita4;
            ZonaParcare zonaGasita4;
                                    
            Console.WriteLine("Ce loc doriti sa modificati: ");

            AlegereParcare(out parcareGasita4, out zonaGasita4);
                                    
            Console.WriteLine("Schimbare capacitate locuri: ");
            int capacitate4 = Optiuni.Citeste();

            if (parcareGasita4 != null && zonaGasita4 != null)
            {
                ZonaParcare.ModificareCapacitateZona(zonaGasita4, capacitate4);
            }
            break;
        
        default:
            Console.WriteLine("Optiunea aleasa nu exista!");
            break;
    }
}
void DefinireaTipurilorDeAbonamente()
{
    Console.WriteLine("(1)\tCreare abonament\n" +
                      "(2)\tConfigurare abonamente(pret/perioada valabilitate/reguli)\n");
                            
    Console.Write("Optiunea aleasa este: "); 
    int opt_admin2 = Optiuni.Citeste();
    switch (opt_admin2) 
    {
        case 1:
            Console.Write("ID: ");
            int idAbNou1 = Optiuni.Citeste();
            Console.Write("Nume: ");
            string numeAbNou1 = Console.ReadLine();
            Console.Write("Pret: ");
            float pretAbNou1 = Optiuni.Citeste();
            Console.Write("Durata zile: ");
            int durataZile1 = Optiuni.Citeste(); 
            Console.Write("Reguli: ");
            string reguliAbNou1 = Console.ReadLine();


            managerAbonamente.AdaugaAbonament(new AbonamentStandard(idAbNou1));
            break;

        case 2:
            Console.WriteLine("Ce abonament doriti sa schimbati(standard/premuim)?");
            string tipAb2 = Console.ReadLine();
            Console.Write("Pret nou: ");
            float pretAbNou2 = Optiuni.Citeste();
            Console.Write("Durata zile: ");
            int durataZile2 = Optiuni.Citeste();
            Console.Write("Reguli noi: ");
            string reguliAbNou2 = Console.ReadLine();

            if (tipAb2 == "standard" || tipAb2 == "STANDARD")
            {
                AbonamentStandard.pretStandard = pretAbNou2;
                AbonamentStandard.durataStandard = durataZile2;
                AbonamentStandard.reguliStandard = reguliAbNou2;
            }
            else if (tipAb2 == "premuim" || tipAb2 == "PREMUIM")
            {
                AbonamentPremium.pretPremium = pretAbNou2;
                AbonamentPremium.durataPremium = durataZile2;
                AbonamentPremium.reguliPremium = reguliAbNou2;
            }
            else
            {
                Console.WriteLine("Abonamentul: " + tipAb2 + " nu exista!");
            }
            break;
        
        default:
            Console.WriteLine("Optiunea aleasa nu exista!");
            break;
    }
}
void GestionareaAbonamentelorActive()
{
    Console.WriteLine("(1)\tVizualizare abonamente\n" +
                      "(2)\tVizualizare istoric parcari\n" +
                      "(3)\tAjustare abonament\n");
                            
    Console.Write("Optiunea aleasa este: ");
    int opt_admin3 = Optiuni.Citeste();
    switch (opt_admin3)
    {
        case 1:
            managerAbonamente.AfiseazaAbonamente();
            break;
                                
        case 2:
            ParcareManager parcareManager = new ParcareManager();
            parcareManager.AfiseazaIstoric();
            break;
                                
        case 3:




            break;
        
        default:
            Console.WriteLine("Optiunea aleasa nu exista!");
            break;
    }

}
void ConfigurareaLimitelorSiRegulilor()
{
    Console.Write("Schimbati regulile la abonamentul standard/premium : ");
    string tipAb4 = Console.ReadLine();
    Console.Write("Reguli noi: ");
    string reguliAbNou4 = Console.ReadLine();
                            
    if (tipAb4 == "standard" || tipAb4 == "STANDARD")
    {
        AbonamentStandard.reguliStandard = reguliAbNou4;
    } 
    else if (tipAb4 == "premuim" || tipAb4 == "PREMUIM")
    {
        AbonamentPremium.reguliPremium = reguliAbNou4;
    }
    else
    {
        Console.WriteLine("Abonamentul: " + tipAb4 +" nu exista!");
    }
}

void MeniuClient()
{
    Client c1;
            Console.Write("Numarul masinii: ");
            c1 = new Client(Console.ReadLine());
            
            while(runningClient)
            {
                int obt_client;
            
                Console.WriteLine("(1)\tCăutarea ofertelor de abonament\n" +
                                  "(2)\tVizualizarea detaliilor unui abonament\n" +
                                  "(3)\tCumpărarea unui abonament\n" +
                                  "(4)\tGestionarea abonamentelor personale\n" +
                                  "(5)\tIstoric abonamente\n" +
                                  "(6)\tIesire\n" );
            
                Console.WriteLine("Optiunea dvs: ");
                obt_client = Optiuni.Citeste();

                switch (obt_client)
                {
                    case 1:
                        CautareaOfertelorDeAbonament();
                        break;
                    
                    case 2:
                        VizualizareaDetaliilorUnuiAbonament();
                        break;
                    
                    case 3:
                        CumparareaUnuiAbonament(c1);
                        break;
                    
                    case 4:
                        GestionareaAbonamentelorPersonale(c1);
                        break;
                    
                    case 5:
                        managerAbonamente.AfiseazaAbonamente();
                        break;
                    
                    case 6:
                        if (obt_client == 6)
                        {
                            runningClient = false;
                        }
                        break;
                    
                    default:
                        Console.WriteLine("Optiune invalida!");
                        break;
                }
            }
}
//Proprietati meniu admin

void CautareaOfertelorDeAbonament()
{
    Console.Write("ID ul abonamentului: ");
    int id_abonament = Optiuni.Citeste();
    Abonament ab = managerAbonamente.CautaAbonament(id_abonament);

    if (ab == null)
        Console.WriteLine("Abonament inexistent!");
    else
        ab.AfiseazaDetalii();
}
void VizualizareaDetaliilorUnuiAbonament()
{
    Console.Write("Vizualizati tipurile de abonamente standard/premium : ");
    string tipAbClient1 = Console.ReadLine();
                            
    if (tipAbClient1 == "standard" || tipAbClient1 == "STANDARD")
    {
        Console.WriteLine(abonamentStandard.ToString());
    } 
    else if (tipAbClient1 == "premuim" || tipAbClient1 == "PREMUIM")
    {
        Console.WriteLine(abonamentPremium.ToString());
    }
    else
    {
        Console.WriteLine("Abonamentul: " + tipAbClient1 +" nu exista!");
    } 
}
void CumparareaUnuiAbonament(Client c)
{
    Console.Write("Introdu ID abonament: ");
    int id = Optiuni.Citeste();
    managerAbonamente.CumparaAbonament(c, id);
}
void GestionareaAbonamentelorPersonale(Client c)
{
    Console.WriteLine("(1)\tVizualizare abonamente\n" +
                      "(2)\tInnoire abonament\n" +
                      "(3)\tAnulare abonament\n");
    Console.Write("Optiunea dvs. este: ");
    int obt_client4 = Optiuni.Citeste();

    switch (obt_client4)
    {
        case 1:
            managerAbonamente.AfiseazaAbonamente();
            break;
                            
        case 2:
            break;
                            
        case 3:
            break;
                            
        default:
            Console.WriteLine("Optiunea aleasa nu exista!");
            break;
    }
}