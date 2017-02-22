using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Templete;
using DBUtility;//请先添加引用
namespace LL.DAL.Templete
{
	/// <summary>
	/// 
	/// </summary>
	public class DALphome_enewsnewstempclass:Iphome_enewsnewstempclass
	{
		public DALphome_enewsnewstempclass()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LL.Model.Templete.phome_enewsnewstempclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsnewstempclass(");
			strSql.Append("classid,classname)");
			strSql.Append(" values (");
			strSql.Append("@classid,@classname)");
			SqlParameter[] parameters = {
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@classname", SqlDbType.NVarChar,90)};
			parameters[0].Value = model.classid;
			parameters[1].Value = model.classname;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(LL.Model.Templete.phome_enewsnewstempclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsnewstempclass set ");
			strSql.Append("classid=@classid,");
			strSql.Append("classname=@classname");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@classname", SqlDbType.NVarChar,90)};
			parameters[0].Value = model.classid;
			parameters[1].Value = model.classname;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete()
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_enewsnewstempclass ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Templete.phome_enewsnewstempclass GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 classid,classname from phome_enewsnewstempclass ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			LL.Model.Templete.phome_enewsnewstempclass model=new LL.Model.Templete.phome_enewsnewstempclass();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["classid"].ToString()!="")
				{
					model.classid=int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
				}
				model.classname=ds.Tables[0].Rows[0]["classname"].ToString();
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
			strSql.Append("select classid,classname ");
			strSql.Append(" FROM phome_enewsnewstempclass ");
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
			strSql.Append(" classid,classname ");
			strSql.Append(" FROM phome_enewsnewstempclass ");
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
        public DataSet GetList(int PageIndex, int PageSize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(" classid,classname ");
            strSql.Append(" FROM phome_enewsnewstempclass ");



            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }


            IPager pager = new IPager();

            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "classid";

            if (!string.IsNullOrEmpty(orderby))
            {

                pager.OrderBy = orderby;
            }
            else
            {

                pager.OrderBy = "classid desc";
            }

            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;



            return pager.GetResult();

        }
		#endregion  成员方法


    
    }
}

