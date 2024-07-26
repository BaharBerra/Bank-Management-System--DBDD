using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Bank_Management_System
{
    class DataTransactions
    {

        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-U5R4FIQH\SQLWORK;Initial Catalog=""Bank Management System"";Integrated Security=True");
        public int TransactionID { set; get; }
        public int AccountId { set; get; }
        public double Amount { set; get; }
        public string TransactionType { set; get; }
        public int DateTime { set; get; }

        public List<DataTransactions> dataTransactions()
        {
            List<DataTransactions> listData = new List<DataTransactions>();
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string sql = "SELECT * FROM Transactions WHERE date_time IS NULL";

                    using (SqlCommand cmd = new SqlCommand(sql, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DataTransactions addTD = new DataTransactions();
                            addTD.TransactionID = (int)reader["transaction_id"];
                            addTD.AccountId = (int)reader["account_id"];
                            addTD.Amount = (int)reader["amount"];
                            addTD.TransactionType = reader["transaction_type"].ToString();
                            addTD.DateTime = (int)reader["date_time"];


                            listData.Add(addTD);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting Database: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;

        }
    }
}