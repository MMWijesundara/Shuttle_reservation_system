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
    public partial class Loading_screen : Form
    {
        public Loading_screen()
        {
            InitializeComponent();
        }

        private void Loading_screen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value < 100)
            {
                progressBar1.Value += 1;

                label3.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();

                MessageBox.Show("Done!");
            }
        }
    }
}
