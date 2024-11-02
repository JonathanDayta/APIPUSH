using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace Dal
{
    /// <summary>
    /// 设备操作日志
    /// </summary>
    public class OpLogDal
    {
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <returns></returns>
        public List<OpLogModel> Get()
        {            
            List<OpLogModel> Oplogs = new List<OpLogModel>();
            DataTable dt = GetAll();
            if (dt == null)
                return Oplogs;

            foreach (DataRow row in dt.Rows)
            {
                OpLogModel oplog = new OpLogModel();
                oplog.ID = Tools.TryConvertToInt32( row["ID"]);
                oplog.User = row["User"].ToString();
                oplog.Operator = row["Operator"].ToString();
                oplog.DeviceID = row["DeviceID"].ToString();
                oplog.OpTime = Convert.ToDateTime(row["OpTime"].ToString());
                oplog.OpType = row["OpType"].ToString();
                oplog.Obj1 = row["Obj1"].ToString();
                oplog.Obj2 = row["Obj2"].ToString();
                oplog.Obj3 = row["Obj3"].ToString();
                oplog.Obj4 = row["Obj4"].ToString();

                Oplogs.Add(oplog);
            }

            return Oplogs;
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string sql = string.Format(@"select * from OpLog order by OpTime desc");

            return SqliteHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="devsn"></param>
        /// <returns></returns>
        public DataTable GetOplogByTime(DateTime starttime, DateTime endtime, string devSN)
        {
            string whereDevSN = (string.IsNullOrEmpty(devSN)) ? "" : " and DeviceID=@DevSN";

            string sql = string.Format(@"select * from OpLog where OpTime>@OpTime1 and OpTime<@OpTime2 {0}  order by OpTime desc", whereDevSN);

            SqlParameter[] parameters = {
                new SqlParameter("@OpTime1", starttime),
                new SqlParameter("@OpTime2", endtime),
                new SqlParameter("@DevSN", devSN)
            };
            return SqliteHelper.GetDataTable(sql, parameters);
        }
        /// <summary>
        /// 清空记录
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from OpLog";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="oplog"></param>
        /// <returns></returns>
        public int Add(OpLogModel oplog)
        {
            string sql = string.Format(@"insert into OpLog(Operator,OpTime,OpType,[User],Obj1,Obj2,Obj3,Obj4,DeviceID) values (@Operator,@OpTime,@OpType,@User,@Obj1,@Obj2,@Obj3,@Obj4,@DeviceID);");

            SqlParameter[] parameters = {
                        new SqlParameter("@Operator", oplog.Operator) ,
                        new SqlParameter("@OpTime", oplog.OpTime) ,
                        new SqlParameter("@OpType", oplog.OpType) ,
                        new SqlParameter("@User",oplog.User) ,
                        new SqlParameter("@Obj1", oplog.Obj1) ,
                        new SqlParameter("@Obj2", oplog.Obj2) ,
                        new SqlParameter("@Obj3", oplog.Obj3) ,
                        new SqlParameter("@Obj4", oplog.Obj4),
                        new SqlParameter("@DeviceID", oplog.DeviceID)
                    };
            if (oplog.OpType == "30")
            {
                //enrolamiento de usuario
                save_assignmentUsr(oplog.DeviceID, oplog.Obj1);
            }
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        private void save_assignmentUsr(String serialNumber, String idUserPin)
        {
            AssignmentUserModel assignment = new AssignmentUserModel();
            assignment.DevSN = serialNumber;
            assignment.PIN = idUserPin;
            Add(assignment);
        }

        private int Add(AssignmentUserModel assignUser)
        {
            string sqlSearch = string.Format(@"select ID from AssignmentUser where DevSN=@DevSN and PIN=@PIN");
            SqlParameter[] parametersSearch = {
                        new SqlParameter("@DevSN", assignUser.DevSN),
                        new SqlParameter("@PIN", assignUser.PIN)
                    };
            DataTable dt = SqliteHelper.GetDataTable(sqlSearch, parametersSearch);

            if (dt != null && dt.Rows.Count > 0)
            {
                return 0;
            }
            else
            {
                string sql = string.Format(@"insert into AssignmentUser(DevSN, PIN, HIGHDATE) values (@DevSN, @PIN, @highDate);");

                SqlParameter[] parameters = {
                                new SqlParameter("@DevSN", assignUser.DevSN) ,
                                new SqlParameter("@PIN", assignUser.PIN) ,
                                new SqlParameter("@highDate", DateTime.Now)
                            };
                return SqliteHelper.ExecuteNonQuery(sql, parameters);
            }
        }
    }
}
