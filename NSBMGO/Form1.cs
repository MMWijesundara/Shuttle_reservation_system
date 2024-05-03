using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
//using TheArtOfDevHtmlRenderer.Adapters;
using System.IO;
using Guna.UI2.WinForms.Suite;

namespace NSBMGO
{
    public partial class Form1 : Form
    {
        private SqlConnection con1;
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private OpenFileDialog openFileDialog1;
        private byte[] imageData;
        private string imagePath;
        DataTable table;

        public Form1()
        {
            InitializeComponent();
            con1 = new SqlConnection("Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");

            adapter = new SqlDataAdapter();
            dataSet = new DataSet();
        }


        private void bttnAdd_Click(object sender, EventArgs e)
        {
            int Date = int.Parse(txtDate.Text);
            string News = txtNews.Text;
            

            string query = "INSERT INTO [News] (Date,News) VALUES (@Date, @News)";

            SqlCommand cmd = new SqlCommand(query, con1);

            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@News", News);

            try
            {
                con1.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved");

                adapter.SelectCommand = new SqlCommand("SELECT * FROM [News]", con1);
                dataSet.Clear();
                adapter.Fill(dataSet, "News");
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con1.Close();
            }
        }

        
    }
}
