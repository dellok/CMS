using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Member;
using  DBUtility;
using LL.Model.Member;
using Project.Common;
namespace LL.DAL.Member
{
	/// <summary>
	///留言
	/// </summary>
	public partial class DALphome_enewsgbook:Iphome_enewsgbook
	{
		public DALphome_enewsgbook()
		{}
		#region  Method

		


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(phome_enewsgbook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsgbook(");
			strSql.Append("name,email,call,lytime,lytext,retext,bid,ip,checked,userid,username)");
			strSql.Append(" values (");
			strSql.Append("@name,@email,@call,@lytime,@lytext,@retext,@bid,@ip,@checked,@userid,@username)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,90),
					new SqlParameter("@email", SqlDbType.NVarChar,240),
					new SqlParameter("@call", SqlDbType.NVarChar,90),
					new SqlParameter("@lytime", SqlDbType.DateTime),
					new SqlParameter("@lytext", SqlDbType.NVarChar),
					new SqlParameter("@retext", SqlDbType.NVarChar),
					new SqlParameter("@bid", SqlDbType.Int,4),
					new SqlParameter("@ip", SqlDbType.NVarChar,60),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,90)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.email;
			parameters[2].Value = model.call;
			parameters[3].Value = model.lytime;
			parameters[4].Value = model.lytext;
			parameters[5].Value = model.retext;
			parameters[6].Value = model.bid;
			parameters[7].Value = model.ip;
			parameters[8].Value = model.@checked;
            parameters[9].Value = model.userid;
            parameters[10].Value = model.username;

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
		public int Update(phome_enewsgbook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsgbook set ");
			strSql.Append("name=@name,");
			strSql.Append("email=@email,");
			strSql.Append("call=@call,");
			strSql.Append("lytime=@lytime,");
			strSql.Append("lytext=@lytext,");
			strSql.Append("retext=@retext,");
			strSql.Append("bid=@bid,");
			strSql.Append("ip=@ip,");
			strSql.Append("checked=@checked,");
			strSql.Append("userid=@userid,");
			strSql.Append("username=@username");
			strSql.Append(" where lyid=@lyid");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,90),
					new SqlParameter("@email", SqlDbType.NVarChar,240),
					new SqlParameter("@call", SqlDbType.NVarChar,90),
					new SqlParameter("@lytime", SqlDbType.DateTime),
					new SqlParameter("@lytext", SqlDbType.NVarChar),
					new SqlParameter("@retext", SqlDbType.NVarChar),
					new SqlParameter("@bid", SqlDbType.Int,4),
					new SqlParameter("@ip", SqlDbType.NVarChar,60),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,90),
					new SqlParameter("@lyid", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.email;
			parameters[2].Value = model.call;
			parameters[3].Value = model.lytime;
			parameters[4].Value = model.lytext;
			parameters[5].Value = model.retext;
			parameters[6].Value = model.bid;
			parameters[7].Value = model.ip;
			parameters[8].Value = model.@checked;
			parameters[9].Value = model.userid;
			parameters[10].Value = model.username;
			parameters[11].Value = model.lyid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			return rows;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int lyid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsgbook ");
			strSql.Append(" where lyid=@lyid");
			SqlParameter[] parameters = {
					new SqlParameter("@lyid", SqlDbType.Int,4)
};
			parameters[0].Value = lyid;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public int DeleteList(string lyidlist )
		{
            return DeleteList(lyidlist,"");
			
		}
        public int DeleteList(string lyidlist,string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_enewsgbook ");
            strSql.Append(" where lyid in (" + lyidlist + ")  ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.AppendFormat(" and {0}", Util.FilterStartAndEndSign(where,"and"));
            }
            return DbHelperSQL.ExecuteSql(strSql.ToString());

        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public phome_enewsgbook GetModel(int lyid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 lyid,name,email,call,lytime,lytext,retext,bid,ip,checked,userid,username from phome_enewsgbook ");
			strSql.Append(" where lyid=@lyid");
			SqlParameter[] parameters = {
					new SqlParameter("@lyid", SqlDbType.Int,4)
};
			parameters[0].Value = lyid;

			phome_enewsgbook model=new phome_enewsgbook();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
                return GetModelByDataRow(ds.Tables[0].Rows[0]);
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
			strSql.Append("select lyid,name,email,call,lytime,lytext,retext,bid,ip,checked,userid,username ");
			strSql.Append(" FROM phome_enewsgbook ");
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
			strSql.Append(" lyid,name,email,call,lytime,lytext,retext,bid,ip,checked,userid,username ");
			strSql.Append(" FROM phome_enewsgbook ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

	

		#endregion  Method


        public phome_enewsgbook GetModelByDataRow(DataRow row)
        {
            phome_enewsgbook model = new phome_enewsgbook();
            if (row["lyid"] != null && row["lyid"].ToString() != "")
            {
                model.lyid = int.Parse(row["lyid"].ToString());
            }
            if (row["name"] != null && row["name"].ToString() != "")
            {
                model.name = row["name"].ToString();
            }
            if (row["email"] != null && row["email"].ToString() != "")
            {
                model.email = row["email"].ToString();
            }
            if (row["call"] != null && row["call"].ToString() != "")
            {
                model.call = row["call"].ToString();
            }
            if (row["lytime"] != null && row["lytime"].ToString() != "")
            {
                model.lytime = DateTime.Parse(row["lytime"].ToString());
            }
            if (row["lytext"] != null && row["lytext"].ToString() != "")
            {
                model.lytext = row["lytext"].ToString();
            }
            if (row["retext"] != null && row["retext"].ToString() != "")
            {
                model.retext = row["retext"].ToString();
            }
            if (row["bid"] != null && row["bid"].ToString() != "")
            {
                model.bid = int.Parse(row["bid"].ToString());
            }
            if (row["ip"] != null && row["ip"].ToString() != "")
            {
                model.ip = row["ip"].ToString();
            }
            if (row["checked"] != null && row["checked"].ToString() != "")
            {
                model.@checked = int.Parse(row["checked"].ToString());
            }
            if (row["userid"] != null && row["userid"].ToString() != "")
            {
                model.userid = int.Parse(row["userid"].ToString());
            }
            if (row["username"] != null && row["username"].ToString() != "")
            {
                model.username = row["username"].ToString();
            }
            return model;
        }

        public DataSet GetList(int PageIndex, int PageSize, string strWhere, string orderby)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select b.*,m.username  from  phome_enewsgbook  b inner join   phome_enewsmember m  on b.userid=m.userid ");
            strSql.Append(IPager.SetSqlWhere(strWhere));
            IPager pager = new IPager();
            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "fid";

            if (!string.IsNullOrEmpty(orderby))
            {
                pager.OrderBy = orderby;
            }
            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;

            return pager.GetResult();
        }
    }
}

