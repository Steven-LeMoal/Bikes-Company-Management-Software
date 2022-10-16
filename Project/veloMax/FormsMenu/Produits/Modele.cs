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

namespace veloMax.FormsMenu.Produits
{
    public partial class Modele : Form
    {
        int ID = 0;
        int IDPiece = 0;
        int[] IDAssemble = { 0, 0 };
        public Modele(string user)
        {
            InitializeComponent();
            DisplayData();
            DisplayDataPiece();
            DisplayDataAssemble();
            Clear();

            if (user.Equals("normal"))
            {
                //btnRafraichir.Visible = false;
                btnAjouter.Visible = false;
                btnModifier.Visible = false;
                btnSupprimer.Visible = false;
                btnSup2.Visible = false;
                btnAjouterUsers.Visible = false;
            }
        }


        private void DisplayData()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from Modele;", connection.Connection);
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
            dgvModele.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "Num. produit", "Nom du produit", "Grandeur","Prix unitaire", "Ligne de produit","Date d'introduction", "Date de discontinuation"};
            for (int i = 0; i < columns.Length; i++)
            {
                dgvModele.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dateIntroduction_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            /*
            if(DateTime.Compare(dateIntroduction.Value, now) < 0)
            {
                MessageBox.Show("Veuillez saisir une date égale au supérieur à aujourd'hui");
                dateIntroduction.Value = now.AddDays(-1);
            }*/
        }

        private void dateDiscontinuation_ValueChanged(object sender, EventArgs e)
        {
            /*
            if ((DateTime.Compare(dateIntroduction.Value, now) < 0 ||DateTime.Compare(dateDiscontinuation.Value, dateIntroduction.Value) < 0)
            {
                MessageBox.Show("Veuillez saisir une date égale au supérieur à la date d'introduction");
                dateDiscontinuation.Value = dateIntroduction.Value.AddDays(1);
            }*/
        }

