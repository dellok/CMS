using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Temp;
using DBUtility;
using LL.Model.Temp;
using System.Collections.Generic;
using LL.Model;

namespace LL.DAL.Temp
{
    public partial class DALTempItem : Repository<IAggregateRoot>,ITempItem
    {
        public DALTempItem()
        { }
        #region  Method


        /// <summary>
        /// id>0 ,为修改判断，

        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsName(string name, int id)
        {
            string sql = string.Format(" select count(*) from  TempItem  where name='{0}'", name);
            if (id > 0)
            {
                sql += string.Format(" and id<>{0}", id);
            }

            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                return (int)obj > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TempItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TempItem(");
            strSql.Append("Name,Url,IsCreateStaticPage,ADPageName,TempType,TempText)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Url,@IsCreateStaticPage,@ADPageName,@TempType,@TempText)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,300),
					new SqlParameter("@IsCreateStaticPage", SqlDbType.Bit,1),
                    new SqlParameter("@ADPageName", SqlDbType.VarChar,300),    
                         new SqlParameter("@TempType", SqlDbType.Int),
                    new SqlParameter("@TempText", SqlDbType.Text)
                                        };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.IsCreateStaticPage;
            parameters[3].Value = model.ADPageName;
            parameters[4].Value = model.TempType;
            parameters[5].Value = model.TempText;

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
        public int Update(TempItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TempItem set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Url=@Url,");
            strSql.Append("IsCreateStaticPage=@IsCreateStaticPage,");
            strSql.Append("TempType=@TempType,");
            strSql.Append("TempText=@TempText");

            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Url", SqlDbType.VarChar,300),
					new SqlParameter("@IsCreateStaticPage", SqlDbType.Bit,1),
                    new SqlParameter("@TempType", SqlDbType.Int),
                    new SqlParameter("@TempText", SqlDbType.Text),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.IsCreateStaticPage;
            parameters[3].Value = model.TempType;
            parameters[4].Value = model.TempText;
            parameters[5].Value = model.ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TempItem ");
            strSql.AppendFormat(" where ID={0}", ID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());

        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TempItem ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return DbHelperSQL.ExecuteSql(strSql.ToString());

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TempItem GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from TempItem ");
            strSql.AppendFormat(" where ID={0}", ID);

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

        public TempItem GetModelByDataRow(DataRow row)
        {
            TempItem model = new TempItem();
            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["Name"] != null && row["Name"].ToString() != "")
            {
                model.Name = row["Name"].ToString();
            }
            if (row["ADPageName"] != null && row["ADPageName"].ToString() != "")
            {
                model.ADPageName = row["ADPageName"].ToString();
            }
            if (row["Url"] != null && row["Url"].ToString() != "")
            {
                model.Url = row["Url"].ToString();
            }

            if (row["TempType"] != null && row["TempType"].ToString() != "")
            {
                model.TempType =int.Parse( row["TempType"].ToString());
            }

            if (row["TempText"] != null && row["TempText"].ToString() != "")
            {
                model.TempText = row["TempText"].ToString();
            }
            if (row["IsCreateStaticPage"] != null && row["IsCreateStaticPage"].ToString() != "")
            {
                if ((row["IsCreateStaticPage"].ToString() == "1") || (row["IsCreateStaticPage"].ToString().ToLower() == "true"))
                {
                    model.IsCreateStaticPage = true;
                }
                else
                {
                    model.IsCreateStaticPage = false;
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
            strSql.Append("select * ");
            strSql.Append(" FROM TempItem ");
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
            strSql.Append("* ");
            strSql.Append(" FROM TempItem ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  Method


        public List<TempItem> GetModelAll()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" * ");
            strSql.Append(" FROM TempItem ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            List<TempItem> arr = new List<TempItem>();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                arr.Add(GetModelByDataRow(item));
            }
            return arr;
        }

        public DataSet GetList(int pageindex, int pagesize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select * from  TempItem");
            strSql.Append(IPager.SetSqlWhere(strWhere));
            IPager pager = new IPager();
            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "ID";

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

