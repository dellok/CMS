using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LL.BLL.Admin;
using LL.Common;
using Project.Common;
using LL.Model.Admin;
public partial class Admin_AdminPasswordUpdate : AdminPage
{
    BLLAdminUser bllAdmin = new BLLAdminUser();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ShowLoginName();   
        }
    }



    private void ShowLoginName()
    {
        AdminUser model = bllAdmin.GetModel(base.GetReqIDValue);
        lblLoginName.Text = model.LoginName;

    }

    #region 更改密码
    protected void btnUpdatePwd_Click(object sender, EventArgs e)
    {
        string strError = string.Empty;
        string strNewPwd = txtNewPwd.Text.Trim();
        string strReplyPwd = txtReplyNewPwd.Text.Trim();

        if (strNewPwd != strReplyPwd)
        {
            strError = "两次密码输入不致!";
        }
        if ( string.IsNullOrEmpty(strError.Trim()) || strError.Trim().Length <1)
        {

            this.UpdateAdminPwd(strNewPwd);
        }
    }
    /// <summary>
    /// 更新密码
    /// </summary>
    /// <param name="strNewPwd"></param>
    /// <returns></returns>
    private void UpdateAdminPwd(string strNewPwd)
    {

        AdminUser adminModel = bllAdmin.GetModel(base.GetReqAdminIDValue);

        adminModel.Password = Project.Common.WebSecurity.EncryptPasswordMD5(strNewPwd);

        int intR = bllAdmin.Update(adminModel);
        if (intR > 0)
        {
            JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInCurrent,PubMsg.Msg_UpdateSuccess,"AdminList.aspx");
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }

    }

    #endregion 更改密码
}