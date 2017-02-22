using System;
using System.Data;
using LL.Model.Member;

namespace LL.IDAL.Member
{
	/// <summary>
	/// 留言分类
	/// </summary>
	public interface Iphome_enewsgbookclass
	{
		#region  成员方法
		
		int Add(phome_enewsgbookclass model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(phome_enewsgbookclass model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int Delete(int bid);
		int DeleteList(string bidlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewsgbookclass GetModel(int bid);
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

        phome_enewsgbookclass GetModelByDataRow(DataRow dataRow);
    } 
}
