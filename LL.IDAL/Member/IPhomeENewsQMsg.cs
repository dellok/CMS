using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using LL.Model.Member;
namespace LL.IDAL.Member
{
    /// <summary>
    /// 接口层Iphome_enewsqmsg  的摘要说明。
    /// </summary>
    public interface IPhomeENewsQMsg : IBase<phome_enewsqmsg>
    {
        #region  成员方法
     
        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DeleteAll(List<int> arrID);
        phome_enewsqmsg  GetModel(int id,int userid);

        /// <summary>
        /// 从用户收件箱得到信内容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <returns></returns>
         phome_enewsqmsg GetModelByUserInbox(int id, string username);
        /// <summary>
        /// 从用户发件箱得到信内容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="letterSaveType"></param>
        /// <returns></returns>
         phome_enewsqmsg GetModelByUserOutbox(int id, string username);

        int   AddBath(List<phome_enewsqmsg> arrmsg);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
  
       
        #endregion  成员方法

        /// <summary>
        /// 批量发送信息
        /// </summary>
        /// <param name="sqlRole"></param>
        /// <param name="intSendNum"></param>
        /// <param name="strTitle"></param>
        /// <param name="strContent"></param>
        /// <returns></returns>
        int BatchSendByMemberRole(string sqlRole, int intSendNum, string strTitle, string strContent, string TagUserName);

        DataSet  Select(int PageIndex, int PageSize, string p);
        int DeleteAll(string where);

        /// <summary>
        /// 收到信息的总数
        /// isread 
        /// 1,为已读，0,未读,<0 则为全部
        /// </summary>
        /// <param name="isRead"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        int  TotalReceiveMsg(int isRead, string username);

        int SignBoxRead(int MessageID);
    }
}