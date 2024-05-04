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
        // Event handler for clicking the labels
        private void Label_Click(object sender, EventArgs e)
        {
            {
                Guna2HtmlLabel lbl = sender as Guna2HtmlLabel;
                if (lbl.BackColor == Color.White)
                {
                    lbl.BackColor = ColorTranslator.FromHtml("#1151f2"); // Change color to blue when clicked
                    selectedLabels.Add(lbl); // Add the clicked label to the list of selected labels
                }
                else if (lbl.BackColor == ColorTranslator.FromHtml("#1151f2"))
                {
                    lbl.BackColor = Color.White; // Change color back to default when unclicked
                    selectedLabels.Remove(lbl); // Remove the unclicked label from the list of selected labels
                }

                // Update the total selected seats count
                UpdateSelectedSeatsCount();
            }
        }

        // Update the total selected seats count
        private void UpdateSelectedSeatsCount()
        {
            // Update the textbox with the total count of selected seats
            txtTotalSeats.Text = selectedLabels.Count.ToString();
        }

        // Event handler for clicking the "Add Seats" button
        private void btnAddSeats_Click(object sender, EventArgs e)
        {
            // Clear the textbox before updating
            txtTotalSeats.Text = "";

            // Change color to red for selected labels
            foreach (Guna2HtmlLabel lbl in selectedLabels)
            {
                lbl.BackColor = ColorTranslator.FromHtml("#ed0933");
            }
        }
    }

}
