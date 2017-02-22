using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.Admin;
using DBUtility;
using Project.Common;
using System.Data.SqlClient;
using System.Data;
using LL.Model.Admin;
using LL.Model;

namespace LL.DAL.Admin
{
    public class DALAdminUser :Repository<IAggregateRoot>, IAdminUser
    {

        /// <summary>
        /// id>0 为修改时判断 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool ExistsLoginName(int ID, string LoginName)
        {
        
            string sql = string.Format("  select  count(*) from  AdminUser   where  loginname='{0}'",LoginName);
            if (ID > 0)
            {
                sql += string.Format(" and  id<>{0}", ID);
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
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool ExistsLoginName(string LoginName)
        {
            return this.ExistsLoginName(0, LoginName);
        }

        public int  Add(AdminUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdminUser(");
            strSql.Append("LoginName,Password,[Checked],NewsClass,InDate,StyleID,FileLevel,Remark,AdminRoleID,LastTime,LastIP,LoginNum)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@Password,@Checked,@NewsClass,@InDate,@StyleID,@FileLevel,@Remark,@AdminRoleID,@LastTime,@LastIP,@LoginNum)");
            SqlParameter[] parameters = {
			
					new SqlParameter("@LoginName", SqlDbType.VarChar,100),
					new SqlParameter("@Password", SqlDbType.VarChar,100),
					new SqlParameter("@Checked", SqlDbType.Bit,1),
					new SqlParameter("@NewsClass", SqlDbType.VarChar),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@StyleID", SqlDbType.Int,4),
					new SqlParameter("@FileLevel", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,500),
					new SqlParameter("@AdminRoleID", SqlDbType.Int,4),
					new SqlParameter("@LastTime", SqlDbType.DateTime),
					new SqlParameter("@LastIP", SqlDbType.VarChar,50),
					new SqlParameter("@LoginNum", SqlDbType.Int,4)};
    
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Checked;
            parameters[3].Value = model.NewsClass;
            parameters[4].Value = model.InDate;
            parameters[5].Value = model.StyleID;
            parameters[6].Value = model.FileLevel;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.AdminRoleID;
            parameters[9].Value = model.LastTime;
            parameters[10].Value = model.LastIP;
            parameters[11].Value = model.LoginNum;

          return   DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(AdminUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminUser set ");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("Password=@Password,");
            strSql.Append("[Checked]=@Checked,");
            strSql.Append("NewsClass=@NewsClass,");
            strSql.Append("InDate=@InDate,");
            strSql.Append("StyleID=@StyleID,");
            strSql.Append("FileLevel=@FileLevel,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("AdminRoleID=@AdminRoleID,");
            strSql.Append("LastTime=@LastTime,");
            strSql.Append("LastIP=@LastIP,");
            strSql.Append("LoginNum=@LoginNum");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,100),
					new SqlParameter("@Password", SqlDbType.VarChar,100),
					new SqlParameter("@Checked", SqlDbType.Bit,1),
					new SqlParameter("@NewsClass", SqlDbType.VarChar),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@StyleID", SqlDbType.Int,4),
					new SqlParameter("@FileLevel", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,500),
					new SqlParameter("@AdminRoleID", SqlDbType.Int,4),
					new SqlParameter("@LastTime", SqlDbType.DateTime),
					new SqlParameter("@LastIP", SqlDbType.VarChar,50),
					new SqlParameter("@LoginNum", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Checked;
            parameters[3].Value = model.NewsClass;
            parameters[4].Value = model.InDate;
            parameters[5].Value = model.StyleID;
            parameters[6].Value = model.FileLevel;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.AdminRoleID;
            parameters[9].Value = model.LastTime;
            parameters[10].Value = model.LastIP;
            parameters[11].Value = model.LoginNum;
            parameters[12].Value = model.ID;
            return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
           
        }

        /// <summary>
        /// 更改管理员密码
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
       public  int UpdatePwd(int uid, string pwd)
        {

            string sql = string.Format("  update   adminuser  set Password='{0}' where  id={1}", pwd, uid);

            return DbHelperSQL.ExecuteSql(sql);

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdminUser ");
            strSql.AppendFormat(" where ID={0}",ID);
          
            return  DbHelperSQL.ExecuteSql(strSql.ToString());
            
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdminUser ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public AdminUser GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *  from AdminUser ");
            strSql.AppendFormat(" where ID={0}",ID);
            
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
        private AdminUser GetModelByDataRow(DataRow row)
        {
              AdminUser model = new AdminUser();

            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["LoginName"] != null && row["LoginName"].ToString() != "")
            {
                model.LoginName = row["LoginName"].ToString();
            }
            if (row["Password"] != null && row["Password"].ToString() != "")
            {
                model.Password = row["Password"].ToString();
            }
            if (row["Checked"] != null && row["Checked"].ToString() != "")
            {
                if ((row["Checked"].ToString() == "1") || (row["Checked"].ToString().ToLower() == "true"))
                {
                    model.Checked = true;
                }
                else
                {
                    model.Checked = false;
                }
            }
            if (row["NewsClass"] != null && row["NewsClass"].ToString() != "")
            {
                model.NewsClass = row["NewsClass"].ToString();
            }
            if (row["InDate"] != null && row["InDate"].ToString() != "")
            {
                model.InDate = DateTime.Parse(row["InDate"].ToString());
            }
            if (row["StyleID"] != null && row["StyleID"].ToString() != "")
            {
                model.StyleID = int.Parse(row["StyleID"].ToString());
            }
            if (row["FileLevel"] != null && row["FileLevel"].ToString() != "")
            {
                model.FileLevel = int.Parse(row["FileLevel"].ToString());
            }
            if (row["Remark"] != null && row["Remark"].ToString() != "")
            {
                model.Remark = row["Remark"].ToString();
            }
            if (row["AdminRoleID"] != null && row["AdminRoleID"].ToString() != "")
            {
                model.AdminRoleID = int.Parse(row["AdminRoleID"].ToString());
            }
            if (row["LastTime"] != null && row["LastTime"].ToString() != "")
            {
                model.LastTime = DateTime.Parse(row["LastTime"].ToString());
            }
            if (row["LastIP"] != null && row["LastIP"].ToString() != "")
            {
                model.LastIP = row["LastIP"].ToString();
            }
            if (row["LoginNum"] != null && row["LoginNum"].ToString() != "")
            {
                model.LoginNum = int.Parse(row["LoginNum"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public AdminUser GetModelByNameAndPwd(string LoginName, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *  from AdminUser ");
            strSql.AppendFormat(" where LoginName='{0}' and Password='{1}'", LoginName,Password);
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
       public int  SetAdminChecked(int id, bool isChecked)
        {
            string sql = string.Format("update adminuser set checked={0} where id={1}", isChecked?1:0, id);
            return DBUtility.DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 得到全部信息
        /// </summary>
        /// <returns></returns>
        public List<AdminUser> GetModelAll()
        {
            List<AdminUser> arr = new List<AdminUser>();
            DataSet ds = GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    arr.Add(GetModelByDataRow(row));
                }
            }
            return arr;
        }


        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   *  from AdminUser ");
            strSql.Append(IPager.SetSqlWhere(strWhere));
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }
        public DataSet GetList(int pageindex, int pagesize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select * from  AdminUser");

            strSql.Append(IPager.SetSqlWhere(strWhere));
            IPager pager = new IPager();
            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "id";

            if (!string.IsNullOrEmpty(orderby))
            {
                pager.OrderBy = orderby;
            }
            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;

            return pager.GetResult();
        }



     
    }
}
