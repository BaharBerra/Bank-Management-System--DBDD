using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Bank_Management_System
{
    public partial class LoginForm : Form
    {
        SqlConnection connect= new SqlConnection(@"Data Source=LAPTOP-U5R4FIQH\SQLWORK;Initial Catalog=""Bank Management System"";Integrated Security=True");
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (accountno.Text == "" || pin.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    connect.Open();
                   



                    String selectData = "SELECT * FROM Accounts WHERE account_id  = @account_id AND Pin = @Pin";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@account_id", accountno.Text.Trim());
                        cmd.Parameters.AddWithValue("@Pin", pin.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);


                        if (table.Rows.Count >= 1)
                        {
                            MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MainForm mForm = new MainForm();
                            mForm.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Incorrect AccountNo/Pin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close();
                }


            }
        }
        private void showPin_CheckedChanged(object sender, EventArgs e)
        {
            pin.PasswordChar = showPin.Checked ? '\0' : '*';
        }
    }
}
