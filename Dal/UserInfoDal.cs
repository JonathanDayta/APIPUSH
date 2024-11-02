using Model;
using Model.DTO;
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
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoDal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(UserInfoModel user)
        {
            string sql = string.Format(@"
insert into UserInfo(
    DevSN,PIN,UserName,Passwd,IDCard,Grp,TZ,Pri,HighDate
   ) values (
    @DevSN,@PIN,@UserName,@Passwd,@IDCard,@Grp,@TZ,@Pri,@HighDate
);");

            SqlParameter[] parameters = {
                        new SqlParameter("@DevSN", user.DevSN) ,
                        new SqlParameter("@PIN", user.PIN) ,
                        new SqlParameter("@UserName", user.UserName) ,
                        new SqlParameter("@Pri",user.Pri) ,
                        new SqlParameter("@Passwd", user.Passwd) ,
                        new SqlParameter("@IDCard", user.IDCard) ,
                        new SqlParameter("@Grp", user.Grp) ,
                        new SqlParameter("@TZ", user.TZ),
                        new SqlParameter("@HighDate", DateTime.Now)
                    };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Update(UserInfoModel user)
        {
            string sql = string.Format(@"
update UserInfo set 
    DevSN=@DevSN
    ,UserName=@UserName
    ,Passwd=@Passwd
    ,IDCard=@IDCard
    ,Grp=@Grp,TZ=@TZ
    ,Pri=@Pri
where PIN=@PIN
");

            SqlParameter[] parameters = {
                        new SqlParameter("@DevSN", user.DevSN) ,
                        new SqlParameter("@PIN", user.PIN) ,
                        new SqlParameter("@UserName", user.UserName) ,
                        new SqlParameter("@Pri",user.Pri) ,
                        new SqlParameter("@Passwd", user.Passwd) ,
                        new SqlParameter("@IDCard", user.IDCard) ,
                        new SqlParameter("@Grp", user.Grp) ,
                        new SqlParameter("@TZ", user.TZ)
                    };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public UserInfoModel Get(string pin)
        {
            string sql = string.Format(@"select * from UserInfo  where PIN=@PIN");
            SqlParameter[] parameters = {
              new SqlParameter("@PIN", pin)
            };

            DataTable dt = SqliteHelper.GetDataTable(sql, parameters);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            UserInfoModel user = new UserInfoModel();
            user.ID = Tools.TryConvertToInt32(row["ID"]);
            user.PIN = row["PIN"].ToString();
            user.UserName = row["UserName"].ToString();
            user.Passwd = row["Passwd"].ToString();
            user.IDCard = row["IDCard"].ToString();
            user.Grp = row["Grp"].ToString();
            user.TZ = row["TZ"].ToString();
            user.Pri = row["Pri"].ToString();
            user.DevSN = row["DevSN"].ToString();

            return user;
        }
        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public List<UserInfoModel> Get(List<string> pins)
        {
            string sql = string.Format(@"select ID,PIN,UserName,Passwd,IDCard,Grp,TZ,Pri,DevSN  from UserInfo  where PIN in ({0}) ", Tools.UnionString(pins));

            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<UserInfoModel> list = new List<UserInfoModel>();
            if (dt == null || dt.Rows.Count == 0)
                return list;

            foreach (DataRow row in dt.Rows)
            {
                UserInfoModel user = new UserInfoModel();
                user.ID = Tools.TryConvertToInt32(row["ID"].ToString());
                user.PIN = row["PIN"].ToString();
                user.UserName = row["UserName"].ToString();
                user.Passwd = row["Passwd"].ToString();
                user.IDCard = row["IDCard"].ToString();
                user.Grp = row["Grp"].ToString();
                user.TZ = row["TZ"].ToString();
                user.Pri = row["Pri"].ToString();
                user.DevSN = row["DevSN"].ToString();

                list.Add(user);
            }

            return list;
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string sql = string.Format(@"
SELECT u.ID, u.DevSN, u.PIN, u.UserName, u.Passwd, u.IDCard, u.Grp, u.TZ, ctui.descEng as Pri
    ,isnull(fp.FP9Count,0) as FP9Count
    ,isnull(fp.FP10Count,0) as FP10Count
    ,isnull(fp.FP12Count,0) as FP12Count
    ,isnull(bd.PalmCount,0) as PalmCount
    ,isnull(f.FaceCount,0)+isnull(bp.BioPhotoCount,0) as FaceCount
FROM UserInfo u 
 LEFT JOIN (
    select pin
        ,sum(case when MajorVer='9' then 1 else 0 end) as FP9Count
        ,sum(case when MajorVer='10' then 1 else 0 end) as FP10Count
        ,sum(case when MajorVer='12' then 1 else 0 end) as FP12Count
    from TmpFP GROUP BY PIN) fp ON u.PIN = fp.PIN 
 LEFT JOIN (select pin,count(id) as FaceCount from TmpFace GROUP BY PIN) f ON u.PIN = f.PIN 
 LEFT JOIN (select pin,count(id) as BioPhotoCount from TmpBioPhoto where type='9' or type='0'  GROUP BY PIN) bp ON u.PIN = bp.PIN 
 LEFT JOIN (select pin,count(id) as PalmCount from TmpBioData where type='8' GROUP BY PIN) bd ON u.PIN = bd.PIN 
 LEFT JOIN CatTypeUserInformation ctui on ctui.code = u.Pri 
ORDER BY u.pin");
            return SqliteHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="pins"></param>
        /// <returns></returns>
        public int Delete(List<string> pins)
        {
            string strPins = Tools.UnionString(pins);

            List<string> listSql = new List<string>();
            //删除一体化模板信息
            listSql.Add(string.Format(@"
delete from TmpBioData 
  where PIN in ({0}) 
", strPins));
            //删除指纹模板信息
            listSql.Add(string.Format(@"
delete from TmpFP 
  where PIN in ({0}) 
", strPins));
            //删除人脸模板信息
            listSql.Add(string.Format(@"
delete from TmpFace 
  where PIN in ({0}) 
", strPins));
            //删除指静脉模板信息
            listSql.Add(string.Format(@"
delete from TmpFvein 
  where PIN in ({0}) 
", strPins));
            //删除用户照片信息
            listSql.Add(string.Format(@"
delete from TmpUserPic 
  where PIN in ({0}) 
", strPins));
            //删除比对照片信息
            listSql.Add(string.Format(@"
delete from TmpBioPhoto 
  where PIN in ({0}) 
", strPins));
            //删除用户信息
            listSql.Add(string.Format(@"
delete from UserInfo 
  where PIN in ({0}) 
", strPins));

            listSql.Add(string.Format(@"
delete from AssignmentUser 
  where PIN in ({0}) 
", strPins));

            try
            {
                SqliteHelper.ExecuteManySql(listSql);
            }
            catch 
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// 清空记录
        /// </summary>
        /// <returns></returns>
        public int ClearAll()
        {
            string sql = "delete from UserInfo";
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        public void AddUsers(List<UsuarioCargaDto> lstUsuariosCarga)
        {
            SqliteHelper.AddUsers(lstUsuariosCarga);
        }

        public void DeleteUsers(List<UsuarioCargaDto> lstUsuariosCarga)
        {
            SqliteHelper.DeleteUsers(lstUsuariosCarga);
        }
    }
}
