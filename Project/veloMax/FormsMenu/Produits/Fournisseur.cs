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

//j'ai changé l'emplacement du fichier mais sa ne veut pas changer le nom du namespace
namespace veloMax.FormsMenu.Stocks
{
    public partial class Fournisseur : Form
    {
        string ID = "";
        public Fournisseur(string user)
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
            MySqlDataAdapter command = new MySqlDataAdapter("select * from Fournisseur;", connection.Connection);
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
            dgvFournisseur.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "Siret", "Nom entreprise", "Libellé de réactivité"};
            for (int i = 0; i < columns.Length; i++)
            {
                dgvFournisseur.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            siret.Text = "";
            nomEntreprise.Text = "";
            libelleReactivite.Text = "";
        }

        private void dgvModele_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvFournisseur.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    ID = dgvFournisseur.Rows[e.RowIndex].Cells[0].Value.ToString();
                    DataConnection connection = new DataConnection();

                    MySqlCommand command = new MySqlCommand("select * from Fournisseur WHERE siret=@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.openConnection();
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        siret.Text = data["siret"].ToString();
                        nomEntreprise.Text = data["nomEntreprise"].ToString();
                        libelleReactivite.Text = data["libelleReactivite"].ToString();
                    }
                    //reader["user_password"].ToString()
                    connection.closeConnection();
                }
            }
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            DisplayData();
            Clear();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(siret.Text) || String.IsNullOrEmpty(nomEntreprise.Text) || String.IsNullOrEmpty(libelleReactivite.Text) )
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide ou modifier le siret..");
            }
            else
            {
                DataConnection connection = new DataConnection();
                connection.openConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO Fournisseur (`siret`,`nomEntreprise`,`libelleReactivite`)  VALUES(@a,@b,@c);", connection.Connection);
                command.Parameters.AddWithValue("@a", siret.Text.Trim()); 
                command.Parameters.AddWithValue("@b", nomEntreprise.Text.Trim());
                command.Parameters.AddWithValue("@c", libelleReactivite.Text.Trim());
                command.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Base de données mise à jour..");
                Clear();
                DisplayData();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(siret.Text) || String.IsNullOrEmpty(nomEntreprise.Text) || String.IsNullOrEmpty(libelleReactivite.Text) || !ID.Equals(siret.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide ou modifier le siret..");
            }
            else
            {
                DataConnection connection = new DataConnection();
                connection.openConnection();
                MySqlCommand command = new MySqlCommand("UPDATE Fournisseur SET nomEntreprise=@a,libelleReactivite=@b  WHERE siret =@ID;", connection.Connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@a", nomEntreprise.Text.Trim());
                command.Parameters.AddWithValue("@b", libelleReactivite.Text.Trim());
                command.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Base de données mise à jour..");
                Clear();
                DisplayData();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (ID != "")
            {
                DataConnection connection = new DataConnection();
                MySqlCommand cmd = new MySqlCommand("delete from Fournisseur where siret=@id;", connection.Connection);
                connection.openConnection();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Suppression réussit!");
                DisplayData();
                ID = "";
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une colonne!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFournisseur.Sort(dgvFournisseur.Columns[comboBox1.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int index = comboBox1.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "siret", "nomEntreprise", "libelleReactivite"};
                (dgvFournisseur.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox1.Text);
            }
            else
            {
                DisplayData();
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siret_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
