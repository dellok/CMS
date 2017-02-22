using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DBUtility;
using LL.DAL;
using LL.Model;

namespace LL.DAL
{
  public   class DALNewsBase:Repository<IAggregateRoot>  
 
    {



      private string tbname = "";
      private string field_id = "id";
      private string field_classid = "classid";
      private string field_checked = "checked";
      private string field_recommend = "isgood";
      private string field_istop = "istop";
      private string field_firsttitle = "firsttitle";
      private string searchtbname = "";



      public string SearchTableName
      {
          get { return searchtbname; }
          set { searchtbname = value; }
      
      }

      public string TableName
      {
          get { return tbname; }
          set { tbname = value; }

      }
      public string Field_ID
      {
          get { return field_id; }
          set { field_id = value; }
      }
      public string Field_ClassID
      {
          get { return field_classid; }
          set { field_classid = value; }
      }


      public string Field_Recommend
      {
          get { return field_recommend; }
          set { field_recommend = value; }
      }
      public string Field_Checked
      {
          get { return field_checked; }
          set { field_checked = value; }
      }
      public string Field_IsTop
      {
          get { return field_istop; }
          set { field_istop = value; }
      }
      public string Field_FirstTitle
      {
          get { return field_firsttitle; }
          set { field_firsttitle = value; }
      }

      #region
      /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <param name="check"></param>
        /// <returns></returns>

