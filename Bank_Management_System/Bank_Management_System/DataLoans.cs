using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System
{
    class DataLoans
    {
        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-U5R4FIQH\SQLWORK;Initial Catalog=""Bank Management System"";Integrated Security=True");
        public int loan_id { set; get; }
        public int client_id { set; get; }
        public double amount { set; get; }
        public double interest_rate { set; get; }
        public int duration { set; get; }
        public int account_id { set; get; }
       
    }
}
