using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.BLL.Member;

using LL.BLL.Popedom;
using LL.BLL.Admin;
using LL.Common;
using Project.Common;

public partial class Send_SendMsg : AdminPage
{

    BLLphome_enewsmembergroup bllMemberGroup = new BLLphome_enewsmembergroup();

    BLLphome_enewsmember bllMember = new BLLphome_enewsmember();
    BLLPhomeENewsQMsg bllMsg = new BLLPhomeENewsQMsg();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            BindAdminRole();
        }

    }

    private void BindAdminRole()
    {
        cboxMemberGroup.DataSource = bllMemberGroup.GetAllListByCache();
        cboxMemberGroup.DataTextField = "groupname";
        cboxMemberGroup.DataValueField = "groupid";
        cboxMemberGroup.DataBind();

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        //得到所选角色
        List<int> arrRole = new List<int>();
        foreach (ListItem item in cboxMemberGroup.Items)
        {
            if (item.Selected)
            {
                arrRole.Add(Format.DataConvertToInt(item.Value));
            }
        }
        string strEventGroupSendNum = txtEveryGroupSendNum.Text.Trim();
        string strTitle = txtTitle.Text.Trim();
        string strContent = txtContent.Text.Trim();

        SendMessage(arrRole, strEventGroupSendNum, strTitle, strContent);
    }


    private void SendMessage(List<int> arrRole, string strEventGroupSendNum, string strTitle, string strContent)
    {



        if (arrRole.Count()<1)
        {

            JsAlert.ShowAlert("请选择要发送的会员组");
        }



        int intR = bllMsg.BatchSendByMemberRole(arrRole, strEventGroupSendNum, strTitle, strContent, lblTagUserName.Text.Trim());



        JsAlert.ShowAlert("共发送:{0} 位会员!");


    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtEveryGroupSendNum.Text = "";
        txtTitle.Text = "";
        txtContent.Text = "";
    }
}