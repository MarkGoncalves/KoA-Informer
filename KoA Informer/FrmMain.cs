using System;
using System.Windows.Forms;
using KoA_Informer.Forms;

namespace KoA_Informer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FrmMaterial { MdiParent = this };
            form.Show();
        }

        private void buildingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FrmBuilding { MdiParent = this };
            form.Show();
        }
    }
}