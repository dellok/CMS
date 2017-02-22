using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using LL.BLL.Member;

using Project.Common;
using LL.Model.Member;

public partial class Member_MemberGroupUpdate : AdminPage
{
    BLLphome_enewsmembergroup bllMemberGoroup = new BLLphome_enewsmembergroup();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            ShowInfo();
        }
    }


    /// <summary>
    /// 显示信息
    /// </summary>
    private void ShowInfo()
    {

        if (base.GetReqIDValue> 0)
        {

            phome_enewsmembergroup group = bllMemberGoroup.GetModelFromCache(base.GetReqIDValue);


            if (group != null)
            {

                txtMemberGroupName.Text = group.groupname;
                txtMemberGroupLevel.Text = group.level.ToString();
                txtMemberFavoriteLimitNum.Text = group.favanum.ToString();
                txtDownLimitNum.Text = group.daydown.ToString();
                txtMsgLimitNum.Text = group.msgnum.ToString();
                txtMsgContentLimtNum.Text = group.msglen.ToString();


                radioListRegisterInWeb.SelectedIndex = radioListRegisterInWeb.Items.IndexOf(radioListRegisterInWeb.Items.FindByValue(group.canreg.ToString()));
                radiolistNeedCheck.SelectedIndex = radiolistNeedCheck.Items.IndexOf(radiolistNeedCheck.Items.FindByValue(group.regchecked.ToString()));

            }
            else
            {
                JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInCurrent,PubMsg.Msg_DataInfo_Lost,"MemberGroupList.aspx");
                btnUpdate.Enabled = false;
            }
          


        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_DataInfo_Lost);
            btnUpdate.Enabled = false;


        }
    }



    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        string strMemberGroupName = txtMemberGroupName.Text.Trim();
        int level = Format.DataConvertToInt(txtMemberGroupLevel.Text.Trim());
        int favoriteLimit = Format.DataConvertToInt(txtMemberFavoriteLimitNum.Text.Trim());
        int downLimit = Format.DataConvertToInt(txtDownLimitNum.Text.Trim());
        int msgLimit = Format.DataConvertToInt(txtMsgLimitNum.Text.Trim());
        int msgContentLimit = Format.DataConvertToInt(txtMsgContentLimtNum.Text.Trim());
        int showWeb = Format.DataConvertToInt(radioListRegisterInWeb.SelectedValue);
        int  needCheck = Format.DataConvertToInt(radiolistNeedCheck.SelectedValue);

        phome_enewsmembergroup groupmodel = bllMemberGoroup.GetModel(base.GetReqIDValue);


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


        int intR = bllMemberGoroup.Update(groupmodel);

        if (intR > 0)
        {

            btnUpdate.Enabled = false;
            ShowInfo();

            JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);

        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);

        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("MemberGroupList.aspx",true);

    }
}