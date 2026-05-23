using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controller;
using MediaTek86.model;

namespace MediaTek86.view
{
    /// <summary>
    /// Fenêtre de gestion du personnel
    /// de l'application MediaTeck86
    /// finaliser le 23/05/2026
    /// Warda SADEQ
    /// </summary>
    public partial class FrmPersonnel : Form
    {
        /// <summary>
        /// Contrôleur de gestion du personnel
        /// </summary>
        private readonly FrmPersonnelController controller;

        /// <summary>
        /// Liste des personnels
        /// </summary>
        private List<Personnel> lesPersonnels;

        /// <summary>
        /// Personnel actuellement sélectionné
        /// </summary>
        private Personnel personnelSelectionne;

        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        public FrmPersonnel()
        {
            InitializeComponent();

            controller = new FrmPersonnelController();

            RemplirListePersonnel();
            RemplirListeService();
        }

        /// <summary>
        /// remplir la liste du personnel dans le dgv
        /// </summary>
        private void RemplirListePersonnel()
        {
            
            lesPersonnels = controller.GetLesPersonnels();

            dgvPersonnel.DataSource = null;
            dgvPersonnel.DataSource = lesPersonnels;

            // Masquage des colonnes inutiles (idpersonnel)
            dgvPersonnel.Columns["Idpersonnel"].Visible = false;
            dgvPersonnel.Columns["NomPrenom"].Visible = false;

            // bloquer la modification direct de dgv
            dgvPersonnel.ReadOnly = true;
            dgvPersonnel.AllowUserToAddRows = false;
            dgvPersonnel.AllowUserToDeleteRows = false;
            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonnel.MultiSelect = false;
        }

        /// <summary>
        /// Charge les services dans la ComboBox
        /// </summary>
        private void RemplirListeService()
        {
            cbxService.DataSource = controller.GetLesServices();

            cbxService.DisplayMember = "Nom";

            cbxService.ValueMember = "Idservice";
        }

        /// <summary>
        /// Sélection d'un personnel dans le tableau
        /// </summary>
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

        /// <summary>
        /// Ajoute d' nouveau personnel
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Vérification avant ajout champ obligatoire
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

            // Vérification doublon (ne pas ajouter un personnel qui existe déja)
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

            // Récupération du service
            Service service = (Service)cbxService.SelectedItem;

            // Création du personnel
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

            // Réinitialisation des champs (remettre à vide les champs)
            ViderChamps();

            MessageBox.Show(
                "Personnel ajouté.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// <summary>
        /// Vide les champs de saisie
        /// </summary>
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

        /// <summary>
        /// Recherche un personnel déjà existant
        /// </summary>
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

        /// <summary>
        /// boucle pour sélectionner un personnel dans le tableau et afficher ses informations
        /// </summary>
        private void SelectionnerPersonnel(Personnel personnel)
        {
            for (int i = 0; i < lesPersonnels.Count; i++)
            {
                if (lesPersonnels[i].Idpersonnel == personnel.Idpersonnel)
                {
                    dgvPersonnel.ClearSelection();

                    dgvPersonnel.Rows[i].Selected = true;

                    dgvPersonnel.CurrentCell = dgvPersonnel.Rows[i].Cells["Nom"];

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

        /// <summary>
        /// Recherche un personnel par son nom
        /// </summary>
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string nomRecherche = txtNom.Text.Trim();

            // Vérification saisie
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

            // Recherche du personnel
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
                "Personnel non trouvé.",
                "Recherche",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtNom.Focus();
        }

        /// <summary>
        /// Réinitialise les champs
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ViderChamps();

            dgvPersonnel.ClearSelection();

            txtNom.Focus();
        }

        /// <summary>
        /// Modifie un personnel
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            // condition de vérification des champs
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

            // Vérification des champs
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

            // Récupération du service
            Service service = (Service)cbxService.SelectedItem;

            // màj des informations
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

        /// <summary>
        /// Supprimer un personnel
        /// </summary>
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

            // Confirmation utilisateur
            DialogResult result = MessageBox.Show(
                "Voulez-vous supprimer ce personnel ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Suppression en base
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