using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.Model.Member;
using System.Data;


namespace LL.IDAL.Member
{
 public     interface IMemberWebSiteFriendLink
    {

        int Add(MemberWebSiteFriendLink model);

        int Update(MemberWebSiteFriendLink model);

        int Delete(int id);

         /// <summary>
         /// 审核 会员网站友情连接
        /// </summary>
        /// <param name="arrIDs"></param>
        /// <returns></returns>
        int CheckedMemberFriendLink(List<int> arrIDs,bool  chd);

        MemberWebSiteFriendLink GetModel(int id);
        int DelAll(List<int> arrID);

        List<MemberWebSiteFriendLink> GetMemberFriendLinkByMemberID(int userid);
   

          DataSet GetList(int PageIndex, int PageSize,string strWhere);
   
 }
}
