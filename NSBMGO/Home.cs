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
        DataTable table;
        
        public Home()
        {
            InitializeComponent();
        }

        internal FormBorderStyle FormBorderStyle;
        public bool TopLevel {  get; internal set; }

        private void Home_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtMessage.Text);
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            table= new DataTable();
            table.Columns.Add("Messages", typeof(string));

            guna2DataGridView1.DataSource = table;
        }

        private void txtSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtMessage.Text);
            int index = guna2DataGridView1.CurrentCell.RowIndex;

            if (index > -1)
            {
                txtMessage.Text = table.Rows[index].ItemArray[0].ToString();

            }
            txtMessage.Clear() ;
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            int index = guna2DataGridView1.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }
    }

}
