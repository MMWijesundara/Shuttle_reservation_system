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
    public partial class Home : UserControl
    {
        internal FormBorderStyle FormBorderStyle;
        public Home()
        {
            InitializeComponent();
        }

        public bool TopLevel {  get; internal set; } 
    }
}
