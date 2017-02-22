using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using LL.IDAL.Member;

using System.Transactions;
using LL.Model.Member;
using LL.DAL.Member;
namespace LL.DAL.Member
{
    /// <summary>
    /// 数据访问类phome_enewsmemberadd。
    /// </summary>
    public class DALphome_enewsmemberadd : Iphome_enewsmemberadd
    {


        public DALphome_enewsmemberadd()
        { }
        #region  成员方法




        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(phome_enewsmemberadd model)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into phome_enewsmemberadd(");
            strSql.Append("userid,truename,oicq,msn,call,phone,address,zip,spacestyleid,homepage,saytext,company,fax,userpic,spacename,spacegg,viewstats,sex,duty,leixing,city,industry,products,direction,yzm,gslogo)");
            strSql.Append(" values (");
            strSql.Append("@userid,@truename,@oicq,@msn,@call,@phone,@address,@zip,@spacestyleid,@homepage,@saytext,@company,@fax,@userpic,@spacename,@spacegg,@viewstats,@sex,@duty,@leixing,@city,@industry,@products,@direction,@yzm,@gslogo)");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,8),
					new SqlParameter("@truename", SqlDbType.VarChar,20),
					new SqlParameter("@oicq", SqlDbType.VarChar,25),
					new SqlParameter("@msn", SqlDbType.VarChar,120),
					new SqlParameter("@call", SqlDbType.VarChar,30),
					new SqlParameter("@phone", SqlDbType.VarChar,30),
					new SqlParameter("@address", SqlDbType.VarChar,255),
					new SqlParameter("@zip", SqlDbType.VarChar,8),
					new SqlParameter("@spacestyleid", SqlDbType.Int,4),
					new SqlParameter("@homepage", SqlDbType.VarChar,200),
					new SqlParameter("@saytext", SqlDbType.Text),
					new SqlParameter("@company", SqlDbType.VarChar,255),
					new SqlParameter("@fax", SqlDbType.VarChar,30),
					new SqlParameter("@userpic", SqlDbType.VarChar,200),
					new SqlParameter("@spacename", SqlDbType.VarChar,255),
					new SqlParameter("@spacegg", SqlDbType.Text),
					new SqlParameter("@viewstats", SqlDbType.Int,8),
					new SqlParameter("@sex", SqlDbType.VarChar,6),
					new SqlParameter("@duty", SqlDbType.VarChar,80),
					new SqlParameter("@leixing", SqlDbType.VarChar,255),
					new SqlParameter("@city", SqlDbType.VarChar,10),
					new SqlParameter("@industry", SqlDbType.VarChar,255),
					new SqlParameter("@products", SqlDbType.VarChar,255),
					new SqlParameter("@direction", SqlDbType.VarChar,10),
					new SqlParameter("@yzm", SqlDbType.VarChar,28),
					new SqlParameter("@gslogo", SqlDbType.VarChar,255),
					};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.truename;
            parameters[2].Value = model.oicq;
            parameters[3].Value = model.msn;
            parameters[4].Value = model.call;
            parameters[5].Value = model.phone;
            parameters[6].Value = model.address;
            parameters[7].Value = model.zip;
            parameters[8].Value = model.spacestyleid;
            parameters[9].Value = model.homepage;
            parameters[10].Value = model.saytext;
            parameters[11].Value = model.company;
            parameters[12].Value = model.fax;
            parameters[13].Value = model.userpic;
            parameters[14].Value = model.spacename;
            parameters[15].Value = model.spacegg;
            parameters[16].Value = model.viewstats;
            parameters[17].Value = model.sex;
            parameters[18].Value = model.duty;
            parameters[19].Value = model.leixing;
            parameters[20].Value = model.city;
            parameters[21].Value = model.industry;
            parameters[22].Value = model.products;
            parameters[23].Value = model.direction;
            parameters[24].Value = model.yzm;
            parameters[25].Value = model.gslogo;
          

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(phome_enewsmemberadd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update phome_enewsmemberadd set ");
            strSql.Append("truename=@truename,");
            strSql.Append("oicq=@oicq,");
            strSql.Append("msn=@msn,");
            strSql.Append("call=@call,");
            strSql.Append("phone=@phone,");
            strSql.Append("address=@address,");
            strSql.Append("zip=@zip,");
            strSql.Append("spacestyleid=@spacestyleid,");
            strSql.Append("homepage=@homepage,");
            strSql.Append("saytext=@saytext,");
            strSql.Append("company=@company,");
            strSql.Append("fax=@fax,");
            strSql.Append("userpic=@userpic,");
            strSql.Append("spacename=@spacename,");
            strSql.Append("spacegg=@spacegg,");
            strSql.Append("viewstats=@viewstats,");
            strSql.Append("sex=@sex,");
            strSql.Append("duty=@duty,");
            strSql.Append("leixing=@leixing,");
            strSql.Append("city=@city,");
            strSql.Append("industry=@industry,");
            strSql.Append("products=@products,");
            strSql.Append("direction=@direction,");
            strSql.Append("yzm=@yzm,");
            strSql.Append("gslogo=@gslogo");
         
            strSql.Append(" where userid=@userid  ");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,8),
					new SqlParameter("@truename", SqlDbType.VarChar,20),
					new SqlParameter("@oicq", SqlDbType.VarChar,25),
					new SqlParameter("@msn", SqlDbType.VarChar,120),
					new SqlParameter("@call", SqlDbType.VarChar,30),
					new SqlParameter("@phone", SqlDbType.VarChar,30),
					new SqlParameter("@address", SqlDbType.VarChar,255),
					new SqlParameter("@zip", SqlDbType.VarChar,8),
					new SqlParameter("@spacestyleid", SqlDbType.Int,4),
					new SqlParameter("@homepage", SqlDbType.VarChar,200),
					new SqlParameter("@saytext", SqlDbType.Text),
					new SqlParameter("@company", SqlDbType.VarChar,255),
					new SqlParameter("@fax", SqlDbType.VarChar,30),
					new SqlParameter("@userpic", SqlDbType.VarChar,200),
					new SqlParameter("@spacename", SqlDbType.VarChar,255),
					new SqlParameter("@spacegg", SqlDbType.Text),
					new SqlParameter("@viewstats", SqlDbType.Int,8),
					new SqlParameter("@sex", SqlDbType.VarChar,6),
					new SqlParameter("@duty", SqlDbType.VarChar,80),
					new SqlParameter("@leixing", SqlDbType.VarChar,255),
					new SqlParameter("@city", SqlDbType.VarChar,10),
					new SqlParameter("@industry", SqlDbType.VarChar,255),
					new SqlParameter("@products", SqlDbType.VarChar,255),
					new SqlParameter("@direction", SqlDbType.VarChar,10),
					new SqlParameter("@yzm", SqlDbType.VarChar,28),
					new SqlParameter("@gslogo", SqlDbType.VarChar,255),
					};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.truename;
            parameters[2].Value = model.oicq;
            parameters[3].Value = model.msn;
            parameters[4].Value = model.call;
            parameters[5].Value = model.phone;
            parameters[6].Value = model.address;
            parameters[7].Value = model.zip;
            parameters[8].Value = model.spacestyleid;
            parameters[9].Value = model.homepage;
            parameters[10].Value = model.saytext;
            parameters[11].Value = model.company;
            parameters[12].Value = model.fax;
            parameters[13].Value = model.userpic;
            parameters[14].Value = model.spacename;
            parameters[15].Value = model.spacegg;
            parameters[16].Value = model.viewstats;
            parameters[17].Value = model.sex;
            parameters[18].Value = model.duty;
            parameters[19].Value = model.leixing;
            parameters[20].Value = model.city;
            parameters[21].Value = model.industry;
            parameters[22].Value = model.products;
            parameters[23].Value = model.direction;
            parameters[24].Value = model.yzm;
            parameters[25].Value = model.gslogo;
        

            try
            {
                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {

                return 0;
            }

        }

        public int UpdateInfo(phome_enewsmemberadd model)
        {


            return Update(model);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_enewsmemberadd ");
            strSql.Append(" where userid=@userid ");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int),
					};
            parameters[0].Value = userid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public phome_enewsmemberadd GetModel(int userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *  from phome_enewsmemberadd ");
            strSql.AppendFormat(" where userid={0} ",userid);
            

            phome_enewsmemberadd model = new phome_enewsmemberadd();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetModelByDataRow(ds.Tables[0].Rows[0]);
            }
            else
            {
               //可能会出现，会员登录信息存在，而会员详细信息不存在情况
                if (userid > 0)
                {
                    phome_enewsmemberadd addModel = new phome_enewsmemberadd();
                    addModel.userid = userid;
                    Add(addModel);
                    return addModel;
                }
                else
                {

                    return null;
                }
            }
        }


        /// <summary>
        /// 根据DataRow 返回对像
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public phome_enewsmemberadd GetModelByDataRow(DataRow row)
        {

            phome_enewsmemberadd model = new phome_enewsmemberadd();

            if (row["userid"].ToString() != "")
            {
                model.userid = int.Parse(row["userid"].ToString());
            }
            model.truename = row["truename"].ToString();
            model.oicq = row["oicq"].ToString();
            model.msn = row["msn"].ToString();
            model.call = row["call"].ToString();
            model.phone = row["phone"].ToString();
            model.address = row["address"].ToString();
            model.zip = row["zip"].ToString();
            if (row["spacestyleid"].ToString() != "")
            {
                model.spacestyleid = int.Parse(row["spacestyleid"].ToString());
            }
            model.homepage = row["homepage"].ToString();
            model.saytext = row["saytext"].ToString();
            model.company = row["company"].ToString();
            model.fax = row["fax"].ToString();
            model.userpic = row["userpic"].ToString();
            model.spacename = row["spacename"].ToString();
            model.spacegg = row["spacegg"].ToString();
            if (row["viewstats"].ToString() != "")
            {
                model.viewstats = int.Parse(row["viewstats"].ToString());
            }
            model.sex = row["sex"].ToString();
            model.duty = row["duty"].ToString();
            model.leixing = row["leixing"].ToString();
            model.city = row["city"].ToString();
            model.industry = row["industry"].ToString();
            model.products = row["products"].ToString();
            model.direction = row["direction"].ToString();
            model.yzm = row["yzm"].ToString();
            model.gslogo = row["gslogo"].ToString();



            return model;




        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM phome_enewsmemberadd ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM phome_enewsmemberadd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }




        /// <summary>
        /// 增加一个新会员
        /// 返回:0 程序没添加成功, -1 为异常错误 
        /// </summary>
        /// <param name="modelLogin"></param>
        /// <param name="modelMemberInfo"></param>
        /// <returns></returns>
        public int AddNewMember(phome_enewsmember modelLogin, phome_enewsmemberadd modelMemberInfo)
        {
            int intR = 0;
            using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
            {
                try
                {
                    DALphome_enewsmember dalLogin = new DALphome_enewsmember();
                    int intUserID = dalLogin.Add(modelLogin);
                    if (intUserID > 0)
                    {


                        modelMemberInfo.userid = intUserID;
                        //执行情况
                        intR = Add(modelMemberInfo);

                        //是否执行成功
                        if (intR > 0)
                        {
                            scope.Complete();
                        }
                        intR = intUserID;

                    }
                }
                catch(Exception ee)
                {
                    intR = 0;
                }
                finally
                {

                    scope.Dispose();
                }
            }
            return intR;
        }


        /// <summary>
        /// 更新会员头像
        /// </summary>
        /// <param name="picPath"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int UpdateMemberHeadPic(string picPath, int userid)
        {


            string sql = string.Format(" update  phome_enewsmemberadd set  userpic=@userpic  where userid=@userid");

            SqlParameter[] parameters = {
                                            new SqlParameter("@userpic",SqlDbType.VarChar,100),
					new SqlParameter("@userid", SqlDbType.Int)
					};
            parameters[0].Value = picPath;
            parameters[1].Value = userid;

            return DbHelperSQL.ExecuteSql(sql, parameters);

        }
        /// <summary>
        /// 更新会员公司简介
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="companyIntro"></param>
        /// <returns></returns>
        public int UpdateCompanyIntro(int userid, string companyIntro)
        {
            string sql = string.Format(" update  phome_enewsmemberadd set  saytext=@saytext  where userid=@userid");

            SqlParameter[] parameters = {
                                            new SqlParameter("@saytext",SqlDbType.Text),
					new SqlParameter("@userid", SqlDbType.Int)
					};
            parameters[0].Value = companyIntro;
            parameters[1].Value = userid;

            return DbHelperSQL.ExecuteSql(sql, parameters);

        }
        /// <summary>
        /// 更新会员公司logo
        /// </summary>
        /// <param name="picPath"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int UpdateMemberCompanyLogo(string logoPath, int userid)
        {


            string sql = string.Format(" update  phome_enewsmemberadd set  gslogo=@gslogo  where userid=@userid");

            SqlParameter[] parameters = {
                                            new SqlParameter("@gslogo",SqlDbType.NVarChar,100),
					new SqlParameter("@userid", SqlDbType.Int)
					};
            parameters[0].Value = logoPath;
            parameters[1].Value = userid;

            return DbHelperSQL.ExecuteSql(sql, parameters);

        }

        /// <summary>
        /// 修改的我空间名称与公告
        /// </summary>
        /// <param name="strSpaceName"></param>
        /// <param name="strSpaceNotice"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int UpdateSpace(string strSpaceName, string strSpaceNotice, int userid)
        {



            string sql = string.Format(" update  phome_enewsmemberadd set  spacename=@spacename  ,spacegg=@spacegg where userid=@userid");

            SqlParameter[] parameters = {  new SqlParameter("@spacename",SqlDbType.VarChar,255),
                                             new SqlParameter("@spacegg",SqlDbType.VarChar,1000),
		                                    new SqlParameter("@userid", SqlDbType.Int)
					};
            parameters[0].Value = strSpaceName;
            parameters[1].Value = strSpaceNotice;
            parameters[2].Value = userid;

            return DbHelperSQL.ExecuteSql(sql, parameters);

        }

        /// <summary>
        /// 得到登录信息及详细信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetMemberLoginAndCompanyInfo(int UserID)
        {

            string sql = string.Format(" select  top 1  l.* ,i.*,g.groupname from phome_enewsmember l inner join  phome_enewsmemberadd i on l.userid=i.userid  inner join    [phome_enewsmembergroup]  g on l.groupid= g.groupid  where l.userid={0}", UserID);


            return DbHelperSQL.Query(sql);

        }

        /// <summary>
        /// 修改登录信息，及基本信息
        /// </summary>
        /// <param name="modelLogin"></param>
        /// <param name="modelMemberInfo"></param>
        /// <returns></returns>
        public int UpdateLoginAndMemberInfo(phome_enewsmember modelLogin, phome_enewsmemberadd modelMemberInfo)
        {
            int intR = 0;
            DALphome_enewsmember dalLogin = new DALphome_enewsmember();
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    dalLogin.Update(modelLogin);
                    Update(modelMemberInfo);
                    scope.Complete();
                    intR = 1;
                }
                catch (Exception)
                {
                }
                finally
                {


                    scope.Dispose();

                }
            }

            return intR;




        }
        #endregion  成员方法


        public DataSet GetList(int pageIndex, int pageSize, string strWhere, string filedOrder)
        {
            return new DataSet();
        }
    }
}

