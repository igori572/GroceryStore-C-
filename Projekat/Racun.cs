using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class Racun
    {
        private int racunID;
        private int cena;
        private DateTime vreme;

        public Racun(int racunID, int cena, DateTime vreme)
        {
            this.RacunID = racunID;
            this.Cena = cena;
            this.Vreme = vreme;
        }

        public Racun()
        {
            this.racunID = 0;
            this.cena = 0;
            this.vreme = DateTime.MinValue;
        }

        public int RacunID { get => racunID; set => racunID = value; }
        public int Cena { get => cena; set => cena = value; }
        public DateTime Vreme { get => vreme; set => vreme = value; }
    }
}

