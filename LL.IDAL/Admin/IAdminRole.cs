using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LL.Model.Admin;

namespace LL.IDAL.Admin
{
   public  interface IAdminRole:IBase<AdminRole>
    {
         bool Exists(int ID, string  RoleName);
       

    }
}
