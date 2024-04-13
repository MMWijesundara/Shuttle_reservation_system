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
    public partial class reserve_card : UserControl
    {
        public reserve_card()
        {
            InitializeComponent();
        }

        

        private void reserve_card_Click(object sender, EventArgs e)
        {
            MessageBox.Show("clicked");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            reserve__2_ reservepnl = new reserve__2_();
            reservepnl.Show();
        }
    }
}
