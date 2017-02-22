using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;
using LL.Model.News;
using LL.DALFactory;
using LL.IDAL.News;
using System.Text;
using LL.Model;
using LL.Common.Cache;
using Project.Common;
using System.Text.RegularExpressions;
using System.Collections;
namespace LL.BLL.News
{

    public partial class BLLphome_ecms_news:ServiceBase<phome_ecms_news>
    {
        private readonly Iphome_ecms_news dal = DataAccess.Createphome_ecms_news();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(phome_ecms_news model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 得到对像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public phome_ecms_news GetModel(int id, int userid)
        {
            return dal.GetModel(id, userid);
        }
        /// <summary>
        /// 得到对像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public phome_ecms_news GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public phome_ecms_news GetUsDetail(int classid)
        {
            phome_ecms_news model = new phome_ecms_news();

            string where = string.Format(" classid={0}", classid);

            DataSet ds = dal.GetList(1, 1, where, "");

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = dal.GetModelByDataRow(ds.Tables[0].Rows[0]);
                }

            }

            return model;

        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(phome_ecms_news model)
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
        public int BatchRecomend(List<int> arrIDS, bool isRecomend)
        {
            return dal.BatchRecomend(arrIDS, isRecomend);
        }

        public int BatchFirstTitle(List<int> arrIDS, bool isFirstTitle)
        {
            return dal.BatchFirstTitle(arrIDS, isFirstTitle);
        }


        public int BatchTop(List<int> arrIDS, int topNum,int userid)
        {
            return dal.BatchIsTop(arrIDS, topNum,userid);
        }
        public int BatchChecked(List<int> arrIDS, bool check, int userid)
        {
            return dal.BatchChecked(arrIDS, check, userid);
        }
        public int BatchDel(List<int> arrIDS, int userid)
        {
            return dal.BatchDel(arrIDS, userid);
        }
        public int BatchRecomend(List<int> arrIDS, bool isRecomend, int userid)
        {
            return dal.BatchRecomend(arrIDS, isRecomend, userid);
        }

        public int BatchFirstTitle(List<int> arrIDS, bool isFirstTitle, int userid)
        {
            return dal.BatchFirstTitle(arrIDS, isFirstTitle, userid);
        }




        public int BatchFiling(List<int> arrIDS)
        {

            return dal.BatchFiling(arrIDS);

        }

        public int UpdateNewsClass(List<int> arrIDS, int intClassID)
        {

            return dal.UpdateNewsClass(arrIDS, intClassID);
        }

        #region  查询
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
        public DataSet GetList(int PageIndex, int PageSize, string strKeyWord, string strSDate, string strEDate, string strSearchType, string strChecked, string isMebmer, int newClassID)
        {

            return GetList(PageIndex, PageSize, strKeyWord, strSDate, strEDate, strSearchType, strChecked, isMebmer, newClassID, "");

        }

