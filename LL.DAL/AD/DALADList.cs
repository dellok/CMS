using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LL.IDAL.AD;
using DBUtility;
using System.Data.SqlClient;
using LL.Model.AD;
using LL.Model;

namespace LL.DAL.AD
{
   public  class DALADList:Repository<IAggregateRoot>,IADList
    {
  
        
     
        public  readonly string strTableName = "adlist";



        public int Add(ADList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ADList(");
			strSql.Append("FileClass,Title,Page,Position,Url,Width,Height,Seq,InDate,StartDate,EndDate,Script,Remark,Hit,Checked,IsRecycle,UploadFileID,FileUrl,PV)");
			strSql.Append(" values (");
			strSql.Append("@FileClass,@Title,@Page,@Position,@Url,@Width,@Height,@Seq,@InDate,@StartDate,@EndDate,@Script,@Remark,@Hit,@Checked,@IsRecycle,@UploadFileID,@FileUrl,@PV)");
			SqlParameter[] parameters = {
					new SqlParameter("@FileClass", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Page", SqlDbType.VarChar,50),
					new SqlParameter("@Position", SqlDbType.VarChar,10),
					new SqlParameter("@Url", SqlDbType.VarChar,200),
					new SqlParameter("@Width", SqlDbType.Int,4),
					new SqlParameter("@Height", SqlDbType.Int,4),
					new SqlParameter("@Seq", SqlDbType.Int,4),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Script", SqlDbType.VarChar,1000),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@Checked", SqlDbType.Bit,1),
					new SqlParameter("@IsRecycle", SqlDbType.Bit,1),
					new SqlParameter("@UploadFileID", SqlDbType.Int,4),
					new SqlParameter("@FileUrl", SqlDbType.VarChar,200),
					new SqlParameter("@PV", SqlDbType.Int,4)};

			parameters[0].Value = model.FileClass;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Page;
			parameters[3].Value = model.Position;
			parameters[4].Value = model.Url;
			parameters[5].Value = model.Width;
			parameters[6].Value = model.Height;
			parameters[7].Value = model.Seq;
			parameters[8].Value = model.InDate;
			parameters[9].Value = model.StartDate;
			parameters[10].Value = model.EndDate;
			parameters[11].Value = model.Script;
			parameters[12].Value = model.Remark;
			parameters[13].Value = model.Hit;
			parameters[14].Value = model.Checked;
			parameters[15].Value = model.IsRecycle;
			parameters[16].Value = model.UploadFileID;
			parameters[17].Value = model.FileUrl;
			parameters[18].Value = model.PV;

	return 	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public int Update(ADList model)
        {

            try
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update ADList set ");
                strSql.Append("FileClass=@FileClass,");
                strSql.Append("Title=@Title,");
                strSql.Append("Page=@Page,");
                strSql.Append("Position=@Position,");
                strSql.Append("Url=@Url,");
                strSql.Append("Width=@Width,");
                strSql.Append("Height=@Height,");
                strSql.Append("Seq=@Seq,");
                strSql.Append("InDate=@InDate,");
                strSql.Append("StartDate=@StartDate,");
                strSql.Append("EndDate=@EndDate,");
                strSql.Append("Script=@Script,");
                strSql.Append("Remark=@Remark,");
                strSql.Append("Hit=@Hit,");
                strSql.Append("checked=@Checked,");
                strSql.Append("IsRecycle=@IsRecycle,");
                strSql.Append("UploadFileID=@UploadFileID,");
                strSql.Append("FileUrl=@FileUrl,");
                strSql.Append("PV=@PV");
                strSql.Append(" where ID=@ID ");
                SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@FileClass", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Page", SqlDbType.VarChar,50),
					new SqlParameter("@Position", SqlDbType.VarChar,10),
					new SqlParameter("@Url", SqlDbType.VarChar,200),
					new SqlParameter("@Width", SqlDbType.Int,4),
					new SqlParameter("@Height", SqlDbType.Int,4),
					new SqlParameter("@Seq", SqlDbType.Int,4),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Script", SqlDbType.VarChar,1000),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@Checked", SqlDbType.Bit,1),
					new SqlParameter("@IsRecycle", SqlDbType.Bit,1),
					new SqlParameter("@UploadFileID", SqlDbType.Int,4),
					new SqlParameter("@FileUrl", SqlDbType.VarChar,200),
					new SqlParameter("@PV", SqlDbType.Int,4)};
                parameters[0].Value = model.ID;
                parameters[1].Value = model.FileClass;
                parameters[2].Value = model.Title;
                parameters[3].Value = model.Page;
                parameters[4].Value = model.Position;
                parameters[5].Value = model.Url;
                parameters[6].Value = model.Width;
                parameters[7].Value = model.Height;
                parameters[8].Value = model.Seq;
                parameters[9].Value = model.InDate;
                parameters[10].Value = model.StartDate;
                parameters[11].Value = model.EndDate;
                parameters[12].Value = model.Script;
                parameters[13].Value = model.Remark;
                parameters[14].Value = model.Hit;
                parameters[15].Value = model.Checked;
                parameters[16].Value = model.IsRecycle;
                parameters[17].Value = model.UploadFileID;
                parameters[18].Value = model.FileUrl;
                parameters[19].Value = model.PV;

