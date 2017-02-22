using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_CityRadioList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

     
    }

   private  string DefultValue = "北京";
 
    /// <summary>
    /// 设置城市
    /// </summary>
  public string  SetValue
  {

     
      set {

          if (string.IsNullOrEmpty(value))
          {
              radioCityList.SelectedIndex = radioCityList.Items.IndexOf(radioCityList.Items.FindByValue(DefultValue));
          }
          else
          {
              radioCityList.SelectedIndex = radioCityList.Items.IndexOf(radioCityList.Items.FindByValue(value));
          }
      }
  }

    /// <summary>
    /// 得到选择城市
    /// </summary>
  public string GetValue
  {
      get {
          return radioCityList.SelectedValue.Trim();
      }

  
  }
}