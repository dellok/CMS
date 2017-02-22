using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LL.Common;
using Project.Common;
using LL.BLL.Member;
using LL.Model.Member;

public partial class UserControl_UCMemberGroup : System.Web.UI.UserControl
{

    /// <summary>
    /// 默认值
    /// </summary>
    private string DefultValue = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            drplMemberGroupList.AutoPostBack = AutoPostBack;
            BindList();

            SetSelectedItem();
        }
    }

    private void SetSelectedItem()
    {
        drplMemberGroupList.SelectedIndex = drplMemberGroupList.Items.IndexOf(drplMemberGroupList.Items.FindByValue(SetValue));
    }
    private void BindList()
    {


        BLLphome_enewsmembergroup bllMemberGroup = new BLLphome_enewsmembergroup();
        List<phome_enewsmembergroup> arrFunGroup = bllMemberGroup.GetAllListByCache().OrderBy(m=>m.level).ToList();
       
        drplMemberGroupList.DataSource = arrFunGroup;

        drplMemberGroupList.DataTextField = "groupname";
        drplMemberGroupList.DataValueField = "groupid";
        
        drplMemberGroupList.DataBind();


        if (IsAppendEmptyItem)
        {
            ListItem item = new ListItem("---请选择会员组---", "0");
            item.Selected = true;
            drplMemberGroupList.Items.Insert(0, item);
            drplMemberGroupList.AppendDataBoundItems = true;
        }
    }

    public string SetValue
    {
        set { ViewState["v"] = value; }
        get { if (ViewState["v"] != null) { return ViewState["v"].ToString(); } else { return DefultValue; } }

    }

    /// <summary>
    /// 得到选择值
    /// </summary>
    public string GetValue
    {
        get
        {
            return drplMemberGroupList.SelectedValue.Trim();
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
    public bool IsAppendEmptyItem
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

    public void drplMemberGroupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetValue = drplMemberGroupList.SelectedValue;
    }
}