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
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
        {
            InitializeComponent();
        }

        private void Admin_dashboard_Load(object sender, EventArgs e)
        {
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height; 

            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void btn_reserve_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {

        }

        private void pnl_profile_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
