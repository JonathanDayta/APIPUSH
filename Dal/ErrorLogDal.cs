using Model;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    /// <summary>
    /// 设备异常日志
    /// </summary>
    public class ErrorLogDal
    {
        /// <summary>add a record
        /// </summary>
        public int Add(ErrorLogModel model)
        {
            string sql = string.Format(@"insert into ErrorLog(ErrorCode,ErrMsg,DataOrigin,CmdId,Additional,DeviceID
    ) values (@ErrorCode,@ErrMsg,@DataOrigin,@CmdId,@Additional,@DeviceID);");

            SqlParameter[] parameters = {
                        new SqlParameter("@ErrorCode",  model.ErrCode) ,
                        new SqlParameter("@ErrMsg", model.ErrMsg) ,
                        new SqlParameter("@DataOrigin", model.DataOrigin),
                        new SqlParameter("@CmdId",  model.CmdId) ,
                        new SqlParameter("@Additional", model.Additional) ,
                        new SqlParameter("@DeviceID",  model.DeviceID)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// get record
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public DataTable GetAll(string devSN)
        {
            string whereDevSN = (string.IsNullOrEmpty(devSN)) ? "" : " where DeviceID=@DevSN";

            string sql = string.Format(@"select * from Errorlog {0} order by id desc", whereDevSN);

            SqlParameter[] SqlParameters = {
                new SqlParameter("@DevSN",devSN)
            };
            return SqliteHelper.GetDataTable(sql.ToString(), SqlParameters);
        }

        /// <summary>delete all record
        /// </summary>
        public int ClearAll()
        {
            string sql = "delete from ErrorLog";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
