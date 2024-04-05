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


namespace NSBMGO
{
    public partial class LogIn : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=********;Connect Timeout=30;Application Intent=ReadWrite;Multi Subnet Failover=False");
        


        public LogIn()
        {
            InitializeComponent();
        }


       

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //con.Open();
            
            //SqlCommand cmd = new SqlCommand("select username,password from users where username '"+txt_username.Text+"' and password '"+txt_password.Text+"'");

            //SqlParameter usernameParam;
            //usernameParam = new SqlParameter("@username", this.txt_username.Text.Trim());

            //SqlParameter passwordParam;
            //passwordParam = new SqlParameter("@password", this.txt_password.Text.Trim());

            

            //cmd.Parameters.Add(usernameParam);  
            //cmd.Parameters.Add(passwordParam);

            

            //SqlDataReader dr = cmd.ExecuteReader(); 

            if (txt_username.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please fill username","Warning",MessageBoxButtons.OK);
            }

            if (txt_password.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please fill password", "Warning", MessageBoxButtons.OK);
            }

            //else if (dr.HasRows)
            //{
            //    MessageBox.Show("Login success");
            //}

            else
            {
                MessageBox.Show("Log In success!");
                this.Hide();
                
                Operator_dashboard operator_Dashboard = new Operator_dashboard();
                operator_Dashboard.ShowDialog();
            }

            //con.Close();


            

            
        }
    }
}
