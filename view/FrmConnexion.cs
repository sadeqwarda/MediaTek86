using System;
using System.Windows.Forms;
using MediaTek86.controller;

namespace MediaTek86.view
{
    public partial class FrmConnexion : Form
    {
        private readonly FrmConnexionController controller;

        public FrmConnexion()
        {
            InitializeComponent();
            controller = new FrmConnexionController();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtLogin.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {

            string login = txtLogin.Text;
            string pwd = txtPwd.Text;

            if (controller.ControleAuthentification(login, pwd))
            {
                FrmMenu frm = new FrmMenu();
                frm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(
                    "Login ou mot de passe incorrect",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtPwd.Clear();
                txtPwd.Focus();
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAfficherPwd_Click(object sender, EventArgs e)
        {
            txtPwd.UseSystemPasswordChar = !txtPwd.UseSystemPasswordChar;
        }
    
    }

}