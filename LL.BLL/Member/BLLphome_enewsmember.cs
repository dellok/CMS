using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;
using LL.Model.Member;
using LL.DALFactory;
using LL.IDAL.Member;
using System.Text;
namespace LL.BLL.Member
{
    /// <summary>
    /// 业务逻辑类phome_enewsmember 的摘要说明。
    /// </summary>
    public class BLLphome_enewsmember
    {
        private readonly Iphome_enewsmember dal = LL.DALFactory.DataAccess.Createphome_enewsmember();
        public BLLphome_enewsmember()
        { }
        #region  成员方法
       /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(phome_enewsmember model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(phome_enewsmember model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// 删除登录信息，删除基本信息
        /// </summary>
        public void Delete(int userid)
        {
            dal.Delete(userid);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public phome_enewsmember GetModel(int userid)
        {

            return dal.GetModel(userid);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<phome_enewsmember> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<phome_enewsmember> DataTableToList(DataTable dt)
        {
            List<phome_enewsmember> modelList = new List<phome_enewsmember>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                phome_enewsmember model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new phome_enewsmember();
                    if (dt.Rows[n]["userid"].ToString() != "")
                    {
                        model.userid = int.Parse(dt.Rows[n]["userid"].ToString());
                    }
                    model.username = dt.Rows[n]["username"].ToString();
                    model.password = dt.Rows[n]["password"].ToString();
                    model.rnd = dt.Rows[n]["rnd"].ToString();
                    model.email = dt.Rows[n]["email"].ToString();
                    if (dt.Rows[n]["registertime"].ToString() != "")
                    {
                        model.registertime = DateTime.Parse(dt.Rows[n]["registertime"].ToString());
                    }
                    if (dt.Rows[n]["groupid"].ToString() != "")
                    {
                        model.groupid = int.Parse(dt.Rows[n]["groupid"].ToString());
                    }
                    if (dt.Rows[n]["userfen"].ToString() != "")
                    {
                        model.userfen = int.Parse(dt.Rows[n]["userfen"].ToString());
                    }
                    if (dt.Rows[n]["userdate"].ToString() != "")
                    {
                        model.userdate =dt.Rows[n]["userdate"].ToString();
                    }
                    if (dt.Rows[n]["money"].ToString() != "")
                    {
                        model.money = decimal.Parse(dt.Rows[n]["money"].ToString());
                    }
                    model.todaydate = dt.Rows[n]["todaydate"].ToString();
                    if (dt.Rows[n]["todaydown"].ToString() != "")
                    {
                        model.todaydown = int.Parse(dt.Rows[n]["todaydown"].ToString());
                    }
                    if (dt.Rows[n]["zgroupid"].ToString() != "")
                    {
                        model.zgroupid = int.Parse(dt.Rows[n]["zgroupid"].ToString());
                    }
                    if (dt.Rows[n]["havemsg"].ToString() != "")
                    {
                        model.havemsg = int.Parse(dt.Rows[n]["havemsg"].ToString());
                    }
                    if (dt.Rows[n]["checked"].ToString() != "")
                    {
                        model.@checked = int.Parse(dt.Rows[n]["checked"].ToString());
                    }
                  
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

        #endregion  成员方法

        public phome_enewsmember Login(string strLoginName, string strPwd)
        {

            return dal.Login(strLoginName, strPwd);

        }


        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="strUsername"></param>
        /// <returns></returns>
        public bool ExistsUserName(string strUsername)
        {
            return dal.ExistsUserName(0, strUsername);
        }
        /// <summary>
        /// 验证登录名是否已使用
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="strUsername"></param>
        /// <returns></returns>
        public bool ExistsUserName(int userid, string strUsername)
        {
            return dal.ExistsUserName(userid, strUsername.Trim());
        }



        /// <summary>
        /// 验证登录名是否已使用
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="strUsername"></param>
        /// <returns></returns>
        public bool ExistsNickName(int userid, string strUsername)
        {
            return dal.ExistsNickName(userid, strUsername.Trim());
        }

        public bool ExistsNickName(string strNickName)
        {
            return ExistsNickName(0, strNickName);

        }


        /// <summary>
        /// 验证Email名是否已使用
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="strUsername"></param>
        /// <returns></returns>
        public bool ExistsUserEmail(int userid, string email)
        {
            return dal.ExistsUserEmail(userid, email.Trim());
        }

        /// <summary>
        /// 更新密码或Email
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="strNewPwd"></param>
        /// <param name="email"></param>
        /// <returns></returns>

        public int UpdatePwd(int userID, string strNewPwd)
        {


            return dal.UpdatePwd(userID, strNewPwd);



        }
        /// <summary>
        /// Email
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="strNewPwd"></param>
        /// <param name="email"></param>
        /// <returns></returns>

        public int UpdateEmail(int userID, string email)
        {


            return dal.UpdateEmail(userID, email);



        }


        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="loginName"></param>
        /// <param name="groupID"></param>
        /// <param name="mcheck"></param>
        /// <returns></returns>

        public DataSet GetList(int PageIndex, int PageSize, string loginName, string email, int groupID, int mcheck)
        {
            return GetList(PageIndex, PageSize, loginName, -1, groupID, email, mcheck);

        }
        public DataSet GetList(int PageIndex, int PageSize, string loginName, int groupID, int mcheck)
        {

            return GetList(PageIndex, PageSize, loginName, 0, groupID, "", mcheck);
        }


        public DataSet GetList(int PageIndex, int PageSize, string loginName, int userid, int groupID, string email, int mcheck)
        {
            StringBuilder where = new StringBuilder(" 1=1 ");
            if (!string.IsNullOrEmpty(loginName))
            {

                where.AppendFormat(" and  username like '%{0}%'", loginName);

            }

            if (userid > 0)
            {

                where.AppendFormat(" and userid={0}", userid);
            }
            if (groupID > 0)
            {
                where.AppendFormat(" and  groupid={0}", groupID);
            }

            if (!string.IsNullOrEmpty(email))
            {
                where.AppendFormat(" and email like'%{0}%'", email);

            }
            if (mcheck >= 0)
            {

                where.AppendFormat(" and  checked={0}", mcheck);
            }



            return dal.GetList(PageIndex, PageSize, where.ToString(), " registertime desc ");

        }

        public DataSet GetList(int PageIndex, int PageSize, string loginName, int userid, string groupID, int mcheck)
        {
            StringBuilder where = new StringBuilder(" 1=1 ");
            if (!string.IsNullOrEmpty(loginName))
            {

                where.AppendFormat(" and  username like '%{0}%'", loginName);

            }

            if (userid > 0)
            {

                where.AppendFormat(" and userid={0}", userid);
            }
            if (!string.IsNullOrEmpty(groupID))
            {
                where.AppendFormat(" and  groupid in ({0})", groupID);
            }

            if (mcheck >= 0)
            {

                where.AppendFormat(" and  checked={0}", mcheck);
            }



            return dal.GetList(PageIndex, PageSize, where.ToString(), " registertime desc ");

        }


        public DataSet GetLoginAndInfoList(int PageIndex, int PageSize, string loginName, int userid, string groupID, int mcheck)
        {

            StringBuilder where = new StringBuilder(" 1=1 ");
            if (!string.IsNullOrEmpty(loginName))
            {

                where.AppendFormat(" and  l.username like '%{0}%'", loginName);

            }

            if (userid > 0)
            {

                where.AppendFormat(" and l.userid={0}", userid);
            }
            if (!string.IsNullOrEmpty(groupID))
            {
                where.AppendFormat(" and  l.groupid in ({0})", groupID);
            }

            if (mcheck >= 0)
            {

                where.AppendFormat(" and  l.checked={0}", mcheck);
            }



            return dal.GetLoginAndInfoList(PageIndex, PageSize, where.ToString(), " registertime desc ");


        }


        public DataSet GetList(int PageIndex, int PageSize, string where, string orderby)
        {

            return dal.GetList(PageIndex, PageSize, where, orderby);

        }
        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <param name="Checked"></param>
        /// <returns></returns>
        public int BatchCheckedMember(List<int> arrIDS, int Checked)
        {

            return dal.BatchCheckedMember(arrIDS, Checked);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <returns></returns>
        public int BatchDelMember(List<int> arrIDS)
        {

            return dal.BatchDelMember(arrIDS);
        }


        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="lastDate"></param>
        /// <returns></returns>
        public int SetLoginLastDate(int userid, string lastDate)
        {
            return dal.SetLoginLastDate(userid, lastDate);
        }


        /// <summary>
        /// 最新加入
        /// </summary>
        /// <param name="TopNum"></param>
        /// <returns></returns>
        public DataSet GetNewJoinCompany(int TopNum)
        {

            return dal.GetNewJoinCompany(TopNum);
        }

        /// <summary>
        ///推荐企业
        /// </summary>
        /// <param name="TopNum"></param>
        /// <returns></returns>
        public DataSet GetRecommendCompany(int TopNum)
        {

            return dal.GetRecommendCompany(TopNum);

        }




        public int GetMemberRole(int userid)
        {
            return dal.GetMemberRole(userid);
        }
    }
}

