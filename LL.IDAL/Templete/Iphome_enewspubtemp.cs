using System;
using System.Data;
namespace LL.IDAL.Templete
{
	/// <summary>
	/// 接口层phome_enewspubtemp
	/// </summary>
	public interface Iphome_enewspubtemp
	{
		#region  成员方法
	
		int  Add(LL.Model.Templete.phome_enewspubtemp model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int  Update(LL.Model.Templete.phome_enewspubtemp model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int  Delete(int id);
		int  DeleteList(string idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		LL.Model.Templete.phome_enewspubtemp GetModel(int id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);

		#endregion  成员方法
        string GetPubTempTextByFiled(string id);
         int UpdateField(string filed, string value);
    } 
}
