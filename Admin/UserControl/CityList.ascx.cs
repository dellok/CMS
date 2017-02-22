using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;

public partial class UserControl_CityList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (IsSearch)
            {
                ListItem otherItem = new ListItem("---不 限---", "");
     
                drplCity.Items.Insert(0, otherItem);
                drplCity.SelectedIndex = 0;
            }
        }
    
    
    }


   
     

    #region   其它，或者不限项

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


   private  string DefultValue = "";
 

  public string SetValue
  {


      set
      {

          if (string.IsNullOrEmpty(value))
          {
              drplCity.SelectedIndex = drplCity.Items.IndexOf(drplCity.Items.FindByValue(DefultValue));
          }
          else
          {
              drplCity.SelectedIndex = drplCity.Items.IndexOf(drplCity.Items.FindByValue(value));
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

      
          return drplCity.SelectedValue.Trim();
      }


  }
}