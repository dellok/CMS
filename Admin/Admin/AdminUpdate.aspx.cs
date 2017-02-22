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

public partial class Admin_AdminUpdate : AdminPage
{

    BLLAdminUser bllAdmin = new BLLAdminUser();

    protected void Page_Load(object sender, EventArgs e)
    {

    
        
        if (!Page.IsPostBack)
        {
           
            ShowAdminInfo();
      
        }

       
    }

    protected void ShowAdminInfo()
    {


        if (base.GetReqIDValue > 0)
        {

            AdminUser adminModel = bllAdmin.GetModel(GetReqIDValue);
            txtLName.Text = adminModel.LoginName;
            txtRemark.Text = adminModel.Remark;
            ucAdminRole.SetValue = adminModel.AdminRoleID.ToString();
            cboxAvailable.Checked = adminModel.Checked;


        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_DataInfo_Lost);
            btnUpdate.Enabled = false;
        
        }
       



    
    }


    #region  验证输入

    public string CheckInput()
    {
        string strErr = "";

        if (this.txtLName.Text.Trim() == "")
        {
            strErr += string.Format("{0}\\n",PubMsg.Msg_Login_Name_NeedInput);
        }
        else
        {
            if (bllAdmin.ExistsLoginName(base.GetReqIDValue,txtLName.Text.Trim()))
            {
                strErr += string.Format("{0}\\n", PubMsg.Msg_Login_Name_Exist);
            }
        }

        return strErr;

    }


    /// <summary>
    /// 根据方框设置对象
    /// </summary>
    /// <returns></returns>
    private AdminUser SetModel()
    {

        string LoginName = this.txtLName.Text;
        int Admin_Role = Project.Common.Format.DataConvertToInt(ucAdminRole.GetValue);
        string Remark = this.txtRemark.Text;
        bool Available = cboxAvailable.Checked;
        string newPwd = txtNewPwd.Text.Trim();

      
        AdminUser adminModel = bllAdmin.GetModel(base.GetReqAdminIDValue);
        adminModel.LoginName = LoginName;
        adminModel.AdminRoleID = Admin_Role;
        adminModel.Remark = Remark;
        adminModel.Checked = Available;

        if (!string.IsNullOrEmpty(newPwd))
        {
            adminModel.Password = Project.Common.WebSecurity.EncryptPasswordMD5(newPwd);
        }
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
     
        this.txtLName.Text = "";
        this.txtRemark.Text = "";
    }

    /// <summary>
    /// 增加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        string strErr = CheckInput();
        if (strErr != "")
        {
            JsAlert.ShowAlert(strErr);
            return;
        }

        AdminUser model = SetModel();
        int intR = bllAdmin.Update(model);
        if (intR > 0)
        {
            JsAlert.ShowAlert( JsAlert.AlertType.OpenWindowInCurrent, PubMsg.Msg_UpdateSuccess,"AdminList.aspx");
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }


    }


    #endregion




    protected void btnUpdatePwd_Click(object sender, EventArgs e)
    {

       UpdatePwd();
    }

    private void UpdatePwd()
    {
        string newPwd = txtNewPwd.Text.Trim();
        if (!string.IsNullOrEmpty(newPwd))
        {
            int id = 0;
            string pwd = Project.Common.WebSecurity.EncryptPasswordMD5(newPwd);
            int intR = bllAdmin.UpdatePwd(id,pwd);
            if (intR > 0)
            {
                JsAlert.ShowAlert("密码修改成功!");
            }
            else
            {
                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }
            
        }
    
    }
}