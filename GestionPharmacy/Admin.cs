using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPharmacy
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void connexionBtn_Click(object sender, EventArgs e)
        {
            if (passTb.Text == "")
            {
                MessageBox.Show("Entrez le mot de passe de l'Admiistrateur");
            }
            else if (passTb.Text == "Admin")
            {
                Agents Ag = new Agents();
                Ag.Show();
                this.Hide();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Connexion Connect = new Connexion();
            Connect.Show();
            this.Hide();
            this.Close();
        }
    }
}
