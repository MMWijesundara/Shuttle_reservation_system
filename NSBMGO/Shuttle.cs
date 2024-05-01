using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



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
                cmd.CommandText = "INSERT INTO Shuttle(number_plate,depart_time,route_id,driver_id) VALUES(@numberPlate,@departTime,@routeId,@driverId)";
                cmd.Parameters.AddWithValue("@numberPlate", txtNumberPlate.Text);
                cmd.Parameters.AddWithValue("@routeId", txtRouteID.Text);
                cmd.Parameters.AddWithValue("@driverId", txtDriverID.Text);
                cmd.Parameters.AddWithValue("@departTime", txtDepartTime.Text);

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

            string query = "UPDATE [Shuttle] SET number_plate = @numberPlate, depart_time = @departTime, route_id= @routeId, driver_id= @driverId WHERE shuttle_id = @shuttleId";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@numberPlate", txtNumberPlate.Text);
            cmd.Parameters.AddWithValue("@routeId", txtRouteID.Text);
            cmd.Parameters.AddWithValue("@driverId", txtDriverID.Text);
            cmd.Parameters.AddWithValue("@departTime", txtDepartTime.Text);

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
            txtDepartTime.Clear();
            txtRouteID.Clear();
            txtDriverID.Clear();
        }
    }
}
