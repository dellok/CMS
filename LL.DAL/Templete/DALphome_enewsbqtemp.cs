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
	/// 数据访问类:phome_enewsbqtemp
	/// </summary>
	public partial class DALphome_enewsbqtemp:Iphome_enewsbqtemp
	{
		public DALphome_enewsbqtemp()
		{}
		#region  Method

		


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(phome_enewsbqtemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsbqtemp(");
			strSql.Append("tempname,modid,temptext,showdate,listvar,subnews,rownum,classid)");
			strSql.Append(" values (");
			strSql.Append("@tempname,@modid,@temptext,@showdate,@listvar,@subnews,@rownum,@classid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@tempname", SqlDbType.NVarChar,180),
					new SqlParameter("@modid", SqlDbType.Int,4),
					new SqlParameter("@temptext", SqlDbType.NVarChar),
					new SqlParameter("@showdate", SqlDbType.NVarChar,150),
					new SqlParameter("@listvar", SqlDbType.NVarChar),
					new SqlParameter("@subnews", SqlDbType.Int,4),
					new SqlParameter("@rownum", SqlDbType.Int,4),
					new SqlParameter("@classid", SqlDbType.Int,4)};
			parameters[0].Value = model.tempname;
			parameters[1].Value = model.modid;
			parameters[2].Value = model.temptext;
			parameters[3].Value = model.showdate;
			parameters[4].Value = model.listvar;
			parameters[5].Value = model.subnews;
			parameters[6].Value = model.rownum;
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
		public bool Update(phome_enewsbqtemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsbqtemp set ");
			strSql.Append("tempname=@tempname,");
			strSql.Append("modid=@modid,");
			strSql.Append("temptext=@temptext,");
			strSql.Append("showdate=@showdate,");
			strSql.Append("listvar=@listvar,");
			strSql.Append("subnews=@subnews,");
			strSql.Append("rownum=@rownum,");
			strSql.Append("classid=@classid");
			strSql.Append(" where tempid=@tempid");
			SqlParameter[] parameters = {
					new SqlParameter("@tempname", SqlDbType.NVarChar,180),
					new SqlParameter("@modid", SqlDbType.Int,4),
					new SqlParameter("@temptext", SqlDbType.NVarChar),
					new SqlParameter("@showdate", SqlDbType.NVarChar,150),
					new SqlParameter("@listvar", SqlDbType.NVarChar),
					new SqlParameter("@subnews", SqlDbType.Int,4),
					new SqlParameter("@rownum", SqlDbType.Int,4),
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@tempid", SqlDbType.Int,4)};
			parameters[0].Value = model.tempname;
			parameters[1].Value = model.modid;
			parameters[2].Value = model.temptext;
			parameters[3].Value = model.showdate;
			parameters[4].Value = model.listvar;
			parameters[5].Value = model.subnews;
			parameters[6].Value = model.rownum;
			parameters[7].Value = model.classid;
			parameters[8].Value = model.tempid;

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
		public bool Delete(int tempid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsbqtemp ");
			strSql.Append(" where tempid=@tempid");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4)
};
			parameters[0].Value = tempid;

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
		public bool DeleteList(string tempidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsbqtemp ");
			strSql.Append(" where tempid in ("+tempidlist + ")  ");
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
		public phome_enewsbqtemp GetModel(int tempid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 tempid,tempname,modid,temptext,showdate,listvar,subnews,rownum,classid from phome_enewsbqtemp ");
			strSql.Append(" where tempid=@tempid");
			SqlParameter[] parameters = {
					new SqlParameter("@tempid", SqlDbType.Int,4)
};
			parameters[0].Value = tempid;

			phome_enewsbqtemp model=new phome_enewsbqtemp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["tempid"]!=null && ds.Tables[0].Rows[0]["tempid"].ToString()!="")
				{
					model.tempid=int.Parse(ds.Tables[0].Rows[0]["tempid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tempname"]!=null && ds.Tables[0].Rows[0]["tempname"].ToString()!="")
				{
					model.tempname=ds.Tables[0].Rows[0]["tempname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["modid"]!=null && ds.Tables[0].Rows[0]["modid"].ToString()!="")
				{
					model.modid=int.Parse(ds.Tables[0].Rows[0]["modid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["temptext"]!=null && ds.Tables[0].Rows[0]["temptext"].ToString()!="")
				{
					model.temptext=ds.Tables[0].Rows[0]["temptext"].ToString();
				}
				if(ds.Tables[0].Rows[0]["showdate"]!=null && ds.Tables[0].Rows[0]["showdate"].ToString()!="")
				{
					model.showdate=ds.Tables[0].Rows[0]["showdate"].ToString();
				}
				if(ds.Tables[0].Rows[0]["listvar"]!=null && ds.Tables[0].Rows[0]["listvar"].ToString()!="")
				{
					model.listvar=ds.Tables[0].Rows[0]["listvar"].ToString();
				}
				if(ds.Tables[0].Rows[0]["subnews"]!=null && ds.Tables[0].Rows[0]["subnews"].ToString()!="")
				{
					model.subnews=int.Parse(ds.Tables[0].Rows[0]["subnews"].ToString());
				}
				if(ds.Tables[0].Rows[0]["rownum"]!=null && ds.Tables[0].Rows[0]["rownum"].ToString()!="")
				{
					model.rownum=int.Parse(ds.Tables[0].Rows[0]["rownum"].ToString());
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
			strSql.Append("select tempid,tempname,modid,temptext,showdate,listvar,subnews,rownum,classid ");
			strSql.Append(" FROM phome_enewsbqtemp ");
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
            strSql.Append("select ");
            strSql.Append(" tempid,tempname,modid,temptext,showdate,listvar,subnews,rownum,classid,m.mname ");
            strSql.Append(" FROM phome_enewsbqtemp t left join  phome_enewsmod m on  t.modid=m.mid");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }


            IPager pager = new IPager();

            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "tempid";

            if (!string.IsNullOrEmpty(orderby))
            {

                pager.OrderBy = orderby;
            }
            else
            {
                pager.OrderBy = "tempid";
            }

            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;



            return pager.GetResult();
        }
		#endregion  Method
	}
}

