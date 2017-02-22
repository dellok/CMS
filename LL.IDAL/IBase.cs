using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LL.Model;

namespace LL.IDAL { 


    public interface IBase<T>:IRepository<T> 
        where  T:class,IAggregateRoot
    {
        int Add(T model);
        int Update(T model);
        int Delete(int id);
        T GetModel(int id);
        List<T> GetModelAll();

        DataSet GetList(string strWhere);
        DataSet GetList(int pageindex, int pagesize, string where, string orderby);
        DataSet GetDataBySpName(string name);



}
}




