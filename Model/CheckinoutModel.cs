using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CheckinoutModel
    {

        public CheckinoutModel()
        {
            this.userid = 1;
            this.checktime = Convert.ToDateTime("1900-01-01 00:00:00");
            this.checktype = "0";
            this.verifycode = 1;
            this.SN = "0";
            this.sensorid = "0";
            this.WorkCode = "0";
            this.Reserved = "0";
            this.company_id = 1;
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _userid;
        public int userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private DateTime _checktime;
        public DateTime checktime
        {
            get { return _checktime; }
            set { _checktime = value; }
        }

        private string _checktype;
        public string checktype
        {
            get { return _checktype; }
            set { _checktype = value; }
        }

        private int _verifycode;
        public int verifycode
        {
            get { return _verifycode; }
            set { _verifycode = value; }
        }

        private string _SN;
        public string SN
        {
            get { return _SN; }
            set { _SN = value; }
        }

        private string _sensorid;
        public string sensorid
        {
            get { return _sensorid; }
            set { _sensorid = value; }
        }

        private string _WorkCode;
        public string WorkCode
        {
            get { return _WorkCode; }
            set { _WorkCode = value; }
        }

        private string _Reserved;
        public string Reserved
        {
            get { return _Reserved; }
            set { _Reserved = value; }
        }

        private int _company_id;
        public int company_id
        {
            get { return _company_id; }
            set { _company_id = value; }
        }
    }
}
