using System;
using System.Data;
using LL.Model.Member;
namespace LL.IDAL.Member
{
	/// <summary>
	/// 会员空间模板
	/// </summary>
	public interface Iphome_enewsspacestyle
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  Add(phome_enewsspacestyle model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
        int Update(phome_enewsspacestyle model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
        int Delete(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewsspacestyle GetModel(int id);
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

        phome_enewsspacestyle GetModelByDataRow(DataRow dataRow);
    } 
}
