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

public partial class Admin_AdminAdd : AdminPage
{

    BLLAdminUser bllAdmin = new BLLAdminUser();

    protected void Page_Load(object sender, EventArgs e)
    {



    }
    #region  验证输入

    public string CheckInput()
    {
        string strErr = "";

        if (this.txtLoginName.Text.Trim() == "")
        {
            strErr += "登录名不能为空！\\n";
        }
        else
        {

            if (bllAdmin.ExistsLoginName(txtLoginName.Text.Trim()))
            {
                strErr += "此登录名已存在\\n！";
            }
        }
        
        
        if (this.txtLoginPwd.Text.Trim() == "")
        {
            strErr += "密码不能为空！\\n";
        }



        return strErr;

    }


    /// <summary>
    /// 根据方框设置对象
    /// </summary>
    /// <returns></returns>
    private AdminUser SetModel()
    {
        string Real_Name = this.txtRealName.Text;
        string LoginName = this.txtLoginName.Text;
        string LoginPwd = this.txtLoginPwd.Text;
        int Admin_Role =Project.Common.Format.DataConvertToInt(ucAdminRole.GetValue);
        string Remark = this.txtRemark.Text;
        bool Available = cboxAvailable.Checked;

        AdminUser adminModel = new AdminUser();
        adminModel.LoginName = LoginName;
        adminModel.Password = Project.Common.WebSecurity.EncryptPasswordMD5(LoginPwd);
        adminModel.AdminRoleID = Admin_Role;
        adminModel.Remark = Remark;
        adminModel.Checked = Available;
        adminModel.InDate = DateTime.Now;
        return adminModel;
    }
    #endregion

    #region  add ,update delete
    /// <summary>
    /// 清除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtRealName.Text = "";
        this.txtLoginName.Text = "";
        this.txtLoginPwd.Text = "";

        this.txtRemark.Text = "";
    }

    /// <summary>
    /// 增加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string strErr = CheckInput();
        if (strErr != "")
        {
            JsAlert.ShowAlert(strErr);
            return;
        }

        AdminUser model = SetModel();
        int intR = bllAdmin.Add(model);
        if (intR > 0)
        {
            JsAlert.ShowAlert(PubMsg.Msg_AddSuccess);
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }
    }


    #endregion



}