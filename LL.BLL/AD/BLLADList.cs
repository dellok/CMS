using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.News;
using System.Data;
using LL.IDAL.AD;
using LL.Common;
using LL.Common.Cache;
using LL.Model.AD;
using LL.Model.Temp;
namespace LL.BLL.AD
{
   public  class BLLADList
    {
       private IADList  dal = LL.DALFactory.DataAccess.CreateADList ();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public int Add(ADList  model)
       {
           int i= dal.Add(model);
           RemoveCache();
           return i;
       }

       /// <summary>
       /// 得到对像
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public ADList GetModel(int id)
       {
           return dal.GetModel(id);
       }

       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public int Update(ADList  model)
       {  
        int i= dal.Update(model);
        RemoveCache();
        return i;
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
       public DataSet GetList(int PageIndex, int PageSize, string strKeyWord, string strSDate, string strEDate, string strSearchType, string strIsRecycle ,string strChecked)
       {

           StringBuilder where = new StringBuilder("    1=1 ");

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
           if (!string.IsNullOrEmpty(strChecked) && strChecked!="-1")
           {
               where.AppendFormat(" and   checked={0}", strChecked);
           }
           //审核状态
           if (!string.IsNullOrEmpty(strIsRecycle) && strIsRecycle != "-1")
           {
               where.AppendFormat(" and   isrecycle={0}", strIsRecycle);
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

           return dal.GetList(PageIndex, PageSize, where.ToString());

       }
       /// <summary>
       /// id
       /// </summary>
       /// <param name="ID"></param>
       /// <returns></returns>
       public int Delete(int ID,string  fileName)
       {
          
           int i= dal.Delete(ID, fileName);
           RemoveCache();
           return i;
       }


       public int BatchChecked(List<int> arrIDS, int IsChecked)
       {
           int i = dal.BatchChecked(arrIDS, IsChecked);
           RemoveCache();
           return i;
       }

       public int BatchDel(List<int> arrIDS)
       {

           int i = dal.BatchDel(arrIDS, (int)LL.Common.EnumClass.FileInfoType.AD);
           RemoveCache();
           return i;
       }

       /// <summary>
       /// 得到列表
       /// </summary>
       /// <param name="PageIndex"></param>
       /// <param name="PageSize"></param>
       /// <param name="strKeyWord"></param>
       /// <param name="strPage"></param>
       /// <param name="strPagePosition"></param>
       /// <param name="strSDate"></param>
       /// <param name="strEDate"></param>
       /// <param name="strZSDate"></param>
       /// <param name="strZEDate"></param>
       /// <param name="strFileType"></param>
       /// <param name="strChecked"></param>
       /// <returns></returns>
       public DataSet GetList(int PageIndex, int PageSize, string strKeyWord, string strPage, string strPagePosition, string strSDate, string strEDate, string strZSDate, string strZEDate, string strFileType, string isRecycle, string strChecked)
       {
           return GetList(PageIndex, PageSize, strKeyWord, strPage, strPagePosition, -1, strSDate, strEDate, strZSDate, strZEDate, strFileType, isRecycle, strChecked);
       }

       public int BatchDel(List<int> arrIDS, int fileInfoType)
       {
           int i = dal.BatchDel(arrIDS, fileInfoType);
           RemoveCache();
           return i;
       }

       /// <summary>
       /// 批量移致动到回收
       /// </summary>
       /// <param name="arrIDS"></param>
       /// <param name="p"></param>
       /// <returns></returns>
       public int BatchMoveToRecycle(List<int> arrIDS, int IsRecycle)
       {
          
           int i = dal.BatchMoveToRecycle(arrIDS, IsRecycle);
           RemoveCache();
           return i;
       }
       /// <summary>
       ///bc xxsd
       /// </summary>
       /// <param name="ADPage"></param>
       /// <param name="ADPagePosition"></param>
       /// <param name="p"></param>
       /// <returns></returns>
       public List<ADList> GetADList(string ADPage, string ADPagePosition, bool IsCheck ,bool IsExpired)
       {
           return dal.GetADList( ADPage,  ADPagePosition,  IsCheck , IsExpired);
       }

       /// <summary>
       /// 是否开启
       /// true 为开启的广告，false 取出所有广告
       /// </summary>
       /// <param name="isCheck"></param>
       /// <returns></returns>
       public List<ADList> GetAllADList(bool isCheck)
       {
           return dal.GetAllADList(isCheck);
       }
        #region  cache

       #region   与缓存有关的
       public List<ADList> GetModelAllByCache()
       {


           if (CacheManager.GetCache(Key_Cache) != null)
           {
               List<ADList> list = (List<ADList>)CacheManager.GetCache(Key_Cache);

               return list;
           }
           else
           {
               List<ADList> list = dal.GetModelAll();
               CacheManager.SaveCache(Key_Cache, list);
               return list;
           }
       }



       public string Key_Cache { get { return this.GetType().Name; } }
       void RemoveCache()
       {
           CacheManager.Remove(Key_Cache);

       }

       #endregion   
 
       /// <summary>
       ///取出页面位置广告,是否包含过期的但未下架的广告
       /// </summary>
       /// <param name="ADPage"></param>
       /// <param name="ADPagePosition"></param>>IsExpired
       /// <returns></returns>
       public List<ADList> GetADListByCache(string ADPage, string ADPagePosition,  bool IsExpired)
       {

           List<ADList> arrAD = new List<ADList>();

           arrAD = GetModelAllByCache();


           DateTime now = DateTime.Now;

           if (!IsExpired)
           {
               arrAD = (from m in arrAD
                        where m.Page == ADPage && m.Position == ADPagePosition &&  m.EndDate > now  && m.IsRecycle!=true
                        orderby m.Seq ascending ,m.ID descending
                        select m).ToList();

           }
           else
           {
               arrAD = (from m in arrAD
                        where m.Page == ADPage && m.Position == ADPagePosition && m.IsRecycle != true
                        orderby m.Seq ascending, m.ID descending
                        select m).ToList();
           }

           return arrAD;


       
       }


       public ADList GetADListByCache(string ADPage, string ADPagePosition,int seq, bool IsExpired)
       {

           List<ADList> arrAD = new List<ADList>();
           arrAD = GetModelAllByCache();
           return arrAD.Where(m=>m.Page==ADPage && m.Position==ADPagePosition && m.Seq==seq).FirstOrDefault();
         

       }
    
        #endregion

       /// <summary>
       /// 广告计数
       /// </summary>
       /// <param name="intID"></param>
       /// <param name="hitNum"></param>
       /// <returns></returns>
       public int  ADHit(int intID, int hitNum)
       {
                     
       int i=  dal.ADHit(intID,hitNum);
        RemoveCache();
       return i;
           
       }



       public int ADPV(int intID, int pvNum)
       {

           int i = dal.ADPV(intID, pvNum);
           RemoveCache();
           return i;
          
           
       }

       public DataSet GetList(int PageIndex, int PageSize, string strKeyWord, string strPage, string strPagePosition, int seq, string strSDate, string strEDate, string strZSDate, string strZEDate, string strFileType, string isRecycle, string strChecked)
       {

           StringBuilder where = new StringBuilder("    1=1 ");

           //广告所在页面

           if (!string.IsNullOrEmpty(strPage) && strPage != "0")
           {
               where.AppendFormat(" and  Page = '{0}' ", strPage);
           }
           //广告所在页面位置
           if (!string.IsNullOrEmpty(strPagePosition) && strPagePosition != "0")
           {
               where.AppendFormat(" and  Position = '{0}' ", strPagePosition);
           }

           if (seq>0)
           {

               where.AppendFormat(" and seq={0}",seq);
           }
           ///广告开始时间
           if (!string.IsNullOrEmpty(strSDate))
           {
               where.AppendFormat(" and   StartDate>='{0}'", strSDate);
           }
           if (!string.IsNullOrEmpty(strEDate))
           {
               where.AppendFormat(" and   StartDate<='{0}'", strEDate);
           }
           //广告结束时间
           if (!string.IsNullOrEmpty(strZSDate))
           {
               where.AppendFormat(" and   EndDate>='{0}'", strSDate);
           }
           if (!string.IsNullOrEmpty(strZEDate))
           {
               where.AppendFormat(" and   EndDate<='{0}'", strEDate);
           }
           //审核状态
           if (!string.IsNullOrEmpty(strChecked) && strChecked != "-1")
           {
               where.AppendFormat(" and   checked={0}", strChecked);
           }
           //审核状态
           if (!string.IsNullOrEmpty(isRecycle) && isRecycle != "-1")
           {
               where.AppendFormat(" and   isRecycle={0}", isRecycle);
           }


           //判断关键字
           if (!string.IsNullOrEmpty(strKeyWord))
           {

               where.AppendFormat(" and  title like '%{0}%' ", strKeyWord);

           }

           //文件类型:flash img
           if (!string.IsNullOrEmpty(strFileType) && strFileType != "0")
           {
               where.AppendFormat(" and  fileclass={0}", strFileType);
           }

           return dal.GetList(PageIndex, PageSize, where.ToString());
       }

       /// <summary>
       /// 得到web.cofig 中的 广告页项
       /// </summary>
       /// <returns></returns>
       public static List<string> GetADPage()
       {

           
           string pageList = LL.Common.Cache.ConfigManager.GetConfigSettingsValue("ADPage");


           string[] aPages = pageList.Split(new char[] { PubConstant.Key_Sign_CommaSign });

           List<string> arrPage = new List<string>();

           foreach (string item in aPages)
           {

               arrPage.Add(item);
           }


           return arrPage;
       }

       /// <summary>
       /// 得到web.cofig 中的 页面中广告位置项
       /// </summary>
       /// <returns></returns>
       public static List<string> PagePosition()
       {
           List<string> adposition = new List<string>();


           string pageList = LL.Common.Cache.ConfigManager.GetConfigSettingsValue("ADPagePosition");


           string[] aPagesPosition = pageList.Split(new char[] { PubConstant.Key_Sign_CommaSign });

           List<string> arrPage = new List<string>();

           foreach (string item in aPagesPosition)
           {

               adposition.Add(item);
           }
           return adposition;
       }
    }
}
