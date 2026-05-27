namespace proiect_daczo_remus_1050
{
    partial class ProdusControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblPret = new Label();
            lblCod = new Label();
            lblDenumire = new Label();
            lblCategorie = new Label();
            lblCantitate = new Label();
            lblFurnizor = new Label();
            labelPRICE = new Label();
            SuspendLayout();
            // label1 - "Cod produs:"
            label1.AutoSize = true;
            label1.Location = new Point(25, 18);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Cod produs:";
            // label2 - "Denumire:"
            label2.AutoSize = true;
            label2.Location = new Point(25, 43);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 1;
            label2.Text = "Denumire:";
            // label3 - "Categorie:"
            label3.AutoSize = true;
            label3.Location = new Point(25, 68);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Categorie:";
            // label4 - "Pret:"
            label4.AutoSize = true;
            label4.Location = new Point(25, 93);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 3;
            label4.Text = "Pret:";
            label4.Click += label4_Click;
            // label5 - neutilizat
            label5.AutoSize = true;
            label5.Location = new Point(25, 0);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 4;
            label5.Visible = false;
            // label6 - "Cantitate:"
            label6.AutoSize = true;
            label6.Location = new Point(25, 118);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 5;
            label6.Text = "Cantitate:";
            // lblPret - titlul "Furnizor:"
            lblPret.AutoSize = true;
            lblPret.Location = new Point(25, 143);
            lblPret.Name = "lblPret";
            lblPret.Size = new Size(56, 15);
            lblPret.TabIndex = 6;
            lblPret.Text = "Furnizor:";
            // lblCod - valoare cod
            lblCod.AutoSize = true;
            lblCod.Location = new Point(110, 18);
            lblCod.Name = "lblCod";
            lblCod.Size = new Size(0, 15);
            lblCod.TabIndex = 7;
            // lblDenumire - valoare denumire
            lblDenumire.AutoSize = true;
            lblDenumire.Location = new Point(110, 43);
            lblDenumire.Name = "lblDenumire";
            lblDenumire.Size = new Size(0, 15);
            lblDenumire.TabIndex = 8;
            // lblCategorie - valoare categorie
            lblCategorie.AutoSize = true;
            lblCategorie.Location = new Point(110, 68);
            lblCategorie.Name = "lblCategorie";
            lblCategorie.Size = new Size(0, 15);
            lblCategorie.TabIndex = 9;
            // lblCantitate - valoare cantitate
            lblCantitate.AutoSize = true;
            lblCantitate.Location = new Point(110, 118);
            lblCantitate.Name = "lblCantitate";
            lblCantitate.Size = new Size(0, 15);
            lblCantitate.TabIndex = 11;
            // lblFurnizor - valoare furnizor
            lblFurnizor.AutoSize = true;
            lblFurnizor.Location = new Point(110, 143);
            lblFurnizor.Name = "lblFurnizor";
            lblFurnizor.Size = new Size(0, 15);
            lblFurnizor.TabIndex = 12;
            // labelPRICE - valoare pret
            labelPRICE.AutoSize = true;
            labelPRICE.Location = new Point(110, 93);
            labelPRICE.Name = "labelPRICE";
            labelPRICE.Size = new Size(0, 15);
            labelPRICE.TabIndex = 13;
            // ProdusControl
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelPRICE);
            Controls.Add(lblFurnizor);
            Controls.Add(lblCantitate);
            Controls.Add(lblCategorie);
            Controls.Add(lblDenumire);
            Controls.Add(lblCod);
            Controls.Add(lblPret);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ProdusControl";
            Size = new Size(256, 180);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblPret;
        private Label lblCod;
        private Label lblDenumire;
        private Label lblCategorie;
        private Label lblCantitate;
        private Label lblFurnizor;
        private Label labelPRICE;
    }
}