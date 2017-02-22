using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.DALFactory;
using LL.IDAL.Log;

using System.Web;
using Project.Common;
using LL.Model.Log;
namespace LL.BLL.Log
{
    public class BLLVisitorLog
    {

        IVisitorLog dal = DataAccess.CreateDALVisitorLog();




        public int Add(int infoid, string title, int classid, string infotype,int pv ,int hit)
        {
            HttpRequest req = HttpContext.Current.Request;


            VisitorLog model = new VisitorLog();

            model.InfoID = infoid;
            model.InfoTitle = title;
            model.InfoType = infotype;
            model.InfoClassID = classid;

            model.PV = pv;
            model.Hit = hit;
            model.IP = req.UserHostAddress;
            model.Visitor = req.ServerVariables.Get("Remote_Host").ToString();


            if (req.UrlReferrer != null)
            {
                model.ReUrl = req.UrlReferrer.ToString();
            }
         

           


            model.InDate = DateTime.Now;
            return Add(model);
        }

       
        public int Add(VisitorLog model)
        {
            return dal.Add(model);
        }



        public System.Data.DataSet TotalVisitorLog(int PageIndex, int PageSize, string type, string infoid, string infotitle, string sdate, string edate,string orderby)
        {

            StringBuilder where = new StringBuilder(" 1=1");

            if (!string.IsNullOrEmpty(type))
            {

                where.AppendFormat(" and  InfoType='{0}'   ", type);
            }
            if (!string.IsNullOrEmpty(infoid))
            {

                where.AppendFormat(" and infoid={0}   ", Format.DataConvertToInt(infoid));
            }
            if (!string.IsNullOrEmpty(infotitle))
            {

                where.AppendFormat(" and infotitle like '%{0}%'   ", type);
            }
            if (!string.IsNullOrEmpty(sdate))
            {

                where.AppendFormat(" and indate >='{0}'   ", sdate);
            }
            if (!string.IsNullOrEmpty(edate))
            {

                where.AppendFormat("  and indate <='{0}'   ", edate);
            }



            return dal.TotalVisitorLog(PageIndex, PageSize,type, where.ToString(),orderby);

        }

    }
}
