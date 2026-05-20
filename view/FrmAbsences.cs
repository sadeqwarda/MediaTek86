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
        }
        private void RemplirListePersonnel()
        {
            lesPersonnels = controller.GetLesPersonnels();

            cmbPersonnel.DataSource = null;
            cmbPersonnel.DataSource = lesPersonnels;
            cmbPersonnel.DisplayMember = "NomPrenom";
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
    }
}
