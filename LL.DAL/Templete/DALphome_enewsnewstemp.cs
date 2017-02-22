using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Templete;
using DBUtility;//请先添加引用
namespace LL.DAL.Templete
{
	/// <summary>
	/// 内容模板
	/// </summary>
	public class DALphome_enewsnewstemp:Iphome_enewsnewstemp
	{
		public DALphome_enewsnewstemp()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("tempid", "phome_enewsnewstemp"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int tempid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from phome_enewsnewstemp");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4)};
			parameters[0].Value = tempid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LL.Model.Templete.phome_enewsnewstemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsnewstemp(");
			strSql.Append("tempname,isdefault,temptext,showdate,modid,classid)");
			strSql.Append(" values (");
			strSql.Append("@tempname,@isdefault,@temptext,@showdate,@modid,@classid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@tempname", SqlDbType.NVarChar,180),
					new SqlParameter("@isdefault", SqlDbType.Int,4),
					new SqlParameter("@temptext", SqlDbType.NVarChar),
					new SqlParameter("@showdate", SqlDbType.NVarChar,150),
					new SqlParameter("@modid", SqlDbType.Int,4),
					new SqlParameter("@classid", SqlDbType.Int,4)};
			parameters[0].Value = model.tempname;
			parameters[1].Value = model.isdefault;
			parameters[2].Value = model.temptext;
			parameters[3].Value = model.showdate;
			parameters[4].Value = model.modid;
			parameters[5].Value = model.classid;

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
		public int Update(LL.Model.Templete.phome_enewsnewstemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsnewstemp set ");
			strSql.Append("tempname=@tempname,");
			strSql.Append("isdefault=@isdefault,");
			strSql.Append("temptext=@temptext,");
			strSql.Append("showdate=@showdate,");
			strSql.Append("modid=@modid,");
			strSql.Append("classid=@classid");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4),
					new SqlParameter("@tempname", SqlDbType.NVarChar,180),
					new SqlParameter("@isdefault", SqlDbType.Int,4),
					new SqlParameter("@temptext", SqlDbType.NVarChar),
					new SqlParameter("@showdate", SqlDbType.NVarChar,150),
					new SqlParameter("@modid", SqlDbType.Int,4),
					new SqlParameter("@classid", SqlDbType.Int,4)};
			parameters[0].Value = model.tempid;
			parameters[1].Value = model.tempname;
			parameters[2].Value = model.isdefault;
			parameters[3].Value = model.temptext;
			parameters[4].Value = model.showdate;
			parameters[5].Value = model.modid;
			parameters[6].Value = model.classid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int tempid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsnewstemp ");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4)};
			parameters[0].Value = tempid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Templete.phome_enewsnewstemp GetModel(int tempid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 tempid,tempname,isdefault,temptext,showdate,modid,classid from phome_enewsnewstemp ");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4)};
			parameters[0].Value = tempid;

			LL.Model.Templete.phome_enewsnewstemp model=new LL.Model.Templete.phome_enewsnewstemp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["tempid"].ToString()!="")
				{
					model.tempid=int.Parse(ds.Tables[0].Rows[0]["tempid"].ToString());
				}
				model.tempname=ds.Tables[0].Rows[0]["tempname"].ToString();
				if(ds.Tables[0].Rows[0]["isdefault"].ToString()!="")
				{
					model.isdefault=int.Parse(ds.Tables[0].Rows[0]["isdefault"].ToString());
				}
				model.temptext=ds.Tables[0].Rows[0]["temptext"].ToString();
				model.showdate=ds.Tables[0].Rows[0]["showdate"].ToString();
				if(ds.Tables[0].Rows[0]["modid"].ToString()!="")
				{
					model.modid=int.Parse(ds.Tables[0].Rows[0]["modid"].ToString());
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



            return GetList(1, 1000, strWhere, string.Empty);

		}

        
        
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public DataSet GetList(int pageindex, int pagesize, string  where  ,string oderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.tempid,t.tempname,t.isdefault,t.temptext,t.showdate,t.modid,t.classid,m.mname ");
            strSql.AppendFormat(" FROM phome_enewsnewstemp t left join  phome_enewsmod  m  on  t.modid=m.mid   where 1=1 {0}",where);
            IPager pager = new IPager();

            pager.TableName = strSql.ToString();
            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;
            pager.PrimaryKeyField = " tempid ";
            pager.OrderBy = " tempid desc";

            return pager.GetResult();
        }

		
		

		#endregion  成员方法
	}
}

