using System;
using System.Data;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// 接口层Iphome_enewslisttemp 的摘要说明。
	/// </summary>
	public interface Iphome_enewslisttemp
	{
		#region  成员方法
	
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(LL.Model.Templete.phome_enewslisttemp model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(LL.Model.Templete.phome_enewslisttemp model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int Delete(int tempid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		LL.Model.Templete.phome_enewslisttemp GetModel(int tempid);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
	
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法

        DataSet GetList(int PageIndex, int PageSize, string where, string p);
    }
}
