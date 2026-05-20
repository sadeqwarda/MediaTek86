namespace MediaTek86.view
{
    partial class FrmPersonnel
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
            this.lblTitre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPersonnel = new System.Windows.Forms.DataGridView();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.cbxService = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitre.Location = new System.Drawing.Point(267, 9);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(241, 26);
            this.lblTitre.TabIndex = 8;
            this.lblTitre.Text = "Gestion du Personnel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(38, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Liste du Personnel";
            // 
            // dgvPersonnel
            // 
            this.dgvPersonnel.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnel.Location = new System.Drawing.Point(109, 91);
            this.dgvPersonnel.Name = "dgvPersonnel";
            this.dgvPersonnel.Size = new System.Drawing.Size(662, 219);
            this.dgvPersonnel.TabIndex = 10;
            this.dgvPersonnel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonnel_CellClick);
            // 
            // txtPrenom
            // 
            this.txtPrenom.BackColor = System.Drawing.Color.SkyBlue;
            this.txtPrenom.Location = new System.Drawing.Point(272, 397);
            this.txtPrenom.Multiline = true;
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(336, 40);
            this.txtPrenom.TabIndex = 11;
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.SkyBlue;
            this.txtNom.Location = new System.Drawing.Point(272, 345);
            this.txtNom.Multiline = true;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(336, 40);
            this.txtNom.TabIndex = 12;
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.SkyBlue;
            this.txtTel.Location = new System.Drawing.Point(272, 451);
            this.txtTel.Multiline = true;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(336, 40);
            this.txtTel.TabIndex = 13;
            // 
            // txtMail
            // 
            this.txtMail.BackColor = System.Drawing.Color.SkyBlue;
            this.txtMail.Location = new System.Drawing.Point(272, 503);
            this.txtMail.Multiline = true;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(336, 40);
            this.txtMail.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(42, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nom        ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(38, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Prénom  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(38, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 26);
            this.label4.TabIndex = 17;
            this.label4.Text = "Téléphone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(38, 517);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 26);
            this.label5.TabIndex = 18;
            this.label5.Text = "Mail     ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(38, 561);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 26);
            this.label6.TabIndex = 19;
            this.label6.Text = "Service  ";
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAjouter.Location = new System.Drawing.Point(329, 599);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(118, 51);
            this.btnAjouter.TabIndex = 21;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModifier.Location = new System.Drawing.Point(453, 599);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(118, 51);
            this.btnModifier.TabIndex = 22;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Red;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSupprimer.Location = new System.Drawing.Point(577, 599);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(118, 51);
            this.btnSupprimer.TabIndex = 23;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.DarkOrange;
            this.btnRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRetour.Location = new System.Drawing.Point(701, 599);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(118, 51);
            this.btnRetour.TabIndex = 24;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            // 
            // cbxService
            // 
            this.cbxService.FormattingEnabled = true;
            this.cbxService.Location = new System.Drawing.Point(272, 561);
            this.cbxService.Name = "cbxService";
            this.cbxService.Size = new System.Drawing.Size(321, 21);
            this.cbxService.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(106, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(378, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "Sélectionnez un personnel pour modifier ses informations";
            // 
            // FrmPersonnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(847, 679);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxService);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.dgvPersonnel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmPersonnel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPersonnel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPersonnel;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.ComboBox cbxService;
        private System.Windows.Forms.Label label7;
    }
}