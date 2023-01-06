using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace satstat
{
    public abstract class Pozycja
    {
        protected string adres { get; set; }
        protected string adresLAN { get; set; }
       
        protected int id { get; set; }
       
        protected string nazwa { get; set; }
        protected string rola { get; set; }
       

        public string Adres
        {
            get { return adres; }

        }

        public string AdresLan
        {
            get { return adresLAN; }

        }

        public int Id
        {
            get { return id; }

        }


        public string Rola
        {
            get { return rola; }

        }


        public string Nazwa
        {
            get { return nazwa; }

        }

        public Pozycja()
        {
            nazwa = "brak danych";
            adres = "8.8.8.8";
            adresLAN = "brak danych";
            id = 0;
            rola = "brak danych";
        }
        public Pozycja(int id_,string adres_,string adresLAN_, string nazwa_, string rola_)
        {
            id = id_;
            adres = adres_;
            adresLAN = adresLAN_;
            nazwa = nazwa_;
            rola = rola_;

            

        }

     

        public virtual void WypiszInfo()
    {

        Console.WriteLine($"=================================================");
        Console.WriteLine($"{id} || {nazwa} || {rola} || ");
        Console.WriteLine($"---------------------------------------------------");
    }


}
}



