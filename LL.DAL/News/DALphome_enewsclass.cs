using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.News;
using DBUtility;
using LL.Model.News;
using System.Collections.Generic;
using LL.Model;
using LL.IDAL;

namespace LL.DAL.News
{
	
	public partial class DALphome_enewsclass:Repository<IAggregateRoot>, Iphome_enewsclass

    {
        /// <summary>
        /// 删除分类及其下的字分类
        /// </summary>
        public const string SP_PhomeNewsClass_Del = "SP_PhomeNewsClass_Del";
		public DALphome_enewsclass()
		{}
		#region  Method


      


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LL.Model.News.phome_enewsclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsclass(");
			strSql.Append("bclassid,classname,sonclass,is_zt,lencord,link_num,newstempid,onclick,listtempid,featherclass,islast,classpath,classtype,newspath,filename,filetype,openpl,openadd,newline,newshowdate,newstrlen,hotline,hotstrlen,hotshowdate,goodline,goodstrlen,goodshowdate,classurl,groupid,myorder,filename_qz,hotplline,hotplshowdate,hotplstrlen,modid,checked,docheckuser,checkuser,firstline,firststrlen,firstshowdate,bname,islist,searchtempid,tid,tbname,maxnum,checkpl,down_num,online_num,listorderf,listorder,reorderf,reorder,intro,classimg,jstempid,addinfofen,listdt,showclass,showdt,checkqadd,qaddlist,qaddgroupid,qaddshowkey,adminqinfo,doctime,classpagekey,dtlisttempid,classtempid,nreclass,nreinfo,nrejs,nottobq,ipath,addreinfo,haddlist,sametitle,definfovoteid,wburl,qeditchecked,wapstyleid)");
			strSql.Append(" values (");
			strSql.Append("@bclassid,@classname,@sonclass,@is_zt,@lencord,@link_num,@newstempid,@onclick,@listtempid,@featherclass,@islast,@classpath,@classtype,@newspath,@filename,@filetype,@openpl,@openadd,@newline,@newshowdate,@newstrlen,@hotline,@hotstrlen,@hotshowdate,@goodline,@goodstrlen,@goodshowdate,@classurl,@groupid,@myorder,@filename_qz,@hotplline,@hotplshowdate,@hotplstrlen,@modid,@checked,@docheckuser,@checkuser,@firstline,@firststrlen,@firstshowdate,@bname,@islist,@searchtempid,@tid,@tbname,@maxnum,@checkpl,@down_num,@online_num,@listorderf,@listorder,@reorderf,@reorder,@intro,@classimg,@jstempid,@addinfofen,@listdt,@showclass,@showdt,@checkqadd,@qaddlist,@qaddgroupid,@qaddshowkey,@adminqinfo,@doctime,@classpagekey,@dtlisttempid,@classtempid,@nreclass,@nreinfo,@nrejs,@nottobq,@ipath,@addreinfo,@haddlist,@sametitle,@definfovoteid,@wburl,@qeditchecked,@wapstyleid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@bclassid", SqlDbType.Int,4),
					new SqlParameter("@classname", SqlDbType.NVarChar,150),
					new SqlParameter("@sonclass", SqlDbType.NVarChar),
					new SqlParameter("@is_zt", SqlDbType.Int,4),
					new SqlParameter("@lencord", SqlDbType.Int,4),
					new SqlParameter("@link_num", SqlDbType.Int,4),
					new SqlParameter("@newstempid", SqlDbType.Int,4),
					new SqlParameter("@onclick", SqlDbType.Int,4),
					new SqlParameter("@listtempid", SqlDbType.Int,4),
					new SqlParameter("@featherclass", SqlDbType.NVarChar),
					new SqlParameter("@islast", SqlDbType.Int,4),
					new SqlParameter("@classpath", SqlDbType.NVarChar),
					new SqlParameter("@classtype", SqlDbType.NVarChar,30),
					new SqlParameter("@newspath", SqlDbType.NVarChar,60),
					new SqlParameter("@filename", SqlDbType.Int,4),
					new SqlParameter("@filetype", SqlDbType.NVarChar,30),
					new SqlParameter("@openpl", SqlDbType.Int,4),
					new SqlParameter("@openadd", SqlDbType.Int,4),
					new SqlParameter("@newline", SqlDbType.Int,4),
					new SqlParameter("@newshowdate", SqlDbType.Int,4),
					new SqlParameter("@newstrlen", SqlDbType.Int,4),
					new SqlParameter("@hotline", SqlDbType.Int,4),
					new SqlParameter("@hotstrlen", SqlDbType.Int,4),
					new SqlParameter("@hotshowdate", SqlDbType.Int,4),
					new SqlParameter("@goodline", SqlDbType.Int,4),
					new SqlParameter("@goodstrlen", SqlDbType.Int,4),
					new SqlParameter("@goodshowdate", SqlDbType.Int,4),
					new SqlParameter("@classurl", SqlDbType.NVarChar,255),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@myorder", SqlDbType.Int,4),
					new SqlParameter("@filename_qz", SqlDbType.NVarChar,60),
					new SqlParameter("@hotplline", SqlDbType.Int,4),
					new SqlParameter("@hotplshowdate", SqlDbType.Int,4),
					new SqlParameter("@hotplstrlen", SqlDbType.Int,4),
					new SqlParameter("@modid", SqlDbType.Int,4),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@docheckuser", SqlDbType.Int,4),
					new SqlParameter("@checkuser", SqlDbType.NVarChar),
					new SqlParameter("@firstline", SqlDbType.Int,4),
					new SqlParameter("@firststrlen", SqlDbType.Int,4),
					new SqlParameter("@firstshowdate", SqlDbType.Int,4),
					new SqlParameter("@bname", SqlDbType.NVarChar,150),
					new SqlParameter("@islist", SqlDbType.Int,4),
					new SqlParameter("@searchtempid", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.Int,4),
					new SqlParameter("@tbname", SqlDbType.NVarChar,180),
					new SqlParameter("@maxnum", SqlDbType.Int,4),
					new SqlParameter("@checkpl", SqlDbType.Int,4),
					new SqlParameter("@down_num", SqlDbType.Int,4),
					new SqlParameter("@online_num", SqlDbType.Int,4),
					new SqlParameter("@listorderf", SqlDbType.NVarChar,90),
					new SqlParameter("@listorder", SqlDbType.NVarChar,12),
					new SqlParameter("@reorderf", SqlDbType.NVarChar,90),
					new SqlParameter("@reorder", SqlDbType.NVarChar,12),
					new SqlParameter("@intro", SqlDbType.NVarChar),
					new SqlParameter("@classimg", SqlDbType.NVarChar,255),
					new SqlParameter("@jstempid", SqlDbType.Int,4),
					new SqlParameter("@addinfofen", SqlDbType.Int,4),
					new SqlParameter("@listdt", SqlDbType.Int,4),
					new SqlParameter("@showclass", SqlDbType.Int,4),
					new SqlParameter("@showdt", SqlDbType.Int,4),
					new SqlParameter("@checkqadd", SqlDbType.Int,4),
					new SqlParameter("@qaddlist", SqlDbType.Int,4),
					new SqlParameter("@qaddgroupid", SqlDbType.Int,4),
					new SqlParameter("@qaddshowkey", SqlDbType.Int,4),
					new SqlParameter("@adminqinfo", SqlDbType.Int,4),
					new SqlParameter("@doctime", SqlDbType.Int,4),
					new SqlParameter("@classpagekey", SqlDbType.NVarChar,255),
					new SqlParameter("@dtlisttempid", SqlDbType.Int,4),
					new SqlParameter("@classtempid", SqlDbType.Int,4),
					new SqlParameter("@nreclass", SqlDbType.Int,4),
					new SqlParameter("@nreinfo", SqlDbType.Int,4),
					new SqlParameter("@nrejs", SqlDbType.Int,4),
					new SqlParameter("@nottobq", SqlDbType.Int,4),
					new SqlParameter("@ipath", SqlDbType.NVarChar,255),
					new SqlParameter("@addreinfo", SqlDbType.Int,4),
					new SqlParameter("@haddlist", SqlDbType.Int,4),
					new SqlParameter("@sametitle", SqlDbType.Int,4),
					new SqlParameter("@definfovoteid", SqlDbType.Int,4),
					new SqlParameter("@wburl", SqlDbType.NVarChar,255),
					new SqlParameter("@qeditchecked", SqlDbType.Int,4),
					new SqlParameter("@wapstyleid", SqlDbType.Int,4)};
			parameters[0].Value = model.bclassid;
			parameters[1].Value = model.classname;
			parameters[2].Value = model.sonclass;
			parameters[3].Value = model.is_zt;
			parameters[4].Value = model.lencord;
			parameters[5].Value = model.link_num;
			parameters[6].Value = model.newstempid;
			parameters[7].Value = model.onclick;
			parameters[8].Value = model.listtempid;
			parameters[9].Value = model.featherclass;
			parameters[10].Value = model.islast;
			parameters[11].Value = model.classpath;
			parameters[12].Value = model.classtype;
			parameters[13].Value = model.newspath;
			parameters[14].Value = model.filename;
			parameters[15].Value = model.filetype;
			parameters[16].Value = model.openpl;
			parameters[17].Value = model.openadd;
			parameters[18].Value = model.newline;
			parameters[19].Value = model.newshowdate;
			parameters[20].Value = model.newstrlen;
			parameters[21].Value = model.hotline;
			parameters[22].Value = model.hotstrlen;
			parameters[23].Value = model.hotshowdate;
			parameters[24].Value = model.goodline;
			parameters[25].Value = model.goodstrlen;
			parameters[26].Value = model.goodshowdate;
			parameters[27].Value = model.classurl;
			parameters[28].Value = model.groupid;
			parameters[29].Value = model.myorder;
			parameters[30].Value = model.filename_qz;
			parameters[31].Value = model.hotplline;
			parameters[32].Value = model.hotplshowdate;
			parameters[33].Value = model.hotplstrlen;
			parameters[34].Value = model.modid;
			parameters[35].Value = model.@checked;
			parameters[36].Value = model.docheckuser;
			parameters[37].Value = model.checkuser;
			parameters[38].Value = model.firstline;
			parameters[39].Value = model.firststrlen;
			parameters[40].Value = model.firstshowdate;
			parameters[41].Value = model.bname;
			parameters[42].Value = model.islist;
			parameters[43].Value = model.searchtempid;
			parameters[44].Value = model.tid;
			parameters[45].Value = model.tbname;
			parameters[46].Value = model.maxnum;
			parameters[47].Value = model.checkpl;
			parameters[48].Value = model.down_num;
			parameters[49].Value = model.online_num;
			parameters[50].Value = model.listorderf;
			parameters[51].Value = model.listorder;
			parameters[52].Value = model.reorderf;
			parameters[53].Value = model.reorder;
			parameters[54].Value = model.intro;
			parameters[55].Value = model.classimg;
			parameters[56].Value = model.jstempid;
			parameters[57].Value = model.addinfofen;
			parameters[58].Value = model.listdt;
			parameters[59].Value = model.showclass;
			parameters[60].Value = model.showdt;
			parameters[61].Value = model.checkqadd;
			parameters[62].Value = model.qaddlist;
			parameters[63].Value = model.qaddgroupid;
			parameters[64].Value = model.qaddshowkey;
			parameters[65].Value = model.adminqinfo;
			parameters[66].Value = model.doctime;
			parameters[67].Value = model.classpagekey;
			parameters[68].Value = model.dtlisttempid;
			parameters[69].Value = model.classtempid;
			parameters[70].Value = model.nreclass;
			parameters[71].Value = model.nreinfo;
			parameters[72].Value = model.nrejs;
			parameters[73].Value = model.nottobq;
			parameters[74].Value = model.ipath;
			parameters[75].Value = model.addreinfo;
			parameters[76].Value = model.haddlist;
			parameters[77].Value = model.sametitle;
			parameters[78].Value = model.definfovoteid;
			parameters[79].Value = model.wburl;
			parameters[80].Value = model.qeditchecked;
			parameters[81].Value = model.wapstyleid;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public int  Update(LL.Model.News.phome_enewsclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsclass set ");
			strSql.Append("bclassid=@bclassid,");
			strSql.Append("classname=@classname,");
			strSql.Append("sonclass=@sonclass,");
			strSql.Append("is_zt=@is_zt,");
			strSql.Append("lencord=@lencord,");
			strSql.Append("link_num=@link_num,");
			strSql.Append("newstempid=@newstempid,");
			strSql.Append("onclick=@onclick,");
			strSql.Append("listtempid=@listtempid,");
			strSql.Append("featherclass=@featherclass,");
			strSql.Append("islast=@islast,");
			strSql.Append("classpath=@classpath,");
			strSql.Append("classtype=@classtype,");
			strSql.Append("newspath=@newspath,");
			strSql.Append("filename=@filename,");
			strSql.Append("filetype=@filetype,");
			strSql.Append("openpl=@openpl,");
			strSql.Append("openadd=@openadd,");
			strSql.Append("newline=@newline,");
			strSql.Append("newshowdate=@newshowdate,");
			strSql.Append("newstrlen=@newstrlen,");
			strSql.Append("hotline=@hotline,");
			strSql.Append("hotstrlen=@hotstrlen,");
			strSql.Append("hotshowdate=@hotshowdate,");
			strSql.Append("goodline=@goodline,");
			strSql.Append("goodstrlen=@goodstrlen,");
			strSql.Append("goodshowdate=@goodshowdate,");
			strSql.Append("classurl=@classurl,");
			strSql.Append("groupid=@groupid,");
			strSql.Append("myorder=@myorder,");
			strSql.Append("filename_qz=@filename_qz,");
			strSql.Append("hotplline=@hotplline,");
			strSql.Append("hotplshowdate=@hotplshowdate,");
			strSql.Append("hotplstrlen=@hotplstrlen,");
			strSql.Append("modid=@modid,");
			strSql.Append("checked=@checked,");
			strSql.Append("docheckuser=@docheckuser,");
			strSql.Append("checkuser=@checkuser,");
			strSql.Append("firstline=@firstline,");
			strSql.Append("firststrlen=@firststrlen,");
			strSql.Append("firstshowdate=@firstshowdate,");
			strSql.Append("bname=@bname,");
			strSql.Append("islist=@islist,");
			strSql.Append("searchtempid=@searchtempid,");
			strSql.Append("tid=@tid,");
			strSql.Append("tbname=@tbname,");
			strSql.Append("maxnum=@maxnum,");
			strSql.Append("checkpl=@checkpl,");
			strSql.Append("down_num=@down_num,");
			strSql.Append("online_num=@online_num,");
			strSql.Append("listorderf=@listorderf,");
			strSql.Append("listorder=@listorder,");
			strSql.Append("reorderf=@reorderf,");
			strSql.Append("reorder=@reorder,");
			strSql.Append("intro=@intro,");
			strSql.Append("classimg=@classimg,");
			strSql.Append("jstempid=@jstempid,");
			strSql.Append("addinfofen=@addinfofen,");
			strSql.Append("listdt=@listdt,");
			strSql.Append("showclass=@showclass,");
			strSql.Append("showdt=@showdt,");
			strSql.Append("checkqadd=@checkqadd,");
			strSql.Append("qaddlist=@qaddlist,");
			strSql.Append("qaddgroupid=@qaddgroupid,");
			strSql.Append("qaddshowkey=@qaddshowkey,");
			strSql.Append("adminqinfo=@adminqinfo,");
			strSql.Append("doctime=@doctime,");
			strSql.Append("classpagekey=@classpagekey,");
			strSql.Append("dtlisttempid=@dtlisttempid,");
			strSql.Append("classtempid=@classtempid,");
			strSql.Append("nreclass=@nreclass,");
			strSql.Append("nreinfo=@nreinfo,");
			strSql.Append("nrejs=@nrejs,");
			strSql.Append("nottobq=@nottobq,");
			strSql.Append("ipath=@ipath,");
			strSql.Append("addreinfo=@addreinfo,");
			strSql.Append("haddlist=@haddlist,");
			strSql.Append("sametitle=@sametitle,");
			strSql.Append("definfovoteid=@definfovoteid,");
			strSql.Append("wburl=@wburl,");
			strSql.Append("qeditchecked=@qeditchecked,");
			strSql.Append("wapstyleid=@wapstyleid");
			strSql.Append(" where classid=@classid");
			SqlParameter[] parameters = {
					new SqlParameter("@bclassid", SqlDbType.Int,4),
					new SqlParameter("@classname", SqlDbType.NVarChar,150),
					new SqlParameter("@sonclass", SqlDbType.NVarChar),
					new SqlParameter("@is_zt", SqlDbType.Int,4),
					new SqlParameter("@lencord", SqlDbType.Int,4),
					new SqlParameter("@link_num", SqlDbType.Int,4),
					new SqlParameter("@newstempid", SqlDbType.Int,4),
					new SqlParameter("@onclick", SqlDbType.Int,4),
					new SqlParameter("@listtempid", SqlDbType.Int,4),
					new SqlParameter("@featherclass", SqlDbType.NVarChar),
					new SqlParameter("@islast", SqlDbType.Int,4),
					new SqlParameter("@classpath", SqlDbType.NVarChar),
					new SqlParameter("@classtype", SqlDbType.NVarChar,30),
					new SqlParameter("@newspath", SqlDbType.NVarChar,60),
					new SqlParameter("@filename", SqlDbType.Int,4),
					new SqlParameter("@filetype", SqlDbType.NVarChar,30),
					new SqlParameter("@openpl", SqlDbType.Int,4),
					new SqlParameter("@openadd", SqlDbType.Int,4),
					new SqlParameter("@newline", SqlDbType.Int,4),
					new SqlParameter("@newshowdate", SqlDbType.Int,4),
					new SqlParameter("@newstrlen", SqlDbType.Int,4),
					new SqlParameter("@hotline", SqlDbType.Int,4),
					new SqlParameter("@hotstrlen", SqlDbType.Int,4),
					new SqlParameter("@hotshowdate", SqlDbType.Int,4),
					new SqlParameter("@goodline", SqlDbType.Int,4),
					new SqlParameter("@goodstrlen", SqlDbType.Int,4),
					new SqlParameter("@goodshowdate", SqlDbType.Int,4),
					new SqlParameter("@classurl", SqlDbType.NVarChar,255),
					new SqlParameter("@groupid", SqlDbType.Int,4),
					new SqlParameter("@myorder", SqlDbType.Int,4),
					new SqlParameter("@filename_qz", SqlDbType.NVarChar,60),
					new SqlParameter("@hotplline", SqlDbType.Int,4),
					new SqlParameter("@hotplshowdate", SqlDbType.Int,4),
					new SqlParameter("@hotplstrlen", SqlDbType.Int,4),
					new SqlParameter("@modid", SqlDbType.Int,4),
					new SqlParameter("@checked", SqlDbType.Int,4),
					new SqlParameter("@docheckuser", SqlDbType.Int,4),
					new SqlParameter("@checkuser", SqlDbType.NVarChar),
					new SqlParameter("@firstline", SqlDbType.Int,4),
					new SqlParameter("@firststrlen", SqlDbType.Int,4),
					new SqlParameter("@firstshowdate", SqlDbType.Int,4),
					new SqlParameter("@bname", SqlDbType.NVarChar,150),
					new SqlParameter("@islist", SqlDbType.Int,4),
					new SqlParameter("@searchtempid", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.Int,4),
					new SqlParameter("@tbname", SqlDbType.NVarChar,180),
					new SqlParameter("@maxnum", SqlDbType.Int,4),
					new SqlParameter("@checkpl", SqlDbType.Int,4),
					new SqlParameter("@down_num", SqlDbType.Int,4),
					new SqlParameter("@online_num", SqlDbType.Int,4),
					new SqlParameter("@listorderf", SqlDbType.NVarChar,90),
					new SqlParameter("@listorder", SqlDbType.NVarChar,12),
					new SqlParameter("@reorderf", SqlDbType.NVarChar,90),
					new SqlParameter("@reorder", SqlDbType.NVarChar,12),
					new SqlParameter("@intro", SqlDbType.NVarChar),
					new SqlParameter("@classimg", SqlDbType.NVarChar,255),
					new SqlParameter("@jstempid", SqlDbType.Int,4),
					new SqlParameter("@addinfofen", SqlDbType.Int,4),
					new SqlParameter("@listdt", SqlDbType.Int,4),
					new SqlParameter("@showclass", SqlDbType.Int,4),
					new SqlParameter("@showdt", SqlDbType.Int,4),
					new SqlParameter("@checkqadd", SqlDbType.Int,4),
					new SqlParameter("@qaddlist", SqlDbType.Int,4),
					new SqlParameter("@qaddgroupid", SqlDbType.Int,4),
					new SqlParameter("@qaddshowkey", SqlDbType.Int,4),
					new SqlParameter("@adminqinfo", SqlDbType.Int,4),
					new SqlParameter("@doctime", SqlDbType.Int,4),
					new SqlParameter("@classpagekey", SqlDbType.NVarChar,255),
					new SqlParameter("@dtlisttempid", SqlDbType.Int,4),
					new SqlParameter("@classtempid", SqlDbType.Int,4),
					new SqlParameter("@nreclass", SqlDbType.Int,4),
					new SqlParameter("@nreinfo", SqlDbType.Int,4),
					new SqlParameter("@nrejs", SqlDbType.Int,4),
					new SqlParameter("@nottobq", SqlDbType.Int,4),
					new SqlParameter("@ipath", SqlDbType.NVarChar,255),
					new SqlParameter("@addreinfo", SqlDbType.Int,4),
					new SqlParameter("@haddlist", SqlDbType.Int,4),
					new SqlParameter("@sametitle", SqlDbType.Int,4),
					new SqlParameter("@definfovoteid", SqlDbType.Int,4),
					new SqlParameter("@wburl", SqlDbType.NVarChar,255),
					new SqlParameter("@qeditchecked", SqlDbType.Int,4),
					new SqlParameter("@wapstyleid", SqlDbType.Int,4),
					new SqlParameter("@classid", SqlDbType.Int,4)};
			parameters[0].Value = model.bclassid;
			parameters[1].Value = model.classname;
			parameters[2].Value = model.sonclass;
			parameters[3].Value = model.is_zt;
			parameters[4].Value = model.lencord;
			parameters[5].Value = model.link_num;
			parameters[6].Value = model.newstempid;
			parameters[7].Value = model.onclick;
			parameters[8].Value = model.listtempid;
			parameters[9].Value = model.featherclass;
			parameters[10].Value = model.islast;
			parameters[11].Value = model.classpath;
			parameters[12].Value = model.classtype;
			parameters[13].Value = model.newspath;
			parameters[14].Value = model.filename;
			parameters[15].Value = model.filetype;
			parameters[16].Value = model.openpl;
			parameters[17].Value = model.openadd;
			parameters[18].Value = model.newline;
			parameters[19].Value = model.newshowdate;
			parameters[20].Value = model.newstrlen;
			parameters[21].Value = model.hotline;
			parameters[22].Value = model.hotstrlen;
			parameters[23].Value = model.hotshowdate;
			parameters[24].Value = model.goodline;
			parameters[25].Value = model.goodstrlen;
			parameters[26].Value = model.goodshowdate;
			parameters[27].Value = model.classurl;
			parameters[28].Value = model.groupid;
			parameters[29].Value = model.myorder;
			parameters[30].Value = model.filename_qz;
			parameters[31].Value = model.hotplline;
			parameters[32].Value = model.hotplshowdate;
			parameters[33].Value = model.hotplstrlen;
			parameters[34].Value = model.modid;
			parameters[35].Value = model.@checked;
			parameters[36].Value = model.docheckuser;
			parameters[37].Value = model.checkuser;
			parameters[38].Value = model.firstline;
			parameters[39].Value = model.firststrlen;
			parameters[40].Value = model.firstshowdate;
			parameters[41].Value = model.bname;
			parameters[42].Value = model.islist;
			parameters[43].Value = model.searchtempid;
			parameters[44].Value = model.tid;
			parameters[45].Value = model.tbname;
			parameters[46].Value = model.maxnum;
			parameters[47].Value = model.checkpl;
			parameters[48].Value = model.down_num;
			parameters[49].Value = model.online_num;
			parameters[50].Value = model.listorderf;
			parameters[51].Value = model.listorder;
			parameters[52].Value = model.reorderf;
			parameters[53].Value = model.reorder;
			parameters[54].Value = model.intro;
			parameters[55].Value = model.classimg;
			parameters[56].Value = model.jstempid;
			parameters[57].Value = model.addinfofen;
			parameters[58].Value = model.listdt;
			parameters[59].Value = model.showclass;
			parameters[60].Value = model.showdt;
			parameters[61].Value = model.checkqadd;
			parameters[62].Value = model.qaddlist;
			parameters[63].Value = model.qaddgroupid;
			parameters[64].Value = model.qaddshowkey;
			parameters[65].Value = model.adminqinfo;
			parameters[66].Value = model.doctime;
			parameters[67].Value = model.classpagekey;
			parameters[68].Value = model.dtlisttempid;
			parameters[69].Value = model.classtempid;
			parameters[70].Value = model.nreclass;
			parameters[71].Value = model.nreinfo;
			parameters[72].Value = model.nrejs;
			parameters[73].Value = model.nottobq;
			parameters[74].Value = model.ipath;
			parameters[75].Value = model.addreinfo;
			parameters[76].Value = model.haddlist;
			parameters[77].Value = model.sametitle;
			parameters[78].Value = model.definfovoteid;
			parameters[79].Value = model.wburl;
			parameters[80].Value = model.qeditchecked;
			parameters[81].Value = model.wapstyleid;
			parameters[82].Value = model.classid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return rows;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int classid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsclass ");
			strSql.Append(" where classid=@classid");
			SqlParameter[] parameters = {
					new SqlParameter("@classid", SqlDbType.Int,4)
};
			parameters[0].Value = classid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return rows;
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public int  DeleteList(string classidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsclass ");
			strSql.Append(" where classid in ("+classidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
            return rows;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.News.phome_enewsclass GetModel(int classid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 classid,bclassid,classname,sonclass,is_zt,lencord,link_num,newstempid,onclick,listtempid,featherclass,islast,classpath,classtype,newspath,filename,filetype,openpl,openadd,newline,newshowdate,newstrlen,hotline,hotstrlen,hotshowdate,goodline,goodstrlen,goodshowdate,classurl,groupid,myorder,filename_qz,hotplline,hotplshowdate,hotplstrlen,modid,checked,docheckuser,checkuser,firstline,firststrlen,firstshowdate,bname,islist,searchtempid,tid,tbname,maxnum,checkpl,down_num,online_num,listorderf,listorder,reorderf,reorder,intro,classimg,jstempid,addinfofen,listdt,showclass,showdt,checkqadd,qaddlist,qaddgroupid,qaddshowkey,adminqinfo,doctime,classpagekey,dtlisttempid,classtempid,nreclass,nreinfo,nrejs,nottobq,ipath,addreinfo,haddlist,sametitle,definfovoteid,wburl,qeditchecked,wapstyleid from phome_enewsclass ");
			strSql.Append(" where classid=@classid");
			SqlParameter[] parameters = {
					new SqlParameter("@classid", SqlDbType.Int,4)
};
			parameters[0].Value = classid;

			LL.Model.News.phome_enewsclass model=new LL.Model.News.phome_enewsclass();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{

                return GetModelByDataRow(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


        public phome_enewsclass GetModelByDataRow(DataRow row)
        {
            phome_enewsclass model = new phome_enewsclass();

            if (row["classid"] != null && row["classid"].ToString() != "")
            {
                model.classid = int.Parse(row["classid"].ToString());
            }
            if (row["bclassid"] != null && row["bclassid"].ToString() != "")
            {
                model.bclassid = int.Parse(row["bclassid"].ToString());
            }
            if (row["classname"] != null && row["classname"].ToString() != "")
            {
                model.classname = row["classname"].ToString();
            }
            if (row["sonclass"] != null && row["sonclass"].ToString() != "")
            {
                model.sonclass = row["sonclass"].ToString();
            }
            if (row["is_zt"] != null && row["is_zt"].ToString() != "")
            {
                model.is_zt = int.Parse(row["is_zt"].ToString());
            }
            if (row["lencord"] != null && row["lencord"].ToString() != "")
            {
                model.lencord = int.Parse(row["lencord"].ToString());
            }
            if (row["link_num"] != null && row["link_num"].ToString() != "")
            {
                model.link_num = int.Parse(row["link_num"].ToString());
            }
            if (row["newstempid"] != null && row["newstempid"].ToString() != "")
            {
                model.newstempid = int.Parse(row["newstempid"].ToString());
            }
            if (row["onclick"] != null && row["onclick"].ToString() != "")
            {
                model.onclick = int.Parse(row["onclick"].ToString());
            }
            if (row["listtempid"] != null && row["listtempid"].ToString() != "")
            {
                model.listtempid = int.Parse(row["listtempid"].ToString());
            }
            if (row["featherclass"] != null && row["featherclass"].ToString() != "")
            {
                model.featherclass = row["featherclass"].ToString();
            }
            if (row["islast"] != null && row["islast"].ToString() != "")
            {
                model.islast = int.Parse(row["islast"].ToString());
            }
            if (row["classpath"] != null && row["classpath"].ToString() != "")
            {
                model.classpath = row["classpath"].ToString();
            }
            if (row["classtype"] != null && row["classtype"].ToString() != "")
            {
                model.classtype = row["classtype"].ToString();
            }
            if (row["newspath"] != null && row["newspath"].ToString() != "")
            {
                model.newspath = row["newspath"].ToString();
            }
            if (row["filename"] != null && row["filename"].ToString() != "")
            {
                model.filename = int.Parse(row["filename"].ToString());
            }
            if (row["filetype"] != null && row["filetype"].ToString() != "")
            {
                model.filetype = row["filetype"].ToString();
            }
            if (row["openpl"] != null && row["openpl"].ToString() != "")
            {
                model.openpl = int.Parse(row["openpl"].ToString());
            }
            if (row["openadd"] != null && row["openadd"].ToString() != "")
            {
                model.openadd = int.Parse(row["openadd"].ToString());
            }
            if (row["newline"] != null && row["newline"].ToString() != "")
            {
                model.newline = int.Parse(row["newline"].ToString());
            }
            if (row["newshowdate"] != null && row["newshowdate"].ToString() != "")
            {
                model.newshowdate = int.Parse(row["newshowdate"].ToString());
            }
            if (row["newstrlen"] != null && row["newstrlen"].ToString() != "")
            {
                model.newstrlen = int.Parse(row["newstrlen"].ToString());
            }
            if (row["hotline"] != null && row["hotline"].ToString() != "")
            {
                model.hotline = int.Parse(row["hotline"].ToString());
            }
            if (row["hotstrlen"] != null && row["hotstrlen"].ToString() != "")
            {
                model.hotstrlen = int.Parse(row["hotstrlen"].ToString());
            }
            if (row["hotshowdate"] != null && row["hotshowdate"].ToString() != "")
            {
                model.hotshowdate = int.Parse(row["hotshowdate"].ToString());
            }
            if (row["goodline"] != null && row["goodline"].ToString() != "")
            {
                model.goodline = int.Parse(row["goodline"].ToString());
            }
            if (row["goodstrlen"] != null && row["goodstrlen"].ToString() != "")
            {
                model.goodstrlen = int.Parse(row["goodstrlen"].ToString());
            }
            if (row["goodshowdate"] != null && row["goodshowdate"].ToString() != "")
            {
                model.goodshowdate = int.Parse(row["goodshowdate"].ToString());
            }
            if (row["classurl"] != null && row["classurl"].ToString() != "")
            {
                model.classurl = row["classurl"].ToString();
            }
            if (row["groupid"] != null && row["groupid"].ToString() != "")
            {
                model.groupid = int.Parse(row["groupid"].ToString());
            }
            if (row["myorder"] != null && row["myorder"].ToString() != "")
            {
                model.myorder = int.Parse(row["myorder"].ToString());
            }
            if (row["filename_qz"] != null && row["filename_qz"].ToString() != "")
            {
                model.filename_qz = row["filename_qz"].ToString();
            }
            if (row["hotplline"] != null && row["hotplline"].ToString() != "")
            {
                model.hotplline = int.Parse(row["hotplline"].ToString());
            }
            if (row["hotplshowdate"] != null && row["hotplshowdate"].ToString() != "")
            {
                model.hotplshowdate = int.Parse(row["hotplshowdate"].ToString());
            }
            if (row["hotplstrlen"] != null && row["hotplstrlen"].ToString() != "")
            {
                model.hotplstrlen = int.Parse(row["hotplstrlen"].ToString());
            }
            if (row["modid"] != null && row["modid"].ToString() != "")
            {
                model.modid = int.Parse(row["modid"].ToString());
            }
            if (row["checked"] != null && row["checked"].ToString() != "")
            {
                model.@checked = int.Parse(row["checked"].ToString());
            }
            if (row["docheckuser"] != null && row["docheckuser"].ToString() != "")
            {
                model.docheckuser = int.Parse(row["docheckuser"].ToString());
            }
            if (row["checkuser"] != null && row["checkuser"].ToString() != "")
            {
                model.checkuser = row["checkuser"].ToString();
            }
            if (row["firstline"] != null && row["firstline"].ToString() != "")
            {
                model.firstline = int.Parse(row["firstline"].ToString());
            }
            if (row["firststrlen"] != null && row["firststrlen"].ToString() != "")
            {
                model.firststrlen = int.Parse(row["firststrlen"].ToString());
            }
            if (row["firstshowdate"] != null && row["firstshowdate"].ToString() != "")
            {
                model.firstshowdate = int.Parse(row["firstshowdate"].ToString());
            }
            if (row["bname"] != null && row["bname"].ToString() != "")
            {
                model.bname = row["bname"].ToString();
            }
            if (row["islist"] != null && row["islist"].ToString() != "")
            {
                model.islist = int.Parse(row["islist"].ToString());
            }
            if (row["searchtempid"] != null && row["searchtempid"].ToString() != "")
            {
                model.searchtempid = int.Parse(row["searchtempid"].ToString());
            }
            if (row["tid"] != null && row["tid"].ToString() != "")
            {
                model.tid = int.Parse(row["tid"].ToString());
            }
            if (row["tbname"] != null && row["tbname"].ToString() != "")
            {
                model.tbname = row["tbname"].ToString();
            }
            if (row["maxnum"] != null && row["maxnum"].ToString() != "")
            {
                model.maxnum = int.Parse(row["maxnum"].ToString());
            }
            if (row["checkpl"] != null && row["checkpl"].ToString() != "")
            {
                model.checkpl = int.Parse(row["checkpl"].ToString());
            }
            if (row["down_num"] != null && row["down_num"].ToString() != "")
            {
                model.down_num = int.Parse(row["down_num"].ToString());
            }
            if (row["online_num"] != null && row["online_num"].ToString() != "")
            {
                model.online_num = int.Parse(row["online_num"].ToString());
            }
            if (row["listorderf"] != null && row["listorderf"].ToString() != "")
            {
                model.listorderf = row["listorderf"].ToString();
            }
            if (row["listorder"] != null && row["listorder"].ToString() != "")
            {
                model.listorder = row["listorder"].ToString();
            }
            if (row["reorderf"] != null && row["reorderf"].ToString() != "")
            {
                model.reorderf = row["reorderf"].ToString();
            }
            if (row["reorder"] != null && row["reorder"].ToString() != "")
            {
                model.reorder = row["reorder"].ToString();
            }
            if (row["intro"] != null && row["intro"].ToString() != "")
            {
                model.intro = row["intro"].ToString();
            }
            if (row["classimg"] != null && row["classimg"].ToString() != "")
            {
                model.classimg = row["classimg"].ToString();
            }
            if (row["jstempid"] != null && row["jstempid"].ToString() != "")
            {
                model.jstempid = int.Parse(row["jstempid"].ToString());
            }
            if (row["addinfofen"] != null && row["addinfofen"].ToString() != "")
            {
                model.addinfofen = int.Parse(row["addinfofen"].ToString());
            }
            if (row["listdt"] != null && row["listdt"].ToString() != "")
            {
                model.listdt = int.Parse(row["listdt"].ToString());
            }
            if (row["showclass"] != null && row["showclass"].ToString() != "")
            {
                model.showclass = int.Parse(row["showclass"].ToString());
            }
            if (row["showdt"] != null && row["showdt"].ToString() != "")
            {
                model.showdt = int.Parse(row["showdt"].ToString());
            }
            if (row["checkqadd"] != null && row["checkqadd"].ToString() != "")
            {
                model.checkqadd = int.Parse(row["checkqadd"].ToString());
            }
            if (row["qaddlist"] != null && row["qaddlist"].ToString() != "")
            {
                model.qaddlist = int.Parse(row["qaddlist"].ToString());
            }
            if (row["qaddgroupid"] != null && row["qaddgroupid"].ToString() != "")
            {
                model.qaddgroupid = int.Parse(row["qaddgroupid"].ToString());
            }
            if (row["qaddshowkey"] != null && row["qaddshowkey"].ToString() != "")
            {
                model.qaddshowkey = int.Parse(row["qaddshowkey"].ToString());
            }
            if (row["adminqinfo"] != null && row["adminqinfo"].ToString() != "")
            {
                model.adminqinfo = int.Parse(row["adminqinfo"].ToString());
            }
            if (row["doctime"] != null && row["doctime"].ToString() != "")
            {
                model.doctime = int.Parse(row["doctime"].ToString());
            }
            if (row["classpagekey"] != null && row["classpagekey"].ToString() != "")
            {
                model.classpagekey = row["classpagekey"].ToString();
            }
            if (row["dtlisttempid"] != null && row["dtlisttempid"].ToString() != "")
            {
                model.dtlisttempid = int.Parse(row["dtlisttempid"].ToString());
            }
            if (row["classtempid"] != null && row["classtempid"].ToString() != "")
            {
                model.classtempid = int.Parse(row["classtempid"].ToString());
            }
            if (row["nreclass"] != null && row["nreclass"].ToString() != "")
            {
                model.nreclass = int.Parse(row["nreclass"].ToString());
            }
            if (row["nreinfo"] != null && row["nreinfo"].ToString() != "")
            {
                model.nreinfo = int.Parse(row["nreinfo"].ToString());
            }
            if (row["nrejs"] != null && row["nrejs"].ToString() != "")
            {
                model.nrejs = int.Parse(row["nrejs"].ToString());
            }
            if (row["nottobq"] != null && row["nottobq"].ToString() != "")
            {
                model.nottobq = int.Parse(row["nottobq"].ToString());
            }
            if (row["ipath"] != null && row["ipath"].ToString() != "")
            {
                model.ipath = row["ipath"].ToString();
            }
            if (row["addreinfo"] != null && row["addreinfo"].ToString() != "")
            {
                model.addreinfo = int.Parse(row["addreinfo"].ToString());
            }
            if (row["haddlist"] != null && row["haddlist"].ToString() != "")
            {
                model.haddlist = int.Parse(row["haddlist"].ToString());
            }
            if (row["sametitle"] != null && row["sametitle"].ToString() != "")
            {
                model.sametitle = int.Parse(row["sametitle"].ToString());
            }
            if (row["definfovoteid"] != null && row["definfovoteid"].ToString() != "")
            {
                model.definfovoteid = int.Parse(row["definfovoteid"].ToString());
            }
            if (row["wburl"] != null && row["wburl"].ToString() != "")
            {
                model.wburl = row["wburl"].ToString();
            }
            if (row["qeditchecked"] != null && row["qeditchecked"].ToString() != "")
            {
                model.qeditchecked = int.Parse(row["qeditchecked"].ToString());
            }
            if (row["wapstyleid"] != null && row["wapstyleid"].ToString() != "")
            {
                model.wapstyleid = int.Parse(row["wapstyleid"].ToString());
            }

            return model;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select classid,bclassid,classname,sonclass,is_zt,lencord,link_num,newstempid,onclick,listtempid,featherclass,islast,classpath,classtype,newspath,filename,filetype,openpl,openadd,newline,newshowdate,newstrlen,hotline,hotstrlen,hotshowdate,goodline,goodstrlen,goodshowdate,classurl,groupid,myorder,filename_qz,hotplline,hotplshowdate,hotplstrlen,modid,checked,docheckuser,checkuser,firstline,firststrlen,firstshowdate,bname,islist,searchtempid,tid,tbname,maxnum,checkpl,down_num,online_num,listorderf,listorder,reorderf,reorder,intro,classimg,jstempid,addinfofen,listdt,showclass,showdt,checkqadd,qaddlist,qaddgroupid,qaddshowkey,adminqinfo,doctime,classpagekey,dtlisttempid,classtempid,nreclass,nreinfo,nrejs,nottobq,ipath,addreinfo,haddlist,sametitle,definfovoteid,wburl,qeditchecked,wapstyleid ");
			strSql.Append(" FROM phome_enewsclass ");
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
            strSql.Append(" FROM phome_enewsclass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }


            IPager pager = new IPager();

            pager.TableName = strSql.ToString();
            pager.PrimaryKeyField = "classid";

            if (!string.IsNullOrEmpty(orderby))
            {

                pager.OrderBy = orderby;
            }




            pager.PageIndex = pageindex;
            pager.PageSize = pagesize;



            return pager.GetResult();
        }

     public    int DeleteAndSonNode(int id)
        {
            int intR = 0;
            //删除子项
            SqlParameter[] parameters = { new SqlParameter("@classid", System.Data.SqlDbType.Int) };
            parameters[0].Value = id;

            DBUtility.DbHelperSQL.RunProcedure(SP_PhomeNewsClass_Del, parameters, out intR);
            return intR;
     
     
        }
		#endregion  Method




     public List<phome_enewsclass> GetModelAll()
     {
         List<phome_enewsclass> arr = new List<phome_enewsclass>();
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

