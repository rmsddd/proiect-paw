using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_daczo_remus_1050
{
    internal class Comanda
    {
        private int idComanda;
        private Furnizor furnizor;
        private DateTime dataComanda;
        private List<Produs> produseComanda;
        private string status;

        public Comanda(int id, Furnizor f, DateTime data)
        {
            idComanda = id;
            furnizor = f;
            dataComanda = data;
            produseComanda = new List<Produs>();
            status = "In asteptare";
        }

        public int IdComanda
        {
            get { return idComanda; }
            set { idComanda = value; }
        }

        public Furnizor Furnizor
        {
            get { return furnizor; }
            set { furnizor = value; }
        }

        public DateTime DataComanda
        {
            get { return dataComanda; }
            set { dataComanda = value; }
        }

        public List<Produs> ProduseComanda
        {
            get { return produseComanda; }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if (value == "In asteptare" || value == "Livrata" || value == "Anulata")
                    status = value;
            }
        }

        public void AdaugaProdus(Produs p)
        {
            produseComanda.Add(p);
        }

        public void LivrareComanda()
        {
            if (status == "In asteptare")
            {
                foreach (Produs p in produseComanda)
                    p.CantitateStoc += p.CantitateStoc;
                status = "Livrata";
            }
            else
            {
                throw new Exception("Comanda nu poate fi livrata!");
            }
        }

        public override string ToString()
        {
            return "Comanda: " + idComanda +
                   " | Furnizor: " + furnizor.Nume +
                   " | Data: " + dataComanda.ToShortDateString() +
                   " | Status: " + status;
        }
    }
}
