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

namespace veloMax.FomsMenu.Produits
{
    public partial class Pieces : Form
    {
        int ID = 0;
        int IDAppro = 0;
        string IDFournisseur = "";

        public Pieces(string user)
        {
            InitializeComponent();
            Clear();
            DisplayData();
            DisplayDataFournisseur();
            DisplayDataAppro();

            if(user.Equals("normal"))
            {
                //btnRafraichir.Visible = false;
                btnAjouter.Visible = false;
                btnModifier.Visible = false;
                btnSupprimer.Visible = false;
                btnSup2.Visible = false;
                btnAjoutFourni.Visible = false;
            }
        }

        private void dgvPiece_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvPiece_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if (dgvPiece.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    ID = Convert.ToInt32(dgvPiece.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DataConnection connection = new DataConnection();

                    MySqlCommand command = new MySqlCommand("select * from Piece WHERE numProduit=@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.openConnection();
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        numProduit.Text = data["numProduit"].ToString();
                        descriptionP.Text = data["descriptionP"].ToString();
                        nomFournisseur.Text = data["nomFournisseur"].ToString();
                        numProdFournisseur.Text = data["numProdFournisseur"].ToString();
                        prixUnitaire.Text = data["prixUnitaire"].ToString();
                        dateIntroduction.Text = data["dateIntroduction"].ToString();
                        dateDiscontinuation.Text = data["dateDiscontinuation"].ToString();
                        delaiApprovisionnement.Text = data["delaiApprovisionnement"].ToString();
                    }
                    //reader["user_password"].ToString()
                    connection.closeConnection();

                    command = new MySqlCommand("SELECT (sum(A.quantite) - sum(Cp.quantite)) " +
                        "FROM Approvisionne as A " +
                        "join CommanderPiece as Cp on A.numProduit_Appro = Cp.numProduit_CommanderPiece " +
                        "WHERE A.numProduit_Appro = @ID " +
                        "GROUP BY A.numProduit_Appro; ", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.openConnection();
                    data = command.ExecuteReader();
                    while (data.Read())
                    {
                        if (Int32.Parse(data["(sum(A.quantite) - sum(Cp.quantite))"].ToString()) < 1 || String.IsNullOrEmpty(data["(sum(A.quantite) - sum(Cp.quantite))"].ToString()))
                        {
                            MessageBox.Show("La quantité en stock de cette pièce est de 0!!!");
                        }

                        labelStockP.Text = data["(sum(A.quantite) - sum(Cp.quantite))"].ToString();
                    }
                    //reader["user_password"].ToString()
                    connection.closeConnection();

                    
                }
            }

        }

