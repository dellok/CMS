using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using LL.Common;
using LL.BLL.Admin;
using Project.Common;
using LL.Model.Admin;
using LL.Common.Cache;
using System.Web.Security;


public partial class Login : Page
{

    /// <summary>
    /// 登录
    /// </summary>
    public void CheckLogin()
    {

        StringBuilder strError = new StringBuilder();


        if (string.IsNullOrEmpty(txtLoginName.Text.Trim()))
        {
            strError.AppendFormat("{0}\\n", PubMsg.Msg_Login_Name_NeedInput);
        }

        if (string.IsNullOrEmpty(txtPwd.Text.Trim()))
        {

            strError.AppendFormat("{0}\\n", PubMsg.Msg_Login_Password_NeedInput);
        }

      /*   if (string.IsNullOrEmpty(txtCheckCode.Text.Trim()))
        {
            strError.AppendFormat("{0}\\n", PubMsg.Msg_CheckCode_NeedInput);
        }
        else
        {
           if (txtCheckCode.Text.Trim().ToLower() != Format.DataConvertToString(SessionManager.GetSession(PubConstant.Key_CheckCode)).ToLower())
            {
            
                strError.AppendFormat("{0}\\n", PubMsg.Msg_CheckCode_NoMatch);
            }

        }*/

        //弹出提示对
        if (!string.IsNullOrEmpty(strError.ToString()))
        {


            JsAlert.ShowAlert(strError.ToString());
            return;
        }
        else
        {

            DoLogin(txtLoginName.Text, txtPwd.Text);
        }
    }



    /// <summary>
    /// 验证登录
    /// </summary>
    /// <param name="p"></param>
    /// <param name="p_2"></param>
    /// <param name="p_3"></param>
    /// <returns></returns>
    private void DoLogin(string loginName, string pwd)
    {

        BLLAdminUser  bllLogin=new BLLAdminUser();
        pwd = Project.Common.WebSecurity.EncryptPasswordMD5(pwd);
        AdminUser loginModel = bllLogin.GetModel(loginName, pwd);
       
        if (loginModel != null)
        {

            if (!loginModel.Checked)
            {

                JsAlert.ShowAlert("员工离职,帐号禁用!");
            }
            else
            {

                //存入session中

                SessionManager.SetSession(PubConstant.Key_Admin, loginModel);
                CookieManager.SetLogin(loginModel.ID.ToString(), PubConstant.Key_Admin, loginModel.LoginName, PubConstant.Key_Admin, 12);
                if (Request.QueryString[PubConstant.Key_ReutrnPage] != null)
                {

                    Response.Redirect(Request.QueryString[PubConstant.Key_ReutrnPage]);
                }
                else
                {
                    string indexUrl = "/include/index.aspx";
                    Response.Redirect(indexUrl, true);

                }
            }
        }
        else
        {
            ///用户名与密码不对
            JsAlert.ShowAlert(PubMsg.Msg_Login_NameAndPwd_NoMatch);

        }




       }


   
           protected void btnLogin_Click(object sender, ImageClickEventArgs e)
           {
               CheckLogin();

           }
}