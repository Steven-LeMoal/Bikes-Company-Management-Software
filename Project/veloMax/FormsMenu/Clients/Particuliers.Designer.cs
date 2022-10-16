
namespace veloMax.FormsMenu.Clients
{
    partial class Particuliers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.courriel = new System.Windows.Forms.TextBox();
            this.telephone = new System.Windows.Forms.TextBox();
            this.adresse = new System.Windows.Forms.TextBox();
            this.nom = new System.Windows.Forms.TextBox();
            this.prenom = new System.Windows.Forms.TextBox();
            this.idClient = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnRafraichir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1627, 784);
            this.panel5.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel6.Controls.Add(this.courriel);
            this.panel6.Controls.Add(this.telephone);
            this.panel6.Controls.Add(this.adresse);
            this.panel6.Controls.Add(this.nom);
            this.panel6.Controls.Add(this.prenom);
            this.panel6.Controls.Add(this.idClient);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(11, 152);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(465, 404);
            this.panel6.TabIndex = 10;
            // 
            // courriel
            // 
            this.courriel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courriel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.courriel.Location = new System.Drawing.Point(202, 321);
            this.courriel.MaxLength = 39;
            this.courriel.Name = "courriel";
            this.courriel.Size = new System.Drawing.Size(245, 29);
            this.courriel.TabIndex = 19;
            // 
            // telephone
            // 
            this.telephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telephone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.telephone.Location = new System.Drawing.Point(202, 264);
            this.telephone.MaxLength = 10;
            this.telephone.Name = "telephone";
            this.telephone.Size = new System.Drawing.Size(245, 29);
            this.telephone.TabIndex = 18;
            this.telephone.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // adresse
            // 
            this.adresse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adresse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.adresse.Location = new System.Drawing.Point(202, 202);
            this.adresse.MaxLength = 39;
            this.adresse.Name = "adresse";
            this.adresse.Size = new System.Drawing.Size(245, 29);
            this.adresse.TabIndex = 17;
            // 
            // nom
            // 
            this.nom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nom.Location = new System.Drawing.Point(202, 86);
            this.nom.MaxLength = 19;
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(245, 29);
            this.nom.TabIndex = 16;
            // 
            // prenom
            // 
            this.prenom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prenom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prenom.Location = new System.Drawing.Point(202, 142);
            this.prenom.MaxLength = 19;
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(245, 29);
            this.prenom.TabIndex = 9;
            this.prenom.TextChanged += new System.EventHandler(this.prenom_TextChanged);
            // 
            // idClient
            // 
            this.idClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.idClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idClient.Location = new System.Drawing.Point(202, 37);
            this.idClient.Name = "idClient";
            this.idClient.ReadOnly = true;
            this.idClient.Size = new System.Drawing.Size(245, 22);
            this.idClient.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(12, 37);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(169, 313);
            this.panel7.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(7, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Courriel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Telephone";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(7, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Adresse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(8, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Prenom";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(8, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "Nom";
            this.label13.Click += new System.EventHandler(this.nom_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(8, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Numéro du client";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.dgvUsers);
            this.panel4.Location = new System.Drawing.Point(514, 152);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1113, 521);
            this.panel4.TabIndex = 5;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            this.dgvUsers.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsers.RowTemplate.Height = 25;
            this.dgvUsers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(1113, 521);
            this.dgvUsers.TabIndex = 6;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1627, 104);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4600, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gestion des Pièces";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btnSupprimer);
            this.panel2.Controls.Add(this.btnModifier);
            this.panel2.Controls.Add(this.btnAjouter);
            this.panel2.Controls.Add(this.btnRafraichir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1627, 28);
            this.panel2.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Numero/Identifiant",
            "Nom",
            "Prenom",
            "Adresse",
            "Telephone",
            "Courriel"});
            this.comboBox1.Location = new System.Drawing.Point(1209, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 29);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(1368, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 28);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSupprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSupprimer.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSupprimer.FlatAppearance.BorderSize = 3;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSupprimer.Location = new System.Drawing.Point(357, 0);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(119, 28);
            this.btnSupprimer.TabIndex = 3;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnModifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnModifier.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnModifier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnModifier.FlatAppearance.BorderSize = 3;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModifier.Location = new System.Drawing.Point(238, 0);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(119, 28);
            this.btnModifier.TabIndex = 2;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAjouter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAjouter.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAjouter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAjouter.FlatAppearance.BorderSize = 3;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAjouter.Location = new System.Drawing.Point(119, 0);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(119, 28);
            this.btnAjouter.TabIndex = 1;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnRafraichir
            // 
            this.btnRafraichir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRafraichir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRafraichir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRafraichir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRafraichir.FlatAppearance.BorderSize = 3;
            this.btnRafraichir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRafraichir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRafraichir.Location = new System.Drawing.Point(0, 0);
            this.btnRafraichir.Name = "btnRafraichir";
            this.btnRafraichir.Size = new System.Drawing.Size(119, 28);
            this.btnRafraichir.TabIndex = 0;
            this.btnRafraichir.Text = "Rafraichir";
            this.btnRafraichir.UseVisualStyleBackColor = false;
            this.btnRafraichir.Click += new System.EventHandler(this.btnRafraichir_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1627, 64);
            this.panel3.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gestion des clients particuliers";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Particuliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 784);
            this.Controls.Add(this.panel5);
            this.Name = "Particuliers";
            this.Text = "Particuliers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox telephone;
        private System.Windows.Forms.TextBox adresse;
        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.TextBox prenom;
        private System.Windows.Forms.TextBox idClient;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnRafraichir;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox courriel;
        private System.Windows.Forms.Label label12;
    }
}