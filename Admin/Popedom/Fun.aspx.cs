using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using LL.BLL.Popedom;
using Project.Common;
using System.Text;
using LL.Model.Popedom;
using System.Data;
public partial class Popedom_Fun : System.Web.UI.Page
{
    BLLPopedomFun bllFun = new BLLPopedomFun();

    BLLPopedomFunGroup bllGroup = new BLLPopedomFunGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDrplPopedomGroup();
            BindList();
        }
    }
    /// <summary>
    /// 绑定列表
    /// </summary>
    public void BindList()
    {
        int FunGroupID =Format.DataConvertToInt(drplPGroup.SelectedValue);

        string where = "";
        if (FunGroupID > 0)
        {
          where += string.Format("    PopedomGroupID={0}",FunGroupID);
        }

        int PageIndex = pager.CurrentPageIndex;
        int PageSize = pager.PageSize;


        DataSet ds = bllFun.GetList(PageIndex, PageSize, where);

        if (ds.Tables.Count == 2)
        {
                 int TotalRecords = 0;

                 TotalRecords = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
        
                 pager.RecordCount = TotalRecords;

        
                dataListView.DataSource = ds.Tables[0];
                dataListView.DataBind();
      

        }


    }


    private void BindDrplPopedomGroup()
    {

        List<PopedomGroup> arrFunGroup = bllGroup.GetModelAllByCache();
        drplPGroup.DataTextField = "Name";
        drplPGroup.DataValueField = "ID";
        drplPGroup.DataSource = arrFunGroup;
        drplPGroup.DataBind();
        ListItem item = new ListItem("---请选择功能组---", "0");
        item.Selected = true;
        drplPGroup.Items.Insert(0, item);


        drplPGroupAdd.DataTextField = "Name";
        drplPGroupAdd.DataValueField = "ID";
        drplPGroupAdd.DataSource = arrFunGroup;
        drplPGroupAdd.DataBind();
    }



    #region  操作 增删，改
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        ListView control = (ListView)sender;

        int ID = Format.DataConvertToInt(control.DataKeys[e.ItemIndex].Value);

        int intR = bllFun.Delete(ID);


        if (intR > 0)
        {
            BindList();
        }
        else
        {

            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);

        }
    }
    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataListView_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
      
        dataListView.EditIndex = -1;
        this.BindList();

    }
    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataListView_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {

        string EditTextFunNameID = "txtEditFunName";
        string EditFunGroupDropDownListID = "drplEditPGroup";
        string EditTextUrlID = "txtEditUrl";
        string EditCboxIsShowID = "cboxIsShow";


        ListView control = (ListView)sender;
        ListViewDataItem rowItem = control.Items[e.ItemIndex];

         

        int ID = Format.DataConvertToInt(control.DataKeys[e.ItemIndex].Value);

        string Name = ((TextBox)rowItem.FindControl(EditTextFunNameID)).Text;
        string Url = ((TextBox)rowItem.FindControl(EditTextUrlID)).Text;
        int FunGroupID = Format.DataConvertToInt(((DropDownList)rowItem.FindControl(EditFunGroupDropDownListID)).SelectedValue);
        bool IsShow = Format.DataConvertToBool(((CheckBox)rowItem.FindControl(EditCboxIsShowID)).Checked);


        PopedomFun model = bllFun.GetModel(ID);
        //是否需要更改
        if (model.Name != Name || model.Url != Url || model.showInMenu != IsShow || model.PopedomGroupID != FunGroupID)
        {
            model.Name = Name;
            model.PopedomGroupID = FunGroupID;
            model.showInMenu = IsShow;
            model.Url = Url;
            int intR = bllFun.Update(model);

            if (intR > 0)
            {

                dataListView.EditIndex = -1;
                BindList();
                JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);

            }
            else
            {

                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);

            }
        }
    }

    /// <summary>
    /// 编辑 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataListView_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        dataListView.EditIndex = e.NewEditIndex;
        this.BindList();

    }


    /// <summary>
    /// 添加跟新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string error = "";

        if (!checkInput(ref error))
        {
            JsAlert.ShowAlert(error);
            return;
        }
        string Name = this.txtName.Text;
        string Url = this.txtUrl.Text;
        int PopedomGroupID = Format.DataConvertToInt(drplPGroupAdd.SelectedValue);

        PopedomFun model = new PopedomFun();

        model.Name = Name;
        model.Url = Url;
        model.showInMenu = Format.DataConvertToBool(rbtnShowInMenu.SelectedValue);
        model.PopedomGroupID = PopedomGroupID;

        int intR = bllFun.Add(model);

        if (intR > 0)
        {

            BindList();
            JsAlert.ShowAlert(PubMsg.Msg_AddSuccess);

        }
        else
        {

            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);

        }

    }


    /// <summary>
    /// 输入检测
    /// </summary>
    /// <param name="errmsg"></param>
    /// <returns></returns>
    public bool checkInput(ref string errmsg)
    {
        string errormsg = "";
        if (txtName.Text.Trim() == "")
        {
            errormsg += "请输入功能模块名称！\\n";
        }
        if (txtUrl.Text.Trim() == "")
        {
            errormsg += "请填写页面路径！\\n";
        }
        if (!string.IsNullOrEmpty(errormsg))
        {
            errmsg = errormsg;
            return false;
        }
        return true;
    }
    #endregion

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }

    /// <summary>
    /// 得到分组名称
    /// </summary>
    /// <param name="pid"></param>
    /// <returns></returns>
    public string GetPopedomGroupName(object pid)
    {

        PopedomGroup model = bllGroup.GetModelByCache(Format.DataConvertToInt(pid));

        if (model != null)
        {

            return model.Name;
        }
        else
        {

            return "分组信息丢失!";

        }


    }



    protected void drpPGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList();
    }
    protected void dataListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

        if (e.Item.ItemType == ListViewItemType.DataItem)
        {

            DropDownList pGroup = (DropDownList)e.Item.FindControl("drplEditPGroup");

            if (pGroup!=null)
            {
                List<PopedomGroup> arrFunGroup = bllGroup.GetModelAllByCache();
                pGroup.DataTextField = "Name";
                pGroup.DataValueField = "ID";
                pGroup.DataSource = arrFunGroup;
                pGroup.DataBind();
                HiddenField hideGID = (HiddenField)e.Item.FindControl("hGID");
                pGroup.SelectedIndex = pGroup.Items.IndexOf(pGroup.Items.FindByValue(hideGID.Value));


            }
        
        }


    }


    protected void pager_PageChanged(object sender, EventArgs e)
    {
        BindList();

    }


   
}