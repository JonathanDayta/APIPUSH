using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AssignmentUserModel
    {

        public AssignmentUserModel()
        {
            this.DevSN = "1";
            this.PIN = "1";
            this.HighDate = DateTime.Now;
        }

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _devsn;
        public string DevSN
        {
            get { return _devsn; }
            set { _devsn = value; }
        }

        /// <summary>
        /// PIN
        /// </summary>		
        private string _pin;
        public string PIN
        {
            get { return _pin; }
            set { _pin = value; }
        }

        /// <summary>
        /// HighDate
        /// </summary>		
        private DateTime _highDate;
        public DateTime HighDate
        {
            get { return _highDate; }
            set { _highDate = value; }
        }
    }
}
