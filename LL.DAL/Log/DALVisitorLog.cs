using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DBUtility;
using System.Data;
using LL.IDAL.Log;
using LL.Common.EnumClass;
using LL.Model.Log;
using System.Data.SqlClient;
using LL.Model;

namespace LL.DAL.Log
{
   public  class DALVisitorLog:Repository<IAggregateRoot>,IVisitorLog
    {

      
       string tbName = "visitorlog";


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int  Add(VisitorLog model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into VisitorLog(");
           strSql.Append("IP,Visitor,InDate,ReUrl,InfoID,InfoTitle,InfoClassID,InfoUrl,InfoType,PV,Hit)");
           strSql.Append(" values (");
           strSql.Append("@IP,@Visitor,@InDate,@ReUrl,@InfoID,@InfoTitle,@InfoClassID,@InfoUrl,@InfoType,@PV,@Hit)");
           SqlParameter[] parameters = {
				
					new SqlParameter("@IP", SqlDbType.VarChar,20),
					new SqlParameter("@Visitor", SqlDbType.VarChar,50),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@ReUrl", SqlDbType.VarChar,300),
					new SqlParameter("@InfoID", SqlDbType.Int,4),
					new SqlParameter("@InfoTitle", SqlDbType.VarChar,50),
					new SqlParameter("@InfoClassID", SqlDbType.Int,4),
					new SqlParameter("@InfoUrl", SqlDbType.VarChar,50),
					new SqlParameter("@InfoType", SqlDbType.VarChar,50),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@Hit", SqlDbType.Int,4)};
         
           parameters[0].Value = model.IP;
           parameters[1].Value = model.Visitor;
           parameters[2].Value = model.InDate;
           parameters[3].Value = model.ReUrl;
           parameters[4].Value = model.InfoID;
           parameters[5].Value = model.InfoTitle;
           parameters[6].Value = model.InfoClassID;
           parameters[7].Value = model.InfoUrl;
           parameters[8].Value = model.InfoType;
           parameters[9].Value = model.PV;
           parameters[10].Value = model.Hit;

          return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public int Update(VisitorLog model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update VisitorLog set ");
  
           strSql.Append("IP=@IP,");
           strSql.Append("Visitor=@Visitor,");
           strSql.Append("InDate=@InDate,");
           strSql.Append("ReUrl=@ReUrl,");
           strSql.Append("InfoID=@InfoID,");
           strSql.Append("InfoTitle=@InfoTitle,");
           strSql.Append("InfoClassID=@InfoClassID,");
           strSql.Append("InfoUrl=@InfoUrl,");
           strSql.Append("InfoType=@InfoType,");
           strSql.Append("PV=@PV,");
           strSql.Append("Hit=@Hit");
           strSql.Append(" where ");
           strSql.Append("ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@IP", SqlDbType.VarChar,20),
					new SqlParameter("@Visitor", SqlDbType.VarChar,50),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@ReUrl", SqlDbType.VarChar,300),
					new SqlParameter("@InfoID", SqlDbType.Int,4),
					new SqlParameter("@InfoTitle", SqlDbType.VarChar,50),
					new SqlParameter("@InfoClassID", SqlDbType.Int,4),
					new SqlParameter("@InfoUrl", SqlDbType.VarChar,50),
					new SqlParameter("@InfoType", SqlDbType.VarChar,50),
					new SqlParameter("@PV", SqlDbType.Int,4),
					new SqlParameter("@Hit", SqlDbType.Int,4)};
           parameters[0].Value = model.ID;
           parameters[1].Value = model.IP;
           parameters[2].Value = model.Visitor;
           parameters[3].Value = model.InDate;
           parameters[4].Value = model.ReUrl;
           parameters[5].Value = model.InfoID;
           parameters[6].Value = model.InfoTitle;
           parameters[7].Value = model.InfoClassID;
           parameters[8].Value = model.InfoUrl;
           parameters[9].Value = model.InfoType;
           parameters[10].Value = model.PV;
           parameters[11].Value = model.Hit;

          return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
          
       }

        public int Delete(int id)
        {

            string sql = string.Format(" delete  {0} where id={1}",tbName,id);
            return DbHelperSQL.ExecuteSql(sql);


        }

       public  VisitorLog  GetModel(int id)
       {

 	       StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,IP,Visitor,InDate,ReUrl,InfoID,InfoTitle,InfoClassID,InfoUrl,InfoType,PV,Hit from VisitorLog ");
			strSql.AppendFormat(" where  id={0}",id);
			

		
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				
       return  GetModelByDataRow(ds.Tables[0].Rows[0] );
			}
			else
			{
				return null;
			}
		}

       private VisitorLog GetModelByDataRow(DataRow row)
       {
           VisitorLog model = new VisitorLog();
           if (row["ID"] != null && row["ID"].ToString() != "")
           {
               model.ID = int.Parse(row["ID"].ToString());
           }
           if (row["IP"] != null && row["IP"].ToString() != "")
           {
               model.IP = row["IP"].ToString();
           }
           if (row["Visitor"] != null && row["Visitor"].ToString() != "")
           {
               model.Visitor = row["Visitor"].ToString();
           }
           if (row["InDate"] != null && row["InDate"].ToString() != "")
           {
               model.InDate = DateTime.Parse(row["InDate"].ToString());
           }
           if (row["ReUrl"] != null && row["ReUrl"].ToString() != "")
           {
               model.ReUrl = row["ReUrl"].ToString();
           }
           if (row["InfoID"] != null && row["InfoID"].ToString() != "")
           {
               model.InfoID = int.Parse(row["InfoID"].ToString());
           }
           if (row["InfoTitle"] != null && row["InfoTitle"].ToString() != "")
           {
               model.InfoTitle = row["InfoTitle"].ToString();
           }
           if (row["InfoClassID"] != null && row["InfoClassID"].ToString() != "")
           {
               model.InfoClassID = int.Parse(row["InfoClassID"].ToString());
           }
           if (row["InfoUrl"] != null && row["InfoUrl"].ToString() != "")
           {
               model.InfoUrl = row["InfoUrl"].ToString();
           }
           if (row["InfoType"] != null && row["InfoType"].ToString() != "")
           {
               model.InfoType = row["InfoType"].ToString();
           }
           if (row["PV"] != null && row["PV"].ToString() != "")
           {
               model.PV = int.Parse(row["PV"].ToString());
           }
           if (row["Hit"] != null && row["Hit"].ToString() != "")
           {
               model.Hit = int.Parse(row["Hit"].ToString());
           }
           return model;
       }

    
        public DataSet GetList(int PageIndex, int PageSize, string strWhere,string orderby)
        {
            IPager pager = new IPager();
            pager.TableName = tbName;
            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;
            pager.PrimaryKeyField = "id";

            if (!string.IsNullOrEmpty(orderby))
            {

                pager.OrderBy = orderby; 
            }

            pager.Where = strWhere;

            return pager.GetSearchResultBySingleTable();
        }

       public DataSet TotalVisitorLog(int PageIndex,int PageSize,string type,string where,string orderby)
       {

           string sql = string.Format(" select count(pv) as pvs, count(visitor) as visitors ,count(ip) ips ,infoid ,infotitle  from visitorlog  where {0}   group by   infoid ,infotitle ", where);

           
           if (!string.IsNullOrEmpty(type) ||   type.ToLower()==PageDirectory.AD.ToString().ToLower())
           {
               sql = string.Format(" select count(pv) as pvs, count(visitor) as visitors ,count(ip) ips,  count(hit) hits ,infoid ,infotitle  from visitorlog   where {0}   group by   infoid ,infotitle ", where);
           }
           IPager pager = new IPager();
           pager.TableName = sql;
           pager.PageIndex = PageIndex;
           pager.PageSize = PageSize;
           pager.PrimaryKeyField = "infoid";
           pager.OrderBy = orderby;
           return pager.GetResult();

       }
       public DataSet GetList(int PageIndex, int PageSize, string strWhere)
       {

           IPager pager = new IPager();
           pager.TableName = tbName;
           pager.PageIndex = PageIndex;
           pager.PageSize = PageSize;
           pager.PrimaryKeyField = "infoid";
           pager.OrderBy = "infoid desc";
           return pager.GetResult();

       }


       public List<VisitorLog> GetModelAll()
       {
           throw new NotImplementedException();
       }

       public DataSet GetList(string strWhere)
       {
           throw new NotImplementedException();
       }
    }
}
