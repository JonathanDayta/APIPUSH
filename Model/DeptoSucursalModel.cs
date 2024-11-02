using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DeptoSucursalModel
    {
        public DeptoSucursalModel()
        {
            this.idDeptoSucursal = 0;
            this.nomSucursal = "";
            this.idCliente = 0;
        }

        private int _idDeptoSucursal;
        public int idDeptoSucursal
        {
            get { return _idDeptoSucursal; }
            set { _idDeptoSucursal = value; }
        }

        private string _nomSucursal;
        public string nomSucursal
        {
            get { return _nomSucursal; }
            set { _nomSucursal = value; }
        }

        private int _idCliente;
        public int idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
    }
}
