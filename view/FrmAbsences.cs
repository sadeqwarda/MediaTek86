using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controller;
using MediaTek86.model;

namespace MediaTek86.view
{
    /// <summary>
    /// Fenêtre de gestion des absences
    /// de l'application MediaTek86
    /// finalisée le 23/05/2026
    /// Warda SADEQ
    /// </summary>
    public partial class FrmAbsences : Form
    {
        private readonly FrmAbsencesController controller;
        private List<Personnel> lesPersonnels;
        private List<Absence> lesAbsences;
        private Absence absenceSelectionnee;

        // Sauvegarde de l'ancienne date début
        private DateTime ancienneDateDebutSelectionnee;

        public FrmAbsences()
        {
            InitializeComponent();

            controller = new FrmAbsencesController();

            RemplirListePersonnel();
            RemplirListeMotifs();
            RemplirListeAbsences();
        }

        /// <summary>
        /// Charge la liste des personnels dans la ComboBox
        /// </summary>
        private void RemplirListePersonnel()
        {
            lesPersonnels = controller.GetLesPersonnels();

            cmbPersonnel.DataSource = null;
            cmbPersonnel.DataSource = lesPersonnels;
            cmbPersonnel.DisplayMember = "NomPrenom";

            // ComboBox vide au démarrage
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
                lesAbsences = new List<Absence>();
                return;
            }

            lesAbsences = controller.GetLesAbsences(personnel);

            dgvAbsences.DataSource = null;
            dgvAbsences.DataSource = lesAbsences;

            dgvAbsences.Columns["Datedebut"].HeaderText = "Date début";
            dgvAbsences.Columns["Datefin"].HeaderText = "Date fin";
            dgvAbsences.Columns["Motif"].HeaderText = "Motif";

            dgvAbsences.Columns["Personnel"].Visible = false;

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
            cmbMotif.DisplayMember = "Libelle";
            cmbMotif.ValueMember = "Idmotif";
        }

        /// <summary>
        /// Vérifie si une absence chevauche une autre absence
        /// </summary>
        private bool ChevauchementAjout(DateTime dateDebut, DateTime dateFin)
        {
            foreach (Absence uneAbsence in lesAbsences)
            {
                if (dateDebut <= uneAbsence.Datefin.Date &&
                    dateFin >= uneAbsence.Datedebut.Date)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Vérifie le chevauchement lors d'une modification
        /// </summary>
       private bool ChevauchementModification(DateTime dateDebut, DateTime dateFin)
        {
            foreach (Absence uneAbsence in lesAbsences)
            {
                // Ignore uniquement l'absence sélectionnée
                if (uneAbsence == absenceSelectionnee)
                {
                    continue;
                }

                // Vérification chevauchement
                if (dateDebut <= uneAbsence.Datefin.Date &&
                    dateFin >= uneAbsence.Datedebut.Date)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Actualise les absences lors du changement de personnel
        /// </summary>
        private void cmbPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            absenceSelectionnee = null;
            RemplirListeAbsences();
        }

        /// <summary>
        /// Sélection d'une absence dans le tableau
        /// </summary>
        private void dgvAbsences_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && lesAbsences != null)
            {
                absenceSelectionnee = lesAbsences[e.RowIndex];
                ancienneDateDebutSelectionnee = absenceSelectionnee.Datedebut;

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
            if (cmbPersonnel.SelectedItem == null)
            {
                MessageBox.Show(
                    "Sélectionner un personnel.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DateTime dateDebut = dtpDateDebut.Value.Date;
            DateTime dateFin = dtpDateFin.Value.Date;

            foreach (Absence uneAbsence in lesAbsences)
            {
                if (uneAbsence.Datedebut.Date == dateDebut)
                {
                    MessageBox.Show(
                        "Une absence existe déjà à cette date de début.",
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }
            if (dateDebut > dateFin)
            {
                MessageBox.Show(
                    "La date de début doit être antérieure ou égale à la date de fin.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (ChevauchementAjout(dateDebut, dateFin))
            {
                MessageBox.Show(
                    "Cette absence chevauche une absence existante.",
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
                Datedebut = dateDebut,
                Datefin = dateFin,
                Motif = motif
            };

            controller.AjoutAbsence(absence);

            RemplirListeAbsences();
            absenceSelectionnee = null;

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
            if (absenceSelectionnee == null)
            {
                MessageBox.Show(
                    "Une absence doit être sélectionnée.",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DateTime dateDebut = dtpDateDebut.Value.Date;
            DateTime dateFin = dtpDateFin.Value.Date;

            if (dateDebut > dateFin)
            {
                MessageBox.Show(
                    "La date de début doit être antérieure ou égale à la date de fin.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (ChevauchementModification(dateDebut, dateFin))
            {
                MessageBox.Show(
                    "Cette absence chevauche une absence existante.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "Voulez-vous modifier cette absence ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                DateTime ancienneDateDebut = ancienneDateDebutSelectionnee;

                absenceSelectionnee.Datedebut = dateDebut;
                absenceSelectionnee.Datefin = dateFin;
                absenceSelectionnee.Motif = (Motif)cmbMotif.SelectedItem;

                controller.ModifAbsence(absenceSelectionnee, ancienneDateDebut);

                RemplirListeAbsences();
                absenceSelectionnee = null;

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
            if (absenceSelectionnee == null)
            {
                MessageBox.Show(
                    "Une absence doit être sélectionnée.",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "Voulez-vous supprimer cette absence ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                controller.SupprAbsence(absenceSelectionnee);

                RemplirListeAbsences();
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