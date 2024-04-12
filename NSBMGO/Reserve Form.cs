using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSBMGO
{
    public partial class Reserve_Form : Form
    {
        public Reserve_Form()
        {
            InitializeComponent();
        }

        

        private void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {
            // Check if there are any empty cells in the table layout panel
            if (IsTableLayoutPanelEmpty(tableLayoutPanel3))
            {
                // Start adding cards until all cells are filled

                for (int rowIndex = 0; rowIndex < tableLayoutPanel3.RowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < tableLayoutPanel3.ColumnCount; columnIndex++)
                    {
                        // Check if the current cell is empty
                        if (CanAddCardToTableLayoutPanel(tableLayoutPanel3, rowIndex, columnIndex))
                        {
                            // Create a new reserve_card instance
                            reserve_card card = new reserve_card();
                            card.Anchor = AnchorStyles.None; // Optional: Set anchoring as needed

                            // Add the card to the current cell
                            tableLayoutPanel3.Controls.Add(card, columnIndex, rowIndex); // Swap order
                        }
                    }
                }
            }
            else
            {
                // Handle the case where the table layout panel is already full
                MessageBox.Show("The table layout panel is already full.");
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
