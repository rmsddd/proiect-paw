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
    internal partial class Form3 : Form
    {
        private GestiuneStoc gestiune;
        private bool isDragging = false;
        private int dragIndex = -1;
        private Point dragStartPoint;

        internal Form3(GestiuneStoc g)
        {
            try
            {
                InitializeComponent();
                gestiune = g;

                foreach (Produs p in gestiune.Produse)
                    listaProduse.Items.Add(p.ToString());

                listaProduse.MouseDown += listaProduse_MouseDown;
                listaProduse.MouseMove += listaProduse_MouseMove;
                listaProduse.MouseUp += listaProduse_MouseUp;
                listaProduse.DragEnter += listaProduse_DragEnter;
                listaProduse.DragDrop += listaProduse_DragDrop;
                listaProduse.AllowDrop = true;

                listaSelectate.MouseDown += listaSelectate_MouseDown;
                listaSelectate.DragEnter += listaSelectate_DragEnter;
                listaSelectate.DragDrop += listaSelectate_DragDrop;
                listaSelectate.AllowDrop = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void listaProduse_MouseDown(object sender, MouseEventArgs e)
        {
            int index = listaProduse.IndexFromPoint(e.Location);
            if (index >= 0)
            {
                listaProduse.SelectedIndex = index;
                produsControl1.AfiseazaProdus(gestiune.Produse[index]);
                isDragging = true;
                dragIndex = index;
                dragStartPoint = e.Location;
            }
        }

        private void listaProduse_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Left && dragIndex >= 0)
            {
                if (Math.Abs(e.X - dragStartPoint.X) > 3 || Math.Abs(e.Y - dragStartPoint.Y) > 3)
                {
                    isDragging = false;
                    listaProduse.DoDragDrop(listaProduse.Items[dragIndex].ToString(), DragDropEffects.Copy);
                }
            }
        }

        private void listaProduse_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void listaProduse_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.Text) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void listaProduse_DragDrop(object sender, DragEventArgs e)
        {
            string item = e.Data.GetData(DataFormats.Text).ToString();
            listaSelectate.Items.Remove(item);
        }

        private void listaSelectate_MouseDown(object sender, MouseEventArgs e)
        {
            if (listaSelectate.SelectedItem != null)
                listaSelectate.DoDragDrop(listaSelectate.SelectedItem.ToString(), DragDropEffects.Move);
        }

        private void listaSelectate_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.Text) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void listaSelectate_DragDrop(object sender, DragEventArgs e)
        {
            string item = e.Data.GetData(DataFormats.Text).ToString();
            if (!listaSelectate.Items.Contains(item))
                listaSelectate.Items.Add(item);
            else
                MessageBox.Show("Produsul e deja selectat!");
        }

        private void btnCreeazaComanda_Click(object sender, EventArgs e)
        {
            if (listaSelectate.Items.Count == 0)
            {
                MessageBox.Show("Nu ai selectat niciun produs!");
                return;
            }

            Comanda comanda = new Comanda(
                gestiune.Comenzi.Count + 1,
                gestiune.Furnizori[0],
                DateTime.Now);

            foreach (string item in listaSelectate.Items)
            {
                foreach (Produs p in gestiune.Produse)
                {
                    if (item.Contains(p.Denumire))
                    {
                        comanda.AdaugaProdus(p);
                        break;
                    }
                }
            }

            gestiune.AdaugaComanda(comanda);
            MessageBox.Show("Comanda a fost creata cu " + listaSelectate.Items.Count + " produse!");
            listaSelectate.Items.Clear();
        }
    }
}