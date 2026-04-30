using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_daczo_remus_1050
{
    internal class Operatii
    {
        internal class Operatie
        {
            private int idOperatie;
            private Produs produs;
            private string tipOperatie; 
            private int cantitate;
            private DateTime dataOperatie;

            public Operatie(int id, Produs p, string tip, int cant, DateTime data)
            {
                idOperatie = id;
                produs = p;
                tipOperatie = tip;
                cantitate = cant;
                dataOperatie = data;
            }

            public int IdOperatie
            {
                get { return idOperatie; }
                set { idOperatie = value; }
            }

            public Produs Produs
            {
                get { return produs; }
                set { produs = value; }
            }

            public string TipOperatie
            {
                get { return tipOperatie; }
                set { if (value == "Intrare" || value == "Iesire") tipOperatie = value; }
            }

            public int Cantitate
            {
                get { return cantitate; }
                set { if (value > 0) cantitate = value; }
            }

            public DateTime DataOperatie
            {
                get { return dataOperatie; }
                set { dataOperatie = value; } 
            }

            public void aplicaOperatie()
            {
                if (tipOperatie == "Intrare")
                {
                    produs.CantitateStoc += cantitate;
                }
                else if (tipOperatie == "Iesire")
                {
                    if (Produs.CantitateStoc >= cantitate)
                        Produs.CantitateStoc -= cantitate;
                    else
                        throw new Exception("Stoc insuficient!");
                }
            }

            public override string ToString()
            {
                return Produs.Denumire + " | " +
                       TipOperatie + " | " +
                       Cantitate + " | " +
                       DataOperatie.ToShortDateString();
            }

        }
    }
}
