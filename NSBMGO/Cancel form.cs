using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NSBMGO
{
    public partial class Cancel_form : Form
    {
        public Cancel_form()
        {
            InitializeComponent();
        }




        private DataTable generateTickets(string studentId)
        {
            //connection con = new connection();
            //con.conn.Open();


            SqlConnection con2 = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");
            con2.Open();

            string query = "SELECT * FROM [Ticket] WHERE studentId = @stuId";
            SqlCommand cmd = new SqlCommand(query, con2);
            cmd.Parameters.AddWithValue("@stuId", txtSearch.Text);
            con2.Close();

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;

            }

        }

        private DataTable getShuttleDetails()
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");
            con2.Open();

            string query = "SELECT * FROM [Ticket] WHERE studentId = @stuId";
            SqlCommand cmd = new SqlCommand(query, con2);
            cmd.Parameters.AddWithValue("@stuId", txtSearch.Text);

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;

            }
        }


        private void generateCard()
        {
            DataTable dtTicket = generateTickets(txtSearch.Text);

            if (dtTicket.Rows.Count > 0)
            {
                for (int i = 0; i < dtTicket.Rows.Count; i++)
                {
                    Cancel_card ticket = new Cancel_card();
                    ticket.lblstuId.Text = dtTicket.Rows[i]["studentId"].ToString();
                    ticket.lblStuName.Text = dtTicket.Rows[i]["studentFullName"].ToString();
                    ticket.lblSeatCount.Text = dtTicket.Rows[i]["totalSeats"].ToString();

                    ticket.lblTotPrice.Text = Convert.ToDecimal(dtTicket.Rows[i]["totalPrice"]).ToString("F2") + " LKR";

                    ticket.Anchor = AnchorStyles.None;

                    tableLayoutPanel2.Controls.Add(ticket);

                }

            }
            else
            {
                MessageBox.Show("No such data exist", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_form_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_IconRightClick(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter StudentId", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tableLayoutPanel2.Controls.Clear();
                generateCard();

            }

        }
    }
}
