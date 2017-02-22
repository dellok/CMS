using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LL.BLL.Admin;
using LL.Common;
using LL.BLL.Member;
using Project.Common;
using LL.Model.Member;
public partial class Member_MemberGroupList : System.Web.UI.Page
{
    BLLphome_enewsmembergroup bllMemberGoroup = new BLLphome_enewsmembergroup();

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

        string strMemberGroupName = txtMemberGroupName.Text.Trim();
        int  level=Format.DataConvertToInt(txtMemberGroupLevel.Text.Trim());
        int favoriteLimit = Format.DataConvertToInt(txtMemberFavoriteLimitNum.Text.Trim());
        int downLimit = Format.DataConvertToInt(txtDownLimitNum.Text.Trim());
        int msgLimit = Format.DataConvertToInt(txtMsgLimitNum.Text.Trim());
        int msgContentLimit = Format.DataConvertToInt(txtMsgContentLimtNum.Text.Trim());
        int showWeb=Format.DataConvertToInt(radioListRegisterInWeb.SelectedValue);
        int needCheck = Format.DataConvertToInt(radiolistNeedCheck.SelectedValue);
        
        phome_enewsmembergroup  groupmodel=new phome_enewsmembergroup();


        groupmodel.groupname = strMemberGroupName;
        groupmodel.favanum = favoriteLimit;
        groupmodel.level = level;
        groupmodel.msglen = msgContentLimit;
        groupmodel.msgnum = msgLimit;
      
        groupmodel.daydown = downLimit;
        groupmodel.canreg = showWeb;
        groupmodel.regchecked = needCheck;
        //注册表单
        groupmodel.formid = 0;


        int intR = bllMemberGoroup.Add(groupmodel);

        if (intR > 0)
        {

            btnAdd.Enabled = false;
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
        List<phome_enewsmembergroup> arrRole = bllMemberGoroup.GetAllListByCache().OrderBy(m => m.level).ToList() ;
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
        bllMemberGoroup.Delete(ID);
        BindList();
    }
    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataViewList_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {


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