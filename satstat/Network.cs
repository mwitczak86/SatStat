using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;

namespace satstat
{
    public class Network : IZarzadzeniePozycjami
    {

        private string name { get; set; }
        public List<Katalog> kata = new List<Katalog>();
        public Network()
        {

        }

        public Network(string name_)
        {
            this.name = name_;
        }





        public void DodajPozycje(Pozycja pozycja, string typStacji_)
        {

            foreach (Katalog katalog in kata)
            {
                if (typStacji_ == katalog.TypStacji)
                {
                    katalog.DodajPozycje(pozycja);
                }
            }

        }
        public void DodajKatalog(Katalog katalog)
        {

            kata.Add(katalog);
        }

        public Pozycja ZnajdzPozycjePoNazwie(string nazwa)
        {
            Pozycja result = null;

            foreach (Katalog katalog in kata)
            {
                result = katalog.ZnajdzPozycjePoNazwie(nazwa);

                if (result != null)
                {
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

        public Pozycja ZnajdzPozycjePoID(int id)
        {
            Pozycja result = null;

            foreach (Katalog katalog in kata)
            {
                result = katalog.ZnajdzPozycjePoID(id);

                if (result != null)
                {
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
            foreach (Katalog katalog in kata)
            {
                result = katalog.PingHostaPoNazwie(nazwa);

                if (result != null)
                {
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

        public Pozycja PingHostaPoID(int id)
        {
            Pozycja result = null;

            foreach (Katalog katalog in kata)
            {
                result = katalog.PingHostaPoID(id);

                if (result != null)
                {
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

      

        public Pozycja PingStalyPoID(int id)
        {


            Pozycja result = null;

            foreach (Katalog katalog in kata)
            {
                result = katalog.PingStalyPoID(id);

                if (result != null)
                {
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________________________________________________");
            Console.WriteLine("\n Spis stacji znajdujących się w sieci: " + name + "\n");
            string f = string.Format("|{0,5}|{1,35}|{2,25}|{3,35}|", "ID", "NAZWA", "ADRES", "ROLA");
            Console.WriteLine("______________________________________________________________________________________________________");
            Console.WriteLine("\n" + f);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Katalog katalog in kata)
            {
                katalog.WypiszWszystkiePozycje();
            }


        }

       

        public void PingujWszystkie()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n ********* Status stacji znajdujących się w sieci: *******************" + "\n");
            string f = string.Format("|{0,5}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}|{6,15}|", "ID", "NAZWA", "ADRES", "CZAS", "TTL", "BAJTÓW", "STATUS");
            Console.WriteLine("\n" + f);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Katalog katalog in kata)
            {
                katalog.PingujWszystkie();
            }


        }

        public void WszystkiePosortowane()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n ********* Wykaz wszystkich stacji znajdujących się w sieci:  " + name + " *******************" + "\n");
            string f = string.Format("|{0,5}|{1,35}|{2,25}|{3,35}|", "ID", "NAZWA", "ADRES", "ROLA");
            Console.WriteLine("\n" + f);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Katalog katalog in kata)
            {
                katalog.WszystkiePosortowane();
            }


        }

        public void ExportData()
        {
            foreach (Katalog katalog in kata)
            {

                katalog.ExportData();
            }
        }

        public void ExportDataAuto()
        {
            foreach (Katalog katalog in kata)
            {

                katalog.ExportDataAuto();
            }
        }
    }
}

