using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Member;
using DBUtility;
using System.Collections.Generic;
using LL.Model.Member;
using Project.Common;
namespace LL.DAL.Member
{

    /// <summary>
    /// 数据访问类phome_enewsmember。
    /// </summary>
    public class DALphome_enewsmember :Iphome_enewsmember
    {
        public DALphome_enewsmember()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from phome_enewsmember");
            strSql.Append(" where userid=@userid ");
            SqlParameter[] parameters = {
					new SqlParameter("@userid",SqlDbType.Int)};
            parameters[0].Value = userid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 验证登录名
        /// userid >0  为修改时骓
        /// userid<1 为增加时验证
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ExistsUserName(int userid, string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from phome_enewsmember");

            strSql.Append(" where  username=@username ");

            if (userid > 0)
            {
                strSql.AppendFormat(" and  userid<>{0}", userid);
            }

            SqlParameter[] parameters = {
					new SqlParameter("@username",SqlDbType.VarChar,100)};
            parameters[0].Value = username;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 验证登录名
        /// userid >0  为修改时骓
        /// userid<1 为增加时验证
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ExistsNickName(int userid, string nickname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from phome_enewsmember");

            strSql.Append(" where  nickname=@nickname ");

            if (userid > 0)
            {
                strSql.AppendFormat(" and  userid<>{0}", userid);
            }

            SqlParameter[] parameters = {
					new SqlParameter("@nickname",SqlDbType.VarChar,100)};
            parameters[0].Value = nickname;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 验证会员Email
        /// userid >0 为修改验证, userid<1 为增加时验证
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ExistsUserEmail(int userid, string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from phome_enewsmember");
            strSql.Append(" where  email=@email ");

            if (userid > 0)
            {
                strSql.AppendFormat(" and  userid<>{0}", userid);
            }

            SqlParameter[] parameters = {
					new SqlParameter("@email",SqlDbType.VarChar,100)};
            parameters[0].Value = email;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 修改密码或email
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="strNewPwd"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int UpdatePwd(int userID, string strNewPwd)
        {
            string strSql = " update   phome_enewsmember  set    password=@password  where   userid=@userid";

            SqlParameter[] parameters = {
				
					new SqlParameter("@password", SqlDbType.VarChar,32),
					new SqlParameter("@userid", SqlDbType.Int)};
            parameters[0].Value = strNewPwd;
            parameters[1].Value = userID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 修改Email
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int UpdateEmail(int userID, string email)
        {
            string strSql = " update   phome_enewsmember  set    email=@email where   userid=@userid";

            SqlParameter[] parameters = {
				
					new SqlParameter("@email", SqlDbType.VarChar,32),
					new SqlParameter("@userid", SqlDbType.Int)};
            parameters[0].Value = email;
            parameters[1].Value = userID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);


        }
        /// <summary>
        /// 增加一条数据,并返回生成的userid
        /// </summary>
        public int Add(phome_enewsmember model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into phome_enewsmember(");
            strSql.Append("username,password,rnd,email,registertime,groupid,userfen,userdate,money,todaydate,todaydown,zgroupid,havemsg,checked)");
            strSql.Append(" values (");
            strSql.Append("@username,@password,@rnd,@email,@registertime,@groupid,@userfen,@userdate,@money,@todaydate,@todaydown,@zgroupid,@havemsg,@checked)   select @@identity");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,30),
					new SqlParameter("@password", SqlDbType.VarChar,300),
					new SqlParameter("@rnd", SqlDbType.VarChar,30),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@registertime", SqlDbType.DateTime),
					new SqlParameter("@groupid", SqlDbType.Int),
					new SqlParameter("@userfen", SqlDbType.Int),
					new SqlParameter("@userdate", SqlDbType.VarChar),
					new SqlParameter("@money", SqlDbType.Float),
					new SqlParameter("@todaydate", SqlDbType.VarChar,10),
					new SqlParameter("@todaydown", SqlDbType.Int),
					new SqlParameter("@zgroupid", SqlDbType.Int),
					new SqlParameter("@havemsg", SqlDbType.Int),
					new SqlParameter("@checked", SqlDbType.Int)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.password;
            parameters[2].Value = model.rnd;
            parameters[3].Value = model.email;
            parameters[4].Value = model.registertime;
            parameters[5].Value = model.groupid;
            parameters[6].Value = model.userfen;
            parameters[7].Value = model.userdate;
            parameters[8].Value = model.money;
            parameters[9].Value = model.todaydate;
            parameters[10].Value = model.todaydown;
            parameters[11].Value = model.zgroupid;
            parameters[12].Value = model.havemsg;
            parameters[13].Value = model.@checked;
        
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            int intR = 0;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    intR = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }

            return intR;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(phome_enewsmember model)
        {




            StringBuilder strSql = new StringBuilder();
            strSql.Append("update phome_enewsmember set ");
            strSql.Append("username=@username,");
            strSql.Append("password=@password,");
            strSql.Append("rnd=@rnd,");
            strSql.Append("email=@email,");
            strSql.Append("registertime=@registertime,");
            strSql.Append("groupid=@groupid,");
            strSql.Append("userfen=@userfen,");
            strSql.Append("userdate=@userdate,");
            strSql.Append("money=@money,");
            strSql.Append("todaydate=@todaydate,");
            strSql.Append("todaydown=@todaydown,");
            strSql.Append("zgroupid=@zgroupid,");
            strSql.Append("havemsg=@havemsg,");
            strSql.Append("checked=@checked");
         
            strSql.Append(" where userid=@userid ");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,11),
					new SqlParameter("@username", SqlDbType.VarChar,30),
					new SqlParameter("@password", SqlDbType.VarChar,300),
					new SqlParameter("@rnd", SqlDbType.VarChar,30),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@registertime", SqlDbType.DateTime),
					new SqlParameter("@groupid", SqlDbType.Int,6),
					new SqlParameter("@userfen", SqlDbType.Int,11),
					new SqlParameter("@userdate", SqlDbType.VarChar,30),
					new SqlParameter("@money", SqlDbType.Float,11),
					new SqlParameter("@todaydate", SqlDbType.VarChar,10),
					new SqlParameter("@todaydown", SqlDbType.Int,11),
					new SqlParameter("@zgroupid", SqlDbType.Int,6),
					new SqlParameter("@havemsg", SqlDbType.Int,1),
					new SqlParameter("@checked", SqlDbType.Int,1)
           
					};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.username;
            parameters[2].Value = model.password;
            parameters[3].Value = model.rnd;
            parameters[4].Value = model.email;
            parameters[5].Value = model.registertime;
            parameters[6].Value = model.groupid;
            parameters[7].Value = model.userfen;
            parameters[8].Value = model.userdate;
            parameters[9].Value = model.money;
            parameters[10].Value = model.todaydate;
            parameters[11].Value = model.todaydown;
            parameters[12].Value = model.zgroupid;
            parameters[13].Value = model.havemsg;
            parameters[14].Value = model.@checked;
          

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 验证登录，运回 member对像,并检查是否到期
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public phome_enewsmember Login(string strLoginName, string strPwd)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from phome_enewsmember ");
            strSql.Append(" where   username=@username and    password=@password ");

            SqlParameter[] parameters = { new SqlParameter("@username", SqlDbType.VarChar, 30), new SqlParameter("@password", SqlDbType.VarChar, 300) };
            parameters[0].Value = strLoginName;
            parameters[1].Value = strPwd;
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
        /// 最后一次登录时间
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="lastDate"></param>
        /// <returns></returns>
        public int SetLoginLastDate(int userid, string lastDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  phome_enewsmember  set  lastlogintime='{0}' where userid={1} ", lastDate, userid);
            try
            {
                return DbHelperSQL.ExecuteSql(strSql.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public int SetMemberUseDate(int userid, DateTime sdate, DateTime edate)
        {

            string sql = string.Format("   update  phome_enewsmember set  sdate='{0}' ,edate='{1}' where userid={2}", sdate, edate, userid);


            return DbHelperSQL.ExecuteSql(sql);



        }
        /// <summary>
        /// 删除用户信息
        /// 删除登录信息
        /// 删除注册信息
        /// </summary>
        public int Delete(int userid)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.Append("   delete   from phome_enewsmember  where userid=@userid ");
            strSql.Append("   delete   from phome_enewsmemberadd where userid=@userid");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int)};
            parameters[0].Value = userid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public phome_enewsmember GetModel(int userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from phome_enewsmember ");
            strSql.Append(" where userid=@userid ");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int)};
            parameters[0].Value = userid;

            phome_enewsmember model = new phome_enewsmember();
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
        /// 根据DataRow 返回对像
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public phome_enewsmember GetModelByDataRow(DataRow row)
        {

            phome_enewsmember model = new phome_enewsmember();

            if (row["userid"].ToString() != "")
            {
                model.userid = int.Parse(row["userid"].ToString());
            }
            model.username = row["username"].ToString();
            model.password = row["password"].ToString();
            model.rnd = row["rnd"].ToString();
            model.email = row["email"].ToString();
            if (row["registertime"].ToString() != "")
            {
                model.registertime = DateTime.Parse(row["registertime"].ToString());
            }
            if (row["groupid"].ToString() != "")
            {
                model.groupid = int.Parse(row["groupid"].ToString());
            }
            if (row["userfen"].ToString() != "")
            {
                model.userfen = int.Parse(row["userfen"].ToString());
            }
            if (row["userdate"].ToString() != "")
            {
                model.userdate =row["userdate"].ToString();
            }
            if (row["money"].ToString() != "" )
            {
                model.money = decimal.Parse(row["money"].ToString());
            }
            model.todaydate = row["todaydate"].ToString();
            if (row["todaydown"].ToString() != "")
            {
                model.todaydown = int.Parse(row["todaydown"].ToString());
            }
            if (row["zgroupid"].ToString() != "")
            {
                model.zgroupid = int.Parse(row["zgroupid"].ToString());
            }
            if (row["havemsg"].ToString() != "")
            {
                model.havemsg = int.Parse(row["havemsg"].ToString());
            }
            if (row["checked"].ToString() != "")
            {
                model.@checked = int.Parse(row["checked"].ToString());
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
            strSql.Append(" FROM phome_enewsmember ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <param name="Checked"></param>
        /// <returns></returns>
        public int BatchCheckedMember(List<int> arrIDS, int Checked)
        {

            StringBuilder checkedSql = new StringBuilder();

            foreach (int userid in arrIDS)
            {

                checkedSql.AppendFormat("   update  phome_enewsmember set checked={0} where userid={1}", Checked, userid);

            }

            return DbHelperSQL.ExecuteSql(checkedSql.ToString());



        }

        /// <summary>
        /// 批量删除
        /// 删除登录信息，
        /// 删除基本信息
        /// </summary>
        /// <param name="arrIDS"></param>
        /// <returns></returns>
        public int BatchDelMember(List<int> arrIDS)
        {
            StringBuilder delSql = new StringBuilder();
            foreach (int userid in arrIDS)
            {
                delSql.AppendFormat("   delete   phome_enewsmember  where userid={0}", userid);
                delSql.AppendFormat("    delete  phome_enewsmemeradd where userid={0}", userid);

            }
            return DbHelperSQL.ExecuteSql(delSql.ToString());
        }

        /// <summary>
        /// 得到列表
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="loginName"></param>
        /// <param name="groupID"></param>
        /// <param name="mcheck"></param>
        /// <returns></returns>
        public DataSet GetList(int PageIndex, int PageSize, string where)
        {
            return GetList(PageIndex, PageSize, where, string.Empty);
        }
        public DataSet GetList(int PageIndex, int PageSize, string where, string orderby)
        {
            string tableName = string.Format(" select * from  phome_enewsmember where  {0}", where);

            if (string.IsNullOrEmpty(orderby))
            {

                orderby = "   userid desc ";
            }

            IPager pager = new IPager(tableName, "userid", PageIndex, PageSize, "*", orderby);

            return pager.GetResult();
        }
        #endregion  成员方法

        public DataSet GetLoginAndInfoList(int PageIndex, int PageSize, string where, string orderby)
        {
            string tableName = string.Format(" select l.* ,m.truename ,m.oicq ,m.msn ,m.call ,m.phone ,m.address ,m.zip ,m.spacestyleid ,m.homepage ,m.saytext ,m.company ,m.fax ,m.userpic ,m.spacename ,m.spacegg ,m.viewstats ,m.sex ,m.duty ,m.leixing ,m.city ,m.industry ,m.products ,m.direction ,m.yzm ,m.gslogo  from  phome_enewsmember l inner join  phome_enewsmemberadd m  on l.userid=m.userid where  {0}", where);

            if (string.IsNullOrEmpty(orderby))
            {

                orderby = "   userid desc ";
            }

            IPager pager = new IPager(tableName, "userid", PageIndex, PageSize, "*", orderby);

            return pager.GetResult();
        }

        /// <summary>
        /// 得到会员角色
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetMemberRole(int userid)
        {


            string sql = string.Format(" select  top 1 groupid  from  phome_enewsmember where userid={0}", userid);


            object role = DbHelperSQL.GetSingle(sql);


            if (role != null)
            {

                return (int)role;
            }
            else
            {

                return 0;
            }

        }


        #region 最新加入，推荐


        public DataSet GetNewJoinCompany(int TopNum)
        {

            throw new Exception();
            // string sql = string.Format("  select top  {0} * from  phome_enewsmember where   checked=1  order by id desc ");

        }

        public DataSet GetRecommendCompany(int TopNum)
        {
            throw new Exception();

        }
        #endregion




        bool Iphome_enewsmember.Delete(int userid)
        {
            throw new NotImplementedException();
        }

        public bool DeleteList(string useridlist)
        {
            throw new NotImplementedException();
        }

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }
    }
}


