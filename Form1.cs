using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlreport
{
    public partial class Form1 : Form
    {
        frm_castegoria frm_ca;
        public Form1()
        {
            InitializeComponent();
        }

        void Alta_frm_ca(object sender,EventArgs e)
        {
            frm_ca = null;

        }

        private void frmcastegoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(frm_ca == null)
            {
                frm_ca = new frm_castegoria();
                frm_ca.FormClosed += new FormClosedEventHandler(Alta_frm_ca);
                frm_ca.Show();

            }
            else
            {
                frm_ca.Activate();

            }
        }
    }
}
