using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using LL.BLL.Admin;
using LL.BLL.Popedom;

using Project.Common;
using LL.BLL.Member;
using LL.Common.EnumClass;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class News_NewsClassTree : AdminPage
{

    BLLphome_enewsmember bllLogin = new BLLphome_enewsmember();

    BLLphome_enewsmemberadd bllMember = new BLLphome_enewsmemberadd();


    private const string Sp_VipMemberList = "sp_VipMemberList";

    private const string target = "frmVipSite";
    private const string toUrl = "Default.aspx";

    string groupid = "";
    int userid = 0;
    string arrid = "";
    string groupname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        userid = Format.DataConvertToInt(Request[LL.Common.PubConstant.Key_MemberID]);
        groupid = Request[LL.Common.PubConstant.Key_GroupID];

      
        if (!Page.IsPostBack)
        {
            BindMemberGroup();
            ShowMemberList();
        }
    }
    /// <summary>
    /// 绑定有网站的会员组
    /// </summary>
    void BindMemberGroup()
    {
        string gname="";
        foreach (var item in Enum.GetValues(typeof(WebSiteMemberGroupID)))
        {
            drplSearchType.Items.Add(new ListItem(item.ToString(), ((int)item).ToString()));
            arrid += "," + ((int)item).ToString();
            gname+=","+item.ToString();
            
          
        }
    

        arrid = Util.FilterStartAndEndSign(arrid, ",");
        gname=Util.FilterStartAndEndSign(gname, ",");


        drplSearchType.Items.Insert(0, new ListItem("不限", arrid));
        groupname = Enum.GetName(typeof(WebSiteMemberGroupID), Format.DataConvertToInt(groupid));

        if (string.IsNullOrEmpty(groupid))
        {
            
            groupid = arrid;

            groupname = gname;
        
        }
       
        drplSearchType.SelectedIndex = drplSearchType.Items.IndexOf(drplSearchType.Items.FindByValue(groupid));


      
    }

    private void ItemUrl(ref StringBuilder sb, string userid, string username, string groupid, string company, string target, string call, string email, string address)
    {
        //id, pid, name, url, title, target, icon, iconOpen, open
        string urlParm = string.Format("?userid={0}&id={0}&groupid={1}&username={2}&company={3}&isVipWebSite=true&email={4}&address={5}&call={6}", userid, groupid, username, company,email,address,call);

  
        VipWebSiteNav(ref sb, urlParm, userid);
    }

    void VipWebSiteNav(ref StringBuilder sb, string urlParm, string userid)
    {

        sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,true); ", 1, userid, "公司Banner", "CompanyBanner.aspx" + urlParm, "", target);
        sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,true); ", 2, userid, "公司简介", "CompanyIntroManager.aspx" + urlParm, "", target);
        sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,true); ", 2, userid, "联系我们", "Conact.aspx" + urlParm, "", target);

        sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,true); ", 6, userid, "新闻动态", "NewsList.aspx" + urlParm, "", target);

        sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,true); ", 5, userid, "产品展厅", "ProductList.aspx" + urlParm, "", target);

        sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,true); ", 5, userid, "解决方案", "ProductList.aspx" + urlParm, "", target);



     
        sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,true); ", 8, userid, "企业招聘", "Job.aspx" + urlParm, "", target);
    }
    


    protected void btnSearchMember_Click(object sender, EventArgs e)
    {
        ShowMemberList();
    }
    protected void pager_PageChanged(object sender, EventArgs e)
    {

        ShowMemberList();

    }


    private void ShowMemberList()
    {

        string loginname = txtMemberName.Text.Trim();
        int pagesize = pager.PageSize;
        int pageindex = pager.CurrentPageIndex;

        string strGroupID = drplSearchType.SelectedValue;

       
        
        DataSet ds = bllLogin.GetLoginAndInfoList(pageindex, pagesize, loginname, userid, strGroupID, -1);
        int rows = 0;
        if (ds.Tables.Count == 2)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                rows = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);

               
            }
            else {

                lblDTree.Text = "【" + groupname + "】 会员组目前无数据!";
            }
            pager.RecordCount = rows;



        } BindMemberTree(ds.Tables[0]);
    }

    private void BindMemberTree(DataTable tb)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<script>  d = new dTree('d'); ");
        string rootUrl = string.Format("NewsList.aspx?{0}={1}", LL.Common.PubConstant.Key_ClassID, 0);
        sb.AppendFormat("  d.add(0,-1,'会员网站管理','{0}','{0}','{1}','','',false) ;", rootUrl, target);

        foreach (DataRow row in tb.Rows)
        {
            //string company = row["company"].ToString();
            string userid = row["userid"].ToString();
            string address = row["address"].ToString();
            string email = row["email"].ToString();
            string call = row["call"].ToString();
            string mgroupid = row["groupid"].ToString();
            string username = row["username"].ToString();
            string company = row["company"].ToString();
            //StringBuilder strUname = new StringBuilder();
            //char[] charU = username.ToCharArray();
            //for (int i = 0; i < charU.Length; i++)
            //{
            //    strUname.Append(charU[i]);
            //    if (i>=13 && i%13==0)
            //    {
            //        strUname.AppendFormat("<br>");
            //    }
            //}

            
            username = Project.Common.Util.HtmlSplit(username);
            string linkTitle = string.Format("{0}:{1}", username,Util.CutString(company,24,true));

            string urlMemberWebSite = string.Format("{0}/VipSite/index.aspx?u={1}",LL.Common.Cache.ConfigManager.MainDomain,userid);
            sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,false); ", userid, 0, linkTitle, urlMemberWebSite, company, "_blank");
            //添加子类    
            ItemUrl(ref sb, userid, username, mgroupid, "", target, call, email, address);

        }

        sb.AppendFormat("d.config.useIcons='/scripts/dtree/img/';");
        sb.AppendFormat("document.write(d);    var   toUrl='" + toUrl + "';   </script>");
        lblDTree.Text = sb.ToString();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ShowMemberList();
    }
}