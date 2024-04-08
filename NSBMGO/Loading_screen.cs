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
            if (bunifuProgressBar1.Value <= 99)
            {
                bunifuProgressBar1.Value += 1;
                guna2HtmlLabel2.Text = (bunifuProgressBar1.Value.ToString() + "% ");


            }

            else
            {
                timer1.Stop();  
                LogIn login = new LogIn();

                this.Hide();
                login.Show();
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
