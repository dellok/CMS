using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Templete;
using DBUtility;
using LL.Model.Templete;//请先添加引用
namespace LL.DAL.Templete
{
	/// <summary>
	/// 数据访问类phome_enewstempvar。
	/// </summary>
	public class DALphome_enewstempvar:Iphome_enewstempvar
	{
		public DALphome_enewstempvar()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(phome_enewstempvar model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewstempvar(");
			strSql.Append("myvar,varname,varvalue,classid,isclose,myorder)");
			strSql.Append(" values (");
			strSql.Append("@myvar,@varname,@varvalue,@classid,@isclose,@myorder)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@myvar", SqlDbType.VarChar,180),
					new SqlParameter("@varname", SqlDbType.VarChar,180),
					new SqlParameter("@varvalue", SqlDbType.Text),
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@isclose", SqlDbType.Int,4),
					new SqlParameter("@myorder", SqlDbType.Int,4)};
			parameters[0].Value = model.myvar;
			parameters[1].Value = model.varname;
			parameters[2].Value = model.varvalue;
			parameters[3].Value = model.classid;
			parameters[4].Value = model.isclose;
			parameters[5].Value = model.myorder;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(phome_enewstempvar model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewstempvar set ");
			strSql.Append("myvar=@myvar,");
			strSql.Append("varname=@varname,");
			strSql.Append("varvalue=@varvalue,");
			strSql.Append("classid=@classid,");
			strSql.Append("isclose=@isclose,");
			strSql.Append("myorder=@myorder");
			strSql.Append(" where varid=@varid ");
			SqlParameter[] parameters = {
					new SqlParameter("@varid", SqlDbType.Int,4),
					new SqlParameter("@myvar", SqlDbType.VarChar,180),
					new SqlParameter("@varname", SqlDbType.VarChar,180),
					new SqlParameter("@varvalue", SqlDbType.Text),
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@isclose", SqlDbType.Int,4),
					new SqlParameter("@myorder", SqlDbType.Int,4)};
			parameters[0].Value = model.varid;
			parameters[1].Value = model.myvar;
			parameters[2].Value = model.varname;
			parameters[3].Value = model.varvalue;
			parameters[4].Value = model.classid;
			parameters[5].Value = model.isclose;
			parameters[6].Value = model.myorder;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int varid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewstempvar ");
			strSql.Append(" where varid=@varid ");
			SqlParameter[] parameters = {
					new SqlParameter("@varid", SqlDbType.Int,4)};
			parameters[0].Value = varid;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public phome_enewstempvar GetModel(int varid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 varid,myvar,varname,varvalue,classid,isclose,myorder from phome_enewstempvar ");
			strSql.Append(" where varid=@varid ");
			SqlParameter[] parameters = {
					new SqlParameter("@varid", SqlDbType.Int,4)};
			parameters[0].Value = varid;

			phome_enewstempvar model=new phome_enewstempvar();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["varid"].ToString()!="")
				{
					model.varid=int.Parse(ds.Tables[0].Rows[0]["varid"].ToString());
				}
				model.myvar=ds.Tables[0].Rows[0]["myvar"].ToString();
				model.varname=ds.Tables[0].Rows[0]["varname"].ToString();
				model.varvalue=ds.Tables[0].Rows[0]["varvalue"].ToString();
				if(ds.Tables[0].Rows[0]["classid"].ToString()!="")
				{
					model.classid=int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isclose"].ToString()!="")
				{
					model.isclose=int.Parse(ds.Tables[0].Rows[0]["isclose"].ToString());
				}
				if(ds.Tables[0].Rows[0]["myorder"].ToString()!="")
				{
					model.myorder=int.Parse(ds.Tables[0].Rows[0]["myorder"].ToString());
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
			strSql.Append("select varid,myvar,varname,varvalue,classid,isclose,myorder ");
			strSql.Append(" FROM phome_enewstempvar ");
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
			strSql.Append(" varid,myvar,varname,varvalue,classid,isclose,myorder ");
			strSql.Append(" FROM phome_enewstempvar ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "phome_enewstempvar";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法


        
    }
}

