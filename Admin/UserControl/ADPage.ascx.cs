using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using LL.Common.EnumClass;
using LL.BLL.AD;
using LL.BLL.Temp;
using LL.Common;
using LL.Model.Temp;

public partial class UserControl_ADPage : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {





        if (!Page.IsPostBack)
        {

      
            SetSelectedItem();
        }
    }
    protected void  Page_Init(object sender, EventArgs e)
    {
        BindList();
 
       
    }


    void BindList()
    {

       BLLTempItem bllTemp = new BLLTempItem();
        List<TempItem> arr = bllTemp.GetModelAllByCache();

        foreach (TempItem temp in arr)
        {
            ListItem item = new ListItem(temp.ADPageName, temp.ADPageName);
            drplADPage.Items.Add(item);

        }

        //foreach (string   strPage in  BLLADList.GetADPage())
        //{
        //    ListItem item = new ListItem(strPage, strPage);
        //    drplADPage.Items.Add(item);
          
        //}

        if (IsSearch)
        {
            ListItem otherItem = new ListItem("不限", "0");
            drplADPage.Items.Insert(0, otherItem);
            drplADPage.SelectedIndex = 0;
        }




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


    private string DefaultText = "全局";

    /// <summary>
    /// 设置城市
    /// </summary>
    public string SetValue
    {



        set { ViewState["v"] = value; SetSelectedItem();  }
        get { if (ViewState["v"] != null) { return ViewState["v"].ToString(); } else { return DefaultText; } }
      
    }
    private void SetSelectedItem()
    {


        drplADPage.SelectedIndex = drplADPage.Items.IndexOf(drplADPage.Items.FindByText(SetValue));

    }
    /// <summary>
    /// 得到选择城市
    /// </summary>
    public string GetValue
    {
        get
        {
          
            return drplADPage.SelectedValue.Trim();
        }
    }


}