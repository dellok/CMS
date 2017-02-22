using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;

using LL.IDAL.Member;
using LL.Model.Member;
namespace LL.DAL.Member
{
	/// <summary>
	/// 好友分类
	/// </summary>
	public partial class DALphome_enewshyclass:Iphome_enewshyclass
	{
		public DALphome_enewshyclass()
		{}
		#region  Method
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(phome_enewshyclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewshyclass(");
			strSql.Append("cname,userid)");
			strSql.Append(" values (");
			strSql.Append("@cname,@userid)");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,90),
					new SqlParameter("@userid", SqlDbType.Int,4)};
			
			parameters[0].Value = model.cname;
			parameters[1].Value = model.userid;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


 
		public int Update(int cid,string  cname)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewshyclass set ");
				strSql.Append("cname=@cname");
	
			strSql.Append(" where ");
            strSql.Append("cid=@cid");

            SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@cname", SqlDbType.NVarChar,200)};
				parameters[0].Value = cid;
			    parameters[1].Value =cname;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

            return rows;
		}

        public int Update(phome_enewshyclass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update phome_enewshyclass set ");
            strSql.Append("cname=@cname");
            strSql.Append("userid=@userid");
            strSql.Append(" where ");
            strSql.Append("cid=@cid");

            SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
                    new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@cname", SqlDbType.NVarChar,90)};
            parameters[0].Value = model.cid;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.cname;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            return rows;
        }

	
		public int Delete(int id,int userid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewshyclass ");
			strSql.AppendFormat(" where  cid={0}",id);

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

        public phome_enewshyclass GetModel(int id)
        {

            return GetModel(id,0);
        }
		
		public phome_enewshyclass GetModel(int id,int userid)
		{

			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 cid,cname,userid from phome_enewshyclass ");
            strSql.AppendFormat(" where  cid={0}", id);
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



        public phome_enewshyclass  GetModelByDataRow(DataRow row)
        {
            phome_enewshyclass model=new phome_enewshyclass();
        	if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["cname"]!=null && row["cname"].ToString()!="")
				{
					model.cname=row["cname"].ToString();
				}
				if(row["userid"]!=null && row["userid"].ToString()!="")
				{
					model.userid=int.Parse(row["userid"].ToString());
				}
				return model;
        }


		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select cid,cname,userid ");
			strSql.Append(" FROM phome_enewshyclass ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" cid,cname,userid ");
			strSql.Append(" FROM phome_enewshyclass ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int pageindex, int pagesize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select * from  phome_enewshyclass");

            strSql.Append(IPager.SetSqlWhere(strWhere));
            IPager pager = new IPager();
            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "cid";
            pager.OrderBy = orderby;
            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;
            return pager.GetResult();
        }
		#endregion  Method
        public bool ExistisClassName(string cname, int userid ,int id)
        {
            StringBuilder sql=new StringBuilder();
            sql.Append(" select count(*)  from phome_enewshyclass  where ");
            sql.AppendFormat("  cname ='{0}'", cname);
            if (userid>0)
            {
                sql.AppendFormat(" and  userid={0}", userid); 
            }

            if (id>0)
            {
                sql.AppendFormat("  and  cid <>{0}", id);
            }


            object obj = DbHelperSQL.GetSingle(sql.ToString());

            if (obj != null)
            {
                 
                return (int)obj>0?true:false;

            }
            else
            {

                return false;
            }




        }


   
    }
}

