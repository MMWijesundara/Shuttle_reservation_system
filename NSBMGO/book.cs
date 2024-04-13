using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSBMGO
{
    public partial class reserve__2_ : Form
    {
        public reserve__2_()
        {
            InitializeComponent();
        }

        private void reserve__2__Load(object sender, EventArgs e)
        {

        }

        private void guna2Button38_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Booking successfull.","Alert",MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Close();
                
            }
        }
    }
}
