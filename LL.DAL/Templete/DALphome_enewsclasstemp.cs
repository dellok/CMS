using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Templete;
using DBUtility;//请先添加引用
namespace LL.DAL.Templete
{
	/// <summary>
	/// 数据访问类phome_enewsclasstemp。
	/// </summary>
	public class DALphome_enewsclasstemp:Iphome_enewsclasstemp
	{
		public DALphome_enewsclasstemp()
		{}
		#region  成员方法

		


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LL.Model.Templete.phome_enewsclasstemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsclasstemp(");
			strSql.Append("tempname,temptext,classid)");
			strSql.Append(" values (");
			strSql.Append("@tempname,@temptext,@classid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@tempname", SqlDbType.NVarChar,90),
					new SqlParameter("@temptext", SqlDbType.NVarChar),
					new SqlParameter("@classid", SqlDbType.Int,4)};
			parameters[0].Value = model.tempname;
			parameters[1].Value = model.temptext;
			parameters[2].Value = model.classid;

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
		public int  Update(LL.Model.Templete.phome_enewsclasstemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsclasstemp set ");
			strSql.Append("tempname=@tempname,");
			strSql.Append("temptext=@temptext,");
			strSql.Append("classid=@classid");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4),
					new SqlParameter("@tempname", SqlDbType.NVarChar,90),
					new SqlParameter("@temptext", SqlDbType.NVarChar),
					new SqlParameter("@classid", SqlDbType.Int,4)};
			parameters[0].Value = model.tempid;
			parameters[1].Value = model.tempname;
			parameters[2].Value = model.temptext;
			parameters[3].Value = model.classid;

		return  	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int tempid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsclasstemp ");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4)};
			parameters[0].Value = tempid;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Templete.phome_enewsclasstemp GetModel(int tempid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 tempid,tempname,temptext,classid from phome_enewsclasstemp ");
			strSql.Append(" where tempid=@tempid ");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4)};
			parameters[0].Value = tempid;

			LL.Model.Templete.phome_enewsclasstemp model=new LL.Model.Templete.phome_enewsclasstemp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["tempid"].ToString()!="")
				{
					model.tempid=int.Parse(ds.Tables[0].Rows[0]["tempid"].ToString());
				}
				model.tempname=ds.Tables[0].Rows[0]["tempname"].ToString();
				model.temptext=ds.Tables[0].Rows[0]["temptext"].ToString();
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
			strSql.Append("select tempid,tempname,temptext,classid ");
			strSql.Append(" FROM phome_enewsclasstemp ");
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
			strSql.Append(" tempid,tempname,temptext,classid ");
			strSql.Append(" FROM phome_enewsclasstemp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        public DataSet GetList(int PageIndex, int PageSize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  tempid,tempname,temptext,classid FROM phome_enewsclasstemp ");
           



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

