using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using Project.Common;
public partial class UserControl_SexRadioList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {

            if (IsSearch)
            {
                ListItem  otherItem=new ListItem("不限","");
                otherItem.Selected = true;
                radioSexList.Items.Insert(0, otherItem);


            }

        }
    }




    #region  

    /// <summary>
    /// 是否有基它项
    /// </summary>
    private string Key_IsOther = "IsHasOtherItem";
    /// <summary>
    /// 是否有基它项
    /// </summary>
    public bool IsSearch
    {


        get {
            bool IsDefault = false;
            if (ViewState[Key_IsOther]!=null)
            {
               IsDefault = Format.DataConvertToBool(ViewState[Key_IsOther]);
            }
            return IsDefault;
        }
        set {

            ViewState[Key_IsOther] = value;
        }
    
    
    }


    #endregion

    private string DefultValue = "";

    /// <summary>
    /// 设置城市
    /// </summary>
    public string SetValue
    {
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                radioSexList.SelectedIndex = radioSexList.Items.IndexOf(radioSexList.Items.FindByValue(DefultValue));

            }
            else
            {
                radioSexList.SelectedIndex = radioSexList.Items.IndexOf(radioSexList.Items.FindByValue(value));
            }
        }
    }

    /// <summary>
    /// 得到选择城市
    /// </summary>
    public string GetValue
    {
        get
        {
            return radioSexList.SelectedValue.Trim();
        }


    }
}