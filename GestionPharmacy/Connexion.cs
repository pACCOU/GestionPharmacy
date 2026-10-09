using System;
using System.Windows.Forms;

namespace GestionPharmacy
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void closeLbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passwordTb_TextChanged(object sender, EventArgs e)
        {
        }

        private void connexionBtn_Click(object sender, EventArgs e)
        {
            if (userNameTb.Text.Trim() == "" || passwordTb.Text == "")
            {
                MessageBox.Show("Entrer un nom d'utilisateur et un mot de passe");
                return;
            }

            try
            {
                // Bug d'origine : la requête comparait le mot de passe au contrôle
                // (passwordTb) et non à son texte, la connexion échouait toujours.
                int n = Convert.ToInt32(Db.Scalar(
                    "SELECT COUNT(*) FROM AgentTbl WHERE AgNom = @nom AND AgPdw = @pwd",
                    Db.P("@nom", userNameTb.Text.Trim()),
                    Db.P("@pwd", passwordTb.Text)));

                if (n == 1)
                {
                    new Medicaments().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base : " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Hide();
        }
    }
}
