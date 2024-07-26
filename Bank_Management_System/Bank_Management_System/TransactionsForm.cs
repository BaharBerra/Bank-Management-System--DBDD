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
    public partial class TransactionsForm : UserControl
    {

        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-U5R4FIQH\SQLWORK;Initial Catalog=""Bank Management System"";Integrated Security=True");
        public TransactionsForm()
        {
            InitializeComponent();
        }

        public void TransactionDisplayData()
        { 
            DataTransactions addTD = new DataTransactions();

            dataGridView1.DataSource = addTD.dataTransactions()
;


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
