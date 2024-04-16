using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSBMGO.Data_access_layer
{
    internal class ClassDAL
    {

        public DataTable ReadItemsFromTable(string ResCity)
        {
            connection con1 = new connection();
            con1.conn.Open();

            string query = "SELECT * FROM Shuttle WHERE end_city = '" + ResCity + "'";

            SqlCommand cmd = new SqlCommand(query, con1.conn);

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
                MessageBox.Show("Error: "+ex);
                throw;
            }

        }
    }
}
