using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TblEmpleadoModel
    {
        public TblEmpleadoModel()
        {
            this.numEmpleado = 0;
            this.nombre = string.Empty;
            this.site = string.Empty;
            this.desDepto = string.Empty;
        }

        private long _numEmpleado;
        public long numEmpleado
        {
            get { return _numEmpleado; }
            set { _numEmpleado = value; }
        }

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _site;
        public string site
        {
            get { return _site; }
            set { _site = value; }
        }

        private string _desDepto;
        public string desDepto
        {
            get { return _desDepto; }
            set { _desDepto = value; }
        }
    }
}
