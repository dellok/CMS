using System;
using System.Data;
using System.Collections.Generic;
using LL.Model.Upload;
using LL.DALFactory;
using LL.IDAL.Upload;
namespace LL.BLL.Upload
{
    /// <summary>
    /// UploadFile
    /// </summary>
    public partial class BLLUploadFile
    {
        private readonly IUploadFile dal = DataAccess.CreateUploadFile();
        public BLLUploadFile()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LL.Model.Upload.UploadFile model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(LL.Model.Upload.UploadFile model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LL.Model.Upload.UploadFile GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LL.Model.Upload.UploadFile> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LL.Model.Upload.UploadFile> DataTableToList(DataTable dt)
        {
            List<LL.Model.Upload.UploadFile> modelList = new List<LL.Model.Upload.UploadFile>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LL.Model.Upload.UploadFile model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LL.Model.Upload.UploadFile();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["FileClass"] != null && dt.Rows[n]["FileClass"].ToString() != "")
                    {
                        model.FileClass = int.Parse(dt.Rows[n]["FileClass"].ToString());
                    }
                    if (dt.Rows[n]["FileInfoType"] != null && dt.Rows[n]["FileInfoType"].ToString() != "")
                    {
                        model.FileInfoType = int.Parse(dt.Rows[n]["FileInfoType"].ToString());
                    }
                    if (dt.Rows[n]["FileName"] != null && dt.Rows[n]["FileName"].ToString() != "")
                    {
                        model.FileName = dt.Rows[n]["FileName"].ToString();
                    }
                    if (dt.Rows[n]["FileSize"] != null && dt.Rows[n]["FileSize"].ToString() != "")
                    {
                        model.FileSize = int.Parse(dt.Rows[n]["FileSize"].ToString());
                    }
                    if (dt.Rows[n]["Path"] != null && dt.Rows[n]["Path"].ToString() != "")
                    {
                        model.Path = dt.Rows[n]["Path"].ToString();
                    }
                    if (dt.Rows[n]["UploadUser"] != null && dt.Rows[n]["UploadUser"].ToString() != "")
                    {
                        model.UploadUser = dt.Rows[n]["UploadUser"].ToString();
                    }
                    if (dt.Rows[n]["UploadUserRole"] != null && dt.Rows[n]["UploadUserRole"].ToString() != "")
                    {
                        model.UploadUserRole = int.Parse(dt.Rows[n]["UploadUserRole"].ToString());
                    }
                    if (dt.Rows[n]["InDate"] != null && dt.Rows[n]["InDate"].ToString() != "")
                    {
                        model.InDate = DateTime.Parse(dt.Rows[n]["InDate"].ToString());
                    }
                    if (dt.Rows[n]["NewsID"] != null && dt.Rows[n]["NewsID"].ToString() != "")
                    {
                        model.NewsID = int.Parse(dt.Rows[n]["NewsID"].ToString());
                    }
                    if (dt.Rows[n]["NewsClassID"] != null && dt.Rows[n]["NewsClassID"].ToString() != "")
                    {
                        model.NewsClassID = int.Parse(dt.Rows[n]["NewsClassID"].ToString());
                    }
                    if (dt.Rows[n]["No"] != null && dt.Rows[n]["No"].ToString() != "")
                    {
                        model.No = dt.Rows[n]["No"].ToString();
                    }
                    if (dt.Rows[n]["Hit"] != null && dt.Rows[n]["Hit"].ToString() != "")
                    {
                        model.Hit = int.Parse(dt.Rows[n]["Hit"].ToString());
                    }
                    if (dt.Rows[n]["CJID"] != null && dt.Rows[n]["CJID"].ToString() != "")
                    {
                        model.CJID = int.Parse(dt.Rows[n]["CJID"].ToString());
                    }
                    if (dt.Rows[n]["FPathath"] != null && dt.Rows[n]["FPathath"].ToString() != "")
                    {
                        model.FPathath = int.Parse(dt.Rows[n]["FPathath"].ToString());
                    }
                    if (dt.Rows[n]["Extension"] != null && dt.Rows[n]["Extension"].ToString() != "")
                    {
                        model.Extension = dt.Rows[n]["Extension"].ToString();
                    }
                    if (dt.Rows[n]["IsRecycle"] != null && dt.Rows[n]["IsRecycle"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsRecycle"].ToString() == "1") || (dt.Rows[n]["IsRecycle"].ToString().ToLower() == "true"))
                        {
                            model.IsRecycle = true;
                        }
                        else
                        {
                            model.IsRecycle = false;
                        }
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method

        public DataSet GetList(int PageIndex, int PageSize, int fClass, int fType)
        {
            return dal.GetList(PageIndex,PageSize,"","");
        }

        public int BatchDel(List<int> arrIDS)
        {

            return dal.BatchDel(arrIDS);
        }

        public void SetUploadFileToRecycle(int p, int p_2)
        {
            throw new NotImplementedException();
        }
    }
}

