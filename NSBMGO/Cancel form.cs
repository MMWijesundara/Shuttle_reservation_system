using NSBMGO.Data_access_layer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            try
            {
                using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
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

        private void txtSearch_IconRightClick(object sender, EventArgs e)
        {
            DataTable dt1 = generateTickets(txtSearch.Text);

            for(int i = 0; i < dt1.Rows.Count; i++)
            {
                Cancel_card ticket = new Cancel_card();
                ticket[i]
            }

        }


    }
}
