using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UsuarioCargaDto
    {
        public UsuarioCargaDto()
        {
            this.PIN = "";
            this.Nombre = "";
            this.SerialNumber = "";
        }

        /// <summary>
        /// ID
        /// </summary>		
        private string _PIN;
        public string PIN
        {
            get { return _PIN; }
            set { _PIN = value; }
        }

        /// <summary>
        /// ID
        /// </summary>		
        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        /// ID
        /// </summary>		
        private string _SerialNumber;
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
    }
}
