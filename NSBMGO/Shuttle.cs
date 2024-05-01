using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;



namespace NSBMGO
{
    public partial class Shuttle : UserControl
    {
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private SqlConnection conn;


        public Shuttle()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");
            adapter = new SqlDataAdapter();
            dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            shuttleDataGridView1.DataSource = dataTable;

        }

        internal FormBorderStyle formBorderStyle;

        public bool TopLevel { get; internal set; }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Shuttle(number_plate,start_city,end_city,depart_time,price,driver_id,shuttle_id) VALUES(@numberPlate,@startCity,@endCity,@departTime,@price,@driverId,@shuttleId)";
                cmd.Parameters.AddWithValue("@numberPlate", txtNumberPlate.Text);
                cmd.Parameters.AddWithValue("@startCity", txtStartCity.Text);
                cmd.Parameters.AddWithValue("@endCity", txtEndCity.Text);
                cmd.Parameters.AddWithValue("@departTime", txtDepartTime.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@driverId", txtDriverId.Text);
                cmd.Parameters.AddWithValue("@shuttleId", txtShuttleID.Text);

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

        private void Shuttle_Load(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            shuttleDataGridView1.DataSource = dataTable;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Shuttle]", conn);
            SqlDataAdapter
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            shuttleDataGridView1.DataSource = dt;
            conn.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            conn.Open();

            string query = "UPDATE [Shuttle] SET number_plate = @numberPlate, start_city = @startCity, end_city= @endCity, depart_time = @departTime, price = @price,driver_id =@driverId  WHERE shuttle_id = @shuttleId";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@numberPlate", txtNumberPlate.Text);
            cmd.Parameters.AddWithValue("@startCity", txtStartCity.Text);
            cmd.Parameters.AddWithValue("@endCity", txtEndCity.Text);
            cmd.Parameters.AddWithValue("@departTime", txtDepartTime.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@driverId", txtDriverId.Text);
            //cmd.Parameters.AddWithValue("@shuttleId", txtShuttleID.Text);

            if (shuttleDataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = shuttleDataGridView1.SelectedRows[0].Index;


                int shuttleId = Convert.ToInt32(shuttleDataGridView1.Rows[selectedRowIndex].Cells[0].Value);


                cmd.Parameters.AddWithValue("@shuttleId", shuttleId);


                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    int secondRowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    adapter.SelectCommand = new SqlCommand("SELECT * FROM [Shuttle]", conn);
                    dataSet.Clear();
                    adapter.Fill(dataSet, "Shuttle");
                    shuttleDataGridView1.DataSource = dataSet.Tables["Shuttle"];

                    if (rowsAffected > 0 && secondRowsAffected > 0)
                    {
                        MessageBox.Show("Successfully Updated");
                        dataSet.Clear();
                        adapter.SelectCommand = new SqlCommand("SELECT * FROM [Shuttle]", conn);
                        adapter.Fill(dataSet, "Shuttle");
                        shuttleDataGridView1.DataSource = dataSet.Tables["Shuttle"];
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
            if (shuttleDataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = shuttleDataGridView1.SelectedRows[0].Index;


                int shuttleId = Convert.ToInt32(shuttleDataGridView1.Rows[selectedRowIndex].Cells[0].Value);

                string query = "DELETE FROM [Shuttle] WHERE shuttle_id = @shuttleId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@shuttleId", shuttleId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully Deleted");

                        dataSet.Clear();
                        adapter.SelectCommand = new SqlCommand("SELECT * FROM [Shuttle]", conn);
                        adapter.Fill(dataSet, "Shuttle");
                        shuttleDataGridView1.DataSource = dataSet.Tables["Shuttle"];
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


            txtNumberPlate.Clear();
            txtStartCity.Clear();
            txtEndCity.Clear();
            txtDepartTime.Clear();
            txtPrice.Clear();
            txtDriverId.Clear();
            txtShuttleID.Clear();   
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string query = "SELECT * FROM Shuttle WHERE start_city = @startcity AND end_city = @endcity";

            cmd.Parameters.AddWithValue("@startCity", txtStartCity.Text);
            cmd.Parameters.AddWithValue("@endCity", txtEndCity.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Successfully Saved");

            adapter.SelectCommand = new SqlCommand("query", conn);
            dataSet.Clear();
            adapter.Fill(dataSet, "Shuttle");
            shuttleDataGridView1.DataSource = dataSet.Tables["Shuttle"];
            conn.Close();



        }
    }
}
