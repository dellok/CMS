using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LL.IDAL.News;
using LL.Model.News;
using DBUtility;
using LL.Model;

namespace LL.DAL.News
{
   public  class DALNewsFeedback:Repository<IAggregateRoot>,INewsFeedback
    {

       DALphomeecmsnews dalNews = new DALphomeecmsnews();
     

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(NewsFeedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewsFeedback(");
            strSql.Append("NewsID,NewsClassID,UserID,UserName,IP,InDate,Content,Checked,Recommend,ReplyParentID,PageUrl,Title)");
            strSql.Append(" values (");
            strSql.Append("@NewsID,@NewsClassID,@UserID,@UserName,@IP,@InDate,@Content,@Checked,@Recommend,@ReplyParentID,@PageUrl,@Title)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@NewsClassID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@IP", SqlDbType.VarChar,100),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Content", SqlDbType.VarChar,1000),
					new SqlParameter("@Checked", SqlDbType.Bit,1),
					new SqlParameter("@Recommend", SqlDbType.Bit,1),
					new SqlParameter("@ReplyParentID", SqlDbType.Int,4),
					new SqlParameter("@PageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@Title", SqlDbType.VarChar,200)};
            parameters[0].Value = model.NewsID;
            parameters[1].Value = model.NewsClassID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.IP;
            parameters[5].Value = model.InDate;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.Checked;
            parameters[8].Value = model.Recommend;
            parameters[9].Value = model.ReplyParentID;
            parameters[10].Value = model.PageUrl;
            parameters[11].Value = model.Title;

            object obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (obj == null)
            {
               


                return 0;
            }
            else
            { //更新新闻评论数据 

                dalNews.UpdateNewsFeedbackNum(model.ID);
                return Convert.ToInt32(obj);
            }

        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public int Update(NewsFeedback model)
        {

            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update NewsFeedback set ");
                strSql.Append("NewsID=@NewsID,");
                strSql.Append("NewsClassID=@NewsClassID,");
                strSql.Append("UserID=@UserID,");
                strSql.Append("UserName=@UserName,");
                strSql.Append("IP=@IP,");
                strSql.Append("InDate=@InDate,");
                strSql.Append("Content=@Content,");
                strSql.Append("Checked=@Checked,");
                strSql.Append("Recommend=@Recommend,");
                strSql.Append("ReplyParentID=@ReplyParentID,");
                strSql.Append("PageUrl=@PageUrl,");
                strSql.Append("Title=@Title");
                strSql.Append(" where ID=@ID ");
                SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@NewsClassID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@IP", SqlDbType.VarChar,100),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Content", SqlDbType.VarChar,1000),
					new SqlParameter("@Checked", SqlDbType.Bit,1),
					new SqlParameter("@Recommend", SqlDbType.Bit,1),
					new SqlParameter("@ReplyParentID", SqlDbType.Int,4),
					new SqlParameter("@PageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@Title", SqlDbType.VarChar,200)};
                parameters[0].Value = model.ID;
                parameters[1].Value = model.NewsID;
                parameters[2].Value = model.NewsClassID;
                parameters[3].Value = model.UserID;
                parameters[4].Value = model.UserName;
                parameters[5].Value = model.IP;
                parameters[6].Value = model.InDate;
                parameters[7].Value = model.Content;
                parameters[8].Value = model.Checked;
                parameters[9].Value = model.Recommend;
                parameters[10].Value = model.ReplyParentID;
                parameters[11].Value = model.PageUrl;
                parameters[12].Value = model.Title;

               return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            }
            catch (Exception)
            {

                return 0;
            }


        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public int Delete(int ID)
        {
           StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsFeedback ");
			strSql.AppendFormat(" where ID={0}",ID);

			return  DbHelperSQL.ExecuteSql(strSql.ToString());
			
        }
       /// <summary>
       /// 删除全部
       /// </summary>
       /// <param name="IDS"></param>
       /// <returns></returns>
        public int DeleteAll(List<int> IDS)
        {

            StringBuilder delSql = new StringBuilder();

            foreach (int id in IDS)
            {

                delSql.AppendFormat("   delete   NewsFeedback  where id={0}", id);

            }
            return  DbHelperSQL.ExecuteSql(delSql.ToString());        
        }
        /// <summary>
        /// 返回对橡
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsFeedback GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,NewsID,NewsClassID,UserID,UserName,IP,InDate,Content,Checked,Recommend,ReplyParentID,PageUrl,Title from NewsFeedback ");
            strSql.AppendFormat(" where ID={0}",ID);
         

