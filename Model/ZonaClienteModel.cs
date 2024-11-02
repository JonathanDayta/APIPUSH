using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ZonaClienteModel
    {
        public ZonaClienteModel()
        {
            this.idZonaCliente = 0;
            this.nomCliente = "";
        }

        private int _idZonaCliente;
        public int idZonaCliente
        {
            get { return _idZonaCliente; }
            set { _idZonaCliente = value; }
        }

        private string _nomCliente;
        public string nomCliente
        {
            get { return _nomCliente; }
            set { _nomCliente = value; }
        }
    }
}
