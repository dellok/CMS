using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.Admin;
using LL.Model.Admin;
using DBUtility;
using Project.Common;
using System.Data.SqlClient;
using System.Data;
using LL.Model;

namespace LL.DAL.Admin
{
   public  class DALAdminRole:Repository<IAggregateRoot>,IAdminRole
    {
       /// <summary>
       /// id>0 为修改时判断
       /// </summary>
       /// <param name="ID"></param>
       /// <param name="RoleName"></param>
       /// <returns></returns>
       public bool Exists(int ID, string RoleName)
       {
           string sql = string.Format("  select  count(*) from  AdminRole   where  RoleName='{0}'", RoleName);
           if (ID > 0)
           {
               sql += string.Format(" and  id={0}", ID);
           }
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
       /// <summary>
       /// 添加是判断  角色名是否存在
       /// </summary>
       /// <param name="RoleName"></param>
       /// <returns></returns>
       public bool Exists(string  RoleName)
       {
          return this.Exists(0, RoleName);
       }

       public int  Add(AdminRole model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into AdminRole(");
           strSql.Append("RoleName,InDate,Remark,Enabled)");
           strSql.Append(" values (");
           strSql.Append("@RoleName,@InDate,@Remark,@Enabled)");
           SqlParameter[] parameters = {
		
					new SqlParameter("@RoleName", SqlDbType.VarChar,100),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,300),
					new SqlParameter("@Enabled", SqlDbType.Bit,1)};
     
           parameters[0].Value = model.RoleName;
           parameters[1].Value = model.InDate;
           parameters[2].Value = model.Remark;
           parameters[3].Value = model.Enabled;

           return  DbHelperSQL.ExecuteSql(strSql.ToString());
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public int  Update(AdminRole model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update AdminRole set ");
           strSql.Append("RoleName=@RoleName,");
           strSql.Append("InDate=@InDate,");
           strSql.Append("Remark=@Remark,");
           strSql.Append("Enabled=@Enabled");
           strSql.Append(" where ID=@ID ");
           SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,100),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,300),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
           parameters[0].Value = model.RoleName;
           parameters[1].Value = model.InDate;
           parameters[2].Value = model.Remark;
           parameters[3].Value = model.Enabled;
           parameters[4].Value = model.ID;

          return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }
       /// <summary>
       /// 删除一条数据
       /// </summary>
       public int  Delete(int ID)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from AdminRole ");
           strSql.AppendFormat(" where ID={0} ",ID);

           return  DbHelperSQL.ExecuteSql(strSql.ToString());
         
       }
       /// <summary>
       /// 批量删除数据
       /// </summary>
       public int  DeleteList(string IDlist)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from AdminRole ");
           strSql.Append(" where ID in (" + IDlist + ")  ");
           return  DbHelperSQL.ExecuteSql(strSql.ToString());
          
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public AdminRole GetModel(int ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 ID,RoleName,InDate,Remark,Enabled from AdminRole ");
           strSql.AppendFormat(" where ID={0} ",ID);

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
       private AdminRole GetModelByDataRow(DataRow row)
       {
           AdminRole model = new AdminRole();


           if (row["ID"] != null && row["ID"].ToString() != "")
           {
               model.ID = int.Parse(row["ID"].ToString());
           }
           if (row["RoleName"] != null && row["RoleName"].ToString() != "")
           {
               model.RoleName = row["RoleName"].ToString();
           }
           if (row["InDate"] != null && row["InDate"].ToString() != "")
           {
               model.InDate = DateTime.Parse(row["InDate"].ToString());
           }
           if (row["Remark"] != null && row["Remark"].ToString() != "")
           {
               model.Remark = row["Remark"].ToString();
           }
           if (row["Enabled"] != null && row["Enabled"].ToString() != "")
           {
               if ((row["Enabled"].ToString() == "1") || (row["Enabled"].ToString().ToLower() == "true"))
               {
                   model.Enabled = true;
               }
               else
               {
                   model.Enabled = false;
               }
           }
           return model;
       }



       public List<AdminRole> GetModelAll()
       {
           List<AdminRole> arr = new List<AdminRole>();
           DataSet ds = GetList("");
           if (ds.Tables[0].Rows.Count > 0)
           {
               foreach (DataRow  item in  ds.Tables[0].Rows)
               {
                   arr.Add(GetModelByDataRow(item));
               }
             
           }

           return arr;
       }

       public DataSet GetList(string strWhere)
       {
           string sql = string.Format(" select *  from  AdminRole ");
           sql += IPager.SetSqlWhere(strWhere);
           DataSet ds = DbHelperSQL.Query(sql);
           return ds;
       }

       public DataSet GetList(int pageindex, int pagesize, string where, string orderby)
       {
           throw new NotImplementedException();
       }
    }
}
