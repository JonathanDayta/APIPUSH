using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace BLL
{
    public class ZonaClienteBll
    {
        private ZonaClienteDal _dal = new ZonaClienteDal();

        public List<ZonaClienteModel> GetClientes()
        {
            return _dal.getClientes();
        }
    }
}
