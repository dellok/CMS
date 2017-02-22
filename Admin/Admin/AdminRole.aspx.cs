using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;

using LL.BLL.Admin;
using LL.Common;
using LL.Model.Admin;
public partial class Admin_AdminRole : System.Web.UI.Page
{

    BLLAdminRole bllARole = new BLLAdminRole();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindList();
        }
    }

    #region  增加会员
    /// <summary>
    /// 增加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string RoleName = txtName.Text.Trim();
        bool Enabled = cboxEnabled.Checked;
        AdminRole roleModel = new AdminRole();
        roleModel.RoleName = RoleName;
        roleModel.InDate = DateTime.Now;
        roleModel.Remark = txtRemark.Text;

        int intR = bllARole.Add(roleModel);

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
    /// 绑定列表
    /// </summary>
    private void BindList()
    {
        List<AdminRole> arrRole = bllARole.GetModelAllByCache();
        dataViewList.DataSource = arrRole;
        dataViewList.DataBind();
    }
    #endregion

    #region 修改，删除   ,编辑
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataViewList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        int ID = Format.DataConvertToInt(dataViewList.DataKeys[e.ItemIndex].Value);
        bllARole.Delete(ID);
        BindList();
    }
    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataViewList_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {


        int ID = Format.DataConvertToInt(dataViewList.DataKeys[e.ItemIndex].Value);

        string txtNameID = "txtEditName";
        string txtRemarkID = "txtEditRemark";
        string cboxEditEnabled = "cboxEditEnabled";

        ListViewDataItem row = dataViewList.Items[e.ItemIndex];

        string strName = (row.FindControl(txtNameID) as TextBox).Text.Trim();
        bool enabled = (row.FindControl(cboxEditEnabled) as CheckBox).Checked;
        string remark = (row.FindControl(txtRemarkID) as TextBox).Text.Trim();

        AdminRole editModel = bllARole.GetModel(ID);

        if (strName != editModel.RoleName || enabled != editModel.Enabled || remark != editModel.Remark)
        {

            editModel.RoleName = strName;
            editModel.Remark = remark;
            editModel.Enabled = enabled;
            bllARole.Update(editModel);

            dataViewList.EditIndex = -1;
            this.BindList();
          
        }

    }
    protected void dataViewList_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {

        dataViewList.EditIndex = -1;
        BindList();



    }
    protected void dataViewList_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        dataViewList.EditIndex = e.NewEditIndex;
        BindList();

    }
    #endregion
}