using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class Kategorija
    {
        private int id;
        private string naziv;

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public Kategorija()
        {
            this.Id = 0;
            this.Naziv = "";
        }
    }
}
