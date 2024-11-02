using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Model;

namespace Dal
{
    /// <summary>WdmsSqlHelper
    /// </summary>
    public sealed class WdmsSqlHelper
    {
        static string connString;

        static WdmsSqlHelper()
        {
            connString = ConnectionDb.CONN_STR_WDMS_ISS_PRUEBAS;
        }

        /// <summary> Execute Sql
        /// </summary>        
        /// <param name="cmdText"></param> 
        /// <param name="parameters"></param> 
        /// <returns></returns> 
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] parameters)
        {
            //string connString = ConnString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                int val = 0;
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        AuxiliarCommandSql.PrepareCommand(cmd, conn, null, cmdText, parameters);
                        val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("ERROR ExecuteNonQuery (Message): " + e.Message);
                        System.Console.WriteLine("ERROR ExecuteNonQuery: " + e.StackTrace);
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    } 
                }
                return val;
            }
        }

        /// <summary> Get first row first column data
        /// </summary> 
        /// <param name="cmdText"></param> 
        /// <returns></returns> 
        public static object ExecuteScalar(string cmdText, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                object val;
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        AuxiliarCommandSql.PrepareCommand(cmd, conn, null, cmdText, parameters);
                        val = cmd.ExecuteScalar();
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("ERROR ExecuteScalar: " + e.StackTrace);
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                return val;
            }
        }

        /// <summary>Get DataTable By SQL
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable(string cmdText, params SqlParameter[] parameters)
        {
            DataSet ds = GetDataSet(connString, cmdText, parameters);
            if (ds == null || ds.Tables.Count == 0)
                return null;
            return ds.Tables[0];
        }

        public static List<ZonaClienteModel> GetAllClientes()
        {
            List<ZonaClienteModel> retorno = new List<ZonaClienteModel>();
            
            ZonaClienteModel zonaClienteBase = new ZonaClienteModel()
            {
                idZonaCliente = 0,
                nomCliente = "Select a client/zone"
            };
            retorno.Add(zonaClienteBase);
            
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand("Select idZonaCliente, nomCliente from catZonaCliente", conn))
                    {
                        com.CommandType = System.Data.CommandType.Text;
                        using (SqlDataReader sqlDataReader = com.ExecuteReader())
                        {
                            if (sqlDataReader.HasRows)
                            {
                                while (sqlDataReader.Read())
                                {
                                    ZonaClienteModel zonaCliente = new ZonaClienteModel()
                                    {
                                        idZonaCliente = sqlDataReader.GetInt32(0),
                                        nomCliente = sqlDataReader.GetString(1)
                                    };
                                    retorno.Add(zonaCliente);
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("No rows found.");
                            }
                        }
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("ERROR(E) GetDataSet: " + e.StackTrace);
                    throw new Exception(e.Message);
                }
            }
            return retorno;
        }

        public static List<DeptoSucursalModel> GetAllDeptoSucursalByClient(int idClient)
        {
            List<DeptoSucursalModel> retorno = new List<DeptoSucursalModel>();
   
            if (idClient == 0)
            {
                DeptoSucursalModel deptoSucursalBase = new DeptoSucursalModel()
                {
                    idDeptoSucursal = 0,
                    nomSucursal = "Select a department"
                };
                retorno.Add(deptoSucursalBase);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand com = new SqlCommand("Select idDeptoSucursal, nomSucursal from catDeptoSucursal where idCliente=" + idClient, conn))
                        {
                            com.CommandType = System.Data.CommandType.Text;
                            using (SqlDataReader sqlDataReader = com.ExecuteReader())
                            {
                                if (sqlDataReader.HasRows)
                                {
                                    while (sqlDataReader.Read())
                                    {
                                        DeptoSucursalModel depto = new DeptoSucursalModel()
                                        {
                                            idDeptoSucursal = sqlDataReader.GetInt32(0),
                                            nomSucursal = sqlDataReader.GetString(1)
                                        };
                                        retorno.Add(depto);
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("No rows found.");
                                }
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("ERROR(E) GetDataSet: " + e.StackTrace);
                        throw new Exception(e.Message);
                    }
                }
            }
            return retorno;
        }

        public static List<TblEmpleadoModel> GetEmpleadosBySite(string site)
        {
            List<TblEmpleadoModel> retorno = new List<TblEmpleadoModel>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand("SELECT numEmpleado, nombre, site, desDepto from tblEmpleados where status='A' and site='" + site + "'", conn))
                    {
                        com.CommandType = System.Data.CommandType.Text;
                        using (SqlDataReader sqlDataReader = com.ExecuteReader())
                        {
                            if (sqlDataReader.HasRows)
                            {
                                while (sqlDataReader.Read())
                                {
                                    TblEmpleadoModel empl = new TblEmpleadoModel()
                                    {
                                        numEmpleado = sqlDataReader.GetInt64(0),
                                        nombre = sqlDataReader.GetString(1),
                                        site = sqlDataReader.GetString(2),
                                        desDepto = sqlDataReader.GetString(3)
                                    };
                                    retorno.Add(empl);
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("No rows found.");
                            }
                        }
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("ERROR(E) GetEmpleadosBySite: " + e.StackTrace);
                    throw new Exception(e.Message);
                }
            }
            return retorno;
        }

        private static DataSet GetDataSet(string connString, string cmdText, params SqlParameter[] parameters)
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
    }
}