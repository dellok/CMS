using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.Model.Member;
namespace LL.IDAL.Member
{
  
    public interface Iphome_enewsmemberadd
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(phome_enewsmemberadd model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(phome_enewsmemberadd model);

        int UpdateInfo(phome_enewsmemberadd model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int userid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        phome_enewsmemberadd GetModel(int userid);
        /// <summary>
        /// 根据DataRow 返回对像
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        phome_enewsmemberadd GetModelByDataRow(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);

        /// <summary>
        /// 增加一个新会员
        /// 返回:0 程序没添加成功, -1 为异常错误 
        /// </summary>
        /// <param name="modelLogin"></param>
        /// <param name="modelMemberInfo"></param>
        /// <returns></returns>
        int AddNewMember(phome_enewsmember modelLogin, phome_enewsmemberadd modelMemberInfo);

        /// <summary>
        /// 更新会员头像
        /// </summary>
        /// <param name="picPath"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        int UpdateMemberHeadPic(string picPath, int userid);

        /// <summary>
        /// 更新会员公司logo
        /// </summary>
        /// <param name="picPath"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        int UpdateMemberCompanyLogo(string logoPath, int userid);

        /// <summary>
        /// 修改的我空间名称与公告
        /// </summary>
        /// <param name="strSpaceName"></param>
        /// <param name="strSpaceNotice"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        int UpdateSpace(string strSpaceName, string strSpaceNotice, int userid);
        #endregion  成员方法

        int UpdateLoginAndMemberInfo(phome_enewsmember modelLogin, phome_enewsmemberadd modelMemberInfo);

        DataSet GetMemberLoginAndCompanyInfo(int UserID);

        int UpdateCompanyIntro(int userid, string companyintro);

        DataSet GetList(int pageIndex, int pageSize, string strWhere, string filedOrder);
    }
}

