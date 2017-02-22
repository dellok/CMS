using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LL.BLL.Member;
using Project.Common;

public partial class Member_Space_Index : AdminPage
{
    BLLphome_enewsmemberfeedback bll = new BLLphome_enewsmemberfeedback();

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {

           
            BindList();

        }
    }

    private void BindReq()
    {

        if (Request["userid"] != null)
        {

            txtSearchKeyword.Text = Request["userid"].ToString();
            drplWhereField.SelectedIndex = drplWhereField.Items.IndexOf(drplWhereField.Items.FindByValue("userid"));

        }

    }


    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        DeleteAll();
    }
    protected void pager_PageChanged(object sender, EventArgs e)
    {

        BindList();
    }

    private void BindList()
    {
        BindReq();
        int PageIndex = pager.CurrentPageIndex;
        int PageSize = pager.PageSize;

        string where = txtSearchKeyword.Text.Trim();

        if (!string.IsNullOrEmpty(where))
        {
            where = string.Format(" f.{0}='{1}'", drplWhereField.SelectedValue, where);

        }

        DataSet ds = bll.GetList(PageIndex, PageSize, where, "");

        if (ds.Tables.Count == 2)
        {
            pager.RecordCount = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);

            listData.DataSource = ds.Tables[0];
            listData.DataBind();
        }
    }

   

 
    void DeleteAll()
    {
        //得到选择项
        string cboxID = "cboxID";
        List<int> arrSelectID = new List<int>();
        foreach (var item in listData.Items)
        {

            CheckBox tempBox = item.FindControl(cboxID) as CheckBox;

            if (tempBox.Checked)
            {
                int msgid = Format.DataConvertToInt(tempBox.ToolTip);
                if (msgid > 0)
                {
                    arrSelectID.Add(msgid);
                }
            }
        }
        if (arrSelectID.Count > 0)
        {
            int intR = bll.DeleteAll(arrSelectID);

            if (intR > 0)
            {

                BindList();
            }
            else
            {
                JsAlert.ShowAlert("删除的过程中出现了错误!");
            }
        }
        
    }


   

    protected void listData_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

        int id = Format.DataConvertToInt(listData.DataKeys[listData.SelectedIndex]);
        int intR = bll.Delete(id);
        if (intR > 0)
        {

            BindList();
        }
        else
        {
            JsAlert.ShowAlert("删除的过程中出现了错误!");
        }
     
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }
}