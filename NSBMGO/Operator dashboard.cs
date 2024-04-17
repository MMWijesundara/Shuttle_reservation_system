using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Guna.UI2.WinForms;


namespace NSBMGO
{
    public partial class Operator_dashboard : Form
    {
        
        public Operator_dashboard()
        {
            InitializeComponent();

            
        }
        private void Operator_dashboard_Load(object sender, EventArgs e)
        {
            
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
            
            
        }

        private void btnlogout_click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to switch user?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
                LogIn logIn = new LogIn();
                logIn.Show();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
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

            Reserve reserve = new Reserve();
            reserve.TopLevel = false;
            reserve.FormBorderStyle = FormBorderStyle.None;
            reserve.Dock = DockStyle.Fill;

            pnl_fill.Controls.Clear();
            pnl_fill.Controls.Add(reserve);

            reserve.Show();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            Cancel cancel = new Cancel();
            cancel.TopLevel = false;
            cancel.FormBorderStyle = FormBorderStyle.None;
            cancel.Dock = DockStyle.Fill;

            pnl_fill.Controls.Clear();
            pnl_fill.Controls.Add(cancel);

            cancel.Show();
        }

        private void pnl_fill_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
