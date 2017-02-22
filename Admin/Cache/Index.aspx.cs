using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using LL.Model.Temp;
using LL.BLL.Temp;

public partial class Cache_Index : System.Web.UI.Page
{
    BLLTempItem bllTemp = new BLLTempItem();
    private string cboxID = "cboxItem";
    public StringBuilder strPinDao = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindItem();
        }
    }

    private void BindItem()
    {
        List<TempItem> arr = bllTemp.GetModelAllByCache();
        if (arr.Count>0)
        {
           arr = arr.Where(m => m.IsCreateStaticPage == true).ToList();
        }
        foreach (TempItem item in  arr)
        {
        
       strPinDao.AppendFormat(" <input  type=\"checkbox\"  class=\"cboxPinDao\"  name=\"{0}\" value=\"{1}\"  />{0}", item.Name, item.Url);
       
        }
       
    }


}
