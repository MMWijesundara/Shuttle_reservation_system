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
    public partial class Operator_dashboard : Form
    {
        public Operator_dashboard()
        {
            InitializeComponent();

            
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Operator_dashboard_Load(object sender, EventArgs e)
        {
            
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
        }

        

        private void btnlogout_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.TopLevel = false;
            home.FormBorderStyle = FormBorderStyle.None;
            home.Dock = DockStyle.Fill;

            pnl_fill.Controls.Clear();
            pnl_fill.Controls.Add(home);

            home.Show();
        }

        private void btn_reserve_Click(object sender, EventArgs e)
        {

        }

        //private void btnhome_click(object sender, EventArgs e)
        //{

        //}

        //private void btnreserve_click(object sender, EventArgs e)
        //{

        //}

        //private void btncancel_click(object sender, EventArgs e)
        //{

        //}
    }
}
