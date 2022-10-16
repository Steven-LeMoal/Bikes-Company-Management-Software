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
    public partial class ProgrammeFidelite : Form
    {
        int ID = 0;
        int IDAdhere = 0;
        int IDClient = 0;
        public ProgrammeFidelite(string user)
        {
            InitializeComponent();
            DisplayData();
            DisplayDataAdhere();
            DisplayDataClient();
            Clear();

            if (user.Equals("normal"))
            {
                //btnRafraichir.Visible = false;
                btnAjouter.Visible = false;
                btnModifier.Visible = false;
                btnSupprimer.Visible = false;
                btnAjoutClient.Visible = false;
                btnModifier2.Visible = false;
                btnSup2.Visible = false;
            }
        }


        private void DisplayData()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from ProgramFidelite;", connection.Connection);
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
            dgvPF.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "Numéro du Programme", "Description", "Cout", "Duree", "Rabais"};
            for (int i = 0; i < columns.Length; i++)
            {
                dgvPF.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            numProgramme.Text = "";
            descriptionPF.Text = "";
            cout.Text = "";
            duree.Text = "";
            rabais.Text = "";
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            DisplayData();
            Clear();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(descriptionPF.Text) || String.IsNullOrEmpty(cout.Text) || String.IsNullOrEmpty(duree.Text) || String.IsNullOrEmpty(rabais.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide...");
            }
            else
            {
                if (Int32.Parse(rabais.Text.Trim()) <= 100)
                {
                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    MySqlCommand command = new MySqlCommand("INSERT INTO ProgramFidelite (`descriptionPF`,`cout`,`duree`,`rabais`)  VALUES(@a,@b,@c,@d);", connection.Connection);
                    command.Parameters.AddWithValue("@a", descriptionPF.Text.Trim());
                    command.Parameters.AddWithValue("@b", Int32.Parse(cout.Text.Trim()));
                    command.Parameters.AddWithValue("@c", Int32.Parse(duree.Text.Trim()));
                    command.Parameters.AddWithValue("@d", Int32.Parse(rabais.Text.Trim()));
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    Clear();
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Veuillez saisir un rabais compris entre 0 et 100 (%)");
                }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(numProgramme.Text) || String.IsNullOrEmpty(descriptionPF.Text) || String.IsNullOrEmpty(cout.Text) || String.IsNullOrEmpty(duree.Text) || String.IsNullOrEmpty(rabais.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide...");
            }
            else
            {
                if(Int32.Parse(rabais.Text.Trim()) <= 100)
                {
                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    MySqlCommand command = new MySqlCommand("UPDATE ProgramFidelite SET descriptionPF=@a,cout=@b,duree=@c,rabais=@d  WHERE numProgramme =@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@a", descriptionPF.Text.Trim());
                    command.Parameters.AddWithValue("@b", Int32.Parse(cout.Text.Trim()));
                    command.Parameters.AddWithValue("@c", Int32.Parse(duree.Text.Trim()));
                    command.Parameters.AddWithValue("@d", Int32.Parse(rabais.Text.Trim()));
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    Clear();
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Veuillez saisir un rabais compris entre 0 et 100 (%)");
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DataConnection connection = new DataConnection();
                MySqlCommand cmd = new MySqlCommand("delete from ProgramFidelite where numProgramme=@id;", connection.Connection);
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
            dgvPF.Sort(dgvPF.Columns[comboBox1.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int index = comboBox1.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "numProgramme", "descriptionPF", "cout", "duree", "rabais" };
                (dgvPF.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox1.Text);
            }
            else
            {
                DisplayData();
            }
        }

        private void cout_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cout.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                cout.Text = cout.Text.Remove(cout.Text.Length - 1);
            }
        }

        private void duree_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(duree.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                duree.Text = duree.Text.Remove(duree.Text.Length - 1);
            }
        }

        private void rabais_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(rabais.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                rabais.Text = rabais.Text.Remove(rabais.Text.Length - 1);
            }
        }

        private void dgvPF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvPF.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    ID = Convert.ToInt32(dgvPF.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DataConnection connection = new DataConnection();

                    MySqlCommand command = new MySqlCommand("select * from ProgramFidelite WHERE numProgramme=@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.openConnection();
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        numProgramme.Text = data["numProgramme"].ToString();
                        descriptionPF.Text = data["descriptionPF"].ToString();
                        cout.Text = data["cout"].ToString();
                        duree.Text = data["duree"].ToString();
                        rabais.Text = data["rabais"].ToString();
                    }
                    //reader["user_password"].ToString()
                    connection.closeConnection();
                }
            }
        }

        private void DisplayDataClient()
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
            dgvClients.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "ID. CLient", "Nom", "Prenom", "Adresse", "Telephone", "Courriel" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvClients.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void btnRafraichirClient_Click(object sender, EventArgs e)
        {
            DisplayDataClient();
        }

        private void btnAjoutClient_Click(object sender, EventArgs e)
        {
            if (IDClient == 0)
            {
                MessageBox.Show("Veuillez choissir un client..");
            }
            else
            {

                int programme = 0;
                int client = 0;

                DataConnection connection = new DataConnection();
                connection.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT idClient_Adhere,numProgramme_Adhere From Adhere where idClient_Adhere = @id1 and numProgramme_Adhere = @id2;", connection.Connection);
                command.Parameters.AddWithValue("@id1", ID);
                command.Parameters.AddWithValue("@id2", IDClient);
                MySqlDataReader data = command.ExecuteReader();
                while (data.Read())
                {
                    programme = Int32.Parse(data["idClient_Adhere"].ToString());
                    client = Int32.Parse(data["numProgramme_Adhere"].ToString());
                }
                connection.closeConnection();



                if (programme != 0 && client != 0)
                {
                    DialogResult result = MessageBox.Show("Une pièce similaire existe déjà sur la commande, voulez-vous la remplacer ?", "Warning", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        connection = new DataConnection();
                        command = new MySqlCommand("delete from Adhere where idClient_Adhere = @id1 and numProgramme_Adhere = @id2;", connection.Connection);
                        connection.openConnection();
                        command.Parameters.AddWithValue("@id1", programme);
                        command.Parameters.AddWithValue("@id2", client);
                        command.ExecuteNonQuery();
                        connection.closeConnection();


                        connection = new DataConnection();
                        connection.openConnection();
                        command = new MySqlCommand("INSERT INTO Adhere (`idClient_Adhere`,`numProgramme_Adhere`,`dateAdhesion`)  VALUES(@a,@b,@c);", connection.Connection);
                        command.Parameters.AddWithValue("@a", IDClient);
                        command.Parameters.AddWithValue("@b", ID);
                        command.Parameters.AddWithValue("@c", DateTime.Now);
                        command.ExecuteNonQuery();
                        connection.closeConnection();
                        MessageBox.Show("Base de données mise à jour..");
                        DisplayDataAdhere();
                        IDClient = 0;
                    }
                }
                else
                {

                    connection = new DataConnection();
                    connection.openConnection();
                    command = new MySqlCommand("INSERT INTO Adhere (`idClient_Adhere`,`numProgramme_Adhere`,`dateAdhesion`)  VALUES(@a,@b,@c);", connection.Connection);
                    command.Parameters.AddWithValue("@a", IDClient);
                    command.Parameters.AddWithValue("@b", ID);
                    command.Parameters.AddWithValue("@c", DateTime.Now);
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    DisplayDataAdhere();
                    IDClient = 0;
                }


            }
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvClients.Sort(dgvClients.Columns[comboBoxClient.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBoxClient_TextChanged(object sender, EventArgs e)
        {
            if (textBoxClient.Text != "")
            {
                int index = comboBoxClient.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "idClient", "nom", "prenom", "adresse", "telephone", "courriel" };
                (dgvClients.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBoxClient.Text);
            }
            else
            {
                DisplayDataClient();
            }
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvClients.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    IDClient = Convert.ToInt32(dgvClients.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }

        private void DisplayDataAdhere()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from Adhere;", connection.Connection);
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
            dgvAdhere.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "ID. CLient", "Num. du programme", "Date d'ahdésion"};
            for (int i = 0; i < columns.Length; i++)
            {
                dgvAdhere.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void btnRafraichir2_Click(object sender, EventArgs e)
        {
            DisplayDataAdhere();
        }

        private void btnSup2_Click(object sender, EventArgs e)
        {
            if (IDAdhere != 0)
            {
                DataConnection connection = new DataConnection();
                MySqlCommand cmd = new MySqlCommand("delete from Adhere where idClient_Adhere=@id;", connection.Connection);
                connection.openConnection();
                cmd.Parameters.AddWithValue("@id", IDAdhere);
                cmd.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Suppression réussit!");
                DisplayDataAdhere();
                IDAdhere = 0;
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une colonne!");
            }
        }

        private void comboBoxAdhere_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAdhere.Sort(dgvAdhere.Columns[comboBoxAdhere.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBoxAdhere_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAdhere.Text != "")
            {
                int index = comboBoxAdhere.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "idClient_Adhere", "numProgramme_Adhere", "dateAdhesion"};
                (dgvAdhere.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBoxAdhere.Text);
            }
            else
            {
                DisplayDataAdhere();
            }
        }

        private void dgvAdhere_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvClients.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    IDAdhere  = Convert.ToInt32(dgvAdhere.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
