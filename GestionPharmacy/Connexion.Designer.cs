namespace GestionPharmacy
{
    partial class Connexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.userNameTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.passwordTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.connexionBtn = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.closeLbl = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 443);
            this.panel1.TabIndex = 0;
            // 
            // userNameTb
            // 
            this.userNameTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userNameTb.DefaultText = "";
            this.userNameTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.userNameTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.userNameTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.userNameTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.userNameTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userNameTb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userNameTb.Location = new System.Drawing.Point(456, 170);
            this.userNameTb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userNameTb.Name = "userNameTb";
            this.userNameTb.PasswordChar = '\0';
            this.userNameTb.PlaceholderText = "Username";
            this.userNameTb.SelectedText = "";
            this.userNameTb.Size = new System.Drawing.Size(229, 48);
            this.userNameTb.TabIndex = 1;
            // 
            // passwordTb
            // 
            this.passwordTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTb.DefaultText = "";
            this.passwordTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passwordTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passwordTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passwordTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordTb.Location = new System.Drawing.Point(454, 235);
            this.passwordTb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.PasswordChar = '●';
            this.passwordTb.PlaceholderText = "Password";
            this.passwordTb.SelectedText = "";
            this.passwordTb.Size = new System.Drawing.Size(229, 48);
            this.passwordTb.TabIndex = 2;
            this.passwordTb.UseSystemPasswordChar = true;
            this.passwordTb.TextChanged += new System.EventHandler(this.passwordTb_TextChanged);
            // 
            // connexionBtn
            // 
            this.connexionBtn.BackColor = System.Drawing.Color.Transparent;
            this.connexionBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.connexionBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.connexionBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.connexionBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.connexionBtn.FillColor = System.Drawing.Color.MediumAquamarine;
            this.connexionBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.connexionBtn.ForeColor = System.Drawing.Color.White;
            this.connexionBtn.Location = new System.Drawing.Point(479, 335);
            this.connexionBtn.Name = "connexionBtn";
            this.connexionBtn.Size = new System.Drawing.Size(180, 45);
            this.connexionBtn.TabIndex = 3;
            this.connexionBtn.Text = "&Connexion";
            this.connexionBtn.Click += new System.EventHandler(this.connexionBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(473, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "CONNEXION";
            // 
            // closeLbl
            // 
            this.closeLbl.BackColor = System.Drawing.Color.Red;
            this.closeLbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeLbl.Location = new System.Drawing.Point(696, 12);
            this.closeLbl.Name = "closeLbl";
            this.closeLbl.Size = new System.Drawing.Size(33, 30);
            this.closeLbl.TabIndex = 5;
            this.closeLbl.Text = "X";
            this.closeLbl.UseVisualStyleBackColor = false;
            this.closeLbl.Click += new System.EventHandler(this.closeLbl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(553, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Admin";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 443);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.closeLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connexionBtn);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.userNameTb);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Connexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox userNameTb;
        private Guna.UI2.WinForms.Guna2TextBox passwordTb;
        private Guna.UI2.WinForms.Guna2Button connexionBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeLbl;
        private System.Windows.Forms.Label label2;
    }
}