using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NSBMGO
{
    public partial class Cancel_card : UserControl
    {
        public Cancel_card()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            deleteTicket();
        }

        private void deleteTicket()
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Encrypt=True;");
            string query = "DELETE FROM [Ticket] WHERE studentId = @stuId";

            //Cancel_form form = new Cancel_form();
            
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@stuId",lblstuId.Text);

            try
            {
                conn.Open();
                int rowsAff = cmd.ExecuteNonQuery();
                
                MessageBox.Show($"Deletion succesfull. {rowsAff} rows affected. ");
                conn.Close();

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
