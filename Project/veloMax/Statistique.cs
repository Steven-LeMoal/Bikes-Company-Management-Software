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
    public partial class Statistique : Form
    {
        public Statistique()
        {
            InitializeComponent();
            Dgv1();
            //Dgv1Bis();
            Dgv2();
            Dgv3();
            Dgv4();
            MoyenneCommande();

        }

        private void Dgv1()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select Cp.numProduit_CommanderPiece, sum(Cp.quantite) from CommanderPiece as Cp group by Cp.numProduit_CommanderPiece;", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.closeConnection();
            string[] columns = { "Num. de la pièce", "Quantité total commandé"};
            for (int i = 0; i < columns.Length; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void Dgv1Bis()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select Cm.numProduit_CommanderModele, sum(Cm.quantite) from CommanderModele as Cm group by Cm.numProduit_CommanderModele;", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.closeConnection();
            string[] columns = { "Num. du Modèle", "Quantité total commandé" };
            for (int i = 0; i < columns.Length; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void Dgv2()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select Pf.descriptionPF, I.nom, I.prenom from Adhere as A join ProgramFidelite as Pf on Pf.numProgramme = A.numProgramme_Adhere join Individu as I on I.idClient = A.idClient_Adhere order by Pf.descriptionPF, I.nom, I.prenom; ", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            dataGridView2.DataSource = dt;
            connection.closeConnection();
            string[] columns = { "Nom du programme", "Nom du client", "Prenom du client" };
            for (int i = 0; i < columns.Length; i++)
            {
                dataGridView2.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void Dgv3()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select Pf.descriptionPF, I.nom, I.prenom, DATE_ADD(A.dateAdhesion, interval + Pf.duree year) from Adhere as A join ProgramFidelite as Pf on Pf.numProgramme = A.numProgramme_Adhere join Individu as I on I.idClient = A.idClient_Adhere order by Pf.descriptionPF, I.nom, I.prenom; ", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            dataGridView3.DataSource = dt;
            connection.closeConnection();
            string[] columns = { "Nom du programme", "nom", "prenom","date de fin" };
            for (int i = 0; i < columns.Length; i++)
            {
                dataGridView3.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void Dgv4()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select I.nom, I.prenom, sum(Cp.quantite) from Individu as I join CommandeClient as Cc on I.idClient = Cc.idClient_Commande join CommanderPiece as Cp on Cp.numUnique_Commande_P = Cc.numUnique_Commande_C group by Cp.numUnique_Commande_P having sum(Cp.quantite) = max(Cp.quantite); ", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            dataGridView4.DataSource = dt;
            connection.closeConnection();
            string[] columns = { "Nom du Client", "Prenom du Client", "Somme de pièce commandés (max)" };
            for (int i = 0; i < columns.Length; i++)
            {
                dataGridView4.Columns[i].HeaderCell.Value = columns[i];
            }
        }
        
        private void MoyenneCommande()
        {
            double value = 0;
            int i = 0;
            DataConnection connection = new DataConnection();
            connection.openConnection();
            MySqlCommand command = new MySqlCommand("select avg(Cp.quantite * P.prixUnitaire) from CommanderPiece as Cp join Piece as P on P.numProduit = Cp.numProduit_CommanderPiece group by Cp.numProduit_CommanderPiece; ", connection.Connection);
            MySqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                value += Convert.ToDouble(data["avg(Cp.quantite * P.prixUnitaire)"].ToString());
                i += 1;
            }
            connection.closeConnection();
            labelMoyenne.Text = Convert.ToString(value / i);
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPiece_Click(object sender, EventArgs e)
        {
            Dgv1();
        }

        private void btnModele_Click(object sender, EventArgs e)
        {
            Dgv1Bis();
        }
    }
}
