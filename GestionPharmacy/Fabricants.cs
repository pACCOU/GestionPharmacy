using System;
using System.Windows.Forms;

namespace GestionPharmacy
{
    public partial class Fabricants : Form
    {
        private int cle = 0;   // FabNum de la ligne sélectionnée (0 = aucune)

        public Fabricants()
        {
            InitializeComponent();
            afficher();
            reinitialiser();
        }

        private void reinitialiser()
        {
            nomFabTb.Text = "";
            addFabTb.Text = "";
            telFabTb.Text = "";
            descFabTb.Text = "";
            cle = 0;
        }

        private void afficher()
        {
            try
            {
                // Bug d'origine : ce formulaire utilisait une chaîne OLEDB (Access)
                // avec un SqlConnection -> plantait systématiquement à l'ouverture.
                fabricantsDGV.DataSource = Db.Table(
                    "SELECT FabNum, FabNom, FabAd, FabDesc, FabTel FROM FabricantTbl ORDER BY FabNom");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool champsValides()
        {
            if (nomFabTb.Text.Trim() == "" || addFabTb.Text.Trim() == "" ||
                descFabTb.Text.Trim() == "" || telFabTb.Text.Trim() == "")
            {
                MessageBox.Show("Complétez les informations manquantes");
                return false;
            }
            return true;
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
            if (!champsValides()) return;
            try
            {
                Db.Execute(
                    "INSERT INTO FabricantTbl (FabNom, FabAd, FabDesc, FabTel) VALUES (@nom, @ad, @desc, @tel)",
                    Db.P("@nom", nomFabTb.Text.Trim()),
                    Db.P("@ad", addFabTb.Text.Trim()),
                    Db.P("@desc", descFabTb.Text.Trim()),
                    Db.P("@tel", telFabTb.Text.Trim()));
                MessageBox.Show("Fabricant ajouté avec succès");
                afficher();
                reinitialiser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void modifierBtn_Click(object sender, EventArgs e)
        {
            if (cle == 0) { MessageBox.Show("Sélectionnez le fabricant à modifier"); return; }
            if (!champsValides()) return;
            try
            {
                // Bugs d'origine : UPDATE sans WHERE (tous les fabricants modifiés)
                // et le téléphone écrasait l'adresse (FabAd affecté deux fois).
                Db.Execute(
                    "UPDATE FabricantTbl SET FabNom=@nom, FabAd=@ad, FabDesc=@desc, FabTel=@tel WHERE FabNum=@id",
                    Db.P("@nom", nomFabTb.Text.Trim()),
                    Db.P("@ad", addFabTb.Text.Trim()),
                    Db.P("@desc", descFabTb.Text.Trim()),
                    Db.P("@tel", telFabTb.Text.Trim()),
                    Db.P("@id", cle));
                MessageBox.Show("Fabricant modifié avec succès");
                afficher();
                reinitialiser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void supprimerBtn_Click(object sender, EventArgs e)
        {
            if (cle == 0) { MessageBox.Show("Sélectionnez le fabricant à supprimer"); return; }
            if (MessageBox.Show("Supprimer ce fabricant ? Ses médicaments doivent d'abord être réaffectés.",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                // Bug d'origine : nom de table erroné (FabriquantTbl).
                Db.Execute("DELETE FROM FabricantTbl WHERE FabNum=@id", Db.P("@id", cle));
                MessageBox.Show("Fabricant supprimé avec succès");
                afficher();
                reinitialiser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void fabricantsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = fabricantsDGV.Rows[e.RowIndex];
            if (row.Cells[0].Value == null) { cle = 0; return; }

            cle = Convert.ToInt32(row.Cells[0].Value);
            nomFabTb.Text = Convert.ToString(row.Cells[1].Value);
            addFabTb.Text = Convert.ToString(row.Cells[2].Value);
            descFabTb.Text = Convert.ToString(row.Cells[3].Value);
            telFabTb.Text = Convert.ToString(row.Cells[4].Value);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Medicaments().Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
