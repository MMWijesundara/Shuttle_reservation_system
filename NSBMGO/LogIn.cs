using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace NSBMGO
{
    public partial class LogIn : Form
    {





        SqlConnection conn = new SqlConnection(@"Data Source=nsbmgo.database.windows.net;Initial Catalog=NSBMGO;User ID=nsbmgo;Password=admin@123;Encrypt=True;");



        public LogIn()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
          (
        int nLeftRect,     // x-coordinate of upper-left corner
        int nTopRect,      // y-coordinate of upper-left corner
        int nRightRect,    // x-coordinate of lower-right corner
        int nBottomRect,   // y-coordinate of lower-right corner
        int nWidthEllipse, // width of ellipse
        int nHeightEllipse // height of ellipse
             );




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

                if (txt_username.Text.Length == 0)
                {
                    if (MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        txt_username.Focus();

                    }
                }

                if (txt_password.Text.Length == 0)
                {
                    if (MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        txt_username.Focus();

                    }
                }


                else if (dt.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    password = txt_password.Text;

                    string role = dt.Rows[0]["role"].ToString();

                    switch (role)
                    {
                        case "operator":
                            this.Hide();
                            Operator_dashboard operator_Dashboard = new Operator_dashboard();
                            operator_Dashboard.Show();
                            operator_Dashboard.lbl_top_name.Text = ("Hi," + username + ".");
                            operator_Dashboard.btn_shuttle.Hide();
                            operator_Dashboard.btn_driver.Hide();

                            break;

                        case "admin":
                            this.Hide();
                            Operator_dashboard admin_Dashboard = new Operator_dashboard();
                            admin_Dashboard.Show();
                            admin_Dashboard.lbl_top_name.Text = ("Hi," + username + ".");
                           
                            break;
                    }




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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

