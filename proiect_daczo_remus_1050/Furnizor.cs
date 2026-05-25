using System;
using System.Collections.Generic;
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

        public Furnizor(int c, string n, string tel)
        {
            codFurnizor = c;
            nume = n;
            telefon = tel;
            produse = new List<Produs>();
        }

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
            string rezultat = "Furnizor: " + nume + "\n";
            rezultat += "Cod furnizor: " + codFurnizor + "\n";
            rezultat += "Telefonul furnizorului: " + telefon + "\n";
            rezultat += "Produse:\n";

            foreach (Produs p in produse)
            {
                rezultat += p.ToString() + "\n";
            }

            return rezultat;
        }

    }
}
