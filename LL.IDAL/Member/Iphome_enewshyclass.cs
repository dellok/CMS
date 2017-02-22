using System;
using System.Data;

using LL.Model.Member;
namespace LL.IDAL.Member
{
	/// <summary>
	/// 好友分类
	/// </summary>
	public interface Iphome_enewshyclass
	{
		#region  成员方法
	
		int Add(phome_enewshyclass model);
         int Update(phome_enewshyclass model);
        int Update(int cid, string cname);
	
		int  Delete(int id,int userid);
        int Delete(int id);

		phome_enewshyclass GetModel(int id);
        phome_enewshyclass GetModel(int id,int userid);
	
		DataSet GetList(int PageIndex,int PageSize,string strWhere,string filedOrder);

		#endregion  成员方法

        phome_enewshyclass GetModelByDataRow(DataRow dataRow);

        DataSet GetList(string strWhere);


        /// <summary>
        /// 判断好友分类名
        /// </summary>
        /// <param name="cname"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ExistisClassName(string cname,int userid,int id);
    } 
}
