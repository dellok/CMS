using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.BLL.Member;

using LL.BLL.Popedom;
using LL.BLL.Admin;
using LL.Common;
using System.Data;
using Project.Common;

public partial class Send_DelMsg : AdminPage
{

    BLLAdminRole bllAdminRole = new BLLAdminRole();
    BLLphome_enewsmember bllMember = new BLLphome_enewsmember();
    BLLPhomeENewsQMsg bllMsg = new BLLPhomeENewsQMsg();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            BindList();
        }

    }





    protected void btnSearch_Click(object sender, EventArgs e)
    {

        BindList();


    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    private void BindList()
    {
        string msgType = drplMsgType.SelectedValue;

        string searchType = drplKeyWordType.SelectedValue;

        string fromUser = txtFromUser.Text.Trim();
        string toUser = txtToUser.Text.Trim();

        string keyword = txtKeyWord.Text.Trim();

        string sdate = txtStart.Text.Trim();
        string edate = txtEnd.Text.Trim();

        int PageIndex = pager.CurrentPageIndex;
        int PageSize = pager.PageSize;

        DataSet ds = bllMsg.Select(PageIndex, PageSize, msgType, searchType, fromUser, cboxFrom.Checked, toUser, cboxToUser.Checked, keyword, sdate, edate);
        int rows = 0;

        if (ds.Tables.Count > 0)
        {
            dataViewList.DataSource = ds.Tables[0];
            dataViewList.DataBind();

            if (ds.Tables[1].Rows.Count > 0)
            {
                rows = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
            }
            pager.RecordCount = rows;
        }
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchDelete_Click(object sender, EventArgs e)
    {
        List<int> IDS = PageCommon.GetCheckedValues("cboxItem", dataViewList);

        if (IDS.Count() > 0)
        {
            bllMsg.DeleteAll(IDS);
            BindList();
        }
        else
        {


            JsAlert.ShowAlert("请选择要删除的数据");
        }
       

    }
    //删除全部
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string msgType = drplMsgType.SelectedValue;

        string searchType = drplKeyWordType.SelectedValue;

        string fromUser = txtFromUser.Text.Trim();
        string toUser = txtToUser.Text.Trim();
        string keyword = txtKeyWord.Text.Trim();
        
        string sdate = txtStart.Text.Trim();
        string edate = txtEnd.Text.Trim();


       int intR= bllMsg.DelAll(msgType, searchType, fromUser, cboxFrom.Checked, toUser, cboxToUser.Checked, keyword, sdate, edate);
       this.BindList();

       JsAlert.ShowAlert(string.Format("共删除{0}条记录!",intR));
          
    }
    protected void pager_PageChanged(object sender, EventArgs e)
    {
        this.BindList();
    }


    #region 全选与反向选择
    string cboxid = "cboxItem";

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
}