using System.IO;
using System.Linq.Expressions;
namespace proiect_daczo_remus_1050
{
    public partial class Form1 : Form
    {
        GestiuneStoc gestiune = new GestiuneStoc();
        public Form1()
        {
            InitializeComponent();
        }



        private void btnAdauga_Click(object sender, EventArgs e)
        {
            int cod;
            if (!int.TryParse(txtCodProdus.Text, out cod))
            {
                MessageBox.Show("Codul produsului trebuie sa fie numar");
                return;
            }


            if (gestiune.ExistaProdus(cod))
            {
                MessageBox.Show("Exista deja un produs cu acest cod!");
                return;
            }


            if (txtDenumire.Text == "")
            {
                MessageBox.Show("Completeaza denumirea produsului");
                return;
            }

            float pret;
            if (!float.TryParse(txtPret.Text, out pret))
            {
                MessageBox.Show("Pretul produsului trebuie sa fie numar");
                return;
            }

            int cantitate;
            if (!int.TryParse(txtCantitate.Text, out cantitate))
            {
                MessageBox.Show("Cantitatea produsului trebuie sa fie numar");
                return;
            }


            string denumire = txtDenumire.Text;
            string categorie = txtCategorie.Text;

            int codFurnizor;
            if (!int.TryParse(txtCodFurnizor.Text, out codFurnizor))
            {
                MessageBox.Show("Codul furnizorului trebuie sa fie numar");
                return;
            }
            string numeFurnizor = txtNumeFurnizor.Text;
            string telefon = txtTelFurnizor.Text;

            Furnizor f = new Furnizor(codFurnizor, numeFurnizor, telefon);
            gestiune.AdaugaFurnizor(f);


            Produs p = new Produs(cod, denumire, categorie, pret, cantitate, f);

            gestiune.AdaugaProdus(p);

            listaProduse.Items.Add(p.ToString());

            MessageBox.Show("Produsul a fost adaugat in stoc!");
        }

        private void btnAfiseaza_Click(object sender, EventArgs e)
        {
            if (gestiune.Produse.Count == 0)
            {
                MessageBox.Show("Nu exista produse in stoc!");
                return;
            }
            string mesaj = "";
            foreach (Produs p in gestiune.Produse)
            {
                mesaj += p.ToString() + "\n";
            }
            MessageBox.Show(mesaj);
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            try
            {
                gestiune.Salveaza("stoc.txt");
                MessageBox.Show("Datele au fost salvate!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIncarca_Click(object sender, EventArgs e)
        {
            if (!File.Exists("stoc.txt"))
            {
                MessageBox.Show("Fisierul nu exista!");
                return;
            }
            try
            {
                gestiune.Incarca("stoc.txt");
                listaProduse.Items.Clear();
                foreach (Produs p in gestiune.Produse)
                    listaProduse.Items.Add(p.ToString());
                MessageBox.Show("Datele au fost incarcate din fisier!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCodProdus.Text = "";
            txtDenumire.Text = "";
            txtCategorie.Text = "";
            txtPret.Text = "";
            txtCantitate.Text = "";

            txtCodFurnizor.Text = "";
            txtNumeFurnizor.Text = "";
            txtTelFurnizor.Text = "";

            listaProduse.Items.Clear();
            MessageBox.Show("Campurile au fost resetate!");
        }
    }
}
