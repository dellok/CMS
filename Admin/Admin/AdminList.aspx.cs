using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using LL.BLL.Admin;

using Project.Common;
using System.Text;
using LL.Model.Admin;
using System.Data;
public partial class Admin_AdminList : AdminPage
{


    BLLAdminUser bllAdmin = new BLLAdminUser();

    protected void Page_Load(object sender, EventArgs e)
    {

 
        if (!Page.IsPostBack)
        {

            this.BindList();
        }


    }


   
 

    private void BindList()
    {

        string strName = txtLoginName.Text.Trim();
        int  roleid =Format.DataConvertToInt(ucAdminRoleList.GetValue);



       StringBuilder where=new StringBuilder();

        if (!string.IsNullOrEmpty(strName))
        {
            where.AppendFormat(" and   LoginName like '%{0}%'",strName);
         }
        if (roleid>0)
        {
            where.AppendFormat(" and  AdminRoleID={0}",roleid);
        
        }


        int PageIndex = pager.CurrentPageIndex;
        int PageSize = pager.PageSize;

  
        DataSet ds = bllAdmin.GetList(PageIndex, PageSize, where.ToString(),"  checked desc");

        if (ds.Tables.Count == 2)
        {
            int TotalRecords = 0;

            TotalRecords = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);

            pager.RecordCount = TotalRecords;


            dataListView.DataSource = ds.Tables[0];
            dataListView.DataBind();


        }
      
    }

    #region 修改，删除



    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

        DataList container = (DataList)sender;
        int ID = Format.DataConvertToInt(container.DataKeys[e.ItemIndex]);
        int intR = bllAdmin.Delete(ID);
        if (intR > 0)
        {
            this.BindList();
            JsAlert.ShowAlert(PubMsg.Msg_Delete_Success);
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);

        }

    }



    /// <summary>
    /// 开启
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataList_ItemCommand(object sender, ListViewCommandEventArgs e)
    {

        ///开启与关闭操作
        if (e.CommandName == "SetAdminCheck")
        {
            int AdminID=0;
            bool enabled = false;

            string[]   ids = e.CommandArgument.ToString().Split( new char[]{ PubConstant.Key_Sign_CommaSign});
            if (ids.Length==2)
            {
                AdminID=Format.DataConvertToInt(ids[0]);
                enabled=Format.DataConvertToBool(ids[1]);
	        }

            AdminUser model = bllAdmin.GetModel(AdminID);

            if (model != null)
            {
                model.Checked = enabled ? false : true;
                int intR = bllAdmin.Update(model);

                if (intR < 1)
                {

                    JsAlert.ShowAlert("开启用户过程中出现了问题，请与管理员联系!");
                }
            }
            else
            {
                JsAlert.ShowAlert("此用户信息丢失!");
            
            }
     

        }
    }

    #endregion
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }

    protected void cboxEnabled_CheckedChanged(object sender, EventArgs e)
    {
          CheckBox cbox = (CheckBox)sender;
        int id=Format.DataConvertToInt(cbox.ToolTip);


        if (id>0)
        {
            bllAdmin.SetAdminChecked(id, cbox.Checked);
        }


    }
    protected void pager_PageChanged(object sender, EventArgs e)
    {
        BindList();
    }
}