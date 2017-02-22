using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Data.Linq;
using LL.BLL.Popedom;
using Project.Common;
using LL.Common;
using LL.Model.Popedom;

public partial class FunGroup : AdminPage
{
    
    BLLPopedomFunGroup bllFGroup = new BLLPopedomFunGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //绑定数据
            BindList();
        }
    }
    /// <summary>
    /// 绑定列表
    /// </summary>
    public void BindList()
    {
        List<PopedomGroup> arrGroup = bllFGroup.GetModelAllByCache();
        dataListView.DataSource = arrGroup;
        dataListView.DataBind();
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

        int intR = bllFGroup.Delete(ID);


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

        string EditGroupID = "txtEditGroupName";
        string EditOrderID = "txtEditOrder";
        string EditRemarkID = "txtEditRemark";
        string EditCboxISShow = "cboxIsShow";


        ListView control = (ListView)sender;
        ListViewDataItem rowItem = control.Items[e.ItemIndex];

        int ID = Format.DataConvertToInt(control.DataKeys[e.ItemIndex].Value);
        string Name = ((TextBox)rowItem.FindControl(EditGroupID)).Text;
        string Remark = ((TextBox)rowItem.FindControl(EditRemarkID)).Text;
        int Order = Format.DataConvertToInt(((TextBox)rowItem.FindControl(EditOrderID)).Text.Trim());
        bool IsShow = Format.DataConvertToBool(((CheckBox)rowItem.FindControl(EditCboxISShow)).Checked);
        PopedomGroup model = bllFGroup.GetModel(ID);
        //是否需要更改
        if (model.Name != Name || model.Remark != Remark || model.Order != Order ||  model.IsShow!=IsShow)
        {
            model.Name = Name;
            model.Remark = Remark;
            model.Order = Order;
            model.IsShow = IsShow;

            int intR = bllFGroup.Update(model);

            if (intR > 0)
            {

                control.EditIndex = -1;
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
        string Remark = this.txtRemark.Text;
        int Order = Format.DataConvertToInt(this.txtOrder.Text);

        PopedomGroup model = new PopedomGroup();
        model.Name = Name;
        model.Remark = Remark;
        model.Order = Order;
        model.IsShow = Format.DataConvertToBool(rbtnShowInMenu.SelectedValue);
        int intR = bllFGroup.Add(model);

        if (intR > 0)
        {

            BindList();
            JsAlert.ShowAlert(PubMsg.Msg_AddSuccess);
        
        }
        else
        {

            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);

        }
        txtOrder.Text = "0";
     
        txtName.Text = "";
        txtRemark.Text = "";
        BindList();
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
            errormsg += "请输入分组名称！\\n";
        }
        if (txtOrder.Text.Trim() == "")
        {
            errormsg += "请填写显示顺序!\\n";
        }

        if (!Util.IsNumeric(txtOrder.Text))
        {
            errormsg += "显示顺序只能输入数字！";
        }

        if (!string.IsNullOrEmpty(errormsg))
        {
            errmsg = errormsg;
            return false;
        }
        return true;
    }
    #endregion
 
}
