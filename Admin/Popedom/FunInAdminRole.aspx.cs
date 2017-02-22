using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LL.BLL.Popedom;

using System.Data;
using System.Text;
using Project.Common;
using LL.BLL.Admin;
using LL.Model.Popedom;
using LL.Common;
public partial class Popedom_FunInAdminRole :AdminPage
{
    BLLPopedomFunInAdminRole bllFInRole = new BLLPopedomFunInAdminRole();
    BLLPopedomFunGroup bllFGroup = new BLLPopedomFunGroup();
    BLLAdminRole bllAdminRole = new BLLAdminRole();
    BLLPopedomFun bllFun = new BLLPopedomFun();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindAdminRole();
            WritePopedomList();
        }

    }


    #region 绑定会员角色
    private void BindAdminRole()
    {
        listboxAdminRole.DataSource = bllAdminRole.GetModelAllByCache();
        listboxAdminRole.DataTextField = "RoleName";
        listboxAdminRole.DataValueField = "ID";
        listboxAdminRole.DataBind();
        InitSelectedItem();
    }
    private void InitSelectedItem()
    {
        if (Request[PubConstant.Key_AdminRole] != null)
        {
            int AdminRoleID = Format.DataConvertToInt(Request[PubConstant.Key_AdminRole]);
            listboxAdminRole.Items.FindByValue(AdminRoleID.ToString()).Selected = true;
        }
    }
    #endregion
    /// <summary>
    /// 权限列表
    /// </summary>
    public void WritePopedomList()
    {
        //会员角色ID
        int RoleID = Format.DataConvertToInt(listboxAdminRole.SelectedValue);

        StringBuilder html = new StringBuilder();

        List<PopedomGroup> arrFGroup = bllFGroup.GetModelAll();
        foreach (var item in arrFGroup)
        {
            html.AppendFormat("<div class=\"div_list\">");
            ///组名

            int grounid = item.ID;
            html.AppendFormat("<div class=\"div_title\">{0} <input type=\"checkbox\"  onclick=\"javascript:$('.c_{1}').attr('checked',this.checked)\"    /> </div>", item.Name, grounid);
            //最出角色关联的功能 最出组关联的 页面(功能)

            List<PopedomFun> arrFun = bllFun.SelectByGroupFromCache(item.ID);
            List<PopedomFunInAdminRole> arrFInRole = bllFInRole.SelectFunByRoleFromCache(RoleID);

            foreach (var fun in arrFun)
            {
                ///生成CheckBox
                int isCheck = arrFInRole.Where(m => m.PopedomFunID == fun.ID).Count();
                string ichecked = isCheck > 0 ? "checked='checked'" : "";
            
                html.AppendFormat("<div class=\"div_popedom\"><input type=\"checkbox\"  name=\"{3}\"  class=\"c_{4}\"   {0}   value=\"{1}\" />{2} </div> ", ichecked, fun.ID, fun.Name, PubConstant.Key_PopedomFun,grounid);
           
            }
      
            html.AppendFormat("</div>");
        }

        lblFunList.Text = html.ToString();


    }


    #region  得到编辑的权限
    /// <summary>
    /// 提交信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEditFunInRole_Click(object sender, EventArgs e)
    {

        int AdminRoleID = Format.DataConvertToInt(listboxAdminRole.SelectedValue);
        //得到选择的权限信息
        string strFunIDS = Format.RequestToString(PubConstant.Key_PopedomFun);

        if (!string.IsNullOrEmpty(strFunIDS) && AdminRoleID>0)
        {

            //最出信息

            string[] arrStrFunIDS = strFunIDS.Split(new char[] { PubConstant.Key_Sign_CommaSign });


            if (arrStrFunIDS.Count() > 0)
            {

                int intR = bllFInRole.EditFunInAdminRole(AdminRoleID, arrStrFunIDS);


                if (intR > 0)
                {


                    JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);
                }
               
            }

        }

        WritePopedomList();
    }

    #endregion
    protected void listboxAdminRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        WritePopedomList();
    }
}