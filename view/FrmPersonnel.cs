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
        private void dgvPersonnel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Personnel personnel = lesPersonnels[e.RowIndex];

                txtNom.Text = personnel.Nom;
                txtPrenom.Text = personnel.Prenom;
                txtTel.Text = personnel.Tel;
                txtMail.Text = personnel.Mail;

                cbxService.SelectedValue = personnel.Service.Idservice;
            }

        }
    }
}