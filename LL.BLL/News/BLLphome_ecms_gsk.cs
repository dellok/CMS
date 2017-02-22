using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;
using LL.Model.News;
using LL.DALFactory;
using LL.IDAL.News;
using System.Text;
namespace LL.BLL.News
{
	public partial class BLLphome_ecms_gsk
	{
		private readonly Iphome_ecms_gsk dal=DataAccess.Createphome_ecms_gsk();
		  /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public int Add(phome_ecms_gsk  model)
       {
           return dal.Add(model);
       }
       /// <summary>
       /// 得到对像
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public phome_ecms_gsk  GetModel(int id,int userid)
       {
         return   dal.GetModel(id,userid);
       
       }
       public phome_ecms_gsk GetModel(int id)
       {
           return dal.GetModel(id);

       }
       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public int Update(phome_ecms_gsk  model)
       {

           return dal.Update(model);
       
       }

       public int BatchChecked(List<int> arrIDS, bool check)
       {
           return dal.BatchChecked(arrIDS, check);
       }
       public int BatchDel(List<int> arrIDS)
       {
           return dal.BatchDel(arrIDS);
       }

       public int BatchRecomend(List<int> arrIDS, bool  isRecomend)
       {
           return dal.BatchRecomend(arrIDS, isRecomend);
       }
       public int BatchFirstTitle(List<int> arrIDS, bool  isFirstTitle)
       {
           return dal.BatchFirstTitle(arrIDS, isFirstTitle);
       }
       public int BatchTop(List<int> arrIDS, int topNum)
       {
           return dal.BatchIsTop(arrIDS, topNum);
       }
       public int BatchFiling(List<int> arrIDS)
       {
           return dal.BatchFiling(arrIDS);
       }
    

       /// <summary>
       /// 查询新闻
       /// </summary>
       /// <param name="PageIndex"></param>
       /// <param name="PageSize"></param>
       /// <param name="strKeyWord"></param>
       /// <param name="strSDate"></param>
       /// <param name="strEDate"></param>
       /// <param name="strSearchType"></param>
       /// <param name="strChecked"></param>
       /// <returns></returns>

       public DataSet GetList(int PageIndex, int PageSize,string bclassid, string  arrclassid, string strKeyWord, string strSDate, string strEDate, string strSearchType, string strChecked)
       {

           StringBuilder where = new StringBuilder();


           if (!string.IsNullOrEmpty(arrclassid) && arrclassid!="0")
           {
               where.AppendFormat(" and  classid in ({0})", arrclassid);
           }
           else if (!string.IsNullOrEmpty(bclassid))
           {
               where.AppendFormat(" and  classid in ( select classid from phome_enewsclass where bclassid={0})", bclassid);
           }

           ///新闻发布时间
           if (!string.IsNullOrEmpty(strSDate))
           {
               where.AppendFormat(" and   newstime>='{0}'", strSDate);
           }
           if (!string.IsNullOrEmpty(strEDate))
           {
               where.AppendFormat(" and   newstime<='{0}'", strEDate);
           }
           //审核状态
           if (!string.IsNullOrEmpty(strChecked) && strChecked != "-1")
           {
               where.AppendFormat(" and   checked={0}", strChecked);
           }
           //判断关键字
           if (!string.IsNullOrEmpty(strKeyWord))
           {
               if (!string.IsNullOrEmpty(strSearchType))
               {
                   where.AppendFormat(" and {0} like '%{1}%'  ", strSearchType, strKeyWord);
               }
               else
               {
                   where.AppendFormat(" and  (title like '%{0}%'  or newstext like '%{0}%' )", strKeyWord);
               }
           }

           return GetList(PageIndex, PageSize, where.ToString());
       }
       public DataSet GetList(int PageIndex, int PageSize, string strKeyWord, string strSDate, string strEDate, string strSearchType, string strChecked)
       {
           return GetList(PageIndex, PageSize, "","", strKeyWord, strSDate, strEDate, strSearchType, strChecked);

       }

       public DataSet GetList(int PageIndex, int PageSize,string where)
       {
           return dal.GetList(PageIndex, PageSize, where.ToString(),"");
       }
     
       /// <summary>
       /// id
       /// </summary>
       /// <param name="ID"></param>
       /// <returns></returns>
       public int Delete(int ID)
       {
           return dal.Delete(ID);
       }



       public DataSet GetList(int PageIndex, int PageSize, string where, string orderby)
       {

           return dal.GetList(PageIndex, PageSize, where, orderby);
       }

       public  int SignHaveHtml(int ID, int havehtml)
       {

           return dal.SignHaveHtml(ID, havehtml);
       }

      
    }
}



