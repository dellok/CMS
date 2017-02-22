using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Data.SqlClient;
using LL.Model.Member;
using LL.IDAL.Member;
using DBUtility;
namespace CLB.DAL.Member
{
    public class DALMemberWebSiteFriendLink : IMemberWebSiteFriendLink
    {

   

        public string TbName="MemberWebSiteFriendLink";

        /// <summary>
        ///增加记录 返回id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(MemberWebSiteFriendLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MemberWebSiteFriendLink(");
            strSql.Append("Title,Url,UserID,InDate,Checked)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Url,@UserID,@InDate,@Checked)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,300),
					new SqlParameter("@Url", SqlDbType.VarChar,100),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Checked", SqlDbType.Bit,1)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.InDate;
            parameters[4].Value = model.Checked;

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
        /// 批量删除数据用户
        /// </summary>
        /// <param name="arrID"></param>
        /// <returns></returns>
        public int DelAll(List<int> arrID)
        {
            int intResult = 0;
            StringBuilder delSql = new StringBuilder();
            foreach (int item in arrID)
            {
                delSql.AppendFormat(" delete  MemberWebSiteFriendLink where ID={0} ", item);
            }
            if (!string.IsNullOrEmpty(delSql.ToString()))
            {
                intResult = DbHelperSQL.ExecuteSql(delSql.ToString());
            }
            return intResult;
        }
      

  
        /// <summary>
        /// 判断是否已添加相同的新闻
        /// ID>0 为修改时判断
        /// ID小于=0 为增加进判断
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public bool ExistsExists(int ID, string Url)
        {
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberWebSiteFriendLink");
			strSql.Append(" where ID=@ID  and  url=@url");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@url", SqlDbType.VarChar)
                                        
                                        };
			parameters[0].Value = ID;
            parameters[1].Value = Url;
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		

        }
        

   



        public int CheckedMemberFriendLink(List<int> arrIDs, bool chd)
        {

            StringBuilder sql = new StringBuilder();

            foreach (int  id in arrIDs)
            {

                sql.AppendFormat(" update    MemberWebSiteFriendLink set  [checked]  where id={0}   ",id);
            }

            return DbHelperSQL.ExecuteSql(sql.ToString());
        }
     
        public List<MemberWebSiteFriendLink> GetMemberFriendLinkByMemberID(int userid)
        {


            List<MemberWebSiteFriendLink> arr = new List<MemberWebSiteFriendLink>();
            string where = string.Format("select  *  from  MemberWebSiteFriendLink where  userid={0} ",userid);
            DataSet ds = DbHelperSQL.Query(where);

            foreach (DataRow item in ds.Tables[0].Rows)
            {

                arr.Add(GetModel(item));
            }


           return arr;


        }
       public DataSet  GetList(int PageIndex,int PageSize,string strWhere)
        {
           // string where = string.Format("UserID={0}",UserID);
            IPager pager = new IPager();
            pager.TableName = TbName;
            pager.Where = strWhere;
            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;
            pager.PrimaryKeyField = "ID";
            //绑定新闻列表Sql
            return pager.GetResult();

        }

       #region  成员方法

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public int  Update(MemberWebSiteFriendLink model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update MemberWebSiteFriendLink set ");
           strSql.Append("Title=@Title,");
           strSql.Append("Url=@Url,");
           strSql.Append("UserID=@UserID,");
           strSql.Append("InDate=@InDate,");
           strSql.Append("Checked=@Checked");
           strSql.Append(" where ID=@ID ");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,300),
					new SqlParameter("@Url", SqlDbType.VarChar,100),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Checked", SqlDbType.Bit,1)};
           parameters[0].Value = model.ID;
           parameters[1].Value = model.Title;
           parameters[2].Value = model.Url;
           parameters[3].Value = model.UserID;
           parameters[4].Value = model.InDate;
           parameters[5].Value = model.Checked;

          return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public int  Delete(int ID)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from MemberWebSiteFriendLink ");
           strSql.AppendFormat(" where ID={0} ",ID);

           return DbHelperSQL.ExecuteSql(strSql.ToString());
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public  MemberWebSiteFriendLink GetModel(int ID)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 ID,Title,Url,UserID,InDate,Checked from MemberWebSiteFriendLink ");
           strSql.AppendFormat(" where ID={0} ",ID);

           DataSet ds = DbHelperSQL.Query(strSql.ToString());

           if (ds.Tables[0].Rows.Count > 0)
           {

               return GetModel(ds.Tables[0].Rows[0]);

           }
           else
           {

               return null;
           }

       }
       private MemberWebSiteFriendLink GetModel(DataRow row)
       {

           MemberWebSiteFriendLink model = new MemberWebSiteFriendLink();

           if (row["ID"].ToString() != "")
           {
               model.ID = int.Parse(row["ID"].ToString());
           }
           model.Title = row["Title"].ToString();
           model.Url = row["Url"].ToString();
           if (row["UserID"].ToString() != "")
           {
               model.UserID = int.Parse(row["UserID"].ToString());
           }
           if (row["InDate"].ToString() != "")
           {
               model.InDate = DateTime.Parse(row["InDate"].ToString());
           }
           if (row["Checked"].ToString() != "")
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
           return model;
      


       
       }
       
       #endregion  成员方法

    

  
    }
}
