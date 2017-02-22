using System;
using System.Data;
using LL.Model.Member;
namespace LL.IDAL.Member
{
	/// <summary>
	/// 会员留言
	/// </summary>
	public interface Iphome_enewsgbook
	{
		#region  成员方法
	
		int Add(phome_enewsgbook model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(phome_enewsgbook model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int  Delete(int lyid);
		int  DeleteList(string lyidlist ,string where);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		phome_enewsgbook GetModel(int lyid);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);

		#endregion  成员方法

        phome_enewsgbook GetModelByDataRow(DataRow  row);

        DataSet GetList(int PageIndex, int PageSize, string strSearch, string field);
    } 
}
