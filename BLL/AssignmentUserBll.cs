using Dal;
using Model;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class AssignmentUserBll
    {
        private AssignmentUserDal _dal = new AssignmentUserDal();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(AssignmentUserModel user)
        {
            return _dal.Add(user);
        }
    }
}
