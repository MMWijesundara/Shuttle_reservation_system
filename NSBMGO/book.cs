using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using NSBMGO.Data_access_layer;

namespace NSBMGO
{
    public partial class reserve__2_ : Form
    {
        public reserve__2_()
        {
            InitializeComponent();
        }

        private void reserve__2__Load(object sender, EventArgs e)
        {

        }

        private void guna2Button38_Click(object sender, EventArgs e)
        {
            string studentID = guna2TextBox2.Text;
            string phone = guna2TextBox4.Text;
            string studentfullname = guna2TextBox1.Text;
            string studentaddress = guna2TextBox3.Text;
            string paymentdate = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");
            string batch = guna2TextBox5.Text;
            string totalseats = guna2TextBox7.Text;
            string pricepertickets = guna2TextBox8.Text;
            string totalprice = guna2TextBox9.Text;

           
            try
            {
                SqlConnection conn = new SqlConnection( @"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Ticket(student_id,phone,student_full_name," +
                    "student_address,payment_date,batch,total_seats," +
                    "ticket_price,total_price) VALUES(@studentid,@phone," +
                                  "@studentfullname,@studentaddress,@paymentdate," +
                                  "@batch,@totalseats," +
                                  "@priceperttickets,@totalprice)";

                cmd.Parameters.AddWithValue("@studentid", studentID);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@studentfullname", studentfullname);
                cmd.Parameters.AddWithValue("@studentaddress", studentaddress);
                cmd.Parameters.AddWithValue("@paymentdate", paymentdate);
                cmd.Parameters.AddWithValue("@batch",batch);
                cmd.Parameters.AddWithValue("@totalseats",totalseats);
                cmd.Parameters.AddWithValue("@pricepartickets",pricepertickets);
                cmd.Parameters.AddWithValue("@totalprice",totalprice);
               

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            { 
                MessageBox.Show( ex.Message);
              
            }
            if (MessageBox.Show("Booking successfull.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Close();

            }
        }
    }
}
