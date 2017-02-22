using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LL.Model;
using System.Data.SqlClient;

namespace LL.IDAL
{
   public  interface IRepository<T> where  T:class,IAggregateRoot
    {

        DataSet GetDataBySpName(string name, SqlParameter[] parms = null);
    }
}
