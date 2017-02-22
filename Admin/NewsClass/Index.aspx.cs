using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.BLL.News;
using LL.Common;

using Project.Common;
using LL.Model.News;
public partial class Index : AdminPage
{

     BLLphome_enewsclass bllClass = new BLLphome_enewsclass();
    List<phome_enewsclass> AllClass = new List<phome_enewsclass>();
    protected void Page_Load(object sender, EventArgs e)
    {

        FillTree();
    }


   private  List<phome_enewsclass> GetArrClass()
    {

        List<phome_enewsclass> arrClass = bllClass.GetModelAllByCache().OrderBy(m => m.classid).ToList();
        
       
       int  bclassid = Format.DataConvertToInt(base.GetReqBClassID);
     


        if (bclassid>0)
        {
         
                GetAllClassIDFromBClassID(bclassid);
                phome_enewsclass fclass = bllClass.GetModelByCache(bclassid);
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
    void FillTree()
    {
        string target = "ClassEdit";
       string editUrl = "ClassEdit.aspx?ID=";
     //得到新闻分类


        List<phome_enewsclass> arrClass = GetArrClass();

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("<script>  d = new dTree('d'); ");
        string rootEditUrl = string.Format("{0}{1}", editUrl, 0);
        sb.AppendFormat("  d.add(0,-1,'新闻管理','{0}','{0}','{1}','','',true) ;", rootEditUrl, target);

        foreach (phome_enewsclass  item in  arrClass)
        {
         
                string id = item.classid.ToString();
                string className = item.classname;
                string pid = item.bclassid.ToString();



                string toUrl = string.Format("{0}{1}",editUrl, id);
                sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,false); ", id, pid, className, toUrl, className,target);
        }
        sb.AppendFormat("d.config.useIcons='/scripts/dtree/img/';");
        sb.AppendFormat("document.write(d);     </script>");
        lblDTree.Text= sb.ToString();
    }
}

