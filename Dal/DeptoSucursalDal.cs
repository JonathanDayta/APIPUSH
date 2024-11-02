using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;
using Utils;

namespace Dal
{
    public class DeptoSucursalDal
    {
        public List<DeptoSucursalModel> getDeptoSucursalByIdClient(int idClient)
        {
            List<DeptoSucursalModel> retorno = WdmsSqlHelper.GetAllDeptoSucursalByClient(idClient);
            System.Console.WriteLine("Departments-Sucursal: " + retorno.Count);
            return retorno;
        }

        public int GetIdCliente(int idDeptoSuc)
        {
            string sql = string.Format(@"select idCliente from catDeptoSucursal where idDeptoSucursal=@idDeptoSuc");

            SqlParameter[] parameters = {
                        new SqlParameter("@idDeptoSuc", idDeptoSuc)
            };
            int count = Tools.TryConvertToInt32(WdmsSqlHelper.ExecuteScalar(sql, parameters));
            return count;
        }
    }
}
