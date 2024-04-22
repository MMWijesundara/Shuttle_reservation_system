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
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            tableLayoutPanel1.Dock = DockStyle.Fill;

            table = new DataTable();
            table.Columns.Add("Messages", typeof(string));

            guna2DataGridView1.DataSource = table;
        }

        

        



         

        private void txtAdd(object sender, EventArgs e)
        {
            table.Rows.Add(txtMessage.Text);
            int index = guna2DataGridView1.CurrentCell.RowIndex;

            if (index > 0)
            {
                txtMessage.Text = table.Rows[index].ItemArray[0].ToString();
            }
            txtMessage.Clear();
        }

        private void txt_delete(object sender, EventArgs e)
        {
            if (table.Rows.Count > 0)
            {
                int index = guna2DataGridView1.CurrentCell.RowIndex;
                table.Rows[index].Delete();
            }
        }
    }

}
