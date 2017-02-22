using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Model.News;
using LL.Common;
using System.Text;
using Project.Common;
using System.Data;
using LL.BLL.News;
using DBUtility;

using LL.BLL.Member;

public partial class SolutionManager : AdminPage
{
    BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
    int NewsClassID = (int)LL.Common.EnumClass.VipSiteItemsClassID.解决方案;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCompanyIntro();
        }
    }
    private void BindCompanyIntro()
    {
        if (GetReqIDValue > 0)
        {
            string sql = string.Format("  select id, title,titlepic, newstext,newstime  from   phome_ecms_news where userid={0} and classid={1} and id={2}", GetReqMemberID,  NewsClassID, GetReqIDValue);
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtTitle.Text = row["title"].ToString();
                txtTitlePic.Text = row["titlepic"].ToString();
                txtNewstext.Value =   HttpUtility.HtmlDecode(row["newstext"].ToString());
                txtPostTime.Text = row["newstime"].ToString();
                hideID.Value = row["id"].ToString();
                btnAdd.Text = " 修 改 ";
            }
        }
        else
        {
            btnAdd2.Visible = false;
            btnAdd.Text = "增  加";
        }
    }
    #region  添加产品
    protected void btnEdit_Click(object sender, EventArgs e)
    {

        EditNews();
    }

    private void EditNews()
    {
        StringBuilder strError = new StringBuilder();

        if (string.IsNullOrEmpty(txtNewstext.Value.Trim()))
        {
            strError.AppendFormat("{0}\\n", PubMsg.Msg_Content_NeedInput);
        }

        if (strError.ToString().Trim() != "")
        {
            JsAlert.ShowAlert(strError.ToString());
            return;
        }

        int id = Format.DataConvertToInt(hideID.Value);


        if (id > 0)
        {
            //更改
            phome_ecms_news model = bllNews.GetModel(id, GetReqMemberID);
            model.title = txtTitle.Text.Trim();
            model.classid = NewsClassID;
            model.titlepic = txtTitlePic.Text.Trim();
            model.lastdotime = Format.DataConvertToInt(Format.DateTimeToUnixTimeStamp(DateTime.Now));
            model.newstext = txtNewstext.Value;
            model.smalltext = Util.SplitHTML(txtNewstext.Value);
            model.smalltext = model.smalltext.Length > Data.MaxSmallTextLenght ? model.smalltext.Substring(0, Data.MaxSmallTextLenght) : model.smalltext;
            model.@checked = cboxChecked.Checked ? 1 : 0;
            string newstime = txtPostTime.Text.Trim();
            model.newstime = Format.DataConvertToDateTime(newstime);


            int intR = bllNews.Update(model);

            if (intR > 0)
            {
                JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);
            }
            else
            {
                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }

        }
        else
        {
            //添加


            phome_ecms_news model = new phome_ecms_news();
            model.classid = NewsClassID;
            model.userid = GetReqMemberID;
            model.username = GetReqMemberUserName;
            //groupid 设置新闻浏览权限
            model.groupid = 0;
            model.ismember = 0;
            model.@checked = cboxChecked.Checked ? 1 : 0;
            model.newstime = DateTime.Now;
            model.truetime = Format.DataConvertToInt(Format.DateTimeToUnixTimeStamp(DateTime.Now));
            model.lastdotime = Format.DataConvertToInt(Format.DateTimeToUnixTimeStamp(DateTime.Now));
           

            #region 不为空的属性
            model.newspath = "";
            model.keyboard = "";
            model.keyid = "";
            model.ztid = "";
            model.titlefont = "";
            model.titleurl = "";
            model.filename = "";
            model.filenameqz = "";
            model.titlepic = "";
            #endregion

            model.title = txtTitle.Text.Trim();
            model.titlepic = txtTitlePic.Text.Trim();
            model.writer = GetReqMemberCompany;
            model.befrom = GetReqMemberCompany;

            model.newstext = txtNewstext.Value;
            model.smalltext = Util.SplitHTML(txtNewstext.Value);
            model.smalltext = model.smalltext.Length > Data.MaxSmallTextLenght ? model.smalltext.Substring(0, Data.MaxSmallTextLenght) : model.smalltext;

            ///提交数据
            int intR = bllNews.Add(model);
            if (intR > 0)
            {
                //string url=string.Format("?id={0}",intR);
        
                JsAlert.ShowAlert(PubMsg.Msg_AddSuccess);

            }
            else
            {
                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }
        }
        BindCompanyIntro();
    }
    #endregion






    //进行增加
    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        string url = string.Format("SolutionManager.aspx?userid={0}", GetReqMemberID);
        Response.Redirect(url);
     
    }


    protected void btnReturnNewsList_Click(object sender, EventArgs e)
    {
        string url = string.Format("SolutionList.aspx?userid={0}", GetReqMemberID);
      Response.Redirect(url,true);


    }

    protected void btnClear_Click(object sender, EventArgs e)
    {

        txtTitle.Text = string.Empty;
        txtTitlePic.Text = string.Empty;
        txtNewstext.Value = string.Empty;
        hideID.Value = "0";
        btnAdd2.Visible = false;
        btnAdd.Text = "增  加";

    }

 
    




}