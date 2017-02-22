using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.Model.Member;
using LL.IDAL.Member;
using LL.Common;
using System.Data;
using Project.Common;
namespace LL.BLL.Member
{
    public class BLLMemberWebSiteFriendLink
    {
        private IMemberWebSiteFriendLink dal = LL.DALFactory.DataAccess.CreateMemberWebSiteFriendLink();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(MemberWebSiteFriendLink model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 得到对像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MemberWebSiteFriendLink GetModel(int id)
        {
            return dal.GetModel(id);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(MemberWebSiteFriendLink model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="arrID"></param>
        /// <returns></returns>
        public int DelAll(List<int> arrID)
        {
            return dal.DelAll(arrID);
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


        public List<MemberWebSiteFriendLink> GetMemberFriendLinkByMemberID(int userid)
        {

            return dal.GetMemberFriendLinkByMemberID(userid);
        }






  
    }
}
