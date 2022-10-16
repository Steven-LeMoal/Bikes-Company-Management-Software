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

namespace veloMax.FormsMenu.Clients
{
    public partial class Particuliers : Form
    {
        int ID = 0;

        public Particuliers(string user)
        {
            InitializeComponent();
            DisplayData();
            Clear();

            if (user.Equals("normal"))
            {
                //btnRafraichir.Visible = false;
                btnAjouter.Visible = false;
                btnModifier.Visible = false;
                btnSupprimer.Visible = false;
            }
        }

        private void DisplayData()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from Individu;", connection.Connection);
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
            string[] columns = { "ID. CLient", "Nom", "Prenom", "Adresse", "Telephone", "Courriel"};
            for (int i = 0; i < columns.Length; i++)
            {
                dgvUsers.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            idClient.Text = "";
            nom.Text = "";
            prenom.Text = "";
            adresse.Text = "";
            telephone.Text = "";
            courriel.Text = "";
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            DisplayData();
            Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvUsers.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    ID = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DataConnection connection = new DataConnection();

                    MySqlCommand command = new MySqlCommand("select * from Individu WHERE idClient=@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.openConnection();
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        idClient.Text = data["idClient"].ToString();
                        nom.Text = data["nom"].ToString();
                        prenom.Text = data["prenom"].ToString();
                        adresse.Text = data["adresse"].ToString();
                        telephone.Text = data["telephone"].ToString();
                        courriel.Text = data["courriel"].ToString();
                    }
                    //reader["user_password"].ToString()
                    connection.closeConnection();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvUsers.Sort(dgvUsers.Columns[comboBox1.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int index = comboBox1.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "idClient", "nom", "prenom", "adresse", "telephone", "courriel"};
                (dgvUsers.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox1.Text);
            }
            else
            {
                DisplayData();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DataConnection connection = new DataConnection();
                MySqlCommand cmd = new MySqlCommand("delete from Individu where idClient=@id;", connection.Connection);
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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nom.Text) || String.IsNullOrEmpty(prenom.Text) || String.IsNullOrEmpty(adresse.Text) || String.IsNullOrEmpty(telephone.Text) || String.IsNullOrEmpty(courriel.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide..");
            }
            else
            {

                DataConnection connection = new DataConnection();
                connection.openConnection();
                //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                MySqlCommand command = new MySqlCommand("INSERT INTO Individu (`nom`,`prenom`,`adresse`,`telephone`,`courriel`)  VALUES(@a,@b,@c,@d,@e);", connection.Connection);
                command.Parameters.AddWithValue("@a", nom.Text.Trim());
                command.Parameters.AddWithValue("@b", prenom.Text.Trim());
                command.Parameters.AddWithValue("@c", adresse.Text.Trim());
                command.Parameters.AddWithValue("@d", telephone.Text.Trim());
                command.Parameters.AddWithValue("@e", courriel.Text.Trim());
                command.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Base de données mise à jour..");
                Clear();
                DisplayData();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nom.Text) || String.IsNullOrEmpty(prenom.Text) || String.IsNullOrEmpty(adresse.Text) || String.IsNullOrEmpty(telephone.Text) || String.IsNullOrEmpty(courriel.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide..");
            }
            else
            {
                DataConnection connection = new DataConnection();
                connection.openConnection();
                MySqlCommand command = new MySqlCommand("UPDATE Individu SET nom=@a,prenom=@b,adresse=@c,telephone=@d,courriel=@e  WHERE idClient =@ID;", connection.Connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@a", nom.Text.Trim());
                command.Parameters.AddWithValue("@b", prenom.Text.Trim());
                command.Parameters.AddWithValue("@c", adresse.Text.Trim());
                command.Parameters.AddWithValue("@d", telephone.Text.Trim());
                command.Parameters.AddWithValue("@e", courriel.Text.Trim());
                command.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Base de données mise à jour..");
                Clear();
                DisplayData();
            }
        }

        private void prenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void nom_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