      public int BatchChecked(List<int> arrIDS, bool chk)
      {

       return    BatchChecked(arrIDS,chk);
      
      }
        public int BatchChecked(List<int> arrIDS, bool check,int userid)
        {
            StringBuilder sql = new StringBuilder();
            foreach (int id in arrIDS)
            {
                sql.AppendFormat(" update  {0}  set  {1}={2} where  {3}={4}  ", TableName, Field_Checked,check?1:0,Field_ID,id);

               if (userid>0)
               {

                   sql.AppendFormat(" and userid={0}",userid);
                   
               }
            }

            
            return DbHelperSQL.ExecuteSql(sql.ToString());
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <returns></returns>
        public int BatchDel(List<int> arrIDS)
        {

            return BatchDel(arrIDS);
        }
        public int BatchDel(List<int> arrIDS,int userid)
        {
            StringBuilder sql = new StringBuilder();
            foreach (int id in arrIDS)
            {
                sql.AppendFormat(" delete  {0} where {1}={2}",TableName,Field_ID, id);

                if (userid > 0)
                {

                    sql.AppendFormat(" and userid={0}", userid);

                }
            }
            return DbHelperSQL.ExecuteSql(sql.ToString());
        }

        /// <summary>
        /// 批量推荐
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <param name="intClassID"></param>
        /// <returns></returns>
        public int BatchRecomend(List<int> arrIDS, bool isRecommend)
        {

            return BatchRecomend(arrIDS,isRecommend,0);
        }
        public int BatchRecomend(List<int> arrIDS, bool isRecommend,int userid)
        {
            StringBuilder sql = new StringBuilder();
            foreach (int id in arrIDS)
            {
                sql.AppendFormat(" update   {0}  set  {1}={2} where {3}={4}",TableName,Field_Recommend,isRecommend?1:0,Field_ID,id );

                if (userid > 0)
                {

                    sql.AppendFormat(" and userid={0}", userid);

                }
            }
            return DbHelperSQL.ExecuteSql(sql.ToString());
        }

        /// <summary>
        /// 批量头条
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <param name="intClassID"></param>
        /// <returns></returns>

        public int BatchFirstTitle(List<int> arrIDS, bool isFirstTitle)
        {
            return BatchFirstTitle(arrIDS,isFirstTitle);
        
        }

        public int BatchFirstTitle(List<int> arrIDS, bool isFirstTitle,int userid)
        {
            StringBuilder sql = new StringBuilder();
            foreach (int id in arrIDS)
            {
                sql.AppendFormat(" update    {0} set  {1}={2} where {3}={4}", TableName, Field_FirstTitle, isFirstTitle?1:0, Field_ID, id);

                if (userid > 0)
                {

                    sql.AppendFormat(" and userid={0}", userid);

                }
            }
            return DbHelperSQL.ExecuteSql(sql.ToString());
        }
        /// <summary>
        /// 批量置顶
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <param name="intClassID"></param>
        /// <returns></returns>
        public int BatchIsTop(List<int> arrIDS, int intTopNum)
        {

            return BatchIsTop(arrIDS,intTopNum);
        }
        public int BatchIsTop(List<int> arrIDS, int intTopNum,int userid)
        {
            StringBuilder sql = new StringBuilder();
            foreach (int id in arrIDS)
            {
                sql.AppendFormat(" update    {0} set  {1}={2} where {3}={4}", TableName, Field_IsTop,  intTopNum, Field_ID, id);

                if (userid > 0)
                {

                    sql.AppendFormat(" and userid={0}", userid);

                }
            }
            return DbHelperSQL.ExecuteSql(sql.ToString());
        }

        /// <summary>
        /// 归档
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <returns></returns>
        public int BatchFiling(List<int> arrIDS)
        {/*

            StringBuilder sql = new StringBuilder();
            foreach (int id in arrIDS)
            {
                sql.AppendFormat(" delete  {0} where id={0}", id);
            }
            return DbHelperSQL.ExecuteSql(sql.ToString());
            */
            return 0;
        }

        /// <summary>
        /// 更新新闻分类
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <param name="intClassID"></param>
        /// <returns></returns>
        public int UpdateNewsClass(List<int> arrIDS, int intClassID)
        {

            StringBuilder sql = new StringBuilder();
            foreach (int id in arrIDS)
            {
                sql.AppendFormat(" update  {0} set  {1}={2} where {3}={4}", TableName, Field_ClassID, intClassID, Field_ID, id);
            }
            return DbHelperSQL.ExecuteSql(sql.ToString());
        }

      #endregion

        #region
        /// <summary>
        /// 更新点击 量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateTopHit(int id)
        {
            string sql = string.Format("update  {0}  set  diggtop=isnull(diggtop,1)+1 where id={1}", TableName, id);
            return DbHelperSQL.ExecuteSql(sql);

        }
        public int GetTopHit(int id)
        {
            string sql = string.Format("select   count(diggtop)  from {0}   where id={1}", TableName, id);


           return  (int)DbHelperSQL.GetSingle(sql);

        }

      /// <summary>
      /// 新闻顶一下
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        public int UpdateHit(int id)
        {

            string sql = string.Format("  update  {0} set diggtop=isnull(diggtop,0)+1  where id={1}", TableName, id);
            return DbHelperSQL.ExecuteSql(sql);
        }
        public int GetHit(int id)
        {

            string sql = string.Format("  select  count(diggtop) from {0}  where id={1}", TableName, id);
            return (int)DbHelperSQL.GetSingle(sql);
        }

      /// <summary>
      /// 新闻浏览量
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        public int UpdateVoteNum(int id)
        {
            string sql = string.Format("  update  {0} set Onclick=isnull(Onclick,0)+1  where id={1}", TableName, id);
            return DbHelperSQL.ExecuteSql(sql);
        }

        public int GetVoteNum(int id)
        {
            string sql = string.Format("select   count(Onclick)  from {0}   where id={1}", TableName, id);


            return (int)DbHelperSQL.GetSingle(sql);

        }




      /// <summary>
      /// 标记新闻已生成列态页
      /// </summary>
      /// <param name="id"></param>
      /// <param name="havehtml"></param>
      /// <returns></returns>
        public int SignHaveHtml(int id, int havehtml)
        {

            string sql = string.Format(" update  {0} set  havehtml=1 where id={2}",TableName, havehtml,id );
            return DbHelperSQL.ExecuteSql(sql);
        }

      

        #endregion

    }
}
