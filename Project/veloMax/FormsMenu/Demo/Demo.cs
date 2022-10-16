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
using System.IO;

namespace veloMax.FormsMenu.Demo
{
    public partial class Demo : Form
    {
        int value = 0;
        public Demo()
        {
            InitializeComponent();
            btnExport.Visible = false;
            labelenonce.Visible = false;
            labelvalue.Visible = false;
            dgvCumul.Visible = false;
            dgvFourni.Visible = false;
            dgvProduit.Visible = false;
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (value == 0)
            {
                btnExport.Visible = false;
                labelenonce.Visible = false;
                labelvalue.Visible = false;
                dgvCumul.Visible = false;
                dgvFourni.Visible = false;
                dgvProduit.Visible = false;
            }
            value += 1;

            if (value == 1)
            {
                NombreClient();
                labelenonce.Visible = true;
                labelvalue.Visible = true;
            }
            else if(value == 2)
            {
                DgvCumulParticulier();
                dgvCumul.Visible = true;
            }
            else if (value == 3)
            {
                StockInf2();
                dgvProduit.Visible = true;
            }
            else if (value == 4)
            {
                Fournisseur();
                dgvFourni.Visible = true;
            }
            else if (value == 5)
            {
                DataConnection connection = new DataConnection();
                DataTable dt = new DataTable();
                MySqlDataAdapter command = new MySqlDataAdapter("SELECT P.numProduit, P.descriptionP, (sum(A.quantite) - sum(Cp.quantite)) " +
                "FROM Piece as P " +
                "Join Approvisionne as A on P.numProduit = A.numProduit_Appro " +
                "join CommanderPiece as Cp on A.numProduit_Appro = Cp.numProduit_CommanderPiece " +
                "GROUP BY P.numProduit having (sum(A.quantite) - sum(Cp.quantite)) <= 20 order by P.numProduit asc;", connection.Connection);
                connection.openConnection();
                command.Fill(dt);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                ds.WriteXml(File.OpenWrite(@"stockinf20.xml"));
                //projet/bin/debug/net.../stockinf2.xml
                connection.closeConnection();
                btnExport.Visible = true;
                value = 0;
            }
        }

        private void NombreClient()
        {
            int add = 0;
            DataConnection connection = new DataConnection();
            connection.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT count(*) From Individu;", connection.Connection);
            MySqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                add = Int32.Parse(data["count(*)"].ToString());
            }
            connection.closeConnection();

            connection = new DataConnection();
            connection.openConnection();
            command = new MySqlCommand("SELECT count(*) From BoutiqueSpecialise;", connection.Connection);
            data = command.ExecuteReader();
            while (data.Read())
            {
                labelvalue.Text = Convert.ToString(Int32.Parse(data["count(*)"].ToString()) + add);
            }
            connection.closeConnection();
        }

        private void DgvCumulParticulier()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select I.nom, sum(Cp.quantite * P.prixUnitaire), sum(Cm.quantite * M.prixUnitaire) " +
                "from Individu as I " +
                "join CommandeClient as Cc on I.idClient = Cc.idClient_Commande " +
                "join CommanderPiece as Cp on Cc.numUnique_Commande_C = Cp.numUnique_Commande_P " +
                "join Piece as P on Cp.numProduit_CommanderPiece = P.numProduit " +
                "join CommanderModele as Cm on Cc.numUnique_Commande_C = Cm.numUnique_Commande_M " +
                "join Modele as M on Cm.numProduit_CommanderModele = M.numProduit " +
                "group by numUnique_Commande_P, Cm.numUnique_Commande_M, I.idClient " +
                "order by I.nom asc; ", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            dgvCumul.DataSource = dt;
            connection.closeConnection();
            string[] columns = { "Nom du client", "Total commandés en euro : Pièces", "Total commandés en euro : Modèle" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvCumul.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void DgvCumulBoutique()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("select B.nomCompagnie, sum(Cp.quantite * P.prixUnitaire), sum(Cm.quantite * M.prixUnitaire) " +
                "from BoutiqueSpecialise as B " +
                "join CommandeBoutique as Cb on B.idBoutique = Cb.idBoutique_Commande " +
                "join CommanderPiece as Cp on Cb.numUnique_Commande_B = Cp.numUnique_Commande_P " +
                "join Piece as P on Cp.numProduit_CommanderPiece = P.numProduit " +
                "join CommanderModele as Cm on Cb.numUnique_Commande_B = Cm.numUnique_Commande_M " +
                "join Modele as M on Cm.numProduit_CommanderModele = M.numProduit " +
                "group by numUnique_Commande_P, Cm.numUnique_Commande_M, B.idBoutique " +
                "order by B.nomCompagnie asc;", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            dgvCumul.DataSource = dt;
            connection.closeConnection();
            string[] columns = { "Nom de la compganie", "Total commandés en euro : Pièces", "Total commandés en euro : Modèle" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvCumul.Columns[i].HeaderCell.Value = columns[i];
            }
        }


        private void btnParticulier_Click(object sender, EventArgs e)
        {
            DgvCumulParticulier();
        }

        private void btnBoutique_Click(object sender, EventArgs e)
        {
            DgvCumulBoutique();
        }

        private void StockInf2()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("SELECT P.numProduit, P.descriptionP, (sum(A.quantite) - sum(Cp.quantite)) " +
            "FROM Piece as P " +
            "Join Approvisionne as A on P.numProduit = A.numProduit_Appro " +
            "join CommanderPiece as Cp on A.numProduit_Appro = Cp.numProduit_CommanderPiece " +
            "GROUP BY P.numProduit having (sum(A.quantite) - sum(Cp.quantite)) <= 20; ", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            dgvProduit.DataSource = dt;
            connection.closeConnection();
            string[] columns = { "Num. du produit", "Description","Stock <= 20" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvProduit.Columns[i].HeaderCell.Value = columns[i];
            }
        }

        private void Fournisseur()
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("SELECT (A.quantite * count(A.numProduit_Appro)), F.nomEntreprise From Approvisionne as A " +
            "join Fournisseur as F on A.siret_Appro = F.siret " +
            "Group by F.nomEntreprise order by F.nomEntreprise asc;", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            dgvFourni.DataSource = dt;
            connection.closeConnection();
            string[] columns = { "Nombre de Pièce total Approvisionnées", "Entreprise" };
            for (int i = 0; i < columns.Length; i++)
            {
                dgvFourni.Columns[i].HeaderCell.Value = columns[i];
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            DataConnection connection = new DataConnection();
            DataTable dt = new DataTable();
            MySqlDataAdapter command = new MySqlDataAdapter("SELECT P.numProduit, P.descriptionP, (sum(A.quantite) - sum(Cp.quantite)) " +
            "FROM Piece as P " +
            "Join Approvisionne as A on P.numProduit = A.numProduit_Appro " +
            "join CommanderPiece as Cp on A.numProduit_Appro = Cp.numProduit_CommanderPiece " +
            "GROUP BY P.numProduit having (sum(A.quantite) - sum(Cp.quantite)) <= 20 order by P.numProduit asc;", connection.Connection);
            connection.openConnection();
            command.Fill(dt);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.WriteXml(File.OpenWrite(@"C:/Users/Stockinf20.xml"));
            connection.closeConnection();
        }

        private void Demo_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
