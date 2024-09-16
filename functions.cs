using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainMangementSystem
{
    internal class functions
    {
        private SqlConnection Con;
        private SqlDataAdapter SqlDataAdapter;
        private DataTable DataTable;
        private SqlCommand sqlCommand;
        private string ConnectionStr;

        public void Connection()
        {
            ConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\TrainTicketingSystem.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConnectionStr);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = Con;
        }

        public DataTable GetData(string Query)
        {
            try
            {
                DataTable = new DataTable();
                SqlDataAdapter = new SqlDataAdapter(Query, ConnectionStr);
                SqlDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch(Exception error)
            {
                throw new Exception("An error occurred while fetching data: " + error.Message);
            }
        }

        public int setData(string Query)
        {
            int Cnt = 0;

            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            sqlCommand.CommandText = Query;

            Cnt = sqlCommand.ExecuteNonQuery();

            Con.Close();

            return Cnt;

        }
    }
}
