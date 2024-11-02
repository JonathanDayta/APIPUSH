using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Dal
{
    public class AssignmentUserDal
    {

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(AssignmentUserModel assignUser)
        {
            string sqlSearch = string.Format(@"select ID from AssignmentUser where DevSN=@DevSN and PIN=@PIN");
            SqlParameter[] parametersSearch = {
                        new SqlParameter("@DevSN", assignUser.DevSN) ,
                        new SqlParameter("@PIN", assignUser.PIN)
                    };
            DataTable dt = SqliteHelper.GetDataTable(sqlSearch, parametersSearch);

            if (dt != null && dt.Rows.Count > 0)
            {
                return 0;
            }
            else {
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
