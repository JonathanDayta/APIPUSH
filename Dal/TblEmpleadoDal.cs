using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Utils;

namespace Dal
{
    public class TblEmpleadoDal
    {
        public List<TblEmpleadoModel> GetEmpleadosBySite(string site)
        {
            if (StringExtension.isNotNullEmptyBlank(site))
            {
                return WdmsSqlHelper.GetEmpleadosBySite(site);
            }
            else
            {
                return null;
            }
        }
    }
}
