using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Baohiemyte
{
    public class DataProfile
    {
        string connect = @"Data Source = .\SQLEXPRESS;Initial Catalog = NCC; Persist Security Info=True;User ID = sa; Password=towada";
        //string connect = @"Data Source=10.120.112.215;Initial Catalog=NCC;Persist Security Info=True;User ID=sa;Password=Mtv@2020;MultipleActiveResultSets=True";
        //string connect = @"Data Source=.;Initial Catalog=NCC;Persist Security Info=True;User ID = admin; Password=12345678a@;MultipleActiveResultSets=True";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        public DataProfile()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void Connect()
        {
            conn = new SqlConnection(connect);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void Disconnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public DataTable GetDataTable(string sql)
        {
            try
            {
                Connect();
                da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Disconnect();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataSet GetDataTableJson(string sql)
        {
            try
            {
                Connect();
                da = new SqlDataAdapter(sql, conn);
                DataSet dt = new DataSet();
                da.Fill(dt);
                Disconnect();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetDataTableStore_All(string storename)
        {
            try
            {
                Connect();
                SqlCommand cmd2 = new SqlCommand(storename, conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Disconnect();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetDataTableStoreById(string storename, int id)
        {
            try
            {
                Connect();
                SqlCommand cmd1 = new SqlCommand(storename, conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@id", SqlDbType.BigInt, 10).Value = id;
                da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Disconnect();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public void ExcuteQuery(string sql)
        {
            Connect();
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Disconnect();
        }
    }
}