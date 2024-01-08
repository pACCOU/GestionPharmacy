using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GestionPharmacy
{
    public partial class Medicaments : Form
    {
        public Medicaments()
        {
            InitializeComponent();
            afficher();
            reinitialiser();
            RemplirMed();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB) \ MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Documents\MaPharmacie.mdf; Integrated Security=True; Connect Timeout=30");
        private void reinitialiser()
        {

            nomMedTb.Text = "";
            prixMedTb.Text = "";
            qteMedTb.Text = "";
            fabMedCbx.Text = "";
            expMedDate.Text = "";
            Cle = 0;
        }
        private void afficher()
        {
            Con.Open();
            string Req = "Select * From MedicamentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            medicamentsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void RemplirMed() {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MedNum From MedicamentTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MedNum", typeof(int));
            dt.Load(Rdr);
            fabMedCbx.ValueMember = "MedNum";
            fabMedCbx.DataSource = dt;
            Con.Close();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (nomMedTb.Text == "" || prixMedTb.Text == "" || qteMedTb.Text == "" || fabMedCbx.SelectedIndex == -1)
            {
                MessageBox.Show("Information Manquante");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "Update MedicamentTbl set MedNom='" + nomMedTb.Text + "', MedPrix='" + prixMedTb.Text + "', MedQte='" + qteMedTb.Text + "', MedFab='" + fabMedCbx.SelectedValue.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Médicaments Modifié Avec succes");

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
        private void ajouterBtn_Click(object sender, EventArgs e)
        {
            if (nomMedTb.Text == "" || prixMedTb.Text == "" || qteMedTb.Text == "" || fabMedCbx.SelectedIndex == -1)
            {
                MessageBox.Show("Completez les Informations Manquantes");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "Insert into MedicamentTbl values( '" + nomMedTb.Text + "', '" + prixMedTb.Text + "', '" + qteMedTb.Text + "','" + fabMedCbx.SelectedValue.ToString() + "', '" + expMedDate.Value.Date + "')" ;
            SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Médicaments Ajouté Avec succes");

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
                    string Req = "delete from MedicamentsTbl where MedNum=" + Cle + "";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Médicament Supprimé Avec succes");

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

        private void reinitialiserBtn_Click(object sender, EventArgs e)
        {
            reinitialiser();
        }
        int Cle = 0;
        private void medicamentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nomMedTb.Text = medicamentsDGV.SelectedRows[0].Cells[1].Value.ToString();
            prixMedTb.Text = medicamentsDGV.SelectedRows[0].Cells[2].Value.ToString();
            qteMedTb.Text = medicamentsDGV.SelectedRows[0].Cells[3].Value.ToString();           

            fabMedCbx.SelectedValue = medicamentsDGV.SelectedRows[0].Cells[4].Value.ToString();
            expMedDate.Text = medicamentsDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (nomMedTb.Text == "")
                Cle = 0;
            else
                Cle = Convert.ToInt32(medicamentsDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Fabricants Fab = new Fabricants();
            Fab.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
