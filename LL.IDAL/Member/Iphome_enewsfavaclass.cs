using System;
using System.Data;
using LL.Model.Member;
using System.Collections.Generic;
namespace LL.IDAL.Member
{

	public interface Iphome_enewsfavaclass
	{
		#region  成员方法
		
		int Add(phome_enewsfavaclass model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int  Update(phome_enewsfavaclass model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int  Delete(int cid);
		int  DeleteList(string cidlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewsfavaclass GetModel(int cid);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
        List<phome_enewsfavaclass>  GetListByUserID(int userid);

        int Delete(int id, int userid);

        bool ExistsClassName(string cname, int userid, int id);
    } 
}