           NewsFeedback model = new NewsFeedback();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NewsID"] != null && ds.Tables[0].Rows[0]["NewsID"].ToString() != "")
                {
                    model.NewsID = int.Parse(ds.Tables[0].Rows[0]["NewsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NewsClassID"] != null && ds.Tables[0].Rows[0]["NewsClassID"].ToString() != "")
                {
                    model.NewsClassID = int.Parse(ds.Tables[0].Rows[0]["NewsClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IP"] != null && ds.Tables[0].Rows[0]["IP"].ToString() != "")
                {
                    model.IP = ds.Tables[0].Rows[0]["IP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InDate"] != null && ds.Tables[0].Rows[0]["InDate"].ToString() != "")
                {
                    model.InDate = DateTime.Parse(ds.Tables[0].Rows[0]["InDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Checked"] != null && ds.Tables[0].Rows[0]["Checked"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Checked"].ToString() == "1") || (ds.Tables[0].Rows[0]["Checked"].ToString().ToLower() == "true"))
                    {
                        model.Checked = true;
                    }
                    else
                    {
                        model.Checked = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Recommend"] != null && ds.Tables[0].Rows[0]["Recommend"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Recommend"].ToString() == "1") || (ds.Tables[0].Rows[0]["Recommend"].ToString().ToLower() == "true"))
                    {
                        model.Recommend = true;
                    }
                    else
                    {
                        model.Recommend = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ReplyParentID"] != null && ds.Tables[0].Rows[0]["ReplyParentID"].ToString() != "")
                {
                    model.ReplyParentID = int.Parse(ds.Tables[0].Rows[0]["ReplyParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PageUrl"] != null && ds.Tables[0].Rows[0]["PageUrl"].ToString() != "")
                {
                    model.PageUrl = ds.Tables[0].Rows[0]["PageUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public List<NewsFeedback> GetModelAll()
        {
            return null;
        }

       /// <summary>
       /// 查询信息
       /// </summary>
       /// <param name="PageIndex"></param>
       /// <param name="PageSize"></param>
       /// <param name="where"></param>
       /// <returns></returns>
       public  System.Data.DataSet GetList(int PageIndex, int PageSize, string where,string orderby)
        {
            string tableName = string.Format("  select  n.* ,p.content as replyContent  from  NewsFeedback  n  left join  newsfeedback  p  on n.replyparentid=p.id  where {0} ", where);


            IPager ipager = new IPager();
            ipager.TableName = tableName;
            ipager.PageIndex = PageIndex;
            ipager.OrderBy = orderby;
            ipager.PageSize = PageSize;
            return ipager.GetResult();
          
        
        }
       /// <summary>
       /// 批量审核
       /// </summary>
       /// <param name="IDS"></param>
       /// <param name="IsChecked"></param>
       /// <returns></returns>
       public int BatchChecked(List<int> IDS, bool IsChecked)
       {
           StringBuilder sql = new StringBuilder();


           int ched = IsChecked ? 1 : 0;
           foreach (int  id in IDS)
           {

               sql.AppendFormat("  update   newsfeedback set  checked={0} where id={1} ",ched,id);

           }

           return DBUtility.DbHelperSQL.ExecuteSql(sql.ToString());

          
       }

       /// <summary>
       /// 批量推荐
       /// </summary>
       /// <param name="IDS"></param>
       /// <param name="IsRecommend"></param>
       /// <returns></returns>
       public int BatchRecommend(List<int> IDS, bool IsRecommend)
       {
           StringBuilder sql = new StringBuilder();
           int isrd = IsRecommend ? 1 : 0;
           foreach (int id in IDS)
           {

               sql.AppendFormat(" update   newsfeedback set  recommend={0} where id={1}", isrd, id);

           }

           return DBUtility.DbHelperSQL.ExecuteSql(sql.ToString());
       }

   

       public DataSet GetList(string strWhere)
       {
           throw new NotImplementedException();
       }

       public DataSet GetList(int PageIndex, int PageSize, string where)
       {
           return GetList(PageIndex, PageSize, where, "");
       }
    }
}
