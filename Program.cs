using Proiect_POO;

bool running = true;
bool runningAdmin = true;
bool runningClient = true;

int capacitate = 10;

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
            int incercari_parola = 3;
            Admin a1;
            
            Console.WriteLine("Pentru a intra pe contul de admin trebuie sa bagati parola!\n" +
                              "Pentru a iesi tastati IESIRE\n" +
                              "Parola: ");
            a1 = new Admin(Console.ReadLine());

            if (a1.MatchPassword() == 1)
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
                            Console.WriteLine("(1)\tCreare loc parcare\n" +
                                              "(2)\tModificare loc parcare\n" +
                                              "(3)\tStergere loc parcare\n" +
                                              "(4)\tModificare capacitate/reguli\n");
                            break;

                        case 2:
                            Console.WriteLine("(1)\tCreare abonament\n" +
                                              "(2)\tConfigurare abonamente(pret/perioada valabilitate/reguli)\n");
                            break;

                        case 3:
                            Console.WriteLine("(1)\tVizualizare abonamente\n" +
                                              "(2)\tVizualizare istoric parcari\n" +
                                              "(3)\tAjustare abonament\n");
                            break;

                        case 4:
                            Console.WriteLine("(1)\tDefinire reguli abonamente\n");
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



            break;
        
        case 2:
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.WriteLine("(1)\tVizualizare abonamente\n" +
                                          "(2)\tInnoire abonament\n" +
                                          "(3)\tAnulare abonament\n");
                        break;
                    case 5:
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
            
            break;
        default:
            Console.WriteLine("Optiune invalida!");
            break;
    }
}