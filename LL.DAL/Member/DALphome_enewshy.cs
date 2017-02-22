using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Member;
using DBUtility;
using LL.Model.Member;
using Project.Common;
namespace LL.DAL.Member
{
	/// <summary>
	///我的好友
	/// </summary>
	public partial class DALphome_enewshy:Iphome_enewshy
	{
		public DALphome_enewshy()
		{}
		#region  Method


       public  bool ExistsCName(string cname, int  userid, int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select count(*)  from phome_enewshy  where ");
            sql.AppendFormat("  fname ='{0}'", cname);
            if (userid > 0)
            {
                sql.AppendFormat(" and  userid={0}", userid);
            }
            if (id > 0)
            {
                sql.AppendFormat("  and  fid <>{0}", id);
            }

            object obj = DbHelperSQL.GetSingle(sql.ToString());

            if (obj != null)
            {
                return (int)obj > 0 ? true : false;
            }
            else
            {

                return false;
            }
        }
		
		public int  Add(phome_enewshy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewshy(");
			strSql.Append("userid,fname,cid,fsay)");
			strSql.Append(" values (");
			strSql.Append("@userid,@fname,@cid,@fsay)");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@fname", SqlDbType.NVarChar,90),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@fsay", SqlDbType.NVarChar,255)};
		
			parameters[0].Value = model.userid;
			parameters[1].Value = model.fname;
			parameters[2].Value = model.cid;
			parameters[3].Value = model.fsay;
		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		public int  Update(phome_enewshy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewshy set ");
			strSql.Append("userid=@userid,");
			strSql.Append("fname=@fname,");
			strSql.Append("cid=@cid,");
			strSql.Append("fsay=@fsay");
            strSql.Append(" where  fid=@fid");
			SqlParameter[] parameters = {
					new SqlParameter("@fid", SqlDbType.Int,4),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@fname", SqlDbType.NVarChar,90),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@fsay", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.fid;
			parameters[1].Value = model.userid;
			parameters[2].Value = model.fname;
			parameters[3].Value = model.cid;
			parameters[4].Value = model.fsay;
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return rows;
		}
        public int Delete(int id, int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from phome_enewshy  where fid={0}",id);
            if (userid>0)
            {
                strSql.AppendFormat(" and userid={0}",userid);
            }

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());

            return rows;
        }
		public int Delete(int id)
		{

            return Delete(id,0);
		}


        public phome_enewshy GetModel(int id)
        {

            return GetModel(id,0);
        }
		
		public phome_enewshy GetModel(int id,int userid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 fid,userid,fname,cid,fsay from phome_enewshy ");
			strSql.AppendFormat("  where fid={0}",id);
            if (userid > 0)
            {
                strSql.AppendFormat(" and userid={0}", userid);
            }
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{

                return GetModelByDataRow(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

        public phome_enewshy GetModelByDataRow(DataRow row)
        {
            phome_enewshy model = new phome_enewshy();

            if (row["fid"] != null && row["fid"].ToString() != "")
            {
                model.fid = int.Parse(row["fid"].ToString());
            }
            if (row["userid"] != null && row["userid"].ToString() != "")
            {
                model.userid = int.Parse(row["userid"].ToString());
            }
            if (row["fname"] != null && row["fname"].ToString() != "")
            {
                model.fname = row["fname"].ToString();
            }
            if (row["cid"] != null && row["cid"].ToString() != "")
            {
                model.cid = int.Parse(row["cid"].ToString());
            }
            if (row["fsay"] != null && row["fsay"].ToString() != "")
            {
                model.fsay = row["fsay"].ToString();
            }
            return model;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select fid,userid,fname,cid,fsay ");
			strSql.Append(" FROM phome_enewshy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public DataSet GetList(int pageindex, int pagesize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select * from  phome_enewshy");

            if (strWhere.Trim() != "")
            {
                strWhere = strWhere.Trim().ToLower();

                if (strWhere.IndexOf("and") == 0)
                {
                    strSql.Append(" where  1=1 " + strWhere);
                }
                else
                {
                    strSql.AppendFormat(" where  {0}", strWhere);
                }
            }
            IPager pager = new IPager();
            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "fid";
            pager.OrderBy = orderby;
           
            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;

            return pager.GetResult();
		}

		
		#endregion  Method
	}
}

