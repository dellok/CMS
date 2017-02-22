using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Member;
using DBUtility;
using LL.Model.Member;
namespace LL.DAL.Member
{
	/// <summary>
    /// 留言分类
	/// </summary>
	public partial class DALphome_enewsgbookclass:Iphome_enewsgbookclass
	{
		public DALphome_enewsgbookclass()
		{}
		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(phome_enewsgbookclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsgbookclass(");
			strSql.Append("bname,checked,groupid)");
			strSql.Append(" values (");
			strSql.Append("@bname,@checked,@groupid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@bname", SqlDbType.NVarChar,180),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@groupid", SqlDbType.Int,4)};
			parameters[0].Value = model.bname;
			parameters[1].Value = model.@checked;
			parameters[2].Value = model.groupid;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			return (int)obj;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(phome_enewsgbookclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsgbookclass set ");
			strSql.Append("bname=@bname,");
			strSql.Append("checked=@checked,");
			strSql.Append("groupid=@groupid");
			strSql.Append(" where bid=@bid");
			SqlParameter[] parameters = {
					new SqlParameter("@bname", SqlDbType.NVarChar,180),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@bid", SqlDbType.Int,4)};
			parameters[0].Value = model.bname;
			parameters[1].Value = model.@checked;
			parameters[2].Value = model.groupid;
			parameters[3].Value = model.bid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			return rows;
		}


		public int  Delete(int bid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsgbookclass ");
			strSql.Append(" where bid=@bid");
			SqlParameter[] parameters = {
					new SqlParameter("@bid", SqlDbType.Int,4)
};
			parameters[0].Value = bid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

            return rows;
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public int  DeleteList(string bidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsgbookclass ");
			strSql.Append(" where bid in ("+bidlist + ")  ");
			return DbHelperSQL.ExecuteSql(strSql.ToString());
			 
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public phome_enewsgbookclass GetModel(int bid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 bid,bname,checked,groupid from phome_enewsgbookclass ");
			strSql.AppendFormat(" where bid=@bid");
			

	
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
              return   GetModelByDataRow(ds.Tables[0].Rows[0]);
		
			}
			else
			{
				return null;
			}
		}

        public   phome_enewsgbookclass GetModelByDataRow(DataRow row)
        {
            phome_enewsgbookclass model = new phome_enewsgbookclass();
            if (row["bid"] != null && row["bid"].ToString() != "")
            {
                model.bid = int.Parse(row["bid"].ToString());
            }
            if (row["bname"] != null && row["bname"].ToString() != "")
            {
                model.bname = row["bname"].ToString();
            }
            if (row["checked"] != null && row["checked"].ToString() != "")
            {
                model.@checked = int.Parse(row["checked"].ToString());
            }
            if (row["groupid"] != null && row["groupid"].ToString() != "")
            {
                model.groupid = int.Parse(row["groupid"].ToString());
            }
            return model;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select bid,bname,checked,groupid ");
			strSql.Append(" FROM phome_enewsgbookclass ");
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
			strSql.Append(" bid,bname,checked,groupid ");
			strSql.Append(" FROM phome_enewsgbookclass ");
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
			parameters[0].Value = "phome_enewsgbookclass";
			parameters[1].Value = "bid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method











    }
}

