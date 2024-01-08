namespace GestionPharmacy
{
    partial class Splash
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProgressBar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.percentLbl = new System.Windows.Forms.Label();
            this.ProgressBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Controls.Add(this.percentLbl);
            this.ProgressBar.FillColor = System.Drawing.Color.MediumAquamarine;
            this.ProgressBar.FillThickness = 8;
            this.ProgressBar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ProgressBar.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.ProgressBar.Location = new System.Drawing.Point(263, 124);
            this.ProgressBar.Minimum = 0;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressColor = System.Drawing.Color.White;
            this.ProgressBar.ProgressColor2 = System.Drawing.Color.White;
            this.ProgressBar.ProgressThickness = 13;
            this.ProgressBar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ProgressBar.Size = new System.Drawing.Size(216, 216);
            this.ProgressBar.TabIndex = 0;
            this.ProgressBar.Text = "guna2CircleProgressBar1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = " PHARMACY MANAGEMENT ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // percentLbl
            // 
            this.percentLbl.AutoSize = true;
            this.percentLbl.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLbl.ForeColor = System.Drawing.Color.White;
            this.percentLbl.Location = new System.Drawing.Point(89, 68);
            this.percentLbl.Name = "percentLbl";
            this.percentLbl.Size = new System.Drawing.Size(51, 44);
            this.percentLbl.TabIndex = 2;
            this.percentLbl.Text = "%";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressBar);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ProgressBar.ResumeLayout(false);
            this.ProgressBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleProgressBar ProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label percentLbl;
    }
}

