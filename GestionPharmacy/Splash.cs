using System;
using System.Windows.Forms;

namespace GestionPharmacy
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int pdd = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pdd +=1;
            ProgressBar.Value = pdd;
            percentLbl.Text = pdd + "%";
            if (ProgressBar.Value == 100)
            {
                ProgressBar.Value = 0;
                timer1.Stop();
                Connexion MyCon = new Connexion();
                MyCon.Show();
                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
