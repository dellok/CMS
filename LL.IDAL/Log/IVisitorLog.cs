using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using LL.Model.Log;
namespace LL.IDAL.Log
{
    public interface IVisitorLog : IBase<VisitorLog>
    {

        DataSet TotalVisitorLog(int PageIndex, int PageSize, string type, string where, string orderby);
    }
}
