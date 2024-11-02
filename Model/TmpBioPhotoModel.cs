using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 比对照片
    /// </summary>
    public class TmpBioPhotoModel
    {
        public TmpBioPhotoModel()
        {
            this.Size = 0;
            this.DischargeDate = DateTime.Now;
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
        /// <summary>
        /// PIN
        /// </summary>		
        private string _pin;
        public string Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }
        /// <summary>
        /// FID
        /// </summary>		
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        /// <summary>
        /// FID
        /// </summary>		
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// Size
        /// </summary>		
        private int _size;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        /// <summary>
        /// Content
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// DischargeDate
        /// </summary>		
        private DateTime _dischargeDate;
        public DateTime DischargeDate
        {
            get { return _dischargeDate; }
            set { _dischargeDate = value; }
        }
    }
    
}
