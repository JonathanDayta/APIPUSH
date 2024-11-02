using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace Dal
{
    /// <summary>
    /// 指纹模板
    /// </summary>
    public class TmpFPDal
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public List<TmpFPModel> Get(string pin)
        {
            string sql = string.Format(@"select * from TmpFP where pin = '{0}';", pin);

            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
                return new List<TmpFPModel>();

            List<TmpFPModel> fps = new List<TmpFPModel>();
            foreach (DataRow row in dt.Rows)
            {
                TmpFPModel fp = new TmpFPModel();
                fp.ID = Convert.ToInt32(row["ID"].ToString());
                fp.Pin = row["PIN"].ToString();
                fp.Fid = row["FID"].ToString();
                fp.Size = Convert.ToInt32(row["Size"].ToString());
                fp.Valid = row["Valid"].ToString();
                fp.Tmp = row["Tmp"].ToString();
                fp.MajorVer = row["MajorVer"].ToString();
                fp.MinorVer = row["MinorVer"].ToString();
                fp.Duress = row["Duress"].ToString();
                fps.Add(fp);
            }
            return fps;
        }

        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="ver"></param>
        /// <returns></returns>
        public int GetCount(string pin, string ver)
        {
            string sql = string.Format(@"select count(*) from TmpFP where pin='{0}' and ver='{1}'", pin.ToLower(), ver.ToLower());

            return Tools.TryConvertToInt32(SqliteHelper.ExecuteScalar(sql));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(TmpFPModel model)
        {
            string sql = string.Format(@"delete from TmpFP where Pin=@Pin and MajorVer=@MajorVer and Fid=@Fid;");

            string sql2 = string.Format(@"insert into TmpFP(Pin,Fid,Size,Valid,Tmp,MajorVer,MinorVer,Duress,DischargeDate) values(@Pin,@Fid,@Size,@Valid,@Tmp,@MajorVer,@MinorVer,@Duress,@DischargeDate);");

            SqlParameter[] parameters = {
                        new SqlParameter("@Pin", model.Pin) ,
                        new SqlParameter("@Fid", model.Fid) ,
                        new SqlParameter("@Size",model.Size) ,
                        new SqlParameter("@Valid", model.Valid) ,
                        new SqlParameter("@Tmp", model.Tmp) ,
                        new SqlParameter("@MajorVer", Tools.ValidaParametroStr(model.MajorVer)),
                        new SqlParameter("@MinorVer", Tools.ValidaParametroStr(model.MinorVer)),
                        new SqlParameter("@Duress", model.Duress),
                        new SqlParameter("@DischargeDate", DateTime.Now)
                    };
            SqliteHelper.ExecuteNonQuery(sql.ToString(), parameters);
            return SqliteHelper.ExecuteNonQuery(sql2.ToString(), parameters);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public int Delete(List<string> pins)
        {
            string sql = string.Format(@"delete from TmpFP  where Pin in ({0});", Tools.UnionString(pins));

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from TmpFP ";
            return SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
