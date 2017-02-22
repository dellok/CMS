using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.Admin;

using LL.DALFactory;
using LL.Model.Admin;
namespace LL.BLL.Admin
{
    public class BLLAdminInAdminRole
    {
        IAdminInAdminRole dal = DataAccess.CreateDALAdminInAdminRole();

        /// <summary>
        /// id>0 为修改时判断
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool Exists(int AdminUserID,  int  AdminRoleID)
        {
            return dal.Exists(AdminUserID, AdminRoleID);
        }

        public int Add(AdminInAdminRole model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(AdminInAdminRole model)
        {
            return dal.Update(model);
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        public AdminInAdminRole GetModel(int id)
        {

            return dal.GetModel(id);
        }
    }
}
