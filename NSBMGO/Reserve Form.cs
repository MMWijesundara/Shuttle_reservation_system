using System.Data.SqlClient;
using NSBMGO.Class_BLL;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NSBMGO
{
    public partial class Reserve_Form : Form
    {
        public Reserve_Form()
        {
            InitializeComponent();
        }









        public void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {

            generateReserveCards();
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
                        cards[i].Time.Text = dt.Rows[i]["depart_time"].ToString();
                        cards[i].startCity.Text = dt.Rows[i]["start_city"].ToString();
                        cards[i].endCity.Text = dt.Rows[i]["end_city"].ToString();
                        cards[i].Price.Text = dt.Rows[i]["price"].ToString();

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





        // Helper method to check if the table layout panel is empty
        private bool IsTableLayoutPanelEmpty(TableLayoutPanel tableLayoutPanel)
        {
            return tableLayoutPanel.Controls.Count == 0;
        }

        // Helper method to check if a specific cell is available for adding a card
        private bool CanAddCardToTableLayoutPanel(TableLayoutPanel tableLayoutPanel, int rowIndex, int columnIndex)
        {
            if (rowIndex > tableLayoutPanel.RowCount || columnIndex > tableLayoutPanel.ColumnCount)
            {
                return false; // Out of bounds
            }

            // Check if the cell at the specified index already contains a control
            return tableLayoutPanel.GetControlFromPosition(columnIndex, rowIndex) == null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            generateReserveCards();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
   
        private void Draw1chairs()
        {
            int chair = 1; // Initialize chair to 1

            for (int i = 0; i < pnChair1.ColumnCount; i++)
            {
                for (int j = 0; j < pnChair1.RowCount; j++)
                {
                    Label lblchair = new Label();
                    lblchair.Text = chair.ToString(); // Convert chair to string
                    lblchair.AutoSize = false;
                    lblchair.Dock = DockStyle.Fill;
                    lblchair.TextAlign = ContentAlignment.MiddleCenter;
                    lblchair.BackColor = Color.White;
                    pnChair1.Controls.Add(lblchair, i, j);
                    chair++;

                    lblchair.Click += Lblchair_Click;


                }
            }
        }

        private void Lblchair_Click(object sender, EventArgs e)
        {
            Label lblchair = sender as Label;
            if (lblchair.BackColor == Color.White)
            {
                lblchair.BackColor = Color.SkyBlue;
            }

            else if (lblchair.BackColor == Color.SkyBlue)

                lblchair.BackColor = Color.White;


            else if (lblchair.BackColor == Color.Red)

                MessageBox.Show("The chair " + lblchair.Text + "is choose.");
        }

        private void Draw2chairs()
        {
            int chair2 = 23;
            for (int z = 0; z < pnChair2.ColumnCount; z++)
            {
                for (int x = 0; x < pnChair2.RowCount; x++)
                {
                    Label lblchair2 = new Label();
                    lblchair2.Text = chair2 + "";
                    lblchair2.AutoSize = false;
                    lblchair2.Dock = DockStyle.Fill;
                    lblchair2.TextAlign = ContentAlignment.MiddleCenter;
                    lblchair2.BackColor = Color.White;

                    pnChair2.Controls.Add(lblchair2, z, x);
                    chair2++;

                    lblchair2.Click += Lblchair2_Click;
                }
            }
        }

        private void Lblchair2_Click(object sender, EventArgs e)
        {
            Label lblchair2 = sender as Label;
            if (lblchair2.BackColor == Color.White)
            {
                lblchair2.BackColor = Color.SkyBlue;
            }
            else if (lblchair2.BackColor == Color.SkyBlue)

                lblchair2.BackColor = Color.White;


            else if (lblchair2.BackColor == Color.Red)

                MessageBox.Show("The chair " + lblchair2.Text + "is choose.");
        }

        private void Draw3chairs()
        {
            int chair3 = 45;
            int maxColumns = 6; // Maximum number of columns

            for (int m = 0; m < Math.Min(pnChair3.ColumnCount, maxColumns); m++)
            {

                for (int n = 0; n < 1; n++)
                {
                    Label lblchair3 = new Label();
                    lblchair3.Text = chair3.ToString();
                    lblchair3.AutoSize = false;
                    lblchair3.Dock = DockStyle.Fill;
                    lblchair3.TextAlign = ContentAlignment.MiddleCenter;
                    lblchair3.BackColor = Color.White;

                    pnChair3.Controls.Add(lblchair3, m, n);
                    chair3++;

                    lblchair3.Click += Lblchair3_Click;


                }
            }
        }

        private void Lblchair3_Click(object sender, EventArgs e)
        {
            Label lblchair3 = sender as Label;
            if (lblchair3.BackColor == Color.White)
            {
                lblchair3.BackColor = Color.SkyBlue;
            }
            else if (lblchair3.BackColor == Color.SkyBlue)

                lblchair3.BackColor = Color.White;


            else if (lblchair3.BackColor == Color.Red)

                MessageBox.Show("The chair " + lblchair3.Text + "is choose.");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("confirm the selected labels..", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (result == DialogResult.OK)
            {
                StringBuilder selectedChairs = new StringBuilder();

                for (int i = 0; i < pnChair1.Controls.Count; i++)
                {
                    Label lblchair = pnChair1.Controls[i] as Label;
                    if (lblchair.BackColor == Color.SkyBlue)
                    {
                        lblchair.BackColor = Color.Red;
                        int chair = int.Parse(lblchair.Text);

                    }
                }

                for (int i = 0; i < pnChair2.Controls.Count; i++)
                {
                    Label lblchair2 = pnChair2.Controls[i] as Label;
                    if (lblchair2.BackColor == Color.SkyBlue)
                    {
                        lblchair2.BackColor = Color.Red;
                        int chair = int.Parse(lblchair2.Text);

                    }
                }

                for (int i = 0; i < pnChair3.Controls.Count; i++)
                {

                    Label lblchair3 = pnChair3.Controls[i] as Label;
                    if (lblchair3.BackColor == Color.SkyBlue)
                    {
                        lblchair3.BackColor = Color.Red;
                        int chair = int.Parse(lblchair3.Text);

                    }


                }
                foreach (Control control in pnChair1.Controls)
                {
                    if (control is Button btnChair && btnChair.BackColor == Color.Red)
                    {
                        selectedChairs.Append(btnChair.Text).Append(", ");
                    }
                }

                foreach (Control control in pnChair2.Controls)
                {
                    if (control is Button btnChair2 && btnChair2.BackColor == Color.Red)
                    {
                        selectedChairs.Append(btnChair2.Text).Append(", ");
                    }
                }

                for (int i = 0; i < pnChair3.Controls.Count; i++)
                {
                    Label lblchair3 = pnChair3.Controls[i] as Label;
                    if (lblchair3.BackColor == Color.SkyBlue)
                    {
                        lblchair3.BackColor = Color.Red;
                        int chair = int.Parse(lblchair3.Text);
                    }


                    int selectedLabelCount = 0;

                    foreach (Control control in pnChair3.Controls)
                    {
                        if (control is Label label && label.BackColor == Color.Red)
                        {
                            selectedLabelCount++;
                        }
                    }
                    foreach (Control control in pnChair1.Controls)
                    {
                        if (control is Label label && label.BackColor == Color.Red)
                        {
                            selectedLabelCount++;
                        }
                    }
                    foreach (Control control in pnChair2.Controls)
                    {
                        if (control is Label label && label.BackColor == Color.Red)
                        {
                            selectedLabelCount++;
                            guna2Button38.Enabled = true;
                            guna2TextBox7.Text = selectedLabelCount.ToString();
                        }
                    }
                }
            }



            else
            {
                DeselectAllLabels(pnChair1.Controls);
                DeselectAllLabels(pnChair2.Controls);
                DeselectAllLabels(pnChair3.Controls);
            }


        }
        private void DeselectAllLabels(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Label label && label.BackColor == Color.SkyBlue)
                {
                    label.BackColor = Color.White;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("confirm the selected labels..", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (result == DialogResult.OK)
            {
                StringBuilder selectedChairs = new StringBuilder();

                for (int i = 0; i < pnChair1.Controls.Count; i++)
                {
                    Label lblchair = pnChair1.Controls[i] as Label;
                    if (lblchair.BackColor == Color.SkyBlue)
                    {
                        lblchair.BackColor = Color.Red;
                        int chair = int.Parse(lblchair.Text);

                    }
                }

                for (int i = 0; i < pnChair2.Controls.Count; i++)
                {
                    Label lblchair2 = pnChair2.Controls[i] as Label;
                    if (lblchair2.BackColor == Color.SkyBlue)
                    {
                        lblchair2.BackColor = Color.Red;
                        int chair = int.Parse(lblchair2.Text);

                    }
                }

                for (int i = 0; i < pnChair3.Controls.Count; i++)
                {

                    Label lblchair3 = pnChair3.Controls[i] as Label;
                    if (lblchair3.BackColor == Color.SkyBlue)
                    {
                        lblchair3.BackColor = Color.Red;
                        int chair = int.Parse(lblchair3.Text);

                    }


                }
                foreach (Control control in pnChair1.Controls)
                {
                    if (control is Button btnChair && btnChair.BackColor == Color.Red)
                    {
                        selectedChairs.Append(btnChair.Text).Append(", ");
                    }
                }

                foreach (Control control in pnChair2.Controls)
                {
                    if (control is Button btnChair2 && btnChair2.BackColor == Color.Red)
                    {
                        selectedChairs.Append(btnChair2.Text).Append(", ");
                    }
                }

                for (int i = 0; i < pnChair3.Controls.Count; i++)
                {
                    Label lblchair3 = pnChair3.Controls[i] as Label;
                    if (lblchair3.BackColor == Color.SkyBlue)
                    {
                        lblchair3.BackColor = Color.Red;
                        int chair = int.Parse(lblchair3.Text);
                    }


                    int selectedLabelCount = 0;

                    foreach (Control control in pnChair3.Controls)
                    {
                        if (control is Label label && label.BackColor == Color.Red)
                        {
                            selectedLabelCount++;
                        }
                    }
                    foreach (Control control in pnChair1.Controls)
                    {
                        if (control is Label label && label.BackColor == Color.Red)
                        {
                            selectedLabelCount++;
                        }
                    }
                    foreach (Control control in pnChair2.Controls)
                    {
                        if (control is Label label && label.BackColor == Color.Red)
                        {
                            selectedLabelCount++;

                            guna2Button38.Enabled = true;
                            guna2TextBox7.Text = selectedLabelCount.ToString();
                        }
                    }
                }
            }

           
        }

        private void guna2Button38_Click_1(object sender, EventArgs e)
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
                SqlConnection conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");

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
                cmd.Parameters.AddWithValue("@batch", batch);
                cmd.Parameters.AddWithValue("@totalseats", totalseats);
                cmd.Parameters.AddWithValue("@pricepartickets", pricepertickets);
                cmd.Parameters.AddWithValue("@totalprice", totalprice);


                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            if (MessageBox.Show("Booking successfull.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Close();

            }
        }

        private void Reserve_Form_Load(object sender, EventArgs e)
        {
            Draw1chairs();
            Draw2chairs();
            Draw3chairs();


            pnChair1.BorderStyle = BorderStyle.Fixed3D;
            pnChair2.BorderStyle = BorderStyle.Fixed3D;
            pnChair3.BorderStyle = BorderStyle.Fixed3D;

        }
    }
}
