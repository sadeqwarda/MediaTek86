using MediaTek86.model;
using MediaTek86.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTek86.view
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonnel_Click(object sender, EventArgs e)
        {
            FrmPersonnel frm = new FrmPersonnel();
            frm.ShowDialog();
        }

        private void btnAbsences_Click(object sender, EventArgs e)
        {
            FrmAbsences frm = new FrmAbsences();
            frm.ShowDialog();
        }
    }
}
