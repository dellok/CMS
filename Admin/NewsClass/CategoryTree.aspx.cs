using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using LL.BLL.Admin;
using LL.BLL.Popedom;
using Project.Common;
using LL.BLL.News;

using System.Data;
using LL.Model.News;
public partial class CategoryTree : AdminPage
{
    BLLphome_enewsclass bllClass = new BLLphome_enewsclass();
    List<phome_enewsclass> AllClass = new List<phome_enewsclass>();
    const  string    Sp_NewsCountByClass="sp_NewsCountByClass";
    protected void Page_Load(object sender, EventArgs e)
    {

        FillTree(GetArrClass());
    }


   private  List<phome_enewsclass> GetArrClass()
    {

        List<phome_enewsclass> arrClass = bllClass.GetModelAllByCache().OrderBy(m => m.classid).ToList();
        
       
       int  bclassid = Format.DataConvertToInt(base.GetReqBClassID);
     


        if (bclassid>0)
        {
         
                GetAllClassIDFromBClassID(bclassid);
                phome_enewsclass fclass = bllClass.GetModelFromCache(bclassid);
                fclass.bclassid = 0;
                AllClass.Add(fclass);
                arrClass = AllClass;
         
        }
        return arrClass;
    }


   public void GetAllClassIDFromBClassID(int bClassID)
   {
       List<phome_enewsclass> tempClass = bllClass.GetSonClassByIDFromCache(bClassID);

      
       if (tempClass.Count > 0)
       {
           foreach (phome_enewsclass item in tempClass)
           {
               AllClass.Add(item);
               GetAllClassIDFromBClassID(Format.DataConvertToInt(item.classid));
           }
       }
   }
    /// <summary>
    /// 得到分类下的新闻数量
    /// </summary>
    /// <returns></returns>
   public DataSet GetNewsCountByClass() {




     return   DBUtility.DbHelperSQL.RunProcedure(Sp_NewsCountByClass);
   
   
   
   }
    void FillTree(List<phome_enewsclass> arrClass)
    {
        string target = "CategoryEdit";
        string toUrl = "CategoryEdit.aspx";
        //得到新闻分类
   
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("<script>  d = new dTree('d'); ");
        sb.AppendFormat("  d.add(0,-1,'新闻类别管理','{0}','{0}','{1}','','',true) ;",toUrl,target);

        DataSet ds = GetNewsCountByClass();

        foreach (phome_enewsclass  item in  arrClass)
        {
            //if (item.islist>0)
            //{
                string id = item.classid.ToString();
                string className = item.classname;
                string pid = item.bclassid.ToString();
                string url = string.Format("{0}?{1}={2}",toUrl ,PubConstant.Key_ClassID, id);
                string newsCount = "0";

                DataRow[]   rRows = ds.Tables[0].Select(" classid="+id);

                if (rRows.Count()>0)
                {
                    newsCount = rRows[0]["newsCount"].ToString();
                }

                if (bllClass.GetSonClassByIDFromCache(Format.DataConvertToInt(id)).Count() > 0)
                {
                    url = string.Format("{0}?{1}={2}", toUrl, PubConstant.Key_BClassID, id);
                }

                sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,false); ", id, pid, className + string.Format("<font color=green>({0})</font>", id) + string.Format("<font color=red>({0}</font>)", newsCount), url, url, target);
         

            // }
        }
        sb.AppendFormat("d.config.useIcons='/scripts/dtree/img/';");
        sb.AppendFormat("document.write(d);     </script>");
        lblDTree.Text= sb.ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchClass();

    }

    private void SearchClass()
    {
        List<phome_enewsclass> arrClass = bllClass.GetModelAllByCache().OrderBy(m => m.classid).ToList();

       
        string txt = txtClassName.Text;

        if (!string.IsNullOrEmpty(txt))
        {

            arrClass = arrClass.Where(m => m.classname.Contains(txt)).ToList();
           
        }

        FillTree(arrClass);

    }


}