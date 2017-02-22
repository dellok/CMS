using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using LL.Common.Cache;
using Project.Common;
using Project.Common;
using System.Net;
using System.Text;

using Project.Common;

using LL.BLL.News;
using System.Data;
using System.IO;
using LL.BLL.Log;
using LL.Common.EnumClass;
public partial class Index : Page
{


    BLLVisitorLog bllLog = new BLLVisitorLog();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindItem();
        }
    }

    private void BindItem()
    {

      
        List<object> arrAnonymous = new List<object>();

        foreach (int v in Enum.GetValues(typeof(PageDirectory)))
        {
            PageDirectory pd = (PageDirectory)Enum.Parse(typeof(PageDirectory), v.ToString());
            string name = AliasAttribute.EnumAlias(pd);
            string PageDir = pd.ToString();

            if (PageDir.ToLower()=="index")
            {

                continue;
            }
             dynamic an = new { ItemName = name, PageDir = PageDir, ADPage = name };
             arrAnonymous.Add(an);
        }

        drplItem.DataSource = arrAnonymous;
        drplItem.DataTextField = "ItemName";
        drplItem.DataValueField = "PageDir";
        drplItem.DataBind();


        drplItem.Items.Insert(0, new ListItem("--全部--",""));


    }


   
    protected void btnCreateHtml_Click(object sender, EventArgs e)
    {

    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {


        SearchVisitorLogTotal();

    }

    private void SearchVisitorLogTotal()
    {


        int PageIndex = pager.CurrentPageIndex;
        int PageSize = pager.PageSize;

        string type = drplItem.SelectedValue;
        string infoid = txtInfoID.Text.Trim();
        string infotitle = txtInfoTitle.Text.Trim();
        string sdate = txtSDate.Text.Trim();
        sdate = string.IsNullOrEmpty(sdate) ? DateTime.Now.ToShortDateString() :sdate;
        string edate = txtEDate.Text.Trim();
        edate = string.IsNullOrEmpty(edate) ? DateTime.Now.AddDays(1).ToShortDateString():edate;
        string orderby = radioOrderBy.SelectedValue;

        DataSet ds = bllLog.TotalVisitorLog(PageIndex,PageSize, type, infoid, infotitle, sdate, edate,orderby);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dataViewList.DataSource = ds.Tables[0];
            dataViewList.DataBind();

            pager.RecordCount = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
           
        }
        else
        {
            dataViewList.DataSource = null;
            dataViewList.DataBind();
        }
    }
    protected void pager_PageChanged(object sender, EventArgs e)
    {
        SearchVisitorLogTotal();

    }
}
