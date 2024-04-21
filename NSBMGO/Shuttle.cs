using NSBMGO.Data_access_layer;
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

namespace NSBMGO
{
    public partial class Shuttle : UserControl
    {
        public Shuttle()
        {
            InitializeComponent();
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //string numberPlate = txtNumberPlate.Text;
            //string startCity = txtStartCity.Text;
            //string endCity = txtEndCity.Text;
            //string departTime = txtDepartTime.Text;
            //int seatCount = int.Parse(txtseatCount.Text);
            //string driverName = txtDriverName.Text;

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Shuttle(number_plate,start_city,end_city,depart_time) VALUES(@numberPlate,@startCity,@endCity,@departTime)";
                cmd.Parameters.AddWithValue ("@numberPlate",txtNumberPlate.Text);
                cmd.Parameters.AddWithValue("@startCity",txtStartCity.Text);
                cmd.Parameters.AddWithValue("@endCity",txtEndCity.Text);
                cmd.Parameters.AddWithValue("@departTime",txtDepartTime.Text);
                cmd.Parameters.AddWithValue("@seatCount",txtseatCount.Text);
                cmd.Parameters.AddWithValue("@drivername",txtDriverName.Text);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }
    }
}
