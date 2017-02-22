using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;

public partial class UserControl_IndustryList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

       

   
    }

    protected void Page_Init(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {
            if (IsHasOtherItem)
            {

                drplIndustry.SelectedItem.Selected = false;
                ListItem otherItem = new ListItem("---不限---", "0");
                otherItem.Selected = true;
                drplIndustry.Items.Insert(0, otherItem);

            

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
    public bool IsHasOtherItem
    {


        get
        {
            bool IsDefault = false;
            if (ViewState[Key_IsOther] != null)
            {
                IsDefault = Format.DataConvertToBool(ViewState[Key_IsOther]);
            }
            return IsDefault;
        }
        set
        {

            ViewState[Key_IsOther] = value;
        }


    }


    #endregion

  private  string DefultValue = "食品";
 
    /// <summary>
    /// 设置城市
    /// </summary>
  public string  SetValue
  {

     
      set {

          if (string.IsNullOrEmpty(value))
          {
             drplIndustry.SelectedIndex = drplIndustry.Items.IndexOf(drplIndustry.Items.FindByValue(DefultValue));
          }
          else
          {
              drplIndustry.SelectedIndex = drplIndustry.Items.IndexOf(drplIndustry.Items.FindByValue(value));
          }
      }
  }

    /// <summary>
    /// 得到选择城市
    /// </summary>
  public string GetValue
  {
      get {


          return drplIndustry.SelectedValue.Trim();

         
      }

  
  }
}