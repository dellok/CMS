using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
public partial class Admin_TotalPostNews : AdminPage
{
    public string sDate = "";
    public string eDate = "";
    public string aName = "";
    public string totalNews = "0";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {


            txtAdminName.Text = base.CurrentLogin.LoginName;


        }



    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {


         sDate = txtSDate.Text.Trim();
         eDate = txtEDate.Text.Trim();
         aName = txtAdminName.Text.Trim();

        if (string.IsNullOrEmpty(sDate))
        {

            sDate = DateTime.Now.AddMonths(-1).ToShortDateString();
        }
       
        if (string.IsNullOrEmpty(eDate))
        {

            eDate = DateTime.Now.AddDays(1).ToShortDateString();
        }

       
        if (string.IsNullOrEmpty(aName))
        {

            aName = CurrentLogin.LoginName;
        }

        string sql = string.Format(" select count(*) from phome_ecms_news  where     newstime between '{0}' and '{1}'  and username='{2}'",sDate,eDate,aName);




        object obj = DBUtility.DbHelperSQL.GetSingle(sql);


        totalNews = obj.ToString();




    }
}