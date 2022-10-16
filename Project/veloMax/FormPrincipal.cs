using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veloMax
{
    public partial class FormPrincipal : Form
    {
        string user;
        public FormPrincipal(string username, string role)
        {
            InitializeComponent();
            CustomeDesign();
            userInfo.Text = "Utilisateur : " + username + Environment.NewLine + "Rôle : " + role;
            user = role;
            if (role.Equals("admin") == false)
            {
                btnSysteme.Visible = false;
            }

        }
        private void CustomeDesign()
        {
            panelProduitsSubMenu.Visible = false;
            panelClientsSubMenu.Visible = false;
            panelSystemeSubMenu.Visible = false;
        }

        private void CacherMenu()
        {
            if (panelProduitsSubMenu.Visible)
            {
                panelProduitsSubMenu.Visible = false;
            }
            if (panelClientsSubMenu.Visible)
            {
                panelClientsSubMenu.Visible = false;
            }
            if(panelSystemeSubMenu.Visible)
            {
                panelSystemeSubMenu.Visible = false;
            }
        }

        private void MontrerMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                CacherMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            //childForm.BringToFront();
            childForm.Show();
        }

        #region Menu Produits
        private void btnProduits_Click(object sender, EventArgs e)
        {
            MontrerMenu(panelProduitsSubMenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FomsMenu.Produits.Pieces(user));
            //..
            //Your code..
            //..
            CacherMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMenu.Produits.Modele(user));
            //..
            //Your code..
            //..
            CacherMenu();
        }

        private void btnFournisseur_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMenu.Stocks.Fournisseur(user));
            //..
            //Your code..
            //..
            CacherMenu();
        }

        #endregion

        #region Menu CLients
        private void btnClients_Click(object sender, EventArgs e)
        {
            MontrerMenu(panelClientsSubMenu);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMenu.Clients.Boutique(user));
            //..
            //Your code..
            //..
            CacherMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMenu.Clients.Particuliers(user));
            //..
            //Your code..
            //..
            CacherMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMenu.Clients.ProgrammeFidelite(user));
            //..
            //Your code..
            //..
            CacherMenu();
        }
        #endregion

        #region Menu Commandes
        private void btnCommandes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMenu.Commandes.Commandes(user));
        }

        #endregion

        #region Menu Statistiques
        private void btnStatistiques_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Statistique());
        }
        #endregion

        #region Menu Systeme
        private void btnSysteme_Click_1(object sender, EventArgs e)
        {
            MontrerMenu(panelSystemeSubMenu);
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            //..
            //Your code..
            //..
            CacherMenu();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMenu.Systeme.User());
            //..
            //Your code..
            //..
            CacherMenu();
        }
        #endregion

        #region Demo
        private void btnDemo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsMenu.Demo.Demo());
        }
        #endregion

        private void panelProduitsSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void user_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
