using System;
using System.Windows.Forms;

namespace GestionPharmacy
{
    public partial class Medicaments : Form
    {
        private int cle = 0;   // MedNum de la ligne sélectionnée (0 = aucune)

        public Medicaments()
        {
            InitializeComponent();
            afficher();
            remplirFabricants();
            reinitialiser();
        }

        private void reinitialiser()
        {
            nomMedTb.Text = "";
            prixMedTb.Text = "";
            qteMedTb.Text = "";
            fabMedCbx.SelectedIndex = -1;
            expMedDate.Value = DateTime.Today;
            cle = 0;
        }

        private void afficher()
        {
            try
            {
                medicamentsDGV.DataSource = Db.Table(
                    "SELECT MedNum, MedNom, MedPrix, MedQte, MedFab, MedExp FROM MedicamentTbl ORDER BY MedNom");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Bug d'origine : la liste déroulante "fabricant" était remplie avec les
        /// numéros de médicaments. Elle liste maintenant les fabricants par nom.
        /// </summary>
        private void remplirFabricants()
        {
            try
            {
                var dt = Db.Table("SELECT FabNum, FabNom FROM FabricantTbl ORDER BY FabNom");
                fabMedCbx.DisplayMember = "FabNom";
                fabMedCbx.ValueMember = "FabNum";
                fabMedCbx.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool champsValides(out decimal prix, out int qte)
        {
            prix = 0; qte = 0;
            if (nomMedTb.Text.Trim() == "" || fabMedCbx.SelectedIndex == -1)
            {
                MessageBox.Show("Complétez les informations manquantes");
                return false;
            }
            if (!decimal.TryParse(prixMedTb.Text, out prix) || prix < 0)
            {
                MessageBox.Show("Prix invalide");
                return false;
            }
            if (!int.TryParse(qteMedTb.Text, out qte) || qte < 0)
            {
                MessageBox.Show("Quantité invalide");
                return false;
            }
            return true;
        }

        private void ajouterBtn_Click(object sender, EventArgs e)
        {
            decimal prix; int qte;
            if (!champsValides(out prix, out qte)) return;
            try
            {
                Db.Execute(
                    "INSERT INTO MedicamentTbl (MedNom, MedPrix, MedQte, MedFab, MedExp) VALUES (@nom, @prix, @qte, @fab, @exp)",
                    Db.P("@nom", nomMedTb.Text.Trim()),
                    Db.P("@prix", prix),
                    Db.P("@qte", qte),
                    Db.P("@fab", Convert.ToInt32(fabMedCbx.SelectedValue)),
                    Db.P("@exp", expMedDate.Value.Date));
                MessageBox.Show("Médicament ajouté avec succès");
                afficher();
                reinitialiser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // Bouton "Modifier"
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (cle == 0) { MessageBox.Show("Sélectionnez le médicament à modifier"); return; }
            decimal prix; int qte;
            if (!champsValides(out prix, out qte)) return;
            try
            {
                // Bug d'origine : UPDATE sans WHERE -> modifiait TOUS les médicaments.
                Db.Execute(
                    "UPDATE MedicamentTbl SET MedNom=@nom, MedPrix=@prix, MedQte=@qte, MedFab=@fab, MedExp=@exp WHERE MedNum=@id",
                    Db.P("@nom", nomMedTb.Text.Trim()),
                    Db.P("@prix", prix),
                    Db.P("@qte", qte),
                    Db.P("@fab", Convert.ToInt32(fabMedCbx.SelectedValue)),
                    Db.P("@exp", expMedDate.Value.Date),
                    Db.P("@id", cle));
                MessageBox.Show("Médicament modifié avec succès");
                afficher();
                reinitialiser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void supprimerBtn_Click(object sender, EventArgs e)
        {
            if (cle == 0) { MessageBox.Show("Sélectionnez le médicament à supprimer"); return; }
            if (MessageBox.Show("Supprimer ce médicament ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                // Bug d'origine : nom de table erroné (MedicamentsTbl).
                Db.Execute("DELETE FROM MedicamentTbl WHERE MedNum=@id", Db.P("@id", cle));
                MessageBox.Show("Médicament supprimé avec succès");
                afficher();
                reinitialiser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void reinitialiserBtn_Click(object sender, EventArgs e)
        {
            reinitialiser();
        }

        private void medicamentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = medicamentsDGV.Rows[e.RowIndex];
            if (row.Cells[0].Value == null) { cle = 0; return; }

            cle = Convert.ToInt32(row.Cells[0].Value);
            nomMedTb.Text = Convert.ToString(row.Cells[1].Value);
            prixMedTb.Text = Convert.ToString(row.Cells[2].Value);
            qteMedTb.Text = Convert.ToString(row.Cells[3].Value);
            fabMedCbx.SelectedValue = row.Cells[4].Value;
            DateTime exp;
            if (DateTime.TryParse(Convert.ToString(row.Cells[5].Value), out exp))
                expMedDate.Value = exp;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Fabricants().Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
