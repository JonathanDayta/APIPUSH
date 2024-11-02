using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace Dal
{
    /// <summary>
    /// Clase de data access layer para la tabla Checkinout
    /// </summary>
    public class CheckinoutDal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="checklog"></param>
        /// <returns></returns>
        public int Add(CheckinoutModel checklog)
        {
            //System.Console.WriteLine("Numero de serie: " + checklog.SN);
            //Obtiene los datos de la sucursal y compania
            DatosWdms datos = consultaDatosCheck(checklog.SN);
            //String userid = consultaUsuario(checklog.userid, datos.idCompania); //buscar

            if (datos != null)
            {
                String userid = consultaUsuario(checklog.userid, datos.idCompania);
                if (userid != null)
                {
                    int existeReg = existeRegistro(checklog, userid);
                    //System.Console.WriteLine("EXISTE >>> ("+ userid + " con time: " + checklog.checktime + "): " + existeReg);
                    if (existeReg == 0)
                    {
                        //Inserta datos del checkinout
                        string sqls = string.Format(@"INSERT INTO checkinout(userid, checktime, checktype, verifycode, SN, sensorid, WorkCode, Reserved, company_id) VALUES (@userid, @checktime, @checktype, @verifycode, @SN, @sensorid, @WorkCode, @Reserved, @company_id);");
                        SqlParameter[] parameters = {
                            new SqlParameter("@userid", userid),
                            new SqlParameter("@checktime", checklog.checktime),
                            new SqlParameter("@checktype", Tools.ValidaParametroStr(checklog.checktype)),
                            new SqlParameter("@verifycode", checklog.verifycode),
                            new SqlParameter("@SN", Tools.ValidaParametroStr(checklog.SN)),
                            new SqlParameter("@sensorid", datos.idSucursal),
                            new SqlParameter("@WorkCode", Tools.ValidaParametroStr(checklog.WorkCode)),
                            new SqlParameter("@Reserved", Tools.ValidaParametroStr(checklog.Reserved)),
                            new SqlParameter("@company_id", datos.idCompania)
                        };

                        return WdmsSqlHelper.ExecuteNonQuery(sqls, parameters);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else { 
                    return 0; 
                }
            } 
            else
            {
                throw new Exception("No existe dispositivo registrado con el numero de serie: " + checklog.SN);
            }
        }

        /// <summary>
        /// Verifica el conteo de datos insertados para evitar duplicados
        /// </summary>
        /// <param name="checklog"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        private int existeRegistro(CheckinoutModel checklog, String userid)
        {
            int data = 0;
            string sql = string.Format(@"select count(id) as count from checkinout where userid=@userid and checktime=@checktime and SN=@SN");

            SqlParameter[] parametersSql = {
                new SqlParameter("@userid", userid),
                new SqlParameter("@checktime", checklog.checktime),
                new SqlParameter("@SN", Tools.ValidaParametroStr(checklog.SN))
            };

            DataTable dt = WdmsSqlHelper.GetDataTable(sql, parametersSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                if (row["count"] != null)
                {
                    data = Tools.TryConvertToInt32(row["count"].ToString());
                }
            }

            return data;
        }

        /// <summary>
        /// Consulta los datos de la compania y la sucursal
        /// </summary>
        /// <param name="numeroSerie"></param>
        /// <returns></returns>
        private DatosWdms consultaDatosCheck(string numeroSerie)
        {
            DatosWdms datos = null;
            //Obtiene los datos de la sucursal y compania
            string searchSql = string.Format(@"select company_id as IDCOM, DeptID as IDSUC from iclock where SN = @SN");
            SqlParameter[] parametersSql = {
                new SqlParameter("@SN", numeroSerie)
            };

            DataTable dt = WdmsSqlHelper.GetDataTable(searchSql, parametersSql);
            //System.Console.WriteLine("Datos obtenidos: " + dt.Rows.Count);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                if (row["IDSUC"] != null && row["IDCOM"] != null)
                {
                    datos = new DatosWdms(row["IDSUC"].ToString(), Tools.TryConvertToInt32(row["IDCOM"].ToString()));
                }
            }

            return datos;
        }

        /// <summary>
        /// Consulta el ID del usuario dado el ID de la DB primaria
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        private string consultaUsuario(int userid, int idCompania)
        {
            string userWdms = null;
            string consultaUsr = "SELECT userid from userinfo where badgenumber like('%' + cast(@badgenumber as varchar(50))) and company_id=@idCompania";

            SqlParameter[] parametersSql = {
                new SqlParameter("@badgenumber", userid),
                new SqlParameter("@idCompania", idCompania)
            };

            DataTable dt = WdmsSqlHelper.GetDataTable(consultaUsr, parametersSql);
            //System.Console.WriteLine("Datos obtenidos: " + dt.Rows.Count);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                if (row["userid"] != null)
                {
                    userWdms = row["userid"].ToString();
                }
            }

            return userWdms;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="attTime"></param>
        /// <returns></returns>
        public bool IsExist(int userid, DateTime checktime)
        {
            string sql = string.Format(@"select count(*) from checkinout where userid=@userid and checktime=@checktime");

            SqlParameter[] parameters = {
                        new SqlParameter("@userid", userid) ,
                        new SqlParameter("@checktime", checktime)
                    };
            int count = Tools.TryConvertToInt32(WdmsSqlHelper.ExecuteScalar(sql, parameters));

            if (count <= 0)
            {
                return false;
            }
            return true;
        }
    }

    public class DatosWdms
    {
        private string _idSucursal = string.Empty;
        private int _idCompania = 0;

        public string idSucursal
        {
            get { return _idSucursal; }
            set { _idSucursal = value; }
        }

        public int idCompania
        {
            get { return _idCompania; }
            set { _idCompania = value; }
        }

        public DatosWdms(string idSuc, int idComp)
        {
            _idSucursal = idSuc;
            _idCompania = idComp;
        }
    }
}
