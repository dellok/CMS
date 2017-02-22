using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.Model.Popedom;

namespace LL.IDAL.Popedom
{
    public interface IPopedomFunInAdminRole:IBase<PopedomFunInAdminRole>
    {
        bool Exist(int FunID,int AdminRoleID);
        /// <summary>
        /// 批量修改功能 与admin角色关联信息
        /// </summary>
        /// <param name="AdminRoleID"></param>
        /// <param name="arrEditFunInAdminRole"></param>
        /// <returns></returns>

        int EditFunInAdminRole(int AdminRoleID, List<PopedomFunInAdminRole> arrEditFunInAdminRole);

        int DelBatch(List<PopedomFunInAdminRole> arrDelFunInAdminRole);
        int AddBatch(List<PopedomFunInAdminRole> arrAddFunInAdminRole);
    }
}