        private void dgvPiece_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void DisplayData()
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
            string[] columns = { "Num. produit","Description","Nom du fournisseur","Num. du produit fournisseur","Prix unitaire","Date d'introduction","Date de discontinuation","Délai d'approvisionnement" };
            for(int i = 0; i < columns.Length;i++)
            {
                dgvPiece.Columns[i].HeaderCell.Value = columns[i];
            }
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
            numProduit.Text = "";
            descriptionP.Text = "";
            nomFournisseur.Text = "";
            numProdFournisseur.Text = "";
            prixUnitaire.Text = "";
            dateIntroduction.Text = "";
            dateDiscontinuation.Text = "";
            delaiApprovisionnement.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(descriptionP.Text) || String.IsNullOrEmpty(nomFournisseur.Text) || String.IsNullOrEmpty(numProdFournisseur.Text) || String.IsNullOrEmpty(prixUnitaire.Text) || String.IsNullOrEmpty(dateIntroduction.Text) || String.IsNullOrEmpty(dateDiscontinuation.Text) || String.IsNullOrEmpty(delaiApprovisionnement.Text))
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
                    MySqlCommand command = new MySqlCommand("INSERT INTO Piece (`descriptionP`,`nomFournisseur`,`numProdFournisseur`,`prixUnitaire`,`dateIntroduction`,`dateDiscontinuation`,`delaiApprovisionnement`)  VALUES(@a,@b,@g,@c,@d,@e,@f);", connection.Connection);
                    command.Parameters.AddWithValue("@a", descriptionP.Text.Trim());
                    command.Parameters.AddWithValue("@b", nomFournisseur.Text.Trim());
                    command.Parameters.AddWithValue("@g", Int32.Parse(numProdFournisseur.Text.Trim()));
                    command.Parameters.AddWithValue("@c", Int32.Parse(prixUnitaire.Text.Trim()));
                    command.Parameters.AddWithValue("@d", dateIntroduction.Value);
                    command.Parameters.AddWithValue("@e", dateDiscontinuation.Value);
                    command.Parameters.AddWithValue("@f", Int32.Parse(delaiApprovisionnement.Text.Trim()));
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
            if (String.IsNullOrEmpty(descriptionP.Text) || String.IsNullOrEmpty(nomFournisseur.Text) || String.IsNullOrEmpty(numProdFournisseur.Text) || String.IsNullOrEmpty(prixUnitaire.Text) || String.IsNullOrEmpty(dateIntroduction.Text) || String.IsNullOrEmpty(dateDiscontinuation.Text) || String.IsNullOrEmpty(delaiApprovisionnement.Text))
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
                    MySqlCommand command = new MySqlCommand("UPDATE Piece SET descriptionP=@a,nomFournisseur=@b,numProdFournisseur=@g,prixUnitaire=@c,dateIntroduction=@d,dateDiscontinuation=@e,delaiApprovisionnement=@f  WHERE numProduit =@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@a", descriptionP.Text.Trim());
                    command.Parameters.AddWithValue("@b", nomFournisseur.Text.Trim());
                    command.Parameters.AddWithValue("@g", Int32.Parse(numProdFournisseur.Text.Trim()));
                    command.Parameters.AddWithValue("@c", Int32.Parse(prixUnitaire.Text.Trim()));
                    command.Parameters.AddWithValue("@d", dateIntroduction.Value);
                    command.Parameters.AddWithValue("@e", dateDiscontinuation.Value);
                    command.Parameters.AddWithValue("@f", Int32.Parse(delaiApprovisionnement.Text.Trim()));
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    Clear();
                    DisplayData();
                }
            }
        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int index = comboBox1.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "numProduit", "descriptionP", "nomFournisseur", "numProdFournisseur", "prixUnitaire", "dateIntroduction", "dateDiscontinuation", "delaiApprovisionnement" };
                (dgvPiece.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox1.Text);
            }
            else
            {
                DisplayData();
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPiece.Sort(dgvPiece.Columns[comboBox1.SelectedIndex], ListSortDirection.Ascending);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DataConnection connection = new DataConnection();
                MySqlCommand cmd = new MySqlCommand("delete from Piece where numProduit=@id;", connection.Connection);
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

        private void prixUnitaire_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(prixUnitaire.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                prixUnitaire.Text = prixUnitaire.Text.Remove(prixUnitaire.Text.Length - 1);
            }
        }

        private void delaiApprovisionnement_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(prixUnitaire.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                prixUnitaire.Text = prixUnitaire.Text.Remove(prixUnitaire.Text.Length - 1);
            }

        }

        private void numProdFournisseur_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(prixUnitaire.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                prixUnitaire.Text = prixUnitaire.Text.Remove(prixUnitaire.Text.Length - 1);
            }
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
            if (DateTime.Compare(dateDiscontinuation.Value, dateIntroduction.Value) < 0)
            {
                MessageBox.Show("Veuillez saisir une date égale au supérieur à la date d'introduction");
                dateDiscontinuation.Value = dateIntroduction.Value.AddDays(1);
            }*/
        }

        private void textBoxQuantite_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(prixUnitaire.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                prixUnitaire.Text = prixUnitaire.Text.Remove(prixUnitaire.Text.Length - 1);
            }
        }

        private void DisplayDataFournisseur()
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
            string[] columns = { "Siret", "Nom entreprise", "Libellé de réactivité" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvFournisseur.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        #region Inutile

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Pieces_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPiece_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPiece_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }


        private void descriptionP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numProduit_TextChanged(object sender, EventArgs e)
        {

        }

        private void nomFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void btnRafraichirFourni_Click(object sender, EventArgs e)
        {
            DisplayDataFournisseur();
            comboBox3.Text = "";
        }

        private void btnAjoutFourni_Click(object sender, EventArgs e)
        {
            if (IDFournisseur == "" || ID == 0 || String.IsNullOrEmpty(textBoxQuantite.Text))
            {
                MessageBox.Show("Veuillez saisir une piéce, un fournisseur et saisir la quantité..");
            }
            else
            {
                DataConnection connection = new DataConnection();
                connection.openConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO Approvisionne (`siret_Appro`,`numProduit_Appro`,`quantite`,`dateAchat`)  VALUES(@a,@b,@c,@d);", connection.Connection);
                command.Parameters.AddWithValue("@a", IDFournisseur);
                command.Parameters.AddWithValue("@b", ID);
                command.Parameters.AddWithValue("@c", Int32.Parse(textBoxQuantite.Text.Trim()));
                command.Parameters.AddWithValue("@d", DateTime.Now);
                command.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Base de données mise à jour..");
                Clear();
                DisplayData();
                DisplayDataAppro();
                IDFournisseur = "";
                ID = 0;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFournisseur.Sort(dgvFournisseur.Columns[comboBox3.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int index = comboBox3.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "siret", "nomEntreprise", "libelleReactivite" };
                (dgvFournisseur.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox3.Text);
            }
            else
            {
                DisplayDataFournisseur();
            }
        }

        private void dgvFournisseur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvFournisseur.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    IDFournisseur = dgvFournisseur.Rows[e.RowIndex].Cells[0].Value.ToString();
                    nomFournisseur.Text = dgvFournisseur.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }
        }

        private void DisplayDataAppro()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from Approvisionne;", connection.Connection);
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
            dgvAppro.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "Id Approvisionnement", "Siret du fournisseur", "Num. produit", "Quantite","Date d'achat" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvAppro.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void btnRafraichirAppro_Click(object sender, EventArgs e)
        {
            DisplayDataAppro();
            textBoxQuantite.Text = "";
        }

        private void btnSup2_Click(object sender, EventArgs e)
        {
            if (IDAppro != 0)
            {
                DataConnection connection = new DataConnection();
                MySqlCommand cmd = new MySqlCommand("delete from Approvisionne where numUniqueAppro=@id;", connection.Connection);
                connection.openConnection();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                connection.closeConnection();
                MessageBox.Show("Suppression réussit!");
                IDAppro = 0;
                ID = 0;
                labelStockP.Text = "...";
                DisplayData();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une colonne!");
            }
        }

        private void comboBoxAppro_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAppro.Sort(dgvAppro.Columns[comboBoxAppro.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAppro.Text != "")
            {
                int index = comboBoxAppro.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = {"numUniqueAppro", "siret_Appro", "numProduit_Appro", "quantite", "dateAchat" };
                (dgvAppro.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBoxAppro.Text);
            }
            else
            {
                DisplayDataAppro();
            }
        }

        private void dgvAppro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvAppro.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    IDAppro = Int32.Parse(dgvAppro.Rows[e.RowIndex].Cells[0].Value.ToString());
                    
                }
            }
        }

        private void dgvAppro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvFournisseur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void labelStockP_Click(object sender, EventArgs e)
        {

        }
    }
}
