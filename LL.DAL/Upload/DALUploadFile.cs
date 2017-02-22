using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.Upload;
using LL.Model.Upload;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace LL.DAL.Upload
{
   public  class DALUploadFile:IUploadFile
    {


       private  readonly string strTableName = "uploadfile";


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(UploadFile model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into UploadFile(");
           strSql.Append("FileClass,FileInfoType,FileName,FileSize,Path,UploadUser,UploadUserRole,InDate,NewsID,NewsClassID,No,Hit,CJID,FPathath,Extension,IsRecycle,UserID,Title)");
           strSql.Append(" values (");
           strSql.Append("@FileClass,@FileInfoType,@FileName,@FileSize,@Path,@UploadUser,@UploadUserRole,@InDate,@NewsID,@NewsClassID,@No,@Hit,@CJID,@FPathath,@Extension,@IsRecycle,@UserID,@Title)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@FileClass", SqlDbType.Int,4),
					new SqlParameter("@FileInfoType", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.NVarChar,300),
					new SqlParameter("@UploadUser", SqlDbType.NVarChar,100),
					new SqlParameter("@UploadUserRole", SqlDbType.Int,4),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@NewsClassID", SqlDbType.Int,4),
					new SqlParameter("@No", SqlDbType.NVarChar,60),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@CJID", SqlDbType.Int,4),
					new SqlParameter("@FPathath", SqlDbType.Int,4),
					new SqlParameter("@Extension", SqlDbType.VarChar,10),
					new SqlParameter("@IsRecycle", SqlDbType.Bit,1),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,300)};
           parameters[0].Value = model.FileClass;
           parameters[1].Value = model.FileInfoType;
           parameters[2].Value = model.FileName;
           parameters[3].Value = model.FileSize;
           parameters[4].Value = model.Path;
           parameters[5].Value = model.UploadUser;
           parameters[6].Value = model.UploadUserRole;
           parameters[7].Value = model.InDate;
           parameters[8].Value = model.NewsID;
           parameters[9].Value = model.NewsClassID;
           parameters[10].Value = model.No;
           parameters[11].Value = model.Hit;
           parameters[12].Value = model.CJID;
           parameters[13].Value = model.FPathath;
           parameters[14].Value = model.Extension;
           parameters[15].Value = model.IsRecycle;
           parameters[16].Value = model.UserID;
           parameters[17].Value = model.Title;

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
       public int  Update(UploadFile model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update UploadFile set ");
           strSql.Append("FileClass=@FileClass,");
           strSql.Append("FileInfoType=@FileInfoType,");
           strSql.Append("FileName=@FileName,");
           strSql.Append("FileSize=@FileSize,");
           strSql.Append("Path=@Path,");
           strSql.Append("UploadUser=@UploadUser,");
           strSql.Append("UploadUserRole=@UploadUserRole,");
           strSql.Append("InDate=@InDate,");
           strSql.Append("NewsID=@NewsID,");
           strSql.Append("NewsClassID=@NewsClassID,");
           strSql.Append("No=@No,");
           strSql.Append("Hit=@Hit,");
           strSql.Append("CJID=@CJID,");
           strSql.Append("FPathath=@FPathath,");
           strSql.Append("Extension=@Extension,");
           strSql.Append("IsRecycle=@IsRecycle,");
           strSql.Append("UserID=@UserID,");
           strSql.Append("Title=@Title");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@FileClass", SqlDbType.Int,4),
					new SqlParameter("@FileInfoType", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.NVarChar,300),
					new SqlParameter("@UploadUser", SqlDbType.NVarChar,100),
					new SqlParameter("@UploadUserRole", SqlDbType.Int,4),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@NewsClassID", SqlDbType.Int,4),
					new SqlParameter("@No", SqlDbType.NVarChar,60),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@CJID", SqlDbType.Int,4),
					new SqlParameter("@FPathath", SqlDbType.Int,4),
					new SqlParameter("@Extension", SqlDbType.VarChar,10),
					new SqlParameter("@IsRecycle", SqlDbType.Bit,1),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,300),
					new SqlParameter("@ID", SqlDbType.Int,4)};
           parameters[0].Value = model.FileClass;
           parameters[1].Value = model.FileInfoType;
           parameters[2].Value = model.FileName;
           parameters[3].Value = model.FileSize;
           parameters[4].Value = model.Path;
           parameters[5].Value = model.UploadUser;
           parameters[6].Value = model.UploadUserRole;
           parameters[7].Value = model.InDate;
           parameters[8].Value = model.NewsID;
           parameters[9].Value = model.NewsClassID;
           parameters[10].Value = model.No;
           parameters[11].Value = model.Hit;
           parameters[12].Value = model.CJID;
           parameters[13].Value = model.FPathath;
           parameters[14].Value = model.Extension;
           parameters[15].Value = model.IsRecycle;
           parameters[16].Value = model.UserID;
           parameters[17].Value = model.Title;
           parameters[18].Value = model.ID;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
          
       }

      
       /// <summary>
       /// 批量删除数据
       /// </summary>
       public int DeleteList(string IDlist)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from UploadFile ");
           strSql.Append(" where ID in (" + IDlist + ")  ");
           int rows = DbHelperSQL.ExecuteSql(strSql.ToString());

           return rows;
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public UploadFile GetModel(int ID)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 ID,FileClass,FileInfoType,FileName,FileSize,Path,UploadUser,UploadUserRole,InDate,NewsID,NewsClassID,No,Hit,CJID,FPathath,Extension,IsRecycle,UserID,Title from UploadFile ");
           strSql.AppendFormat(" where ID={0}",ID);
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
       public UploadFile  GetModelByDataRow(DataRow row)
       {
           UploadFile model = new UploadFile();
           if (row["ID"] != null && row["ID"].ToString() != "")
           {
               model.ID = int.Parse(row["ID"].ToString());
           }
           if (row["FileClass"] != null && row["FileClass"].ToString() != "")
           {
               model.FileClass = int.Parse(row["FileClass"].ToString());
           }
           if (row["FileInfoType"] != null && row["FileInfoType"].ToString() != "")
           {
               model.FileInfoType = int.Parse(row["FileInfoType"].ToString());
           }
           if (row["FileName"] != null && row["FileName"].ToString() != "")
           {
               model.FileName = row["FileName"].ToString();
           }
           if (row["FileSize"] != null && row["FileSize"].ToString() != "")
           {
               model.FileSize = int.Parse(row["FileSize"].ToString());
           }
           if (row["Path"] != null && row["Path"].ToString() != "")
           {
               model.Path = row["Path"].ToString();
           }
           if (row["UploadUser"] != null && row["UploadUser"].ToString() != "")
           {
               model.UploadUser = row["UploadUser"].ToString();
           }
           if (row["UploadUserRole"] != null && row["UploadUserRole"].ToString() != "")
           {
               model.UploadUserRole = int.Parse(row["UploadUserRole"].ToString());
           }
           if (row["InDate"] != null && row["InDate"].ToString() != "")
           {
               model.InDate = DateTime.Parse(row["InDate"].ToString());
           }
           if (row["NewsID"] != null && row["NewsID"].ToString() != "")
           {
               model.NewsID = int.Parse(row["NewsID"].ToString());
           }
           if (row["NewsClassID"] != null && row["NewsClassID"].ToString() != "")
           {
               model.NewsClassID = int.Parse(row["NewsClassID"].ToString());
           }
           if (row["No"] != null && row["No"].ToString() != "")
           {
               model.No = row["No"].ToString();
           }
           if (row["Hit"] != null && row["Hit"].ToString() != "")
           {
               model.Hit = int.Parse(row["Hit"].ToString());
           }
           if (row["CJID"] != null && row["CJID"].ToString() != "")
           {
               model.CJID = int.Parse(row["CJID"].ToString());
           }
           if (row["FPathath"] != null && row["FPathath"].ToString() != "")
           {
               model.FPathath = int.Parse(row["FPathath"].ToString());
           }
           if (row["Extension"] != null && row["Extension"].ToString() != "")
           {
               model.Extension = row["Extension"].ToString();
           }
           if (row["IsRecycle"] != null && row["IsRecycle"].ToString() != "")
           {
               if ((row["IsRecycle"].ToString() == "1") || (row["IsRecycle"].ToString().ToLower() == "true"))
               {
                   model.IsRecycle = true;
               }
               else
               {
                   model.IsRecycle = false;
               }
           }
           if (row["UserID"] != null && row["UserID"].ToString() != "")
           {
               model.UserID = int.Parse(row["UserID"].ToString());
           }
           if (row["Title"] != null && row["Title"].ToString() != "")
           {
               model.Title = row["Title"].ToString();
           }

           return model;
       
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select ID,FileClass,FileInfoType,FileName,FileSize,Path,UploadUser,UploadUserRole,InDate,NewsID,NewsClassID,No,Hit,CJID,FPathath,Extension,IsRecycle,UserID,Title ");
           strSql.Append(" FROM UploadFile ");
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
           strSql.Append(" ID,FileClass,FileInfoType,FileName,FileSize,Path,UploadUser,UploadUserRole,InDate,NewsID,NewsClassID,No,Hit,CJID,FPathath,Extension,IsRecycle,UserID,Title ");
           strSql.Append(" FROM UploadFile ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by " + filedOrder);
           return DbHelperSQL.Query(strSql.ToString());
       }

        public int  Delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                

                    sql.AppendFormat(" delete  UploadFileInNews where  UploadFileID={0}", id);
                    sql.AppendFormat(" delete  UploadFile   where id={0}   ", id);


                return DBUtility.DbHelperSQL.ExecuteSql(sql.ToString());
               

            }
            catch (Exception)
            {

                return 0;
            }
        }


        public int DelDataAndFile(int id)
        {

            try
            {
                StringBuilder sql = new StringBuilder();


                sql.AppendFormat(" delete  UploadFileInNews where  UploadFileID={0}", id);
                sql.AppendFormat(" delete  UploadFile where id={0}   ", id);


                return DBUtility.DbHelperSQL.ExecuteSql(sql.ToString());

               
            }
            catch (Exception)
            {

                return 0;
            }
        
        }
       
        public List<UploadFile> GetModelAll()
        {
            throw new NotImplementedException();
        }


       /// <summary>
       /// 图片放入回收站
       /// </summary>
       /// <param name="newsID"></param>
       /// <param name="fileInfoType"></param>
       /// <returns></returns>
        public int SetUploadFileToRecycle(int newsID, int fileInfoType)
        {

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" update   {0}  set      IsRecycle=1  where  newsid={1} and fileinfoType={2} ",strTableName,newsID,fileInfoType);
            return DBUtility.DbHelperSQL.ExecuteSql(sql.ToString());
        
        
        }

       /// <summary>
       /// 删除图片，删除关联项，设置图片为回收站判态
       /// </summary>
       /// <param name="arrIDS"></param>
       /// <returns></returns>
       public  int BatchDel(List<int> arrIDS)
        {

            StringBuilder sql = new StringBuilder();
            foreach (int  id in arrIDS)
            {


                sql.AppendFormat(" delete  UploadFileInNews where  UploadFileID={0}",id);
                sql.AppendFormat(" delete  UploadFil where id={0}   ", id);
   
            }
            return DBUtility.DbHelperSQL.ExecuteSql(sql.ToString());
        }


        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public System.Data.DataSet GetList(int PageIndex, int PageSize, string where)
        {
            return GetList(PageSize,PageIndex,where,"");
        }

        public System.Data.DataSet GetVipMemberPic(int PageIndex, int PageSize, int UserID, int ClassID, int FileInfoType)
        {

            string where = string.Format(" userid={0} and  newsclassid={1} and   fileinfotype={2}", UserID, ClassID, FileInfoType);

          return    GetList( PageIndex,  PageSize,  where);


        }




        public DataSet GetList(int PageIndex, int PageSize, string where, string orderby)
        {
            string tableName = string.Format(" select *  from  UploadFile {0} ", IPager.SetSqlWhere(where));
            IPager pager = new IPager(tableName, "ID", PageIndex, PageSize, "*", orderby);
           
            return pager.GetResult();
        }
    }
}
