using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LL.Model.Upload;
    namespace LL.IDAL.Upload
    {
        /// <summary>
        /// 接口层UploadFile
        /// </summary>
        public interface IUploadFile
        {
            #region  成员方法
            /// <summary>
            /// 增加一条数据
            /// </summary>
            int Add(UploadFile model);
            /// <summary>
            /// 更新一条数据
            /// </summary>
            int  Update(UploadFile model);
            /// <summary>
            /// 删除一条数据
            /// </summary>
            int   Delete(int ID);
            int  DeleteList(string IDlist);
            /// <summary>
            /// 得到一个对象实体
            /// </summary>
            UploadFile GetModel(int ID);
            /// <summary>
            /// 获得数据列表
            /// </summary>
            DataSet GetList(string strWhere);
            /// <summary>
            /// 获得前几行数据
            /// </summary>
            DataSet GetList(int Top, string strWhere, string filedOrder);
            /// <summary>
            /// 根据分页获得数据列表
            /// </summary>
            DataSet GetList(int PageSize,int PageIndex,string strWhere,string orderby);
            #endregion  成员方法

            int BatchDel(List<int> arrIDS);
        }
    }


