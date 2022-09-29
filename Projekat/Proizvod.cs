using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    public class Proizvod
    {
        public int cena;
        public int kolicina;
        public int iD;
        public int iD_kat;
        public string naziv;      
        //public MesecnaProdaja meseci;
        public int u_korpi;

        public int Cena { get => cena; set => cena = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public int ID { get => iD; set => iD = value; }
        public int ID_kat { get => iD_kat; set => iD_kat = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public int U_korpi { get => u_korpi; set => u_korpi = value; }

        public Proizvod(int cena, int kolicina, int iD, int iD_kat, string naziv)
        {
            this.Cena = cena;
            this.Kolicina = kolicina;
            ID = iD;
            ID_kat = iD_kat;
            this.Naziv = naziv;
        }
        public Proizvod()
        {
            this.Cena = 0;
            this.Kolicina =1;
            ID = -1;
            ID_kat = -1;
            this.Naziv = "";
        }

        public override string ToString()
        {
            return Naziv + "," + Cena + " RSD"+" X "+kolicina;
        }
        public  string ToString2()
        {
            return Naziv + "," + Cena + " RSD" + " X " ;
        }
    }
}
