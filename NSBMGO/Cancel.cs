﻿using System;
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
    public partial class Cancel : UserControl
    {
        public Cancel()
        {
            InitializeComponent();
        }

        public FormBorderStyle FormBorderStyle;
        public bool TopLevel { get; internal set; }
    }
}
