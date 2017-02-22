using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using LL.Common;
using System.Data;
using Project.Common;
using LL.IDAL.Member;
using LL.Model.Member;
namespace LL.BLL.Member
{
    public class BLLPhomeENewsQMsg
    {
        private IPhomeENewsQMsg dal =LL.DALFactory.DataAccess.CreateMemberMsg();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(phome_enewsqmsg model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 得到对像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public phome_enewsqmsg GetModel(int id, int userid)
        {
            return dal.GetModel(id, userid);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(phome_enewsqmsg model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="arrID"></param>
        /// <returns></returns>
        public int DeleteAll(List<int> arrID)
        {
            return dal.DeleteAll(arrID);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        public int AddBath(List<phome_enewsqmsg> arrMsg)
        {

            return dal.AddBath(arrMsg);

        }



        /// <summary>
        /// 取到对像,根据信件存储
        /// </summary>
        /// <param name="MessageID"></param>
        /// <param name="username"></param>
        /// <param name="letterSaveType"></param>
        /// <returns></returns>
        public phome_enewsqmsg GetModel(int MessageID, string username  ,  int letterSaveType)
        {

            if (letterSaveType == (int)LL.Common.EnumClass.LetterSaveType.Inbox)
            {
                return dal.GetModelByUserInbox(MessageID, username);
            }
            else
            {

                return dal.GetModelByUserOutbox(MessageID, username);
            }

        }
        /// <summary>
        /// 批量发送站内信
        /// </summary>
        /// <param name="arrRole"></param>
        /// <param name="strEventGroupSendNum"></param>
        /// <param name="strTitle"></param>
        /// <param name="strContent"></param>
        /// <param name="TagUserName"></param>
        /// <returns></returns>
        public int BatchSendByMemberRole(List<int> arrRole, string strEventGroupSendNum, string strTitle, string strContent, string TagUserName)
        {
            string sqlRole = "";

            foreach (int roleID in arrRole)
            {
                if (roleID > 0)
                {
                    sqlRole += string.Format("{0}{1}", PubConstant.Key_Sign_CommaSign, roleID);
                }
            }
            //过滤前后,
            sqlRole = Util.SplitStartEndComma(sqlRole);

            if (string.IsNullOrEmpty(sqlRole))
            {
                return 0;
            }
            else
            {

                //用存储过程,还是
                int intSendNum = Format.DataConvertToInt(strEventGroupSendNum);
                return dal.BatchSendByMemberRole(sqlRole, intSendNum, strTitle, strContent, TagUserName);


            }
        }

        /// <summary>
        /// 得到信息
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="msgType"></param>
        /// <param name="searchType"></param>
        /// <param name="fromUser"></param>
        /// <param name="IsLikeFUser"></param>
        /// <param name="toUser"></param>
        /// <param name="IsLikeToUser"></param>
        /// <param name="keyword"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        public DataSet Select(int PageIndex, int PageSize, string msgType, string searchType, string fromUser, bool IsLikeFUser, string toUser, bool IsLikeToUser, string keyword, string sdate, string edate)
        {
        
            string where=WhereStr(msgType,searchType,fromUser, IsLikeFUser, toUser, IsLikeToUser,keyword,sdate,edate);
            return dal.Select(PageIndex, PageSize, where);
        }

        public int DelAll( string msgType, string searchType, string fromUser, bool IsLikeFUser, string toUser, bool IsLikeToUser, string keyword, string sdate, string edate)
        {
            string where = WhereStr(msgType, searchType, fromUser, IsLikeFUser, toUser, IsLikeToUser, keyword, sdate, edate);
            return dal.DeleteAll(where);
        
        }

        /// <summary>
        /// whedre
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="searchType"></param>
        /// <param name="fromUser"></param>
        /// <param name="IsLikeFUser"></param>
        /// <param name="toUser"></param>
        /// <param name="IsLikeToUser"></param>
        /// <param name="keyword"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        private string WhereStr(string msgType, string searchType, string fromUser, bool IsLikeFUser, string toUser, bool IsLikeToUser, string keyword, string sdate, string edate)
        {
            StringBuilder whereSql = new StringBuilder(" 1=1 ");
            switch (msgType)
            {
                case "1":
                    whereSql.AppendFormat(" and outbox=0");
                    break;
                case "2":
                    whereSql.AppendFormat(" and outbox=1");
                    break;
                case "3":
                    whereSql.AppendFormat(" and issys=1");
                    break;
            }
            ///查询关键词是否为空
            if (!string.IsNullOrEmpty(keyword))
            {
                switch (searchType)
                {
                    case "0":

                        whereSql.AppendFormat(" and  title like '%{0}%' and  msgtext like '%{0}%'  ", keyword);
                        break;
                    case "1":
                        whereSql.AppendFormat(" and  title like '%{0}%'   ", keyword);
                        break;
                    case "2":
                        whereSql.AppendFormat(" and  msgtext like '%{0}%'  ", keyword);
                        break;
                }
            }
            if (!string.IsNullOrEmpty(fromUser))
            {
                if (IsLikeFUser)
                {
                    whereSql.AppendFormat(" and from_username like '%{0}%'", fromUser);
                }
                else
                {
                    whereSql.AppendFormat(" and   from_username='{0}'", fromUser);
                }
            }
            if (!string.IsNullOrEmpty(toUser))
            {

                if (IsLikeToUser)
                {
                    whereSql.AppendFormat(" and to_username like '%{0}%'", toUser);
                }
                else
                {
                    whereSql.AppendFormat(" and to_username='{0}'", toUser);
                }
            }
            if (!string.IsNullOrEmpty(sdate))
            {
                whereSql.AppendFormat(" and msgtime>= ", sdate);
            }
            if (!string.IsNullOrEmpty(edate))
            {
                whereSql.AppendFormat(" and msgtime<= ", edate);
            }
            return whereSql.ToString();
        }


        public int TotalReceiveMsg(int isRead, string  username)
        {

            return dal.TotalReceiveMsg(isRead, username);
        }

        public DataSet GetList(int PageIndex, int PageSize, string where, string p)
        {

            return dal.Select(PageIndex, PageSize, where);
        
        }



        public int SignBoxRead(int MessageID)
        {

            return dal.SignBoxRead(MessageID);
           
        }

        public phome_enewsqmsg GetModel(int MessageID)
        {
            return dal.GetModel(MessageID);
        }
    }
}
