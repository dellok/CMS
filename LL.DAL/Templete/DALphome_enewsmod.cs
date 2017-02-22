using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Templete;
using DBUtility;//请先添加引用
namespace LL.DAL.Templete
{
	/// <summary>
	/// 数据访问类phome_enewsmod。
	/// </summary>
	public class DALphome_enewsmod:Iphome_enewsmod
	{
		public DALphome_enewsmod()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("mid", "phome_enewsmod"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int mid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from phome_enewsmod");
			strSql.Append(" where mid=@mid ");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)};
			parameters[0].Value = mid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LL.Model.Templete.phome_enewsmod model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsmod(");
			strSql.Append("mname,mtemp,mzs,cj,enter,tempvar,sonclass,searchvar,tid,tbname,qenter,mustqenterf,qmtemp,listandf,setandf,listtempvar,filef,imgf,flashf,qmname,canaddf,caneditf,dohtmlf,tobrf,definfovoteid)");
			strSql.Append(" values (");
			strSql.Append("@mname,@mtemp,@mzs,@cj,@enter,@tempvar,@sonclass,@searchvar,@tid,@tbname,@qenter,@mustqenterf,@qmtemp,@listandf,@setandf,@listtempvar,@filef,@imgf,@flashf,@qmname,@canaddf,@caneditf,@dohtmlf,@tobrf,@definfovoteid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,255),
					new SqlParameter("@mtemp", SqlDbType.NVarChar),
					new SqlParameter("@mzs", SqlDbType.NVarChar,255),
					new SqlParameter("@cj", SqlDbType.NVarChar),
					new SqlParameter("@enter", SqlDbType.NVarChar),
					new SqlParameter("@tempvar", SqlDbType.NVarChar),
					new SqlParameter("@sonclass", SqlDbType.NVarChar),
					new SqlParameter("@searchvar", SqlDbType.NVarChar,255),
					new SqlParameter("@tid", SqlDbType.Int,4),
					new SqlParameter("@tbname", SqlDbType.NVarChar,180),
					new SqlParameter("@qenter", SqlDbType.NVarChar),
					new SqlParameter("@mustqenterf", SqlDbType.NVarChar),
					new SqlParameter("@qmtemp", SqlDbType.NVarChar),
					new SqlParameter("@listandf", SqlDbType.NVarChar),
					new SqlParameter("@setandf", SqlDbType.Int,4),
					new SqlParameter("@listtempvar", SqlDbType.NVarChar),
					new SqlParameter("@filef", SqlDbType.NVarChar,255),
					new SqlParameter("@imgf", SqlDbType.NVarChar,255),
					new SqlParameter("@flashf", SqlDbType.NVarChar,255),
					new SqlParameter("@qmname", SqlDbType.NVarChar,90),
					new SqlParameter("@canaddf", SqlDbType.NVarChar),
					new SqlParameter("@caneditf", SqlDbType.NVarChar),
					new SqlParameter("@dohtmlf", SqlDbType.NVarChar),
					new SqlParameter("@tobrf", SqlDbType.NVarChar),
					new SqlParameter("@definfovoteid", SqlDbType.Int,4)};
			parameters[0].Value = model.mname;
			parameters[1].Value = model.mtemp;
			parameters[2].Value = model.mzs;
			parameters[3].Value = model.cj;
			parameters[4].Value = model.enter;
			parameters[5].Value = model.tempvar;
			parameters[6].Value = model.sonclass;
			parameters[7].Value = model.searchvar;
			parameters[8].Value = model.tid;
			parameters[9].Value = model.tbname;
			parameters[10].Value = model.qenter;
			parameters[11].Value = model.mustqenterf;
			parameters[12].Value = model.qmtemp;
			parameters[13].Value = model.listandf;
			parameters[14].Value = model.setandf;
			parameters[15].Value = model.listtempvar;
			parameters[16].Value = model.filef;
			parameters[17].Value = model.imgf;
			parameters[18].Value = model.flashf;
			parameters[19].Value = model.qmname;
			parameters[20].Value = model.canaddf;
			parameters[21].Value = model.caneditf;
			parameters[22].Value = model.dohtmlf;
			parameters[23].Value = model.tobrf;
			parameters[24].Value = model.definfovoteid;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(LL.Model.Templete.phome_enewsmod model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsmod set ");
			strSql.Append("mname=@mname,");
			strSql.Append("mtemp=@mtemp,");
			strSql.Append("mzs=@mzs,");
			strSql.Append("cj=@cj,");
			strSql.Append("enter=@enter,");
			strSql.Append("tempvar=@tempvar,");
			strSql.Append("sonclass=@sonclass,");
			strSql.Append("searchvar=@searchvar,");
			strSql.Append("tid=@tid,");
			strSql.Append("tbname=@tbname,");
			strSql.Append("qenter=@qenter,");
			strSql.Append("mustqenterf=@mustqenterf,");
			strSql.Append("qmtemp=@qmtemp,");
			strSql.Append("listandf=@listandf,");
			strSql.Append("setandf=@setandf,");
			strSql.Append("listtempvar=@listtempvar,");
			strSql.Append("filef=@filef,");
			strSql.Append("imgf=@imgf,");
			strSql.Append("flashf=@flashf,");
			strSql.Append("qmname=@qmname,");
			strSql.Append("canaddf=@canaddf,");
			strSql.Append("caneditf=@caneditf,");
			strSql.Append("dohtmlf=@dohtmlf,");
			strSql.Append("tobrf=@tobrf,");
			strSql.Append("definfovoteid=@definfovoteid");
			strSql.Append(" where mid=@mid ");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4),
					new SqlParameter("@mname", SqlDbType.NVarChar,255),
					new SqlParameter("@mtemp", SqlDbType.NVarChar),
					new SqlParameter("@mzs", SqlDbType.NVarChar,255),
					new SqlParameter("@cj", SqlDbType.NVarChar),
					new SqlParameter("@enter", SqlDbType.NVarChar),
					new SqlParameter("@tempvar", SqlDbType.NVarChar),
					new SqlParameter("@sonclass", SqlDbType.NVarChar),
					new SqlParameter("@searchvar", SqlDbType.NVarChar,255),
					new SqlParameter("@tid", SqlDbType.Int,4),
					new SqlParameter("@tbname", SqlDbType.NVarChar,180),
					new SqlParameter("@qenter", SqlDbType.NVarChar),
					new SqlParameter("@mustqenterf", SqlDbType.NVarChar),
					new SqlParameter("@qmtemp", SqlDbType.NVarChar),
					new SqlParameter("@listandf", SqlDbType.NVarChar),
					new SqlParameter("@setandf", SqlDbType.Int,4),
					new SqlParameter("@listtempvar", SqlDbType.NVarChar),
					new SqlParameter("@filef", SqlDbType.NVarChar,255),
					new SqlParameter("@imgf", SqlDbType.NVarChar,255),
					new SqlParameter("@flashf", SqlDbType.NVarChar,255),
					new SqlParameter("@qmname", SqlDbType.NVarChar,90),
					new SqlParameter("@canaddf", SqlDbType.NVarChar),
					new SqlParameter("@caneditf", SqlDbType.NVarChar),
					new SqlParameter("@dohtmlf", SqlDbType.NVarChar),
					new SqlParameter("@tobrf", SqlDbType.NVarChar),
					new SqlParameter("@definfovoteid", SqlDbType.Int,4)};
			parameters[0].Value = model.mid;
			parameters[1].Value = model.mname;
			parameters[2].Value = model.mtemp;
			parameters[3].Value = model.mzs;
			parameters[4].Value = model.cj;
			parameters[5].Value = model.enter;
			parameters[6].Value = model.tempvar;
			parameters[7].Value = model.sonclass;
			parameters[8].Value = model.searchvar;
			parameters[9].Value = model.tid;
			parameters[10].Value = model.tbname;
			parameters[11].Value = model.qenter;
			parameters[12].Value = model.mustqenterf;
			parameters[13].Value = model.qmtemp;
			parameters[14].Value = model.listandf;
			parameters[15].Value = model.setandf;
			parameters[16].Value = model.listtempvar;
			parameters[17].Value = model.filef;
			parameters[18].Value = model.imgf;
			parameters[19].Value = model.flashf;
			parameters[20].Value = model.qmname;
			parameters[21].Value = model.canaddf;
			parameters[22].Value = model.caneditf;
			parameters[23].Value = model.dohtmlf;
			parameters[24].Value = model.tobrf;
			parameters[25].Value = model.definfovoteid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int mid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsmod ");
			strSql.Append(" where mid=@mid ");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)};
			parameters[0].Value = mid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Templete.phome_enewsmod GetModel(int mid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 mid,mname,mtemp,mzs,cj,enter,tempvar,sonclass,searchvar,tid,tbname,qenter,mustqenterf,qmtemp,listandf,setandf,listtempvar,filef,imgf,flashf,qmname,canaddf,caneditf,dohtmlf,tobrf,definfovoteid from phome_enewsmod ");
			strSql.Append(" where mid=@mid ");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)};
			parameters[0].Value = mid;

			LL.Model.Templete.phome_enewsmod model=new LL.Model.Templete.phome_enewsmod();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["mid"].ToString()!="")
				{
					model.mid=int.Parse(ds.Tables[0].Rows[0]["mid"].ToString());
				}
				model.mname=ds.Tables[0].Rows[0]["mname"].ToString();
				model.mtemp=ds.Tables[0].Rows[0]["mtemp"].ToString();
				model.mzs=ds.Tables[0].Rows[0]["mzs"].ToString();
				model.cj=ds.Tables[0].Rows[0]["cj"].ToString();
				model.enter=ds.Tables[0].Rows[0]["enter"].ToString();
				model.tempvar=ds.Tables[0].Rows[0]["tempvar"].ToString();
				model.sonclass=ds.Tables[0].Rows[0]["sonclass"].ToString();
				model.searchvar=ds.Tables[0].Rows[0]["searchvar"].ToString();
				if(ds.Tables[0].Rows[0]["tid"].ToString()!="")
				{
					model.tid=int.Parse(ds.Tables[0].Rows[0]["tid"].ToString());
				}
				model.tbname=ds.Tables[0].Rows[0]["tbname"].ToString();
				model.qenter=ds.Tables[0].Rows[0]["qenter"].ToString();
				model.mustqenterf=ds.Tables[0].Rows[0]["mustqenterf"].ToString();
				model.qmtemp=ds.Tables[0].Rows[0]["qmtemp"].ToString();
				model.listandf=ds.Tables[0].Rows[0]["listandf"].ToString();
				if(ds.Tables[0].Rows[0]["setandf"].ToString()!="")
				{
					model.setandf=int.Parse(ds.Tables[0].Rows[0]["setandf"].ToString());
				}
				model.listtempvar=ds.Tables[0].Rows[0]["listtempvar"].ToString();
				model.filef=ds.Tables[0].Rows[0]["filef"].ToString();
				model.imgf=ds.Tables[0].Rows[0]["imgf"].ToString();
				model.flashf=ds.Tables[0].Rows[0]["flashf"].ToString();
				model.qmname=ds.Tables[0].Rows[0]["qmname"].ToString();
				model.canaddf=ds.Tables[0].Rows[0]["canaddf"].ToString();
				model.caneditf=ds.Tables[0].Rows[0]["caneditf"].ToString();
				model.dohtmlf=ds.Tables[0].Rows[0]["dohtmlf"].ToString();
				model.tobrf=ds.Tables[0].Rows[0]["tobrf"].ToString();
				if(ds.Tables[0].Rows[0]["definfovoteid"].ToString()!="")
				{
					model.definfovoteid=int.Parse(ds.Tables[0].Rows[0]["definfovoteid"].ToString());
				}
				return model;
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
			strSql.Append("select mid,mname,mtemp,mzs,cj,enter,tempvar,sonclass,searchvar,tid,tbname,qenter,mustqenterf,qmtemp,listandf,setandf,listtempvar,filef,imgf,flashf,qmname,canaddf,caneditf,dohtmlf,tobrf,definfovoteid ");
			strSql.Append(" FROM phome_enewsmod ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" mid,mname,mtemp,mzs,cj,enter,tempvar,sonclass,searchvar,tid,tbname,qenter,mustqenterf,qmtemp,listandf,setandf,listtempvar,filef,imgf,flashf,qmname,canaddf,caneditf,dohtmlf,tobrf,definfovoteid ");
			strSql.Append(" FROM phome_enewsmod ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "phome_enewsmod";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

