using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using LL.Common;

public partial class UserControl_MainWorldAreaCityCheckboxList : System.Web.UI.UserControl
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
            if (!string.IsNullOrEmpty(value))
            {
                //得到分各后的字符串
                string[] arrValue = value.Split(new char[] {PubConstant.Key_Sign_BrokenbarSign });
                foreach (string item in arrValue)
                {
                    ListItem curItem = cboxWorldAreaCityList.Items.FindByValue(item);
                    if (curItem!=null)
                    {
                        curItem.Selected = true;
                    }
                }
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

            StringBuilder arr = new StringBuilder();

            foreach (ListItem item in cboxWorldAreaCityList.Items)
            {
                if (item.Selected)
                {

                    arr.AppendFormat("{0}{1}", item.Value, PubConstant.Key_Sign_BrokenbarSign.ToString());

                }
            }
            string arrV = arr.ToString();

            if (!string.IsNullOrEmpty(arrV))
            {
                arrV = arrV.TrimStart(new char[] { PubConstant.Key_Sign_BrokenbarSign });
                arrV = arrV.TrimEnd(new char[] { PubConstant.Key_Sign_BrokenbarSign });
            }
            return arrV;
        }


    }
}