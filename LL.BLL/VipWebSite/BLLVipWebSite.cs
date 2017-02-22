using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.BLL.Member;
using LL.BLL.News;
using System.Data;
using LL.BLL.Upload;
using LL.Model.Member;
using LL.Model.News;
namespace LL.BLL.VipWebSite
{
        public class BLLVipWebSite
    {
   
        BLLphome_enewsmember bllLogin = new BLLphome_enewsmember();
        BLLphome_enewsmemberadd bllMemberInfo = new BLLphome_enewsmemberadd();
          BLLUploadFile bllUp = new BLLUploadFile();

        #region 公司简介
        /// <summary>
        /// 得到公司简介
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetMemberCompanyIntro(int userid)
        {
            string comintro = "";
            phome_enewsmemberadd membeInfo = bllMemberInfo.GetModel(userid);
            if (membeInfo != null)
            {
                comintro = membeInfo.saytext;
            }
            return comintro;
        }

        public int UpdateMemberCompanyIntro(int userid, string companyintro)
        {

            return bllMemberInfo.UpdateCompanyIntro(userid,companyintro);
        }

        #endregion

        public List<MemberWebSiteFriendLink> GetMemberWebSiteFriendLinkByMemberID(int userid)
        {
            BLLMemberWebSiteFriendLink bllLink = new BLLMemberWebSiteFriendLink();
            return bllLink.GetMemberFriendLinkByMemberID(userid);
        }


        ///// <summary>
        ///// 得到会员电子样本新闻
        ///// </summary>
        ///// <param name="userid"></param>
        ///// <returns></returns>
        //public DataSet GetMemberDMFile(int userid, int topNum)
        //{
        //   // bllNews = new BLLPhomeECmsNews();
        //    string where = string.Format(" userid={0} and classid={1}", userid, (int)CLB.Common.Enum.VipWebSiteItemClassID.电子样本);
        //    DataSet ds=    bllNews.GetList(1, 10,  where);
        //    return ds;
        //}



        //public DataSet GetWuLuProductList(int PageIndex, int PageSize, int  UserID, int ClassID, int FileInfoType)
        //{
          
        //    return bllUp.GetVipMemberPic(PageIndex,PageSize,UserID,ClassID,FileInfoType);
        //}
        
    }
}
