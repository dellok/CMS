using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using Project.Common;
using LL.BLL.News;

using LL.Model.News;
public partial class News_NewsClassTree : AdminPage
{
    BLLphome_enewsclass bllClass = new BLLphome_enewsclass();
    List<phome_enewsclass> AllClass = new List<phome_enewsclass>();
    protected void Page_Load(object sender, EventArgs e)
    {

        FillTree();
    }


   private  List<phome_enewsclass> GetArrClass()
    {
          List<phome_enewsclass> arrClass = bllClass.GetModelAllByCache();

          arrClass.OrderBy(m => m.classid).ToList();
      
       
       int  bclassid = Format.DataConvertToInt(base.GetReqBClassID);
     


        if (bclassid>0)
        {
         
                GetAllClassIDFromBClassID(bclassid);
                phome_enewsclass fclass = bllClass.GetModelByCache(bclassid);
                if (fclass!=null)
                {
                    
                AllClass.Add(fclass);
                arrClass = AllClass;
                }
            // fclass.bclassid = 0;
         
         
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
        string target = "newslist";
        string toUrl = "NewsList.aspx";
     //得到新闻分类


        List<phome_enewsclass> arrClass = GetArrClass();

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("<script>  d = new dTree('d'); ");



  

        string rootUrl = string.Format("NewsList.aspx?{0}={1}", PubConstant.Key_ClassID, 0);

        sb.AppendFormat("  d.add(0,-1,'新闻管理','{0}','{0}','{1}','','',true) ;",rootUrl,target);


        
        foreach (phome_enewsclass  item in  arrClass)
        {
            //if (item.islist>0)
            //{
                string id = item.classid.ToString();
                string className = item.classname;
                string pid = item.bclassid.ToString();

                string tbname = item.tbname;

                tbname = string.IsNullOrEmpty(tbname) ? "news" : tbname;

                if (bllClass.GetSonClassByIDFromCache(Format.DataConvertToInt(id)).Count() > 0)
                {
                    toUrl = string.Format("{0}List.aspx?{1}={2}", tbname, PubConstant.Key_BClassID, id);

                }
                else
                {
                    toUrl = string.Format("{0}List.aspx?{1}={2}", tbname, PubConstant.Key_ClassID, id);

                }
              
    
                sb.AppendFormat("  d.add({0},{1},'{2}','{3}','{4}','{5}','','' ,false); ", id, pid, className, toUrl, toUrl,target);


           // }
        }
        if (arrClass.Count<5)
        {

            sb.AppendFormat("d.openAll();");
        }
        sb.AppendFormat("d.config.useIcons='/scripts/dtree/img/';");
        sb.AppendFormat("document.write(d);    var   toUrl='" + toUrl + "';   </script>");
        lblDTree.Text= sb.ToString();
    }
}