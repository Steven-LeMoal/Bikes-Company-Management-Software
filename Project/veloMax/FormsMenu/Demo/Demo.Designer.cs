
namespace veloMax.FormsMenu.Demo
{
    partial class Demo
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelvalue = new System.Windows.Forms.Label();
            this.labelenonce = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvProduit = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvFourni = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCumul = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnBoutique = new System.Windows.Forms.Button();
            this.btnParticulier = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduit)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFourni)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCumul)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.labelvalue);
            this.panel2.Controls.Add(this.labelenonce);
            this.panel2.Location = new System.Drawing.Point(69, 318);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 70);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // labelvalue
            // 
            this.labelvalue.AutoSize = true;
            this.labelvalue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelvalue.Location = new System.Drawing.Point(366, 28);
            this.labelvalue.Name = "labelvalue";
            this.labelvalue.Size = new System.Drawing.Size(16, 15);
            this.labelvalue.TabIndex = 1;
            this.labelvalue.Text = "...";
            // 
            // labelenonce
            // 
            this.labelenonce.AutoSize = true;
            this.labelenonce.Location = new System.Drawing.Point(164, 28);
            this.labelenonce.Name = "labelenonce";
            this.labelenonce.Size = new System.Drawing.Size(155, 15);
            this.labelenonce.TabIndex = 0;
            this.labelenonce.Text = "Le nombre de client est de : ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.dgvProduit);
            this.panel3.Location = new System.Drawing.Point(69, 424);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(698, 390);
            this.panel3.TabIndex = 2;
            // 
            // dgvProduit
            // 
            this.dgvProduit.AllowUserToAddRows = false;
            this.dgvProduit.AllowUserToDeleteRows = false;
            this.dgvProduit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvProduit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduit.Location = new System.Drawing.Point(0, 0);
            this.dgvProduit.Name = "dgvProduit";
            this.dgvProduit.ReadOnly = true;
            this.dgvProduit.RowTemplate.Height = 25;
            this.dgvProduit.Size = new System.Drawing.Size(698, 390);
            this.dgvProduit.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this.dgvFourni);
            this.panel4.Location = new System.Drawing.Point(903, 424);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(698, 390);
            this.panel4.TabIndex = 3;
            // 
            // dgvFourni
            // 
            this.dgvFourni.AllowUserToAddRows = false;
            this.dgvFourni.AllowUserToDeleteRows = false;
            this.dgvFourni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFourni.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvFourni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFourni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFourni.Location = new System.Drawing.Point(0, 0);
            this.dgvFourni.Name = "dgvFourni";
            this.dgvFourni.ReadOnly = true;
            this.dgvFourni.RowTemplate.Height = 25;
            this.dgvFourni.Size = new System.Drawing.Size(698, 390);
            this.dgvFourni.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(73, 43);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(694, 85);
            this.panel5.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenue sur le mode démo, veuillez cliquer sur le bouton Suivant pour afficher " +
    "la présentation démo";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.dgvCumul);
            this.panel1.Location = new System.Drawing.Point(903, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 345);
            this.panel1.TabIndex = 5;
            // 
            // dgvCumul
            // 
            this.dgvCumul.AllowUserToAddRows = false;
            this.dgvCumul.AllowUserToDeleteRows = false;
            this.dgvCumul.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCumul.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvCumul.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCumul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCumul.Location = new System.Drawing.Point(0, 0);
            this.dgvCumul.Name = "dgvCumul";
            this.dgvCumul.ReadOnly = true;
            this.dgvCumul.RowTemplate.Height = 25;
            this.dgvCumul.Size = new System.Drawing.Size(698, 345);
            this.dgvCumul.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.btnSuivant);
            this.panel6.Location = new System.Drawing.Point(73, 151);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(315, 131);
            this.panel6.TabIndex = 6;
            // 
            // btnSuivant
            // 
            this.btnSuivant.BackColor = System.Drawing.Color.Silver;
            this.btnSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuivant.Location = new System.Drawing.Point(68, 34);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(179, 60);
            this.btnSuivant.TabIndex = 0;
            this.btnSuivant.Text = "Suivant";
            this.btnSuivant.UseVisualStyleBackColor = false;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel7.Controls.Add(this.btnExport);
            this.panel7.Location = new System.Drawing.Point(425, 154);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(341, 127);
            this.panel7.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Silver;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(81, 33);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(179, 60);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export des stocks <= 20 : XML";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel8.Controls.Add(this.btnBoutique);
            this.panel8.Controls.Add(this.btnParticulier);
            this.panel8.Location = new System.Drawing.Point(800, 43);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(79, 345);
            this.panel8.TabIndex = 8;
            // 
            // btnBoutique
            // 
            this.btnBoutique.BackColor = System.Drawing.Color.Silver;
            this.btnBoutique.Location = new System.Drawing.Point(3, 189);
            this.btnBoutique.Name = "btnBoutique";
            this.btnBoutique.Size = new System.Drawing.Size(73, 143);
            this.btnBoutique.TabIndex = 1;
            this.btnBoutique.Text = "Boutique";
            this.btnBoutique.UseVisualStyleBackColor = false;
            this.btnBoutique.Click += new System.EventHandler(this.btnBoutique_Click);
            // 
            // btnParticulier
            // 
            this.btnParticulier.BackColor = System.Drawing.Color.Silver;
            this.btnParticulier.Location = new System.Drawing.Point(3, 15);
            this.btnParticulier.Name = "btnParticulier";
            this.btnParticulier.Size = new System.Drawing.Size(73, 143);
            this.btnParticulier.TabIndex = 0;
            this.btnParticulier.Text = "Particulier";
            this.btnParticulier.UseVisualStyleBackColor = false;
            this.btnParticulier.Click += new System.EventHandler(this.btnParticulier_Click);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1662, 861);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "Demo";
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.Demo_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduit)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFourni)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCumul)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvProduit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvFourni;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCumul;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label labelvalue;
        private System.Windows.Forms.Label labelenonce;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnBoutique;
        private System.Windows.Forms.Button btnParticulier;
    }
}