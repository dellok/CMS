using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using LL.Common;
using LL.Common.Cache;

using LL.BLL.AD;

using System.IO;
using LL.Common.EnumClass;
using LL.BLL;
using LL.Model.AD;
using LL.BLL.Upload;

public partial class PageAD_ADEdit : AdminPage
{

    public string adpage = "";
    public string position = "";

    BLLADList bllAD = new BLLADList();
    BLLUploadFile bllUpFile = new BLLUploadFile();

    private string[] allowImgExtension = ConfigManager.UploadImgExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] allowFlashExtension = ConfigManager.UploadFlashExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            BindFileClass();

            ShowADInfo();
        }
    }

    private void ShowADInfo()
    {
        ADList adInfo = bllAD.GetModel(base.GetReqIDValue);

        radioFileClass.SelectedIndex = radioFileClass.Items.IndexOf(radioFileClass.Items.FindByValue(adInfo.FileClass.ToString()));

        txtADName.Text = adInfo.Title;

        ucPage.SetValue = adInfo.Page.Trim();
        adpage = adInfo.Page;
        position = adInfo.Position.Trim();

        ucADPosition.SetValue = adInfo.Position;


        adLink.Text = BindFile(adInfo.FileClass,adInfo.FileUrl);
        txtADUrl.Text = adInfo.Url;
        txtImgPath.Text = adInfo.FileUrl;
        txtSeq.Text = adInfo.Seq.ToString();
        txtAdWidth.Text = adInfo.Width.ToString();
        txtAdHeight.Text = adInfo.Height.ToString();
        txtSDate.Text = adInfo.StartDate.ToString();
        txtEDate.Text = adInfo.EndDate.ToString();
        txtHit.Text = adInfo.Hit.ToString();
        txtRemark.Text = adInfo.Remark;
        cboxChecked.Checked = Format.DataConvertToBool(adInfo.Checked);
        cboxIsRecycle.Checked = Format.DataConvertToBool(adInfo.IsRecycle);



    }
    #region 显示方式

    int width = 160;
    int height = 90;
    public string BindFile(int  fileClass, string  fileUrl)
    {


        string img = "";
        string fExtension = fileUrl.ToString().Substring(fileUrl.ToString().LastIndexOf(PubConstant.Key_Sign_Dot) + 1);
        bool isImage = allowImgExtension.Contains(fExtension);
        bool isFlv = allowFlashExtension.Contains(fExtension);


        txtImgPath.Text = fileUrl;

        if (isFlv)
        {
            img = string.Format("<a href=\"{0}\"> <embed  src=\"{0}\" alt=\"点击查看此文件\"  width=\"{1}\"   height=\"{2}\" /></a>", fileUrl, width, height);

        }
        else if (isImage)
        {
            img = string.Format("<a href=\"{0}\"  alt=\"点击查看此文件\"  target=\"_blank\"> <img  src=\"{0}\" alt=\"\"  style=\"width:{1};height:{2};border:0px;\"/></a>", fileUrl, width, height);
        }
        else
        {

            img = fileUrl.ToString();
        }

        return img;

    }
    #endregion

    protected void BindFileClass()
    {

        //绑定文件类型       
        foreach (int value in Enum.GetValues(typeof(FileClass)))
        {
            string v = value.ToString();
            string name = AliasAttribute.EnumAlias((FileClass)Enum.Parse(typeof(FileClass), v));

            if (name == "图片" || name == "Flash")
            {
                ListItem item = new ListItem(name, v);
                radioFileClass.Items.Add(item);
            }
        }
    }



    #region 上传文件

    private string UploadFile(FileClass fileClass, BLLUploadManager upManager)
    {
        string imgPath = "";
        if (up.HasFile)
        {
            //得到扩展名:
            string extension = System.IO.Path.GetExtension(up.FileName).Replace(PubConstant.Key_Sign_Dot, "");
            bool isExtension = false;

            if (fileClass == FileClass.Image)
            {
                isExtension = allowImgExtension.Contains(extension);
            }
            if (fileClass == FileClass.Flash)
            {
                isExtension = allowFlashExtension.Contains(extension);
            }

            if (isExtension)
            {

                bool isUpOk = upManager.UploadFile(up, fileClass, FileInfoType.AD);

                if (isUpOk)
                {
                    imgPath = upManager.FileUrlAbsolutePath;
                }
                else
                {
                    JsAlert.ShowAlert(upManager.ErrMsg);
                }

            }
            else
            {
                JsAlert.ShowAlert(PubMsg.Msg_Upload_Extenstion_Error);

            }

        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_Upload_NeedInput);

        }
        return imgPath;
    }
    #endregion


    #region
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string strADType = radioFileClass.SelectedValue;
        string strPageName = ucPage.GetValue;
        string strPagePosition = ucADPosition.GetValue;
        string strADName = txtADName.Text.Trim();
        
        string strADUrl = txtADUrl.Text.Trim();
        string strHit = txtHit.Text.Trim();
        string strWidth = txtAdWidth.Text.Trim();
        string strHeight = txtAdHeight.Text.Trim();

        string strSeq = txtSeq.Text.Trim();

        string strSDate = txtSDate.Text.Trim();
        string strEDate = txtEDate.Text.Trim();
        string strRemark = txtRemark.Text.Trim();

        if (cboxIsUpdateImg.Checked)
        {
            if (!up.HasFile)
            {

                JsAlert.ShowAlert("上传文件不能为空!");


            }
        }

        ADList updateAD = bllAD.GetModel(base.GetReqIDValue);
        string imgPath = txtImgPath.Text.Trim();//updateAD.FileUrl;

        BLLUploadManager upManager = new BLLUploadManager();
        string upImgPath = "";
        //开始上传文件
        if (cboxIsUpdateImg.Checked)
        {
             upImgPath = UploadFile((FileClass)Enum.Parse(typeof(FileClass), strADType), upManager);

            //修改上传的文件夹路径
            if (!string.IsNullOrEmpty(upImgPath))
            {
                imgPath = upImgPath;
            } 
        }
    

      
        updateAD.FileClass = Format.DataConvertToInt(strADType);
        updateAD.Page = strPageName;
        updateAD.Position = strPagePosition;
        updateAD.FileUrl = imgPath;
        updateAD.Seq = Format.DataConvertToInt(strSeq);
        updateAD.Title = strADName;
        updateAD.Url = strADUrl;
        updateAD.Width = Format.DataConvertToInt(strWidth);
        updateAD.Height = Format.DataConvertToInt(strHeight);
        updateAD.StartDate = Format.DataConvertToDateTime(strSDate);
        updateAD.EndDate = Format.DataConvertToDateTime(strEDate);
        updateAD.Hit = Format.DataConvertToInt(strHit);

        updateAD.Checked = cboxChecked.Checked;
        updateAD.IsRecycle = cboxIsRecycle.Checked;
        updateAD.Remark = strRemark;

        int intR = bllAD.Update(updateAD);
        
        if (intR > 0)
        {
           

            if (!string.IsNullOrEmpty(upImgPath))
            {
                bllUpFile.SetUploadFileToRecycle(base.GetReqIDValue,(int)FileInfoType.AD);
                LL.Model.Upload.UploadFile upModel = bllUpFile.GetModel(upManager.FileID);
                upModel.NewsID = intR;
                upModel.NewsClassID = 0;
                upModel.UploadUser = string.Format("Admin:{0}", base.CurrentLogin.LoginName);
                upModel.FileInfoType = (int)FileInfoType.AD;
                upModel.FileClass = Format.DataConvertToInt(radioFileClass.SelectedValue);
                bllUpFile.Update(upModel);
        
            }
  

            JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInCurrent, PubMsg.Msg_UpdateSuccess, ReturnAdListParam());
        }
        else
        {

            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }




    }


    private string ReturnAdListParam()
    { 
    

        return string.Format("ADList.aspx?adpage={0}&position={1}",ucPage.GetValue.ToString(),ucADPosition.GetValue);
  
    
    }

    #endregion


    protected void btnDelete_Click(object sender, EventArgs e)
    {

        FileInfo file = new FileInfo(adLink.Text);

        

            
       int intR= bllAD.Delete(base.GetReqIDValue,file.Name);

       if (intR > 0)
       {
           JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInCurrent, PubMsg.Msg_Delete_Success, ReturnAdListParam());
       }
       else
       {
           JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
       }

    }
}