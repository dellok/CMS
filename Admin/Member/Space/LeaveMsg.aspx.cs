using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Project.Common;
using System.Text;
using LL.Common;
using LL.Model.Member;
using LL.BLL.Member;

public partial class Member_MemberLeaveMsg : AdminPage
{

    BLLphome_enewsmembergbook bllLeaveMsg = new BLLphome_enewsmembergbook();

 
    public string sessinLoginUserName = "";
    public string uname = "";
    protected void Page_Load(object sender, EventArgs e)
    {

     
        if (!Page.IsPostBack)
        {

          
            BindList();

        }
    }

    private void BindReq()
    {
        if (Request["userid"]!=null)
        {
            txtSearchKeyword.Text = Request["userid"].ToString();
            drplWhereField.SelectedIndex = drplWhereField.Items.IndexOf(drplWhereField.Items.FindByValue("userid"));
        }
    }
    private void BindList()
    {
        BindReq();

        int PageIndex = pager.CurrentPageIndex;
        int PageSize = pager.PageSize;
        string where = txtSearchKeyword.Text.Trim();

        if (!string.IsNullOrEmpty(where))
        {
            where = string.Format(" b.{0}='{1}'",drplWhereField.SelectedValue,where);
        }

        DataSet ds = bllLeaveMsg.GetList(PageIndex, PageSize, where);
        if (ds.Tables.Count == 2)
        {
            repList.DataSource = ds.Tables[0];
            repList.DataBind();
            pager.RecordCount = Format.DataConvertToInt(ds.Tables[1].Rows[0]);
        }


    }
    protected void pager_PageChanged(object sender, EventArgs e)
    {
        BindList();
    }




    public string BindReplyLeavaMsg(object retext)
    {

        StringBuilder html = new StringBuilder();


        if (!string.IsNullOrEmpty(retext.ToString()))
        {
            html.AppendFormat("<table border=0 width='100%' cellspacing=1 cellpadding=2 >");
            html.AppendFormat("  <tr> ");
            html.AppendFormat("  <td width='100%' bgcolor='#FFFFFF' style='word-break:break-all'> ");
            html.AppendFormat("<img src=\"/images/regb.gif\" width=\"18\" height=\"18\"><strong><font color=\"#FF0000\">回复:</font></strong> {0}", retext);
            html.AppendFormat("  </td>");
            html.AppendFormat("  </tr>");
            html.AppendFormat(" </table>");
        }

        return html.ToString();
    }


    protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {




    }
    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        List<int> arrids = GetIDS();
        if (arrids.Count > 0)
        {

            int intR = bllLeaveMsg.DeleteList(arrids);

            if (intR > 0)
            {



                JsAlert.ShowAlert(PubMsg.Msg_Delete_Success);
            }
            else
            {

                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }
        }
    }
    protected void btnChecked_Click(object sender, EventArgs e)
    {
      
        Button btn = (Button)sender;

        int chd = Format.DataConvertToInt(btn.CommandArgument);
        List<int> arrids = GetIDS();
        if (arrids.Count > 0)
        {

            int intR = bllLeaveMsg.CheckedList(arrids, chd, 0);

            if (intR > 0)
            {



                JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);
            }
            else
            {

                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }
        }
    }

    public List<int> GetIDS()
    {

        //得到选择项
        string cboxID = "cboxID";
        List<int> arrSelectID = new List<int>();
        foreach (ListViewItem item in repList.Items)
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

        return arrSelectID;



    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }



    protected void repList_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {

        Response.Write(e.CommandArgument.ToString() + "--");

        if (e.CommandName == "Delete")
        {
            int id = Format.DataConvertToInt(e.CommandArgument);

            if (bllLeaveMsg.Delete(id) > 0)
            {

                JsAlert.ShowAlert(PubMsg.Msg_Delete_Success);
            }
            else
            {

                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }


        }

        BindList();
    }
    protected void repList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {


        int id =Format.DataConvertToInt(repList.DataKeys[e.ItemIndex].Value);

        if (bllLeaveMsg.Delete(id) > 0)
        {

            JsAlert.ShowAlert(PubMsg.Msg_Delete_Success);

        }
        else
        {

            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }
        BindList();

    }
}