        public DataSet GetList(int PageIndex, int PageSize, string strKeyWord, string strSDate, string strEDate, string strSearchType, string strChecked, string isMebmer, int newClassID, string bclassid)
        {

            StringBuilder where = new StringBuilder("    1=1 ");


            if (!string.IsNullOrEmpty(bclassid))
            {

                where.AppendFormat("     and  classid in(select classid from phome_enewsclass where bclassid ={0}  )    ", bclassid);

            }
            else
            {

                if (newClassID > 0)
                {
                    where.AppendFormat(" and  classid={0}", newClassID);
                }
            }
            ///新闻发布时间
            if (!string.IsNullOrEmpty(strSDate))
            {
                where.AppendFormat(" and  cast(newstime as datetime)>='{0}'", strSDate);
            }
            if (!string.IsNullOrEmpty(strEDate))
            {
                where.AppendFormat(" and   cast(newstime as datetime)<='{0}'", strEDate);
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


            if (!string.IsNullOrEmpty(isMebmer) && isMebmer != "-1")
            {


                where.AppendFormat(" and  ismember={0}", isMebmer);

            }

            return dal.GetList(PageIndex, PageSize, where.ToString(), " newstime desc");
        }

        public DataSet GetList(int PageIndex, int PageSize, string where, string orderby)
        {

            return dal.GetList(PageIndex, PageSize, where, orderby);

        }


        public DataSet GetList(int PageIndex, int PageSize, string where)
        {

            return dal.GetList(PageIndex, PageSize, where, " newstime desc");

        }

        public DataSet GetTitleList(int PageIndex, int PageSize, string where, string orderby)
        {

            return dal.GetTitleList(PageIndex, PageSize, where, orderby);
        }

        public DataSet GetTopTitleList(int topNum, string where, string orderby)
        {
            return dal.GetTopTitleList(topNum, where, orderby);
        }
        #endregion
        /// <summary>
        /// id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }

        public MvcPager GetDataList(string classid, int? page, string keyword, string orderby)
        {


            string ps = ConfigManager.GetConfigSettingsValue("pagesize");
            MvcPager pager = new MvcPager();
            int PageSize = string.IsNullOrEmpty(ps) ? 20 : Format.DataConvertToInt(ps);
            int PageIndex = Format.DataConvertToInt(page);

            PageIndex = PageIndex > 0 ? PageIndex : 1;
            PageSize = PageSize > 0 ? PageSize : 10;

            StringBuilder where = new StringBuilder();

            where.Append(" checked=1 ");
            //是否是父分类

            string strclassid = Format.DataConvertToString(classid);
            if (!string.IsNullOrEmpty(strclassid))
            {
                //判断是否是父分类
                bool isSonClass = Util.IsNumeric(strclassid);


                if (isSonClass)
                {
                    where.AppendFormat("and  classid={0}", strclassid);


                }
                else
                {
                    Regex reg = new Regex(@"[0-9]+");
                    MatchCollection mc = reg.Matches(strclassid);
                    strclassid = mc[0].Value;
                    if (Format.DataConvertToInt(strclassid) > 0)
                    {
                        where.AppendFormat("and  classid in(select classid from phome_enewsclass where bclassid={0})", strclassid);
                    }
                }


            }

            if (!string.IsNullOrEmpty(Format.DataConvertToString(keyword)))
            {
                where.AppendFormat(" and  title like '%{0}%'", keyword);
            }

            DataSet ds = GetTitleList(PageIndex, PageSize, where.ToString(), orderby);

            int TotalRecords = 0;
            if (ds.Tables[1].Rows.Count > 0)
            {
                TotalRecords = Format.DataConvertToInt(ds.Tables[1].Rows[0][0]);
            }

            List<phome_ecms_news> arr = GetModelListByDataTable(ds.Tables[0]);
            ArrayList a = new ArrayList();
            a.Add(arr);

            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;
            pager.TotalRecords = TotalRecords;
            pager.NewsCollection = a;
            pager.ClassID = classid;
            pager.KeyWord = keyword;

            return pager;

        }



        public DataSet GetMemberPostNewsCount(int userid)
        {

            return dal.GetMemberPostNewsCount(userid);
        }

        #region
        #endregion
        public  DataSet GetModelByIDAndClassID(int id, int classid)
        {

            return dal.GetModelByIDAndClassID(id,classid);
        }

        public  int  SignHaveHtml(int id, int havehtml)
        {

            return dal.SignHaveHtml(id, havehtml);
        }

        public int UpdateVoteNum(int id)
        {
            return dal.UpdateVoteNum(id);
        }

        public int GetHit(int id)
        {
            return dal.GetHit(id);
        }

        public int UpdateHit(int id)
        {
            return dal.UpdateHit(id);
        }

        public DataSet GetTopTitleByClassID(int PageSize, string ClassID, string orderby)
        {

            return dal.GetTopTitleByClassID(PageSize,ClassID,orderby);

        }

        public int  Delete(int id, int userid)
        {
            return dal.Delete(id, userid);
        }



        public int MoveNewsClass(int intClassID, int toClassID)
        {
            return dal.MoveNewsClass(intClassID,toClassID);
        }

        public DataSet GetIndexTitleList()
        {

            return dal.GetIndexTitleList();
        }

        public    phome_ecms_news GetModelByDataRow(DataRow row)
        {  
             return dal.GetModelByDataRow(row);

        }

        public List<phome_ecms_news> GetModelListByDataTable(DataTable dataTable)
        {
            List<phome_ecms_news> arr = new List<phome_ecms_news>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                arr.Add(GetModelByDataRow(dataTable.Rows[i]));
            }

            return arr;

        }

        public DataSet GetIndexZhanHuiList()
        {

            return dal.GetIndexZhanHui();
        }
    }
}
