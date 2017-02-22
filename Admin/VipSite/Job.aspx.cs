using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.BLL.News;
using LL.Model.News;
using LL.Common.EnumClass;
using System.Data;
using LL.Common;
using Project.Common;
public partial class VipWebSite_Job :  AdminPage
{
    BLLphome_ecms_news bllNews=new BLLphome_ecms_news();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            JobInfo();
        }

    }
    void JobInfo()
    { 
    string where=string.Format(" userid={0} and classid={1}",GetReqMemberID, (int)VipSiteItemsClassID.企业招聘);


      DataSet ds=bllNews.GetTopTitleList(1,where," id desc");
        if (ds.Tables.Count>0)
	{
		 
            if (ds.Tables[0].Rows.Count>0)
	{
                DataRow row=ds.Tables[0].Rows[0];
		         txtTitle.Text=row["title"].ToString();
                txtNewstext.Value=row["newstext"].ToString();
                hideID.Value = row["id"].ToString();
	}
	}


    }


    void Edit()
    {

        string title=txtTitle.Text.Trim();
        string content=txtNewstext.Value.ToString();
        phome_ecms_news model = new phome_ecms_news();
        int intR = 0;
        if (!string.IsNullOrEmpty(hideID.Value) && Project.Common.Format.DataConvertToInt(hideID.Value) > 0)
        {
            model = bllNews.GetModel(Project.Common.Format.DataConvertToInt(hideID.Value));
            if (model.id>0)
            {
                model.title = title;
                model.newstext = content;


             intR=   bllNews.Update(model);
            }
           
           

        }
        else {

            model.title = title;
            model.newstext = content;
            model.classid = (int)VipSiteItemsClassID.企业招聘;
            model.@checked = 1;
            model.newstime = DateTime.Now;

          intR=  bllNews.Add(model);
        
        
        }



        if (intR > 0)
        {
            JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }
    
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Edit();
    }
}