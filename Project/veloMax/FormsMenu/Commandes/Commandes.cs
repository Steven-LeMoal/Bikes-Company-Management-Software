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
using System.Globalization;

namespace veloMax.FormsMenu.Commandes
{
    public partial class Commandes : Form
    {
        int ID = 0;
        int IDLien = 0;
        int[] IDCombo = {0,0 };
        int choix = 1;

        public Commandes(string user)
        {
            InitializeComponent();
            DisplayData();
            DisplayDataCombo();
            DisplayDataLien();
            Clear();
            if (user.Equals("normal"))
            {
                //btnRafraichir.Visible = false;
                btnAjouter.Visible = false;
                btnModifier.Visible = false;
                btnSupprimer.Visible = false;
                btnSupLien.Visible = false;
                btnAjoutSelect.Visible = false;
            }
        }

        private void Clear()
        {
            numCommande.Text = "";
            adresseLivraison.Text = "";
            textBox5.Text = "";
            comboBox4.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "";
        }

        private void DisplayData()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select * from Commande;", connection.Connection);
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
            dgvCommande.DataSource = cdt;
            connection.closeConnection();
            string[] columns = { "Num. commande", "Date de commande", "Adresse de Livraison", "Date de livraison"};
            for (int i = 0; i < columns.Length; i++)
            {
                dgvCommande.Columns[i].HeaderCell.Value = columns[i];
            }
            ID = 0;
        }

