using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using Project.Common;
using LL.BLL.News;

using System.Text;
using LL.Model.News;
public partial class Category_DialogClassListBox : System.Web.UI.Page
{

    BLLphome_enewsclass bllClass = new BLLphome_enewsclass();


    int sIndex = 0;
    int eIndex = 4;
    int  classid = 0;
    int pclassid = 0;
    string lblClassID = "";
    string lblClassPathID = "";
    string pHideClassID = "";

    protected void Page_Load(object sender, EventArgs e)
    {

              GetReq();
        if (!Page.IsPostBack)
        {
            BindFirstClass();
            SetCurrentClass();
        }


        string js = string.Format(" var lblClassID='#{0}';var lblClassPath='#{1}';  var  pHideClassID='#{2}'; ", lblClassID, lblClassPathID, pHideClassID);
        JsAlert.WriteJs(js, false);
      
    }
    /// <summary>
    /// 设置当前分类
    /// </summary>
    private void SetCurrentClass()
    {
        hideCurrentClassID.Value = classid.ToString();
    }

    private void BindFirstClass()
    {
        FillTreeValue(pclassid, lstboxClass_0);
    }
 
    #region GetControl,ClearSonControlItem

    public ListBox GetControl(int index)
    {
        ListBox tempControl = null;
        switch (index)
        {
            case 0: tempControl = lstboxClass_0; break;
            case 1: tempControl = lstboxClass_1; break;
            case 2: tempControl = lstboxClass_2; break;
            case 3: tempControl = lstboxClass_3; break;
            //case 4: tempControl = lstboxClass_4; break;
            //case 5: tempControl = lstboxClass_5; break;
            //case 6: tempControl = lstboxClass_6; break;
            //case 7: tempControl = lstboxClass_7; break;
            //case 8: tempControl = lstboxClass_8; break;
            //case 9: tempControl = lstboxClass_9; break;
            default:
                tempControl = lstboxClass_0; break;
        }
        return tempControl;
    }

    public void ClearSonControlItem(int CurrentIndex)
    {
        for (int i = CurrentIndex + 1; i < eIndex; i++)
        {
            ListBox control = GetControl(i);
            if (control != null)
            {
                control.Items.Clear();
            }
        }
    }
    #endregion

    #region  显示列表

    protected void lstboxClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBox currentBox = (ListBox)sender;
        int Index = Format.DataConvertToInt(currentBox.ToolTip);
        int NextIndex = Index + 1;
        NextIndex = NextIndex > eIndex ? eIndex : NextIndex;
        int currentClassID = Format.DataConvertToInt(currentBox.SelectedValue);

        SetCurrentPath(currentClassID);
        ClearSonControlItem(Index);
        //是否不子项
        if (bllClass.ExistsSonNode(currentClassID) > 0)
        {
            FillTreeValue(currentClassID,GetControl(NextIndex));
        }
    }
    /// <summary>
    /// 显示当前选择项的路径
    /// </summary>
    /// <param name="currentClassID"></param>
    private void SetCurrentPath(int currentClassID)
    {
        List<string> arrClassName = new List<string>();
        bllClass.GetClassPathFromCache(currentClassID,ref arrClassName);
        StringBuilder strPath = new StringBuilder();
        if (arrClassName.Count()>0)
        {
            for (int i = 0; i < arrClassName.Count(); i++)
            {
                strPath.AppendFormat("{0}>>",arrClassName[i]);  
            }
        }
        hideCurrentClassID.Value = currentClassID.ToString();
        hideIsHaveSonNode.Value = bllClass.ExistsSonNode(currentClassID).ToString();
        string cn = strPath.ToString();
        if (cn.EndsWith(">>"))
        {
            cn = cn.Substring(0, cn.Length - 2);
        }
        lblCurrentClassName.Text = cn;
    }
    public void  FillTreeValue(int CurrentClasssID,ListBox  ShowSonClassControl)
    {
        List<phome_enewsclass> arrNewsClass = bllClass.GetSonClassByIDFromCache(CurrentClasssID).OrderBy(m=>m.classid).ToList();
        ShowSonClassControl.Items.Clear();
        foreach (phome_enewsclass item in arrNewsClass)
        {
            ShowSonClassControl.Items.Add(new ListItem(item.classname,item.classid.ToString()));
        }
    }
    #endregion
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        //检查当前选择项是否是最终分类
        int intFinalClassID = Format.DataConvertToInt(hideCurrentClassID.Value);
        if (bllClass.ExistsSonNode(intFinalClassID) > 0)
        {
            JsAlert.ShowAlert("当前所选择分类不是最终分类，请选择最终分类!");
        }
    }
    void GetReq()
    {
        if (Request["classid"]!=null)
        {
          classid = Format.DataConvertToInt(Request["classid"]);
        }

        if (Request["pClassid"]!=null)
        {
            pclassid = Format.DataConvertToInt(Request["pClassID"]);
        }
        if (Request["pHideClassID"] != null)
        {
            pHideClassID = Request["pHideClassID"];
        }

        if (Request["lblClassID"]!=null)
        {
            lblClassID = Request["lblClassID"];
        }

        if (Request["lblClassPathID"] != null)
        {
            lblClassPathID = Request["lblClassPathID"];
            
        }
    }
}