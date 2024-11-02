using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace Dal
{
    /// <summary>
    /// 设备
    /// </summary>
    public class DeviceDal
    {
        /// <summary>GetAll
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public DataTable GetAll(string sqlWhere)
        {
            sqlWhere = string.IsNullOrEmpty(sqlWhere) ? "" : " where " + sqlWhere;
            string sql = string.Format(@"select * from Device{0};", sqlWhere);

            return SqliteHelper.GetDataTable(sql);
        }
        /// <summary>Get one model
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public DeviceModel Get(string devSN)
        {
            DataTable dt = GetAll(string.Format("DevSN='{0}'", devSN));
            if (dt == null || dt.Rows.Count == 0)
                return null;

            DeviceModel device = new DeviceModel();
            device.ID = Tools.TryConvertToInt32(dt.Rows[0]["ID"]);
            device.DevSN = Tools.ValidaParametroConsultaStr(dt.Rows[0]["DevSN"]);
            device.TransInterval = Tools.ValidaParametroConsultaStr(dt.Rows[0]["TransInterval"]);
            device.TransTimes = Tools.ValidaParametroConsultaStr(dt.Rows[0]["TransTimes"]);
            device.Encrypt = Tools.ValidaParametroConsultaStr(dt.Rows[0]["Encrypt"]);
            if (dt.Rows[0]["LastRequestTime"] != null) {
                device.LastRequestTime = Convert.ToDateTime(dt.Rows[0]["LastRequestTime"].ToString());
            } 
            else {
                device.LastRequestTime = Convert.ToDateTime("0");
            }
            device.DevIP = Tools.ValidaParametroConsultaStr(dt.Rows[0]["DevIP"]);
            device.DevMac = Tools.ValidaParametroConsultaStr(dt.Rows[0]["DevMac"]);
            device.DevFirmwareVersion = Tools.ValidaParametroConsultaStr(dt.Rows[0]["DevFirmwareVersion"]);
            device.UserCount = Tools.TryConvertToInt32(dt.Rows[0]["UserCount"]);
            device.AttCount = Tools.TryConvertToInt32(dt.Rows[0]["AttCount"]);
            device.DevName = Tools.ValidaParametroConsultaStr(dt.Rows[0]["DevName"]);
            device.TimeZone = Tools.ValidaParametroConsultaStr(dt.Rows[0]["TimeZone"]);
            device.Timeout = Tools.TryConvertToInt32(dt.Rows[0]["Timeout"]);
            device.SyncTime = Tools.TryConvertToInt32(dt.Rows[0]["SyncTime"]);
            device.FpCount = Tools.TryConvertToInt32(dt.Rows[0]["FpCount"]);
            device.AttLogStamp = Tools.ValidaParametroConsultaStr(dt.Rows[0]["ATTLOGStamp"]);
            device.OperLogStamp = Tools.ValidaParametroConsultaStr(dt.Rows[0]["OPERLOGStamp"]);
            device.AttPhotoStamp = Tools.ValidaParametroConsultaStr(dt.Rows[0]["ATTPHOTOStamp"]);
            device.ErrorDelay = Tools.ValidaParametroConsultaStr(dt.Rows[0]["ErrorDelay"]);
            device.Delay = Tools.ValidaParametroConsultaStr(dt.Rows[0]["Delay"]);
            device.TransFlag = Tools.ValidaParametroConsultaStr(dt.Rows[0]["TransFlag"]);
            device.Realtime = Tools.ValidaParametroConsultaStr(dt.Rows[0]["Realtime"]);
            device.VendorName = Tools.ValidaParametroConsultaStr(dt.Rows[0]["VendorName"]);
            device.IRTempDetectionFunOn = Tools.ValidaParametroConsultaStr(dt.Rows[0]["IRTempDetectionFunOn"]);
            device.MaskDetectionFunOn = Tools.ValidaParametroConsultaStr(dt.Rows[0]["MaskDetectionFunOn"]);
            device.MultiBioDataSupport = Tools.ValidaParametroConsultaStr(dt.Rows[0]["MultiBioDataSupport"]);
            device.MultiBioPhotoSupport = Tools.ValidaParametroConsultaStr(dt.Rows[0]["MultiBioPhotoSupport"]);
            device.MultiBioVersion = Tools.ValidaParametroConsultaStr(dt.Rows[0]["MultiBioVersion"]);
            device.MultiBioCount = Tools.ValidaParametroConsultaStr(dt.Rows[0]["MultiBioCount"]);
            device.MaxMultiBioDataCount = Tools.ValidaParametroConsultaStr(dt.Rows[0]["MaxMultiBioDataCount"]);
            device.MaxMultiBioPhotoCount = Tools.ValidaParametroConsultaStr(dt.Rows[0]["MaxMultiBioPhotoCount"]);
            device.IdDeptoSucursal = Tools.TryConvertToInt32(dt.Rows[0]["IdDeptoSucursal"]);

            return device;
        }

        /// <summary>Add
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public int Add(DeviceModel device)
        {
            string sql = string.Format(@"insert into Device(
        DevSN,TransInterval,TransTimes,Encrypt,LastRequestTime,DevIP,DevMac,DevFirmwareVersion
        ,UserCount,AttCount,FpCount,DevName,TimeZone,Timeout,SyncTime,ATTLOGStamp,OPERLOGStamp,ATTPHOTOStamp
        ,ErrorDelay,Delay,TransFlag,Realtime,VendorName,IRTempDetectionFunOn,MaskDetectionFunOn,IdDeptoSucursal
   ) values (
        @DevSN,@TransInterval,@TransTimes,@Encrypt,@LastRequestTime,@DevIP,@DevMac,@DevFirmwareVersion
        ,@UserCount,@AttCount,@FpCount,@DevName,@TimeZone,@Timeout,@SyncTime,@ATTLOGStamp,@OPERLOGStamp,@ATTPHOTOStamp
        ,@ErrorDelay,@Delay,@TransFlag,@Realtime,@VendorName,@IRTempDetectionFunOn,@MaskDetectionFunOn,@IdDeptoSucursal);");

            SqlParameter[] parameters = {
                        new SqlParameter("@DevSN", device.DevSN) ,
                        new SqlParameter("@TransInterval", device.TransInterval) ,
                        new SqlParameter("@TransTimes", device.TransTimes) ,
                        new SqlParameter("@Encrypt", device.Encrypt) ,
                        new SqlParameter("@LastRequestTime", device.LastRequestTime) ,
                        new SqlParameter("@DevIP", device.DevIP) ,
                        new SqlParameter("@DevMac", device.DevMac) ,
                        new SqlParameter("@DevFirmwareVersion", device.DevFirmwareVersion) ,
                        new SqlParameter("@UserCount", device.UserCount) ,
                        new SqlParameter("@AttCount", device.AttCount) ,
                        new SqlParameter("@FpCount", device.FpCount),
                        new SqlParameter("@DevName", device.DevName) ,
                        new SqlParameter("@TimeZone", device.TimeZone) ,
                        new SqlParameter("@Timeout", device.Timeout) ,
                        new SqlParameter("@SyncTime", device.SyncTime) ,
                        new SqlParameter("@ATTLOGStamp",device.AttLogStamp) ,
                        new SqlParameter("@OPERLOGStamp", device.OperLogStamp) ,
                        new SqlParameter("@ATTPHOTOStamp", device.AttPhotoStamp) ,
                        new SqlParameter("@ErrorDelay", device.ErrorDelay) ,
                        new SqlParameter("@Delay",device.Delay) ,
                        new SqlParameter("@TransFlag", device.TransFlag) ,
                        new SqlParameter("@Realtime", device.Realtime) ,
                        new SqlParameter("@VendorName", device.VendorName),
                        new SqlParameter("@IRTempDetectionFunOn", device.IRTempDetectionFunOn),
                        new SqlParameter("@MaskDetectionFunOn", device.MaskDetectionFunOn),
                        new SqlParameter("@IdDeptoSucursal", device.IdDeptoSucursal)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>Delete
        /// </summary>
        /// <param name="devSN"></param>
        /// <returns></returns>
        public int Delete(string devSN)
        {
            string sql = string.Format(@"delete from Device where DevSN='{0}';", devSN);

            return SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>Update
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public int Update(DeviceModel device)
        {
            string sql = string.Format(@"update Device set 
    TransInterval = @TransInterval , 
    TransTimes = @TransTimes , 
    Encrypt = @Encrypt , 
    LastRequestTime = @LastRequestTime , 
    DevIP = @DevIP , 
    DevMac = @DevMac , 
    DevFirmwareVersion = @DevFirmwareVersion , 
    UserCount = @UserCount , 
    AttCount = @AttCount , 
    DevName = @DevName , 
    TimeZone = @TimeZone , 
    Timeout = @Timeout , 
    SyncTime = @SyncTime , 
    ATTLOGStamp = @ATTLOGStamp , 
    OPERLOGStamp = @OPERLOGStamp , 
    ATTPHOTOStamp = @ATTPHOTOStamp , 
    ErrorDelay = @ErrorDelay , 
    Delay = @Delay , 
    TransFlag = @TransFlag , 
    Realtime = @Realtime,  
    VendorName = @VendorName,  
    IRTempDetectionFunOn = @IRTempDetectionFunOn,  
    MaskDetectionFunOn = @MaskDetectionFunOn,  
    MultiBioDataSupport = @MultiBioDataSupport,  
    MultiBioPhotoSupport = @MultiBioPhotoSupport,  
    MultiBioVersion = @MultiBioVersion,  
    MultiBioCount = @MultiBioCount,  
    MaxMultiBioDataCount = @MaxMultiBioDataCount,  
    MaxMultiBioPhotoCount = @MaxMultiBioPhotoCount,  
    FpCount = @FpCount,
    IdDeptoSucursal = @IdDeptoSucursal
    where DevSN=@DevSN ");

            SqlParameter[] parameters = {
                        new SqlParameter("@DevSN",  device.DevSN) ,
                        new SqlParameter("@TransInterval", device.TransInterval) ,
                        new SqlParameter("@TransTimes", device.TransTimes) ,
                        new SqlParameter("@Encrypt", device.Encrypt) ,
                        new SqlParameter("@LastRequestTime", device.LastRequestTime) ,
                        new SqlParameter("@DevIP", device.DevIP) ,
                        new SqlParameter("@DevMac",device.DevMac) ,
                        new SqlParameter("@DevFirmwareVersion", device.DevFirmwareVersion) ,
                        new SqlParameter("@UserCount",device.UserCount) ,
                        new SqlParameter("@AttCount", device.AttCount) ,
                        new SqlParameter("@DevName", device.DevName) ,
                        new SqlParameter("@TimeZone", device.TimeZone) ,
                        new SqlParameter("@Timeout", device.Timeout) ,
                        new SqlParameter("@SyncTime", device.SyncTime) ,
                        new SqlParameter("@ATTLOGStamp", device.AttLogStamp) ,
                        new SqlParameter("@OPERLOGStamp", device.OperLogStamp) ,
                        new SqlParameter("@ATTPHOTOStamp", device.AttPhotoStamp) ,
                        new SqlParameter("@ErrorDelay",device.ErrorDelay) ,
                        new SqlParameter("@Delay", device.Delay) ,
                        new SqlParameter("@TransFlag", device.TransFlag) ,
                        new SqlParameter("@Realtime", device.Realtime) ,
                        new SqlParameter("@VendorName", device.VendorName),
                        new SqlParameter("@IRTempDetectionFunOn", device.IRTempDetectionFunOn),
                        new SqlParameter("@MaskDetectionFunOn", device.MaskDetectionFunOn),
                        new SqlParameter("@MultiBioDataSupport", device.MultiBioDataSupport),
                        new SqlParameter("@MultiBioPhotoSupport", device.MultiBioPhotoSupport),
                        new SqlParameter("@MultiBioVersion", device.MultiBioVersion),
                        new SqlParameter("@MultiBioCount", device.MultiBioCount),
                        new SqlParameter("@MaxMultiBioDataCount", device.MaxMultiBioDataCount),
                        new SqlParameter("@MaxMultiBioPhotoCount", device.MaxMultiBioPhotoCount),
                        new SqlParameter("@FpCount", device.FpCount),
                        new SqlParameter("@IdDeptoSucursal", device.IdDeptoSucursal)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新考勤日志时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateAttLogStamp(string stamp, string devSN)
        {
            string sql = string.Format(@"update Device set ATTLOGStamp = @ATTLOGStamp where DevSN=@DevSN;");

            SqlParameter[] parameters = {
                new SqlParameter("@ATTLOGStamp", stamp),
                new SqlParameter("@DevSN",  devSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 考勤日志时间戳清理
        /// </summary>
        /// <param name="listDevSn"></param>
        public void SetZeroAttLogStamp(List<string> listDevSn)
        {
            string sql = string.Format(@"update Device set ATTLOGStamp = '0' where DevSN in ({0})", Tools.UnionString(listDevSn));

            SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 更新操作日志时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateOperLogStamp(string stamp, string devSN)
        {
            string sql = string.Format(@"update Device set OPERLOGStamp = @OPERLOGStamp where DevSN=@DevSN;");

            SqlParameter[] parameters = {
                new SqlParameter("@OPERLOGStamp",stamp ),
                new SqlParameter("@DevSN",  devSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新错误日志时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateErrorLogStamp(string stamp, string devSN)
        {
            string sql = string.Format(@"update Device set ERRORLOGStamp = @ERRORLOGStamp where DevSN=@DevSN;");

            SqlParameter[] parameters = {
                new SqlParameter("@ERRORLOGStamp",stamp ),
                new SqlParameter("@DevSN",  devSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新考勤图像时间戳
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="devSN"></param>
        public void UpdateAttPhotoStamp(string stamp, string devSN)
        {
            string sql = string.Format(@"update Device set ATTPHOTOStamp = @ATTPHOTOStamp where DevSN=@DevSN;");

            SqlParameter[] parameters = {
                new SqlParameter("@ATTPHOTOStamp",stamp ),
                new SqlParameter("@DevSN",  devSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 清零时间戳
        /// </summary>
        /// <param name="listDevSn"></param>
        public void SetZeroStamp(List<string> listDevSn)
        {
            string sql = string.Format(@"update Device set OPERLOGStamp = '0', ATTLOGStamp = '0', ATTPHOTOStamp = '0' where DevSN in ({0})", Tools.UnionString(listDevSn));

            SqliteHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 更新最后请求时间
        /// </summary>
        /// <param name="DevSN"></param>
        public void SetLastRequestTime(string DevSN)
        {
            string sql = string.Format(@"update Device set LastRequestTime = @LastRequestTime where DevSN=@DevSN;");

            SqlParameter[] parameters = {
                new SqlParameter("@LastRequestTime",Tools.GetDateTimeNowString() ),
                new SqlParameter("@DevSN",  DevSN)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 更新供应商名称
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="vendorName"></param>
        public void UpdateVendorName(string sn, string vendorName)
        {
            string sql = string.Format(@"update Device set VendorName = @VendorName where DevSN=@DevSN;");

            SqlParameter[] parameters = {
                new SqlParameter("@VendorName",vendorName ),
                new SqlParameter("@DevSN",  sn)
            };
            SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 获取所有的DevSN
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllDevSN()
        {
            string sql = string.Format(@"select DevSN from Device;");

            List<string> listDevSN = new List<string>();
            DataTable dt = SqliteHelper.GetDataTable(sql);
            if (dt == null)
            {
                return listDevSN;
            }

            foreach (DataRow row in dt.Rows)
            {
                listDevSN.Add(Tools.ValidaParametroConsultaStr(row[0])); //row[0].ToString());
            }

            return listDevSN;
        }
    }
}
