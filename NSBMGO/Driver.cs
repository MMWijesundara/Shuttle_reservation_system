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
    public partial class Driver : UserControl
    {
        public FormBorderStyle FormBorderStyle;
        public Driver()
        {
            InitializeComponent();
        }

        public bool TopLevel { get; internal set; }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
