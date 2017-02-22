using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

using LL.BLL.Admin;
using LL.Common;
using LL.BLL.Member;
using Project.Common;
using System.Data;
using LL.Common.EnumClass;


public partial class Member_MemberList : AdminPage
{
    BLLphome_enewsmembergroup bllMemberGoroup = new BLLphome_enewsmembergroup();
    BLLphome_enewsmember bllLogin = new BLLphome_enewsmember();
    BLLphome_enewsmemberadd bllMemberInfo = new BLLphome_enewsmemberadd();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetGroupSelected();
            BindList();

        }
    }

    #region  增加会员



    public void SetGroupSelected()
    {

        string gid = Request["groupid"];
        ucMemberGroupList.SetValue = gid;
    }

    /// <summary>
    /// 绑定列表
    /// </summary>
    public void BindList()
    {
        string loginName = txtLoginName.Text.Trim();
        string email = txtEmail.Text.Trim();



        int groupID = Format.DataConvertToInt(ucMemberGroupList.GetValue);
        int mcheck = Format.DataConvertToInt(drplMemberCheck.SelectedValue);



        int PageIndex = pager.CurrentPageIndex;

        int PageSize = pager.PageSize;

        DataSet ds = bllLogin.GetList(PageIndex, PageSize, loginName,email, groupID, mcheck);



        if (ds.Tables.Count == 2)
        {
            int TotalRecords = 0;

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
            else
            {

              
                dataViewList.DataSource = null;
                dataViewList.DataBind();
                JsAlert.ShowAlert("没有符合条件的记录!");
               
            }

        }
    }
    #endregion

    #region 修改，删除   ,编辑
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataViewList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        int ID = Format.DataConvertToInt(dataViewList.DataKeys[e.ItemIndex].Value);
       bllLogin.Delete(ID);
       BindList(); 
        JsAlert.ShowAlert("删除成功!");
     
       
    }

    #endregion
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }


    #region 批量删除数据


    protected void btnBatchCheck_Click(object sender, EventArgs e)
    {

        string cboxid = "cboxItem";
        int intR = 0;
        List<int> arrIDS = PageCommon.GetCheckedValues(cboxid, dataViewList);
        if (arrIDS.Count() > 0)
        {

            intR = bllLogin.BatchCheckedMember(arrIDS, 1);

        }

        BindList();
        JsAlert.ShowAlert(string.Format("已审核 [{0}] 条记录!", intR));



    }
    protected void btnBatchDelete_Click(object sender, EventArgs e)
    {
        string cboxid = "cboxItem";
        int intR = 0;
        List<int> arrIDS = PageCommon.GetCheckedValues(cboxid, dataViewList);
        if (arrIDS.Count() > 0)
        {

            intR = bllLogin.BatchDelMember(arrIDS);
        }

        BindList();
        JsAlert.ShowAlert(string.Format("已删除 [{0}] 条记录!", intR));

    }

    protected void btnBatchUnCheck_Click(object sender, EventArgs e)
    {
        string cboxid = "cboxItem";
        int intR = 0;
        List<int> arrIDS = PageCommon.GetCheckedValues(cboxid, dataViewList);
        if (arrIDS.Count() > 0)
        {
            intR = bllLogin.BatchCheckedMember(arrIDS, 0);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已取消审核 [{0}] 条记录!", intR));
    }
    #endregion

    

    protected void pager_PageChanged(object sender, EventArgs e)
    {
        this.BindList();
    }
    public string BindWebSiteUrl(object uid, object gid)
    {
        Array arrGroupID = Enum.GetValues(typeof(WebSiteMemberGroupID));
        string url = uid.ToString();
        foreach (int item in arrGroupID)
        {
            if (item.ToString() == gid.ToString())
            {
                url = string.Format("<a href=\"/Vipsite/index.aspx?{0}={1}\" title=\"点击进入会员网站管理\">{2}</a>", "u", uid, uid);
                break;
            }


        }

        return url;
    }

}