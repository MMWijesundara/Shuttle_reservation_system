using System;
using System.Drawing;
using System.Windows.Forms;

namespace NSBMGO
{
    public partial class reserve_card : UserControl
    {
        public reserve_card()
        {
            InitializeComponent();
        }

        private void btn_Reserve(object sender, EventArgs e)
        {
            reserve__2_ reservepnl = new reserve__2_();
            reservepnl.Show();
        }

        private void guna2Panel2_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Azure;

        }

        private void guna2Panel2_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
