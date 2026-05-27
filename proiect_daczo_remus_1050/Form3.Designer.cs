namespace proiect_daczo_remus_1050
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            listaProduse = new ListBox();
            listaSelectate = new ListBox();
            label2 = new Label();
            label3 = new Label();
            btnCreeazaComanda = new Button();
            produsControl1 = new ProdusControl();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 99);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 0;
            label1.Text = "Produse disponibile";
            // 
            // listaProduse
            // 
            listaProduse.FormattingEnabled = true;
            listaProduse.ItemHeight = 15;
            listaProduse.Location = new Point(35, 136);
            listaProduse.Name = "listaProduse";
            listaProduse.Size = new Size(299, 94);
            listaProduse.TabIndex = 1;
            // 
            // listaSelectate
            // 
            listaSelectate.FormattingEnabled = true;
            listaSelectate.ItemHeight = 15;
            listaSelectate.Location = new Point(455, 136);
            listaSelectate.Name = "listaSelectate";
            listaSelectate.Size = new Size(320, 94);
            listaSelectate.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(560, 99);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 3;
            label2.Text = "Produse selectate";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(198, 28);
            label3.Name = "label3";
            label3.Size = new Size(412, 25);
            label3.TabIndex = 4;
            label3.Text = "Creare comanda din produsele existente in stoc";
            // 
            // btnCreeazaComanda
            // 
            btnCreeazaComanda.Location = new Point(307, 297);
            btnCreeazaComanda.Name = "btnCreeazaComanda";
            btnCreeazaComanda.Size = new Size(169, 23);
            btnCreeazaComanda.TabIndex = 5;
            btnCreeazaComanda.Text = "Creeaza comanda";
            btnCreeazaComanda.UseVisualStyleBackColor = true;
            btnCreeazaComanda.Click += btnCreeazaComanda_Click;
            // 
            // produsControl1
            // 
            produsControl1.Location = new Point(519, 249);
            produsControl1.Name = "produsControl1";
            produsControl1.Size = new Size(269, 189);
            produsControl1.TabIndex = 6;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(produsControl1);
            Controls.Add(btnCreeazaComanda);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listaSelectate);
            Controls.Add(listaProduse);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Creare comanda";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listaProduse;
        private ListBox listaSelectate;
        private Label label2;
        private Label label3;
        private Button btnCreeazaComanda;
        private ProdusControl produsControl1;
    }
}