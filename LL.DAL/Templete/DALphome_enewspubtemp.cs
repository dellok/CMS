using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL.Templete;
using DBUtility;
namespace LL.DAL.Templete
{
	/// <summary>
	/// 数据访问类:phome_enewspubtemp
	/// </summary>
	public partial class DALphome_enewspubtemp:Iphome_enewspubtemp
	{
		public DALphome_enewspubtemp()
		{}
		#region  Method

		


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LL.Model.Templete.phome_enewspubtemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewspubtemp(");
			strSql.Append("id,indextemp,pllisttemp,cptemp,searchtemp,searchjstemp,searchjstemp1,otherlinktemp,printtemp,downsofttemp,onlinemovietemp,listpagetemp,gbooktemp,loginiframe,otherlinktempsub,otherlinktempdate,loginjstemp)");
			strSql.Append(" values (");
			strSql.Append("@id,@indextemp,@pllisttemp,@cptemp,@searchtemp,@searchjstemp,@searchjstemp1,@otherlinktemp,@printtemp,@downsofttemp,@onlinemovietemp,@listpagetemp,@gbooktemp,@loginiframe,@otherlinktempsub,@otherlinktempdate,@loginjstemp)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@indextemp", SqlDbType.NVarChar),
					new SqlParameter("@pllisttemp", SqlDbType.NVarChar),
					new SqlParameter("@cptemp", SqlDbType.NVarChar),
					new SqlParameter("@searchtemp", SqlDbType.NVarChar),
					new SqlParameter("@searchjstemp", SqlDbType.NVarChar),
					new SqlParameter("@searchjstemp1", SqlDbType.NVarChar),
					new SqlParameter("@otherlinktemp", SqlDbType.NVarChar),
					new SqlParameter("@printtemp", SqlDbType.NVarChar),
					new SqlParameter("@downsofttemp", SqlDbType.NVarChar),
					new SqlParameter("@onlinemovietemp", SqlDbType.NVarChar),
					new SqlParameter("@listpagetemp", SqlDbType.NVarChar),
					new SqlParameter("@gbooktemp", SqlDbType.NVarChar),
					new SqlParameter("@loginiframe", SqlDbType.NVarChar),
					new SqlParameter("@otherlinktempsub", SqlDbType.Int,4),
					new SqlParameter("@otherlinktempdate", SqlDbType.NVarChar,60),
					new SqlParameter("@loginjstemp", SqlDbType.NVarChar)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.indextemp;
			parameters[2].Value = model.pllisttemp;
			parameters[3].Value = model.cptemp;
			parameters[4].Value = model.searchtemp;
			parameters[5].Value = model.searchjstemp;
			parameters[6].Value = model.searchjstemp1;
			parameters[7].Value = model.otherlinktemp;
			parameters[8].Value = model.printtemp;
			parameters[9].Value = model.downsofttemp;
			parameters[10].Value = model.onlinemovietemp;
			parameters[11].Value = model.listpagetemp;
			parameters[12].Value = model.gbooktemp;
			parameters[13].Value = model.loginiframe;
			parameters[14].Value = model.otherlinktempsub;
			parameters[15].Value = model.otherlinktempdate;
			parameters[16].Value = model.loginjstemp;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(LL.Model.Templete.phome_enewspubtemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewspubtemp set ");
			strSql.Append("indextemp=@indextemp,");
			strSql.Append("pllisttemp=@pllisttemp,");
			strSql.Append("cptemp=@cptemp,");
			strSql.Append("searchtemp=@searchtemp,");
			strSql.Append("searchjstemp=@searchjstemp,");
			strSql.Append("searchjstemp1=@searchjstemp1,");
			strSql.Append("otherlinktemp=@otherlinktemp,");
			strSql.Append("printtemp=@printtemp,");
			strSql.Append("downsofttemp=@downsofttemp,");
			strSql.Append("onlinemovietemp=@onlinemovietemp,");
			strSql.Append("listpagetemp=@listpagetemp,");
			strSql.Append("gbooktemp=@gbooktemp,");
			strSql.Append("loginiframe=@loginiframe,");
			strSql.Append("otherlinktempsub=@otherlinktempsub,");
			strSql.Append("otherlinktempdate=@otherlinktempdate,");
			strSql.Append("loginjstemp=@loginjstemp");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@indextemp", SqlDbType.NVarChar),
					new SqlParameter("@pllisttemp", SqlDbType.NVarChar),
					new SqlParameter("@cptemp", SqlDbType.NVarChar),
					new SqlParameter("@searchtemp", SqlDbType.NVarChar),
					new SqlParameter("@searchjstemp", SqlDbType.NVarChar),
					new SqlParameter("@searchjstemp1", SqlDbType.NVarChar),
					new SqlParameter("@otherlinktemp", SqlDbType.NVarChar),
					new SqlParameter("@printtemp", SqlDbType.NVarChar),
					new SqlParameter("@downsofttemp", SqlDbType.NVarChar),
					new SqlParameter("@onlinemovietemp", SqlDbType.NVarChar),
					new SqlParameter("@listpagetemp", SqlDbType.NVarChar),
					new SqlParameter("@gbooktemp", SqlDbType.NVarChar),
					new SqlParameter("@loginiframe", SqlDbType.NVarChar),
					new SqlParameter("@otherlinktempsub", SqlDbType.Int,4),
					new SqlParameter("@otherlinktempdate", SqlDbType.NVarChar,60),
					new SqlParameter("@loginjstemp", SqlDbType.NVarChar),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.indextemp;
			parameters[1].Value = model.pllisttemp;
			parameters[2].Value = model.cptemp;
			parameters[3].Value = model.searchtemp;
			parameters[4].Value = model.searchjstemp;
			parameters[5].Value = model.searchjstemp1;
			parameters[6].Value = model.otherlinktemp;
			parameters[7].Value = model.printtemp;
			parameters[8].Value = model.downsofttemp;
			parameters[9].Value = model.onlinemovietemp;
			parameters[10].Value = model.listpagetemp;
			parameters[11].Value = model.gbooktemp;
			parameters[12].Value = model.loginiframe;
			parameters[13].Value = model.otherlinktempsub;
			parameters[14].Value = model.otherlinktempdate;
			parameters[15].Value = model.loginjstemp;
			parameters[16].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

            return rows;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewspubtemp ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

            return rows;
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public int  DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewspubtemp ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());

            return rows;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Templete.phome_enewspubtemp GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,indextemp,pllisttemp,cptemp,searchtemp,searchjstemp,searchjstemp1,otherlinktemp,printtemp,downsofttemp,onlinemovietemp,listpagetemp,gbooktemp,loginiframe,otherlinktempsub,otherlinktempdate,loginjstemp from phome_enewspubtemp ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			LL.Model.Templete.phome_enewspubtemp model=new LL.Model.Templete.phome_enewspubtemp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["indextemp"]!=null && ds.Tables[0].Rows[0]["indextemp"].ToString()!="")
				{
					model.indextemp=ds.Tables[0].Rows[0]["indextemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pllisttemp"]!=null && ds.Tables[0].Rows[0]["pllisttemp"].ToString()!="")
				{
					model.pllisttemp=ds.Tables[0].Rows[0]["pllisttemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cptemp"]!=null && ds.Tables[0].Rows[0]["cptemp"].ToString()!="")
				{
					model.cptemp=ds.Tables[0].Rows[0]["cptemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["searchtemp"]!=null && ds.Tables[0].Rows[0]["searchtemp"].ToString()!="")
				{
					model.searchtemp=ds.Tables[0].Rows[0]["searchtemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["searchjstemp"]!=null && ds.Tables[0].Rows[0]["searchjstemp"].ToString()!="")
				{
					model.searchjstemp=ds.Tables[0].Rows[0]["searchjstemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["searchjstemp1"]!=null && ds.Tables[0].Rows[0]["searchjstemp1"].ToString()!="")
				{
					model.searchjstemp1=ds.Tables[0].Rows[0]["searchjstemp1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["otherlinktemp"]!=null && ds.Tables[0].Rows[0]["otherlinktemp"].ToString()!="")
				{
					model.otherlinktemp=ds.Tables[0].Rows[0]["otherlinktemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["printtemp"]!=null && ds.Tables[0].Rows[0]["printtemp"].ToString()!="")
				{
					model.printtemp=ds.Tables[0].Rows[0]["printtemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["downsofttemp"]!=null && ds.Tables[0].Rows[0]["downsofttemp"].ToString()!="")
				{
					model.downsofttemp=ds.Tables[0].Rows[0]["downsofttemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["onlinemovietemp"]!=null && ds.Tables[0].Rows[0]["onlinemovietemp"].ToString()!="")
				{
					model.onlinemovietemp=ds.Tables[0].Rows[0]["onlinemovietemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["listpagetemp"]!=null && ds.Tables[0].Rows[0]["listpagetemp"].ToString()!="")
				{
					model.listpagetemp=ds.Tables[0].Rows[0]["listpagetemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gbooktemp"]!=null && ds.Tables[0].Rows[0]["gbooktemp"].ToString()!="")
				{
					model.gbooktemp=ds.Tables[0].Rows[0]["gbooktemp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["loginiframe"]!=null && ds.Tables[0].Rows[0]["loginiframe"].ToString()!="")
				{
					model.loginiframe=ds.Tables[0].Rows[0]["loginiframe"].ToString();
				}
				if(ds.Tables[0].Rows[0]["otherlinktempsub"]!=null && ds.Tables[0].Rows[0]["otherlinktempsub"].ToString()!="")
				{
					model.otherlinktempsub=int.Parse(ds.Tables[0].Rows[0]["otherlinktempsub"].ToString());
				}
				if(ds.Tables[0].Rows[0]["otherlinktempdate"]!=null && ds.Tables[0].Rows[0]["otherlinktempdate"].ToString()!="")
				{
					model.otherlinktempdate=ds.Tables[0].Rows[0]["otherlinktempdate"].ToString();
				}
				if(ds.Tables[0].Rows[0]["loginjstemp"]!=null && ds.Tables[0].Rows[0]["loginjstemp"].ToString()!="")
				{
					model.loginjstemp=ds.Tables[0].Rows[0]["loginjstemp"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

        public string GetPubTempTextByFiled(string field)
        {

            string v = "";

            if (!string.IsNullOrEmpty(field))
            {


                object obj= DbHelperSQL.GetSingle(string.Format(" select  {0}  from    phome_enewspubtemp ",field));

                if (obj!=null)
                {
                    v = obj.ToString();
                }
            }

            return v;

        }

        public int  UpdateField(string filed, string value)
        {
            if (!string.IsNullOrEmpty(filed) && !string.IsNullOrEmpty(value))
            {
                string sql = string.Format(" update      phome_enewspubtemp  set {0}=@v ", filed);
                SqlParameter[] parms = { new SqlParameter("@v", SqlDbType.VarChar, 8000) };
                parms[0].Value = value;
                return DbHelperSQL.ExecuteSql(sql, parms);

            }
            else
            {

                return 0;
            
            }
        
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,indextemp,pllisttemp,cptemp,searchtemp,searchjstemp,searchjstemp1,otherlinktemp,printtemp,downsofttemp,onlinemovietemp,listpagetemp,gbooktemp,loginiframe,otherlinktempsub,otherlinktempdate,loginjstemp ");
			strSql.Append(" FROM phome_enewspubtemp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		

		#endregion  Method
	}
}

