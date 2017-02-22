using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LL.IDAL;
using DBUtility;
using LL.IDAL.Member;
using LL.Model.Member;
namespace LL.DAL.Member
{
	/// <summary>
	///分员空间样式
	/// </summary>
	public partial class DALphome_enewsspacestyle:Iphome_enewsspacestyle
	{
		public DALphome_enewsspacestyle()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(phome_enewsspacestyle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into phome_enewsspacestyle(");
			strSql.Append("styleid,stylename,stylepic,stylesay,stylepath,isdefault,membergroup)");
			strSql.Append(" values (");
			strSql.Append("@styleid,@stylename,@stylepic,@stylesay,@stylepath,@isdefault,@membergroup)");
			SqlParameter[] parameters = {
					new SqlParameter("@styleid", SqlDbType.Int,4),
					new SqlParameter("@stylename", SqlDbType.NVarChar,90),
					new SqlParameter("@stylepic", SqlDbType.NVarChar,255),
					new SqlParameter("@stylesay", SqlDbType.NVarChar,255),
					new SqlParameter("@stylepath", SqlDbType.NVarChar,90),
					new SqlParameter("@isdefault", SqlDbType.Int,4),
					new SqlParameter("@membergroup", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.styleid;
			parameters[1].Value = model.stylename;
			parameters[2].Value = model.stylepic;
			parameters[3].Value = model.stylesay;
			parameters[4].Value = model.stylepath;
			parameters[5].Value = model.isdefault;
			parameters[6].Value = model.membergroup;

		return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(phome_enewsspacestyle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update phome_enewsspacestyle set ");
			strSql.Append("styleid=@styleid,");
			strSql.Append("stylename=@stylename,");
			strSql.Append("stylepic=@stylepic,");
			strSql.Append("stylesay=@stylesay,");
			strSql.Append("stylepath=@stylepath,");
			strSql.Append("isdefault=@isdefault,");
			strSql.Append("membergroup=@membergroup");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@styleid", SqlDbType.Int,4),
					new SqlParameter("@stylename", SqlDbType.NVarChar,90),
					new SqlParameter("@stylepic", SqlDbType.NVarChar,255),
					new SqlParameter("@stylesay", SqlDbType.NVarChar,255),
					new SqlParameter("@stylepath", SqlDbType.NVarChar,90),
					new SqlParameter("@isdefault", SqlDbType.Int,4),
					new SqlParameter("@membergroup", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.styleid;
			parameters[1].Value = model.stylename;
			parameters[2].Value = model.stylepic;
			parameters[3].Value = model.stylesay;
			parameters[4].Value = model.stylepath;
			parameters[5].Value = model.isdefault;
			parameters[6].Value = model.membergroup;

		return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from phome_enewsspacestyle ");
            strSql.AppendFormat(" where styleid={0}",id);
     	return 		DbHelperSQL.ExecuteSql(strSql.ToString());
			
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public phome_enewsspacestyle GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 styleid,stylename,stylepic,stylesay,stylepath,isdefault,membergroup from phome_enewsspacestyle ");
            strSql.AppendFormat(" where styleid={0}",id);


			phome_enewsspacestyle model=new phome_enewsspacestyle();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
                return GetModelByDataRow(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

    public     phome_enewsspacestyle GetModelByDataRow(DataRow row)
        {
            phome_enewsspacestyle model = new phome_enewsspacestyle();

            if (row["styleid"] != null && row["styleid"].ToString() != "")
            {
                model.styleid = int.Parse(row["styleid"].ToString());
            }
            if (row["stylename"] != null && row["stylename"].ToString() != "")
            {
                model.stylename = row["stylename"].ToString();
            }
            if (row["stylepic"] != null && row["stylepic"].ToString() != "")
            {
                model.stylepic = row["stylepic"].ToString();
            }
            if (row["stylesay"] != null && row["stylesay"].ToString() != "")
            {
                model.stylesay = row["stylesay"].ToString();
            }
            if (row["stylepath"] != null && row["stylepath"].ToString() != "")
            {
                model.stylepath = row["stylepath"].ToString();
            }
            if (row["isdefault"] != null && row["isdefault"].ToString() != "")
            {
                model.isdefault = int.Parse(row["isdefault"].ToString());
            }
            if (row["membergroup"] != null && row["membergroup"].ToString() != "")
            {
                model.membergroup = row["membergroup"].ToString();
            }
            return model;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select styleid,stylename,stylepic,stylesay,stylepath,isdefault,membergroup ");
			strSql.Append(" FROM phome_enewsspacestyle ");
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
			strSql.Append(" styleid,stylename,stylepic,stylesay,stylepath,isdefault,membergroup ");
			strSql.Append(" FROM phome_enewsspacestyle ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method
	}
}

