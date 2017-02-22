using System;
using System.Data;
using LL.Model.Templete;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// 接口层Iphome_enewsnewstempclass 的摘要说明。
	/// </summary>
	public interface Iphome_enewsnewstempclass
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  Add(phome_enewsnewstempclass model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(phome_enewsnewstempclass model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int Delete();
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewsnewstempclass GetModel();

        DataSet GetList(int pageindex, int pagesize, string where, string orderby);
		#endregion  成员方法

        DataSet GetList(string strWhere);
    }
}
