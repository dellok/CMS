using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Member;
using DBUtility;
using LL.Model.Member;
using System.Collections.Generic;
namespace LL.DAL.Member
{
    /// <summary>
    ///收藏夹分类
    /// </summary>
    public partial class DALphome_enewsfavaclass : Iphome_enewsfavaclass
    {
        public DALphome_enewsfavaclass()
        { }
        #region  Method
        public bool ExistsClassName(string cname, int userid, int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select count(*)  from phome_enewsfavaclass  where ");
            sql.AppendFormat("  cname ='{0}'", cname);
            if (userid > 0)
            {
                sql.AppendFormat(" and  userid={0}", userid);
            }
            if (id > 0)
            {
                sql.AppendFormat("  and  cid <>{0}", id);
            }
            object obj = DbHelperSQL.GetSingle(sql.ToString());
            if (obj != null)
            {
                return (int)obj > 0 ? true : false;
            }
            else
            {

                return false;
            }




        }

        public List<phome_enewsfavaclass> GetListByUserID(int userid)
        {
            string sql = string.Format(" select  *  from  phome_enewsfavaclass  where userid={0}", userid);

            List<phome_enewsfavaclass> arr = new List<phome_enewsfavaclass>();
            DataSet ds = DbHelperSQL.Query(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    arr.Add(GetModelByDataRow(item));
                }
            }

            return arr;
        }

        private phome_enewsfavaclass GetModelByDataRow(DataRow row)
        {
            phome_enewsfavaclass model = new phome_enewsfavaclass();
            if (row["cid"] != null && row["cid"].ToString() != "")
            {
                model.cid = int.Parse(row["cid"].ToString());
            }
            if (row["cname"] != null && row["cname"].ToString() != "")
            {
                model.cname = row["cname"].ToString();
            }
            if (row["userid"] != null && row["userid"].ToString() != "")
            {
                model.userid = int.Parse(row["userid"].ToString());
            }
            return model;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(phome_enewsfavaclass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into phome_enewsfavaclass(");
            strSql.Append("cname,userid)");
            strSql.Append(" values (");
            strSql.Append("@cname,@userid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,90),
					new SqlParameter("@userid", SqlDbType.Int,4)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.userid;

            return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(int cid, string cname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update phome_enewsfavaclass set ");
            strSql.Append("cname=@cname,");
            strSql.Append(" where cid=@cid");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,90),
		
					new SqlParameter("@cid", SqlDbType.Int,4)};
            parameters[0].Value = cname;

            parameters[1].Value = cid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        
        }
        public int Update(phome_enewsfavaclass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update phome_enewsfavaclass set ");
            strSql.Append("cname=@cname,");
            strSql.Append("userid=@userid");
            strSql.Append(" where cid=@cid");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,90),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.cid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        public int Delete(int id, int userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_enewsfavaclass ");
            strSql.AppendFormat(" where cid={0}", id);
            if (userid > 0)
            {
                strSql.AppendFormat(" and  userid={0}", userid);
            }
            return DbHelperSQL.ExecuteSql(strSql.ToString());

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int cid)
        {
            return Delete(cid, 0);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string cidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_enewsfavaclass ");
            strSql.Append(" where cid in (" + cidlist + ")  ");
            return DbHelperSQL.ExecuteSql(strSql.ToString());

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public phome_enewsfavaclass GetModel(int cid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 cid,cname,userid from phome_enewsfavaclass ");
            strSql.Append(" where cid=@cid");
            SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)
};
            parameters[0].Value = cid;

            phome_enewsfavaclass model = new phome_enewsfavaclass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cid,cname,userid ");
            strSql.Append(" FROM phome_enewsfavaclass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" cid,cname,userid ");
            strSql.Append(" FROM phome_enewsfavaclass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  Method



    }
}

