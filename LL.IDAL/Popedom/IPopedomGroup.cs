using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using LL.Model.Popedom;

namespace LL.IDAL.Popedom
{
   public  interface IPopedomGroup:IBase<PopedomGroup>
    {

       bool Exist(int ID,string GroupName);

    }
}
