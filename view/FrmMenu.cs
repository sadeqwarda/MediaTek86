using System;
using System.Windows.Forms;

namespace MediaTek86.view
{
    /// <summary>
    /// Fenêtre principale de l'application
    /// de l'application MediaTeck86
    /// finaliser le 23/05/2026
    /// Warda SADEQ
    /// </summary>
    public partial class FrmMenu : Form
    {
        /// <summary>
        /// Constructeur de la fenêtre menu
        /// </summary>
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ouvre la fenêtre de gestion du personnel
        /// </summary>
        private void btnPersonnel_Click(object sender, EventArgs e)
        {
            FrmPersonnel frm = new FrmPersonnel();
            frm.ShowDialog();
        }

        /// <summary>
        /// Ouvre la fenêtre de gestion des absences
        /// </summary>
        private void btnAbsences_Click(object sender, EventArgs e)
        {
            FrmAbsences frm = new FrmAbsences();
            frm.ShowDialog();
        }
    }
}