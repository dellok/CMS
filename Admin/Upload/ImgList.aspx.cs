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


public partial class ImgList : AdminPage
{
    private string[] allowImgExtension = ConfigManager.UploadImgExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] allowFlashExtension = ConfigManager.UploadFlashExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] allowMediaExtension = ConfigManager.UploadMediaExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] allowOtherExtension = ConfigManager.UploadOtherExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] diableExtension = ConfigManager.UploadDisabledExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });


    BLLUploadFile bllUF = new BLLUploadFile();

    private readonly string RadioItemSearchAll = "-1";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BindRadioList();
            BindList();


        }
    }






    #region 显示图片

    private void BindRadioList()
    {
       // ListItem allItem = new ListItem("--查询全部--", RadioItemSearchAll);
        //绑定文件类型       
        //foreach (int value in Enum.GetValues(typeof(FileClass)))
        //{
        //    string v = value.ToString();
        //    string name = AliasAttribute.EnumAlias((row.Common.Enum.FileClass)Enum.Parse(typeof(row.Common.Enum.FileClass), v));
        //    ListItem item = new ListItem(name, v);
        //    // if (name == "图片") { item.Selected = true; }
        //    radioFileClass.Items.Add(item);
        //}
        //radioFileClass.Items.Add(allItem);


        //绑定信息类型       
        foreach (int value in Enum.GetValues(typeof(LL.Common.EnumClass.FileInfoType)))
        {
            string v = value.ToString();
            string name = AliasAttribute.EnumAlias((LL.Common.EnumClass.FileInfoType)Enum.Parse(typeof(LL.Common.EnumClass.FileInfoType), v));
            ListItem item = new ListItem(name, v);
            if (name == "新闻") { item.Selected = true; }
            radioFileInfoType.Items.Add(item);
        }
       // radioFileInfoType.Items.Add(allItem);

       // allItem.Selected = true;
    }
    private void BindList()
    {

        int fClass =Format.DataConvertToInt(radioFileInfoType.SelectedValue);
        int fType = Format.DataConvertToInt(radioFileInfoType.SelectedValue);


        int PageIndex = pager.CurrentPageIndex; ;
        int PageSize = pager.PageSize;
        int TotalRecords = 0;
        DataSet ds = bllUF.GetList(PageIndex, PageSize, fClass, fType);

        if (ds.Tables.Count == 2)
        {


            if (ds.Tables[1].Rows.Count > 0)
            {
                TotalRecords = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
            }

            pager.RecordCount = TotalRecords;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dataViewList.DataSource = ds.Tables[0];
                dataViewList.DataBind();
            }

        }
    }

    #endregion

    #region 上传文件
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        BLLUploadManager um = new BLLUploadManager();

        um.UploadUser ="Admin:"+base.CurrentLogin.LoginName;
        um.UserID = base.CurrentLogin.ID;
      

 

        FileClass fClass = FileClass.OtherFile;//(FileClass)Enum.Parse(typeof(FileClass), fclass);
        FileInfoType fType = FileInfoType.News;

    
        if (um.UploadFile(up, fClass, fType))
        {

            //lblUpPath.Text = string.Format("<a href=\"{0}\" target='_blank'>{0}</a>", um .FileUrlAbsolutePath);
          
            
            JsAlert.ShowAlert("上传成功!");
        }
        else
        {
            JsAlert.ShowAlert(um.ErrMsg);
        }
        BindList();
    }
    #endregion
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }
    #region

    int width = 200;
    int height = 150;
    public string BindFile( object fDir,object fName,object fileInfoType)
    {

        if (fDir != null && fName != null && fileInfoType != null)
        {




            string img = "";
            string fExtension = fName.ToString().Substring(fName.ToString().LastIndexOf(PubConstant.Key_Sign_Dot) + 1);


            bool isImage = allowImgExtension.Contains(fExtension);
            bool isFlv = allowFlashExtension.Contains(fExtension);
            bool isMedia = allowMediaExtension.Contains(fExtension);
            bool isDisabled = diableExtension.Contains(fExtension);

            string fPath = string.Format("{0}{1}{2}", ConfigManager.ImgDomin, fDir, fName);

            if (isFlv || isMedia)
            {
                img = string.Format(" <embed  src=\"{0}\" alt=\"点击查看此文件\"  width=\"{1}\"   height=\"{2}\" />", fPath, width, height);

            }
            else if (isImage)
            {
                img = string.Format("<a href=\"{0}\"  alt=\"点击查看此文件\"  target=\"_blank\"> <img  src=\"{0}\" alt=\"\"  style=\"width:{1}px;height:{2}px;border:0px;\"/></a>", fPath, width, height);
            }
            else
            {
                if (isDisabled)
                {
                    img = string.Format("<font  style='color:red'>危险的文件类型【<b>{0}</b>】,建议删除!</font>", fExtension);
                }
                else
                {
                    img = string.Format(" <a  href=\"{0}\" alt=\"点击查询文件\"  target=\"_blank\">【<b>{1}</b>】类型</a>", fPath, fExtension);
                }
            }
            return img;
        }
        else
        {

            return "无数据";
        
        }
    }
    #endregion
        protected void pager_PageChanged(object sender, EventArgs e)
    {
        BindList();
    }

    #region  删除 ，推荐 ,档案, 头条

    string cboxid = "cboxItem";


    /// <summary>
    /// 得到cbox 所选项
    /// </summary>
    /// <returns></returns>

    protected List<int> GetCheckedValues()
    {

        return PageCommon.GetCheckedValues(cboxid, dataViewList);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataViewList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        int ID = Format.DataConvertToInt(dataViewList.DataKeys[e.ItemIndex].Value);
        bllUF.Delete(ID);
        BindList();
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchDelete_Click(object sender, EventArgs e)
    {

        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllUF.BatchDel(arrIDS);
        }

        BindList();
        JsAlert.ShowAlert(string.Format("已删除 [{0}] 条记录!", intR));

    }

 

    #endregion
  

}
