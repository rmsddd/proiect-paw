using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_daczo_remus_1050
{
    internal class GestiuneStoc
    {
        private List<Produs> produse;
        private List<Furnizor> furnizori;
        private List<Client> clienti;
        private List<Comanda> comenzi;

        public GestiuneStoc()
        {
            produse = new List<Produs>();
            furnizori = new List<Furnizor>();
            clienti = new List<Client>();
            comenzi = new List<Comanda>();
        }

        public List<Produs> Produse { get { return produse; } }
        public List<Furnizor> Furnizori { get { return furnizori; } }

        public void AdaugaProdus(Produs p)
        {
            produse.Add(p);
        }

        public bool ExistaProdus(int codProdus)
        {
            foreach (Produs p in produse)
                if (p.CodProdus == codProdus)
                    return true;
            return false;
        }


        public Produs GasesteProdus(int codProdus)
        {
            foreach (Produs p in produse)
                if (p.CodProdus == codProdus)
                    return p;
            return null;
        }
        public void StergeProdusDupaCod(int codProdus)
        {
            Produs p = GasesteProdus(codProdus);
            if (p != null)
                produse.Remove(p);
        }
        public Furnizor GasesteFurnizor(int codFurnizor)
        {
            foreach (Furnizor f in furnizori)
                if (f.CodFurnizor == codFurnizor)
                    return f;
            return null;
        }
        public void AdaugaFurnizor(Furnizor f)
        {
            if (GasesteFurnizor(f.CodFurnizor) == null)
                furnizori.Add(f);
        }

        public void Salveaza(string numeFisier)
        {
            try
            {
                StreamWriter sw = new StreamWriter(numeFisier);
                foreach (Produs p in produse)
                {
                    sw.WriteLine(
                        p.CodProdus + ";" +
                        p.Denumire + ";" +
                        p.Categorie + ";" +
                        p.Pret.ToString(System.Globalization.CultureInfo.InvariantCulture) + ";" +
                        p.CantitateStoc + ";" +
                        p.Furnizor.CodFurnizor + ";" +
                        p.Furnizor.Nume + ";" +
                        p.Furnizor.Telefon
                    );
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare la salvare: " + ex.Message);
            }
        }

        public void Incarca(string numeFisier)
        {
            try
            {
                produse.Clear();
                furnizori.Clear();

                string[] linii = File.ReadAllLines(numeFisier);
                foreach (string linie in linii)
                {
                    string[] v = linie.Split(';');

                    int codProdus = int.Parse(v[0]);
                    string denumire = v[1];
                    string categorie = v[2];
                    float pret = float.Parse(v[3], System.Globalization.CultureInfo.InvariantCulture);
                    int cantitate = int.Parse(v[4]);
                    int codFurnizor = int.Parse(v[5]);
                    string numeFurniz = v[6];
                    string telefon = v[7];

                    Furnizor f = GasesteFurnizor(codFurnizor);
                    if (f == null)
                    {
                        f = new Furnizor(codFurnizor, numeFurniz, telefon);
                        furnizori.Add(f);
                    }

                    Produs p = new Produs(codProdus, denumire, categorie, pret, cantitate, f);
                    produse.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare la incarcare: " + ex.Message);
            }
        }

        public float ValoareTotalaStoc()
        {
            float total = 0;
            foreach (Produs p in produse)
                total += p.Pret * p.CantitateStoc;
            return total;
        }

        public Dictionary<string, int> ProdusePerCategorie()
        {
            Dictionary<string, int> rezultat = new Dictionary<string, int>();
            foreach (Produs p in produse)
            {
                if (rezultat.ContainsKey(p.Categorie))
                    rezultat[p.Categorie]++;
                else
                    rezultat[p.Categorie] = 1;
            }
            return rezultat;
        }

        public void AdaugaClient(Client c)
        {
            clienti.Add(c);
        }

        public void AdaugaComanda(Comanda c)
        {
            comenzi.Add(c);
        }

        public Client GasesteClient(int idClient)
        {
            foreach (Client c in clienti)
                if (c.IdClient == idClient)
                    return c;
            return null;
        }

    }
}
