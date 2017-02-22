using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.BLL.Temp;
using LL.Model.Temp;
using Project.Common;
using LL.Common;
public partial class UserControl_TempTypeDropdownList : System.Web.UI.UserControl
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



        BindControl.DropDownListBindEnum(drplTempType, typeof(LL.Common.EnumClass.Temp.TempType), IsSearch, LL.Common.EnumClass.EnumUtility.EnumBindControlValueType.默认);
        //BLLTempItem bllTemp = new BLLTempItem();
        //List<TempItem> arrRole = bllTemp.GetModelAllByCache();
        //drplTempType.DataSource = arrRole;
        //drplTempType.DataTextField = "Name";
        //drplTempType.DataValueField = "ID";
        //drplTempType.DataBind();
        //if (IsSearch)
        //{
        //    ListItem otherItem = new ListItem("---全部类型---", "");
        //    drplTempType.SelectedIndex = -1;
        //    drplTempType.Items.Insert(0, otherItem);
        //}

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

    /// <summary>
    /// 设置城市
    /// </summary>
    public string SetValue
    {
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                drplTempType.SelectedIndex = 0;

            }
            else
            {
                drplTempType.SelectedIndex = drplTempType.Items.IndexOf(drplTempType.Items.FindByValue(value));
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
            return drplTempType.SelectedValue.Trim();
        }


    }
}