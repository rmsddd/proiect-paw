using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_daczo_remus_1050
{
    internal class Furnizor
    {
        private int codFurnizor;
        private string nume;
        private string telefon;
        private List<Produs> produse;


        public Furnizor() { }
        public Furnizor(int c, string n, string tel)
        {
            codFurnizor = c;
            nume = n;
            telefon = tel;
            produse = new List<Produs>();
        }

        [Key]
        public int CodFurnizor
        {
            get { return codFurnizor; }
            set { codFurnizor = value; }
        }

        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public List<Produs> Produse
        {
            get { return produse; }
        }

        public override string ToString()
        {
            return "Furnizor: " + nume + " | Cod: " + codFurnizor + " | Tel: " + telefon;
        }

    }
}
