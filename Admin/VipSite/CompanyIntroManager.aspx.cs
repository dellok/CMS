using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using Project.Common;
using System.Data;

using LL.BLL.Member;
using LL.Model.Member;
using LL.Common;

public partial class Member_VipWebSite_CompanyIntroManager : AdminPage
{

    //BLLPhomeECmsNews bllNews = new BLLPhomeECmsNews();

    //取出会员公司信息


    BLLphome_enewsmemberadd bllMemberInfo = new BLLphome_enewsmemberadd();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCompanyIntro();
        }

    }

    private void BindCompanyIntro()
    {
        //公司名称
        phome_enewsmemberadd memberInfo = bllMemberInfo.GetModel(GetReqMemberID);

        if (memberInfo!=null)
        {
            lblCompanyName.Text = memberInfo.company;
            txtNewstext.Value = memberInfo.saytext;
        }
      
        //判断公司简介是否添加过
        //string  sql=string.Format("  select top 1 id, newstext  from   phome_ecms_news where userid={0} and classid={1}",GetReqMemberID,(int)LL.Common.Enum.VipWebSiteItemClassID.公司简介);
        //DataSet ds = DbHelperSQL.Query(sql);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    DataRow row = ds.Tables[0].Rows[0];
        //    txtNewstext.Value = row["newstext"].ToString();
        //    hideID.Value = row["id"].ToString();
        //    btnAdd.Text = " 修 改 ";

        //}
        //else
        //{
        //    btnAdd.Text = "增  加";
        //}
    }

    #region
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        btnEdit2();
        BindCompanyIntro();
    }


    void btnEdit2()
    {
        StringBuilder strError = new StringBuilder();
        if (string.IsNullOrEmpty(txtNewstext.Value.Trim()))
        {
            strError.AppendFormat("{0}\\n", PubMsg.Msg_Content_NeedInput);
        }
        //if (string.IsNullOrEmpty(txtCheckCode.Text.Trim()))
        //{
        //    strError.AppendFormat("{0}\\n", PubMsg.Msg_CheckCode_NeedInput);
        //}
        //else
        //{
        //    if (txtCheckCode.Text.Trim() != Format.DataConvertToString(LL.Common.Cache.SessionManager.GetSession(LL.Common.PubConstant.Key_CheckCode)))
        //    {
        //        strError.AppendFormat("{0}\\n", PubMsg.Msg_CheckCode_NoMatch);
        //    }
        //}

        if (strError.ToString().Trim() != "")
        {
            JsAlert.ShowAlert(strError.ToString());
            return;
        }

        int intR = bllMemberInfo.UpdateCompanyIntro(GetReqMemberID, txtNewstext.Value);
        if (intR > 0)
        {
            JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }

    }

   
    #endregion




}