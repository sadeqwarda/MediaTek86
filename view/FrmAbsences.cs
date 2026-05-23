using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controller;
using MediaTek86.model;

namespace MediaTek86.view
{
    /// <summary>
    /// Fenêtre de gestion des absences
    /// de l'application MediaTeck86
    /// finaliser le 23/05/2026
    /// Warda SADEQ
    /// </summary>
    public partial class FrmAbsences : Form
    {
        /// <summary>
        /// Contrôleur de gestion des absences
        /// </summary>
        private readonly FrmAbsencesController controller;

        /// <summary>
        /// Liste des personnels
        /// </summary>
        private List<Personnel> lesPersonnels;

        /// <summary>
        /// Liste des absences
        /// </summary>
        private List<Absence> lesAbsences;

        /// <summary>
        /// Absence actuellement sélectionnée
        /// </summary>
        private Absence absenceSelectionnee;

        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        public FrmAbsences()
        {
            InitializeComponent();

            controller = new FrmAbsencesController();

            RemplirListePersonnel();
            RemplirListeAbsences();
            RemplirListeMotifs();
        }

        /// <summary>
        /// Charge la liste des personnels dans la ComboBox
        /// </summary>
        private void RemplirListePersonnel()
        {
            lesPersonnels = controller.GetLesPersonnels();

            cmbPersonnel.DataSource = null;
            cmbPersonnel.DataSource = lesPersonnels;

            // Affichage nom + prénom
            cmbPersonnel.DisplayMember = "NomPrenom";

            // cmb vide au démarge de la fenêtre
            cmbPersonnel.SelectedIndex = -1;
        }

        /// <summary>
        /// Charge les absences du personnel sélectionné
        /// </summary>
        private void RemplirListeAbsences()
        {
            Personnel personnel = (Personnel)cmbPersonnel.SelectedItem;

            if (personnel == null)
            {
                dgvAbsences.DataSource = null;
                return;
            }

            // Récupération des absences
            lesAbsences = controller.GetLesAbsences(personnel);

            dgvAbsences.DataSource = null;
            dgvAbsences.DataSource = lesAbsences;

            // Renommage des colonnes
            dgvAbsences.Columns["Datedebut"].HeaderText = "Date début";
            dgvAbsences.Columns["Datefin"].HeaderText = "Date fin";
            dgvAbsences.Columns["Motif"].HeaderText = "Motif";

            // Masquage des colonnes inutiles
            dgvAbsences.Columns["Personnel"].Visible = false;

            // Paramétrage du DataGridView (pas de modification direct sur dgvabsences)
            dgvAbsences.ReadOnly = true;
            dgvAbsences.AllowUserToAddRows = false;
            dgvAbsences.AllowUserToDeleteRows = false;
            dgvAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAbsences.MultiSelect = false;
        }

        /// <summary>
        /// Charge les motifs d'absence
        /// </summary>
        private void RemplirListeMotifs()
        {
            cmbMotif.DataSource = controller.GetLesMotifs();

            // Affichage du libellé
            cmbMotif.DisplayMember = "Libelle";

            // Valeur associée
            cmbMotif.ValueMember = "Idmotif";
        }

        /// <summary>
        ///màj/actualisation des absences lors du changement de personnel
        /// </summary>
        private void cmbPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemplirListeAbsences();
        }

        /// <summary>
        /// Sélection/modification absence
        /// </summary>
        private void dgvAbsences_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                absenceSelectionnee = lesAbsences[e.RowIndex];

                dtpDateDebut.Value = absenceSelectionnee.Datedebut;
                dtpDateFin.Value = absenceSelectionnee.Datefin;

                cmbMotif.SelectedValue = absenceSelectionnee.Motif.Idmotif;
            }
        }

        /// <summary>
        /// Ajout d'une nouvelle absence
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // condition date début<date fin
            if (dtpDateDebut.Value.Date > dtpDateFin.Value.Date)
            {
                MessageBox.Show(
                    "La date de début doit être antérieure ou égale à la date de fin.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Personnel personnel = (Personnel)cmbPersonnel.SelectedItem;
            Motif motif = (Motif)cmbMotif.SelectedItem;

            Absence absence = new Absence()
            {
                Personnel = personnel,
                Datedebut = dtpDateDebut.Value.Date,
                Datefin = dtpDateFin.Value.Date,
                Motif = motif
            };

            // Ajout dans la base
            controller.AjoutAbsence(absence);

            // màj tab
            RemplirListeAbsences();

            MessageBox.Show(
                "Absence ajoutée.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// <summary>
        /// Modification d'une absence
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            // Vérification sélection
            if (absenceSelectionnee == null)
            {
                MessageBox.Show(
                    "Une absence doit être selectionner.",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // condition date début< date fin
            if (dtpDateDebut.Value.Date > dtpDateFin.Value.Date)
            {
                MessageBox.Show(
                    "La date de début doit être antérieure ou égale à la date de fin.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Confirmation avant enregistrement
            DialogResult result = MessageBox.Show(
                "Voulez-vous modifier cette absence ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Sauvegarde ancienne date
                DateTime ancienneDateDebut = absenceSelectionnee.Datedebut;

                // màj des infos
                absenceSelectionnee.Datedebut = dtpDateDebut.Value.Date;
                absenceSelectionnee.Datefin = dtpDateFin.Value.Date;
                absenceSelectionnee.Motif = (Motif)cmbMotif.SelectedItem;

                // Mise à jour base de données
                controller.ModifAbsence(absenceSelectionnee, ancienneDateDebut);

                
                RemplirListeAbsences();

                MessageBox.Show(
                    "Absence modifiée.",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        /// <summary>
        /// Suppression d'une absence
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // Vérification sélection
            if (absenceSelectionnee == null)
            {
                MessageBox.Show(
                    "Une absence doit être selectionner..",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Confirmation utilisateur
            DialogResult result = MessageBox.Show(
                "Voulez-vous supprimer cette absence ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Suppression en base
                controller.SupprAbsence(absenceSelectionnee);

                // Actualisation affichage
                RemplirListeAbsences();

                // Réinitialisation sélection
                absenceSelectionnee = null;

                MessageBox.Show(
                    "Absence supprimée.",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}