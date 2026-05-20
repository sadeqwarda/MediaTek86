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
        }
        private void RemplirListeService()
        {
            cbxService.DataSource = controller.GetLesServices();
            cbxService.DisplayMember = "Nom";
            cbxService.ValueMember = "Idservice";

        }
    }
}