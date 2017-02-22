using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using LL.IDAL.Member;

using System.Data.SqlClient;
using System.Data;
using LL.Model.Member;
using DBUtility;
using LL.Model;

namespace LL.DAL.Member
{
    public class DALPhomeENewsQMsg :Repository<IAggregateRoot>, IPhomeENewsQMsg
    {


      
    
        public int Add(phome_enewsqmsg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into phome_enewsqmsg(");
            strSql.Append("mid,title,msgtext,haveread,msgtime,to_username,from_userid,from_username,outbox,issys)");
            strSql.Append(" values (");
            strSql.Append("@mid,@title,@msgtext,@haveread,@msgtime,@to_username,@from_userid,@from_username,@outbox,@issys)");
            SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,120),
					new SqlParameter("@msgtext", SqlDbType.Text),
					new SqlParameter("@haveread", SqlDbType.Bit,1),
					new SqlParameter("@msgtime", SqlDbType.DateTime),
					new SqlParameter("@to_username", SqlDbType.VarChar,30),
					new SqlParameter("@from_userid", SqlDbType.Int,4),
					new SqlParameter("@from_username", SqlDbType.VarChar,30),
					new SqlParameter("@outbox", SqlDbType.Bit,1),
					new SqlParameter("@issys", SqlDbType.Bit,1)};
            parameters[0].Value = model.mid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.msgtext;
            parameters[3].Value = model.haveread;
            parameters[4].Value = model.msgtime;
            parameters[5].Value = model.to_username;
            parameters[6].Value = model.from_userid;
            parameters[7].Value = model.from_username;
            parameters[8].Value = model.outbox;
            parameters[9].Value = model.issys;

