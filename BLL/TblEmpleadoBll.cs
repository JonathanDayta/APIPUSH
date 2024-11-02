using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Business Logic Layer para la tabla de tblEmpleado
    /// </summary>
    public class TblEmpleadoBll
    {
        private TblEmpleadoDal _dal = new TblEmpleadoDal();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public List<TblEmpleadoModel> GetTblEmpleadosBySite(string site)
        {
            return _dal.GetEmpleadosBySite(site);
        }
    }
}
