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
	/// 反馈
	/// </summary>
	public partial class DALphome_enewsmemberfeedback:Iphome_enewsmemberfeedback
	{
		public DALphome_enewsmemberfeedback()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(phome_enewsmemberfeedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsmemberfeedback(");
			strSql.Append("fid,name,company,phone,fax,email,address,zip,title,ftext,userid,ip,uid,uname,addtime)");
			strSql.Append(" values (");
			strSql.Append("@fid,@name,@company,@phone,@fax,@email,@address,@zip,@title,@ftext,@userid,@ip,@uid,@uname,@addtime)");
			SqlParameter[] parameters = {
					new SqlParameter("@fid", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,36),
					new SqlParameter("@company", SqlDbType.NVarChar,240),
					new SqlParameter("@phone", SqlDbType.NVarChar,90),
					new SqlParameter("@fax", SqlDbType.NVarChar,60),
					new SqlParameter("@email", SqlDbType.NVarChar,240),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@zip", SqlDbType.NVarChar,24),
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@ftext", SqlDbType.NVarChar),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@ip", SqlDbType.NVarChar,45),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@uname", SqlDbType.NVarChar,90),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
			parameters[0].Value = model.fid;
			parameters[1].Value = model.name;
			parameters[2].Value = model.company;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.fax;
			parameters[5].Value = model.email;
			parameters[6].Value = model.address;
			parameters[7].Value = model.zip;
			parameters[8].Value = model.title;
			parameters[9].Value = model.ftext;
			parameters[10].Value = model.userid;
			parameters[11].Value = model.ip;
			parameters[12].Value = model.uid;
			parameters[13].Value = model.uname;
			parameters[14].Value = model.addtime;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(phome_enewsmemberfeedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsmemberfeedback set ");
			strSql.Append("name=@name,");
			strSql.Append("company=@company,");
			strSql.Append("phone=@phone,");
			strSql.Append("fax=@fax,");
			strSql.Append("email=@email,");
			strSql.Append("address=@address,");
			strSql.Append("zip=@zip,");
			strSql.Append("title=@title,");
			strSql.Append("ftext=@ftext,");
			strSql.Append("userid=@userid,");
			strSql.Append("ip=@ip,");
			strSql.Append("uid=@uid,");
			strSql.Append("uname=@uname,");
			strSql.Append("addtime=@addtime");
			strSql.Append(" where ");
            strSql.Append("fid=@fid");
			SqlParameter[] parameters = {
					new SqlParameter("@fid", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,36),
					new SqlParameter("@company", SqlDbType.NVarChar,240),
					new SqlParameter("@phone", SqlDbType.NVarChar,90),
					new SqlParameter("@fax", SqlDbType.NVarChar,60),
					new SqlParameter("@email", SqlDbType.NVarChar,240),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@zip", SqlDbType.NVarChar,24),
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@ftext", SqlDbType.NVarChar),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@ip", SqlDbType.NVarChar,45),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@uname", SqlDbType.NVarChar,90),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
			parameters[0].Value = model.fid;
			parameters[1].Value = model.name;
			parameters[2].Value = model.company;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.fax;
			parameters[5].Value = model.email;
			parameters[6].Value = model.address;
			parameters[7].Value = model.zip;
			parameters[8].Value = model.title;
			parameters[9].Value = model.ftext;
			parameters[10].Value = model.userid;
			parameters[11].Value = model.ip;
			parameters[12].Value = model.uid;
			parameters[13].Value = model.uname;
			parameters[14].Value = model.addtime;

			 return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int fid)
		{
		
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsmemberfeedback ");
            strSql.AppendFormat(" where  fid={0}", fid);
		
		return DbHelperSQL.ExecuteSql(strSql.ToString());
			
		}

        public int DeleteAll(string  arrfid)
        {

            return DeleteAll(arrfid,0);
        }
	
		public phome_enewsmemberfeedback GetModel(int fid)
		{
           return  GetModel(fid,0);
		}

	
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select fid,name,company,phone,fax,email,address,zip,title,ftext,userid,ip,uid,uname,addtime ");
			strSql.Append(" FROM phome_enewsmemberfeedback ");
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
			strSql.Append(" fid,name,company,phone,fax,email,address,zip,title,ftext,userid,ip,uid,uname,addtime ");
			strSql.Append(" FROM phome_enewsmemberfeedback ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method

        public phome_enewsmemberfeedback GetModelByDataRow(DataRow row)
        {
            phome_enewsmemberfeedback model = new phome_enewsmemberfeedback();
            if (row["fid"] != null && row["fid"].ToString() != "")
            {
                model.fid = int.Parse(row["fid"].ToString());
            }
            if (row["name"] != null && row["name"].ToString() != "")
            {
                model.name = row["name"].ToString();
            }
            if (row["company"] != null && row["company"].ToString() != "")
            {
                model.company = row["company"].ToString();
            }
            if (row["phone"] != null && row["phone"].ToString() != "")
            {
                model.phone = row["phone"].ToString();
            }
            if (row["fax"] != null && row["fax"].ToString() != "")
            {
                model.fax = row["fax"].ToString();
            }
            if (row["email"] != null && row["email"].ToString() != "")
            {
                model.email = row["email"].ToString();
            }
            if (row["address"] != null && row["address"].ToString() != "")
            {
                model.address = row["address"].ToString();
            }
            if (row["zip"] != null && row["zip"].ToString() != "")
            {
                model.zip = row["zip"].ToString();
            }
            if (row["title"] != null && row["title"].ToString() != "")
            {
                model.title = row["title"].ToString();
            }
            if (row["ftext"] != null && row["ftext"].ToString() != "")
            {
                model.ftext = row["ftext"].ToString();
            }
            if (row["userid"] != null && row["userid"].ToString() != "")
            {
                model.userid = int.Parse(row["userid"].ToString());
            }
            if (row["ip"] != null && row["ip"].ToString() != "")
            {
                model.ip = row["ip"].ToString();
            }
            if (row["uid"] != null && row["uid"].ToString() != "")
            {
                model.uid = int.Parse(row["uid"].ToString());
            }
            if (row["uname"] != null && row["uname"].ToString() != "")
            {
                model.uname = row["uname"].ToString();
            }
            if (row["addtime"] != null && row["addtime"].ToString() != "")
            {
                model.addtime = DateTime.Parse(row["addtime"].ToString());
            }
            return model;
        }




        public DataSet GetList(int pageindex, int pagesize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select m.*,t.username as spacename from  phome_enewsmemberfeedback m left join phome_enewsmember t on m.userid=t.userid");
            strSql.Append(IPager.SetSqlWhere(strWhere));




            IPager pager = new IPager();
            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "fid";
             pager.OrderBy = orderby;
          
            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;

            return pager.GetResult();
        }




        public int DeleteAll(string ids, int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_enewsmemberfeedback ");
            strSql.AppendFormat(" where  fid in {0}", ids);
            if (userid > 0)
            {
                strSql.AppendFormat(" and  userid={0}", userid);
            }
            return DbHelperSQL.ExecuteSql(strSql.ToString());

        }

        public phome_enewsmemberfeedback GetModel(int fid, int userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 fid,name,company,phone,fax,email,address,zip,title,ftext,userid,ip,uid,uname,addtime from phome_enewsmemberfeedback ");
            strSql.AppendFormat(" where  fid={0}", fid);
            if (userid>0)
            {
              strSql.AppendFormat(" and  userid={0}", userid);  
            }

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetModelByDataRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}

