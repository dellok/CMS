using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LL.BLL.Member;
using Project.Common;
using System.Text;
using DBUtility;
using LL.DAL;
public partial class Member_ExtMember : AdminPage
{
    int PageIndex = 1;
    int PageSize = 1000;

    BLLphome_enewsmember bllM = new BLLphome_enewsmember();
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnExtExcel_Click(object sender, EventArgs e)
    {
        Ext();
    }

    void Ext()
    {

      

        //if (!string.IsNullOrEmpty(txtPageSize.Text))
        //{
        //    PageSize = Format.DataConvertToInt( txtPageSize.Text.Trim());
        //}
      
       
        string fileds = string.Empty;
        //得到字段

        foreach (ListItem item in cboxMemberField.Items)
        {

            if (item.Selected)
            {
                fileds += string.Format(" {0} as {1},", item.Value, item.Text);
            }

        }

        fileds = Util.FilterStartAndEndSign(fileds, ",");
        //查询日期
        string d = rdDate.SelectedValue;
        //是否审核 
        string chd = radMemberCheck.SelectedValue;

        //string sdate = txtSDate.Text.Trim();
        //string edate = txtEDate.Text.Trim();

        DateTime sdate=DateTime.Now;
        DateTime edate=DateTime.Now.AddDays(1);

        StringBuilder where = new StringBuilder(" 1=1 ");

        GetDate(d,ref sdate,ref edate);

        where.AppendFormat("  and      l.registertime  between   '{0}'   and '{1}'  ",sdate.ToShortDateString(),edate.ToShortDateString());

        switch (chd.Trim())
        {
            case "1":
                where.AppendFormat(" and  l.[checked]=1");
                break;

            case "0":
                where.AppendFormat(" and l.[checked]<>1");
                break;

        }

        string sql = string.Format(" select   l.userid,{0} from phome_enewsmember l inner join  phome_enewsmemberadd m on l.userid=m.userid  left join   phome_enewsmembergroup  g  on l.groupid=g.groupid  where {1} order by l.userid ", fileds, where.ToString());


        DataSet ds = DbHelperSQL.Query(sql);


       

       ToExcel(ds, sdate, edate);
 /*
        //IPager pager = new IPager();
        
        //pager.TableName = sql;
        //pager.PageIndex = PageIndex;
        //pager.PageSize = PageSize;
        //pager.PrimaryKeyField = "l.userid";
        //pager.OrderBy = " userid  ";
         DataSet ds= pager.GetResult();

       int Rows=Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);

      // int PageCount = Rows / PageSize + 1;




       StringBuilder extBtns = new StringBuilder();

      // extBtns.AppendFormat("<script> var  fields='{0}'; var chd='{1}';var sdate='{2}'; var edate='{3}';  var where=\"{4}\"; var pagesize={5}; </script>", fileds, chd, sdate.ToShortDateString(), edate.ToShortDateString(), where, PageSize);
 
       for (int i = 1; i < PageCount+1; i++)
       {

           string parms=string.Format("{0}",i);
           string  title=string.Format("下载第【{0}】页会员数据",i);

           extBtns.AppendFormat("<input  type='button' onclick=\"javascript:extMember({0})\" value=\"{1}\" class=\"btn_2k3\" style='margin:5px;width:200px;'/>", parms, title);

       
       }


       //lblBtns.Text = extBtns.ToString();

 
          */


    }
      

    private void GetDate( string d,ref DateTime sdate,ref DateTime edate)
    {

        DateTime now = DateTime.Now;

        DateTime preD = now.AddMonths(-1);
        int ds = preD.Day-1;
        DateTime firstday_preMon = preD.AddDays(-ds);


        //本月的第一天
        int cds = now.Day-1;
        DateTime firstday_cMon = now.AddDays(-cds);


        switch (d)
        {
            case "1":

                sdate = firstday_preMon;
                edate = firstday_cMon;


                break;
            case "2":
                sdate = now.AddDays(-3);
                edate = now;
           
                break;

            case "3":

              sdate = now.AddDays(-1);
                edate = now;       
                break;

            case "4":
                sdate = now;
                edate = now.AddDays(1);    
                break;

            case "5":
                int wds = (int)now.DayOfWeek-1;
                sdate = now.AddDays(-wds);

                break;
            case "6":

                sdate = firstday_cMon;
                edate = now.AddDays(1); 
                break;
        }

    }



    public void ToExcel(DataSet ds,DateTime sdate,DateTime edate)
    {


        string typeid = "1";
        HttpResponse resp;
        resp = Page.Response;
        resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        string fileName = string.Format("[{0}]-注册会员数据.xls", sdate.ToString("yyyy-MM-dd") + "-" + edate.ToString("yyyy-MM-dd"));
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
        string colHeaders = "";
        DataTable dt = ds.Tables[0];
        DataRow[] myRow = dt.Select("");
        int i = 0;
        if (typeid == "1")
        {

            int colCount = ds.Tables[0].Columns.Count;
            for (i = 0; i < colCount; i++)
            {
                colHeaders += dt.Columns[i].Caption.ToString() + "\t";
            }
            resp.Write(colHeaders);
            resp.Write("\n");

            int rows = myRow.Count();
            foreach (DataRow row in myRow)
            {
                for (i = 0; i < colCount; i++)
                {
                    resp.Write(row[i].ToString() + "\t");
                }
                resp.Write("\n");
            }
        }
        else
        {
            if (typeid == "2")
            {
                resp.Write(ds.GetXml());
            }
        }


        resp.End();
    }

  
}