using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NSBMGO
{
    public partial class Driver : UserControl
    {
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private OpenFileDialog openFileDialog1;
        private byte[] imageData;
        private string imagePath;
        private SqlConnection conn;
        public Driver()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");
            adapter = new SqlDataAdapter();
            dataSet = new DataSet();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(.jpg; *.jpeg; *.png)|.jpg; *.jpeg; *.png";
            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        internal FormBorderStyle formBorderStyle;
        public bool TopLevel { get; internal set; }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //string drivername = txtNumberPlate.Text;
            //string startCity = txtStartCity.Text;
            //string endCity = txtEndCity.Text;
            //string departTime = txtDepartTime.Text;
            //int seatCount = int.Parse(txtseatCount.Text);
            //string driverName = txtDriverName.Text;
            string contactNo = txtDriverId.Text;
            int contactnumber = Convert.ToInt32(txtContactNumber.Text);

            byte[] imageData = File.ReadAllBytes(imagePath);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Driver(driverName,address,contactNumber,image,driverId) VALUES(@drivername,@driveraddress,@contactnum,@image,@driverId)";
                cmd.Parameters.AddWithValue("@drivername", txtDriverName.Text);
                cmd.Parameters.AddWithValue("@driveraddress", txtDriverAddress.Text);
                cmd.Parameters.AddWithValue("@contactnum", contactnumber);
                cmd.Parameters.AddWithValue("@driverId", txtDriverId.Text);

                cmd.Parameters.AddWithValue("@image", imageData);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Saved");

                adapter.SelectCommand = new SqlCommand("SELECT * FROM [Driver]", conn);
                dataSet.Clear();
                adapter.Fill(dataSet, "Driver");
                dataGridView1.DataSource = dataSet.Tables["Driver"];
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog = new OpenFileDialog();


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                imageData = File.ReadAllBytes(imagePath);

                guna2PictureBox1.Image = Image.FromFile(imagePath);

                this.imagePath = imagePath;
            }
        }

        private void Driver_Load(object sender, EventArgs e)
        {


            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(.jpg; *.jpeg; *.png)|.jpg; *.jpeg; *.png";

            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            try
            {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Driver]", conn);
            SqlDataAdapter
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "UPDATE [Driver] SET driverName = @drivername, address = @address, contactNumber= @contactnumber,  image = @image WHERE driverId = @Id";

            SqlCommand cmd = new SqlCommand(query, conn);
            int contactnumber = int.Parse(txtContactNumber.Text);
            cmd.Parameters.AddWithValue("@drivername", txtDriverName.Text);
            cmd.Parameters.AddWithValue("@address", txtDriverAddress.Text);
            cmd.Parameters.AddWithValue("@contactnumber", contactnumber);
            cmd.Parameters.AddWithValue("@image", imageData);

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                // Get the driverId directly as a string
                string driverId = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                cmd.Parameters.AddWithValue("@Id", driverId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully Updated");
                        refreshDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("No rows updated");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void refreshDataGridView()
        {
            try
            {
                adapter.SelectCommand = new SqlCommand("SELECT * FROM [Driver]", conn);
                dataSet.Clear();
                adapter.Fill(dataSet, "Driver");
                dataGridView1.DataSource = dataSet.Tables["Driver"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing DataGridView: " + ex.Message);
            }
        }


        


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;


                int driverId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);

                string query = "DELETE FROM [Driver] WHERE driverId = @driverId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@driverId", driverId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully Deleted");

                        dataSet.Clear();
                        adapter.SelectCommand = new SqlCommand("SELECT * FROM [Driver]", conn);
                        adapter.Fill(dataSet, "Driver");
                        dataGridView1.DataSource = dataSet.Tables["Driver"];
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

            txtDriverName.Clear();
            txtDriverAddress.Clear();
            txtDriverId.Clear();
            txtContactNumber.Clear();
            guna2PictureBox1.Image = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = guna2TextBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM [Driver] WHERE driverId = @driverId";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@driverId", searchText);

                    adapter.SelectCommand = cmd;
                    dataSet.Clear();
                    adapter.Fill(dataSet, "Driver");
                    dataGridView1.DataSource = dataSet.Tables["Driver"];

                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("No matching records found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                    // Log the exception for debugging purposes
                    Console.WriteLine("Search Error: " + ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter search criteria.");
            }
        }
    }
}
