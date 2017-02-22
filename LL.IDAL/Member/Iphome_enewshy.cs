using System;
using System.Data;
using LL.Model.Member;
namespace LL.IDAL.Member
{
	/// <summary>
	///我的好友
	/// </summary>
	public interface Iphome_enewshy
	{
		#region  成员方法
	
		int Add(phome_enewshy model);
	
		int Update(phome_enewshy model);
		
		int Delete(int id);

		phome_enewshy GetModel(int id);
        phome_enewshy GetModel(int id,int userid);
		DataSet GetList(string strWhere);

		DataSet GetList(int PageIndex,int PageSize,string strWhere,string filedOrder);
	
		#endregion  成员方法

        phome_enewshy GetModelByDataRow(DataRow dataRow);

        bool ExistsCName(string cname, int  userid, int fid);

        int Delete(int id, int userid);
    } 
}
