using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.Model.Admin;

namespace LL.IDAL.Admin
{
    public interface  IAdminInAdminRole:IBase<AdminInAdminRole>
    {
         bool Exists(int AdminUserID,int AdminRoleID);
 
       
}
}
