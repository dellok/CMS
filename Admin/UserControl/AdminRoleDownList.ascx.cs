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

public partial class UCAdminRoleDownList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }

   
    void Page_Init(object sender, EventArgs e)
    {


        BindList();

    }
    void BindList()
    {
        BLLAdminRole bllRole = new BLLAdminRole();

        List<AdminRole> arrRole = bllRole.GetModelAllByCache();
        drplAdminRole.DataSource = arrRole;
        drplAdminRole.DataTextField = "RoleName";
        drplAdminRole.DataValueField = "ID";
        drplAdminRole.DataBind();

        if (IsSearch)
        {
            ListItem otherItem = new ListItem("---请选择管理员角色(默认为全部)---", "0");
            drplAdminRole.SelectedIndex = -1;
            drplAdminRole.Items.Insert(0, otherItem);
        }

    }
    #region   其它，或者不限项


    public bool IsSearch
    {


        get
        {
            
            bool IsDefault = false;
            if (ViewState[PubConstant.Key_IsSearch] != null)
            {
                IsDefault = Format.DataConvertToBool(ViewState[PubConstant.Key_IsSearch]);
            }
            return IsDefault;
        }
        set
        {

            ViewState[PubConstant.Key_IsSearch] = value;
        }


    }


    #endregion


    private string DefultValue = "0";

    public string SetValue
    {


        set
        {

            if (string.IsNullOrEmpty(value))
            {
                drplAdminRole.SelectedIndex = drplAdminRole.Items.IndexOf(drplAdminRole.Items.FindByValue(DefultValue));
            }
            else
            {
                drplAdminRole.SelectedIndex = drplAdminRole.Items.IndexOf(drplAdminRole.Items.FindByValue(value));
            }
        }
    }

    /// <summary>
    /// 得到选择值
    /// </summary>
    public string GetValue
    {
        get
        {
            return drplAdminRole.SelectedValue.Trim();
        }


    }


}