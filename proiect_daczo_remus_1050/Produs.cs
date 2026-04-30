using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_daczo_remus_1050
{
    internal class Produs
    {
        private int codProdus;
        private string denumire;
        private string categorie;
        private float pret;
        private int cantitateStoc;


        public Produs(int cP, string d, string cat,float p,int cant) {
            codProdus = cP;
            denumire = d;
            categorie = cat;
            pret = p;
            cantitateStoc = cant;
        }

        public int CodMaterial
        {
            get { return codProdus; }
            set { codProdus = value; }
        }

        public string Denumire
        {
            get { return denumire; }
            set { denumire = value; }
        }

        public string Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        public float Pret
        {
            get { return pret; }
            set {if (value > 0) pret = value;}
        }

        public int CantitateStoc
        {
            get { return cantitateStoc; }
            set { if(value>=0) cantitateStoc = value;}
            
        }
        public void ModificaStoc(int cant, string tip)
        {
            if (tip == "Intrare")
                cantitateStoc += cant;
            else if (tip == "Iesire")
                cantitateStoc -= cant;
        }
        public override string ToString()
        {
            return "Denumirea este " + denumire + ", iar stocul este " + cantitateStoc;
        }

    }
}
