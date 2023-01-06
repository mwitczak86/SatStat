using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace satstat
{

    class Program
    {
       

        static void Logo()
        {

            Console.Title = "SatStat";
            string title = @"
                  _____       _    _____ _        _   
                 / ____|     | |  / ____| |      | |  
                | (___   __ _| |_| (___ | |_ __ _| |_ 
                 \___ \ / _` | __|\___ \| __/ _` | __|
                 ____) | (_| | |_ ____) | || (_| | |_ 
                |_____/ \__,_|\__|_____/ \__\__,_|\__|
                                      
                                          Michał Witczak
                                                  
            ";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;

        }


        static void WypiszMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t********************* MENU **********************");
            Console.WriteLine("");
            Console.WriteLine("\t[1.] Status wszystkich stacji\n");
            Console.WriteLine("\t[2.] Znajdź stację po ID ");
            Console.WriteLine("\t[3.] Ping do stacji po ID");
            Console.WriteLine("\t[4.] Znajdź stację po Nazwie");
            Console.WriteLine("\t[5.] Ping do stacji po Nazwie");
            Console.WriteLine("\t[6.] Ping stały po ID\n");
            Console.WriteLine("\t[7.] Tabela adresacji");
            Console.WriteLine("\t[8.] Export tabeli do pliku .csv");
            Console.WriteLine("\t[9.] Dodaj nową stację");
            Console.WriteLine("\n\t*************************************************");
            Console.WriteLine("\n\t[x.] SAVE&EXIT");
        }
       
       
        static void WypisaneInfo(Pozycja check)
        {

            if (check == null)
            {
                Console.WriteLine("\n\n------------------------------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t\tBrak pozycji w spisie!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n------------------------------------------------------------------------------------------------------\n\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n|-------------------------------------- ZNALEZIONO : -------------------------------------------------|");
                Console.ForegroundColor = ConsoleColor.White;
                string f = String.Format("|{0,5}|{1,35}|{2,35}|{3,10}|", "ID", "NAZWA", "ADRES IP", "ROLA");

                string n = String.Format("|{0,5}|{1,35}|{2,35}|{3,10}|", check.Id, check.Nazwa, check.Adres, check.Rola);
                string n2 = String.Format("|{0,5}|{1,35}|{2,35}|{3,10}|", "", "", check.AdresLan,"");
                Console.WriteLine(f);
                Console.WriteLine("______________________________________________________________________________________________________");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n" + n);
                Console.WriteLine("\n" + n2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n------------------------------------------------------------------------------------------------------\n");
            }
        }
        static void ClearData()
        {
            //PATH TO INITIAL DATA FILE
            string dataW = "C:/Users/lenovo/source/repos/pingowanie/satstat_git/initial.csv";
            if (File.Exists(dataW))
            {
                File.Delete(dataW);
            }
        }
        static void Main(string[] args)
        { 


            Logo();
            //PATH TO INITIAL DATA FILE
            string dataWej = "C:/Users/lenovo/source/repos/pingowanie/satstat_git/initial.csv";
            Network net1 = new Network("Satcom");
            Katalog kat1 = new Katalog("Katalog stacji");

            Console.WriteLine("Naciśnij dowolny klawisz, aby rozpocząć");
            Console.ReadKey();
            File.WriteAllLines(dataWej,
            File.ReadAllLines(dataWej).Where(x => !String.IsNullOrWhiteSpace(x)));
            string[] wartosci = File.ReadAllLines(dataWej);
                var hosty = new List<Host>();
                
            void InputData()
            {
                
                
                

                   
                  
                   Console.WriteLine("Wpisz nr ID:");
                   int id_ = Convert.ToInt32(Console.ReadLine());
                   Console.WriteLine("Wpisz nazwę");
                   string nazwa_ = Console.ReadLine();
                   Console.WriteLine("Wpisz adres ip (np. 192.168.178.1)");
                   string adres_ = Console.ReadLine();
                   Console.WriteLine("Wpisz drugi adres ip (np. 192.168.178.1), jeśli brak to wpisz " + "-");
                   string adresLAN_ = Console.ReadLine();
                   Console.WriteLine("Wpisz rolę Master/Slave");
                   string rola_ = Console.ReadLine();

                   Host input = new Host(id_, adres_, adresLAN_,nazwa_, rola_);
                   
                   kat1.DodajPozycje(input);
                
            }
            
           
            


            for (int i = 1; i < wartosci.Length; i++)
            {
                Host input = new Host(wartosci[i]);
                hosty.Add(input);
            }

                for (int i = 0; i < hosty.Count; i++)
                {

                    kat1.DodajPozycje(hosty[i]);
                    

                }
                net1.DodajKatalog(kat1);

            

                         
            WypiszMenu();
            
            
            bool petlaMenu = true;
            while (petlaMenu)
            {
                string menu = Console.ReadLine();

                if (menu == "1" || menu == "2" || menu == "3" || menu == "4" || menu == "5" || menu == "6" || menu == "7" || menu == "8" || menu == "9"|| menu == "x")
                {



                    {
                        switch (menu)
                        {
                            case "1":
                                //"Status wszystkich stacji (1) ");
                                net1.PingujWszystkie();
                                Console.WriteLine("Wciśnij dowolny klawisz, aby powrócić.");
                                Console.ReadKey();
                                Console.Clear();
                                Logo();
                                break;


                            case "2":
                                //"Znajdź stację po ID (2) ");
                                Console.WriteLine("Podaj ID stacji: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Pozycja check = net1.ZnajdzPozycjePoID(id);
                                WypisaneInfo(check);
                                Console.WriteLine("Wciśnij dowolny klawisz, aby powrócić.");
                                Console.ReadKey();
                                Console.Clear();
                                Logo();
                                break;

                            case "3":
                                //"Ping do stacji po ID(3)"
                                Console.WriteLine("Podaj ID stacji: ");
                                int id2 = Convert.ToInt32(Console.ReadLine());
                                net1.PingHostaPoID(id2);
                                Console.WriteLine("Wciśnij dowolny klawisz, aby powrócić.");
                                Console.ReadKey();
                                Console.Clear();
                                Logo();
                                break;

                            case "4":
                                //"Znajdź stację po NAZWIE (4) ");
                                Console.WriteLine("Podaj NAZWĘ stacji: ");
                                string nazwa5 = Console.ReadLine();
                                Pozycja check5 = net1.ZnajdzPozycjePoNazwie(nazwa5);
                                WypisaneInfo(check5);
                                Console.WriteLine("Wciśnij dowolny klawisz, aby powrócić.");
                                Console.ReadKey();
                                Console.Clear();
                                Logo();
                                break;

                            case "5":
                                //"Ping do stacji po NAZWIE(5)"
                                Console.WriteLine("Podaj NAZWĘ stacji: ");
                                string nazwa4 = Console.ReadLine();
                                net1.PingHostaPoNazwie(nazwa4);
                                Console.WriteLine("Wciśnij dowolny klawisz, aby powrócić.");
                                Console.ReadKey();
                                Console.Clear();
                                Logo();
                                break;

                            

                            case "6":
                                //Continous ping with ID parameter
                                Console.WriteLine("Podaj ID stacji: ");
                                int id3 = Convert.ToInt32(Console.ReadLine());
                                net1.PingStalyPoID(id3);
                                
                                Console.WriteLine("Wciśnij dowolny klawisz, aby powrócić.");
                                Console.ReadKey();
                                Console.Clear();
                                Logo();
                                break;


                            case "7":
                                //Address table
                                net1.WszystkiePosortowane();
                                Console.WriteLine("Wciśnij dowolny klawisz, aby powrócić.");
                                Console.ReadKey();
                                Console.Clear();
                                Logo();
                                break;


                            case "8":
                                //Address table export
                                Console.WriteLine("Zapis do pliku: data"+ DateTime.Now.ToString("yyyyMMddTHHmmss")+".csv");
                                
                                net1.ExportData();

                                Console.WriteLine("Wciśnij dowolny klawisz, aby powrócić.");
                                Console.ReadKey();
                                Console.Clear();
                                Logo();
                                break;

                            case "9":
                                ///Adding new host
                                InputData();
                                
                                Console.WriteLine("Wciśnij dowolny klawisz, aby powrócić.");
                                Console.ReadKey();
                                Console.Clear();
                                Logo();
                                break;




                            case "x":
                                //Clear data file
                                ClearData();
                                net1.ExportDataAuto();
                                Console.WriteLine("Status danych - OK!\n\n\n");
                                Environment.Exit(0);
                                break;


                            default:
                                petlaMenu = false;
                                break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\tBłąd!!!");
                    Console.WriteLine("\tPodaj wartość z zakresu 1-8");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                Console.WriteLine("\n\nWybierz właściwą opcję, lub zakończ działanie aplikacji.");
                WypiszMenu();
            }


        }
        


    }
}

