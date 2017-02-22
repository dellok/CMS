using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.News;
using DBUtility;
using LL.Model.News;
using System.Collections.Generic;
namespace LL.DAL.News
{
	/// <summary>
	/// 数据访问类:phome_ecms_gsk
	/// </summary>
	public partial class DALphome_ecms_gsk:DALNewsBase,Iphome_ecms_gsk
	{

        
		public DALphome_ecms_gsk()
		{

            base.TableName = "phome_ecms_gsk";


        
        }
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(phome_ecms_gsk model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_ecms_gsk(");
			strSql.Append("id,classid,onclick,newspath,keyboard,keyid,userid,username,ztid,checked,istop,truetime,ismember,dokey,userfen,isgood,titlefont,titleurl,filename,filenameqz,fh,groupid,newstempid,plnum,firsttitle,isqf,totaldown,title,newstime,titlepic,closepl,havehtml,lastdotime,haveaddfen,infopfen,infopfennum,votenum,smalltext,fuwu,hangye,moshi,leixing,address,num,chengli,faren,money,city,market,oem,chukou,area,chanliang,person,tel,fac,dizhi,zip,url,email,leibie,zhizao,gslb,cclb)");
			strSql.Append(" values (");
			strSql.Append("@id,@classid,@onclick,@newspath,@keyboard,@keyid,@userid,@username,@ztid,@checked,@istop,@truetime,@ismember,@dokey,@userfen,@isgood,@titlefont,@titleurl,@filename,@filenameqz,@fh,@groupid,@newstempid,@plnum,@firsttitle,@isqf,@totaldown,@title,@newstime,@titlepic,@closepl,@havehtml,@lastdotime,@haveaddfen,@infopfen,@infopfennum,@votenum,@smalltext,@fuwu,@hangye,@moshi,@leixing,@address,@num,@chengli,@faren,@money,@city,@market,@oem,@chukou,@area,@chanliang,@person,@tel,@fac,@dizhi,@zip,@url,@email,@leibie,@zhizao,@gslb,@cclb)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
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
					new SqlParameter("@smalltext", SqlDbType.Text),
					new SqlParameter("@fuwu", SqlDbType.Text),
					new SqlParameter("@hangye", SqlDbType.Text),
					new SqlParameter("@moshi", SqlDbType.NVarChar,255),
					new SqlParameter("@leixing", SqlDbType.NVarChar,18),
					new SqlParameter("@address", SqlDbType.NVarChar,30),
					new SqlParameter("@num", SqlDbType.NVarChar,60),
					new SqlParameter("@chengli", SqlDbType.NVarChar,60),
					new SqlParameter("@faren", SqlDbType.NVarChar,60),
					new SqlParameter("@money", SqlDbType.NVarChar,150),
					new SqlParameter("@city", SqlDbType.NVarChar,255),
					new SqlParameter("@market", SqlDbType.NVarChar,255),
					new SqlParameter("@oem", SqlDbType.NVarChar,18),
					new SqlParameter("@chukou", SqlDbType.NVarChar,150),
					new SqlParameter("@area", SqlDbType.NVarChar,150),
					new SqlParameter("@chanliang", SqlDbType.NVarChar,150),
					new SqlParameter("@person", SqlDbType.NVarChar,84),
					new SqlParameter("@tel", SqlDbType.NVarChar,150),
					new SqlParameter("@fac", SqlDbType.NVarChar,84),
					new SqlParameter("@dizhi", SqlDbType.NVarChar,240),
					new SqlParameter("@zip", SqlDbType.NVarChar,18),
					new SqlParameter("@url", SqlDbType.NVarChar,240),
					new SqlParameter("@email", SqlDbType.NVarChar,240),
					new SqlParameter("@leibie", SqlDbType.NVarChar,54),
					new SqlParameter("@zhizao", SqlDbType.NVarChar,54),
					new SqlParameter("@gslb", SqlDbType.NVarChar,180),
					new SqlParameter("@cclb", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.classid;
			parameters[2].Value = model.onclick;
			parameters[3].Value = model.newspath;
			parameters[4].Value = model.keyboard;
			parameters[5].Value = model.keyid;
			parameters[6].Value = model.userid;
			parameters[7].Value = model.username;
			parameters[8].Value = model.ztid;
			parameters[9].Value = model.@checked;
			parameters[10].Value = model.istop;
			parameters[11].Value = model.truetime;
			parameters[12].Value = model.ismember;
			parameters[13].Value = model.dokey;
			parameters[14].Value = model.userfen;
			parameters[15].Value = model.isgood;
			parameters[16].Value = model.titlefont;
			parameters[17].Value = model.titleurl;
			parameters[18].Value = model.filename;
			parameters[19].Value = model.filenameqz;
			parameters[20].Value = model.fh;
			parameters[21].Value = model.groupid;
			parameters[22].Value = model.newstempid;
			parameters[23].Value = model.plnum;
			parameters[24].Value = model.firsttitle;
			parameters[25].Value = model.isqf;
			parameters[26].Value = model.totaldown;
			parameters[27].Value = model.title;
			parameters[28].Value = model.newstime;
			parameters[29].Value = model.titlepic;
			parameters[30].Value = model.closepl;
			parameters[31].Value = model.havehtml;
			parameters[32].Value = model.lastdotime;
			parameters[33].Value = model.haveaddfen;
			parameters[34].Value = model.infopfen;
			parameters[35].Value = model.infopfennum;
			parameters[36].Value = model.votenum;
			parameters[37].Value = model.smalltext;
			parameters[38].Value = model.fuwu;
			parameters[39].Value = model.hangye;
			parameters[40].Value = model.moshi;
			parameters[41].Value = model.leixing;
			parameters[42].Value = model.address;
			parameters[43].Value = model.num;
			parameters[44].Value = model.chengli;
			parameters[45].Value = model.faren;
			parameters[46].Value = model.money;
			parameters[47].Value = model.city;
			parameters[48].Value = model.market;
			parameters[49].Value = model.oem;
			parameters[50].Value = model.chukou;
			parameters[51].Value = model.area;
			parameters[52].Value = model.chanliang;
			parameters[53].Value = model.person;
			parameters[54].Value = model.tel;
			parameters[55].Value = model.fac;
			parameters[56].Value = model.dizhi;
			parameters[57].Value = model.zip;
			parameters[58].Value = model.url;
			parameters[59].Value = model.email;
			parameters[60].Value = model.leibie;
			parameters[61].Value = model.zhizao;
			parameters[62].Value = model.gslb;
			parameters[63].Value = model.cclb;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(phome_ecms_gsk model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_ecms_gsk set ");
		
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
			strSql.Append("smalltext=@smalltext,");
			strSql.Append("fuwu=@fuwu,");
			strSql.Append("hangye=@hangye,");
			strSql.Append("moshi=@moshi,");
			strSql.Append("leixing=@leixing,");
			strSql.Append("address=@address,");
			strSql.Append("num=@num,");
			strSql.Append("chengli=@chengli,");
			strSql.Append("faren=@faren,");
			strSql.Append("money=@money,");
			strSql.Append("city=@city,");
			strSql.Append("market=@market,");
			strSql.Append("oem=@oem,");
			strSql.Append("chukou=@chukou,");
			strSql.Append("area=@area,");
			strSql.Append("chanliang=@chanliang,");
			strSql.Append("person=@person,");
			strSql.Append("tel=@tel,");
			strSql.Append("fac=@fac,");
			strSql.Append("dizhi=@dizhi,");
			strSql.Append("zip=@zip,");
			strSql.Append("url=@url,");
			strSql.Append("email=@email,");
			strSql.Append("leibie=@leibie,");
			strSql.Append("zhizao=@zhizao,");
			strSql.Append("gslb=@gslb,");
			strSql.Append("cclb=@cclb");
			strSql.Append(" where ");
            strSql.Append("id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
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
					new SqlParameter("@smalltext", SqlDbType.Text),
					new SqlParameter("@fuwu", SqlDbType.Text),
					new SqlParameter("@hangye", SqlDbType.Text),
					new SqlParameter("@moshi", SqlDbType.NVarChar,255),
					new SqlParameter("@leixing", SqlDbType.NVarChar,18),
					new SqlParameter("@address", SqlDbType.NVarChar,30),
					new SqlParameter("@num", SqlDbType.NVarChar,60),
					new SqlParameter("@chengli", SqlDbType.NVarChar,60),
					new SqlParameter("@faren", SqlDbType.NVarChar,60),
					new SqlParameter("@money", SqlDbType.NVarChar,150),
					new SqlParameter("@city", SqlDbType.NVarChar,255),
					new SqlParameter("@market", SqlDbType.NVarChar,255),
					new SqlParameter("@oem", SqlDbType.NVarChar,18),
					new SqlParameter("@chukou", SqlDbType.NVarChar,150),
					new SqlParameter("@area", SqlDbType.NVarChar,150),
					new SqlParameter("@chanliang", SqlDbType.NVarChar,150),
					new SqlParameter("@person", SqlDbType.NVarChar,84),
					new SqlParameter("@tel", SqlDbType.NVarChar,150),
					new SqlParameter("@fac", SqlDbType.NVarChar,84),
					new SqlParameter("@dizhi", SqlDbType.NVarChar,240),
					new SqlParameter("@zip", SqlDbType.NVarChar,18),
					new SqlParameter("@url", SqlDbType.NVarChar,240),
					new SqlParameter("@email", SqlDbType.NVarChar,240),
					new SqlParameter("@leibie", SqlDbType.NVarChar,54),
					new SqlParameter("@zhizao", SqlDbType.NVarChar,54),
					new SqlParameter("@gslb", SqlDbType.NVarChar,180),
					new SqlParameter("@cclb", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.classid;
			parameters[2].Value = model.onclick;
			parameters[3].Value = model.newspath;
			parameters[4].Value = model.keyboard;
			parameters[5].Value = model.keyid;
			parameters[6].Value = model.userid;
			parameters[7].Value = model.username;
			parameters[8].Value = model.ztid;
			parameters[9].Value = model.@checked;
			parameters[10].Value = model.istop;
			parameters[11].Value = model.truetime;
			parameters[12].Value = model.ismember;
			parameters[13].Value = model.dokey;
			parameters[14].Value = model.userfen;
			parameters[15].Value = model.isgood;
			parameters[16].Value = model.titlefont;
			parameters[17].Value = model.titleurl;
			parameters[18].Value = model.filename;
			parameters[19].Value = model.filenameqz;
			parameters[20].Value = model.fh;
			parameters[21].Value = model.groupid;
			parameters[22].Value = model.newstempid;
			parameters[23].Value = model.plnum;
			parameters[24].Value = model.firsttitle;
			parameters[25].Value = model.isqf;
			parameters[26].Value = model.totaldown;
			parameters[27].Value = model.title;
			parameters[28].Value = model.newstime;
			parameters[29].Value = model.titlepic;
			parameters[30].Value = model.closepl;
			parameters[31].Value = model.havehtml;
			parameters[32].Value = model.lastdotime;
			parameters[33].Value = model.haveaddfen;
			parameters[34].Value = model.infopfen;
			parameters[35].Value = model.infopfennum;
			parameters[36].Value = model.votenum;
			parameters[37].Value = model.smalltext;
			parameters[38].Value = model.fuwu;
			parameters[39].Value = model.hangye;
			parameters[40].Value = model.moshi;
			parameters[41].Value = model.leixing;
			parameters[42].Value = model.address;
			parameters[43].Value = model.num;
			parameters[44].Value = model.chengli;
			parameters[45].Value = model.faren;
			parameters[46].Value = model.money;
			parameters[47].Value = model.city;
			parameters[48].Value = model.market;
			parameters[49].Value = model.oem;
			parameters[50].Value = model.chukou;
			parameters[51].Value = model.area;
			parameters[52].Value = model.chanliang;
			parameters[53].Value = model.person;
			parameters[54].Value = model.tel;
			parameters[55].Value = model.fac;
			parameters[56].Value = model.dizhi;
			parameters[57].Value = model.zip;
			parameters[58].Value = model.url;
			parameters[59].Value = model.email;
			parameters[60].Value = model.leibie;
			parameters[61].Value = model.zhizao;
			parameters[62].Value = model.gslb;
			parameters[63].Value = model.cclb;

		 return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            
		}


		public int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_ecms_gsk ");
			strSql.AppendFormat(" where  id={0}",id);
		    return DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		public phome_ecms_gsk GetModel(int id)
		{
            return GetModel(id, -1);
		}
        private phome_ecms_gsk GetModelByDataRow(DataRow row)
        {
            phome_ecms_gsk model = new phome_ecms_gsk();
            if (row["id"] != null && row["id"].ToString() != "")
            {
                model.ID = int.Parse(row["id"].ToString());
            }
            if (row["classid"] != null && row["classid"].ToString() != "")
            {
                model.classid = int.Parse(row["classid"].ToString());
            }
            if (row["onclick"] != null && row["onclick"].ToString() != "")
            {
                model.onclick = int.Parse(row["onclick"].ToString());
            }
            if (row["newspath"] != null && row["newspath"].ToString() != "")
            {
                model.newspath = row["newspath"].ToString();
            }
            if (row["keyboard"] != null && row["keyboard"].ToString() != "")
            {
                model.keyboard = row["keyboard"].ToString();
            }
            if (row["keyid"] != null && row["keyid"].ToString() != "")
            {
                model.keyid = row["keyid"].ToString();
            }
            if (row["userid"] != null && row["userid"].ToString() != "")
            {
                model.userid = int.Parse(row["userid"].ToString());
            }
            if (row["username"] != null && row["username"].ToString() != "")
            {
                model.username = row["username"].ToString();
            }
            if (row["ztid"] != null && row["ztid"].ToString() != "")
            {
                model.ztid = row["ztid"].ToString();
            }
            if (row["checked"] != null && row["checked"].ToString() != "")
            {
                model.@checked = int.Parse(row["checked"].ToString());
            }
            if (row["istop"] != null && row["istop"].ToString() != "")
            {
                model.istop = int.Parse(row["istop"].ToString());
            }
            if (row["truetime"] != null && row["truetime"].ToString() != "")
            {
                model.truetime = int.Parse(row["truetime"].ToString());
            }
            if (row["ismember"] != null && row["ismember"].ToString() != "")
            {
                model.ismember = int.Parse(row["ismember"].ToString());
            }
            if (row["dokey"] != null && row["dokey"].ToString() != "")
            {
                model.dokey = int.Parse(row["dokey"].ToString());
            }
            if (row["userfen"] != null && row["userfen"].ToString() != "")
            {
                model.userfen = int.Parse(row["userfen"].ToString());
            }
            if (row["isgood"] != null && row["isgood"].ToString() != "")
            {
                model.isgood = int.Parse(row["isgood"].ToString());
            }
            if (row["titlefont"] != null && row["titlefont"].ToString() != "")
            {
                model.titlefont = row["titlefont"].ToString();
            }
            if (row["titleurl"] != null && row["titleurl"].ToString() != "")
            {
                model.titleurl = row["titleurl"].ToString();
            }
            if (row["filename"] != null && row["filename"].ToString() != "")
            {
                model.filename = row["filename"].ToString();
            }
            if (row["filenameqz"] != null && row["filenameqz"].ToString() != "")
            {
                model.filenameqz = row["filenameqz"].ToString();
            }
            if (row["fh"] != null && row["fh"].ToString() != "")
            {
                model.fh = int.Parse(row["fh"].ToString());
            }
            if (row["groupid"] != null && row["groupid"].ToString() != "")
            {
                model.groupid = int.Parse(row["groupid"].ToString());
            }
            if (row["newstempid"] != null && row["newstempid"].ToString() != "")
            {
                model.newstempid = int.Parse(row["newstempid"].ToString());
            }
            if (row["plnum"] != null && row["plnum"].ToString() != "")
            {
                model.plnum = int.Parse(row["plnum"].ToString());
            }
            if (row["firsttitle"] != null && row["firsttitle"].ToString() != "")
            {
                model.firsttitle = int.Parse(row["firsttitle"].ToString());
            }
            if (row["isqf"] != null && row["isqf"].ToString() != "")
            {
                model.isqf = int.Parse(row["isqf"].ToString());
            }
            if (row["totaldown"] != null && row["totaldown"].ToString() != "")
            {
                model.totaldown = int.Parse(row["totaldown"].ToString());
            }
            if (row["title"] != null && row["title"].ToString() != "")
            {
                model.title = row["title"].ToString();
            }
            if (row["newstime"] != null && row["newstime"].ToString() != "")
            {
                model.newstime = DateTime.Parse(row["newstime"].ToString());
            }
            if (row["titlepic"] != null && row["titlepic"].ToString() != "")
            {
                model.titlepic = row["titlepic"].ToString();
            }
            if (row["closepl"] != null && row["closepl"].ToString() != "")
            {
                model.closepl = int.Parse(row["closepl"].ToString());
            }
            if (row["havehtml"] != null && row["havehtml"].ToString() != "")
            {
                model.havehtml = int.Parse(row["havehtml"].ToString());
            }
            if (row["lastdotime"] != null && row["lastdotime"].ToString() != "")
            {
                model.lastdotime = int.Parse(row["lastdotime"].ToString());
            }
            if (row["haveaddfen"] != null && row["haveaddfen"].ToString() != "")
            {
                model.haveaddfen = int.Parse(row["haveaddfen"].ToString());
            }
            if (row["infopfen"] != null && row["infopfen"].ToString() != "")
            {
                model.infopfen = int.Parse(row["infopfen"].ToString());
            }
            if (row["infopfennum"] != null && row["infopfennum"].ToString() != "")
            {
                model.infopfennum = int.Parse(row["infopfennum"].ToString());
            }
            if (row["votenum"] != null && row["votenum"].ToString() != "")
            {
                model.votenum = int.Parse(row["votenum"].ToString());
            }
            if (row["smalltext"] != null && row["smalltext"].ToString() != "")
            {
                model.smalltext = (string)row["smalltext"];
            }
            if (row["fuwu"] != null && row["fuwu"].ToString() != "")
            {
                model.fuwu = (string)row["fuwu"];
            }
            if (row["hangye"] != null && row["hangye"].ToString() != "")
            {
                model.hangye = (string)row["hangye"];
            }
            if (row["moshi"] != null && row["moshi"].ToString() != "")
            {
                model.moshi = row["moshi"].ToString();
            }
            if (row["leixing"] != null && row["leixing"].ToString() != "")
            {
                model.leixing = row["leixing"].ToString();
            }
            if (row["address"] != null && row["address"].ToString() != "")
            {
                model.address = row["address"].ToString();
            }
            if (row["num"] != null && row["num"].ToString() != "")
            {
                model.num = row["num"].ToString();
            }
            if (row["chengli"] != null && row["chengli"].ToString() != "")
            {
                model.chengli = row["chengli"].ToString();
            }
            if (row["faren"] != null && row["faren"].ToString() != "")
            {
                model.faren = row["faren"].ToString();
            }
            if (row["money"] != null && row["money"].ToString() != "")
            {
                model.money = row["money"].ToString();
            }
            if (row["city"] != null && row["city"].ToString() != "")
            {
                model.city = row["city"].ToString();
            }
            if (row["market"] != null && row["market"].ToString() != "")
            {
                model.market = row["market"].ToString();
            }
            if (row["oem"] != null && row["oem"].ToString() != "")
            {
                model.oem = row["oem"].ToString();
            }
            if (row["chukou"] != null && row["chukou"].ToString() != "")
            {
                model.chukou = row["chukou"].ToString();
            }
            if (row["area"] != null && row["area"].ToString() != "")
            {
                model.area = row["area"].ToString();
            }
            if (row["chanliang"] != null && row["chanliang"].ToString() != "")
            {
                model.chanliang = row["chanliang"].ToString();
            }
            if (row["person"] != null && row["person"].ToString() != "")
            {
                model.person = row["person"].ToString();
            }
            if (row["tel"] != null && row["tel"].ToString() != "")
            {
                model.tel = row["tel"].ToString();
            }
            if (row["fac"] != null && row["fac"].ToString() != "")
            {
                model.fac = row["fac"].ToString();
            }
            if (row["dizhi"] != null && row["dizhi"].ToString() != "")
            {
                model.dizhi = row["dizhi"].ToString();
            }
            if (row["zip"] != null && row["zip"].ToString() != "")
            {
                model.zip = row["zip"].ToString();
            }
            if (row["url"] != null && row["url"].ToString() != "")
            {
                model.url = row["url"].ToString();
            }
            if (row["email"] != null && row["email"].ToString() != "")
            {
                model.email = row["email"].ToString();
            }
            if (row["leibie"] != null && row["leibie"].ToString() != "")
            {
                model.leibie = row["leibie"].ToString();
            }
            if (row["zhizao"] != null && row["zhizao"].ToString() != "")
            {
                model.zhizao = row["zhizao"].ToString();
            }
            if (row["gslb"] != null && row["gslb"].ToString() != "")
            {
                model.gslb = row["gslb"].ToString();
            }
            if (row["cclb"] != null && row["cclb"].ToString() != "")
            {
                model.cclb = row["cclb"].ToString();
            }
            return model;
        }


       public  phome_ecms_gsk GetModel(int NewsID, int userid)
        {
            string sql = string.Format("select top 1  * from   phome_ecms_gsk where id={0}",NewsID);
            if (userid>0)
            {
                sql += string.Format(" and userid={0}",userid);
                
            }
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
              return   GetModelByDataRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,classid,onclick,newspath,keyboard,keyid,userid,username,ztid,checked,istop,truetime,ismember,dokey,userfen,isgood,titlefont,titleurl,filename,filenameqz,fh,groupid,newstempid,plnum,firsttitle,isqf,totaldown,title,newstime,titlepic,closepl,havehtml,lastdotime,haveaddfen,infopfen,infopfennum,votenum,smalltext,fuwu,hangye,moshi,leixing,address,num,chengli,faren,money,city,market,oem,chukou,area,chanliang,person,tel,fac,dizhi,zip,url,email,leibie,zhizao,gslb,cclb ");
			strSql.Append(" FROM phome_ecms_gsk ");

            strSql.Append(IPager.SetSqlWhere(strWhere));
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 数据分页
        /// </summary>
        public DataSet GetList(int pageindex, int pagesize, string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" * ");
            strSql.Append(" FROM phome_ecms_gsk ");
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
		#endregion  Method




        public List<phome_ecms_gsk> GetModelAll()
        {

            List<phome_ecms_gsk> arr = new List<phome_ecms_gsk>();
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
    }
}

