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
public partial class DownMemberXLS :Page
{
    int PageIndex = 1;
    int PageSize = 1000;
    string sdate = DateTime.Now.ToShortDateString();
    string edate = DateTime.Now.AddDays(1).ToShortDateString();

    string chd = "";
    BLLphome_enewsmember bllM = new BLLphome_enewsmember();
    protected void Page_Load(object sender, EventArgs e)
    {
        Ext();
    }

   

    void Ext()
    {

        if (!string.IsNullOrEmpty(Request["PageIndex"]))
        {

            PageIndex = Format.DataConvertToInt(Request["PageIndex"]);
            PageIndex = PageIndex > 1 ? PageIndex : 1;
        }
        if (!string.IsNullOrEmpty(Request["PageSize"]))
        {

            PageSize = Format.DataConvertToInt(Request["PageSize"]);
            PageSize = PageSize > 0 ? PageSize : 1000;
        }


        if (!String.IsNullOrEmpty(Request["sDate"]))
        {

            sdate = Request["sdate"];
        } if (!String.IsNullOrEmpty(Request["eDate"]))
        {

            edate = Request["edate"];
        }

        if (!String.IsNullOrEmpty(Request["chd"]))
        {

            chd = Request["chd"];
        }

        string fileds = Request["fields"];
        fileds = Util.FilterStartAndEndSign(fileds, ",");

        string where = "1=1";

        if (!String.IsNullOrEmpty(Request["where"]))
        {

            where = where + "  and " + Request["where"];
    

        }
  
        string sql = string.Format(" select  l.userid,{0} from phome_enewsmember l inner join  phome_enewsmemberadd m on l.userid=m.userid  inner join   phome_enewsmembergroup  g  on l.groupid=g.groupid  where {1}", fileds, where.ToString());


        IPager pager = new IPager();

        pager.TableName = sql;
        pager.PageIndex = PageIndex;
        pager.PageSize = PageSize;
        pager.PrimaryKeyField = "l.userid";
        pager.OrderBy = " userid  ";

        DataSet ds = pager.GetResult();


        if (ds.Tables[0].Rows.Count < 1)
        {
           Response.Write( "没有数据!");
        }
        else
        {
            ToExcel(ds);
        }


    }




    public void ToExcel(DataSet ds)
    {


        string typeid = "1";
        HttpResponse resp;
        resp = Page.Response;
        resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        string fileName = string.Format("[{0}]-会员数据-{1}.xls",DateTime.Parse(sdate).ToString("yyyy-MM-dd")+"-"+DateTime.Parse(edate).ToString("yyyy-MM-dd"), PageIndex);
        Response.AppendHeader("Content-Disposition", "attachment;filename="+fileName);
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

    protected void pager_PageChanged(object sender, EventArgs e)
    {
        Ext();
    }
}