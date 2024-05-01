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
//using Guna.UI2.HtmlRenderer.Adapters;
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
                cmd.CommandText = "INSERT INTO route(startCity,endCity,shuttleId,driverId,price) VALUES(@startCity,@endCity,@shuttleId,@driverId,@price)";
                cmd.Parameters.AddWithValue("@startCity", txtStartCity.Text);
                cmd.Parameters.AddWithValue("@endCity", txtEndCity.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved");

                adapter.SelectCommand = new SqlCommand("SELECT * FROM [route]", conn);
                dataSet.Clear();
                adapter.Fill(dataSet, "route");
                routeDataGridView1.DataSource = dataSet.Tables["route"];
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }

        private void Route_Load(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            routeDataGridView1.DataSource = dataTable;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [route]", conn);
            SqlDataAdapter
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            routeDataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //string numberPlate = txtNumberPlate.Text;
            //string startCity = txtStartCity.Text;
            //string endCity = txtEndCity.Text;
            //string departTime = txtDepartTime.Text;
            //int seatCount = int.TryParse(txtseatCount.Text);
            //string driverName = txtDriverName.Text;

            string query = "UPDATE [route] SET startCity = @startCity, endCity= @endCity, shuttleId = @shuttleId, driverId= @driverId, price = @price WHERE routeId = @routeId";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@startCity", txtStartCity.Text);
            cmd.Parameters.AddWithValue("@endCity", txtEndCity.Text);
            cmd.Parameters.AddWithValue("@shuttleId", txtShuttleID.Text);
            cmd.Parameters.AddWithValue("@driverId", txtDriverID.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);

            if (routeDataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = routeDataGridView1.SelectedRows[0].Index;


                int routeId = Convert.ToInt32(routeDataGridView1.Rows[selectedRowIndex].Cells[0].Value);


                cmd.Parameters.AddWithValue("@routeId", routeId);


                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    int secondRowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    adapter.SelectCommand = new SqlCommand("SELECT * FROM [route]", conn);
                    dataSet.Clear();
                    adapter.Fill(dataSet, "route");
                    routeDataGridView1.DataSource = dataSet.Tables["route"];

                    if (rowsAffected > 0 && secondRowsAffected > 0)
                    {
                        MessageBox.Show("Successfully Updated");
                        dataSet.Clear();
                        adapter.SelectCommand = new SqlCommand("SELECT * FROM [route]", conn);
                        adapter.Fill(dataSet, "route");
                        routeDataGridView1.DataSource = dataSet.Tables["route"];
                    }
                    else
                    {
                        MessageBox.Show("No rows updated");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (routeDataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = routeDataGridView1.SelectedRows[0].Index;


                int routeId = Convert.ToInt32(routeDataGridView1.Rows[selectedRowIndex].Cells[0].Value);

                string query = "DELETE FROM [route] WHERE routeId = @routeId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@routeId", routeId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully Deleted");

                        dataSet.Clear();
                        adapter.SelectCommand = new SqlCommand("SELECT * FROM [route]", conn);
                        adapter.Fill(dataSet, "route");
                        routeDataGridView1.DataSource = dataSet.Tables["route"];
                    }
                    else
                    {
                        MessageBox.Show("No rows deleted");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStartCity.Clear();
            txtEndCity.Clear();
            txtShuttleID.Clear();
            txtDriverID.Clear();
            txtPrice.Clear();
        }
    } }

