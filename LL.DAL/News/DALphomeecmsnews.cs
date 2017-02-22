using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.News;
using Project.Common;
using LL.Model.News;
using System.Collections.Generic;
using LL.DAL;
using DBUtility;
namespace LL.DAL.News
{



    public partial class DALphomeecmsnews : DALNewsBase,Iphome_ecms_news
    {
        private readonly string sp_GetTitleByClassID = "sp_GetTitleByClassID";
        private readonly string Sp_SelectNewsHitNum = "Sp_SelectNewsHitNum";
        private readonly string Sp_GetIndexTitleList = "Sp_GetIndexTitleList";
        public string Sp_GetIndexZhanHui = "sp_Index_ZhanHui";
        string tbName = "phome_ecms_news";
        

        public DALphomeecmsnews()
        {

            base.TableName = tbName;

        }
        #region  Method


        public int GetDataRows(string where)
        {

            string sql = "select count(id) from phome_ecms_news where 1=1 ";
            if (!string.IsNullOrEmpty(where))
            {

                sql += where;
            }

            object obj = DbHelperSQL.GetSingle(sql);


            if (obj != null)
            {

                return (int)obj;
            }
            else
            {

                return 1;
            }


        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LL.Model.News.phome_ecms_news model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into phome_ecms_news(");
            strSql.Append("classid,onclick,newspath,keyboard,keyid,userid,username,ztid,checked,istop,truetime,ismember,dokey,userfen,isgood,titlefont,titleurl,filename,filenameqz,fh,groupid,newstempid,plnum,firsttitle,isqf,totaldown,title,newstime,titlepic,closepl,havehtml,lastdotime,haveaddfen,infopfen,infopfennum,votenum,ftitle,smalltext,writer,befrom,newstext,diggtop)");
            strSql.Append(" values (");
            strSql.Append("@classid,@onclick,@newspath,@keyboard,@keyid,@userid,@username,@ztid,@checked,@istop,@truetime,@ismember,@dokey,@userfen,@isgood,@titlefont,@titleurl,@filename,@filenameqz,@fh,@groupid,@newstempid,@plnum,@firsttitle,@isqf,@totaldown,@title,@newstime,@titlepic,@closepl,@havehtml,@lastdotime,@haveaddfen,@infopfen,@infopfennum,@votenum,@ftitle,@smalltext,@writer,@befrom,@newstext,@diggtop)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@onclick", SqlDbType.Int,4),
					new SqlParameter("@newspath", SqlDbType.NVarChar,150),
					new SqlParameter("@keyboard", SqlDbType.NVarChar,255),
					new SqlParameter("@keyid", SqlDbType.NVarChar,255),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,90),
					new SqlParameter("@ztid", SqlDbType.NVarChar,255),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@truetime", SqlDbType.Int,4),
					new SqlParameter("@ismember", SqlDbType.Int,4),
					new SqlParameter("@dokey", SqlDbType.Int,4),
					new SqlParameter("@userfen", SqlDbType.Int,4),
					new SqlParameter("@isgood", SqlDbType.Int,4),
					new SqlParameter("@titlefont", SqlDbType.NVarChar,150),
					new SqlParameter("@titleurl", SqlDbType.NVarChar,255),
					new SqlParameter("@filename", SqlDbType.NVarChar,180),
					new SqlParameter("@filenameqz", SqlDbType.NVarChar,84),
					new SqlParameter("@fh", SqlDbType.Int,4),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@newstempid", SqlDbType.Int,4),
					new SqlParameter("@plnum", SqlDbType.Int,4),
					new SqlParameter("@firsttitle", SqlDbType.Int,4),
					new SqlParameter("@isqf", SqlDbType.Int,4),
					new SqlParameter("@totaldown", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@newstime", SqlDbType.DateTime),
					new SqlParameter("@titlepic", SqlDbType.NVarChar,255),
					new SqlParameter("@closepl", SqlDbType.Int,4),
					new SqlParameter("@havehtml", SqlDbType.Int,4),
					new SqlParameter("@lastdotime", SqlDbType.Int,4),
					new SqlParameter("@haveaddfen", SqlDbType.Int,4),
					new SqlParameter("@infopfen", SqlDbType.Int,4),
					new SqlParameter("@infopfennum", SqlDbType.Int,4),
					new SqlParameter("@votenum", SqlDbType.Int,4),
					new SqlParameter("@ftitle", SqlDbType.NVarChar,255),
					new SqlParameter("@smalltext", SqlDbType.NVarChar),
					new SqlParameter("@writer", SqlDbType.NVarChar,90),
					new SqlParameter("@befrom", SqlDbType.NVarChar,180),
					new SqlParameter("@newstext", SqlDbType.NVarChar),
					new SqlParameter("@diggtop", SqlDbType.Int,4)};
            parameters[0].Value = model.classid;
            parameters[1].Value = model.onclick;
            parameters[2].Value = model.newspath;
            parameters[3].Value = model.keyboard;
            parameters[4].Value = model.keyid;
            parameters[5].Value = model.userid;
            parameters[6].Value = model.username;
            parameters[7].Value = model.ztid;
            parameters[8].Value = model.@checked;
            parameters[9].Value = model.istop;
            parameters[10].Value = model.truetime;
            parameters[11].Value = model.ismember;
            parameters[12].Value = model.dokey;
            parameters[13].Value = model.userfen;
            parameters[14].Value = model.isgood;
            parameters[15].Value = model.titlefont;
            parameters[16].Value = model.titleurl;
            parameters[17].Value = model.filename;
            parameters[18].Value = model.filenameqz;
            parameters[19].Value = model.fh;
            parameters[20].Value = model.groupid;
            parameters[21].Value = model.newstempid;
            parameters[22].Value = model.plnum;
            parameters[23].Value = model.firsttitle;
            parameters[24].Value = model.isqf;
            parameters[25].Value = model.totaldown;
            parameters[26].Value = model.title;
            parameters[27].Value = model.newstime;
            parameters[28].Value = model.titlepic;
            parameters[29].Value = model.closepl;
            parameters[30].Value = model.havehtml;
            parameters[31].Value = model.lastdotime;
            parameters[32].Value = model.haveaddfen;
            parameters[33].Value = model.infopfen;
            parameters[34].Value = model.infopfennum;
            parameters[35].Value = model.votenum;
            parameters[36].Value = model.ftitle;
            parameters[37].Value = model.smalltext;
            parameters[38].Value = model.writer;
            parameters[39].Value = model.befrom;
            parameters[40].Value = model.newstext;
            parameters[41].Value = model.diggtop;

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
        public int Update(LL.Model.News.phome_ecms_news model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update phome_ecms_news set ");
            strSql.Append("classid=@classid,");
            strSql.Append("onclick=@onclick,");
            strSql.Append("newspath=@newspath,");
            strSql.Append("keyboard=@keyboard,");
            strSql.Append("keyid=@keyid,");
            strSql.Append("userid=@userid,");
            strSql.Append("username=@username,");
            strSql.Append("ztid=@ztid,");
            strSql.Append("checked=@checked,");
            strSql.Append("istop=@istop,");
            strSql.Append("truetime=@truetime,");
            strSql.Append("ismember=@ismember,");
            strSql.Append("dokey=@dokey,");
            strSql.Append("userfen=@userfen,");
            strSql.Append("isgood=@isgood,");
            strSql.Append("titlefont=@titlefont,");
            strSql.Append("titleurl=@titleurl,");
            strSql.Append("filename=@filename,");
            strSql.Append("filenameqz=@filenameqz,");
            strSql.Append("fh=@fh,");
            strSql.Append("groupid=@groupid,");
            strSql.Append("newstempid=@newstempid,");
            strSql.Append("plnum=@plnum,");
            strSql.Append("firsttitle=@firsttitle,");
            strSql.Append("isqf=@isqf,");
            strSql.Append("totaldown=@totaldown,");
            strSql.Append("title=@title,");
            strSql.Append("newstime=@newstime,");
            strSql.Append("titlepic=@titlepic,");
            strSql.Append("closepl=@closepl,");
            strSql.Append("havehtml=@havehtml,");
            strSql.Append("lastdotime=@lastdotime,");
            strSql.Append("haveaddfen=@haveaddfen,");
            strSql.Append("infopfen=@infopfen,");
            strSql.Append("infopfennum=@infopfennum,");
            strSql.Append("votenum=@votenum,");
            strSql.Append("ftitle=@ftitle,");
            strSql.Append("smalltext=@smalltext,");
            strSql.Append("writer=@writer,");
            strSql.Append("befrom=@befrom,");
            strSql.Append("newstext=@newstext,");
            strSql.Append("diggtop=@diggtop");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@classid", SqlDbType.Int,4),
					new SqlParameter("@onclick", SqlDbType.Int,4),
					new SqlParameter("@newspath", SqlDbType.NVarChar,150),
					new SqlParameter("@keyboard", SqlDbType.NVarChar,255),
					new SqlParameter("@keyid", SqlDbType.NVarChar,255),
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,90),
					new SqlParameter("@ztid", SqlDbType.NVarChar,255),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@istop", SqlDbType.Int,4),
					new SqlParameter("@truetime", SqlDbType.Int,4),
					new SqlParameter("@ismember", SqlDbType.Int,4),
					new SqlParameter("@dokey", SqlDbType.Int,4),
					new SqlParameter("@userfen", SqlDbType.Int,4),
					new SqlParameter("@isgood", SqlDbType.Int,4),
					new SqlParameter("@titlefont", SqlDbType.NVarChar,150),
					new SqlParameter("@titleurl", SqlDbType.NVarChar,255),
					new SqlParameter("@filename", SqlDbType.NVarChar,180),
					new SqlParameter("@filenameqz", SqlDbType.NVarChar,84),
					new SqlParameter("@fh", SqlDbType.Int,4),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@newstempid", SqlDbType.Int,4),
					new SqlParameter("@plnum", SqlDbType.Int,4),
					new SqlParameter("@firsttitle", SqlDbType.Int,4),
					new SqlParameter("@isqf", SqlDbType.Int,4),
					new SqlParameter("@totaldown", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@newstime", SqlDbType.DateTime),
					new SqlParameter("@titlepic", SqlDbType.NVarChar,255),
					new SqlParameter("@closepl", SqlDbType.Int,4),
					new SqlParameter("@havehtml", SqlDbType.Int,4),
					new SqlParameter("@lastdotime", SqlDbType.Int,4),
					new SqlParameter("@haveaddfen", SqlDbType.Int,4),
					new SqlParameter("@infopfen", SqlDbType.Int,4),
					new SqlParameter("@infopfennum", SqlDbType.Int,4),
					new SqlParameter("@votenum", SqlDbType.Int,4),
					new SqlParameter("@ftitle", SqlDbType.NVarChar,255),
					new SqlParameter("@smalltext", SqlDbType.NVarChar),
					new SqlParameter("@writer", SqlDbType.NVarChar,90),
					new SqlParameter("@befrom", SqlDbType.NVarChar,180),
					new SqlParameter("@newstext", SqlDbType.NVarChar),
					new SqlParameter("@diggtop", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.classid;
            parameters[1].Value = model.onclick;
            parameters[2].Value = model.newspath;
            parameters[3].Value = model.keyboard;
            parameters[4].Value = model.keyid;
            parameters[5].Value = model.userid;
            parameters[6].Value = model.username;
            parameters[7].Value = model.ztid;
            parameters[8].Value = model.@checked;
            parameters[9].Value = model.istop;
            parameters[10].Value = model.truetime;
            parameters[11].Value = model.ismember;
            parameters[12].Value = model.dokey;
            parameters[13].Value = model.userfen;
            parameters[14].Value = model.isgood;
            parameters[15].Value = model.titlefont;
            parameters[16].Value = model.titleurl;
            parameters[17].Value = model.filename;
            parameters[18].Value = model.filenameqz;
            parameters[19].Value = model.fh;
            parameters[20].Value = model.groupid;
            parameters[21].Value = model.newstempid;
            parameters[22].Value = model.plnum;
            parameters[23].Value = model.firsttitle;
            parameters[24].Value = model.isqf;
            parameters[25].Value = model.totaldown;
            parameters[26].Value = model.title;
            parameters[27].Value = model.newstime;
            parameters[28].Value = model.titlepic;
            parameters[29].Value = model.closepl;
            parameters[30].Value = model.havehtml;
            parameters[31].Value = model.lastdotime;
            parameters[32].Value = model.haveaddfen;
            parameters[33].Value = model.infopfen;
            parameters[34].Value = model.infopfennum;
            parameters[35].Value = model.votenum;
            parameters[36].Value = model.ftitle;
            parameters[37].Value = model.smalltext;
            parameters[38].Value = model.writer;
            parameters[39].Value = model.befrom;
            parameters[40].Value = model.newstext;
            parameters[41].Value = model.diggtop;
            parameters[42].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_ecms_news ");
            strSql.AppendFormat(" where id={0}", id);

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            return rows;
        }

        public int Delete(int id, int userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_ecms_news ");
            strSql.AppendFormat(" where id={0} and userid={1}", id, userid);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            return rows;

        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from phome_ecms_news ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            return rows;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public phome_ecms_news GetModel(int id)
        {

            return GetModel(id, 0);

        }

        public phome_ecms_news GetModel(int NewsID, int userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,classid,onclick,newspath,keyboard,keyid,userid,username,ztid,checked,istop,truetime,ismember,dokey,userfen,isgood,titlefont,titleurl,filename,filenameqz,fh,groupid,newstempid,plnum,firsttitle,isqf,totaldown,title,newstime,titlepic,closepl,havehtml,lastdotime,haveaddfen,infopfen,infopfennum,votenum,ftitle,smalltext,writer,befrom,newstext,diggtop from phome_ecms_news ");
            strSql.AppendFormat(" where id={0}", NewsID);
            if (userid > 0)
            {
                strSql.AppendFormat(" and userid={0}", userid);
            }
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
        public phome_ecms_news GetModelByDataRow(DataRow row)
        {
            phome_ecms_news model = new phome_ecms_news();

            #region

                   if (   row.Table.Columns.Contains("id") &&  row["id"] != null

 && row["id"].ToString() != "")
            {
                model.ID = int.Parse(row["id"].ToString());
            }
            if ( row.Table.Columns.Contains("classid") &&  row["classid"] != null

 && row["classid"].ToString() != "")
            {
                model.classid = int.Parse(row["classid"].ToString());
            }
            if ( row.Table.Columns.Contains("onclick") &&  row["onclick"] != null

 && row["onclick"].ToString() != "")
            {
                model.onclick = int.Parse(row["onclick"].ToString());
            }
            if ( row.Table.Columns.Contains("newspath") &&  row["newspath"] != null

 && row["newspath"].ToString() != "")
            {
                model.newspath = row["newspath"].ToString();
            }
            if ( row.Table.Columns.Contains("keyboard") &&  row["keyboard"] != null

 && row["keyboard"].ToString() != "")
            {
                model.keyboard = row["keyboard"].ToString();
            }
            if ( row.Table.Columns.Contains("keyid") &&  row["keyid"] != null

 && row["keyid"].ToString() != "")
            {
                model.keyid = row["keyid"].ToString();
            }
            if ( row.Table.Columns.Contains("userid") &&  row["userid"] != null

 && row["userid"].ToString() != "")
            {
                model.userid = int.Parse(row["userid"].ToString());
            }
            if ( row.Table.Columns.Contains("username") &&  row["username"] != null

 && row["username"].ToString() != "")
            {
                model.username = row["username"].ToString();
            }
            if ( row.Table.Columns.Contains("ztid") &&  row["ztid"] != null

 && row["ztid"].ToString() != "")
            {
                model.ztid = row["ztid"].ToString();
            }
            if ( row.Table.Columns.Contains("checked") &&  row["checked"] != null

 && row["checked"].ToString() != "")
            {
                model.@checked = int.Parse(row["checked"].ToString());
            }
            if ( row.Table.Columns.Contains("istop") &&  row["istop"] != null

 && row["istop"].ToString() != "")
            {
                model.istop = int.Parse(row["istop"].ToString());
            }
            if ( row.Table.Columns.Contains("truetime") &&  row["truetime"] != null

 && row["truetime"].ToString() != "")
            {
                model.truetime = int.Parse(row["truetime"].ToString());
            }
            if ( row.Table.Columns.Contains("ismember") &&  row["ismember"] != null

 && row["ismember"].ToString() != "")
            {
                model.ismember = int.Parse(row["ismember"].ToString());
            }
            if ( row.Table.Columns.Contains("dokey") &&  row["dokey"] != null

 && row["dokey"].ToString() != "")
            {
                model.dokey = int.Parse(row["dokey"].ToString());
            }
            if ( row.Table.Columns.Contains("userfen") &&  row["userfen"] != null

 && row["userfen"].ToString() != "")
            {
                model.userfen = int.Parse(row["userfen"].ToString());
            }
            if ( row.Table.Columns.Contains("isgood") &&  row["isgood"] != null

 && row["isgood"].ToString() != "")
            {
                model.isgood = int.Parse(row["isgood"].ToString());
            }
            if ( row.Table.Columns.Contains("titlefont") &&  row["titlefont"] != null

 && row["titlefont"].ToString() != "")
            {
                model.titlefont = row["titlefont"].ToString();
            }
            if ( row.Table.Columns.Contains("titleurl") &&  row["titleurl"] != null

 && row["titleurl"].ToString() != "")
            {
                model.titleurl = row["titleurl"].ToString();
            }
            if ( row.Table.Columns.Contains("filename") &&  row["filename"] != null

 && row["filename"].ToString() != "")
            {
                model.filename = row["filename"].ToString();
            }
            if ( row.Table.Columns.Contains("filenameqz") &&  row["filenameqz"] != null

 && row["filenameqz"].ToString() != "")
            {
                model.filenameqz = row["filenameqz"].ToString();
            }
            if ( row.Table.Columns.Contains("fh") &&  row["fh"] != null

 && row["fh"].ToString() != "")
            {
                model.fh = int.Parse(row["fh"].ToString());
            }
            if ( row.Table.Columns.Contains("groupid") &&  row["groupid"] != null

 && row["groupid"].ToString() != "")
            {
                model.groupid = int.Parse(row["groupid"].ToString());
            }
            if ( row.Table.Columns.Contains("newstempid") &&  row["newstempid"] != null

 && row["newstempid"].ToString() != "")
            {
                model.newstempid = int.Parse(row["newstempid"].ToString());
            }
            if ( row.Table.Columns.Contains("plnum") &&  row["plnum"] != null

 && row["plnum"].ToString() != "")
            {
                model.plnum = int.Parse(row["plnum"].ToString());
            }
            if ( row.Table.Columns.Contains("firsttitle") &&  row["firsttitle"] != null

 && row["firsttitle"].ToString() != "")
            {
                model.firsttitle = int.Parse(row["firsttitle"].ToString());
            }
            if ( row.Table.Columns.Contains("isqf") &&  row["isqf"] != null

 && row["isqf"].ToString() != "")
            {
                model.isqf = int.Parse(row["isqf"].ToString());
            }
            if ( row.Table.Columns.Contains("totaldown") &&  row["totaldown"] != null

 && row["totaldown"].ToString() != "")
            {
                model.totaldown = int.Parse(row["totaldown"].ToString());
            }
            if ( row.Table.Columns.Contains("title") &&  row["title"] != null

 && row["title"].ToString() != "")
            {
                model.title = row["title"].ToString();
            }
            if ( row.Table.Columns.Contains("newstime") &&  row["newstime"] != null

 && row["newstime"].ToString() != "")
            {
                model.newstime = DateTime.Parse(row["newstime"].ToString());
            }
            if ( row.Table.Columns.Contains("titlepic") &&  row["titlepic"] != null

 && row["titlepic"].ToString() != "")
            {
                model.titlepic = row["titlepic"].ToString();
            }
            if ( row.Table.Columns.Contains("closepl") &&  row["closepl"] != null

 && row["closepl"].ToString() != "")
            {
                model.closepl = int.Parse(row["closepl"].ToString());
            }
            if ( row.Table.Columns.Contains("havehtml") &&  row["havehtml"] != null

 && row["havehtml"].ToString() != "")
            {
                model.havehtml = int.Parse(row["havehtml"].ToString());
            }
            if ( row.Table.Columns.Contains("lastdotime") &&  row["lastdotime"] != null

 && row["lastdotime"].ToString() != "")
            {
                model.lastdotime = int.Parse(row["lastdotime"].ToString());
            }
            if ( row.Table.Columns.Contains("haveaddfen") &&  row["haveaddfen"] != null

 && row["haveaddfen"].ToString() != "")
            {
                model.haveaddfen = int.Parse(row["haveaddfen"].ToString());
            }
            if ( row.Table.Columns.Contains("infopfen") &&  row["infopfen"] != null

 && row["infopfen"].ToString() != "")
            {
                model.infopfen = int.Parse(row["infopfen"].ToString());
            }
            if ( row.Table.Columns.Contains("infopfennum") &&  row["infopfennum"] != null

 && row["infopfennum"].ToString() != "")
            {
                model.infopfennum = int.Parse(row["infopfennum"].ToString());
            }
            if ( row.Table.Columns.Contains("votenum") &&  row["votenum"] != null

 && row["votenum"].ToString() != "")
            {
                model.votenum = int.Parse(row["votenum"].ToString());
            }
            if ( row.Table.Columns.Contains("ftitle") &&  row["ftitle"] != null

 && row["ftitle"].ToString() != "")
            {
                model.ftitle = row["ftitle"].ToString();
            }
            if ( row.Table.Columns.Contains("smalltext") &&  row["smalltext"] != null

 && row["smalltext"].ToString() != "")
            {
                model.smalltext = row["smalltext"].ToString();
            }
            if ( row.Table.Columns.Contains("writer") &&  row["writer"] != null

 && row["writer"].ToString() != "")
            {
                model.writer = row["writer"].ToString();
            }
            if ( row.Table.Columns.Contains("befrom") &&  row["befrom"] != null

 && row["befrom"].ToString() != "")
            {
                model.befrom = row["befrom"].ToString();
            }
            if ( row.Table.Columns.Contains("newstext") &&  row["newstext"] != null

 && row["newstext"].ToString() != "")
            {
                model.newstext = row["newstext"].ToString();
            }
            if (row.Table.Columns.Contains("diggtop") && row["diggtop"] != null

 && row["diggtop"].ToString() != "")
            {
                model.diggtop = int.Parse(row["diggtop"].ToString());
            }
            #endregion

            return model;
        }


        public const string sp_GetNewsDetailByIDAndClassID = "sp_GetNewsDetailByIDAndClassID";
        /// <summary>
        /// 根据id ，分类id 返回 信息表(以phome_ecms_开头的表)信息 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="classid"></param>
        /// <returns></returns>
        public DataSet GetModelByIDAndClassID(int id, int classid)
        {


            SqlParameter[] parms = { new SqlParameter("@id", SqlDbType.Int), new SqlParameter("@classid", SqlDbType.Int) };
            parms[0].Value = id;
            parms[1].Value = classid;


            return DbHelperSQL.RunProcReturnDS(sp_GetNewsDetailByIDAndClassID, parms);




        }
        /// <summary>
        /// 数据分页
        /// </summary>
        public DataSet GetList(int pageindex, int pagesize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" * ");
            strSql.Append(" FROM phome_ecms_news ");
            if (strWhere.Trim() != "")
            {
                strWhere = strWhere.Trim().ToLower();

                if (strWhere.IndexOf("and") == 0)
                {
                    strSql.Append(" where  1=1 " + strWhere);
                }
                else
                {
                    strSql.AppendFormat(" where  {0}", strWhere);
                }
            }
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




        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,classid,onclick,newspath,keyboard,keyid,userid,username,ztid,checked,istop,truetime,ismember,dokey,userfen,isgood,titlefont,titleurl,filename,filenameqz,fh,groupid,newstempid,plnum,firsttitle,isqf,totaldown,title,newstime,titlepic,closepl,havehtml,lastdotime,haveaddfen,infopfen,infopfennum,votenum,ftitle,smalltext,writer,befrom,newstext,diggtop ");
            strSql.Append(" FROM phome_ecms_news ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  Method
        /// <summary>
        /// 得到前几行新闻存储过程
        /// </summary>

        public DataSet GetTopTitleByClassID(int TopNum, string ClassID, string orderby)
        {
            SqlParameter[] parms = { new SqlParameter("@top", SqlDbType.Int), new SqlParameter("@classid", SqlDbType.VarChar, 100), new SqlParameter("@orderby", SqlDbType.VarChar, 100) };
            parms[0].Value = TopNum;
            parms[1].Value = ClassID;
            parms[2].Value = orderby;
            return DbHelperSQL.RunProcReturnDS(sp_GetTitleByClassID, parms);
        }
        /// <summary>
        /// 点击，浏览，次数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="classid"></param>
        /// <param name="down"></param>
        public int SelectNewsHit(int id, int classid, int down)
        {
            SqlParameter[] parms = { new SqlParameter("@down", SqlDbType.Int), new SqlParameter("@id", SqlDbType.Int), new SqlParameter("@classid", SqlDbType.Int) };
            parms[0].Value = down;
            parms[1].Value = id;
            parms[2].Value = classid;
            DataSet ds = DbHelperSQL.RunProcReturnDS(Sp_SelectNewsHitNum, parms);
            if (ds.Tables[0] != null)
            {

                return Format.DataConvertToInt(ds.Tables[0].Rows[0]);
            }
            else
            {
                return 0;
            }
        }






        #region 批量处理

        public DataSet GetList(int PageIndex, int PageSize, string where)
        {

            string SearchTableName = string.Format("select * from {0} where {1}", tbName, where);
            IPager pager = new IPager(SearchTableName, PageIndex, PageSize, DefaultOrderBy(""));
            return pager.GetResult();

        }


        public string DefaultOrderBy(string orderby)
        {
            if (string.IsNullOrEmpty(orderby))
            {
                orderby = " newstime  desc";

            }
            return orderby;

        }
        public DataSet GetTitleList(int PageIndex, int PageSize, string where, string orderby)
        {
            IPager pager = new IPager();
            pager.TableName = tbName;
            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;
            pager.Fields = " id,classid,userid,title,ftitle,titlepic,titleurl,titlefont,smalltext,newstime,newspath,befrom ";
            pager.PrimaryKeyField = "id";
            pager.OrderBy = DefaultOrderBy(orderby);
            pager.Where = where;

            return pager.GetSearchResultBySingleTable();

        }

        public DataSet GetTopTitleList(int topNum, string where, string orderby)
        {
            string Fields = "id,classid,userid,title,ftitle,titlepic,titleurl,titlefont,smalltext,newstime,newspath,befrom ";

            string ob = "";
            string w = "";

            where += "  and  checked=1";
            if (!string.IsNullOrEmpty(where))
            {

                w = string.Format("   {0}", IPager.SetSqlWhere(where));
            }



            if (!string.IsNullOrEmpty(orderby))
            {

                ob = string.Format(" order by {0}", orderby);
            }
            else
            {
                ob = string.Format(" order by {0}", DefaultOrderBy(orderby));
            }

            string SearchTableName = string.Format("select top {0} {1} from {2} {3}  {4} ", topNum, Fields, tbName, w, ob);

            return DbHelperSQL.Query(SearchTableName);


        }



        #endregion




        public DataSet GetMemberPostNewsCount(int userid)
        {

            string SP_News_GetMemberPostNewsCount = "SP_News_GetMemberPostNewsCount";
            DataSet ds = new DataSet();

            SqlParameter[] param = { new SqlParameter("@userid", SqlDbType.Int) };
            param[0].Value = userid;

            return DbHelperSQL.RunProcedure(SP_News_GetMemberPostNewsCount, param, "td");
        }




        public int UpdateNewsFeedbackNum(int id)
        {
            string sql = string.Format(" update   phome_ecms_news   set plnum=isnull(plnum,1)+1   where id={0}", id);

            return DbHelperSQL.ExecuteSql(sql);
        }


        public int MoveNewsClass(int intClassID, int toClassID)
        {
            string sql = string.Format(" update   phome_ecms_news   set classid={0}   where classid={1}", toClassID,intClassID);

            return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 返回首页所需要的所有标题数据集
        /// </summary>
        /// <returns></returns>
        public DataSet GetIndexTitleList()
        {

            return DbHelperSQL.RunProcedure(Sp_GetIndexTitleList);
        }

     public    DataSet GetIndexZhanHui()
        {


            return DbHelperSQL.RunProcedure(Sp_GetIndexZhanHui);
     }

  
    }
}

