using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NSBMGO
{
    public partial class Reserve_Form : Form
    {

        internal int SeatPrice;
        internal int TotPrice;
        internal int selectedLabelCount;

        private List<Guna2HtmlLabel> selectedLabels = new List<Guna2HtmlLabel>();


        public Reserve_Form()
        {
            InitializeComponent();
        }
        private void Reserve_Form_Load(object sender, EventArgs e)
        {

        }


        private void updateBookingForm()
        {

        }






        public void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {

            generateReserveCards();
        }

        public void generateReserveCards()
        {





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
    }

}
