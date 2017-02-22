using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.BLL.Member;

using LL.Common;
using System.Data;
using LL.BLL.News;
using Project.Common;

public partial class News_NewsFeedback : AdminPage
{
    BLLNewsFeedback bllNewsFback = new BLLNewsFeedback();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindList();
            if (base.GetReqIDValue>0)
            {
                txtNewsID.Text = base.GetReqIDValue.ToString();
            }
        }
    }

    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
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
        string NewsID = txtNewsID.Text.Trim();
        string strSearch = txtSearchContent.Text.Trim();
        string searchType = drplSearchType.SelectedValue;
        string NewsClassID = ucNClass.GetValue;
        bool  IsChecked = cboxChecked.Checked;


        int PageIndex = pager.CurrentPageIndex;
        int PageSize = pager.PageSize;

        DataSet ds = bllNewsFback.GetList(PageIndex, PageSize, NewsID,searchType, strSearch, NewsClassID,"", IsChecked);
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

    #region 删除，审核 操作
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataViewList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

        int ID = Format.DataConvertToInt(dataViewList.DataKeys[e.ItemIndex].Value);
        bllNewsFback.Delete(ID);
        BindList();

    }
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchDelete_Click(object sender, EventArgs e)
    {
        List<int> IDS = GetCheckedValues("cboxItem", dataViewList);
       int intR= bllNewsFback.DeleteAll(IDS);
        BindList();
        JsAlert.ShowAlert(string.Format("删除了【{0}】条记录!", intR));
    }
    protected void btnBatchUnCheck_Click(object sender, EventArgs e)
    {
        List<int> IDS = GetCheckedValues("cboxItem", dataViewList);

    int intR=    bllNewsFback.BatchChecked(IDS, false);
    this.BindList();
    JsAlert.ShowAlert(string.Format("取消审核【{0}】条记录!", intR));
    }
    protected void btnBatchCheck_Click(object sender, EventArgs e)
    {
        List<int> IDS = GetCheckedValues("cboxItem", dataViewList);
      int inR=  bllNewsFback.BatchChecked(IDS, true);
      this.BindList();
      JsAlert.ShowAlert(string.Format("审核通过【{0}】条记录!",inR));

    }
    protected void btnBatchRecommend_Click(object sender, EventArgs e)
    {
        List<int> IDS = GetCheckedValues("cboxItem", dataViewList);
int intR=        bllNewsFback.BatchRecommend(IDS, true);
//JsAlert.ShowAlert(string.Format("推通过【{0}】条记录!", inR));

    }
    protected void btnBatchUnRecommend_Click(object sender, EventArgs e)
    {
        List<int> IDS = GetCheckedValues("cboxItem", dataViewList);
        bllNewsFback.BatchRecommend(IDS, false);
    }

 

    #endregion
    protected void pager_PageChanged(object sender, EventArgs e)
    {
        this.BindList();
    }
    protected void cboxSelectedAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbox = (CheckBox)sender;

        bool isChecked = cbox.Checked;

        foreach (ListViewDataItem row in dataViewList.Items)
        {
            CheckBox citem = row.FindControl("cboxItem") as CheckBox;
            citem.Checked = isChecked;
        }    
    }
}
