using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_MemberInfo : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        int GroupID = base.GetReqMemberGroupID;
        if (GroupID == 7)
        {

            Server.Transfer("MemberPersonInfo2.aspx");

        }
        else
        {
            Server.Transfer("MemberCompanyInfo2.aspx");

        
        }

    

    }
}