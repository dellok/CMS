using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using LL.IDAL.Popedom;
using System.Data.SqlClient;
using LL.Model.Popedom;
using DBUtility;
using Project.Common;
using LL.Model;

namespace LL.DAL.Popedom
{
    public class DALPopedomFun :Repository<IAggregateRoot>, IPopedomFun
    {
        /// <summary>
        /// 是否功能源相同
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public bool Exist(int ID, string Url)
        {
            string sql = string.Format("select count(*) from   popedomfun  where url='{0}'",Url);
            if (ID > 0)
            {
                sql+=string.Format(" and  id={0}",ID);
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
        ///<summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PopedomFun model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PopedomFun(");
            strSql.Append("Name,Url,PopedomGroupID,showInMenu)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Url,@PopedomGroupID,@showInMenu)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,200),
					new SqlParameter("@PopedomGroupID", SqlDbType.Int,4),
					new SqlParameter("@showInMenu", SqlDbType.Bit,1)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.PopedomGroupID;
            parameters[3].Value = model.showInMenu;

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
        public int  Update(PopedomFun model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PopedomFun set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Url=@Url,");
            strSql.Append("PopedomGroupID=@PopedomGroupID,");
            strSql.Append("showInMenu=@showInMenu");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,200),
					new SqlParameter("@PopedomGroupID", SqlDbType.Int,4),
					new SqlParameter("@showInMenu", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.PopedomGroupID;
            parameters[3].Value = model.showInMenu;
            parameters[4].Value = model.ID;

            return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
           
        }


        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PopedomFun ");
            strSql.AppendFormat(" where ID={0}",ID);
            return  DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PopedomFun ");
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
        public PopedomFun GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Url,PopedomGroupID,showInMenu from PopedomFun ");
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

        private PopedomFun GetModelByDataRow(DataRow row )
        {
            PopedomFun model = new PopedomFun();
            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["Name"] != null && row["Name"].ToString() != "")
            {
                model.Name = row["Name"].ToString();
            }
            if (row["Url"] != null && row["Url"].ToString() != "")
            {
                model.Url = row["Url"].ToString();
            }
            if (row["PopedomGroupID"] != null && row["PopedomGroupID"].ToString() != "")
            {
                model.PopedomGroupID = int.Parse(row["PopedomGroupID"].ToString());
            }
            if (row["showInMenu"] != null && row["showInMenu"].ToString() != "")
            {
                if ((row["showInMenu"].ToString() == "1") || (row["showInMenu"].ToString().ToLower() == "true"))
                {
                    model.showInMenu = true;
                }
                else
                {
                    model.showInMenu = false;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Name,Url,PopedomGroupID,showInMenu ");
            strSql.Append(" FROM PopedomFun ");
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
            strSql.Append(" ID,Name,Url,PopedomGroupID,showInMenu ");
            strSql.Append(" FROM PopedomFun ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        public List<PopedomFun> GetModelAll()
        {
            List<PopedomFun> arr = new List<PopedomFun>();
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

        public DataSet GetList(int pageindex, int pagesize, string where, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" * ");
            strSql.Append(" FROM PopedomFun ");
            strSql.Append(IPager.SetSqlWhere(where));


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
