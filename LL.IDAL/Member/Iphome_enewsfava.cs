using System;
using System.Data;
using LL.Model.Member;
namespace LL.IDAL.Member
{

	public interface Iphome_enewsfava
	{
		#region  成员方法
		
		int Add(phome_enewsfava model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(phome_enewsfava model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int Delete(int favaid);
		int DeleteList(string favaidlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewsfava GetModel(int favaid);
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

        DataSet GetList(int PageIndex, int PageSize, string where, string orderby);

        int Delete(int fid, int userid);

         int DeleteList(string favaidlist, string where);
    } 
}
