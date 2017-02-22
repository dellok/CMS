using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using LL.IDAL.Member;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using LL.Model.Member;


namespace LL.DAL.Member
{
    public class DALphome_enewsmembergroup:Iphome_enewsmembergroup
    {



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(phome_enewsmembergroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsmembergroup(");
			strSql.Append("groupname,level,checked,favanum,daydown,msglen,msgnum,canreg,formid,regchecked,spacestyleid)");
			strSql.Append(" values (");
			strSql.Append("@groupname,@level,@checked,@favanum,@daydown,@msglen,@msgnum,@canreg,@formid,@regchecked,@spacestyleid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@groupname", SqlDbType.NVarChar,180),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@favanum", SqlDbType.Int,4),
					new SqlParameter("@daydown", SqlDbType.Int,4),
					new SqlParameter("@msglen", SqlDbType.Int,4),
					new SqlParameter("@msgnum", SqlDbType.Int,4),
					new SqlParameter("@canreg", SqlDbType.Int,4),
					new SqlParameter("@formid", SqlDbType.Int,4),
					new SqlParameter("@regchecked", SqlDbType.Int,4),
					new SqlParameter("@spacestyleid", SqlDbType.Int,4)};
			parameters[0].Value = model.groupname;
			parameters[1].Value = model.level;
			parameters[2].Value = model.@checked;
			parameters[3].Value = model.favanum;
			parameters[4].Value = model.daydown;
			parameters[5].Value = model.msglen;
			parameters[6].Value = model.msgnum;
			parameters[7].Value = model.canreg;
			parameters[8].Value = model.formid;
			parameters[9].Value = model.regchecked;
			parameters[10].Value = model.spacestyleid;

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
        public int  Update(phome_enewsmembergroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsmembergroup set ");
			strSql.Append("groupname=@groupname,");
			strSql.Append("level=@level,");
			strSql.Append("checked=@checked,");
			strSql.Append("favanum=@favanum,");
			strSql.Append("daydown=@daydown,");
			strSql.Append("msglen=@msglen,");
			strSql.Append("msgnum=@msgnum,");
			strSql.Append("canreg=@canreg,");
			strSql.Append("formid=@formid,");
			strSql.Append("regchecked=@regchecked,");
			strSql.Append("spacestyleid=@spacestyleid");
			strSql.Append(" where groupid=@groupid");
			SqlParameter[] parameters = {
					new SqlParameter("@groupname", SqlDbType.NVarChar,180),
					new SqlParameter("@level", SqlDbType.Int,4),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@favanum", SqlDbType.Int,4),
					new SqlParameter("@daydown", SqlDbType.Int,4),
					new SqlParameter("@msglen", SqlDbType.Int,4),
					new SqlParameter("@msgnum", SqlDbType.Int,4),
					new SqlParameter("@canreg", SqlDbType.Int,4),
					new SqlParameter("@formid", SqlDbType.Int,4),
					new SqlParameter("@regchecked", SqlDbType.Int,4),
					new SqlParameter("@spacestyleid", SqlDbType.Int,4),
					new SqlParameter("@groupid", SqlDbType.Int,4)};
			parameters[0].Value = model.groupname;
			parameters[1].Value = model.level;
			parameters[2].Value = model.@checked;
			parameters[3].Value = model.favanum;
			parameters[4].Value = model.daydown;
			parameters[5].Value = model.msglen;
			parameters[6].Value = model.msgnum;
			parameters[7].Value = model.canreg;
			parameters[8].Value = model.formid;
			parameters[9].Value = model.regchecked;
			parameters[10].Value = model.spacestyleid;
			parameters[11].Value = model.groupid;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int groupid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_enewsmembergroup ");
            strSql.Append(" where groupid=@groupid");
            SqlParameter[] parameters = {
					new SqlParameter("@groupid", SqlDbType.Int,4)
};
            parameters[0].Value = groupid;

           return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        
        }
    

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public phome_enewsmembergroup GetModel(int groupid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 groupid,groupname,level,checked,favanum,daydown,msglen,msgnum,canreg,formid,regchecked,spacestyleid from phome_enewsmembergroup ");
			strSql.Append(" where groupid=@groupid");
			SqlParameter[] parameters = {
					new SqlParameter("@groupid", SqlDbType.Int,4)
};
			parameters[0].Value = groupid;

		
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



        public phome_enewsmembergroup GetModelByDataRow(DataRow row)
        {
            phome_enewsmembergroup model = new phome_enewsmembergroup();
            if (row["groupid"] != null && row["groupid"].ToString() != "")
            {
                model.groupid = int.Parse(row["groupid"].ToString());
            }
            if (row["groupname"] != null && row["groupname"].ToString() != "")
            {
                model.groupname = row["groupname"].ToString();
            }
            if (row["level"] != null && row["level"].ToString() != "")
            {
                model.level = int.Parse(row["level"].ToString());
            }
            if (row["checked"] != null && row["checked"].ToString() != "")
            {
                model.@checked = int.Parse(row["checked"].ToString());
            }
            if (row["favanum"] != null && row["favanum"].ToString() != "")
            {
                model.favanum = int.Parse(row["favanum"].ToString());
            }
            if (row["daydown"] != null && row["daydown"].ToString() != "")
            {
                model.daydown = int.Parse(row["daydown"].ToString());
            }
            if (row["msglen"] != null && row["msglen"].ToString() != "")
            {
                model.msglen = int.Parse(row["msglen"].ToString());
            }
            if (row["msgnum"] != null && row["msgnum"].ToString() != "")
            {
                model.msgnum = int.Parse(row["msgnum"].ToString());
            }
            if (row["canreg"] != null && row["canreg"].ToString() != "")
            {
                model.canreg = int.Parse(row["canreg"].ToString());
            }
            if (row["formid"] != null && row["formid"].ToString() != "")
            {
                model.formid = int.Parse(row["formid"].ToString());
            }
            if (row["regchecked"] != null && row["regchecked"].ToString() != "")
            {
                model.regchecked = int.Parse(row["regchecked"].ToString());
            }
            if (row["spacestyleid"] != null && row["spacestyleid"].ToString() != "")
            {
                model.spacestyleid = int.Parse(row["spacestyleid"].ToString());
            }
            return model;
        }
       

        public List<phome_enewsmembergroup> GetAllList()
        {

            List<phome_enewsmembergroup> arr = new List<phome_enewsmembergroup>();
            string sql = "select *  from phome_enewsmembergroup";

            DataSet ds = DbHelperSQL.Query(sql);
            foreach (DataRow  item in ds.Tables[0].Rows)
            {
                arr.Add(GetModelByDataRow(item));
            }
            return arr;
        
        }





    }
}
