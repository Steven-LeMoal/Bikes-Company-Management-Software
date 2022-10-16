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

namespace veloMax.FormsMenu.Systeme
{
    public partial class User : Form
    {
        int ID = 0;

        public User()
        {
            InitializeComponent();
            DisplayData();
        }


        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            DisplayData();
            Clear();
        }

        private void Clear()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            userId.Text = "";
            username.Text = "";
            user_password.Text = "";
            user_type.Text = "";
        }

        private void DisplayData()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from Users;", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            DataTable cdt = dt.Clone();
            foreach (DataColumn column in cdt.Columns)
            {
                column.DataType = typeof(String);
            }
            foreach (DataRow row in dt.Rows)
            {
                cdt.ImportRow(row);
            }
            dgvUsers.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "Numéro de l'utilisateur", "Nom de compte", "Mot de passe", "Type d'utilisateur" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvUsers.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int index = comboBox1.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "userId", "username", "user_password", "user_type" };
                (dgvUsers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox1.Text);
            }
            else
            {
                DisplayData();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvUsers.Sort(dgvUsers.Columns[comboBox1.SelectedIndex], ListSortDirection.Ascending);
        }


        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvUsers.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    ID = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DataConnection connection = new DataConnection();

                    MySqlCommand command = new MySqlCommand("select * from Users WHERE userId=@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.openConnection();
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        userId.Text = data["userId"].ToString();
                        username.Text = data["username"].ToString();
                        user_password.Text = data["user_password"].ToString();
                        user_type.Text = data["user_type"].ToString();

                    }
                    //reader["user_password"].ToString()
                    connection.closeConnection();
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(user_password.Text) || String.IsNullOrEmpty(user_type.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide..");

            }
            else
            {
                int index = user_type.SelectedIndex;
                index = index == -1 ? 1 : index;
                string type = index == 0 ? "admin" : "normal";

                DataConnection connection = new DataConnection();
                connection.openConnection();
                //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                MySqlCommand command = new MySqlCommand("INSERT INTO `veloMax`.`Users` (`username`,`user_password`,`user_type`) VALUES (@a,@b,@c);", connection.Connection);
                command.Parameters.AddWithValue("@a", username.Text.Trim());
                command.Parameters.AddWithValue("@b", user_password.Text.Trim());
                command.Parameters.AddWithValue("@c", type);
                command.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Base de données mise à jour..");
                Clear();
                DisplayData();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(user_password.Text) || String.IsNullOrEmpty(user_type.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide..");

            }
            else
            {
                int index = user_type.SelectedIndex;
                index = index == -1 ? 1 : index;
                string type = index == 0 ? "admin" : "normal";

                DataConnection connection = new DataConnection();
                connection.openConnection();
                MySqlCommand command = new MySqlCommand("UPDATE `veloMax`.`Users` SET username=@a,user_password=@b,user_type=@c WHERE userId=@ID;", connection.Connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@a", username.Text.Trim());
                command.Parameters.AddWithValue("@b", user_password.Text.Trim());
                command.Parameters.AddWithValue("@c", type);
                command.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Base de données mise à jour..");
                Clear();
                DisplayData();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DataConnection connection = new DataConnection();
                MySqlCommand cmd = new MySqlCommand("delete from Users where userId=@id;", connection.Connection);
                connection.openConnection();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Suppression réussit!");
                DisplayData();
                ID = 0;
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une colonne!");
            }
        }

        

        private void userId_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