        #region Inutiles

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Commandes_Load(object sender, EventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void adresseLivraison_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            DisplayData();
            Clear();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if ( String.IsNullOrEmpty(adresseLivraison.Text)  || String.IsNullOrEmpty(dateLivraison.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide..");

            }
            else
            {
                if (DateTime.Compare(dateLivraison.Value, DateTime.Now) < 0)
                {
                    MessageBox.Show("Veuillez saisir une date de livraison égale au supérieur à aujourd'hui");
                }
                else
                {
                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                    MySqlCommand command = new MySqlCommand("INSERT INTO Commande (`dateCommande`,`adresseLivraison`,`dateLivraison`)  VALUES(@a,@b,@c);", connection.Connection);
                    command.Parameters.AddWithValue("@a", DateTime.Now);
                    command.Parameters.AddWithValue("@b", adresseLivraison.Text.Trim());
                    command.Parameters.AddWithValue("@c", dateLivraison.Value);
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
            if (String.IsNullOrEmpty(numCommande.Text) || String.IsNullOrEmpty(adresseLivraison.Text) || String.IsNullOrEmpty(dateLivraison.Text))
            {
                MessageBox.Show("Veuillez ne pas laisser de case vide..");

            }
            else
            {
                if (DateTime.Compare(dateLivraison.Value, DateTime.Now) < 0)
                {
                    MessageBox.Show("Veuillez saisir une date de livraison au moins supérieur à aujourd'hui");
                }
                else
                {
                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                    MySqlCommand command = new MySqlCommand("UPDATE Commande SET adresseLivraison=@b,dateLivraison=@c WHERE numCommande =@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@b", adresseLivraison.Text.Trim());
                    command.Parameters.AddWithValue("@c", dateLivraison.Value);
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
                MySqlCommand command = new MySqlCommand("delete from Commande where numUnique=@id;", connection.Connection);
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
            dgvCommande.Sort(dgvCommande.Columns[comboBox1.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int index = comboBox1.SelectedIndex;
                index = index == -1 ? 0 : index;
                string[] columns = { "numCommande", "dateCommande", "adresseLivraison", "dateLivraison"};
                (dgvCommande.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox1.Text);
            }
            else
            {
                DisplayData();
            }
        }

        private void dgvCommande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvCommande.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    ID = Convert.ToInt32(dgvCommande.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DataConnection connection = new DataConnection();

                    MySqlCommand command = new MySqlCommand("select * from Commande WHERE numUnique=@ID;", connection.Connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.openConnection();
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        numCommande.Text = data["numUnique"].ToString();
                        dateCommande.Text = data["dateCommande"].ToString();
                        adresseLivraison.Text = data["adresseLivraison"].ToString();
                        dateLivraison.Text = data["dateLivraison"].ToString();
                    }
                    //reader["user_password"].ToString()
                    connection.closeConnection();
                }
            }
        }

        private void ChangeLabel()
        {
            if(choix == 1)
            {
                DataConnection connection = new DataConnection();
                connection.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT sum(quantite) From CommanderPiece where numProduit_CommanderPiece = @ID GROUP BY numProduit_CommanderPiece;", connection.Connection);
                command.Parameters.AddWithValue("@ID", IDLien);
                MySqlDataReader data = command.ExecuteReader();
                while (data.Read())
                {
                    labelNombreCommande.Text = data["sum(quantite)"].ToString();
                }
                connection.closeConnection();
            }
            else if(choix == 2)
            {

                DataConnection connection = new DataConnection();
                connection.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT sum(quantite) From CommanderModele where numProduit_CommanderModele = @ID GROUP BY numProduit_CommanderModele;", connection.Connection);
                command.Parameters.AddWithValue("@ID", IDLien);
                MySqlDataReader data = command.ExecuteReader();
                while (data.Read())
                {
                    labelNombreCommande.Text = data["sum(quantite)"].ToString();
                }
                connection.closeConnection();
            }
        }

        private void btnPiece_Click(object sender, EventArgs e)
        {
            choix = 1;
            labelQuantite.Visible = true;
            textBoxCommandeQuantite.Visible = true;
            labelNombre.Text = "Le quantité totale commandée de la pièce sélectionnée total est de : ";
            ChangeLabel();
            DisplayDataLien();
            DisplayDataCombo();
        }

        private void btnModele_Click(object sender, EventArgs e)
        {
            choix = 2;
            labelQuantite.Visible = true;
            textBoxCommandeQuantite.Visible = true;
            labelNombre.Text = "Le quantité totale commandée du modèle sélectionnée total est de : ";
            ChangeLabel();
            DisplayDataLien();
            DisplayDataCombo();
        }

        private void btnParticulier_Click(object sender, EventArgs e)
        {
            choix = 3;
            labelQuantite.Visible = false;
            textBoxCommandeQuantite.Visible = false;
            labelNombre.Visible = false;
            labelNombreCommande.Visible = false;
            DisplayDataLien();
            DisplayDataCombo();
        }

        private void btnBoutique_Click(object sender, EventArgs e)
        {
            choix = 4;
            labelQuantite.Visible = false;
            textBoxCommandeQuantite.Visible = false;
            labelNombre.Visible = false;
            labelNombreCommande.Visible = false;
            DisplayDataLien();
            DisplayDataCombo();
        }

        private void DisplayDataLien()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            comboBox2.Items.Clear();
            if (choix == 1)
            {
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
                dgvLien.DataSource = cdt;
                connection.closeConnection();
                string[] columns = { "Num. produit", "Description", "Nom du fournisseur", "Num. du produit fournisseur", "Prix unitaire", "Date d'introduction", "Date de discontinuation", "Délai d'approvisionnement" };
                comboBox2.Items.AddRange(columns);
                for (int i = 0; i < columns.Length; i++)
                {
                    dgvLien.Columns[i].HeaderCell.Value = columns[i];
                }
            }
            else if(choix == 2)
            {
                MySqlDataAdapter command = new MySqlDataAdapter("select * from Modele;", connection.Connection);
                connection.openConnection();
                command.Fill(dt);
                DataTable cdt = dt.Clone();
                foreach(DataColumn column in cdt.Columns)
                {
                    column.DataType = typeof(String);
                }
                foreach (DataRow row in dt.Rows)
                {
                    cdt.ImportRow(row);
                }
                dgvLien.DataSource = cdt;
                connection.closeConnection();
                string[] columns = { "Num. produit", "Nom du produit", "Grandeur", "Prix unitaire", "Ligne de produit", "Date d'introduction", "Date de discontinuation" };
                comboBox2.Items.AddRange(columns);
                for (int i = 0; i < columns.Length; i++)
                {
                    dgvLien.Columns[i].HeaderCell.Value = columns[i];
                }
            }
            else if(choix == 3)
            {
                MySqlDataAdapter command = new MySqlDataAdapter("select * from Individu;", connection.Connection);
                connection.openConnection();
                command.Fill(dt);
                dgvLien.DataSource = dt;
                connection.closeConnection();
                string[] columns = { "ID. CLient", "Nom", "Prenom", "Adresse", "Telephone", "Courriel" };
                comboBox2.Items.AddRange(columns);
                for (int i = 0; i < columns.Length; i++)
                {
                    dgvLien.Columns[i].HeaderCell.Value = columns[i];
                }
            }
            else if (choix == 4)
            {
                MySqlDataAdapter command = new MySqlDataAdapter("select * from BoutiqueSpecialise;", connection.Connection);
                connection.openConnection();
                command.Fill(dt);
                dgvLien.DataSource = dt;
                connection.closeConnection();
                string[] columns = { "ID. Boutique", "Nom compagnie", "Adresse", "Telephone", "Courriel", "Nom du Contact" };
                comboBox2.Items.AddRange(columns);
                for (int i = 0; i < columns.Length; i++)
                {
                    dgvLien.Columns[i].HeaderCell.Value = columns[i];
                }
            }

            IDLien = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvLien.Sort(dgvLien.Columns[comboBox2.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                int index = comboBox2.SelectedIndex;
                index = index == -1 ? 0 : index;
                
                if(choix == 1)
                {
                    string[] columns = { "numProduit", "descriptionP", "nomFournisseur", "numProdFournisseur", "prixUnitaire", "dateIntroduction", "dateDiscontinuation", "delaiApprovisionnement" };
                    (dgvLien.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox4.Text);
                }
                else if(choix == 2)
                {
                    string[] columns = { "numProduit", "nomProduit", "grandeur", "prixUnitaire", "ligneProduit", "dateIntroduction", "dateDiscontinuation" };
                    (dgvLien.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox4.Text);

                }
                else if (choix == 3)
                {
                    string[] columns = { "idClient", "nom", "prenom", "adresse", "telephone", "courriel" };
                    (dgvLien.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox4.Text);
                }
                else if (choix == 4)
                {
                    string[] columns = { "idBoutique", "nomCompagnie", "adresse", "telephone", "courriel", "nomContact" };
                    (dgvLien.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox4.Text);
                }
            }
            else
            {
                DisplayDataLien();
            }
        }

        private void btnAjoutSelect_Click(object sender, EventArgs e)
        {
            if (ID == 0 || IDLien == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne....");

            }
            else
            {
                if (choix == 1)
                {
                    int stock = 0;

                    if (String.IsNullOrEmpty(textBoxCommandeQuantite.Text.Trim()) || Int32.Parse(textBoxCommandeQuantite.Text.Trim()) < 1)
                    {
                        MessageBox.Show("Veuillez saisir une quantité pour la commande > 0..");
                    }
                    else
                    {
                        DataConnection connection = new DataConnection();
                        MySqlCommand command = new MySqlCommand("SELECT (sum(A.quantite) - sum(Cp.quantite)) " +
                            "FROM Approvisionne as A " +
                            "join CommanderPiece as Cp on A.numProduit_Appro = Cp.numProduit_CommanderPiece " +
                            "WHERE A.numProduit_Appro = @ID " +
                            "GROUP BY A.numProduit_Appro; ", connection.Connection);
                        command.Parameters.AddWithValue("@ID", ID);
                        connection.openConnection();
                        MySqlDataReader data = command.ExecuteReader();
                        while (data.Read())
                        {
                            if (Int32.Parse(data["(sum(A.quantite) - sum(Cp.quantite))"].ToString()) > 0)
                            {
                                stock = Int32.Parse(data["(sum(A.quantite) - sum(Cp.quantite))"].ToString());
                            }
                            if (String.IsNullOrEmpty(data["(sum(A.quantite) - sum(Cp.quantite))"].ToString()))
                            {
                                MessageBox.Show("Pas encore d'approvisionnement de la pièce..");
                            }
                        }
                       
                        connection.closeConnection();

                        MessageBox.Show(String.Format("Le stock est de {0}", stock));
                        //stock >= Int32.Parse(textBoxCommandeQuantite.Text.Trim())
                        if (true)
                        {
                            int piece = 0;
                            int commande = 0;

                            connection.openConnection();
                            command = new MySqlCommand("SELECT C.numUnique_Commande_P,C.numProduit_CommanderPiece From CommanderPiece as C where C.numUnique_Commande_P = @id1 and C.numProduit_CommanderPiece = @id2;", connection.Connection);
                            command.Parameters.AddWithValue("@id1", ID);
                            command.Parameters.AddWithValue("@id2", IDLien);
                            data = command.ExecuteReader();
                            while (data.Read())
                            {
                                piece = Int32.Parse(data["numUnique_Commande_P"].ToString());
                                commande = Int32.Parse(data["numProduit_CommanderPiece"].ToString());
                            }
                            connection.closeConnection();



                            if (piece != 0 && commande != 0)
                            {
                                DialogResult result = MessageBox.Show("Une pièce similaire existe déjà sur la commande, voulez-vous la remplacer ?", "Warning", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    connection = new DataConnection();
                                    command = new MySqlCommand("delete from CommanderPiece where numUnique_Commande_P = @id1 and numProduit_CommanderPiece = @id2;", connection.Connection);
                                    connection.openConnection();
                                    command.Parameters.AddWithValue("@id1", piece);
                                    command.Parameters.AddWithValue("@id2", commande);
                                    command.ExecuteNonQuery();
                                    connection.closeConnection();

                                    connection = new DataConnection();
                                    connection.openConnection();
                                    command = new MySqlCommand("INSERT INTO CommanderPiece (`numUnique_Commande_P`,`numProduit_CommanderPiece`,`quantite`)  VALUES(@a,@b,@c);", connection.Connection);
                                    command.Parameters.AddWithValue("@a", ID);
                                    command.Parameters.AddWithValue("@b", IDLien);
                                    command.Parameters.AddWithValue("@c", Int32.Parse(textBoxCommandeQuantite.Text.Trim()));
                                    command.ExecuteNonQuery();
                                    connection.closeConnection();
                                    MessageBox.Show("Base de données mise à jour..");
                                }
                            }
                            else
                            {
                                connection = new DataConnection();
                                connection.openConnection();
                                command = new MySqlCommand("INSERT INTO CommanderPiece (`numUnique_Commande_P`,`numProduit_CommanderPiece`,`quantite`)  VALUES(@a,@b,@c);", connection.Connection);
                                command.Parameters.AddWithValue("@a", ID);
                                command.Parameters.AddWithValue("@b", IDLien);
                                command.Parameters.AddWithValue("@c", Int32.Parse(textBoxCommandeQuantite.Text.Trim()));
                                command.ExecuteNonQuery();
                                connection.closeConnection();
                                MessageBox.Show("Base de données mise à jour..");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pas assez de stock..");
                        }
                    }
                }
                else if (choix == 2)
                {
                    if (String.IsNullOrEmpty(textBoxCommandeQuantite.Text) || Int32.Parse(textBoxCommandeQuantite.Text.Trim()) < 1)
                    {
                        MessageBox.Show("Veuillez saisir une quantité pour la commande > 0..");
                    }
                    else
                    {
                        int modele = 0;
                        int commande = 0;

                        DataConnection connection = new DataConnection();
                        connection.openConnection();
                        //set(descriptionP,nomProdFournisseur,prixUnitaire,dateIntroduction,dateDiscontinuation,delaiApprovisionnement) 
                        MySqlCommand command = new MySqlCommand("SELECT C.numUnique_Commande_M,C.numProduit_CommanderModele From CommanderModele as C where C.numUnique_Commande_M = @id1 and C.numProduit_CommanderModele = @id2;", connection.Connection);
                        command.Parameters.AddWithValue("@id1", ID);
                        command.Parameters.AddWithValue("@id2", IDLien);
                        MySqlDataReader data = command.ExecuteReader();
                        while (data.Read())
                        {
                            modele = Int32.Parse(data["numUnique_Commande_M"].ToString());
                            commande = Int32.Parse(data["numProduit_CommanderModele"].ToString());
                        }
                        connection.closeConnection();



                        if (modele != 0 && commande != 0)
                        {
                            DialogResult result = MessageBox.Show("Un modèle similaire existe déjà sur la commande, voulez-vous la remplacer ?", "Warning", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                connection = new DataConnection();
                                command = new MySqlCommand("delete from CommanderModele where numUnique_Commande_M = @id1 and numProduit_CommanderModele = @id2;", connection.Connection);
                                connection.openConnection();
                                command.Parameters.AddWithValue("@id1", modele);
                                command.Parameters.AddWithValue("@id2", commande);
                                command.ExecuteNonQuery();
                                connection.closeConnection();

                                connection = new DataConnection();
                                connection.openConnection();
                                command = new MySqlCommand("INSERT INTO CommanderModele (`numUnique_Commande_M`,`numProduit_CommanderModele`,`quantite`)  VALUES(@a,@b,@c);", connection.Connection);
                                command.Parameters.AddWithValue("@a", ID);
                                command.Parameters.AddWithValue("@b", IDLien);
                                command.Parameters.AddWithValue("@c", Int32.Parse(textBoxCommandeQuantite.Text.Trim()));
                                command.ExecuteNonQuery();
                                connection.closeConnection();
                                MessageBox.Show("Base de données mise à jour..");
                            }
                        }
                        else
                        {
                            connection = new DataConnection();
                            connection.openConnection();
                            command = new MySqlCommand("INSERT INTO CommanderModele (`numUnique_Commande_M`,`numProduit_CommanderModele`,`quantite`)  VALUES(@a,@b,@c);", connection.Connection);
                            command.Parameters.AddWithValue("@a", ID);
                            command.Parameters.AddWithValue("@b", IDLien);
                            command.Parameters.AddWithValue("@c", Int32.Parse(textBoxCommandeQuantite.Text.Trim()));
                            command.ExecuteNonQuery();
                            connection.closeConnection();
                            MessageBox.Show("Base de données mise à jour..");
                        }

                    }
                }
                else if (choix == 3)
                {
                    int client = 0;
                    int commande = 0;

                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT C.numUnique_Commande_C,C.idClient_Commande From CommandeClient as C where C.numUnique_Commande_C = @id1 and C.idClient_Commande = @id2;", connection.Connection);
                    command.Parameters.AddWithValue("@id1", ID);
                    command.Parameters.AddWithValue("@id2", IDLien);
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        client = Int32.Parse(data["numUnique_Commande_C"].ToString());
                        commande = Int32.Parse(data["idClient_Commande"].ToString());
                    }
                    connection.closeConnection();

                    bool test = false;

                    if (client == 0 && commande == 0)
                    {
                        connection = new DataConnection();
                        connection.openConnection();
                        command = new MySqlCommand("SELECT C.numUnique_Commande_B,C.idBoutique_Commande From CommandeBoutique as C where C.numUnique_Commande_B = @id1 and C.idBoutique_Commande = @id2;", connection.Connection);
                        command.Parameters.AddWithValue("@id1", ID);
                        command.Parameters.AddWithValue("@id2", IDLien);
                        data = command.ExecuteReader();
                        while (data.Read())
                        {
                            client = Int32.Parse(data["numUnique_Commande_B"].ToString());
                            commande = Int32.Parse(data["idBoutique_Commande"].ToString());
                        }
                        connection.closeConnection();

                        test = client != 0 && commande != 0 ? true : false;
                    }
                        


                    if (client != 0 && commande != 0)
                    {
                        DialogResult result = MessageBox.Show("Une client existe déjà sur la commande, voulez-vous la remplacer ?", "Warning", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            if (test)
                            {
                                connection = new DataConnection();
                                command = new MySqlCommand("delete from CommandeBoutique where numUnique_Commande_B = @id1 and idBoutique_Commande = @id2;", connection.Connection);
                                connection.openConnection();
                                command.Parameters.AddWithValue("@id1", client);
                                command.Parameters.AddWithValue("@id2", commande);
                                command.ExecuteNonQuery();
                                connection.closeConnection();
                            }
                            else
                            {
                                connection = new DataConnection();
                                command = new MySqlCommand("delete from CommandeClient as C where C.numUnique_Commande_C = @id1 and C.idClient_Commande = @id2;", connection.Connection);
                                connection.openConnection();
                                command.Parameters.AddWithValue("@id1", client);
                                command.Parameters.AddWithValue("@id2", commande);
                                command.ExecuteNonQuery();
                                connection.closeConnection();
                            }


                            connection = new DataConnection();
                            connection.openConnection();
                            command = new MySqlCommand("INSERT INTO CommandeClient (`numUnique_Commande_C`,`idClient_Commande`)  VALUES(@a,@b);", connection.Connection);
                            command.Parameters.AddWithValue("@a", ID);
                            command.Parameters.AddWithValue("@b", IDLien);
                            command.ExecuteNonQuery();
                            connection.closeConnection();
                            MessageBox.Show("Base de données mise à jour..");
                        }
                    }
                    else
                    {
                        connection = new DataConnection();
                        connection.openConnection();
                        command = new MySqlCommand("INSERT INTO CommandeClient (`numUnique_Commande_C`,`idClient_Commande`)  VALUES(@a,@b);", connection.Connection);
                        command.Parameters.AddWithValue("@a", ID);
                        command.Parameters.AddWithValue("@b", IDLien);
                        command.ExecuteNonQuery();
                        connection.closeConnection();
                        MessageBox.Show("Base de données mise à jour..");
                    }

                }
                else if (choix == 4)
                {
                    int boutique = 0;
                    int commande = 0;

                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    MySqlCommand command = new MySqlCommand("SELECT C.numUnique_Commande_B,C.idBoutique_Commande From CommandeBoutique as C where C.numUnique_Commande_B = @id1 and C.idBoutique_Commande = @id2;", connection.Connection);
                    command.Parameters.AddWithValue("@id1", ID);
                    command.Parameters.AddWithValue("@id2", IDLien);
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        boutique = Int32.Parse(data["numUnique_Commande_B"].ToString());
                        commande = Int32.Parse(data["idBoutique_Commande"].ToString());
                    }
                    connection.closeConnection();

                    bool test = false;

                    if(boutique == 0 && commande == 0)
                    {
                        connection = new DataConnection();
                        connection.openConnection();
                        command = new MySqlCommand("SELECT C.numUnique_Commande_C,C.idClient_Commande From CommandeClient as C where C.numUnique_Commande_C = @id1 and C.idClient_Commande = @id2;", connection.Connection);
                        command.Parameters.AddWithValue("@id1", ID);
                        command.Parameters.AddWithValue("@id2", IDLien);
                        data = command.ExecuteReader();
                        while (data.Read())
                        {
                            boutique = Int32.Parse(data["numUnique_Commande_C"].ToString());
                            commande = Int32.Parse(data["idClient_Commande"].ToString());
                        }
                        connection.closeConnection();

                        test = boutique != 0 && commande != 0 ? true : false;
                    }



                    if (boutique != 0 && commande != 0)
                    {
                        DialogResult result = MessageBox.Show("Un client existe déjà sur la commande, voulez-vous la remplacer ?", "Warning", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            if (test)
                            {
                                connection = new DataConnection();
                                command = new MySqlCommand("delete from CommandeClient as C where C.numUnique_Commande_C = @id1 and C.idClient_Commande = @id2;", connection.Connection);
                                connection.openConnection();
                                command.Parameters.AddWithValue("@id1", boutique);
                                command.Parameters.AddWithValue("@id2", commande);
                                command.ExecuteNonQuery();
                                connection.closeConnection();
                            }
                            else
                            {
                                connection = new DataConnection();
                                command = new MySqlCommand("delete from CommandeBoutique where numUnique_Commande_B = @id1 and idBoutique_Commande = @id2;", connection.Connection);
                                connection.openConnection();
                                command.Parameters.AddWithValue("@id1", boutique);
                                command.Parameters.AddWithValue("@id2", commande);
                                command.ExecuteNonQuery();
                                connection.closeConnection();
                            }


                            connection = new DataConnection();
                            connection.openConnection();
                            command = new MySqlCommand("INSERT INTO CommandeBoutique (`numUnique_Commande_B`,`idBoutique_Commande`)  VALUES(@a,@b);", connection.Connection);
                            command.Parameters.AddWithValue("@a", ID);
                            command.Parameters.AddWithValue("@b", IDLien);
                            command.ExecuteNonQuery();
                            connection.closeConnection();
                            MessageBox.Show("Base de données mise à jour..");
                        }
                    }
                    else
                    {
                        connection = new DataConnection();
                        connection.openConnection();
                        command = new MySqlCommand("INSERT INTO CommandeBoutique (`numUnique_Commande_B`,`idBoutique_Commande`)  VALUES(@a,@b);", connection.Connection);
                        command.Parameters.AddWithValue("@a", ID);
                        command.Parameters.AddWithValue("@b", IDLien);
                        command.ExecuteNonQuery();
                        connection.closeConnection();
                        MessageBox.Show("Base de données mise à jour..");
                    }

                }
                IDLien = 0;
                DisplayDataCombo();
            }
        }

        private void btnRafraichirSelect_Click(object sender, EventArgs e)
        {
            DisplayDataLien();
            IDLien = 0;
            textBox4.Text = "";
            comboBox2.Text = "";
        }

        private void textBoxCommandeQuantite_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxCommandeQuantite.Text, "[^0-9]"))
            {
                MessageBox.Show("Entrer un nombre entier..");
                textBoxCommandeQuantite.Text = textBoxCommandeQuantite.Text.Remove(textBoxCommandeQuantite.Text.Length - 1);
            }
        }

