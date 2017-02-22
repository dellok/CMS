using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using LL.BLL.News;

using System.Data;
using LL.Common;
using System.Text;
using LL.Model.News;

public partial class News_NewsList : AdminPage
{
    BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
    BLLphome_enewsclass bllClass = new BLLphome_enewsclass();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BindList();

        }
    }


    #region 绑定列表

    /// <summary>
    /// 显示信息列表
    /// </summary>
    private void BindList()
    {



        string strKeyWord = txtKeyWord.Text.Trim();
        string strSDate = txtSDate.Text.Trim();
        string strEDate = txtEDate.Text.Trim();
        string strSearchType = radioSearchType.SelectedValue;
        string strChecked = radioCheckType.SelectedValue;
        string isMebmer = radioPostRole.SelectedValue;


        int PageIndex = pager.CurrentPageIndex;
        int PageSize = pager.PageSize;




        DataSet ds = bllNews.GetList(PageIndex, PageSize, strKeyWord, strSDate, strEDate, strSearchType, strChecked, isMebmer, base.GetReqNewsClassID, base.GetReqBClassID);

        if (ds.Tables.Count == 2)
        {
            int TotalRecords = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                TotalRecords = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
            }

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

        if (base.IsTempEditer())
        {
            phome_ecms_news model = bllNews.GetModel(ID, CurrentLogin.ID);
            if (model != null)
            {
                bllNews.Delete(ID, CurrentLogin.ID);
            }
            else
            {

                JsAlert.ShowAlert("只能删除自己发布的新闻!");
            }
        }
        else
        {
            bllNews.Delete(ID);


        }

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

            intR = bllNews.BatchDel(arrIDS, base.IsTempEditer() ? CurrentLogin.ID : 0);
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
            intR = bllNews.BatchChecked(arrIDS, true, base.IsTempEditer() ? CurrentLogin.ID : 0);
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
            intR = bllNews.BatchChecked(arrIDS, false, base.IsTempEditer() ? CurrentLogin.ID : 0);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已取消审核 [{0}] 条记录!", intR));
    }


    /// <summary>
    /// 推荐
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchRecommend_Click(object sender, EventArgs e)
    {

        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllNews.BatchRecomend(arrIDS, true, base.IsTempEditer() ? CurrentLogin.ID : 0);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已成功设置 [{0}] 条记录!", intR));
    }
    /// <summary>
    /// 最消推荐
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchUnRecommend_Click(object sender, EventArgs e)
    {
        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllNews.BatchRecomend(arrIDS, false, base.IsTempEditer() ? CurrentLogin.ID : 0);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已取消推荐 [{0}] 条记录!", intR));
    }


    /// <summary>
    /// 头条
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchTopNews_Click(object sender, EventArgs e)
    {



        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllNews.BatchFirstTitle(arrIDS, true, base.IsTempEditer() ? CurrentLogin.ID : 0);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已成功设置 [{0}] 条记录!", intR));
    }
    /// <summary>
    /// 最消头条
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchUnTopNews_Click(object sender, EventArgs e)
    {
        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllNews.BatchFirstTitle(arrIDS, false, base.IsTempEditer() ? CurrentLogin.ID : 0);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已取消头条 [{0}] 条记录!", intR));
    }
    /// <summary>
    /// 归档
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBatchFiling_Click(object sender, EventArgs e)
    {
        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllNews.BatchFiling(arrIDS);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("成功设置 [{0}] 条记录!", intR));
    }
    /// <summary>
    /// 置顶级别
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void radioListIsTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        int TopNum = Format.DataConvertToInt((sender as RadioButtonList).SelectedValue);
        int intR = 0;
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllNews.BatchTop(arrIDS, TopNum, base.IsTempEditer() ? CurrentLogin.ID : 0);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已成功设置 [{0}] 条记录!", intR));
    }
    /// <summary>
    /// 移动信息类型
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMoveInfoClass_Click(object sender, EventArgs e)
    {
        int intR = 0;
        int intClassID = Format.DataConvertToInt(ucNewsClass.GetValue);
        List<int> arrIDS = GetCheckedValues();
        if (arrIDS.Count() > 0)
        {
            intR = bllNews.UpdateNewsClass(arrIDS, intClassID);
        }
        BindList();
        JsAlert.ShowAlert(string.Format("已取移动 [{0}] 条记录!", intR));
    }



    #endregion


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindList();
    }

    protected void pager_PageChanged(object sender, EventArgs e)
    {
        this.BindList();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewsAdd.aspx?bclassid=" + GetReqBClassID + "&classid=" + base.GetReqNewsClassID);

    }
    /// <summary>
    /// 数据刷新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        List<int> arrIDS = GetCheckedValues();
        StringBuilder msg = new StringBuilder();
        // msg.Append(SEO.RefreshDetailPage_News(arrIDS));
        msg.Append(SEO.RefreshIndexPage());
        JsAlert.ShowAlert(msg.ToString());
    }
}