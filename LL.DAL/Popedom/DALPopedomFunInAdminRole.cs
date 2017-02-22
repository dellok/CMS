using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using LL.IDAL.Popedom;
using DBUtility;
using LL.Model.Popedom;
using System.Data.SqlClient;
using LL.Model;

namespace LL.DAL.Popedom
{
    public class DALPopedomFunInAdminRole :Repository<IAggregateRoot>,IPopedomFunInAdminRole
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exist(int PopedomRoleID, int PopedomFunID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PopedomFunInAdminRole");
            strSql.Append(" where PopedomRoleID={0} and PopedomFunID={1} ", PopedomRoleID, PopedomFunID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
       
        public DataSet GetList(int pageindex, int pagesize, string where, string orderby)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PopedomFunInAdminRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PopedomFunInAdminRole(");
            strSql.Append("PopedomRoleID,PopedomFunID)");
            strSql.Append(" values (");
            strSql.Append("@PopedomRoleID,@PopedomFunID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PopedomRoleID", SqlDbType.Int,4),
					new SqlParameter("@PopedomFunID", SqlDbType.Int,4)};
            parameters[0].Value = model.PopedomRoleID;
            parameters[1].Value = model.PopedomFunID;

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


        public int Update(PopedomFunInAdminRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PopedomFunInAdminRole set ");
            strSql.Append("PopedomRoleID=@PopedomRoleID,");
            strSql.Append("PopedomFunID=@PopedomFunID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@PopedomRoleID", SqlDbType.Int,4),
					new SqlParameter("@PopedomFunID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PopedomRoleID;
            parameters[2].Value = model.PopedomFunID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PopedomFunInAdminRole ");
            strSql.AppendFormat(" where ID={0}", ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int PopedomRoleID, int PopedomFunID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PopedomFunInAdminRole ");
            strSql.Append(" where PopedomRoleID=@PopedomRoleID and PopedomFunID=@PopedomFunID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PopedomRoleID", SqlDbType.Int,4),
					new SqlParameter("@PopedomFunID", SqlDbType.Int,4)};
            parameters[0].Value = PopedomRoleID;
            parameters[1].Value = PopedomFunID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PopedomFunInAdminRole ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PopedomFunInAdminRole GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PopedomRoleID,PopedomFunID from PopedomFunInAdminRole ");
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


        private PopedomFunInAdminRole GetModelByDataRow(DataRow row)
        {
            PopedomFunInAdminRole model = new PopedomFunInAdminRole();
            if (row["id"] != null && row["id"].ToString() != "")
            {
                model.ID = int.Parse(row["id"].ToString());
            }
            if (row["PopedomRoleID"] != null && row["PopedomRoleID"].ToString() != "")
            {
                model.PopedomRoleID = int.Parse(row["PopedomRoleID"].ToString());
            }
            if (row["PopedomFunID"] != null && row["PopedomFunID"].ToString() != "")
            {
                model.PopedomFunID = int.Parse(row["PopedomFunID"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PopedomRoleID,PopedomFunID ");
            strSql.Append(" FROM PopedomFunInAdminRole ");
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
            strSql.Append(" ID,PopedomRoleID,PopedomFunID ");
            strSql.Append(" FROM PopedomFunInAdminRole ");
            strSql.Append(IPager.SetSqlWhere(strWhere));
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 批量修改功能 与admin角色关联信息
        /// </summary>
        /// <param name="AdminRoleID"></param>
        /// <param name="arrFunIDS"></param>
        /// <returns></returns>
        public int EditFunInAdminRole(int AdminRoleID, List<PopedomFunInAdminRole> arrEditFunInAdminRole)
        {
            int intR = 0;
            List<PopedomFunInAdminRole> arrAddFunRole = new List<PopedomFunInAdminRole>();
            List<PopedomFunInAdminRole> arrDelFunRole = new List<PopedomFunInAdminRole>();
            List<PopedomFunInAdminRole> arrAdminRoleFunList = GetModelAll().Where(m => m.PopedomRoleID == AdminRoleID).ToList();
            ///要增加的信息
            foreach (PopedomFunInAdminRole newFunRoleModel in arrEditFunInAdminRole)
            {
                int intV = arrAdminRoleFunList.Where(m => m.PopedomFunID == newFunRoleModel.PopedomFunID).Count();
                //原角色没有此权限
                if (intV == 0)
                {
                    arrAddFunRole.Add(newFunRoleModel);
                }
            }
            //找到要删除的
            foreach (PopedomFunInAdminRole delModel in arrAdminRoleFunList)
            {
                int intV = arrEditFunInAdminRole.Where(m => m.PopedomFunID == delModel.PopedomFunID).Count();
                //原角色没有此权限
                if (intV == 0)
                {
                    arrDelFunRole.Add(delModel);
                }
            }

            intR = DelBatch(arrDelFunRole);
            intR += AddBatch(arrAddFunRole);
            return intR;

        }
        public  List<PopedomFunInAdminRole> GetModelAll()
        {
            List<PopedomFunInAdminRole> arr = new List<PopedomFunInAdminRole>();
            DataSet ds = GetList("");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                arr.Add(GetModelByDataRow(item));
            }
            return arr;
        }
        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="arrAddFunRole"></param>
        /// <returns></returns>
        public int AddBatch(List<PopedomFunInAdminRole> arrAddFunRole)
        {
            StringBuilder sql = new StringBuilder();
            foreach (PopedomFunInAdminRole item in arrAddFunRole)
            {
                sql.AppendFormat("insert into PopedomFunInAdminRole(");
                sql.Append("PopedomRoleID,PopedomFunID)");
                sql.Append(" values (");
                sql.AppendFormat("{0},{1})    ", item.PopedomRoleID, item.PopedomFunID);
            }
            return DbHelperSQL.ExecuteSql(sql.ToString());
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="arrDelFunRole"></param>
        /// <returns></returns>
        public int DelBatch(List<PopedomFunInAdminRole> arrDelFunRole)
        {

            StringBuilder sql = new StringBuilder();
            foreach (PopedomFunInAdminRole item in arrDelFunRole)
            {
                sql.AppendFormat("delete  PopedomFunInAdminRole where ");
                sql.AppendFormat("PopedomRoleID={0} and PopedomFunID={1}  ", item.PopedomRoleID, item.PopedomFunID);

            }
            return DbHelperSQL.ExecuteSql(sql.ToString());

        }






    }
}
