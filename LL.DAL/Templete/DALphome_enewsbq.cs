using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL;
using DBUtility;
using LL.Model.Templete;
namespace LL.DAL.Templete
{
	/// <summary>
	/// 数据访问类:phome_enewsbq
	/// </summary>
	public partial class DALphome_enewsbq:Iphome_enewsbq
	{
		public DALphome_enewsbq()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(phome_enewsbq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsbq(");
			strSql.Append("bqname,bqsay,funname,bq,issys,bqgs,isclose,classid)");
			strSql.Append(" values (");
			strSql.Append("@bqname,@bqsay,@funname,@bq,@issys,@bqgs,@isclose,@classid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@bqname", SqlDbType.NVarChar,180),
					new SqlParameter("@bqsay", SqlDbType.NVarChar),
					new SqlParameter("@funname", SqlDbType.NVarChar,180),
					new SqlParameter("@bq", SqlDbType.NVarChar,180),
					new SqlParameter("@issys", SqlDbType.Int,4),
					new SqlParameter("@bqgs", SqlDbType.NVarChar),
					new SqlParameter("@isclose", SqlDbType.Int,4),
					new SqlParameter("@classid", SqlDbType.Int,4)};
			parameters[0].Value = model.bqname;
			parameters[1].Value = model.bqsay;
			parameters[2].Value = model.funname;
			parameters[3].Value = model.bq;
			parameters[4].Value = model.issys;
			parameters[5].Value = model.bqgs;
			parameters[6].Value = model.isclose;
			parameters[7].Value = model.classid;

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
		public bool Update(phome_enewsbq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsbq set ");
			strSql.Append("bqname=@bqname,");
			strSql.Append("bqsay=@bqsay,");
			strSql.Append("funname=@funname,");
			strSql.Append("bq=@bq,");
			strSql.Append("issys=@issys,");
			strSql.Append("bqgs=@bqgs,");
			strSql.Append("isclose=@isclose,");
			strSql.Append("classid=@classid");
			strSql.Append(" where bqid=@bqid");
			SqlParameter[] parameters = {
					new SqlParameter("@bqname", SqlDbType.NVarChar,180),
					new SqlParameter("@bqsay", SqlDbType.NVarChar),
					new SqlParameter("@funname", SqlDbType.NVarChar,180),
					new SqlParameter("@bq", SqlDbType.NVarChar,180),
					new SqlParameter("@issys", SqlDbType.Int,4),
					new SqlParameter("@bqgs", SqlDbType.NVarChar),
					new SqlParameter("@isclose", SqlDbType.Int,4),
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@bqid", SqlDbType.Int,4)};
			parameters[0].Value = model.bqname;
			parameters[1].Value = model.bqsay;
			parameters[2].Value = model.funname;
			parameters[3].Value = model.bq;
			parameters[4].Value = model.issys;
			parameters[5].Value = model.bqgs;
			parameters[6].Value = model.isclose;
			parameters[7].Value = model.classid;
			parameters[8].Value = model.bqid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int bqid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsbq ");
			strSql.Append(" where bqid=@bqid");
			SqlParameter[] parameters = {
					new SqlParameter("@bqid", SqlDbType.Int,4)
};
			parameters[0].Value = bqid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string bqidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsbq ");
			strSql.Append(" where bqid in ("+bqidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public phome_enewsbq GetModel(int bqid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 bqid,bqname,bqsay,funname,bq,issys,bqgs,isclose,classid from phome_enewsbq ");
			strSql.Append(" where bqid=@bqid");
			SqlParameter[] parameters = {
					new SqlParameter("@bqid", SqlDbType.Int,4)
};
			parameters[0].Value = bqid;

			phome_enewsbq model=new phome_enewsbq();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["bqid"]!=null && ds.Tables[0].Rows[0]["bqid"].ToString()!="")
				{
					model.bqid=int.Parse(ds.Tables[0].Rows[0]["bqid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["bqname"]!=null && ds.Tables[0].Rows[0]["bqname"].ToString()!="")
				{
					model.bqname=ds.Tables[0].Rows[0]["bqname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bqsay"]!=null && ds.Tables[0].Rows[0]["bqsay"].ToString()!="")
				{
					model.bqsay=ds.Tables[0].Rows[0]["bqsay"].ToString();
				}
				if(ds.Tables[0].Rows[0]["funname"]!=null && ds.Tables[0].Rows[0]["funname"].ToString()!="")
				{
					model.funname=ds.Tables[0].Rows[0]["funname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["bq"]!=null && ds.Tables[0].Rows[0]["bq"].ToString()!="")
				{
					model.bq=ds.Tables[0].Rows[0]["bq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["issys"]!=null && ds.Tables[0].Rows[0]["issys"].ToString()!="")
				{
					model.issys=int.Parse(ds.Tables[0].Rows[0]["issys"].ToString());
				}
				if(ds.Tables[0].Rows[0]["bqgs"]!=null && ds.Tables[0].Rows[0]["bqgs"].ToString()!="")
				{
					model.bqgs=ds.Tables[0].Rows[0]["bqgs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["isclose"]!=null && ds.Tables[0].Rows[0]["isclose"].ToString()!="")
				{
					model.isclose=int.Parse(ds.Tables[0].Rows[0]["isclose"].ToString());
				}
				if(ds.Tables[0].Rows[0]["classid"]!=null && ds.Tables[0].Rows[0]["classid"].ToString()!="")
				{
					model.classid=int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
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
			strSql.Append("select bqid,bqname,bqsay,funname,bq,issys,bqgs,isclose,classid ");
			strSql.Append(" FROM phome_enewsbq ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int pageindex,int pagesize,string strWhere,string orderby)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(" bqid,bqname,bqsay,funname,bq,issys,bqgs,isclose,classid ");
			strSql.Append(" FROM phome_enewsbq ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where  1=1 "+strWhere);
			}
	

            IPager pager = new IPager();

            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "bqid";

            if (!string.IsNullOrEmpty(orderby))
            {

                pager.OrderBy = orderby;
            }

            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;



            return pager.GetResult();
		}

		

		#endregion  Method
	}
}

