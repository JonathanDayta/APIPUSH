using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    public sealed class AuxiliarCommandSql
    {
        /// <summary> PrepareCommand
        /// </summary> 
        /// <param name="cmd">Command</param> 
        /// <param name="conn">Connection</param> 
        /// <param name="trans">Transaction</param> 
        /// <param name="cmdText">SQL Text</param> 
        /// <param name="parameters">Parameter</param> 
        public static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, params SqlParameter[] parameters)
        {
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (SqlException se)
                {
                    System.Console.WriteLine("ERROR al conectarse a la DB con URL: " + conn.DataSource);
                    System.Console.WriteLine("ERROR - stack: " + se.StackTrace);
                    throw new Exception("Error al conectarse a la DB con URL: " + conn.DataSource);
                }
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            System.Console.WriteLine("cmdText :" + cmdText);
            cmd.Parameters.Clear();
            if (null != parameters && parameters.Length > 0)
            {
                for (int i = 0; i < parameters.Length; i++)
                    System.Console.WriteLine("Parametro: [" + parameters[i].ParameterName + "], valor: [" + parameters[i].Value + "]");
                cmd.Parameters.AddRange(parameters);
            }
        }
    }
}
