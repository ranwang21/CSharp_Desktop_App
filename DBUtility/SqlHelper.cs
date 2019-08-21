using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DBUtility
{
    public static class SqlHelper
    {
        /// <summary>
        /// DB Helper to manage CRUD operations
        /// </summary>

        // connection string
        private static string connStrting = ConfigurationManager.ConnectionStrings["connString_Marco"].ToString();

        // *************** UPDATE *********************************
        public static int Update(string sql)
        {
            // instantialize connection
            SqlConnection conn = new SqlConnection(connStrting);

            // instantialize command
            SqlCommand cmd = new SqlCommand(sql, conn);

            // execute
            try
            {
                // open connection
                conn.Open();

                // execute cmd
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // throw exception to UI
                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }

        // *************** RETURN A SINGLE RESULT (Object) *********************************
        public static object GetOneResult(string sql)
        {
            // instantialize connection
            SqlConnection conn = new SqlConnection(connStrting);

            // instantialize command
            SqlCommand cmd = new SqlCommand(sql, conn);

            // execute
            try
            {
                // open connection
                conn.Open();

                // execute cmd
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // throw exception to UI
                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }
        }

        // *************** RETURN MULTIPLE RESULTS (DataReader) *********************************
        public static SqlDataReader GetReader(string sql)
        {
            // instantialize connection
            SqlConnection conn = new SqlConnection(connStrting);

            // instantialize command
            SqlCommand cmd = new SqlCommand(sql, conn);

            // execute
            try
            {
                // open connection
                conn.Open();

                

                // execute cmd
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                // throw exception to UI
                throw ex;
            }

        }


    }
}