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

            timer1 = new Timer();
            timer1.Interval = 1000; // Update every second (1000 milliseconds)
            timer1.Tick += Timer_Tick; // Attach event handler
            timer1.Start(); // Start the timer


            // Set initial value for the label
            UpdateLabel();
        }

        public Point mouseLocation;

        private void Admin_dashboard_Load(object sender, EventArgs e)
        {
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;

            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);

            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left))
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void btn_shuttle_Click(object sender, EventArgs e)
        {
            Shuttle shuttle = new Shuttle();
            shuttle.formBorderStyle = FormBorderStyle.None;
            shuttle.Dock = DockStyle.Fill;
            shuttle.TopLevel = false;
            pnl_fill.Controls.Clear();
            pnl_fill.Controls.Add(shuttle);
            shuttle.Show();
        }

        private void btn_driver_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver();
            driver.formBorderStyle = FormBorderStyle.None;
            driver.Dock = DockStyle.Fill;
            driver.TopLevel = false;
            pnl_fill.Controls.Clear();
            pnl_fill.Controls.Add(driver);
            driver.Show();
        }

        private void btn_route_Click(object sender, EventArgs e)
        {
            Route route = new Route();
            route.formBorderStyle = FormBorderStyle.None;
            route.Dock = DockStyle.Fill;
            route.TopLevel = false;
            pnl_fill.Controls.Clear();
            pnl_fill.Controls.Add(route);
            route.Show();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the label on every tick
            UpdateLabel();
        }

        private void UpdateLabel()
        {

            date.Text = DateTime.Now.ToString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
