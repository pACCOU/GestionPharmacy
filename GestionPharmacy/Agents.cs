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

namespace GestionPharmacy
{
    public partial class Agents : Form
    {
        public Agents()
        {
            InitializeComponent();
            afficher();
            reinitialiser();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB) \ MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Documents\MaPharmacie.mdf; Integrated Security=True; Connect Timeout=30");
        private void reinitialiser()
        {

            nomAgTb.Text = "";
            dateNaissAg.Text = "";
            telAgTb.Text = "";
            genreAgCbx.SelectedIndex = -1;
            pdwAgTb.Text = "";
            
            Cle = 0;
        }
        private void afficher()
        {
            Con.Open();
            string Req = "Select * From AgentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            agentsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void ajoutAgBtn_Click(object sender, EventArgs e)
        {
            if (nomAgTb.Text == "" || telAgTb.Text == "" || genreAgCbx.SelectedIndex == -1 || pdwAgTb.Text == "")
            {
                MessageBox.Show("Completez les Informations Manquantes");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "Insert into AgentTbl values( '" + nomAgTb.Text + "', '" + dateNaissAg.Value.Date + "', '" + telAgTb.Text + "','" + genreAgCbx.SelectedItem.ToString() + "', '" + pdwAgTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Ajouté Avec succes");

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

        private void modifierAgBtn_Click(object sender, EventArgs e)
        {
            if (nomAgTb.Text == "" || telAgTb.Text == "" || pdwAgTb.Text == "" || genreAgCbx.SelectedIndex == -1)
            {
                MessageBox.Show("Information Manquante");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "Update AgentTbl set AgNom='" + nomAgTb.Text + "', AgTel='" + telAgTb.Text + "', AgPdw='" + pdwAgTb.Text + "', AgDateNaiss='" + dateNaissAg.Value.Date + "', AgSex='" + genreAgCbx.SelectedItem.ToString() + "' Where AgNum =" + Cle +"";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Modifié Avec succes");

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

        private void supprimerAgBtn_Click(object sender, EventArgs e)
        {
            if (Cle == 0)
            {
                MessageBox.Show("Selectionner l'agent à supprimer");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "delete from AgentTbl where AgNum=" + Cle + "";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Supprimé Avec succes");

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

        private void reinitialiserAgBtn_Click(object sender, EventArgs e)
        {
            reinitialiser();
        }
        int Cle = 0;
        private void agentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nomAgTb.Text = agentsDGV.SelectedRows[0].Cells[1].Value.ToString();
            dateNaissAg.Text = agentsDGV.SelectedRows[0].Cells[2].Value.ToString();
            telAgTb.Text = agentsDGV.SelectedRows[0].Cells[3].Value.ToString();

            genreAgCbx.SelectedValue = agentsDGV.SelectedRows[0].Cells[4].Value.ToString();
            pdwAgTb.Text = agentsDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (nomAgTb.Text == "")
                Cle = 0;
            else
                Cle = Convert.ToInt32(agentsDGV.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}
