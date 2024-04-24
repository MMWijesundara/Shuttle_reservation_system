using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Guna.UI2.WinForms.Suite;

namespace NSBMGO
{
    public partial class Home : UserControl
    {
        private SqlConnection con1;
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private OpenFileDialog openFileDialog1;
        private byte[] imageData;
        private string imagePath;
        DataTable table;

        
        public Home()
        {

            InitializeComponent();
           
            con1 = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");
            adapter = new SqlDataAdapter();
            dataSet = new DataSet();
            openFileDialog1 = new OpenFileDialog();
           

            DataTable dataTable = new DataTable();
            homedatagridView.DataSource = dataTable;

            
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
        

        

        private void inventory_Load(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            



            DataTable dataTable = new DataTable();
            homedatagridView.DataSource = dataTable;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            SqlConnection con1 = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");
            con1.Open();
            SqlCommand cmd = new SqlCommand("Select * from [News]", con1);
            SqlDataAdapter
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            homedatagridView.DataSource = dt;

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();


            string query = "INSERT INTO [News] (Date,News) VALUES (@Date, @News)";

            SqlCommand cmd = new SqlCommand(query, con1);

            //cmd.Parameters.AddWithValue("@Date",Date);
            //cmd.Parameters.AddWithValue("@News", News);
           

            try
            {
                con1.Open();
                cmd.ExecuteNonQuery();
            

                adapter.SelectCommand = new SqlCommand("SELECT * FROM [News]", con1);
                dataSet.Clear();
                adapter.Fill(dataSet, "News");
                homedatagridView.DataSource = dataSet.Tables["News"];

                con1.Close();
            }

            catch

            {
            }
            finally
            {
                
            }
        }
    }

}
