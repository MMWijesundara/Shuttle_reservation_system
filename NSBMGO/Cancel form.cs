using NSBMGO.Class_BLL;
using NSBMGO.Data_access_layer;
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


        private void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {

        }

        public void generateReserveCards()
        {

            Reserve_Form form = new Reserve_Form();
            string destination = form.Reservecity;

            flowLayoutPanel1.Controls.Clear();

            int studentId = int.Parse(txtSearch.Text);

            
            ClassBLL objBLL2 = new ClassBLL();
            DataTable dt2 = objBLL2.GetTickets(studentId);

            if (dt2 != null)
            {
                if (dt2.Rows.Count > 0)
                {
                    Cancel_card[] cards = new Cancel_card[dt2.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in dt2.Rows)
                        {
                            cards[i] = new Cancel_card();

                            //MemoryStream ms = new MemoryStream();
                            //cards[i].icon = new Bitmap(ms);

                            cards[i].lblstuId.Text = row["studentId"].ToString();
                            cards[i].lblStuName.Text = row["depart_time"].ToString();
                            cards[i].lblDestination.Text = destination;
                            cards[i].lblSeatCount.Text = row["end_city"].ToString();
                            cards[i].lblTotPrice.Text = row["ticket_price"].ToString();

                            tableLayoutPanel2.Controls.Add(cards[i]);
                            cards[i].Anchor = AnchorStyles.None;
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Empty Data.");
                }
            }


        }

        public DataTable GetItemsfromShuttle(string studentId)
        {
            connection conn1 = new connection();
            conn1.conn.Open();
            string query = "SELECT end_city FROM Shuttle WHERE  ";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.Fill(dt);
        }
    }
}
