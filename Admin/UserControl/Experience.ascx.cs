using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_ExperienceRadioList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

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
                radioExperienceList.SelectedIndex = radioExperienceList.Items.IndexOf(radioExperienceList.Items.FindByValue(DefultValue));
            }
            else
            {
                radioExperienceList.SelectedIndex = radioExperienceList.Items.IndexOf(radioExperienceList.Items.FindByValue(value));
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
            return  radioExperienceList.SelectedValue;
        }


    }
}