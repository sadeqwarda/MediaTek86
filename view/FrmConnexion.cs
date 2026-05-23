using System;
using System.Windows.Forms;
using MediaTek86.controller;

namespace MediaTek86.view
{
    /// <summary>
    /// Fenêtre de connexionn
    /// de l'application MediaTeck86
    /// finaliser le 23/05/2026
    /// Warda SADEQ
    /// </summary>
    public partial class FrmConnexion : Form
    {
        /// <summary>
        /// Contrôleur de gestion de la connexion
        /// </summary>
        private readonly FrmConnexionController controller;

        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        public FrmConnexion()
        {
            InitializeComponent();

            // Initialisation du contrôleur
            controller = new FrmConnexionController();
        }

        /// <summary>
        /// focus sur le champ login à l'ouverture
        /// </summary>
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

        /// <summary>
        /// Vérifie l'authentification utilisateur
        /// </summary>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // Récupération des informations saisies
            string login = txtLogin.Text;
            string pwd = txtPwd.Text;

            // test pour la vérification de l'utilisateur
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

        /// <summary>
        /// Annulation de la connexion
        /// </summary>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Afficher/masquer le mot de passe
        /// </summary>
        private void btnAfficherPwd_Click(object sender, EventArgs e)
        {
            txtPwd.UseSystemPasswordChar = !txtPwd.UseSystemPasswordChar;
        }
    }
}