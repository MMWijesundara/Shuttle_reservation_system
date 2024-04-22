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

            timer1 = new Timer();
            timer1.Interval = 1000; // Update every second (1000 milliseconds)
            timer1.Tick += Timer_Tick; // Attach event handler
            timer1.Start(); // Start the timer


            // Set initial value for the label
            UpdateLabel();
        }

        internal FormBorderStyle FormBorderStyle;
        public bool TopLevel {  get; internal set; }

        private void Home_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            table = new DataTable();
            table.Columns.Add("Messages", typeof(string));

            guna2DataGridView1.DataSource = table;
        }

        

        private void txtAdd_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtMessage.Text);
            int index = guna2DataGridView1.CurrentCell.RowIndex;

            if (index > 0)
            {
                txtMessage.Text = table.Rows[index].ItemArray[0].ToString();
            }
            txtMessage.Clear();
        }


        private void txtDelete_Click(object sender, EventArgs e)
        {
            if(table.Rows.Count > 0)
            {
                int index = guna2DataGridView1.CurrentCell.RowIndex;
                table.Rows[index].Delete();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the label on every tick
            UpdateLabel();
        }

        private void UpdateLabel()
        {

            date.Text = DateTime.Now.ToString();
        }
    }

}
