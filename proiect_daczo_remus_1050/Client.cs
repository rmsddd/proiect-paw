using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_daczo_remus_1050
{
    internal class Client
    {
        private int idClient;
        private string nume;
        private string telefon;
        private List<Produs> produseAchizitionate;

        public Client(int id, string n, string tel)
        {
            idClient = id;
            nume = n;
            telefon = tel;
            produseAchizitionate = new List<Produs>();
        }

        public int IdClient
        {
            get { return idClient; }
            set { idClient = value; }
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

        public List<Produs> ProduseAchizitionate
        {
            get { return produseAchizitionate; }
        }

        public void AdaugaProdus(Produs p)
        {
            produseAchizitionate.Add(p);
        }

        public override string ToString()
        {
            return "Client: " + nume + " | Telefon: " + telefon;
        }
    }
}