        private void numProdFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void prixUnitaire_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(prixUnitaire.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                prixUnitaire.Text = prixUnitaire.Text.Remove(prixUnitaire.Text.Length - 1);
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            numProduit.Text = "";
            nomProduit.Text = "";
            grandeur.Text = "";
            //ligne de produit
            ligneProduit.Text = "";
            prixUnitaire.Text = "";
            dateIntroduction.Text = "";
            dateDiscontinuation.Text = "";
            comboBoxAssemble.Text = "";
            textBoxAssemble.Text = "";
            comboBoxPiece.Text = "";
            textBoxPiece.Text = "";
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            DisplayData();
            Clear();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nomProduit.Text) || String.IsNullOrEmpty(grandeur.Text) || String.IsNullOrEmpty(prixUnitaire.Text) || String.IsNullOrEmpty(ligneProduit.Text) || String.IsNullOrEmpty(dateIntroduction.Text) || String.IsNullOrEmpty(dateDiscontinuation.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide..");

            }
            else
            {
                if ((DateTime.Compare(dateIntroduction.Value, DateTime.Now) < 0 || DateTime.Compare(dateDiscontinuation.Value, dateIntroduction.Value) < 0))
                {
                    MessageBox.Show("Veuillez saisir une date d'introduction égale au supérieur à aujourd'hui et une date de discontinuation supérieur ou égale à la date d'introduction");
                }
                else
                {
                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                    MySqlCommand command = new MySqlCommand("INSERT INTO Modele (`nomProduit`,`grandeur`,`prixUnitaire`,`ligneProduit`,`dateIntroduction`,`dateDiscontinuation`)  VALUES(@a,@b,@c,@d,@e,@f);", connection.Connection);
                    command.Parameters.AddWithValue("@a", nomProduit.Text.Trim());
                    command.Parameters.AddWithValue("@b", grandeur.Text.Trim());
                    command.Parameters.AddWithValue("@c", Int32.Parse(prixUnitaire.Text.Trim()));
                    command.Parameters.AddWithValue("@d", ligneProduit.Text.Trim());
                    command.Parameters.AddWithValue("@e", dateIntroduction.Value);
                    command.Parameters.AddWithValue("@f", dateDiscontinuation.Value);
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    Clear();
                    DisplayData();
                }

            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nomProduit.Text) || String.IsNullOrEmpty(grandeur.Text) || String.IsNullOrEmpty(prixUnitaire.Text) || String.IsNullOrEmpty(ligneProduit.Text) || String.IsNullOrEmpty(dateIntroduction.Text) || String.IsNullOrEmpty(dateDiscontinuation.Text))
            { 
                MessageBox.Show("Veuillez ne pas laisser de case vide..");
            }
            else
            {
                if ((DateTime.Compare(dateIntroduction.Value, DateTime.Now) < 0 || DateTime.Compare(dateDiscontinuation.Value, dateIntroduction.Value) < 0))
                {
                    MessageBox.Show("Veuillez saisir une date d'introduction égale au supérieur à aujourd'hui et une date de discontinuation supérieur ou égale à la date d'introduction");
                }
                else
                {
                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    MySqlCommand command = new MySqlCommand("UPDATE Modele SET nomProduit=@a,grandeur=@b,prixUnitaire=@c,ligneProduit=@d,dateIntroduction=@e,dateDiscontinuation=@f  WHERE numProduit =@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@a", nomProduit.Text.Trim());
                    command.Parameters.AddWithValue("@b", grandeur.Text.Trim());
                    command.Parameters.AddWithValue("@c", Int32.Parse(prixUnitaire.Text.Trim()));
                    command.Parameters.AddWithValue("@d", ligneProduit.Text.Trim());
                    command.Parameters.AddWithValue("@e", dateIntroduction.Value);
                    command.Parameters.AddWithValue("@f", dateDiscontinuation.Value);
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    Clear();
                    DisplayData();
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DataConnection connection = new DataConnection();
                MySqlCommand command = new MySqlCommand("delete from Modele where numProduit=@id;", connection.Connection);
                connection.openConnection();
                command.Parameters.AddWithValue("@id", ID);
                command.ExecuteNonQuery();
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
            dgvModele.Sort(dgvModele.Columns[comboBox1.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int index = comboBox1.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "numProduit", "nomProduit", "grandeur", "prixUnitaire", "ligneProduit","dateIntroduction", "dateDiscontinuation" };
                (dgvModele.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox1.Text);
            }
            else
            {
                DisplayData();
            }
        }


        private void dgvModele_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvModele.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    ID = Convert.ToInt32(dgvModele.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DataConnection connection = new DataConnection();

                    MySqlCommand command = new MySqlCommand("select * from Modele WHERE numProduit=@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.openConnection();
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        numProduit.Text = data["numProduit"].ToString();
                        nomProduit.Text = data["nomProduit"].ToString();
                        grandeur.Text = data["grandeur"].ToString();
                        prixUnitaire.Text = data["prixUnitaire"].ToString();
                        ligneProduit.Text = data["ligneProduit"].ToString();
                        dateIntroduction.Text = data["dateIntroduction"].ToString();
                        dateDiscontinuation.Text = data["dateDiscontinuation"].ToString();
                    }
                    //reader["user_password"].ToString()
                    connection.closeConnection();
                }
            }
        }

        private void DisplayDataPiece()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from Piece;", connection.Connection);
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
            dgvPiece.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "ID. CLient", "Nom", "Prenom", "Adresse", "Telephone", "Courriel" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvPiece.Columns[i].HeaderCell.Value = columns[i];
            }
        }


        private void btnRafraichirClient_Click(object sender, EventArgs e)
        {
            DisplayDataPiece();
            comboBoxPiece.Text = "";
            textBoxPiece.Text = "";
        }

        private void btnAjoutClient_Click(object sender, EventArgs e)
        {
            if (ID == 0 || IDPiece == 0)
            {
                MessageBox.Show("Veuillez selectionner un modèle et une pièce..");
            }
            else
            {
                int piece = 0;
                int modele = 0;

                DataConnection connection = new DataConnection();
                connection.openConnection();
                //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                MySqlCommand command = new MySqlCommand("SELECT A.numProduit_Piece,A.numProduit_Modele From Assemble as A JOIN Piece as P on A.numProduit_Piece = P.numProduit where P.descriptionP = (select descriptionP from Piece where numProduit = @ID);", connection.Connection);
                command.Parameters.AddWithValue("@ID", IDPiece);
                MySqlDataReader data = command.ExecuteReader();
                while (data.Read())
                {
                    piece = Int32.Parse(data["numProduit_Piece"].ToString());
                    modele = Int32.Parse(data["numProduit_Modele"].ToString());
                }
                connection.closeConnection();



                if (piece != 0 && modele != 0)
                {
                    DialogResult result = MessageBox.Show("Une pièce avec un description similaire existe déjà, voulez-vous la remplacer ?", "Warning", MessageBoxButtons.YesNo);

                    if(result == DialogResult.Yes)
                    {
                        connection = new DataConnection();
                        command = new MySqlCommand("delete from Assemble where numProduit_Piece=@id1 and numProduit_Modele=@id2;", connection.Connection);
                        connection.openConnection();
                        command.Parameters.AddWithValue("@id1", piece);
                        command.Parameters.AddWithValue("@id2", modele);
                        command.ExecuteNonQuery();
                        connection.closeConnection();


                        connection = new DataConnection();
                        connection.openConnection();
                        //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                        command = new MySqlCommand("INSERT INTO Assemble (`numProduit_Piece`,`numProduit_Modele`)  VALUES(@a,@b);", connection.Connection);
                        command.Parameters.AddWithValue("@a", IDPiece);
                        command.Parameters.AddWithValue("@b", ID);
                        command.ExecuteNonQuery();
                        connection.closeConnection();
                        MessageBox.Show("Base de données mise à jour..");
                        DisplayDataAssemble();
                    }
                }
                else
                {
                    connection = new DataConnection();
                    connection.openConnection();
                    //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                    command = new MySqlCommand("INSERT INTO Assemble (`numProduit_Piece`,`numProduit_Modele`)  VALUES(@a,@b);", connection.Connection);
                    command.Parameters.AddWithValue("@a", IDPiece);
                    command.Parameters.AddWithValue("@b", ID);
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    DisplayDataAssemble();
                }

                ID = 0;
                IDPiece = 0;
            }
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPiece.Sort(dgvPiece.Columns[comboBoxPiece.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBoxClient_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPiece.Text != "")
            {
                int index = comboBoxPiece.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "numProduit", "descriptionP", "nomFournisseur", "numProdFournisseur", "prixUnitaire", "dateIntroduction", "dateDiscontinuation", "delaiApprovisionnement" };
                (dgvPiece.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBoxPiece.Text);
            }
            else
            {
                DisplayDataPiece();
            }
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvPiece.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    IDPiece = Convert.ToInt32(dgvPiece.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }

        private void DisplayDataAssemble()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from Assemble;", connection.Connection);
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
            dgvAssemble.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "ID. pièce", "ID. modèle"};
            for (int i = 0; i < columns.Length; i++)
            {
                dgvAssemble.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void btnRafraichir2_Click(object sender, EventArgs e)
        {
            DisplayDataAssemble();
            comboBoxAssemble.Text = "";
            textBoxAssemble.Text = "";
            IDAssemble[0] = 0;
            IDAssemble[1] = 0;
        }

        private void btnSup2_Click(object sender, EventArgs e)
        {
            if (IDAssemble[0] != 0 && IDAssemble[1] != 0)
            {
                DataConnection connection = new DataConnection();
                MySqlCommand command = new MySqlCommand("delete from Assemble where numProduit_Piece=@id1 and numProduit_Modele=@id2;", connection.Connection);
                connection.openConnection();
                command.Parameters.AddWithValue("@id1", IDAssemble[0]);
                command.Parameters.AddWithValue("@id2", IDAssemble[1]);
                command.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Suppression réussit!");
                IDAssemble[0] = 0;
                IDAssemble[1] = 0;
                DisplayDataAssemble();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une colonne!");
            }
        }

        private void comboBoxAssemble_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAssemble.Sort(dgvAssemble.Columns[comboBoxAssemble.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBoxAssemble_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAssemble.Text != "")
            {
                int index = comboBoxAssemble.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "numProduit_Piece", "numProduit_Modele" };
                (dgvAssemble.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBoxAssemble.Text);
            }
            else
            {
                DisplayDataAssemble();
            }
        }

        private void dgvAssemble_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvAssemble.Rows[e.RowIndex].Cells[0].Value != null && dgvAssemble.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    IDAssemble[0] = Convert.ToInt32(dgvAssemble.Rows[e.RowIndex].Cells[0].Value.ToString());
                    IDAssemble[1] = Convert.ToInt32(dgvAssemble.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