        private void dgvLien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvLien.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    IDLien = Convert.ToInt32(dgvLien.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }

            ChangeLabel();
        }

        private void DisplayDataCombo()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            comboBox4.Items.Clear();
            if (choix == 1)
            {
                MySqlDataAdapter command = new MySqlDataAdapter("select * from CommanderPiece;", connection.Connection);
                connection.openConnection();
                command.Fill(dt);
                dgvCombo.DataSource = dt;
                connection.closeConnection();
                string[] columns = { "Num. commande", "Num. Pièce"};
                comboBox4.Items.AddRange(columns);
                for (int i = 0; i < columns.Length; i++)
                {
                    dgvCombo.Columns[i].HeaderCell.Value = columns[i];
                }
            }
            else if (choix == 2)
            {
                MySqlDataAdapter command = new MySqlDataAdapter("select * from CommanderModele;", connection.Connection);
                connection.openConnection();
                command.Fill(dt);
                dgvCombo.DataSource = dt;
                connection.closeConnection();
                string[] columns = { "Num. commande", "Num. modèle"};
                comboBox4.Items.AddRange(columns);
                for (int i = 0; i < columns.Length; i++)
                {
                    dgvCombo.Columns[i].HeaderCell.Value = columns[i];
                }
            }
            else if (choix == 3)
            {
                MySqlDataAdapter command = new MySqlDataAdapter("select * from CommandeClient;", connection.Connection);
                connection.openConnection();
                command.Fill(dt);
                dgvCombo.DataSource = dt;
                connection.closeConnection();
                string[] columns = { "Num. Commande", "ID. CLient" };
                comboBox4.Items.AddRange(columns);
                for (int i = 0; i < columns.Length; i++)
                {
                    dgvCombo.Columns[i].HeaderCell.Value = columns[i];
                }
            }
            else if (choix == 4)
            {
                MySqlDataAdapter command = new MySqlDataAdapter("select * from CommandeBoutique;", connection.Connection);
                connection.openConnection();
                command.Fill(dt);
                dgvCombo.DataSource = dt;
                connection.closeConnection();
                string[] columns = { "Num. Commande", "ID. Boutique" };
                comboBox4.Items.AddRange(columns);
                for (int i = 0; i < columns.Length; i++)
                {
                    dgvCombo.Columns[i].HeaderCell.Value = columns[i];
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCombo.Sort(dgvCombo.Columns[comboBox4.SelectedIndex], ListSortDirection.Ascending);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                int index = comboBox4.SelectedIndex;
                index = index == -1 ? 0 : index;

                if (choix == 1)
                {
                    string[] columns = { "numUnique_Commande_P", "numProduit_CommanderPiece", "quantite"};
                    (dgvLien.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox4.Text);
                }
                else if (choix == 2)
                {
                    string[] columns = { "numUnique_Commande_M", "numProduit_CommanderModele", "quantite" };
                    (dgvLien.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox4.Text);
                }
                else if (choix == 3)
                {
                    string[] columns = { "numUnique_Comande_C", "idClient_Commande"};
                    (dgvLien.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox4.Text);
                }
                else if (choix == 4)
                {
                    string[] columns = { "numUnique_Comande_M", "idBoutique_Commande" };
                    (dgvLien.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columns[index], textBox4.Text);
                }
            }
            else
            {
                DisplayDataCombo();
            }
        }

        private void btnRafraichirLien_Click(object sender, EventArgs e)
        {
            DisplayDataCombo();
            IDCombo[0] = 0;
            IDCombo[1] = 0;
            textBox5.Text = "";
            comboBox4.Text = "";
        }

        private void btnSupLien_Click(object sender, EventArgs e)
        {
            if(IDCombo[0] == 0 || IDCombo[1] == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne.....");
            }
            else
            {
                if (choix == 1)
                {

                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    MySqlCommand command = new MySqlCommand("DELETE FROM CommanderPiece WHERE numUnique_Commande_P=@a and numProduit_CommanderPiece=@b;", connection.Connection);
                    command.Parameters.AddWithValue("@a", IDCombo[0]);
                    command.Parameters.AddWithValue("@b", IDCombo[1]);
                    command.Parameters.AddWithValue("@c", Int32.Parse(textBoxCommandeQuantite.Text.Trim()));
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    DisplayDataCombo();
                }
                else if (choix == 2)
                {
                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    MySqlCommand command = new MySqlCommand("DELETE FROM CommanderModele WHERE numUnique_Commande_M=@a and numProduit_CommanderModele=@b;", connection.Connection);
                    command.Parameters.AddWithValue("@a", IDCombo[0]);
                    command.Parameters.AddWithValue("@b", IDCombo[1]);
                    command.Parameters.AddWithValue("@c", Int32.Parse(textBoxCommandeQuantite.Text.Trim()));
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    DisplayDataCombo();
                }
                else if (choix == 3)
                {
                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    MySqlCommand command = new MySqlCommand("DELETE FROM CommandeClient WHERE numUnique_Commande_C=@a and idClient_Commande=@b;", connection.Connection);
                    command.Parameters.AddWithValue("@a", IDCombo[0]);
                    command.Parameters.AddWithValue("@b", IDCombo[1]);
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    DisplayDataCombo();
                }
                else if (choix == 4)
                {
                    DataConnection connection = new DataConnection();
                    connection.openConnection();
                    MySqlCommand command = new MySqlCommand("DELETE FROM CommandeBoutique WHERE numUnique_Commande_B=@a and idBoutique_Commande=@b;", connection.Connection);
                    command.Parameters.AddWithValue("@a", IDCombo[0]);
                    command.Parameters.AddWithValue("@b", IDCombo[1]);
                    command.ExecuteNonQuery();
                    connection.closeConnection();
                    MessageBox.Show("Base de données mise à jour..");
                    DisplayDataCombo();
                }
            }
        }
    

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvLien.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    IDCombo[0] = Convert.ToInt32(dgvCombo.Rows[e.RowIndex].Cells[0].Value.ToString());
                    IDCombo[1] = Convert.ToInt32(dgvCombo.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
