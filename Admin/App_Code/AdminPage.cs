using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.SessionState;
using LL.Common;
using System.Collections.Generic;
using Project.Common;
using LL.Common.Cache;
using LL.Model.Admin;
using LL.BLL.Admin;
public class AdminPage : Page
{
    public AdminPage()
    {
    }
    protected override void OnPreInit(EventArgs e)
    {
        RepeatSubmit();
         ValidateLogin();
        base.OnPreInit(e);
    }

    #region 验证登录
    /// <summary>
    /// 验证管理员登录
    /// </summary>
    public void ValidateLogin()
    {

        int adminRoleID = 0;
        if (SessionManager.GetSession(PubConstant.Key_Admin) == null)
        {
            //未登录 
            //验证Cookies
            int userid = CookieManager.GetLoginUserID(PubConstant.Key_Admin);
            if (userid <= 0)
            {
                RedirectLogin();
            }
            else
            {
                //重新存入session中
                BLLAdminUser bllAdmin = new BLLAdminUser();
                AdminUser modelLogin = bllAdmin.GetModel(userid);
                adminRoleID = modelLogin.AdminRoleID;
                //是到权限
                if (modelLogin != null && modelLogin.ID > 0)
                {
                    //存入session中
                    SessionManager.SetSession(PubConstant.Key_Admin, modelLogin);
                    CookieManager.SetLogin(modelLogin.ID.ToString(), PubConstant.Key_Admin, modelLogin.LoginName, modelLogin.Password, PubConstant.Key_Admin, 8);
                }
                else
                {
                    RedirectLogin();
                }
            }
        }
        //else
        //{
        //    adminRoleID = CurrentLogin.ID > 0 ? CurrentLogin.AdminRoleID : 0;
        //}

       // CheckAdminLevel(adminRoleID);
    }

