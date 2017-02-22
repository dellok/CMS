using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using Project.Common;
using LL.Model.Popedom;
using LL.BLL.Popedom;
public partial class UserControl_UCPopedomGroupDownList : System.Web.UI.UserControl
{
    /// <summary>
    /// 默认值
    /// </summary>
    private string DefultValue = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            drplPopedomGroupList.AutoPostBack = AutoPostBack;
            BindList();
        }
    }
    private void BindList()
    {
        BLLPopedomFunGroup bllFGroup = new BLLPopedomFunGroup();
        List<PopedomGroup> arrFunGroup = bllFGroup.GetModelAllByCache();
        drplPopedomGroupList.DataTextField = "Name";
        drplPopedomGroupList.DataValueField = "ID";
        drplPopedomGroupList.DataSource = arrFunGroup;
        drplPopedomGroupList.DataBind();


        if (IsSearch)
        {
            ListItem item = new ListItem("---请选择功能组---", "0");
            item.Selected = true;
            drplPopedomGroupList.Items.Insert(0, item);
            drplPopedomGroupList.AppendDataBoundItems = true;
        }



    }

    public string SetValue
    {


        set
        {

            if (string.IsNullOrEmpty(value))
            {
                drplPopedomGroupList.SelectedIndex = drplPopedomGroupList.Items.IndexOf(drplPopedomGroupList.Items.FindByValue(DefultValue));
            }
            else
            {
                drplPopedomGroupList.SelectedIndex = drplPopedomGroupList.Items.IndexOf(drplPopedomGroupList.Items.FindByValue(value));
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
            return drplPopedomGroupList.SelectedValue.Trim();
        }


    }


    /// <summary>
    /// 得到选择值
    /// </summary>
    public bool AutoPostBack
    {


        set
        {
            ViewState[PubConstant.key_AutoPostBack] = value;
        }

        get
        {

            if (ViewState[PubConstant.key_AutoPostBack] != null)
            {
                return Format.DataConvertToBool(ViewState[PubConstant.key_AutoPostBack]);
            }
            else
            {

                return false;
            }

        }


    }
    /// <summary>
    /// 得到选择值
    /// </summary>
    public bool IsSearch
    {


        set
        {
            ViewState["IsAppendEmptyItem"] = value;
        }

        get
        {

            if (ViewState["IsAppendEmptyItem"] != null)
            {
                return Format.DataConvertToBool(ViewState["IsAppendEmptyItem"]);
            }
            else
            {

                return true;
            }

        }


    }

    public void drplPopedomGroupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetValue = drplPopedomGroupList.SelectedValue;
    }
}