       return      DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(phome_enewsqmsg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update phome_enewsqmsg set ");
            strSql.Append("title=@title,");
            strSql.Append("msgtext=@msgtext,");
            strSql.Append("haveread=@haveread,");
            strSql.Append("msgtime=@msgtime,");
            strSql.Append("to_username=@to_username,");
            strSql.Append("from_userid=@from_userid,");
            strSql.Append("from_username=@from_username,");
            strSql.Append("outbox=@outbox,");
            strSql.Append("issys=@issys");
            strSql.Append(" where mid=@mid ");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,120),
					new SqlParameter("@msgtext", SqlDbType.Text),
					new SqlParameter("@haveread", SqlDbType.Bit,1),
					new SqlParameter("@msgtime", SqlDbType.DateTime),
					new SqlParameter("@to_username", SqlDbType.VarChar,30),
					new SqlParameter("@from_userid", SqlDbType.Int,4),
					new SqlParameter("@from_username", SqlDbType.VarChar,30),
					new SqlParameter("@outbox", SqlDbType.Bit,1),
					new SqlParameter("@issys", SqlDbType.Bit,1),
					new SqlParameter("@mid", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.msgtext;
            parameters[2].Value = model.haveread;
            parameters[3].Value = model.msgtime;
            parameters[4].Value = model.to_username;
            parameters[5].Value = model.from_userid;
            parameters[6].Value = model.from_username;
            parameters[7].Value = model.outbox;
            parameters[8].Value = model.issys;
            parameters[9].Value = model.mid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            return rows;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_enewsqmsg ");
            strSql.Append(" where mid=@mid ");
            SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)};
            parameters[0].Value = mid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        public int DeleteAll(List<int> arrID)
        {

            StringBuilder sql = new StringBuilder();

            foreach (int item in arrID)
            {

                sql.AppendFormat(" {0},",item);
                
            }

         string ids=   Project.Common.Util.FilterStartAndEndSign(sql.ToString(), ",");

         return DeleteList(ids);
        
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string midlist)
        {
            int rows = 0;
            if (midlist.Trim().Length>0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from phome_enewsqmsg ");
                strSql.Append(" where mid in (" + midlist + ")  ");

                rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            }
           

            return rows;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public phome_enewsqmsg GetModel(int mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 mid,title,msgtext,haveread,msgtime,to_username,from_userid,from_username,outbox,issys from phome_enewsqmsg ");
            strSql.Append(" where mid=@mid ");
            SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)};
            parameters[0].Value = mid;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return GetModelByDataSet(ds);
        }


        private phome_enewsqmsg GetModelByDataRow(DataRow row)
        {      phome_enewsqmsg model=new phome_enewsqmsg();
            if (row["mid"] != null && row["mid"].ToString() != "")
                {
                    model.mid = int.Parse(row["mid"].ToString());
                }
                if (row["title"] != null && row["title"].ToString() != "")
                {
                    model.title = row["title"].ToString();
                }
                if (row["msgtext"] != null && row["msgtext"].ToString() != "")
                {
                    model.msgtext = row["msgtext"].ToString();
                }
                if (row["haveread"] != null && row["haveread"].ToString() != "")
                {
                    if ((row["haveread"].ToString() == "1") || (row["haveread"].ToString().ToLower() == "true"))
                    {
                        model.haveread = true;
                    }
                    else
                    {
                        model.haveread = false;
                    }
                }
                if (row["msgtime"] != null && row["msgtime"].ToString() != "")
                {
                    model.msgtime = DateTime.Parse(row["msgtime"].ToString());
                }
                if (row["to_username"] != null && row["to_username"].ToString() != "")
                {
                    model.to_username = row["to_username"].ToString();
                }
                if (row["from_userid"] != null && row["from_userid"].ToString() != "")
                {
                    model.from_userid = int.Parse(row["from_userid"].ToString());
                }
                if (row["from_username"] != null && row["from_username"].ToString() != "")
                {
                    model.from_username = row["from_username"].ToString();
                }
                if (row["outbox"] != null && row["outbox"].ToString() != "")
                {
                    if ((row["outbox"].ToString() == "1") || (row["outbox"].ToString().ToLower() == "true"))
                    {
                        model.outbox = true;
                    }
                    else
                    {
                        model.outbox = false;
                    }
                }
                if (row["issys"] != null && row["issys"].ToString() != "")
                {
                    if ((row["issys"].ToString() == "1") || (row["issys"].ToString().ToLower() == "true"))
                    {
                        model.issys = true;
                    }
                    else
                    {
                        model.issys = false;
                    }
                }
                return model;
         
        }

        public DataSet Select(int pageindex, int pagesize, string where)
        {


            return GetList(pageindex,pagesize,where,"");
        
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int pageindex, int pagesize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  mid,title,msgtext,haveread,msgtime,to_username,from_userid,from_username,outbox,issys  FROM phome_enewsqmsg ");
            strSql.Append(IPager.SetSqlWhere(strWhere));
            IPager pager = new IPager();
            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "mid";
             pager.OrderBy = orderby;

            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;
            return pager.GetResult();
        }


      
      



        public phome_enewsqmsg GetModelByUserInbox(int id, string username)
        {


            string sql = string.Format(" select top 1  * from phome_enewsqmsg where mid={0} and to_username='{1}'",id,username);

            DataSet ds = DbHelperSQL.Query(sql);

            return GetModelByDataSet(ds);

        }

        private phome_enewsqmsg GetModelByDataSet(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetModelByDataRow(ds.Tables[0].Rows[0]);

            }
            else
            {

                return null;
            }
        }

       public  int SignBoxRead(int MessageID)
        {

            string sql = string.Format(" update phome_enewsqmsg set haveread=1 where mid={0}",MessageID);

            return DbHelperSQL.ExecuteSql(sql);
        }
        public phome_enewsqmsg GetModelByUserOutbox(int id, string username)
        {
            string sql = string.Format(" select top 1  * from phome_enewsqmsg where mid={0} and from_username='{1}'",id, username);

            DataSet ds = DbHelperSQL.Query(sql);

            return GetModelByDataSet(ds);
        }

        public int AddBath(List<phome_enewsqmsg> arrmsg)
        {
            StringBuilder sql = new StringBuilder();
            foreach (phome_enewsqmsg item in arrmsg)
            {
                sql.AppendFormat("INSERT INTO phome_enewsqmsg  (title ,msgtext ,haveread   ,msgtime    ,to_username  ,from_userid  ,from_username     ,outbox,issys)");

 sql.AppendFormat(" values (");
 sql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'",item.title,item.msgtext,item.haveread,item.msgtime,item.to_username,item.from_userid,item.from_username,item.outbox,item.issys);

 sql.AppendFormat(" )");
            }

            return DbHelperSQL.ExecuteSql(sql.ToString());
        }

        public int BatchSendByMemberRole(string sqlRole, int intSendNum, string strTitle, string strContent, string TagUserName)
        {

            return 1;
        }

        public phome_enewsqmsg GetModel(int mid, int userid)
        {

            string sql = string.Format(" select top 1 * from phome_enewsqmsg where mid={0} and from_userid={1}", mid, userid);

            DataSet ds = DbHelperSQL.Query(sql);

            return GetModelByDataSet(ds);
        
        
        }
        public int DeleteAll(string where)
        {


            return 0;
        }

        public int TotalReceiveMsg(int isRead, string username)
        {


            string sql = string.Format("  select count(*) from phome_enewsqmsg where haveread='{0}' and to_username='{1}'",isRead,username);

            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
            {

                return (int)obj;
            }
            else
            {

                return 0;
            }


        }


        public List<phome_enewsqmsg> GetModelAll()
        {
            throw new NotImplementedException();
        }

        public DataSet GetList(string strWhere)
        {
            throw new NotImplementedException();
        }
    }
}