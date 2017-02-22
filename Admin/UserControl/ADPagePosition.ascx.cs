using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using LL.Common.EnumClass;
using LL.BLL.AD;
public partial class UserControl_ADPagePosition : System.Web.UI.UserControl
{
    private readonly string Key_View_Value = "v";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {


            SetSelectedItem();
              

          

        }

    }

    protected void Page_Init(object sender, EventArgs e)
    {

        BindList();
    
    }
    void BindList()
    {

        foreach (string  strPagePosition in  BLLADList.PagePosition())
        {
            string itemv = strPagePosition.Trim();
            ListItem item = new ListItem(itemv, itemv);
            drplADPagePosition.Items.Add(item);
        }
        if (IsSearch)
        {
            ListItem otherItem = new ListItem("不限", "0");
            drplADPagePosition.Items.Insert(0, otherItem);
            drplADPagePosition.SelectedIndex = 0;

        }

     

    }

    #region   其它，或者不限项

    /// <summary>
    /// 是否有基它项
    /// </summary>
    private string Key_IsSearch = "IsSearch";
    /// <summary>
    /// 是否有基它项
    /// </summary>
    public bool IsSearch
    {


        get
        {
            bool IsDefault = false;
            if (ViewState[Key_IsSearch] != null)
            {
                IsDefault = Format.DataConvertToBool(ViewState[Key_IsSearch]);
            }
            return IsDefault;
        }
        set
        {

            ViewState[Key_IsSearch] = value;
        }


    }


    #endregion


    private string DefaultText = "不限";

    /// <summary>
    /// 设置城市
    /// </summary>
    public string SetValue
    {



        set { ViewState["v"] = value; SetSelectedItem(); }
        get { if (ViewState["v"] != null) { return ViewState["v"].ToString(); } else { return DefaultText; } }

    }
    private void SetSelectedItem()
    {       
        drplADPagePosition.SelectedIndex = drplADPagePosition.Items.IndexOf(drplADPagePosition.Items.FindByValue(SetValue));
    }



    /// <summary>
    /// 得到选择城市
    /// </summary>
    public string GetValue
    {
        get
        {
            return drplADPagePosition.SelectedValue.Trim();
        }
    }


}