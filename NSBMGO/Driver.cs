using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSBMGO
{
    public partial class Driver : UserControl
    {
        public FormBorderStyle FormBorderStyle;
        private OpenFileDialog openFileDialog1;
        private byte[] imageData;
        private SqlDataAdapter adapter;
        private DataSet dataSet;
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
            driverDataGridView1.DataSource = dataTable;
        }

        internal FormBorderStyle formBorderStyle;
        public bool TopLevel { get; internal set; }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void driverDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            byte[] imageData = File.ReadAllBytes(imagePath);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Driver(driverName,address,contactNumber,image) VALUES(@drivername,@driveraddress,@contactnum,@image)";
                cmd.Parameters.AddWithValue("@drivername", txtDriverName.Text);
                cmd.Parameters.AddWithValue("@driveraddress", txtDriverAddress.Text);
                cmd.Parameters.AddWithValue("@contactnum", txtContactNumber.Text);
         
                cmd.Parameters.AddWithValue("@image", imageData);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Saved");

                adapter.SelectCommand = new SqlCommand("SELECT * FROM [Driver]", conn);
                dataSet.Clear();
                adapter.Fill(dataSet, "Driver");
                driverDataGridView1.DataSource = dataSet.Tables["Driver"];
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
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }


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
            driverDataGridView1.DataSource = dataTable;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Driver]", conn);
            SqlDataAdapter
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            driverDataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //string drivername = txtNumberPlate.Text;
            //string startCity = txtStartCity.Text;
            //string endCity = txtEndCity.Text;
            //string departTime = txtDepartTime.Text;
            //int seatCount = int.TryParse(txtseatCount.Text);
            //string driverName = txtDriverName.Text;

            string query = "UPDATE [Driver] SET driverName = @drivername, address = @address, contactNumber= @contactnumber,  image = @image WHERE driverId = @Id";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@drivername", txtDriverName.Text);
            cmd.Parameters.AddWithValue("@address", txtDriverAddress.Text);
            cmd.Parameters.AddWithValue("@contactnumber", txtContactNumber.Text);
      
            cmd.Parameters.AddWithValue("@image", imageData);

            if (driverDataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = driverDataGridView1.SelectedRows[0].Index;


                int Id = Convert.ToInt32(driverDataGridView1.Rows[selectedRowIndex].Cells[0].Value);


                cmd.Parameters.AddWithValue("@Id", Id);


                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    int secondRowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    adapter.SelectCommand = new SqlCommand("SELECT * FROM [Driver]", conn);
                    dataSet.Clear();
                    adapter.Fill(dataSet, "Driver");
                    driverDataGridView1.DataSource = dataSet.Tables["Driver"];

                    if (rowsAffected > 0 && secondRowsAffected > 0)
                    {
                        MessageBox.Show("Successfully Updated");
                        dataSet.Clear();
                        adapter.SelectCommand = new SqlCommand("SELECT * FROM [Driver]", conn);
                        adapter.Fill(dataSet, "Driver");
                        driverDataGridView1.DataSource = dataSet.Tables["Driver"];
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
            if (driverDataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = driverDataGridView1.SelectedRows[0].Index;


                int driverId = Convert.ToInt32(driverDataGridView1.Rows[selectedRowIndex].Cells[0].Value);

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
                       driverDataGridView1.DataSource = dataSet.Tables["Driver"];
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
            txtContactNumber.Clear();
            guna2PictureBox1.Image=null;
        }
    }
}