    private void CheckAdminLevel(int adminrole)
    {
        string url = HttpContext.Current.Request.Url.AbsolutePath.ToString();
        //得到最终页
        string page = url.Substring(url.LastIndexOf("/") + 1).ToLower();
        //是否能操作此页

        string sql = string.Format("  select  f.id   from  PopedomFun  f inner join PopedomFunInAdminRole  r on  f.id=r.PopedomFunID  where  r.PopedomRoleID={0}  and f.url like '%{1}%'    ", adminrole, page);
        object obj = DBUtility.DbHelperSQL.GetSingle(sql);
        int i = obj != null ? Format.DataConvertToInt(obj) : 0;
        if (i < 1)
        {
            string strUrl = "http://" + HttpContext.Current.Request.Url.Authority + "/NoLevel.aspx";
            JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInCurrent, "没有权限", strUrl);
        }

    }


    /// <summary>
    /// 转发到登录页
    /// </summary>
    private void RedirectLogin()
    {
        string strUrl = "http://" + HttpContext.Current.Request.Url.Authority + "/llweb/index.aspx";
        string returnPageUrl = HttpContext.Current.Request.Url.ToString();

        if (!HttpContext.Current.Request.Url.ToString().Contains("llweb"))
        {
            strUrl = strUrl + "?" + PubConstant.Key_ReutrnPage + "=" + returnPageUrl;
        }

        JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInParent, "", strUrl);


    }
    #endregion
    #region  验证是否是  兼职编辑

    public const int AdminRole_TempEditer = 3;
    public bool IsTempEditer()
    {

        return CurrentLogin.AdminRoleID == AdminRole_TempEditer ? true : false;
    }

    #endregion

 


    /// <summary>
    /// 从session中得到login对像
    /// </summary>
    /// <returns></returns>
    public AdminUser CurrentLogin
    {


        get
        {
            AdminUser model = new AdminUser();
            if (SessionManager.GetSession(PubConstant.Key_Admin) != null)
            {
                model = (AdminUser)SessionManager.GetSession(PubConstant.Key_Admin);
            }
       
            return model;
        }


    }

    /// <summary>
    /// 得到登录用户ID
    /// </summary>
    /// <returns></returns>
    public int LoginID
    {
    

        get
        {
            if (CurrentLogin != null)
            {
                return CurrentLogin.ID;

            }
            else
            {
                return 0;
            }

        }
    }






    //#region RepeatSubmit


    void RepeatSubmit()
    {

        if (Request.Headers["Accept"] == "*/*")
        {


            if (Request.UrlReferrer!=null)
            {
                Response.Redirect(Request.UrlReferrer.AbsoluteUri.ToString(), true);
            }
          

        }

    }
  

    #region  ------------压缩解压缩视图状态---------------------
    protected override object LoadPageStateFromPersistenceMedium()
    {
        string viewState = Request.Form["__VSTATE"];
        byte[] bytes = Convert.FromBase64String(viewState);
        bytes = LL.Common.Cache.ViewStatuManager.Decompress(bytes);
        LosFormatter formatter = new LosFormatter();
        return formatter.Deserialize(Convert.ToBase64String(bytes));
    }

    protected override void SavePageStateToPersistenceMedium(object viewState)
    {
        LosFormatter formatter = new LosFormatter();
        System.IO.StringWriter writer = new System.IO.StringWriter();
        formatter.Serialize(writer, viewState);
        string viewStateString = writer.ToString();
        byte[] bytes = Convert.FromBase64String(viewStateString);
        bytes = LL.Common.Cache.ViewStatuManager.Compress(bytes);
        ScriptManager.RegisterHiddenField(this, "__VSTATE", Convert.ToBase64String(bytes));

    }

    #endregion






    #region viewstate

    public void SetViewState(string key, string v)
    {

        ViewState[key] = v;

    }

    public string GetViewsState(string key)
    {

        if (ViewState[key] != null)
        {

            return ViewState[key].ToString();
        }
        else
        {

            return "";
        }
    }

    #endregion
    public string GetReqValue(string key)
    {


        return Format.RequestToString(key);
    }


    #region  与Member 相关的
    public int GetReqMemberID
    {
        get
        {
            int id = 0;
            if (ViewState[PubConstant.Key_MemberID] != null)
            {
                id = Format.DataConvertToInt(ViewState[PubConstant.Key_MemberID]);
            }
            else
            {
                string reqV = Format.RequestToString(PubConstant.Key_MemberID);

                if (!string.IsNullOrEmpty(reqV))
                {
                    id = Format.DataConvertToInt(reqV);
                }
                ViewState[PubConstant.Key_MemberID] = id;

            }
            return id;
        }
    }

    public string GetReqIsVipWebSite
    {
        get
        {
            string isv = "false";
            if (ViewState[PubConstant.Key_IsVipWebSite] != null)
            {
                isv = ViewState[PubConstant.Key_IsVipWebSite].ToString();
            }
            else
            {
                isv = Format.RequestToString(PubConstant.Key_IsVipWebSite);
                ViewState[PubConstant.Key_IsVipWebSite] = isv;
            }
            return isv;
        }
    }
    /// <summary>
    /// 得到当前请求的会员组ID
    /// </summary>
    public int GetReqMemberGroupID
    {
        get
        {
            int id = 0;
            if (ViewState[PubConstant.Key_GroupID] != null)
            {
                id = Format.DataConvertToInt(ViewState[PubConstant.Key_GroupID]);
            }
            else
            {
                string reqV = Format.RequestToString(PubConstant.Key_GroupID);

                if (!string.IsNullOrEmpty(reqV))
                {
                    id = Format.DataConvertToInt(reqV);
                }
                ViewState[PubConstant.Key_GroupID] = id;
            }
            return id;
        }
    }
    public string GetReqMemberUserName
    {
        get
        {
            string temp = "";
            if (ViewState["UserName"] != null)
            {
                temp = ViewState["UserName"].ToString();
            }
            else
            {
                temp = Format.RequestToString("UserName");
                ViewState["UserName"] = temp;

            }
            return temp;
        }
    }
    public string GetReqMemberCompany
    {
        get
        {
            string temp = "";
            if (ViewState["Company"] != null)
            {
                temp = ViewState["Company"].ToString();
            }
            else
            {
                temp = Format.RequestToString("Company");
                ViewState["Company"] = temp;


            }
            return temp;
        }
    }
    #endregion

    /// <summary>
    /// 从当前页面视图或请求
    /// admin用户ID
    /// </summary>
    public int GetReqAdminIDValue
    {
        get
        {
            int id = 0;
            if (ViewState[PubConstant.Key_ID] != null)
            {
                id = Format.DataConvertToInt(ViewState[PubConstant.Key_ID]);
            }
            else
            {
                string reqV = Format.RequestToString(PubConstant.Key_ID);

                if (!string.IsNullOrEmpty(reqV))
                {
                    id = Format.DataConvertToInt(reqV);
                }
                ViewState[PubConstant.Key_ID] = id;
            }
            return id;
        }
    }
    /// <summary>
    /// 通用的请求
    /// 得到当前请求值(Key:为PubConstant.Key_ID)
    /// </summary>
    public int GetReqIDValue
    {
        get
        {
            int id = 0;
            if (ViewState[PubConstant.Key_ID] != null)
            {
                id = Format.DataConvertToInt(ViewState[PubConstant.Key_ID]);
            }
            else
            {
                string reqV = Format.RequestToString(PubConstant.Key_ID);

                if (!string.IsNullOrEmpty(reqV))
                {
                    id = Format.DataConvertToInt(reqV);
                }
                ViewState[PubConstant.Key_ID] = id;
            }
            return id;
        }
    }

    /// <summary>
    /// 从当前页面视图或请求
    /// classid
    /// </summary>
    public int GetReqNewsClassID
    {
        get
        {
            int classid = 0;
            if (ViewState[PubConstant.Key_ClassID] != null)
            {
                classid = Format.DataConvertToInt(ViewState[PubConstant.Key_ClassID]);
            }
            else
            {
                string reqV = Format.RequestToString(PubConstant.Key_ClassID);

                if (!string.IsNullOrEmpty(reqV))
                {
                    classid = Format.DataConvertToInt(reqV);
                }
                ViewState[PubConstant.Key_ClassID] = classid;
            }
            return classid;
        }
    }


    public string GetReqBClassID
    {
        get
        {
            string bclassid = "";
            if (ViewState[PubConstant.Key_BClassID] != null)
            {
                bclassid = ViewState[PubConstant.Key_BClassID].ToString();
            }
            else
            {
                string reqV = Format.RequestToString(PubConstant.Key_BClassID);

                if (!string.IsNullOrEmpty(reqV))
                {
                    bclassid = Format.DataConvertToInt(reqV).ToString();
                }
                ViewState[PubConstant.Key_BClassID] = bclassid;
            }
            return bclassid;
        }
    }






    #region
    /// <summary>
    /// 提交成功后，重置input
    /// </summary>
    public void AddSuccessInput()
    {
        JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInCurrent, PubMsg.Msg_AddSuccess, Request.RawUrl.ToString());
    }

    #endregion


    #region  选中
    /// <summary>
    /// 得到选中的cbox 值
    /// </summary>
    /// <param name="checkID"></param>
    /// <param name="control"></param>
    public static List<int> GetCheckedValues(string checkID, ListView control)
    {
        List<int> arrCheckedIDS = new List<int>();
        try
        {
            foreach (var item in control.Items)
            {
                CheckBox cbox = item.FindControl(checkID) as CheckBox;
                if (!string.IsNullOrEmpty(cbox.ToolTip))
                {
                    int id = Project.Common.Format.DataConvertToInt(cbox.ToolTip);
                    if (id > 0)
                    {

                        if (cbox.Checked)
                        {
                            arrCheckedIDS.Add(id);
                        }

                    }
                }
            }
        }
        catch (Exception)
        {
        }
        if (arrCheckedIDS.Count == 0)
        {
            JsAlert.ShowAlert("没有可操作项!");
        }
        return arrCheckedIDS;
    }
    public static List<string> GetCheckedValues2(string checkID, ListView control)
    {
        List<string> arrCheckedIDS = new List<string>();
        try
        {
            foreach (var item in control.Items)
            {
                CheckBox cbox = item.FindControl(checkID) as CheckBox;
                if (!string.IsNullOrEmpty(cbox.ToolTip))
                {
                    string id = cbox.ToolTip;
                    if (cbox.Checked)
                    {
                        arrCheckedIDS.Add(id);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        if (arrCheckedIDS.Count == 0)
        {
            JsAlert.ShowAlert("没有可操作项!");
        }
        return arrCheckedIDS;
    }

    #endregion



}


