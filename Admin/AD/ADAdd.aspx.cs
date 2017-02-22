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
using Project.Common;
using System.Net;
using LL.Common.EnumClass;
using LL.BLL;
using LL.BLL.Upload;
using LL.Model.AD;
public partial class PageAD_ADAdd : AdminPage
{

    public string page = "";
   public  string position = "";
   public  int seq = 1;

    BLLADList bllAD = new BLLADList();
    BLLUploadFile bllUpFile = new BLLUploadFile();

    private string[] allowedImgExtension = ConfigManager.UploadImgExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] allowFlashExtension = ConfigManager.UploadFlashExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            BindFileClass();

    
        }
    }



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
                radioFileClass.SelectedIndex = 0;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        AddAd(1);
     

    }


    private void AddAd(int t)
    {
        string strADType = radioFileClass.SelectedValue;

        string strPageName = ucADPage.GetValue;
        string strPagePosition = ucADPosition.GetValue;
        string strADName = txtADName.Text.Trim();
        string strADUrl = txtADUrl.Text.Trim();
        string strHit = txtHit.Text.Trim();
        string strWidth = txtAdWidth.Text.Trim();
        string strHeight = txtAdHeight.Text.Trim();

        string strSeq = txtSeq.Text.Trim();


        string strSDate = txtSDate.Text.Trim();
        if (string.IsNullOrEmpty(strSDate))
        {
            strSDate = DateTime.Now.ToString();
        }
        string strEDate = txtEDate.Text.Trim();
        if (string.IsNullOrEmpty(strEDate))
        {
            strEDate = DateTime.Now.AddYears(3).ToString();
        }
        string strRemark = txtRemark.Text.Trim();
        //开始上传文件
        BLLUploadManager upManager = new BLLUploadManager();


        FileClass fClass = (FileClass)Enum.Parse(typeof(FileClass), strADType);


        string imgPath = UploadFile(fClass, upManager);
        int UpFileID = upManager.FileID;


        ADList newAD = new ADList();
        newAD.FileClass = Format.DataConvertToInt(strADType);
        newAD.Page = strPageName;
        newAD.Position = strPagePosition;
        newAD.FileUrl = imgPath;
         seq = Format.DataConvertToInt(strSeq);
        newAD.Seq = seq > 0 ? seq : 1;
        newAD.Title = strADName;
        newAD.Url = strADUrl;
        newAD.Width = Format.DataConvertToInt(strWidth);
        newAD.Height = Format.DataConvertToInt(strHeight);
        newAD.StartDate = Format.DataConvertToDateTime(strSDate);
        newAD.EndDate = Format.DataConvertToDateTime(strEDate);
        newAD.Hit = Format.DataConvertToInt(strHit);
        newAD.InDate = DateTime.Now;
        newAD.Remark = strRemark;
        newAD.Checked = cboxChecked.Checked;

        if (!string.IsNullOrEmpty(imgPath))
        {

            int intR = bllAD.Add(newAD);
            page = newAD.Page;
            position = newAD.Position;
            seq = newAD.Seq;

            if (intR > 0)
            {

                if (UpFileID>0)
                {
                    
            
                LL.Model.Upload.UploadFile upModel = bllUpFile.GetModel(upManager.FileID);
                
                upModel.NewsID = intR;
                upModel.NewsClassID = 0;
                upModel.UploadUser = string.Format("Admin:{0}", base.CurrentLogin.LoginName);
                upModel.FileInfoType = (int)FileInfoType.AD;
                upModel.FileClass = Format.DataConvertToInt(radioFileClass.SelectedValue);
                bllUpFile.Update(upModel);
                }

             
                //调用修改广告缓存
                SEO.CreateADJs(newAD.Page, newAD.Position, newAD.Seq.ToString());
            

                //添加成功后返回广告列表页
                if (t == 1)
                {
                    ReturnAdList();
                }
                else
                {

                    JsAlert.ShowAlert(PubMsg.Msg_AddSuccess);
                }

            }
            else
            {

                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }
        }
        else
        {

            JsAlert.ShowAlert(PubMsg.Msg_Upload_Error);

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
                isExtension = allowedImgExtension.Contains(extension);
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
             
            //检查外部引用图片路径是否有值

            string outFileUrl=txtAdFilePath.Text.Trim();
            if (!string.IsNullOrEmpty(outFileUrl))
            {

                imgPath = outFileUrl;
            }
            else
            {
                JsAlert.ShowAlert("请上传或输入广告需要的图片或Flash?");
            }


        

        }
        return imgPath;
    }
    #endregion



    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        AddAd(0);

    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        ReturnAdList();
            
    }


    private void ReturnAdList()
    {
        string returnUrl = "ADList.aspx?adpage=" + ucADPage.GetValue + "&position=" + ucADPosition.GetValue;
        Response.Redirect(returnUrl);
      

    }
}