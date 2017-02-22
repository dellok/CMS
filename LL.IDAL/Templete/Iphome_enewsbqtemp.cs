using System;
using System.Data;
using LL.Model.Templete;
namespace LL.IDAL
{
	/// <summary>
	/// 接口层phome_enewsbqtemp
	/// </summary>
	public interface Iphome_enewsbqtemp
	{
		#region  成员方法

        DataSet GetList(int pageindex, int pagesize, string where, string orderby);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(phome_enewsbqtemp model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(phome_enewsbqtemp model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int tempid);
		bool DeleteList(string tempidlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewsbqtemp GetModel(int tempid);


        DataSet GetList(string where);
		#endregion  成员方法
	} 
}
