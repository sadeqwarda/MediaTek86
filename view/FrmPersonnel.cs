using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controller;
using MediaTek86.model;

namespace MediaTek86.view
{
    public partial class FrmPersonnel : Form
    {
        private readonly FrmPersonnelController controller;
        private List<Personnel> lesPersonnels;
        private Personnel personnelSelectionne;

        public FrmPersonnel()
        {
            InitializeComponent();
            controller = new FrmPersonnelController();

            RemplirListePersonnel();
            RemplirListeService();
        }

        private void RemplirListePersonnel()
        {
            lesPersonnels = controller.GetLesPersonnels();

            dgvPersonnel.DataSource = null;
            dgvPersonnel.DataSource = lesPersonnels;

            dgvPersonnel.Columns["Idpersonnel"].Visible = false;

            dgvPersonnel.ReadOnly = true;

            dgvPersonnel.AllowUserToAddRows = false;
            dgvPersonnel.AllowUserToDeleteRows = false;

            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPersonnel.MultiSelect = false;
            dgvPersonnel.Columns["NomPrenom"].Visible = false;
        }
        private void RemplirListeService()
        {
            cbxService.DataSource = controller.GetLesServices();
            cbxService.DisplayMember = "Nom";
            cbxService.ValueMember = "Idservice";

        }
        private void dgvPersonnel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                personnelSelectionne = lesPersonnels[e.RowIndex];

                txtNom.Text = personnelSelectionne.Nom;
                txtPrenom.Text = personnelSelectionne.Prenom;
                txtTel.Text = personnelSelectionne.Tel;
                txtMail.Text = personnelSelectionne.Mail;
                cbxService.SelectedValue = personnelSelectionne.Service.Idservice;
            }

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                string.IsNullOrWhiteSpace(txtTel.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text) ||
                cbxService.SelectedItem == null)
            {
                MessageBox.Show(
                    "Tous les champs doivent être remplis.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Personnel personnelExistant = RechercherPersonnelSaisi();

            if (personnelExistant != null)
            {
                MessageBox.Show(
                    "Personnel déjà existant.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                SelectionnerPersonnel(personnelExistant);
                return;
            }

            Service service = (Service)cbxService.SelectedItem;

            Personnel personnel = new Personnel()
            {
                Nom = txtNom.Text.Trim(),
                Prenom = txtPrenom.Text.Trim(),
                Tel = txtTel.Text.Trim(),
                Mail = txtMail.Text.Trim(),
                Service = service
            };

            controller.AjoutPersonnel(personnel);

            RemplirListePersonnel();
            ViderChamps();

            MessageBox.Show(
                "Personnel ajouté.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void ViderChamps()
        {
            personnelSelectionne = null;

            txtNom.Clear();
            txtPrenom.Clear();
            txtTel.Clear();
            txtMail.Clear();

            if (cbxService.Items.Count > 0)
            {
                cbxService.SelectedIndex = 0;
            }
        }
        private Personnel RechercherPersonnelSaisi()
        {
            foreach (Personnel personnel in lesPersonnels)
            {
                if (personnel.Nom.Equals(txtNom.Text.Trim(), StringComparison.OrdinalIgnoreCase)
                    && personnel.Prenom.Equals(txtPrenom.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return personnel;
                }
            }

            return null;
        }

        private void SelectionnerPersonnel(Personnel personnel)
        {
            for (int i = 0; i < lesPersonnels.Count; i++)
            {
                if (lesPersonnels[i].Idpersonnel == personnel.Idpersonnel)
                {
                    dgvPersonnel.ClearSelection();
                    dgvPersonnel.Rows[i].Selected = true;
                    dgvPersonnel.CurrentCell = dgvPersonnel.Rows[i].Cells[0];

                    personnelSelectionne = personnel;

                    txtNom.Text = personnel.Nom;
                    txtPrenom.Text = personnel.Prenom;
                    txtTel.Text = personnel.Tel;
                    txtMail.Text = personnel.Mail;
                    cbxService.SelectedValue = personnel.Service.Idservice;

                    return;
                }
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string nomRecherche = txtNom.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomRecherche))
            {
                MessageBox.Show(
                    "Saisir un nom.",
                    "Recherche",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtNom.Focus();
                return;
            }

            foreach (Personnel personnel in lesPersonnels)
            {
                if (personnel.Nom.Equals(nomRecherche, StringComparison.OrdinalIgnoreCase))
                {
                    SelectionnerPersonnel(personnel);

                    MessageBox.Show(
                        "Personnel trouvé.",
                        "Recherche",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }
            }

            MessageBox.Show(
                "Personnel introuvable.",
                "Recherche",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtNom.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViderChamps();
            dgvPersonnel.ClearSelection();
            txtNom.Focus();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (personnelSelectionne == null)
            {
                MessageBox.Show(
                    "Sélectionner un personnel.",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                string.IsNullOrWhiteSpace(txtTel.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text) ||
                cbxService.SelectedItem == null)
            {
                MessageBox.Show(
                    "Tous les champs doivent être remplis.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Service service = (Service)cbxService.SelectedItem;

            personnelSelectionne.Nom = txtNom.Text.Trim();
            personnelSelectionne.Prenom = txtPrenom.Text.Trim();
            personnelSelectionne.Tel = txtTel.Text.Trim();
            personnelSelectionne.Mail = txtMail.Text.Trim();
            personnelSelectionne.Service = service;

            controller.ModifPersonnel(personnelSelectionne);

            RemplirListePersonnel();

            MessageBox.Show(
                "Personnel modifié.",
                "Modification",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (personnelSelectionne == null)
            {
                MessageBox.Show(
                    "Sélectionner un personnel.",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                "Voulez-vous supprimer ce personnel ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                controller.SupprPersonnel(personnelSelectionne);

                RemplirListePersonnel();

                ViderChamps();

                MessageBox.Show(
                    "Personnel supprimé.",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
    
}