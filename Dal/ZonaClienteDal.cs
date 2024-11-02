using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Dal
{
    public class ZonaClienteDal
    {
        public List<ZonaClienteModel> getClientes() {
            List<ZonaClienteModel> retorno = WdmsSqlHelper.GetAllClientes();
            System.Console.WriteLine("Cientes: " + retorno.Count);
            return retorno;
        }
    }
}
