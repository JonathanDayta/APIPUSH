using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace BLL
{
    public class DeptoSucursalBll
    {
        private DeptoSucursalDal _dal = new DeptoSucursalDal();

        public List<DeptoSucursalModel> GetDeptoSucursalByIdClient(int idClient)
        {
            return _dal.getDeptoSucursalByIdClient(idClient);
        }

        public int GetIdCliente(int idDeptoSuc)
        {
            return _dal.GetIdCliente(idDeptoSuc);
        }
    }
}
