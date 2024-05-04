namespace NSBMGO
{
    partial class LogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_login = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.txt_password = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_password = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbl_username = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(513, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(452, 469);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbl_login);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 43);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(452, 65);
            this.panel4.TabIndex = 2;
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = false;
            this.lbl_login.BackColor = System.Drawing.Color.Transparent;
            this.lbl_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_login.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.Location = new System.Drawing.Point(0, 0);
            this.lbl_login.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(452, 65);
            this.lbl_login.TabIndex = 1;
            this.lbl_login.Text = "LOG IN";
            this.lbl_login.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.guna2ControlBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(452, 43);
            this.panel3.TabIndex = 1;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(392, 0);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(60, 43);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.guna2Button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_password, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_password, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_username, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_username, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(52, 130);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 274);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(243)))), ((int)(((byte)(183)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(4, 213);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(336, 44);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "LOG IN";
            this.guna2Button1.Click += new System.EventHandler(this.btn_login);
            // 
            // txt_password
            // 
            this.txt_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_password.DefaultText = "";
            this.txt_password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_password.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_password.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_password.ForeColor = System.Drawing.Color.Black;
            this.txt_password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_password.Location = new System.Drawing.Point(4, 146);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '●';
            this.txt_password.PlaceholderText = "••••••••";
            this.txt_password.SelectedText = "";
            this.txt_password.ShadowDecoration.BorderRadius = 5;
            this.txt_password.ShadowDecoration.Depth = 10;
            this.txt_password.Size = new System.Drawing.Size(336, 44);
            this.txt_password.TabIndex = 4;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // lbl_password
            // 
            this.lbl_password.BackColor = System.Drawing.Color.Transparent;
            this.lbl_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_password.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password.Location = new System.Drawing.Point(4, 109);
            this.lbl_password.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(336, 28);
            this.lbl_password.TabIndex = 3;
            this.lbl_password.Text = "PASSWORD:";
            // 
            // lbl_username
            // 
            this.lbl_username.BackColor = System.Drawing.Color.Transparent;
            this.lbl_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_username.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_username.Location = new System.Drawing.Point(4, 4);
            this.lbl_username.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(336, 31);
            this.lbl_username.TabIndex = 1;
            this.lbl_username.Text = "USERNAME:";
            // 
            // txt_username
            // 
            this.txt_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_username.DefaultText = "";
            this.txt_username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_username.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_username.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_username.ForeColor = System.Drawing.Color.Black;
            this.txt_username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_username.Location = new System.Drawing.Point(4, 44);
            this.txt_username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_username.Name = "txt_username";
            this.txt_username.PasswordChar = '\0';
            this.txt_username.PlaceholderText = "user";
            this.txt_username.SelectedText = "";
            this.txt_username.Size = new System.Drawing.Size(336, 44);
            this.txt_username.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::NSBMGO.Properties.Resources.NSBM_Go_logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 469);
            this.panel1.TabIndex = 1;
            // 
            // LogIn
            // 
            this.AcceptButton = this.guna2Button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 469);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LogIn";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.login_load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_password;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_password;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_username;
        public Guna.UI2.WinForms.Guna2TextBox txt_username;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_login;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}