using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace satstat
{
    
    public interface IZarzadzeniePozycjami
    {
        public Pozycja ZnajdzPozycjePoNazwie(string nazwa);
        public Pozycja ZnajdzPozycjePoID(int id);
        public Pozycja PingHostaPoNazwie(string nazwa);
        public Pozycja PingHostaPoID(int id);

        public void ExportData();
        public void ExportDataAuto();
        public void WszystkiePosortowane();

        public void WypiszWszystkiePozycje();

    }
}

