using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using LL.Model.Member;
using System.Data;
namespace LL.IDAL.Member
{
    /// <summary>
    /// 接口层IPhomeENewsMemberGBook  的摘要说明。
    /// </summary>
    public interface Iphome_enewsmembergbook
    {
        #region  成员方法
       
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(phome_enewsmembergbook  model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int  Update(phome_enewsmembergbook  model);
      
  
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        phome_enewsmembergbook  GetModel(int id,int userid);
        /// <summary>
        /// 获得数据列表
        /// </summary>
       DataSet GetList(string strWhere);
   


        #endregion  成员方法

        System.Data.DataSet GetList(int PageIndex, int PageSize, string strSearch, string orderby);

        phome_enewsmembergbook GetModelByDataRow(System.Data.DataRow dataRow);

        int  Delete(int id, int userid);

        int  DeleteAll(string ids, int userid);

        int CheckedAll(string ids, int ched, int userid);
    }
}