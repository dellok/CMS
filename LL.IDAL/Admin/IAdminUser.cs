using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.Model.Admin;
namespace LL.IDAL.Admin
{
    public interface IAdminUser:IBase<AdminUser>
    {
         bool ExistsLoginName(int ID, string LoginName);
         AdminUser GetModelByNameAndPwd(string LoginName, string Password);
         int  SetAdminChecked(int id, bool isChecked);



         int UpdatePwd(int uid, string pwd);
    }
}
