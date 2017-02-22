using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.BLL.Upload;
using DBUtility;
using System.Data;
using LL.Common.Cache;
using LL.Common.EnumClass;
using LL.Common;
using Project.Common;
using LL.Model;
using LL.BLL.Member;
using System.IO;
using LL.Model.Member;
using LL.Model.Upload;
using LL.BLL;
public partial class Member_VipWebSite_CompanyBanner:AdminPage
{
      
    BLLUploadFile bllUpFile = new BLLUploadFile();

    BLLphome_enewsmemberadd bllMember = new BLLphome_enewsmemberadd();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindBannerInfo();            
        }
    }

    protected void BindBannerInfo()
    {
        phome_enewsmemberadd member = bllMember.GetModel(GetReqMemberID);

        if (member!=null)
        {
            SetWebSiteBanner(member.gslogo);
        }
      
    }
    private void SetWebSiteBanner(string imgPath)
    {
        imgEdit.Text = string.Format("<a href=\"{0}\"  target=\"_blank\"><img src=\"{0}\"  style='border:0px;'/></a>", imgPath);
    }
    protected void btnModeif_Click(object sender, EventArgs e)
    {
        BLLUploadManager upManager = new BLLUploadManager();
        //开始上传文件 
        int NewsClassID = (int)LL.Common.EnumClass.VipSiteItemsClassID.网站Banner;
        string title = LL.Common.EnumClass.VipSiteItemsClassID.网站Banner.ToString();


        //开始上传文件,并存储文件到uploadfile 数据表中
        upManager.NewsClassID = NewsClassID;
        upManager.UploadUser = string.Format("Admin:LL编辑-{0}", LoginID);
        upManager.FileInfoType = (int)FileInfoType.MemberCompanyBanner;
        upManager.FileClass = (int)FileClass.Image;
        upManager.UserID = GetReqMemberID;

        if (!string.IsNullOrEmpty(hideID.Value))
        {

          int id = Format.DataConvertToInt(hideID.Value);
          UploadFile  fileModel=bllUpFile.GetModel(id);
          upManager.UploadUser = string.Format("Admin:LL编辑-{0}", LoginID);
          upManager.UploadFileModify(up, FileClass.Image, FileInfoType.MemberCompanyBanner, fileModel);

        
         if (!upManager.IsUploadSuccess)
          {

              JsAlert.ShowAlert(upManager.ErrMsg);
          }

         }
        else
        {
            AddAd(upManager);
            UpdateMemberGsLogo(GetReqMemberID, upManager.FileUrlAbsolutePath);
            BindBannerInfo();
        }

     
    


    }

    private void UpdateMemberGsLogo(int userid,string strLogoPath)
    {

        bllMember.UpdateCompanyLogo(userid,strLogoPath);



    }
    private void AddAd(BLLUploadManager upManager)
    {    
        upManager.UploadUserRole = GetReqMemberGroupID;

        string imgPath = Upload.VipUploadFile(FileClass.Image, FileInfoType.MemberCompanyBanner, upManager, up);
        if (!string.IsNullOrEmpty(imgPath))
        {



            SetWebSiteBanner(imgPath);
            JsAlert.ShowAlert(PubMsg.Msg_AddSuccess);
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_Upload_Error);
        }
    }




}