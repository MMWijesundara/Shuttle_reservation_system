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
    public partial class Shuttle : UserControl
    {
        public Shuttle()
        {
            InitializeComponent();
        }

        internal FormBorderStyle formBorderStyle;

        public bool TopLevel { get; internal set; }

    }
}
