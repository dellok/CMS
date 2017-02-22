using LL.IDAL;
using System.Data;
using System;
using System.Data.SqlClient;
using LL.Model;

namespace LL.DAL
{
    public abstract class Repository<T> : IRepository<T> where T:class,IAggregateRoot 
    {

        /// <summary>
        /// 根据存储过程返回dataset 数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
      public   DataSet GetDataBySpName(string name)
        {

        
            return GetDataBySpName(name,null);
        }
      public   DataSet GetDataBySpName(string name, SqlParameter[] parms=null)
        {

            if (string.IsNullOrEmpty(name))
            {
                return null;

                //throw new Exception("sp name  is null, sp name must  value");

            }
        
            return DBUtility.DbHelperSQL.RunProcReturnDS(name, parms);
           
        }
    }
}
