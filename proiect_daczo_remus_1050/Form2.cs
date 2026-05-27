using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace proiect_daczo_remus_1050
{
    internal partial class Form2 : Form
    {
        private GestiuneStoc gestiune;

        public Form2(GestiuneStoc g)
        {
            InitializeComponent();
            gestiune = g;
            IncarcaGrafic();
        }

        private void IncarcaGrafic()
        {

            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add("Produse per categorie");

            Series serie = new Series("Categorii");
            serie.ChartType = SeriesChartType.Pie;


            Dictionary<string, int> categorii = gestiune.ProdusePerCategorie();

            foreach (var cat in categorii)
            {
                serie.Points.AddXY(cat.Key, cat.Value);
            }

            chart1.Series.Add(serie);
        }
    }
}
