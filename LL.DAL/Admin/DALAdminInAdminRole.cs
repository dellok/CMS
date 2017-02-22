using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.Admin;
using LL.Model.Admin;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
using Project.Common;
using LL.Model;

namespace LL.DAL.Admin
{
    public class DALAdminInAdminRole :Repository<IAggregateRoot> ,IAdminInAdminRole
    {   /// <summary>
        /// 是否角色已添加
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public bool Exists(int AdminUserID, int AdminRoleID)
        {
            string sql = string.Format(" select count(*)  from  AdminInAdminRole  where  AdminUserID={0} and AdminRoleID={1}", AdminUserID, AdminRoleID);
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                return Format.DataConvertToInt(obj) > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }
        public int Add(AdminInAdminRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdminInAdminRole(");
            strSql.Append("AdminUserID,AdminRoleID)");
            strSql.Append(" values (");
            strSql.Append("@AdminUserID,@AdminRoleID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminUserID", SqlDbType.Int,4),
					new SqlParameter("@AdminRoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.AdminUserID;
            parameters[1].Value = model.AdminRoleID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public int Update(AdminInAdminRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminInAdminRole set ");
            strSql.Append("AdminUserID=@AdminUserID,");
            strSql.Append("AdminRoleID=@AdminRoleID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminUserID", SqlDbType.Int,4),
					new SqlParameter("@AdminRoleID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.AdminUserID;
            parameters[1].Value = model.AdminRoleID;
            parameters[2].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString());

        }

        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdminInAdminRole ");
            strSql.AppendFormat(" where ID={0}", ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        public AdminInAdminRole GetModel(int id)
        {
            string sql = string.Format("  select  *    from AdminInAdminRole   from id={0} ",id);
            DataSet ds = DbHelperSQL.Query(sql);
            if(ds.Tables[0].Rows.Count>0) {  return GetModelByDataRow(ds.Tables[0].Rows[0]); } else { return null;}

        }
        public List<AdminInAdminRole> GetModelAll()
        {
            List<AdminInAdminRole> arr = new List<AdminInAdminRole>();

            DataSet ds = GetList("");
           
            foreach (DataRow  item in ds.Tables[0].Rows)
            {
                arr.Add(GetModelByDataRow(ds.Tables[0].Rows[0]));
            }

            return arr;
           
        }

        public DataSet GetList(string strWhere)
        {
            string sql = string.Format("  select  *    from AdminInAdminRole  ");
            sql += IPager.SetSqlWhere(strWhere);
            DataSet ds = DbHelperSQL.Query(sql);
            return ds;
           
        }

        public DataSet GetList(int pageindex, int pagesize, string where, string orderby)
        {
            throw new NotImplementedException();
        }


        public AdminInAdminRole GetModelByDataRow(DataRow row)
        {
            AdminInAdminRole model = new AdminInAdminRole();
            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["AdminUserID"] != null && row["AdminUserID"].ToString() != "")
            {
                model.AdminUserID = int.Parse(row["AdminUserID"].ToString());
            }
            if (row["AdminRoleID"] != null && row["AdminRoleID"].ToString() != "")
            {
                model.AdminRoleID = int.Parse(row["AdminRoleID"].ToString());
            }
            return model;
        }
    }
}
