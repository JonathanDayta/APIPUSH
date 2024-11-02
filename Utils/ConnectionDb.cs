namespace Utils
{
    public class ConnectionDb
    {
        //cadena de conexion a la DB de ZKPushDemo
        public const string CONN_STR_LOCAL = @"Data source=localhost; initial catalog = BIOACCESS; user id = pushUser; password = R9p89%I9Ve";
        public const string CONN_STR_ISS = @"Data source=137.116.39.152,52011; initial catalog = BIOACCESS_ISS; user id=user_bioacces; password=g4@7QZ#Ox34J";
        public const string CONN_STR_LEDO = @"data source=137.116.39.152,52011; initial catalog =BIOACCESS_PRUEBAS; user id=user_bioacces; password=g4@7QZ#Ox34J";
        public const string CONN_STR_SALJAMEX = @"data source=137.116.39.152,52011; initial catalog =BIOACCESS_DESA; user id=BIOACCESS_DESA; password=hNF>£S628VAk";
        public const string CONN_STR_TEST = @"data source=137.116.39.152,52011; initial catalog =BIOACCESS_TEST; user id=user_bioacces_test; password=test_2024##@@";


        //cadena de conexion a la DB de WDMS
        public const string CONN_STR_WDMS_LOCAL = @"Data Source=137.116.39.152,52011; initial catalog =wdms_db_Saljamex; user id=wdms_db_Saljamex; password=FB_[x40keuE0";
        public const string CONN_STR_WDMS_ISS_PRUEBAS = @"Data Source=137.116.39.152,52011;initial catalog =wdms_db_desa; user id=wdms_desa; password=qQt*$U98B1OT";
        public const string CONN_STR_WDMS_ISS = @"Data Source=137.116.39.152,52011; initial catalog = wdms_db; user id = WdmsUser; password=692639D1CA38EFE2@@1";
        public const string CONN_STR_WDMS_LEDO = @"Data Source=137.116.39.152,52011; initial catalog =wdms_db_ledo; user id=WdmsUser; password=692639D1CA38EFE2@@1";
        public const string CONN_STR_WDMS_SALJAMEX = @"Data Source=137.116.39.152,52011; initial catalog =wdms_db_Saljamex; user id=wdms_db_Saljamex; password=FB_[x40keuE0";
        //jdbc:sqlserver://137.116.39.152:52011;databaseName=wdms_db_ledo;trustServerCertificate=false;encrypt=false
    }
}