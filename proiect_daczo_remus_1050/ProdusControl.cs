using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect_daczo_remus_1050
{
    internal partial class ProdusControl : UserControl
    {
        public ProdusControl()
        {
            InitializeComponent();
        }

        public void AfiseazaProdus(Produs p)
        {
            if (p == null)
            {
                lblCod.Text = "";
                lblDenumire.Text = "";
                lblCategorie.Text = "";
                labelPRICE.Text = "";
                lblCantitate.Text = "";
                lblFurnizor.Text = "";
                return;
            }

            lblCod.Text = p.CodProdus.ToString();
            lblDenumire.Text = p.Denumire;
            lblCategorie.Text = p.Categorie;
            labelPRICE.Text = p.Pret.ToString();
            lblCantitate.Text = p.CantitateStoc.ToString();
            lblFurnizor.Text = p.Furnizor != null ? p.Furnizor.Nume : "N/A";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
