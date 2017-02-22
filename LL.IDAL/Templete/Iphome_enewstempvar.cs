using System;
using System.Data;
using LL.Model.Templete;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// 接口层Iphome_enewstempvar 的摘要说明。
	/// </summary>
	public interface Iphome_enewstempvar
	{
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(phome_enewstempvar model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int  Update(phome_enewstempvar model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int  Delete(int varid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewstempvar GetModel(int varid);
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
	}
}
