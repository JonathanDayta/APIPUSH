using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model.DTO;
using Utils;

namespace Dal
{
    /// <summary>SqliteHelper
    /// </summary>
    public sealed class SqliteHelper
    {
        /// <summary>Database Connection String
        /// </summary> 
        static string connString;

        static SqliteHelper ()
        {
            connString = ConnectionDb.CONN_STR_TEST;
        }

        /// <summary> Execute Sql
        /// </summary> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(connString, cmdText);
        }

        /// <summary> Execute Sql By Transaction
        /// </summary> 
        /// <param name="trans"></param> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        /*
        public static int ExecuteNonQuery(SqlTransaction trans, string cmdText, params SqlParameter[] parameters)
        {
            int val = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                AuxiliarCommandSql.PrepareCommand(cmd, (SqlConnection)trans.Connection, trans, cmdText, parameters);
                val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            return val;
        }
        */

        /// <summary> Execute Sql
        /// </summary>        
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery( string cmdText, params SqlParameter[] parameters)
        {
            //string connString = connString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                return ExecuteNonQuery(conn, cmdText, parameters);
            }
        }

        /// <summary> Execute Sql
        /// </summary> 
        /// <param name="connString"></param> 
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery(string connString, string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                return ExecuteNonQuery(conn, cmdText, parameters);
            }
        }

        /// <summary> Execute Sql
        /// </summary> 
        /// <param name="connection"></param> 
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery(SqlConnection connection, string cmdText, params SqlParameter[] parameters)
        {
            int val = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    AuxiliarCommandSql.PrepareCommand(cmd, connection, null, cmdText, parameters);
                    val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("ERROR ExecuteNonQuery (MSG): " + e.Message);
                    System.Console.WriteLine("ERROR ExecuteNonQuery: " + e.StackTrace);
                    throw;
                }
            }
            return val;
        }

        /// <summary> Get first row first column data
        /// </summary> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(connString, cmdText, null);
        }

        /// <summary> Get first row first column data
        /// </summary> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static object ExecuteScalar(string cmdText, SqlParameter[] parameters)
        {
            return ExecuteScalar(connString, cmdText, parameters);
        }

        /// <summary> Get first row first column data
        /// </summary> 
        /// <param name="connString"></param> 
        /// <param name="cmdText"> </param> 
        /// <returns></returns> 
        public static object ExecuteScalar(string connString, string cmdText, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                return ExecuteScalar(conn, cmdText, parameters);
            }
        }

        /// <summary> Get first row first column data
        /// </summary> 
        /// <param name="connection"></param> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static object ExecuteScalar(SqlConnection connection, string cmdText, SqlParameter[] parameters)
        {
            object val;
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    AuxiliarCommandSql.PrepareCommand(cmd, connection, null, cmdText, parameters);
                    val = cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("ERROR ExecuteScalar: " + e.StackTrace);
                    throw;
                }
            }
            return val;
        }

        /// <summary>Get data by DataReader 
        /// </summary> 
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        //public static SqlDataReader ExecuteReader(string cmdText)
        //{
        //    return ExecuteReader(connString, cmdText, null);
        //}
        /// <summary>Get data by DataReader 
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
       //public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] parameters)
        //{
         //   return ExecuteReader(connString, cmdText, parameters);
        //}

        /// <summary>Get data by DataReader 
        /// </summary> 
        /// <param name="connString"></param> 
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns>
        /*
        public static SqlDataReader ExecuteReader(string connString, string cmdText, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                AuxiliarCommandSql.PrepareCommand(cmd, conn, null, cmdText, parameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception e)
            {
                System.Console.WriteLine("ERROR ExecuteReader: " + e.StackTrace);
                conn.Close();
                throw;
            }
        }
        */

        /// <summary>Transaction
        /// </summary>
        /// <param name="listSql"></param>
        public static void ExecuteManySql(List<string> listSql)
        {
            List<ManySql> manySqls = new List<ManySql>();
            foreach (string sql in listSql)
            {
                manySqls.Add(new ManySql(sql, null));
            }

            ExecuteManySql(manySqls);
        }

        /// <summary>Transaction
        /// </summary>
        /// <param name="SQLStringList"></param>
        public static void ExecuteManySql(List<ManySql> SqlStringList)
        {
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cnn.Open();
                    using (SqlTransaction trans = cnn.BeginTransaction())
                    {
                        try
                        {
                            string sSql = string.Empty;
                            SqlParameter[] cmdParms = null;
                            foreach (ManySql ms in SqlStringList)
                            {
                                sSql = ms.Sql;
                                cmdParms = ms.Paras;
                                AuxiliarCommandSql.PrepareCommand(cmd, cnn, trans, sSql, (SqlParameter[])cmdParms);
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine("ERROR ExecuteManySql: " + ex.StackTrace);
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
        /// <summary>Get DataTable By SQL
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string cmdText)
        {
            DataSet ds = GetDataSet(cmdText);
            if (ds == null || ds.Tables.Count == 0)
                return null;
            return ds.Tables[0];
        }
        /// <summary>Get DataTable By SQL
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string cmdText, params SqlParameter[] parameters)
        {
            DataSet ds = GetDataSet(cmdText, parameters);
            if (ds == null || ds.Tables.Count == 0)
                return null;
            return ds.Tables[0];
        }
        /// <summary>Get DataSet By SQL
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string cmdText)
        {
            return GetDataSet(connString, cmdText, null);
        }

        /// <summary>Get DataSet By SQL
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string cmdText, params SqlParameter[] parameters)
        {
            return GetDataSet(connString, cmdText, parameters);
        }
        /// <summary>Get DataSet By SQL
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string connString, string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        conn.Open();
                        try
                        {
                            AuxiliarCommandSql.PrepareCommand(cmd, conn, null, cmdText, parameters);
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                da.Fill(ds, "ds");
                                cmd.Parameters.Clear();
                                return ds;
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine("ERROR GetDataSet: " + ex.StackTrace);
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("ERROR(E) GetDataSet: " + e.StackTrace);
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Carga masiva para la alta de usuarios
        /// </summary>
        /// <param name="lstUsuariosCarga">Lista de carga de usuarios</param>
        /// <returns>Resultado de la ejecucion de la lista</returns>
        public static int AddUsers(List<UsuarioCargaDto> lstUsuariosCarga)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_INSERT_USER", conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            try
                            {
                                cmd.Transaction = trans;
                                foreach (UsuarioCargaDto ucd in lstUsuariosCarga)
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@PIN", System.Data.SqlDbType.NVarChar).Value = ucd.PIN;
                                    cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.NVarChar).Value = ucd.Nombre;
                                    cmd.Parameters.Add("@SN", System.Data.SqlDbType.NVarChar).Value = ucd.SerialNumber;
                                    cmd.Parameters.Add("@PWD", System.Data.SqlDbType.NVarChar).Value = "";
                                    cmd.Parameters.Add("@USRTYPE", System.Data.SqlDbType.NVarChar).Value = "";
                                    cmd.CommandTimeout = 18000;
                                    result = cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                                trans.Commit();
                            }
                            catch (Exception ex)
                            {
                                System.Console.WriteLine("ERROR AddUsers: " + ex.StackTrace);
                                trans.Rollback();
                                throw new Exception(ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("ERROR AddUsers: " + ex.StackTrace);
                        throw new Exception(ex.Message);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Carga masiva para la baja de usuarios
        /// </summary>
        /// <param name="lstUsuariosCarga">Lista de carga de usuarios</param>
        /// <returns>Resultado de la ejecucion de la lista</returns>
        public static int DeleteUsers(List<UsuarioCargaDto> lstUsuariosCarga)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DELETE_USER", conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            try
                            {
                                cmd.Transaction = trans;
                                foreach (UsuarioCargaDto ucd in lstUsuariosCarga)
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@SN", System.Data.SqlDbType.NVarChar).Value = ucd.SerialNumber;
                                    cmd.Parameters.Add("@PIN", System.Data.SqlDbType.NVarChar).Value = ucd.PIN;
                                    cmd.CommandTimeout = 18000;
                                    result = cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                                trans.Commit();
                            }
                            catch (Exception ex)
                            {
                                System.Console.WriteLine("ERROR DeleteUsers: " + ex.StackTrace);
                                trans.Rollback();
                                throw new Exception(ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("ERROR DeleteUsers: " + ex.StackTrace);
                        throw new Exception(ex.Message);
                    }
                }
            }
            return result;
        }

    }

    /// <summary>Transaction SQL
    /// </summary>
    public class ManySql
    {
        private string _sql = string.Empty;
        private SqlParameter[] _paras = null;

        public string Sql
        {
            get { return _sql; }
            set { _sql = value; }
        }

        public SqlParameter[] Paras
        {
            get { return _paras; }
            set { _paras = value; }
        }

        public ManySql(string sql, SqlParameter[] paras)
        {
            _sql = sql;
            _paras = paras;
        }
    }
}