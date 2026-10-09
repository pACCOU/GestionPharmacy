using System;
using System.Windows.Forms;

namespace GestionPharmacy
{
    public partial class Agents : Form
    {
        private int cle = 0;   // AgNum de la ligne sélectionnée (0 = aucune)

        public Agents()
        {
            InitializeComponent();
            afficher();
            reinitialiser();
        }

        private void reinitialiser()
        {
            nomAgTb.Text = "";
            dateNaissAg.Value = DateTime.Today;
            telAgTb.Text = "";
            genreAgCbx.SelectedIndex = -1;
            pdwAgTb.Text = "";
            cle = 0;
        }

        private void afficher()
        {
            try
            {
                agentsDGV.DataSource = Db.Table(
                    "SELECT AgNum, AgNom, AgDateNaiss, AgTel, AgSex, AgPdw FROM AgentTbl ORDER BY AgNom");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool champsValides()
        {
            if (nomAgTb.Text.Trim() == "" || telAgTb.Text.Trim() == "" ||
                genreAgCbx.SelectedIndex == -1 || pdwAgTb.Text == "")
            {
                MessageBox.Show("Complétez les informations manquantes");
                return false;
            }
            return true;
        }

        private void ajoutAgBtn_Click(object sender, EventArgs e)
        {
            if (!champsValides()) return;
            try
            {
                Db.Execute(
                    "INSERT INTO AgentTbl (AgNom, AgDateNaiss, AgTel, AgSex, AgPdw) VALUES (@nom, @dn, @tel, @sexe, @pwd)",
                    Db.P("@nom", nomAgTb.Text.Trim()),
                    Db.P("@dn", dateNaissAg.Value.Date),
                    Db.P("@tel", telAgTb.Text.Trim()),
                    Db.P("@sexe", genreAgCbx.SelectedItem.ToString()),
                    Db.P("@pwd", pdwAgTb.Text));
                MessageBox.Show("Agent ajouté avec succès");
                afficher();
                reinitialiser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void modifierAgBtn_Click(object sender, EventArgs e)
        {
            if (cle == 0) { MessageBox.Show("Sélectionnez l'agent à modifier"); return; }
            if (!champsValides()) return;
            try
            {
                Db.Execute(
                    "UPDATE AgentTbl SET AgNom=@nom, AgDateNaiss=@dn, AgTel=@tel, AgSex=@sexe, AgPdw=@pwd WHERE AgNum=@id",
                    Db.P("@nom", nomAgTb.Text.Trim()),
                    Db.P("@dn", dateNaissAg.Value.Date),
                    Db.P("@tel", telAgTb.Text.Trim()),
                    Db.P("@sexe", genreAgCbx.SelectedItem.ToString()),
                    Db.P("@pwd", pdwAgTb.Text),
                    Db.P("@id", cle));
                MessageBox.Show("Agent modifié avec succès");
                afficher();
                reinitialiser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void supprimerAgBtn_Click(object sender, EventArgs e)
        {
            if (cle == 0) { MessageBox.Show("Sélectionnez l'agent à supprimer"); return; }
            if (MessageBox.Show("Supprimer cet agent ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                Db.Execute("DELETE FROM AgentTbl WHERE AgNum=@id", Db.P("@id", cle));
                MessageBox.Show("Agent supprimé avec succès");
                afficher();
                reinitialiser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void reinitialiserAgBtn_Click(object sender, EventArgs e)
        {
            reinitialiser();
        }

        private void agentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = agentsDGV.Rows[e.RowIndex];
            if (row.Cells[0].Value == null) { cle = 0; return; }

            cle = Convert.ToInt32(row.Cells[0].Value);
            nomAgTb.Text = Convert.ToString(row.Cells[1].Value);
            DateTime dn;
            if (DateTime.TryParse(Convert.ToString(row.Cells[2].Value), out dn))
                dateNaissAg.Value = dn;
            telAgTb.Text = Convert.ToString(row.Cells[3].Value);
            genreAgCbx.SelectedItem = Convert.ToString(row.Cells[4].Value);
            pdwAgTb.Text = Convert.ToString(row.Cells[5].Value);
        }
    }
}
