using System;
using System.Data;
using LL.Model.Member;
namespace LL.IDAL.Member
{
	/// <summary>
	/// 接口层phome_enewsmember
	/// </summary>
	public interface Iphome_enewsmember
	{
		#region  成员方法

        bool ExistsUserName(int userid, string strUsername);
        /// <summary>
        /// 验证会员Email
        /// userid >0 为修改验证, userid<1 为增加时验证
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        bool ExistsUserEmail(int userid, string email);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(phome_enewsmember model);

        /// <summary>
        /// 修改密码或email
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="strNewPwd"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        int UpdatePwd(int userID, string strNewPwd);

        /// <summary>
        /// 修改Email
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        int UpdateEmail(int userID, string email);

        /// <summary>
        /// 增加一条数据,并返回生成的userid
        /// </summary>
        int Add(phome_enewsmember model);

        /// <summary>
        /// 验证登录，运回 member对像
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        phome_enewsmember Login(string strLoginName, string strPwd);

		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int userid);
		bool DeleteList(string useridlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		LL.Model.Member.phome_enewsmember GetModel(int userid);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
        DataSet GetList(int PageIndex, int PageSize, string where);

        int BatchDelMember(System.Collections.Generic.List<int> arrIDS);

        int BatchCheckedMember(System.Collections.Generic.List<int> arrIDS, int Checked);



        /// <summary>
        /// 验证呢称
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        bool ExistsNickName(int userid, string nickname);

        int SetLoginLastDate(int userid, string lastDate);

        /// <summary>
        /// 会员使用时间
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        int SetMemberUseDate(int userid, DateTime sdate, DateTime edate);

        DataSet GetNewJoinCompany(int TopNum);

        DataSet GetRecommendCompany(int TopNum);

        DataSet GetList(int PageIndex, int PageSize, string where, string orderby);

        DataSet GetLoginAndInfoList(int PageIndex, int PageSize, string p, string p_2);

        int GetMemberRole(int userid);
		#endregion  成员方法

      
    } 
}
