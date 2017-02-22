using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Templete;
using DBUtility;//请先添加引用
namespace LL.DAL.Templete
{
	/// <summary>
	/// 数据访问类phome_enewslisttemp。
	/// </summary>
	public class DALphome_enewslisttemp:Iphome_enewslisttemp
	{
		public DALphome_enewslisttemp()
		{}
		#region  成员方法


	

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LL.Model.Templete.phome_enewslisttemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewslisttemp(");
			strSql.Append("tempname,temptext,subnews,isdefault,listvar,rownum,modid,showdate,subtitle,classid)");
			strSql.Append(" values (");
			strSql.Append("@tempname,@temptext,@subnews,@isdefault,@listvar,@rownum,@modid,@showdate,@subtitle,@classid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@tempname", SqlDbType.NVarChar,180),
					new SqlParameter("@temptext", SqlDbType.NVarChar),
					new SqlParameter("@subnews", SqlDbType.Int,4),
					new SqlParameter("@isdefault", SqlDbType.Int,4),
					new SqlParameter("@listvar", SqlDbType.NVarChar),
					new SqlParameter("@rownum", SqlDbType.Int,4),
					new SqlParameter("@modid", SqlDbType.Int,4),
					new SqlParameter("@showdate", SqlDbType.NVarChar,150),
					new SqlParameter("@subtitle", SqlDbType.Int,4),
					new SqlParameter("@classid", SqlDbType.Int,4)};
			parameters[0].Value = model.tempname;
			parameters[1].Value = model.temptext;
			parameters[2].Value = model.subnews;
			parameters[3].Value = model.isdefault;
			parameters[4].Value = model.listvar;
			parameters[5].Value = model.rownum;
			parameters[6].Value = model.modid;
			parameters[7].Value = model.showdate;
			parameters[8].Value = model.subtitle;
			parameters[9].Value = model.classid;

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
		public int Update(LL.Model.Templete.phome_enewslisttemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewslisttemp set ");
			strSql.Append("tempname=@tempname,");
			strSql.Append("temptext=@temptext,");
			strSql.Append("subnews=@subnews,");
			strSql.Append("isdefault=@isdefault,");
			strSql.Append("listvar=@listvar,");
			strSql.Append("rownum=@rownum,");
			strSql.Append("modid=@modid,");
			strSql.Append("showdate=@showdate,");
			strSql.Append("subtitle=@subtitle,");
			strSql.Append("classid=@classid");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4),
					new SqlParameter("@tempname", SqlDbType.NVarChar,180),
					new SqlParameter("@temptext", SqlDbType.NVarChar),
					new SqlParameter("@subnews", SqlDbType.Int,4),
					new SqlParameter("@isdefault", SqlDbType.Int,4),
					new SqlParameter("@listvar", SqlDbType.NVarChar),
					new SqlParameter("@rownum", SqlDbType.Int,4),
					new SqlParameter("@modid", SqlDbType.Int,4),
					new SqlParameter("@showdate", SqlDbType.NVarChar,150),
					new SqlParameter("@subtitle", SqlDbType.Int,4),
					new SqlParameter("@classid", SqlDbType.Int,4)};
			parameters[0].Value = model.tempid;
			parameters[1].Value = model.tempname;
			parameters[2].Value = model.temptext;
			parameters[3].Value = model.subnews;
			parameters[4].Value = model.isdefault;
			parameters[5].Value = model.listvar;
			parameters[6].Value = model.rownum;
			parameters[7].Value = model.modid;
			parameters[8].Value = model.showdate;
			parameters[9].Value = model.subtitle;
			parameters[10].Value = model.classid;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int tempid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewslisttemp ");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4)};
			parameters[0].Value = tempid;

			return  DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Templete.phome_enewslisttemp GetModel(int tempid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 tempid,tempname,temptext,subnews,isdefault,listvar,rownum,modid,showdate,subtitle,classid from phome_enewslisttemp ");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4)};
			parameters[0].Value = tempid;

			LL.Model.Templete.phome_enewslisttemp model=new LL.Model.Templete.phome_enewslisttemp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["tempid"].ToString()!="")
				{
					model.tempid=int.Parse(ds.Tables[0].Rows[0]["tempid"].ToString());
				}
				model.tempname=ds.Tables[0].Rows[0]["tempname"].ToString();
				model.temptext=ds.Tables[0].Rows[0]["temptext"].ToString();
				if(ds.Tables[0].Rows[0]["subnews"].ToString()!="")
				{
					model.subnews=int.Parse(ds.Tables[0].Rows[0]["subnews"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isdefault"].ToString()!="")
				{
					model.isdefault=int.Parse(ds.Tables[0].Rows[0]["isdefault"].ToString());
				}
				model.listvar=ds.Tables[0].Rows[0]["listvar"].ToString();
				if(ds.Tables[0].Rows[0]["rownum"].ToString()!="")
				{
					model.rownum=int.Parse(ds.Tables[0].Rows[0]["rownum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["modid"].ToString()!="")
				{
					model.modid=int.Parse(ds.Tables[0].Rows[0]["modid"].ToString());
				}
				model.showdate=ds.Tables[0].Rows[0]["showdate"].ToString();
				if(ds.Tables[0].Rows[0]["subtitle"].ToString()!="")
				{
					model.subtitle=int.Parse(ds.Tables[0].Rows[0]["subtitle"].ToString());
				}
				if(ds.Tables[0].Rows[0]["classid"].ToString()!="")
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
            strSql.Append("select t.tempid,t.tempname,t.temptext,t.subnews,t.isdefault,t.listvar,t.rownum,t.modid,t.showdate,t.subtitle,t.classid ,m.mname ");
			strSql.Append(" FROM phome_enewslisttemp  t left join  phome_enewsmod  m  on  t.modid=m.mid ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int PageIndex,int PageSize,string strWhere ,string orderby )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(" tempid,tempname,temptext,subnews,isdefault,listvar,rownum,modid,showdate,subtitle,classid ");
			strSql.Append(" FROM phome_enewslisttemp ");
		


            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }


            IPager pager = new IPager();

            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "bqid";

            if (!string.IsNullOrEmpty(orderby))
            {

                pager.OrderBy = orderby;
            }
            else
            {

                pager.OrderBy = "tempid desc";
            }

            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;



            return pager.GetResult();

		}

	

		#endregion  成员方法
	}
}

