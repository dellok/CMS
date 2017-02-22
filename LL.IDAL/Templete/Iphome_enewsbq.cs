using System;
using System.Data;
using LL.Model.Templete;
namespace LL.IDAL
{
	/// <summary>
	/// 接口层phome_enewsbq
	/// </summary>
	public interface Iphome_enewsbq
	{
		#region  成员方法

        DataSet GetList(int pageindex, int pagesize, string where, string orderby);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(phome_enewsbq model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(phome_enewsbq model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int bqid);
		bool DeleteList(string bqidlist );


        DataSet GetList(string where);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewsbq GetModel(int bqid);
	
		#endregion  成员方法
	} 
}
