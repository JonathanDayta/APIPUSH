using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    /// <summary>
    /// Business Logic Layer para la tabla de Checkinout
    /// </summary>
    public class CheckinoutBll
    {
        private CheckinoutDal _dal = new CheckinoutDal();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="attlog"></param>
        /// <returns></returns>
        public int Add(CheckinoutModel checkinout)
        {
            if (_dal.IsExist(checkinout.userid, checkinout.checktime))
            {
                return 0;
            }
            return _dal.Add(checkinout);
        }
    }
}
