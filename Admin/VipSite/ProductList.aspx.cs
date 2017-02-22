using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using LL.BLL.News;
using LL.Model.News;
using System.Data;
public partial class ProductList : AdminPage
{
    BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
    protected void Page_Load(object sender, EventArgs e)
    {

        ShowList();

    }
    private void ShowList()
    {
        int pageindex = pager.CurrentPageIndex;
        int pagesize = 15;
        string title = txtSearchKey.Text.Trim();
        string wheretitle = string.IsNullOrEmpty(title) ? "" : string.Format("  and  title like '%{0}%'", title);

        string where = string.Format(" userid={0} and classid={1} {2}", GetReqMemberID, (int)LL.Common.EnumClass.VipSiteItemsClassID.产品展厅,wheretitle);
        DataSet ds = bllNews.GetList(pageindex, pagesize, where);
        if (ds.Tables.Count == 2)
        {


            repDataList.DataSource = ds.Tables[0];
            repDataList.DataBind();

            if (ds.Tables[1].Rows.Count > 0)
            {

                pager.RecordCount = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
            }

        }


    }
    #region 查找

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ShowList();

    }



    #endregion

    public void btnDel_Click(object sender, EventArgs e)
    {

        LinkButton btn = (LinkButton)sender;

        int id = Format.DataConvertToInt(btn.CommandArgument);

        if (id > 0)
        {
            
            bllNews.Delete(id);
            ShowList();

        }
        else
        {

            JsAlert.ShowAlert("数据有误!");

        }

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string url = string.Format("ProductManager.aspx?userid={0}",GetReqMemberID);

        Response.Redirect(url);

    }
    protected void pager_PageChanged(object sender, EventArgs e)
    {
        ShowList();
    }
}