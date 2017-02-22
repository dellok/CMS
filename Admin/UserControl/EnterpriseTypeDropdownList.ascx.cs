using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_EnterpriseType : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    } private string DefultValue = "制造企业";

    /// <summary>
    /// 设置城市
    /// </summary>
    public string SetValue
    {
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                drplEnterprise.SelectedIndex = drplEnterprise.Items.IndexOf(drplEnterprise.Items.FindByValue(DefultValue));

            }
            else
            {
                drplEnterprise.SelectedIndex = drplEnterprise.Items.IndexOf(drplEnterprise.Items.FindByValue(value));
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
            return drplEnterprise.SelectedValue.Trim();
        }


    }
}