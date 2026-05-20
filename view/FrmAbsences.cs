using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTek86.controller;
using MediaTek86.model;

namespace MediaTek86.view
{
    public partial class FrmAbsences : Form
    {
        private readonly FrmAbsencesController controller;
        private List<Personnel> lesPersonnels;
        private List<Absence> lesAbsences;
        private Absence absenceSelectionnee;
        public FrmAbsences()
        {
            InitializeComponent();
            controller = new FrmAbsencesController();

            RemplirListePersonnel();
            RemplirListePersonnel();
            RemplirListeAbsences();
            RemplirListeMotifs();
        }
        private void RemplirListePersonnel()
        {
            lesPersonnels = controller.GetLesPersonnels();

            cmbPersonnel.DataSource = null;
            cmbPersonnel.DataSource = lesPersonnels;
            cmbPersonnel.DisplayMember = "NomPrenom";
        }
        private void RemplirListeAbsences()
        {
            Personnel personnel = (Personnel)cmbPersonnel.SelectedItem;

            if (personnel == null)
            {
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
        private void RemplirListeMotifs()
        {
            cmbMotif.DataSource = controller.GetLesMotifs();

            cmbMotif.DisplayMember = "Libelle";
            cmbMotif.ValueMember = "Idmotif";
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbMotif_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateDebut_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDateFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmbPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                RemplirListeAbsences();
            
        }

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

            controller.AjoutAbsence(absence);

            RemplirListeAbsences();

            MessageBox.Show(
                "Absence ajoutée.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (absenceSelectionnee == null)
            {
                MessageBox.Show(
                    "Sélectionner une absence.",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

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

            DialogResult result = MessageBox.Show(
                "Voulez-vous modifier cette absence ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                DateTime ancienneDateDebut = absenceSelectionnee.Datedebut;

                absenceSelectionnee.Datedebut = dtpDateDebut.Value.Date;
                absenceSelectionnee.Datefin = dtpDateFin.Value.Date;
                absenceSelectionnee.Motif = (Motif)cmbMotif.SelectedItem;

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

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (absenceSelectionnee == null)
            {
                MessageBox.Show(
                    "Sélectionner une absence.",
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
    }
}
