using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //open home
            FormHome newMDIChild = new FormHome();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();

        }

        private void halterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBus newMDIChild = new FormBus();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void ruteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHalte newMDIChild = new FormHalte();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void jadwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FormRute newMDIChild = new FormRute();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void tiketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
