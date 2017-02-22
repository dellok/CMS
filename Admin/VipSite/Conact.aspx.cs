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
using LL.BLL.Member;
using LL.Model.Member;
using Project.Common;
public partial class Conact : AdminPage
{
    BLLphome_enewsmemberadd bllMember = new BLLphome_enewsmemberadd();
    BLLphome_enewsmember bllLogin = new BLLphome_enewsmember();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ContactInfo();
        }

    }
    void ContactInfo()
    {
        DataSet ds = bllMember.GetMemberLoginAndCompanyInfo(GetReqMemberID);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtEmail.Text = row["email"].ToString();
                txtFax.Text = row["fax"].ToString();
                txtAddress.Text = row["address"].ToString();
                txtWebSite.Text = row["homepage"].ToString();

                txtCall.Text = row["call"].ToString();


            }
        }


    }


    void Edit()
    {
        string email = txtEmail.Text;
        string fax = txtFax.Text;
        string address = txtAddress.Text;
        string homepage = txtWebSite.Text;
        string call = txtCall.Text;




        


        phome_enewsmemberadd member = bllMember.GetModel(GetReqMemberID);
        member.address = address;
        member.call = call;
        member.homepage = homepage;
        member.fax = fax;

        bllLogin.UpdateEmail(GetReqMemberID, email);
        int intR=  bllMember.Update(member);


        if (intR > 0)
        {
            JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }

    }
 

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Edit();
    }
}