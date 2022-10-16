using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace veloMax
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataConnection connection = new DataConnection();

            MySqlCommand command = new MySqlCommand("select username,user_password,user_type from Users WHERE username =@Name AND user_password =@Password", connection.Connection);
            command.Parameters.AddWithValue("@Name", username.Text);
            command.Parameters.AddWithValue("@Password", password.Text);
            connection.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                if(username.Text.Equals(reader["username"].ToString()) && password.Text.Equals(reader["user_password"].ToString()))
                {
                    FormPrincipale(reader["username"].ToString(), reader["user_type"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Connexion refusée", "Connexion", MessageBoxButtons.OK);
            }
            connection.closeConnection();


        }

        private void FormPrincipale(string user,string role)
        {
            this.Hide();
            FormPrincipal form = new FormPrincipal(user,role);
            form.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Veuillez envoyer un message à l'administrateur ...", "Mot de passe oubliée", MessageBoxButtons.OK);
        }

        #region Inutile
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
