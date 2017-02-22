using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using LL.IDAL.Member;
using LL.Model.Member;
namespace LL.DAL.Member
{
    public class  DALphome_enewsmembergbook:Iphome_enewsmembergbook
    {
      

     



        /// <summary>
        /// 得到选择项
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <param name="searchType"></param>
        /// <returns></returns>
        public System.Data.DataSet GetList(int PageIndex, int PageSize, string strWhere, string orderby)
        {
            IPager pager = new IPager();
            StringBuilder strSql = new StringBuilder("select   m.* ,t.username as spaceusername   from  phome_enewsmembergbook m left join  phome_enewsmember  t on m.userid=t.userid");


            strSql.Append(IPager.SetSqlWhere(strWhere));
            pager.TableName = strSql.ToString();
            pager.Fields = "*";
            pager.OrderBy = " gid desc ";
            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;
            pager.PrimaryKeyField = "gid";

            return pager.GetResult();
           
        }
       #region  Method



       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int  Add(phome_enewsmembergbook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsmembergbook(");
			strSql.Append("userid,isprivate,uid,uname,ip,addtime,gbtext,retext,checked)");
			strSql.Append(" values (");
			strSql.Append("@userid,@isprivate,@uid,@uname,@ip,@addtime,@gbtext,@retext,@checked)");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@isprivate", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@uname", SqlDbType.NVarChar,90),
					new SqlParameter("@ip", SqlDbType.NVarChar,45),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@gbtext", SqlDbType.NVarChar),
					new SqlParameter("@retext", SqlDbType.NVarChar),
					new SqlParameter("@checked", SqlDbType.Int,4)};
			parameters[0].Value = model.userid;
			parameters[1].Value = model.isprivate;
			parameters[2].Value = model.uid;
			parameters[3].Value = model.uname;
			parameters[4].Value = model.ip;
			parameters[5].Value = model.addtime;
			parameters[6].Value = model.gbtext;
			parameters[7].Value = model.retext;
			parameters[8].Value = model.@checked;

		return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public int  Update(phome_enewsmembergbook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsmembergbook set ");
			strSql.Append("userid=@userid,");
			strSql.Append("isprivate=@isprivate,");
			strSql.Append("uid=@uid,");
			strSql.Append("uname=@uname,");
			strSql.Append("ip=@ip,");
			strSql.Append("addtime=@addtime,");
			strSql.Append("gbtext=@gbtext,");
			strSql.Append("retext=@retext,");
			strSql.Append("checked=@checked");
            strSql.AppendFormat(" where gid=@gid");
			SqlParameter[] parameters = {
					new SqlParameter("@gid", SqlDbType.Int,4),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@isprivate", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@uname", SqlDbType.NVarChar,90),
					new SqlParameter("@ip", SqlDbType.NVarChar,45),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@gbtext", SqlDbType.NVarChar),
					new SqlParameter("@retext", SqlDbType.NVarChar),
					new SqlParameter("@checked", SqlDbType.Int,4)};
			parameters[0].Value = model.gid;
			parameters[1].Value = model.userid;
			parameters[2].Value = model.isprivate;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.uname;
			parameters[5].Value = model.ip;
			parameters[6].Value = model.addtime;
			parameters[7].Value = model.gbtext;
			parameters[8].Value = model.retext;
			parameters[9].Value = model.@checked;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		
		}

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public int  Delete(int gid)
       {
           return Delete(gid,0);
       }
       public int Delete(int id, int userid)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from phome_enewsmembergbook ");
           strSql.AppendFormat(" where gid={0}", id);
           if (userid > 0)
           {
               strSql.AppendFormat(" and userid={0}", userid);
           }
           return DbHelperSQL.ExecuteSql(strSql.ToString());
       }

   
       public int DeleteAll(string ids, int userid)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from phome_enewsmembergbook ");
           strSql.AppendFormat(" where id in({0})", ids);
           if (userid > 0)
           {
               strSql.AppendFormat(" and userid={0}", userid);
           }
           return DbHelperSQL.ExecuteSql(strSql.ToString());
          
       }

       public int CheckedAll(string ids, int ched, int userid)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from phome_enewsmembergbook ");
           strSql.AppendFormat(" where id in({0}) and checked={1}", ids, ched);
           if (userid > 0)
           {
               strSql.AppendFormat(" and userid={0}", userid);
           }
           return DbHelperSQL.ExecuteSql(strSql.ToString());
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public phome_enewsmembergbook GetModel(int gid)
		{

            return GetModel(gid,0);
			
		}
       public phome_enewsmembergbook GetModel(int id, int userid)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 gid,userid,isprivate,uid,uname,ip,addtime,gbtext,retext,checked from phome_enewsmembergbook ");
           strSql.AppendFormat(" where gid={0}", id);

           if (userid>0)
           {
               strSql.AppendFormat(" and userid={0}",userid);
           }

           DataSet ds = DbHelperSQL.Query(strSql.ToString());
           if (ds.Tables[0].Rows.Count > 0)
           {
               return GetModelByDataRow(ds.Tables[0].Rows[0]);

           }
           else
           {
               return null;
           }
       }

       public  phome_enewsmembergbook GetModelByDataRow(DataRow row)
       {
           phome_enewsmembergbook model = new phome_enewsmembergbook();
           if (row["gid"] != null && row["gid"].ToString() != "")
           {
               model.gid = int.Parse(row["gid"].ToString());
           }
           if (row["userid"] != null && row["userid"].ToString() != "")
           {
               model.userid = int.Parse(row["userid"].ToString());
           }
           if (row["isprivate"] != null && row["isprivate"].ToString() != "")
           {
               model.isprivate = int.Parse(row["isprivate"].ToString());
           }
           if (row["uid"] != null && row["uid"].ToString() != "")
           {
               model.uid = int.Parse(row["uid"].ToString());
           }
           if (row["uname"] != null && row["uname"].ToString() != "")
           {
               model.uname = row["uname"].ToString();
           }
           if (row["ip"] != null && row["ip"].ToString() != "")
           {
               model.ip = row["ip"].ToString();
           }
           if (row["addtime"] != null && row["addtime"].ToString() != "")
           {
               model.addtime = DateTime.Parse(row["addtime"].ToString());
           }
           if (row["gbtext"] != null && row["gbtext"].ToString() != "")
           {
               model.gbtext = row["gbtext"].ToString();
           }
           if (row["retext"] != null && row["retext"].ToString() != "")
           {
               model.retext = row["retext"].ToString();
           }
           if (row["checked"] != null && row["checked"].ToString() != "")
           {
               model.@checked = int.Parse(row["checked"].ToString());
           }
           return model;
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select gid,userid,isprivate,uid,uname,ip,addtime,gbtext,retext,checked ");
           strSql.Append(" FROM phome_enewsmembergbook ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           return DbHelperSQL.Query(strSql.ToString());
       }

       /// <summary>
       /// 获得前几行数据
       /// </summary>
       public DataSet GetList(int Top, string strWhere, string filedOrder)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select ");
           if (Top > 0)
           {
               strSql.Append(" top " + Top.ToString());
           }
           strSql.Append(" gid,userid,isprivate,uid,uname,ip,addtime,gbtext,retext,checked ");
           strSql.Append(" FROM phome_enewsmembergbook ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by " + filedOrder);
           return DbHelperSQL.Query(strSql.ToString());
       }

   
       #endregion  Method





   

    }
}
