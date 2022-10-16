
namespace veloMax
{
    partial class Login
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.username = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.password = new System.Windows.Forms.TextBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::veloMax.Properties.Resources.icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(103, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(124)))), ((int)(((byte)(207)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.username);
            this.panel1.Controls.Add(this.iconPictureBox1);
            this.panel1.Location = new System.Drawing.Point(31, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 41);
            this.panel1.TabIndex = 2;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(124)))), ((int)(((byte)(207)))));
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.username.ForeColor = System.Drawing.Color.Silver;
            this.username.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.username.Location = new System.Drawing.Point(41, 4);
            this.username.Name = "username";
            this.username.PlaceholderText = "utilisateur";
            this.username.Size = new System.Drawing.Size(215, 29);
            this.username.TabIndex = 1;
            this.username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(124)))), ((int)(((byte)(207)))));
            this.iconPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(3, 4);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(124)))), ((int)(((byte)(207)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.password);
            this.panel2.Controls.Add(this.iconPictureBox2);
            this.panel2.Location = new System.Drawing.Point(31, 254);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 41);
            this.panel2.TabIndex = 3;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(124)))), ((int)(((byte)(207)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.password.ForeColor = System.Drawing.Color.Silver;
            this.password.Location = new System.Drawing.Point(41, 4);
            this.password.Name = "password";
            this.password.PlaceholderText = "mot de passe";
            this.password.Size = new System.Drawing.Size(215, 29);
            this.password.TabIndex = 1;
            this.password.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(124)))), ((int)(((byte)(207)))));
            this.iconPictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconPictureBox2.IconColor = System.Drawing.Color.White;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.Location = new System.Drawing.Point(3, 4);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox2.TabIndex = 0;
            this.iconPictureBox2.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.checkBox1.Location = new System.Drawing.Point(31, 318);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(124, 19);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Se rappeler de moi";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(177, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mot de passe oublié ?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(124)))), ((int)(((byte)(207)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(103, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "Connexion";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(327, 459);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox username;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox password;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}
