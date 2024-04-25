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
        private OpenFileDialog openFileDialog1;
        private byte[] imageData;
        private string imagePath;
        private SqlConnection conn;


        public Shuttle()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");
            adapter = new SqlDataAdapter();
            dataSet = new DataSet();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(.jpg; *.jpeg; *.png)|.jpg; *.jpeg; *.png";
            DataTable dataTable = new DataTable();
            shuttleDataGridView1.DataSource = dataTable;

        }

        internal FormBorderStyle formBorderStyle;

        public bool TopLevel { get; internal set; }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //string numberPlate = txtNumberPlate.Text;
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
                cmd.CommandText = "INSERT INTO Shuttle(number_plate,start_city,end_city,depart_time,image) VALUES(@numberPlate,@startCity,@endCity,@departTime,@image)";
                cmd.Parameters.AddWithValue("@numberPlate", txtNumberPlate.Text);
                cmd.Parameters.AddWithValue("@startCity", txtStartCity.Text);
                cmd.Parameters.AddWithValue("@endCity", txtEndCity.Text);
                cmd.Parameters.AddWithValue("@departTime", txtDepartTime.Text);
                cmd.Parameters.AddWithValue("@seatCount", txtseatCount.Text);
                cmd.Parameters.AddWithValue("@drivername", txtDriverName.Text);
                cmd.Parameters.AddWithValue("@image", imageData);

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
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(.jpg; *.jpeg; *.png)|.jpg; *.jpeg; *.png";

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
            //string numberPlate = txtNumberPlate.Text;
            //string startCity = txtStartCity.Text;
            //string endCity = txtEndCity.Text;
            //string departTime = txtDepartTime.Text;
            //int seatCount = int.TryParse(txtseatCount.Text);
            //string driverName = txtDriverName.Text;
            byte[] imageData = File.ReadAllBytes(imagePath);

            string query = "UPDATE [Shuttle] SET number_plate = @numberPlate, start_city = @startCity, end_city= @endCity, depart_time = @departTime, image = @image WHERE shuttle_id = @shuttleId";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@numberPlate", txtNumberPlate.Text);
            cmd.Parameters.AddWithValue("@startCity", txtStartCity.Text);
            cmd.Parameters.AddWithValue("@endCity", txtEndCity.Text);
            cmd.Parameters.AddWithValue("@departTime", txtDepartTime.Text);
            cmd.Parameters.AddWithValue("@seatCount", txtseatCount.Text);
            cmd.Parameters.AddWithValue("@drivername", txtDriverName.Text);
            cmd.Parameters.AddWithValue("@image", imageData);

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
            txtDriverName.Clear();
            txtDepartTime.Clear();
            txtseatCount.Clear();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
