using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using System.Data;
using LL.Common.Cache;
using LL.Common;
using LL.BLL.Upload;
using LL.Common.EnumClass;
using LL.BLL;


public partial class fckeditor_editor_dialog_InsertFile_InsertFile : AdminPage
{
    
    private string[] diableExtension = ConfigManager.UploadDisabledExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });


    BLLUploadFile bllUF = new BLLUploadFile();



    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {


            ShowBtn();
        }
   
    }

    private void ShowBtn()
    {

        string t = Request["type"];

        if (!string.IsNullOrEmpty(t))
        {


            btnInsertText.Visible = false;
            btnTitlePic.Visible = true;

        }
        else
        {
            btnInsertText.Visible = true;
            btnTitlePic.Visible = false;
        
        }


    }

    #region 上传文件
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        BLLUploadManager um = new BLLUploadManager();

        um.UploadUser = "Admin:" + base.CurrentLogin.LoginName;
        um.UserID = base.CurrentLogin.ID;


        FileClass fClass = FileClass.OtherFile;
        FileInfoType fType = FileInfoType.Other;


        if (um.UploadFile(up, fClass, fType))
        {
            txtUrl.Text = um.FileUrlAbsolutePath;

     
           
             JsAlert.ShowAlert("上传成功!");
        }
        else
        {
            JsAlert.ShowAlert(um.ErrMsg);
        }
    }
    #endregion




}
