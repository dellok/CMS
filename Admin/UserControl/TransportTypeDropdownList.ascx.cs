using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_TransportTypeDropdownList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    } private string DefultValue = "公路运输";

    /// <summary>
    /// 设置城市
    /// </summary>
    public string SetValue
    {
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                drplTransport.SelectedIndex = drplTransport.Items.IndexOf(drplTransport.Items.FindByValue(DefultValue));

            }
            else
            {
                drplTransport.SelectedIndex = drplTransport.Items.IndexOf(drplTransport.Items.FindByValue(value));
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
            return drplTransport.SelectedValue.Trim();
        }


    }
}