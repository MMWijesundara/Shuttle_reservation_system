using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Policy;
using System.ComponentModel.Design;


namespace NSBMGO
{
    public partial class LogIn : Form
    {

        
        public SqlCommand cmd;
        public SqlDataReader reader;

        SqlConnection conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Connect Timeout=30;Encrypt=True;");



        public LogIn()
        {
            InitializeComponent();
        }


       

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        

        private void login_load(object sender, EventArgs e)
        {
            
        }

        public void btn_login(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            try
            {
                string query = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    password = txt_password.Text;

                    Operator_dashboard operator_Dashboard = new Operator_dashboard();
                    operator_Dashboard.Show();
                    operator_Dashboard.lbl_top_name.Text =("Hi,"+username+".");
                    
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid LogIn. Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();
                    txt_username.Focus();


                }
            }
            catch (Exception ex)
            {
                DialogResult res;
                res = MessageBox.Show("error: " + ex, "error", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    Application.Exit();
                }



                
            }

            finally
            {
                conn.Close();
            }
        }
    }
    }

