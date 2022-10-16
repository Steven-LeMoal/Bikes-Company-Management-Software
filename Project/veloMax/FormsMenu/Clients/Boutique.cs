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
    public partial class Boutique : Form
    {
        int ID = 0;
        public Boutique(string user)
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

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            DisplayData();
            Clear();
        }

        private void DisplayData()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from BoutiqueSpecialise;", connection.Connection);
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
            dgvBoutique.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "ID. Boutique", "Nom compagnie", "Adresse", "Telephone", "Courriel", "Nom du Contact" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvBoutique.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            idBoutique.Text = "";
            nomCompagnie.Text = "";
            adresse.Text = "";
            telephone.Text = "";
            courriel.Text = "";
            nomContact.Text = "";
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nomCompagnie.Text) || String.IsNullOrEmpty(adresse.Text) || String.IsNullOrEmpty(telephone.Text) || String.IsNullOrEmpty(courriel.Text) || String.IsNullOrEmpty(nomContact.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide..");
            }
            else
            {

                DataConnection connection = new DataConnection();
                connection.openConnection();
                //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                MySqlCommand command = new MySqlCommand("INSERT INTO BoutiqueSpecialise (`nomCompagnie`,`adresse`,`telephone`,`courriel`,`nomContact`)  VALUES(@a,@b,@c,@d,@e);", connection.Connection);
                command.Parameters.AddWithValue("@a", nomCompagnie.Text.Trim());
                command.Parameters.AddWithValue("@b", adresse.Text.Trim());
                command.Parameters.AddWithValue("@d", telephone.Text.Trim());
                command.Parameters.AddWithValue("@e", courriel.Text.Trim());
                command.Parameters.AddWithValue("@c", nomContact.Text.Trim());
                command.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Base de données mise à jour..");
                Clear();
                DisplayData();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nomCompagnie.Text) || String.IsNullOrEmpty(adresse.Text) || String.IsNullOrEmpty(telephone.Text) || String.IsNullOrEmpty(courriel.Text) || String.IsNullOrEmpty(nomContact.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide..");
            }
            else
            {
                DataConnection connection = new DataConnection();
                connection.openConnection();
                MySqlCommand command = new MySqlCommand("UPDATE BoutiqueSpecialise SET nomCompagnie=@a,adresse=@b,telephone=@c,courriel=@d,nomContact=@e  WHERE idBoutique =@ID;", connection.Connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@a", nomCompagnie.Text.Trim());
                command.Parameters.AddWithValue("@b", adresse.Text.Trim());
                command.Parameters.AddWithValue("@c", telephone.Text.Trim());
                command.Parameters.AddWithValue("@d", courriel.Text.Trim());
                command.Parameters.AddWithValue("@e", nomContact.Text.Trim());
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
                MySqlCommand cmd = new MySqlCommand("delete from BoutiqueSpecialise where idBoutique=@id;", connection.Connection);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvBoutique.Sort(dgvBoutique.Columns[comboBox1.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int index = comboBox1.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "idBoutique", "nomCompagnie", "adresse", "telephone", "courriel", "nomContact" };
                (dgvBoutique.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox1.Text);
            }
            else
            {
                DisplayData();
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvBoutique.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    ID = Convert.ToInt32(dgvBoutique.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DataConnection connection = new DataConnection();

                    MySqlCommand command = new MySqlCommand("select * from BoutiqueSpecialise WHERE idBoutique=@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.openConnection();
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        idBoutique.Text = data["idBoutique"].ToString();
                        nomCompagnie.Text = data["nomCompagnie"].ToString();
                        adresse.Text = data["adresse"].ToString();
                        telephone.Text = data["telephone"].ToString();
                        courriel.Text = data["courriel"].ToString();
                        nomContact.Text = data["nomContact"].ToString();
                    }
                    //reader["user_password"].ToString()
                    connection.closeConnection();
                }
            }
        }

        private void telephone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(telephone.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                telephone.Text = telephone.Text.Remove(telephone.Text.Length - 1);
            }
        }
    }
}
