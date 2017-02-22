using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_CompanyTypeDropdownList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
                drplCompanyList.SelectedIndex = 0;

            }
            else
            {
               drplCompanyList.SelectedIndex =drplCompanyList.Items.IndexOf(drplCompanyList.Items.FindByValue(value));
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
            return  drplCompanyList.SelectedValue.Trim();
        }


    }
}