using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using LL.BLL.Admin;
using LL.Model.Admin;
using Project.Common;
public partial class AdminPostNewsTotal : System.Web.UI.Page
{
    BLLAdminUser bllAdmin = new BLLAdminUser();
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            BindAdminList();
            BindList();

        }
    }

    private void BindAdminList()
    {

   List<AdminUser>  arr=   bllAdmin.GetModelAllByCache();

   drplAdmin.DataSource = arr;
   drplAdmin.DataTextField = "LoginName";
   drplAdmin.DataValueField = "ID";
   drplAdmin.DataBind();

   drplAdmin.Items.Insert(0, new ListItem("--- 全 部 ---",""));
    }

    private void BindList()
    {
        SqlParameter[] parms = { new SqlParameter("@tbname", SqlDbType.VarChar, 100), new SqlParameter("@AdminID", SqlDbType.Int) };
        parms[0].Value = drplTbName.SelectedValue;
        parms[1].Value =Format.DataConvertToInt(drplAdmin.SelectedValue);

        DataSet ds = DbHelperSQL.RunProcReturnDS("sp_TotalAdminPostNews",parms);

        dataViewList.DataSource = ds.Tables[0];
        dataViewList.DataBind();


    }
    protected void drplTbName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList();


    }
    protected void drplAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList();
    }
}