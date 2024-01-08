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
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB) \ MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Documents\MaPharmacie.mdf; Integrated Security=True; Connect Timeout=30");

        private void closeLbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passwordTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void connexionBtn_Click(object sender, EventArgs e)
        {
            if (userNameTb.Text == "" || passwordTb.Text == "")
            {
                MessageBox.Show("Entrer Un Nom d'Utilisateur et Mot de Passe");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from AgentTbl where AgNom = '" + userNameTb.Text + "' AND AgPass= '" + passwordTb + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Medicaments Med = new Medicaments();
                    Med.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Mot de Passe Incorrect");
                }
                Con.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
            Con.Close();
        }
    }
}
