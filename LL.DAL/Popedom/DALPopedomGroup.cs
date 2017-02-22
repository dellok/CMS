using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using LL.IDAL.Popedom;
using Project.Common;
using System.Data.SqlClient;
using LL.Model.Popedom;
using LL.Model;

namespace LL.DAL.Popedom
{
   public  class  DALPopedomGroup:Repository<IAggregateRoot>, IPopedomGroup
    {
       
        /// <summary>
        /// 判断组名
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public bool Exist(int ID, string GroupName)
        {
            


            string sql = string.Format(" select count(*) from PopedomGroup where  id={0} and name='{1}' ",ID,GroupName);

            object obj = DbHelperSQL.GetSingle(sql);

            if (obj != null)
            {

                return  Format.DataConvertToInt(obj)>0?true:false;
            }
            else
            {

                return false;
            }



        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PopedomGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PopedomGroup(");
            strSql.Append("Name,Remark,[order],IsShow)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Remark,@Order,@IsShow)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@Order", SqlDbType.Int,4),
					new SqlParameter("@IsShow", SqlDbType.Bit,1)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.Order;
            parameters[3].Value = model.IsShow;

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
        public int  Update(PopedomGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PopedomGroup set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("[Order]=@Order,");
            strSql.Append("IsShow=@IsShow");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@Order", SqlDbType.Int,4),
					new SqlParameter("@IsShow", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.Order;
            parameters[3].Value = model.IsShow;
            parameters[4].Value = model.ID;

            return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
          
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PopedomGroup ");
            strSql.AppendFormat(" where ID={0}",ID);

            return  DbHelperSQL.ExecuteSql(strSql.ToString());
         
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int  DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PopedomGroup ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
        return  DbHelperSQL.ExecuteSql(strSql.ToString());

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PopedomGroup GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *  from PopedomGroup ");
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

        public PopedomGroup GetModelByDataRow(DataRow row)
        {
           PopedomGroup model = new PopedomGroup();
            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["Name"] != null && row["Name"].ToString() != "")
            {
                model.Name = row["Name"].ToString();
            }
            if (row["Remark"] != null && row["Remark"].ToString() != "")
            {
                model.Remark = row["Remark"].ToString();
            }
            if (row["Order"] != null && row["Order"].ToString() != "")
            {
                model.Order = int.Parse(row["Order"].ToString());
            }
            if (row["IsShow"] != null && row["IsShow"].ToString() != "")
            {
                if ((row["IsShow"].ToString() == "1") || (row["IsShow"].ToString().ToLower() == "true"))
                {
                    model.IsShow = true;
                }
                else
                {
                    model.IsShow = false;
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
            strSql.Append("select *  ");
            strSql.Append(" FROM PopedomGroup ");
            strSql.Append(IPager.SetSqlWhere(strWhere));
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
            strSql.Append(" * ");
            strSql.Append(" FROM PopedomGroup ");
            strSql.Append(IPager.SetSqlWhere(strWhere));
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



        public List<PopedomGroup> GetModelAll()
        {
            List<PopedomGroup> arr = new List<PopedomGroup>();
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
            strSql.Append(" FROM PopedomGroup ");
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
