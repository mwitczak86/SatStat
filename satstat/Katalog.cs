using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Timers;
using System.IO;





namespace satstat
{
    public class Katalog : IZarzadzeniePozycjami
    {
        private string typStacji;
        public List<Pozycja> poz = new List<Pozycja>();
        

        public string TypStacji
        {
            get { return typStacji; }
            set { typStacji = value; }
        }

        public Katalog()
        {
            typStacji = "nieokreślony";
        }

        public Katalog(string typStacji_)
        {
            typStacji = typStacji_;
        }


        public void DodajPozycje(Pozycja pos)
        {
            poz.Add(pos);
        }

        
        public Pozycja ZnajdzPozycjePoNazwie(string nazwa)
        {
            Pozycja result = null;
            foreach (Pozycja pos in poz)
            {
                if (pos.Nazwa == nazwa)
                {
                    result = pos;
                    break;
                }
            }
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public Pozycja PingHostaPoNazwie(string nazwa)
        {
            Pozycja result = null;
            foreach (Pozycja pos in poz)
            {
                if (pos.Nazwa == nazwa)
                {
                    Ping ping = new Ping();
                    string adres = pos.Adres;
                    string adres2 = pos.AdresLan;
                    int timeout = 20;
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] bufor = Encoding.ASCII.GetBytes(data);
                    PingOptions opcje = new PingOptions();
                    opcje.DontFragment = true;
                    try
                    {

                        PingReply odpowiedz = ping.Send(adres, timeout, bufor, opcje);
                        PingReply odpowiedz2 = ping.Send(adres2, timeout, bufor, opcje);
                        if (odpowiedz.Status == IPStatus.Success)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            string oi = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", pos.Id, pos.Nazwa, adres, odpowiedz.RoundtripTime + "[ms]", odpowiedz.Options.Ttl, odpowiedz.Buffer.Length, "AKTYWNY");
                            Console.WriteLine("______________________________________________________________________________________________________");
                            Console.WriteLine("\n" + oi);
                            Console.ForegroundColor = ConsoleColor.White;
                            if (odpowiedz2.Status == IPStatus.Success)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                string oi2 = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", "-", "-", adres2, odpowiedz.RoundtripTime + "[ms]", odpowiedz.Options.Ttl, odpowiedz.Buffer.Length, "AKTYWNY");
                                Console.WriteLine("______________________________________________________________________________________________________");
                                Console.WriteLine("\n" + oi2);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                string ob2 = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", "-", "-", adres2, "-", "-", "LAN", "NIEOSIĄGALNY");
                                Console.WriteLine("______________________________________________________________________________________________________");
                                Console.WriteLine("\n" + ob2);
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            string ob2 = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", pos.Id, pos.Nazwa, adres, "-", "-", "", "NIEOSIĄGALNY");
                            string ob3 = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", "", "", adres2, "-", "-", "LAN", "NIEOSIĄGALNY");
                            Console.WriteLine("______________________________________________________________________________________________________");
                            Console.WriteLine("\n" + ob2);
                            Console.WriteLine("\n" + ob3);
                            Console.WriteLine("Błąd: " + adres + " " + odpowiedz.Status.ToString() + " " + "BRAK KOMUNIKACJI Z HOSTEM!!!!\n" +
                                "");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Błąd:" + adres + " " + ex.Message);
                    }

                }

            }
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public Pozycja PingHostaPoID(int id)
        {
            Pozycja result = null;
            foreach (Pozycja pos in poz)
            {
                if (pos.Id == id)
                {
                    Ping ping = new Ping();
                    string adres = pos.Adres;
                    string adres2 = pos.AdresLan;
                    int timeout = 120;
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] bufor = Encoding.ASCII.GetBytes(data);
                    PingOptions opcje = new PingOptions();
                    opcje.DontFragment = true;

                    try
                    {

                        PingReply odpowiedz = ping.Send(adres, timeout, bufor, opcje);
                        PingReply odpowiedz2 = ping.Send(adres2, timeout, bufor, opcje);
                        if (odpowiedz.Status == IPStatus.Success)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            string o = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", pos.Id, pos.Nazwa, adres, odpowiedz.RoundtripTime + "[ms]", odpowiedz.Options.Ttl, odpowiedz.Buffer.Length, "AKTYWNY");
                            Console.WriteLine("______________________________________________________________________________________________________");
                            Console.WriteLine("\n" + o);
                            Console.ForegroundColor = ConsoleColor.White;
                            if (odpowiedz2.Status == IPStatus.Success)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                string o2 = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", "-", "-", adres2, odpowiedz.RoundtripTime + "[ms]", odpowiedz.Options.Ttl, odpowiedz.Buffer.Length, "AKTYWNY");
                                Console.WriteLine("______________________________________________________________________________________________________");
                                Console.WriteLine("\n" + o2);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                string ob1 = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", "-", "-", adres2, "-", "-", "LAN", "NIEOSIĄGALNY");
                                Console.WriteLine("______________________________________________________________________________________________________");
                                Console.WriteLine("\n" + ob1);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            string o = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", pos.Id, pos.Nazwa, adres, "/", "/", "/", "NIEOSIĄGALNY");
                            Console.WriteLine("______________________________________________________________________________________________________");
                            Console.WriteLine("\n" + o);
                            Console.WriteLine("Błąd: " + odpowiedz.Status.ToString() + " " + "BRAK KOMUNIKACJI Z HOSTEM!!!!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Błąd:" + adres + " " + ex.Message);
                    }

                }

            }
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }

        }
        public Pozycja PingStalyPoID(int id)
        {
            Pozycja result = null;
            foreach (Pozycja pos in poz)
            {
                if (pos.Id == id)
                {
                    
                    do
                    {
                        Console.WriteLine("Naciśnij spację, aby przerwać.");
                        while (!Console.KeyAvailable)
                        {
                            
                            Ping ping = new Ping();
                            string adres = pos.Adres;
                            string adres2 = pos.AdresLan;
                            int timeout = 1200;
                            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                            byte[] bufor = Encoding.ASCII.GetBytes(data);
                            PingOptions opcje = new PingOptions();
                            opcje.DontFragment = true;

                            try
                            {

                                PingReply odpowiedz = ping.Send(adres, timeout, bufor, opcje);
                                PingReply odpowiedz2 = ping.Send(adres2, timeout, bufor, opcje);



                                if (odpowiedz.Status == IPStatus.Success)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    string o = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", pos.Id, pos.Nazwa, adres, odpowiedz.RoundtripTime + "[ms]", odpowiedz.Options.Ttl, odpowiedz.Buffer.Length, "AKTYWNY");
                                    Console.WriteLine("______________________________________________________________________________________________________");
                                    Console.WriteLine("\n" + o);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    if (odpowiedz2.Status == IPStatus.Success)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        string o2 = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", "-", "-", adres2, odpowiedz.RoundtripTime + "[ms]", odpowiedz.Options.Ttl, odpowiedz.Buffer.Length, "AKTYWNY");
                                        Console.WriteLine("______________________________________________________________________________________________________");
                                        Console.WriteLine("\n" + o2);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        string ob1 = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", "-", "-", adres2, "-", "-", "LAN", "NIEOSIĄGALNY");
                                        Console.WriteLine("______________________________________________________________________________________________________");
                                        Console.WriteLine("\n" + ob1);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    string o = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", pos.Id, pos.Nazwa, adres, "/", "/", "/", "NIEOSIĄGALNY");
                                    Console.WriteLine("______________________________________________________________________________________________________");
                                    Console.WriteLine("\n" + o);
                                    Console.WriteLine("Błąd: " + odpowiedz.Status.ToString() + " " + "BRAK KOMUNIKACJI Z HOSTEM!!!!\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine("Błąd:" + adres + " " + ex.Message);
                            }
                        }
                    }
                     
                    while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
                } 

            }
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }

        }
        public void PingujWszystkie()
        {
            foreach (Pozycja pos in poz)
            {
                PingHostaPoID(pos.Id);
            }
        }
        public Pozycja ZnajdzPozycjePoID(int id)
        {
            Pozycja result = null;
            foreach (Pozycja pos in poz)
            {
                if (pos.Id == id)
                {
                    result = pos;
                    break;
                }
            }
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
        
          
        public void WypiszWszystkiePozycje()
        {
            

            foreach (Pozycja pos in poz)
            {
                
                Console.WriteLine("\n");
                string n = string.Format("|{0,5}|{1,35}|{2,25}|{3,35}|", pos.Id, pos.Nazwa, pos.Adres, pos.Rola);
                string n2 = string.Format("|{0,5}|{1,35}|{2,25}|{3,35}|", "", "", pos.AdresLan, "");
                Console.WriteLine(n);
                Console.WriteLine(n2);
                Console.WriteLine("______________________________________________________________________________________________________");




            }


        }

        public void WszystkiePosortowane(){
           
            IEnumerable<Pozycja> query = poz.OrderBy(poz => poz.Id);
            foreach (Pozycja pos in query)
            {
                Console.WriteLine("\n");
                string n = string.Format("|{0,5}|{1,35}|{2,25}|{3,35}|", pos.Id, pos.Nazwa, pos.Adres, pos.Rola);
                string n2 = string.Format("|{0,5}|{1,35}|{2,25}|{3,35}|", "", "", pos.AdresLan, "");
                Console.WriteLine(n);
                Console.WriteLine(n2);
                Console.WriteLine("______________________________________________________________________________________________________");
            }
        }

        public void ExportData()
        {
            // using StreamWriter plik = new StreamWriter("C:/Users/lenovo/Desktop/data.csv");
            IEnumerable<Pozycja> qexport = poz.OrderBy(poz => poz.Id);
            
            
            string data = "C:/Users/lenovo/Desktop/data"+DateTime.Now.ToString("yyyyMMddTHHmmss")+".csv";
            foreach (Pozycja pos in qexport)

            {
                string wartosci = (pos.Id.ToString() + "," + pos.Nazwa.ToString() + "," + pos.Adres.ToString() + "," + pos.AdresLan.ToString() + "," + pos.Rola.ToString()+ Environment.NewLine);


                if (!File.Exists(data))
                {
                    string naglowek = "ID" + "," + "NAZWA" + "," + "ADRES SAT" +","+ "ADRES LAN" + "\n";
                    File.WriteAllText(data, naglowek);
                }
                File.AppendAllText(data, wartosci);
            }

            
        }
        public static int licznikMaster = 0;

        public void LicznikMaster()
        {
            foreach (Pozycja pos in poz)
            {
                if (pos.Rola == "Master")
                {
                    licznikMaster = poz.Count();
                    Console.WriteLine(licznikMaster);
                }
            }
        }
        
        public void ExportDataAuto()
        {
            // using StreamWriter plik = new StreamWriter("C:/Users/lenovo/Desktop/data.csv");
            IEnumerable<Pozycja> aexport = poz.OrderBy(poz => poz.Id);
            

            string dataW = "C:/Users/lenovo/Desktop/wejsciowe.csv";
            
            foreach (Pozycja pos in aexport)
                

            {
               

                string wartosci = (pos.Id.ToString() + "," + pos.Nazwa.ToString() + "," + pos.Adres.ToString() + "," + pos.AdresLan.ToString() + "," + pos.Rola.ToString() + Environment.NewLine);


                if (!File.Exists(dataW))
                {
                    string naglowek = "ID" + "," + "NAZWA" + "," + "ADRES SAT" + "," + "ADRES LAN" + ","+"ROLA"+Environment.NewLine;
                    File.WriteAllText(dataW, naglowek);
                }
                File.AppendAllText(dataW, wartosci);
               
            }

            


        }

      
















    }
}
