using System.IO;
using System.Linq.Expressions;
using System.Drawing.Printing;
using Microsoft.EntityFrameworkCore;
namespace proiect_daczo_remus_1050
{
    public partial class Form1 : Form
    {
        GestiuneStoc gestiune = new GestiuneStoc();
        public Form1()
        {
            InitializeComponent();
            listaProduse.SelectedIndexChanged += listaProduse_SelectedIndexChanged;
           
        }


        private void listaProduse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaProduse.SelectedIndex >= 0)
            {
                Produs p = gestiune.Produse[listaProduse.SelectedIndex];
                ProdusControl pc = (ProdusControl)this.Controls["produsControl1"];
                pc.AfiseazaProdus(p);
            }
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

        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSalveaza_Click(sender, e);
        }

        private void incarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnIncarca_Click(sender, e);
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adaugaProdusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdauga_Click(sender, e);
        }



        private void afiseazaDetaliiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listaProduse.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza un produs din lista!");
                return;
            }

            int index = listaProduse.SelectedIndex;
            Produs p = gestiune.Produse[index];
            MessageBox.Show(p.ToString());
        }

        private void stergeProdusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listaProduse.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza un produs din lista!");
                return;
            }

            int index = listaProduse.SelectedIndex;
            Produs p = gestiune.Produse[index];
            gestiune.StergeProdusDupaCod(p.CodProdus);
            listaProduse.Items.RemoveAt(index);
            MessageBox.Show("Produsul a fost sters!");
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }



        private void graficeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(gestiune);
            f2.Show();
        }



        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            float y = 50;
            float x = 50;
            Font font = new Font("Arial", 10);
            Font fontTitlu = new Font("Arial", 14, FontStyle.Bold);

            // Titlu
            e.Graphics.DrawString("LISTA PRODUSE DIN STOC", fontTitlu, Brushes.Black, x, y);
            y += 30;

            // Data
            e.Graphics.DrawString("Data: " + DateTime.Now.ToShortDateString(), font, Brushes.Black, x, y);
            y += 30;

            // Linie separator
            e.Graphics.DrawLine(Pens.Black, x, y, 750, y);
            y += 20;

            // Produse
            foreach (Produs p in gestiune.Produse)
            {
                string linie = "Cod: " + p.CodProdus +
                               " | Denumire: " + p.Denumire +
                               " | Categorie: " + p.Categorie +
                               " | Pret: " + p.Pret +
                               " | Cantitate: " + p.CantitateStoc;
                e.Graphics.DrawString(linie, font, Brushes.Black, x, y);
                y += 25;
            }
            // Linie separator final
            e.Graphics.DrawLine(Pens.Black, x, y, 750, y);
            y += 20;

            // Valoare totala
            e.Graphics.DrawString(
                "Valoare totala stoc: " + gestiune.ValoareTotalaStoc() + " lei",
                fontTitlu, Brushes.Black, x, y);
        }


        private void imprimareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gestiune.Produse.Count == 0)
            {
                MessageBox.Show("Nu exista produse de imprimat!");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void valoareStocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gestiune.Produse.Count == 0)
            {
                MessageBox.Show("Nu exista produse in stoc!");
                return;
            }

            float valoare = gestiune.ValoareTotalaStoc();
            MessageBox.Show("Valoarea totala a stocului este: " + valoare + " lei");
        }

        private void operatiiStocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gestiune.Produse.Count == 0)
            {
                MessageBox.Show("Nu exista produse in stoc!");
                return;
            }
            try
            {
                Form3 f3 = new Form3(gestiune);
                f3.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare Form3: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (StocContext db = new StocContext())
                {
                    db.Database.EnsureCreated();

                    foreach (Produs p in gestiune.Produse)
                    {
                        if (db.Produse.Find(p.CodProdus) == null)
                            db.Produse.Add(p);
                    }

                    foreach (Furnizor f in gestiune.Furnizori)
                    {
                        if (db.Furnizori.Find(f.CodFurnizor) == null)
                            db.Furnizori.Add(f);
                    }

                    db.SaveChanges();
                    MessageBox.Show("Datele au fost salvate in baza de date!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (StocContext db = new StocContext())
                {
                    gestiune = new GestiuneStoc();
                    listaProduse.Items.Clear();

                    foreach (Furnizor f in db.Furnizori)
                        gestiune.AdaugaFurnizor(f);

                    foreach (Produs p in db.Produse.Include(x => x.Furnizor))
                    {
                        gestiune.AdaugaProdus(p);
                        string info = "Cod: " + p.CodProdus + " | " + p.Denumire + " | " + p.Categorie;
                        listaProduse.Items.Add(info);
                    }

                    MessageBox.Show("Datele au fost incarcate din baza de date!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }
    }
}
