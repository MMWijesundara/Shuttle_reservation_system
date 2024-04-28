using NSBMGO.Class_BLL;
using System;
using System.Data;
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

            string Reservecity = guna2TextBox1.Text;

            ClassBLL objBLL = new ClassBLL();

            DataTable dt = objBLL.GetItems(Reservecity);

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
                            cards[i].Price.Text = dt.Rows[i]["ticket_price"].ToString();

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



    }
}
