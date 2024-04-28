using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Guna.UI2.HtmlRenderer.Adapters;
using System.Data.SqlClient;

namespace NSBMGO
{
    public partial class Route : UserControl

    {
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private OpenFileDialog openFileDialog1;
        private byte[] imageData;
        private string imagePath;
        private SqlConnection conn;
        public Route()
        {

            InitializeComponent();
            conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");
            adapter = new SqlDataAdapter();
            dataSet = new DataSet();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(.jpg; *.jpeg; *.png)|.jpg; *.jpeg; *.png";
            DataTable dataTable = new DataTable();
            routeDataGridView1.DataSource = dataTable;
        }

        internal FormBorderStyle formBorderStyle;

        public bool TopLevel { get; internal set; }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO route(startCity,endCity,shuttleId,driverId,price) VALUES(@startCity,@endCity,@shuttleId,driverId,@price)";
                cmd.Parameters.AddWithValue("@startCity", txtStartCity.Text);
                cmd.Parameters.AddWithValue("@endCity", txtEndCity.Text);
                cmd.Parameters.AddWithValue("@shuttleId", txtShuttleID.Text);
                cmd.Parameters.AddWithValue("@driverId", txtDriverID.Text);
                cmd.Parameters.AddWithValue("@prce", txtPrice.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved");

                adapter.SelectCommand = new SqlCommand("SELECT * FROM [Shuttle]", conn);
                dataSet.Clear();
                adapter.Fill(dataSet, "Shuttle");
                shuttleDataGridView1.DataSource = dataSet.Tables["Shuttle"];
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }
    }
}
