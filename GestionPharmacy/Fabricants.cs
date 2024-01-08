using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace GestionPharmacy
{ 
    public partial class Fabricants : Form
    {
       
        public Fabricants()
        {
            InitializeComponent();
            afficher();
            reinitialiser();
        }
        SqlConnection Con = new SqlConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Mapharmacie.accdb");
        private void reinitialiser()
        {
           
            nomFabTb.Text = "";
            addFabTb.Text = "";
            telFabTb.Text = "";
            descFabTb.Text = "";
            Cle = 0;
        }
        private void afficher()
        {
            Con.Open();
            string Req = "Select * From FabricantTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            fabricantsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ReinitialiseBTN_Click(object sender, EventArgs e)
        {
            reinitialiser();
        }

        private void Fabricants_Load(object sender, EventArgs e)
        {

        }

        private void ajouterBtn_Click(object sender, EventArgs e)
        {
            if (nomFabTb.Text == "" || addFabTb.Text == "" || descFabTb.Text == "" || telFabTb.Text == "")
            {
                MessageBox.Show("Completez les Informations Manquantes");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "Insert into FabricantTbl values( '" + nomFabTb.Text + "', '" + addFabTb.Text + "', '" + descFabTb.Text + "','" + telFabTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fabricant Ajouté Avec succes");

                    Con.Close();
                    afficher();
                    reinitialiser();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void modifierBtn_Click(object sender, EventArgs e)
        {
            if (nomFabTb.Text == "" || addFabTb.Text == "" || descFabTb.Text == "" || telFabTb.Text == "")
            {
                MessageBox.Show("Information Manquante");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "Update FabricantTbl set FabNom='" + nomFabTb.Text + "', FabAd='" + addFabTb.Text + "', FabDesc='" + descFabTb.Text + "', FabAd='" + telFabTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fabricant Modifié Avec succes");

                    Con.Close();
                    afficher();
                    reinitialiser();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        
        }

        private void supprimerBtn_Click(object sender, EventArgs e)
        {
            if (Cle == 0)
            {
                MessageBox.Show("Selectionner le Fabricant à supprimer");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "delete from FabriquantTbl where FabNum=" + Cle + "";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fabricant Supprimé Avec succes");

                    Con.Close();
                    afficher();
                    reinitialiser();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Cle = 0;
        private void fabricantsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
                nomFabTb.Text = fabricantsDGV.SelectedRows[0].Cells[1].Value.ToString();
                addFabTb.Text = fabricantsDGV.SelectedRows[0].Cells[2].Value.ToString();
                descFabTb.Text = fabricantsDGV.SelectedRows[0].Cells[3].Value.ToString();
                telFabTb.Text = fabricantsDGV.SelectedRows[0].Cells[4].Value.ToString();

                if (nomFabTb.Text == "")
                { 
                    Cle = 0;
                }
                else 
                { 
                    Cle = Convert.ToInt32(fabricantsDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }

        private void label3_Click(object sender, EventArgs e)
        {
            Medicaments Med = new Medicaments();
            Med.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

