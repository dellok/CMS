using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LL.BLL.AD;
using Project.Common;
using System.Data;
using LL.Common;
using LL.Common.Cache;
using System.IO;
using System.Collections;
using LL.Common.EnumClass;
using System.Text;

public partial class PageAD_ADList : AdminPage
{

  
    private string[] allowImgExtension = ConfigManager.UploadImgExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] allowFlashExtension = ConfigManager.UploadFlashExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] allowMediaExtension = ConfigManager.UploadMediaExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] allowOtherExtension = ConfigManager.UploadOtherExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
    private string[] diableExtension = ConfigManager.UploadDisabledExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });

    BLLADList bllAD = new BLLADList();
    protected void Page_Load(object sender, EventArgs e)
    {
   
        
        if (!Page.IsPostBack)
        {


            this.BindFileClass();
            SetFileClassSelected();
            BindList();
        }
    }
    /// <summary>
    /// 初始化化设置值
    /// </summary>
    protected void SetFileClassSelected()
    {
        ucPage.SetValue = GetReqValue("adpage").Trim();
        ucADPosition.SetValue = GetReqValue("position").Trim();
    }
    protected void BindFileClass()
    {

        ////绑定文件类型       
        foreach (int value in Enum.GetValues(typeof(FileClass)))
        {
            string v = value.ToString();
            string name = AliasAttribute.EnumAlias((FileClass)Enum.Parse(typeof(FileClass), v));
            if (name == "图片" || name == "Flash")
            {
                ListItem item = new ListItem(name, v);
                drplSearchFileType.Items.Add(item);
            }
        }
        ListItem allItem = new ListItem("不限", "0");
        drplSearchFileType.Items.Insert(0, allItem);

    }
    #region 绑定列表

    /// <summary>
    /// 显示信息列表
    /// </summary>
    private void BindList()
    {


        //得到设置查询数据要查询的页面
        ///设置查询页
        string strPage = "";
        string position = "";
            strPage = ucPage.GetValue;
            position = ucADPosition.GetValue;


        string strKeyWord = txtKeyWord.Text.Trim();
        string strSDate = txtSDate.Text.Trim();
        string strEDate = txtEDate.Text.Trim();
        string strZSDate = txtSEndDate.Text.Trim();
        string strZEDate = txtEEndDate.Text.Trim();

       
       

        string strFileType = drplSearchFileType.SelectedValue;
        string strChecked = radioCheckType.SelectedValue;
        string strIsRecycle = RadioButtonList1.SelectedValue;
       

        int PageIndex = pager.CurrentPageIndex;
        int PageSize = pager.PageSize;

        DataSet ds = bllAD.GetList(PageIndex, PageSize, strKeyWord, strPage, position, strSDate, strEDate, strZSDate, strZEDate, strFileType,strIsRecycle, strChecked);

        if (ds.Tables.Count == 2)
        {
                int TotalRecords = 0;
                TotalRecords = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
                pager.RecordCount = TotalRecords;
                dataViewList.DataSource = ds.Tables[0];
                dataViewList.DataBind();
        }
    }
    #endregion


    #region  删除 ，推荐 ,档案, 头条

    string cboxid = "cboxItem";


    /// <summary>
    /// 得到cbox 所选项
    /// </summary>
    /// <returns></returns>

    protected List<int> GetCheckedValues()
    {

        List<int> i = new List<int>();
        Dictionary<int, string> items = PageCommon.GetCheckedKeyValue(cboxid, dataViewList);

        foreach (var item in items)
        {
            i.Add(item.Key);
        }
        return i;


    }

    protected List<string> GetCheckedFileName()
    {
        List<string> i = new List<string>();
        Dictionary<int, string> items = PageCommon.GetCheckedKeyValue(cboxid, dataViewList);

        foreach (var item in items)
        {
            i.Add(item.Value);
        }
        return i;
    
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataViewList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {


        LinkButton btn = dataViewList.Items[e.ItemIndex].FindControl("btnD") as LinkButton;

        int ID = Format.DataConvertToInt(dataViewList.DataKeys[e.ItemIndex].Value);

        
        //得到文件名

        string fileName = btn.CommandArgument;
        DelADFile(fileName);
        bllAD.Delete(ID,fileName);
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

            DelADFile(GetCheckedFileName());
            intR = bllAD.BatchDel(arrIDS,(int)FileInfoType.AD);
        }

        BindList();
        JsAlert.ShowAlert(string.Format("已删除 [{0}] 条记录!", intR));

    }



    
    /// <summary>
    /// 审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchCheck_Click(object sender, EventArgs e)
    {

        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllAD.BatchChecked(arrIDS, 1);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已审核 [{0}] 条记录!", intR));
    }
    /// <summary>
    /// 最消审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchUnCheck_Click(object sender, EventArgs e)
    {
        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllAD.BatchChecked(arrIDS, 0);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已取消审核 [{0}] 条记录!", intR));
    }


    /// <summary>
    /// 放入回收站
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMoveToRecycle_Click(object sender, EventArgs e)
    {
        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllAD.BatchMoveToRecycle(arrIDS, 1);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("操作 [{0}] 条记录!", intR));
    }

    protected void btnUNMoveToRecycle_Click(object sender, EventArgs e)
    {
        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllAD.BatchMoveToRecycle(arrIDS, 0);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("操作 [{0}] 条记录!", intR));
    }
    #endregion
    #region 全选与反向选择

    protected void cbox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbox = (CheckBox)sender;

        bool isChecked = cbox.Checked;

        foreach (ListViewDataItem row in dataViewList.Items)
        {
            CheckBox citem = row.FindControl(cboxid) as CheckBox;
            citem.Checked = isChecked;
        }


        cboxAll.Checked = isChecked;
        cboxAll2.Checked = isChecked;
        reCbox.Checked = false;
    }
    protected void reCbox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbox = (CheckBox)sender;

        bool isChecked = cbox.Checked;

        foreach (ListViewDataItem row in dataViewList.Items)
        {
            CheckBox citem = row.FindControl(cboxid) as CheckBox;

            citem.Checked = !citem.Checked;

        }

        cboxAll.Checked = false;
        cboxAll2.Checked = false;

    }
    #endregion
    #region 分页
    protected void pager_PageChanged(object sender, EventArgs e)
    {
        this.BindList();
    }
    #endregion
    #region 显示方式

    int width = 160;
    int height = 90;
    public string BindFile(object fileClass, object fileUrl,object w,object h)
    {


        int intW = Format.DataConvertToInt(w);
        int intH= Format.DataConvertToInt(h);
        

        intW=intW>0?intW:width;
        intH=intH>0?intH:height;

     
            string img = "";
            string fExtension = fileUrl.ToString().Substring(fileUrl.ToString().LastIndexOf(PubConstant.Key_Sign_Dot) + 1);
            bool isImage = allowImgExtension.Contains(fExtension);
            bool isFlv = allowFlashExtension.Contains(fExtension);
           
            if (isFlv)
            {
                img = string.Format(" <embed  src=\"{0}\" alt=\"点击查看此文件\"  width=\"{1}\"   height=\"{2}\" />", fileUrl, intW, intH);
            }
            else if (isImage)
            {
                img = string.Format("<a href=\"{0}\"  alt=\"点击查看此文件\"  target=\"_blank\"> <img  src=\"{0}\"  class=\"adimg\" alt=\"\"  style='border:0px;'    /></a>", fileUrl);
            }
            else
            {

                img = fileUrl.ToString();
            }

            return img;
     
    }
    #endregion
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindList();
    }
    private string  DelADFile(List<string> arr)
    {
        StringBuilder msg = new StringBuilder();
        foreach (string item in arr)
        {
            msg.AppendFormat("{0}", FileCommon.DelFile(ConfigManager.PhyDir_JsAD + @"\" + item));
        }
        return msg.ToString();
    }
    private string  DelADFile(string  filename)
    {

      return   FileCommon.DelFile(ConfigManager.PhyDir_JsAD+@"\"+filename);
    }
}