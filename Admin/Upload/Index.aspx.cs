using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using System.Text;
using LL.Common;
using LL.Common.Cache;
using LL.Common.EnumClass;
using LL.BLL;
public partial class Upload_Index : AdminPage
{
    int UploadNum = 10;
    //提示信息，成功则显示为路径,否则显示有错误信息
    Dictionary<int, string> arrMsg = new Dictionary<int, string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindList();
        }
    }
    #region 绑定数据
    public FileUpload Upload(int i)
     {
         FileUpload up = FileUpload0;
         switch (i)
         {
             case 0:
                 up= FileUpload0;
                 break;
             case 1:
                 up = FileUpload1;
                 break;
             case 2:
                 up = FileUpload2;
                 break;
                   case 3:
               
                 up = FileUpload3;
                 break;
                         case 4:
                 up = FileUpload4;
                 break;
                         case 5:
                 up = FileUpload5;
                 break;
                         case 6:
                 up = FileUpload6;
                 break;
                         case 7:
                 up = FileUpload7;
                 break;
                         case 8:
                 up = FileUpload8;
                 break;
                         case 9:
                 up = FileUpload9;
                 break;
         }
         return up;
    }


    private void BindList()
    {
        //绑定信息类型       
        foreach (object value in Enum.GetValues(typeof(LL.Common.EnumClass.FileInfoType)))
        {
            string name = AliasAttribute.EnumAlias((LL.Common.EnumClass.FileInfoType)Enum.Parse(typeof(LL.Common.EnumClass.FileInfoType), value.ToString()));
            ListItem item = new ListItem(name, value.ToString());
            if (name == "其它") { item.Selected = true; }
            radioFileInfoType.Items.Add(item);
        }
    }
    #endregion
    #region  上传文件
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        FileClass fClass = FileClass.OtherFile;
        FileInfoType fType = (FileInfoType)Enum.Parse(typeof(FileInfoType), radioFileInfoType.SelectedValue);
  
        //不同的类型上传到的站点不同,调用不同的服务
        //是否有文件
        for (int i = 0; i < UploadNum; i++)
        {
            UploadFile(i, Upload(i), fClass, fType);
        }
        ShowUploadMsg();
    }
    /// <summary>
    /// 显示上传到图片站的图片信息
    /// </summary>
    private void ShowUploadMsg()
    {
        StringBuilder htmlMsg = new StringBuilder();
        StringBuilder tempMsg = new StringBuilder();

        string[] arrImgExtension = ConfigManager.UploadImgExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });

        if (arrMsg.Count() > 0)
        {
            for (int i = 0; i < arrMsg.Count(); i++)
            {
                tempMsg.Clear();
                string strMsg = arrMsg[i].ToString();
                if (!string.IsNullOrEmpty(strMsg))
                {
                    string[] upMsg = strMsg.Split(new char[] { PubConstant.Key_Sign_CommaSign });
                    if (upMsg.Length == 2)
                    {
                        if (upMsg[0].ToUpper() == true.ToString().ToUpper())
                        {
                            string uMsg = string.Format("<p><b>上传信息：</b>{0}</p>", "上传文件成功!");
                            string linkUrl = string.Format("{0}", upMsg[1]);
                            string uPath = string.Format("<p><b>文件路径：</b><a href={0} target=_black>{0}</a></p>", linkUrl);
                            string sFile = "";

                            tempMsg.Append("'");
                            tempMsg.Append(uMsg);

                            tempMsg.Append(uPath);
                            tempMsg.Append(sFile);
                            tempMsg.Append("'");
                        }
                    }
                    else
                    {
                        string uMsg = string.Format("'<p><b>上传信息：</b>{0}</p>'", upMsg[0]);
                        tempMsg.Append(uMsg);
                    }
                }
                else
                {
                    string uMsg = string.Format("'<p><b>上传信息：</b>{0}</p>'", "空信息!");
                    tempMsg.Append(uMsg);
                }
                htmlMsg.AppendFormat("$('#divm{0}').html({1});", i.ToString(), tempMsg.ToString());
            }
        }
        Project.Common.JsAlert.WriteJs(htmlMsg.ToString(), false);
    }
    /// <summary>
    /// 判断是否为img
    /// </summary>
    /// <param name="linkUrl"></param>
    /// <returns></returns>
    private bool CheckImg(string linkUrl, string[] arrImgExtension)
    {





        int len = linkUrl.LastIndexOf(PubConstant.Key_Sign_Dot);
        int lenttotal = linkUrl.Length;
        string ext = linkUrl.Substring(len);
        return arrImgExtension.Contains(ext);
    }
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="i"></param>
    /// <param name="ImgRootPath"></param>
    /// <param name="up"></param>
    /// <param name="fileUpload"></param>
    /// <param name="fClass"></param>
    /// <param name="fType"></param>
    private void UploadFile(int i,  FileUpload fileUpload, FileClass fClass, FileInfoType fType)
    {
        if (fileUpload.HasFile)
        {
            BLLUploadManager up = new BLLUploadManager();
            up.UserID = base.CurrentLogin.ID;
            up.UploadUser = "Admin:" + base.CurrentLogin.LoginName;
            up.UploadUserRole = 16;//admin类型会员
            bool isUpOk = up.UploadFile(fileUpload, fClass, fType);
            if (isUpOk)
            {
                arrMsg.Add(i, string.Format("{0}{1}{2}", up.IsUploadSuccess, PubConstant.Key_Sign_CommaSign, up.FileUrlAbsolutePath));
            }
            else
            {
                arrMsg.Add(i, string.Format("{0}{1}<font  style='color:red'>{2}</font>", "上传出错:", PubConstant.Key_Sign_CommaSign, up.ErrMsg));
            }
        }

    }
    #endregion

}