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

namespace Bank_Management_System
{
    
    public partial class MainForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-U5R4FIQH\SQLWORK;Initial Catalog=""Bank Management System"";Integrated Security=True");
        SqlCommand command;
        SqlDataAdapter da;

        public MainForm()
        {
            InitializeComponent();
        }
        void IDGetir()
        {
            SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-U5R4FIQH\SQLWORK;Initial Catalog=""Bank Management System"";Integrated Security=True");
             connect.Open();
            da = new SqlDataAdapter("SELECT * FROM Loans", connect);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            connect.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }

        private SqlConnection GetConnect()
        {
            return connect;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO Loans(loan_id,account_id,client_id,amount,interest_rate,duration) VALUES (@loan_id,@account_id,@client_id,@amount,@interest_rate,@duration)";
            command= new SqlCommand(sorgu,connect);
            command.Parameters.AddWithValue("@loan_id", int.Parse(loanID.Text));
            command.Parameters.AddWithValue("@account_id", int.Parse(accountID.Text));
            command.Parameters.AddWithValue("@client_id", int.Parse(clientID.Text));
            command.Parameters.AddWithValue("@amount", decimal.Parse(amount.Text));
            command.Parameters.AddWithValue("@interest_rate", decimal.Parse(rate.Text));
            command.Parameters.AddWithValue("@duration", int.Parse(duration.Text));
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            IDGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IDGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            loanID.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            clientID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            accountID.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            amount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            rate.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            duration.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Loans WHERE loan_id=@loan_id";
            command = new SqlCommand(sorgu,connect);
            command.Parameters.AddWithValue("@loan_id", int.Parse(loanID.Text));
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            IDGetir();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Loans SET account_id=@account_id,client_id=@client_id,amount=@amount,interest_rate=@interest_rate,duration=@duration WHERE loan_id=@loan_id";
            command=new SqlCommand(sorgu,connect);
            command.Parameters.AddWithValue("@loan_id", int.Parse(loanID.Text));
            command.Parameters.AddWithValue("@account_id", int.Parse(accountID.Text));
            command.Parameters.AddWithValue("@client_id", int.Parse(clientID.Text));
            command.Parameters.AddWithValue("@amount", decimal.Parse(amount.Text));
            command.Parameters.AddWithValue("@interest_rate", decimal.Parse(rate.Text));
            command.Parameters.AddWithValue("@duration", int.Parse(duration.Text));
            connect.Open() ;
            command.ExecuteNonQuery();
            connect.Close();
            IDGetir();
        }
    }
}
