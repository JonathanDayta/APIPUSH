using Model;
using System;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using Utils;

namespace Dal
{
    /// <summary>
    /// Registro de asistencia
    /// </summary>
    public class AttLogDal
    {
        /// <summary>
        /// Obtener registros de asistencia
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="userID"></param>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public DataTable GetByTime(DateTime startTime, DateTime endTime, string userID, string devSN)
        {
            string wherePin = (string.IsNullOrEmpty(userID)) ? "" : " and a.PIN=@PIN";
            string whereDevSN = (string.IsNullOrEmpty(devSN)) ? "" : " and DeviceID=@DevSN";

            string sql = string.Format(@"select a.*,w.workname from AttLog a left join WorkCode w on a.workcode = w.workcode where a.PIN <> '' and a.AttTime>@AttTime1 and a.AttTime<@AttTime2 {0} {1} order by a.AttTime desc", wherePin, whereDevSN);

            SqlParameter[] parameters = {
                 new SqlParameter("@AttTime1", startTime),
                 new SqlParameter("@AttTime2", endTime),
                 new SqlParameter("@PIN", userID),
                 new SqlParameter("@DevSN", devSN)
            };
            return SqliteHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Obtener registros de asistencia
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string sql = "select * from AttLog order by AttTime desc";
            return SqliteHelper.GetDataTable(sql);
        }
        /// <summary>
        /// Borrar registros de asistencia
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from AttLog";
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Agregar registros de asistencia
        /// </summary>
        /// <param name="attlog"></param>
        /// <returns></returns>
        public int Add(AttLogModel attlog)
        {
            string sql = string.Format(@"insert into AttLog(PIN,AttTime,Status,Verify,WorkCode,Reserved1,Reserved2,MaskFlag,Temperature,DeviceID) values (@PIN,@AttTime,@Status,@Verify,@WorkCode,@Reserved1,@Reserved2,@MaskFlag,@Temperature,@DeviceID);");

            SqlParameter[] parameters = {
                        new SqlParameter("@PIN", Tools.ValidaParametroStr(attlog.PIN)),
                        new SqlParameter("@AttTime", attlog.AttTime),
                        new SqlParameter("@Status", Tools.ValidaParametroStr(attlog.Status)),
                        new SqlParameter("@Verify", Tools.ValidaParametroStr(attlog.Verify)),
                        new SqlParameter("@WorkCode", Tools.ValidaParametroStr(attlog.WorkCode)),
                        new SqlParameter("@Reserved1", Tools.ValidaParametroStr(attlog.Reserved1)),
                        new SqlParameter("@Reserved2", Tools.ValidaParametroStr(attlog.Reserved2)),
                        new SqlParameter("@MaskFlag", attlog.MaskFlag),
                        new SqlParameter("@Temperature", Tools.ValidaParametroStr(attlog.Temperature)), 
                        new SqlParameter("@DeviceID", Tools.ValidaParametroStr(attlog.DeviceID))
                    };

            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// Revisa la existencia de un registro
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="attTime"></param>
        /// <returns></returns>
        public bool IsExist(string pin, DateTime attTime)
        {
            string sql = string.Format(@"select count(*) from AttLog where pin=@PIN and attTime=@AttTime");

            SqlParameter[] parameters = {
                        new SqlParameter("@PIN", pin) ,
                        new SqlParameter("@AttTime", attTime)
                    };
            int count = Tools.TryConvertToInt32(SqliteHelper.ExecuteScalar(sql, parameters));

            if (count <= 0)
                return false;

            return true;
        }
    }
}
