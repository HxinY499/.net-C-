using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public class OracleConn
    {
        public OracleConnection conn;

        public OracleConn()
        {
            string connString = "User Id=jay;Password=jay499;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL.MICRODONE.CN)))";
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            try
            {
                conn.Open();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ~OracleConn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public OracleDataReader GetOracleDate(string commed)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = commed;
            return cmd.ExecuteReader();
        }

        public void InsertOrUpdateDate(string commed)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = conn;

            command.CommandText = commed;
            command.ExecuteNonQuery();

        }
    }    
}