              return   DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            }
            catch (Exception)
            {

                return 0;
            }


        }


        public int Delete(int id)
        {

            string sql = string.Format(" delete  {0} where id={1}",strTableName,id);
            return DbHelperSQL.ExecuteSql(sql.ToString());
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="classid"></param>
        /// fileInfoType   上传图片的栏目
        /// <returns></returns>
        public int Delete(int ID, string  fileName)
        {
            try
            {
           
                StringBuilder sql = new StringBuilder();
                //删除同时，给上传文件表,中对应ID标记为放入图片回收站
                    sql.AppendFormat(" delete  {0} where id={1}  ", strTableName,ID);
                  //  sql.AppendFormat("   update   uploadfile set  IsRecycle=1   where   fileName={0}", fileName);
                   return DbHelperSQL.ExecuteSql(sql.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int BatchMoveToRecycle(List<int> arrIDS, int IsRecycle)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                foreach (int id in arrIDS)
                {
                    //删除同时，给上传文件表,中对应ID标记为放入图片回收站
                    sql.AppendFormat("   update   {0} set  IsRecycle={1}   where   id={2}",strTableName, IsRecycle ,id);  
                }
           
                return DbHelperSQL.ExecuteSql(sql.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        
        }
        public int MoveToRecycle(int id, int IsRecycle)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                  //删除同时，给上传文件表,中对应ID标记为放入图片回收站
                sql.AppendFormat("   update   {0} set  IsRecycle={1}   where   id={2}", strTableName, IsRecycle, id);  
         
                return DbHelperSQL.ExecuteSql(sql.ToString());
            }
            catch (Exception)
            {
                return 0;
            }

        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LL.Model.AD.ADList GetModel(int id)
        {

            string where = string.Format("id={0}", id);
            DataSet ds = GetList(where);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetModelByDataRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public  ADList GetModelByDataRow(DataRow row)
        {
           ADList model = new ADList();

            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["FileClass"] != null && row["FileClass"].ToString() != "")
            {
                model.FileClass = int.Parse(row["FileClass"].ToString());
            }
            if (row["Title"] != null && row["Title"].ToString() != "")
            {
                model.Title = row["Title"].ToString();
            }
            if (row["Page"] != null && row["Page"].ToString() != "")
            {
                model.Page = row["Page"].ToString();
            }
            if (row["Position"] != null && row["Position"].ToString() != "")
            {
                model.Position = row["Position"].ToString();
            }
            if (row["Url"] != null && row["Url"].ToString() != "")
            {
                model.Url = row["Url"].ToString();
            }
            if (row["Width"] != null && row["Width"].ToString() != "")
            {
                model.Width = int.Parse(row["Width"].ToString());
            }
            if (row["Height"] != null && row["Height"].ToString() != "")
            {
                model.Height = int.Parse(row["Height"].ToString());
            }
            if (row["Seq"] != null && row["Seq"].ToString() != "")
            {
                model.Seq = int.Parse(row["Seq"].ToString());
            }
            if (row["InDate"] != null && row["InDate"].ToString() != "")
            {
                model.InDate = DateTime.Parse(row["InDate"].ToString());
            }
            if (row["StartDate"] != null && row["StartDate"].ToString() != "")
            {
                model.StartDate = DateTime.Parse(row["StartDate"].ToString());
            }
            if (row["EndDate"] != null && row["EndDate"].ToString() != "")
            {
                model.EndDate = DateTime.Parse(row["EndDate"].ToString());
            }
            if (row["Script"] != null && row["Script"].ToString() != "")
            {
                model.Script = row["Script"].ToString();
            }
            if (row["Remark"] != null && row["Remark"].ToString() != "")
            {
                model.Remark = row["Remark"].ToString();
            }
            if (row["Hit"] != null && row["Hit"].ToString() != "")
            {
                model.Hit = int.Parse(row["Hit"].ToString());
            }
            if (row["Checked"] != null && row["Checked"].ToString() != "")
            {
                if ((row["Checked"].ToString() == "1") || (row["Checked"].ToString().ToLower() == "true"))
                {
                    model.Checked = true;
                }
                else
                {
                    model.Checked = false;
                }
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
            if (row["UploadFileID"] != null && row["UploadFileID"].ToString() != "")
            {
                model.UploadFileID = int.Parse(row["UploadFileID"].ToString());
            }
            if (row["FileUrl"] != null && row["FileUrl"].ToString() != "")
            {
                model.FileUrl = row["FileUrl"].ToString();
            }
            if (row["PV"] != null && row["PV"].ToString() != "")
            {
                model.PV = int.Parse(row["PV"].ToString());
            }
            return model;
        }
    

        public List<ADList> GetModelAll()
        {
           List<ADList> arr=new List<ADList>();
            DataSet ds = GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
              arr.Add(GetModelByDataRow(ds.Tables[0].Rows[0]));
            }

            return arr;
        }

        public  DataSet GetList(string where)
        {
            string sql = string.Format(" select *  from   {0}   {1}", strTableName,IPager.SetSqlWhere(where));
            return DbHelperSQL.Query(sql);
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

       return      GetList(PageIndex, PageSize, where, "");
        }


        public DataSet GetList(int pageindex, int pagesize, string where, string orderby)
        {
            string tableName = string.Format("  select * from  {0}   {1} ", strTableName, IPager.SetSqlWhere(where));
            IPager pager = new IPager(tableName, "ID", pageindex, pagesize, "*", "page desc ,position asc ,seq asc ");
            return pager.GetResult();
        }
        public int BatchDel(List<int> arrIDS, int fileInfoType)
        {
            StringBuilder sql = new StringBuilder();
            //删除同时，给上传文件表,中对应ID标记为回收站
         
            foreach (int  item in  arrIDS)
            {
                sql.AppendFormat(" delete  {0} where id={1}  ",strTableName,item);
               // sql.AppendFormat("   update   uploadfile set  IsRecycle=true   where  newsid={0} and fileinfoType={1}", item, fileInfoType);
            }
            return DbHelperSQL.ExecuteSql(sql.ToString());
        }


        public int BatchChecked(List<int> arrIDS, int IsChecked)
        {
            StringBuilder sql = new StringBuilder();
            //删除同时，给上传文件表,中对应ID标记为回收站
            int intR = 0;
            foreach (int item in arrIDS)
            {
                 sql.AppendFormat("   update   {0}  set  Checked={1}   where  id={2}",strTableName, IsChecked,item);
            }
            try
            {
                intR= DbHelperSQL.ExecuteSql(sql.ToString());
            }
            catch (Exception)
            {
            }
            return intR;
       
        }
       /// <summary>
       /// 广告点击计数
       /// </summary>
       /// <param name="id"></param>
       /// <param name="hitNum"></param>
       /// <returns></returns>
        public int ADHit(int id,int hitNum)
        {
            int intR = 0;
            string sql = string.Format(" update   {0}  set  hit=isnull(hit,0)+{1}   where  id={2}", strTableName,hitNum,id);
            try
            {
                intR = DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception)
            {


            }
            return intR;
         
        }

       public  int ADPV(int id, int pvNum)
        {
            int intR = 0;
            string sql = string.Format(" update   {0}  set  pv=isnull(pv,0)+{1}   where  id={2}", strTableName, pvNum, id);
            try
            {
                intR = DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception)
            {


            }
            return intR;
        
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="ADPage"></param>
       /// <param name="ADPagePosition"></param>
       /// <param name="IsCheck"></param>
       /// <param name="IsExpired"></param>
       /// <returns></returns>
       public  List<ADList> GetADList(string ADPage, string ADPagePosition, bool IsCheck, bool IsExpired)
       {
           DateTime now =DateTime.Now;
      
           List<ADList>  arrAD=new List<ADList>();

           StringBuilder  where = new StringBuilder();
           where.AppendFormat("page='{0}' and  position='{1}' and  checked={2}  ",ADPage,ADPagePosition,IsCheck?1:0);
            if (!IsExpired)
	                {
                        where.AppendFormat(" EndDate >'{0}'   and  IsRecycle<>1 ", DateTime.Now.ToShortDateString());
            }

               List<ADList> arr=new List<ADList>();
            DataSet ds = GetList(where.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
              arr.Add(GetModelByDataRow(ds.Tables[0].Rows[0]));
            }

            return arr;
        
        }


       /// <summary>
       /// 查询全部广告，
       /// true ,为开启的广告, false 未审核广告
       /// </summary>
       /// <param name="isCheck"></param>
       /// <returns></returns>
      public  List<ADList> GetAllADList(bool isCheck)
       {
           string where = string.Format("checked={0}",isCheck?1:0);
     
           List<ADList> arr = new List<ADList>();
           DataSet ds = GetList(where.ToString());



           foreach (DataRow  item in ds.Tables[0].Rows)
           {
               arr.Add(GetModelByDataRow(item));
               
           }
              
         

           return arr;
         
      }







 
    }
}
