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
public partial class UserControl_TempDropdownList : System.Web.UI.UserControl
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
        BLLTempItem bllTemp = new BLLTempItem();
        List<TempItem> arrRole = bllTemp.GetModelAllByCache();
        drplTempList.DataSource = arrRole;
        drplTempList.DataTextField = "Name";
        drplTempList.DataValueField = "ID";
        drplTempList.DataBind();
        ListItem otherItem = new ListItem("---默认(/templete/News/list.aspx)---", "0");
        drplTempList.SelectedIndex = -1;
        drplTempList.Items.Insert(0, otherItem);


    }

    /// <summary>
    /// 设置城市
    /// </summary>
    public string SetValue
    {
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                drplTempList.SelectedIndex = 0;

            }
            else
            {
                drplTempList.SelectedIndex = drplTempList.Items.IndexOf(drplTempList.Items.FindByValue(value));
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
            return drplTempList.SelectedValue.Trim();
        }


    }
}