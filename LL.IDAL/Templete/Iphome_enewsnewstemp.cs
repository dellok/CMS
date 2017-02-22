using System;
using System.Data;
using LL.Model.Templete;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// 接口层Iphome_enewsnewstemp 的摘要说明。
	/// </summary>
	public interface Iphome_enewsnewstemp
	{
		#region  成员方法
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(phome_enewsnewstemp model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(phome_enewsnewstemp model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int Delete(int tempid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewsnewstemp GetModel(int tempid);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
        DataSet GetList(int pageindex, int pagesize, string where, string oderby);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
	}
}
