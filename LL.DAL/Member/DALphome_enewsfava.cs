using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Member;
using DBUtility;
namespace LL.DAL.Member
{
	/// <summary>
	/// 收藏夹
	/// </summary>
	public partial class DALphome_enewsfava:Iphome_enewsfava
	{
		public DALphome_enewsfava()
		{}
		#region  Method

		


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LL.Model.Member.phome_enewsfava model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsfava(");
			strSql.Append("id,favatime,userid,username,classid,cid)");
			strSql.Append(" values (");
			strSql.Append("@id,@favatime,@userid,@username,@classid,@cid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@favatime", SqlDbType.DateTime),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,90),
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.favatime;
			parameters[2].Value = model.userid;
			parameters[3].Value = model.username;
			parameters[4].Value = model.classid;
			parameters[5].Value = model.cid;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(LL.Model.Member.phome_enewsfava model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsfava set ");
			strSql.Append("id=@id,");
			strSql.Append("favatime=@favatime,");
			strSql.Append("userid=@userid,");
			strSql.Append("username=@username,");
			strSql.Append("classid=@classid,");
			strSql.Append("cid=@cid");
			strSql.Append(" where favaid=@favaid");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@favatime", SqlDbType.DateTime),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,90),
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@favaid", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.favatime;
			parameters[2].Value = model.userid;
			parameters[3].Value = model.username;
			parameters[4].Value = model.classid;
			parameters[5].Value = model.cid;
			parameters[6].Value = model.favaid;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int favaid)
		{

            return Delete(favaid,0);
		}

       public  int Delete(int fid, int userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_enewsfava ");
            strSql.AppendFormat(" where favaid={0}",fid);
         
            if (userid>0)
            {

                strSql.AppendFormat(" and  userid={0}",userid);
            }
           

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

       public int DeleteList(string favaidlist)
       {

           return DeleteList(favaidlist,"");
       }
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public int  DeleteList(string favaidlist ,string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsfava ");
			strSql.Append(" where favaid in ("+favaidlist + ")  ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.AppendFormat(" and {0}",where);
                
            }
			return DbHelperSQL.ExecuteSql(strSql.ToString());
			
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Member.phome_enewsfava GetModel(int favaid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 favaid,id,favatime,userid,username,classid,cid from phome_enewsfava ");
			strSql.Append(" where favaid=@favaid");
			SqlParameter[] parameters = {
					new SqlParameter("@favaid", SqlDbType.Int,4)
};
			parameters[0].Value = favaid;

			LL.Model.Member.phome_enewsfava model=new LL.Model.Member.phome_enewsfava();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["favaid"]!=null && ds.Tables[0].Rows[0]["favaid"].ToString()!="")
				{
					model.favaid=int.Parse(ds.Tables[0].Rows[0]["favaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["favatime"]!=null && ds.Tables[0].Rows[0]["favatime"].ToString()!="")
				{
					model.favatime=DateTime.Parse(ds.Tables[0].Rows[0]["favatime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["userid"]!=null && ds.Tables[0].Rows[0]["userid"].ToString()!="")
				{
					model.userid=int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["username"]!=null && ds.Tables[0].Rows[0]["username"].ToString()!="")
				{
					model.username=ds.Tables[0].Rows[0]["username"].ToString();
				}
				if(ds.Tables[0].Rows[0]["classid"]!=null && ds.Tables[0].Rows[0]["classid"].ToString()!="")
				{
					model.classid=int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cid"]!=null && ds.Tables[0].Rows[0]["cid"].ToString()!="")
				{
					model.cid=int.Parse(ds.Tables[0].Rows[0]["cid"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select favaid,id,favatime,userid,username,classid,cid ");
			strSql.Append(" FROM phome_enewsfava ");
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
			strSql.Append(" favaid,id,favatime,userid,username,classid,cid ");
			strSql.Append(" FROM phome_enewsfava ");
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
            strSql.AppendFormat(" select * from  phome_enewsfava");
            strSql.Append(IPager.SetSqlWhere(strWhere));
            IPager pager = new IPager();
            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "favaid";
            pager.OrderBy = orderby;
            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;

            return pager.GetResult();
        }

		#endregion  Method
	}
}

