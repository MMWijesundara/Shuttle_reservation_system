using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NSBMGO.Data_access_layer
{
    internal class ClassDAL
    {

        public DataTable ReadItemsFromTableShuttle(string startCity, string endCity)
        {
            connection con1 = new connection();
            con1.conn.Open();

            string query = "SELECT * FROM Shuttle WHERE start_city = '" + startCity + "' AND end_city = '" + endCity + "'";

            SqlCommand cmd = new SqlCommand(query, con1.conn);

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

        public DataTable ReadItemsFromTableTicket(int studentId)
        {
            connection con1 = new connection();
            con1.conn.Open();

            string query = "SELECT * FROM Ticket WHERE studentId = '" + studentId + "'";

            SqlCommand cmd = new SqlCommand(query, con1.conn);

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
    }
}
