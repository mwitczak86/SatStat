using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace satstat
{
    public class Host : Pozycja 
    {
        //protected string rodzaj { get; set; }

        //public Host()
        //{
        //    rodzaj = "brak danych";
        //}
       
        public Host(int id_, string adres_, string adresLAN_, string nazwa_, string rola_) : base(id_, adres_, adresLAN_, nazwa_, rola_)
        {

        }

        public Host(string importData)
        {
            string[] data = importData.Split(',');
            this.id = Convert.ToInt32(data[0]);
            this.nazwa = data[1];
            this.adres = data[2];
            this.adresLAN = data[3];
            this.rola = data[4];

        }


        
        










    }


}