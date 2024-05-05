using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using NSBMGO.Class_BLL;
using System.Data;

namespace NSBMGO
{
    public partial class Reserve_Form : Form
    {

        internal int SeatPrice;
        internal int TotPrice;
        internal int selectedLabelCount;
        internal string stD;
        internal string enD;
        internal string shutId;

        private List<Guna2HtmlLabel> selectedLabels = new List<Guna2HtmlLabel>();


        public Reserve_Form()
        {
            InitializeComponent();
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
        }
        private void Reserve_Form_Load(object sender, EventArgs e)
        {

        }


        private void updateBookingForm()
        {

        }

        private void calDetails()
        {
            TotPrice = Convert.ToInt32(txtTotalSeats.Text) * Convert.ToInt32(guna2TextBox10.Text);
            guna2TextBox11.Text = TotPrice.ToString();

        }








        public void generateReserveCards()
        {

            tableLayoutPanel2.Controls.Clear();

            string startcity = txtSearchStart.Text.Trim();
            string endCity = txtSearchEnd.Text.Trim();

            ClassBLL objBLL = new ClassBLL();

            DataTable dt = objBLL.GetItems(startcity, endCity);



            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    reserve_card[] cards = new reserve_card[dt.Rows.Count];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        cards[i] = new reserve_card();

                        //MemoryStream ms = new MemoryStream();
                        //cards[i].icon = new Bitmap(ms);

                        cards[i].numPlate.Text = dt.Rows[i]["number_plate"].ToString();

                        string timeString = dt.Rows[i]["depart_time"].ToString();
                        cards[i].Time.Text = timeString.Substring(0, 5); // Get first 5 characters (hh:mm)



                        cards[i].startCity.Text = dt.Rows[i]["start_city"].ToString();
                        cards[i].endCity.Text = dt.Rows[i]["end_city"].ToString();
                        //cards[i].Price.Text = dt.Rows[i]["price"].ToString();
                        //cards[i].Price.Text = string.Format("{0:C2} LKR", dt.Rows[i]["price"]);
                        cards[i].Price.Text = (dt.Rows[i]["price"]).ToString() + " LKR";

                        //cards[i].btnReserve.Click += new EventHandler(btnReserve_Click);

                        SeatPrice = Convert.ToInt32(dt.Rows[i]["price"]);
                        shutId = dt.Rows[i]["shuttle_id"].ToString();
                        guna2TextBox10.Text = SeatPrice.ToString();



                        tableLayoutPanel2.Controls.Add(cards[i]);
                        cards[i].Anchor = AnchorStyles.None;

                    }
                }

                else
                {
                    MessageBox.Show("Empty Data.");
                }
            }



        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            guna2TextBox10.Text = SeatPrice.ToString();
        }
        private void Label_Click(object sender, EventArgs e)
        {
            {
                Guna2HtmlLabel lbl = sender as Guna2HtmlLabel;
                if (lbl.BackColor == Color.White)
                {
                    lbl.BackColor = ColorTranslator.FromHtml("#1151f2"); 
                    selectedLabels.Add(lbl); 
                    selectedLabelCount++;
                }
                else if (lbl.BackColor == ColorTranslator.FromHtml("#1151f2"))
                {
                    lbl.BackColor = Color.White; 
                    selectedLabels.Remove(lbl); 
                    selectedLabelCount--;
                }

                
                

            }
        }

        
        private void UpdateSelectedSeatsCount()
        {
            

            txtTotalSeats.Text = selectedLabelCount.ToString();

        }

        
        private void btnAddSeats_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to confirm the selected seats?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            

            if (result == DialogResult.Yes)
            {
                UpdateSelectedSeatsCount();
                
                foreach (Guna2HtmlLabel lbl in selectedLabels)
                {
                    lbl.BackColor = ColorTranslator.FromHtml("#ed0933");
                }

                calDetails();
            }

            else
            {
                foreach (Guna2HtmlLabel lbl in selectedLabels)
                {
                    if (lbl.BackColor == ColorTranslator.FromHtml("#1151f2")) // Check if the label color is blue
                    {
                        lbl.BackColor = Color.White;
                    }
                }
            }
            
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Access the selected range of dates
            DateTime startDate = monthCalendar1.SelectionStart;
             stD = startDate.ToString("yyyy-MM-dd");
            DateTime endDate = monthCalendar1.SelectionEnd;
             enD = endDate.ToString("yyyy-MM-dd");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Ticket(studentId,phone,studentFullName,studentAddress,payementDate,payementMethod,batch,totalSeats,ticketPrice,totalPrice,travelStartDate,travelEndDate,shuttleId) VALUES(@studentid,@phone,@studentfullname,@studentaddress,@paymentdate,@payementMeth,@batch,@totalseats,@ppt,@totalprice,@startDate, @endDate, @shutID)";

                cmd.Parameters.AddWithValue("@studentid", guna2TextBox5.Text);
                cmd.Parameters.AddWithValue("@phone", guna2TextBox4.Text);
                cmd.Parameters.AddWithValue("@studentfullname", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@studentaddress", guna2TextBox3.Text);
                cmd.Parameters.AddWithValue("@paymentdate", guna2DateTimePicker2.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@batch", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@totalseats", txtTotalSeats.Text);
                cmd.Parameters.AddWithValue("@ppt", guna2TextBox10.Text);
                cmd.Parameters.AddWithValue("@totalprice", guna2TextBox11.Text);
                cmd.Parameters.AddWithValue("@payementMeth", guna2ComboBox1.Text);
                cmd.Parameters.AddWithValue("@startDate",stD);
                cmd.Parameters.AddWithValue("@endDate", enD);
                cmd.Parameters.AddWithValue("@shutID", shutId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Data inserted successfully!\n{rowsAffected} rows affected. ");
                }
                else
                {
                    MessageBox.Show("An error occurred while inserting data. Please try again.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            generateReserveCards();
        }
    }

}
