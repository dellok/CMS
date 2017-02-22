using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using LL.Common;
using LL.Model.News;
using LL.DALFactory;
using LL.IDAL.News;
using LL.Common.Cache;
using System.Text;
using Project.Common;
namespace LL.BLL.News
{
    /// <summary>
    /// phome_enewsclass
    /// </summary>
    public partial class BLLphome_enewsclass
    {
        private readonly Iphome_enewsclass dal = DataAccess.Createphome_enewsclass();
        public BLLphome_enewsclass()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LL.Model.News.phome_enewsclass model)
        {

           
            int intR= dal.Add(model);

            RemoveCache();
            return intR;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(LL.Model.News.phome_enewsclass model)
        {
    

            int intR = dal.Update(model);

            RemoveCache();
            return intR;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int classid)
        {

            int intR = dal.Delete(classid);
            RemoveCache();
            return intR;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteList(string classidlist)
        {
            int intR = dal.DeleteList(classidlist);
            RemoveCache();
            return intR;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LL.Model.News.phome_enewsclass GetModel(int classid)
        {

            return dal.GetModel(classid);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LL.Model.News.phome_enewsclass> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LL.Model.News.phome_enewsclass> DataTableToList(DataTable dt)
        {
            List<LL.Model.News.phome_enewsclass> modelList = new List<LL.Model.News.phome_enewsclass>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    modelList.Add(dal.GetModelByDataRow(dt.Rows[n]));
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



        #endregion  Method


        #region  得到分类路径

        /// <summary>
        /// 得到父分类到当前分类的路径
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public List<phome_enewsclass> GetClassNodePath(int classid)
        {
            //得到父类对像
            phome_enewsclass node = GetModelByCache(classid);
            List<phome_enewsclass> arrPath = new List<phome_enewsclass>();
            arrPath.Add(node);
            GetFatherNode(node, ref arrPath);
            return arrPath;
        }
        //得到分类路径
        public void GetFatherNode(phome_enewsclass currNode, ref List<phome_enewsclass> arrPath)
        {


            if (currNode!=null && currNode.bclassid > 0)
            {
                phome_enewsclass fNode = GetModelByCache(currNode.bclassid);
                arrPath.Insert(0, fNode);
                GetFatherNode(fNode, ref arrPath);
            }
        }


        #endregion

        #region 所有数据缓存
        /// <summary>
        /// 得到全部信息
        /// </summary>
        /// <returns></returns>
        public List<phome_enewsclass> GetModelAllByCache()
        {
            if (CacheManager.GetCache(Key_Cache) != null)
            {
                List<phome_enewsclass> list = (List<phome_enewsclass>)CacheManager.GetCache(Key_Cache);

                return list;
            }
            else
            {
                List<phome_enewsclass> list = GetModelList("");
                CacheManager.SaveCache(Key_Cache, list);
                return list;
            }
        }


        public string Key_Cache { get { return this.GetType().Name; } }
        void RemoveCache()
        {
            CacheManager.Remove(Key_Cache);

        }


        public phome_enewsclass GetModelFromCache(int classid)
        {

            return GetModelByCache(classid);
        }
        public phome_enewsclass GetModelByCache(int classid)
        {


            return GetModelAllByCache().Where(m => m.classid == classid).FirstOrDefault();


        }

        public string GetClassNameByCache(int classid)
        {

            phome_enewsclass model = GetModelByCache(classid);

            if (model != null)
            {

                return model.classname;
            }
            else
            {

                return "未知分类";
            }


        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public List<phome_enewsclass> GetSonClassByIDFromCache(int bclassid)
        {

            return GetModelAllByCache().Where(m => m.bclassid == bclassid).ToList();
        }




        /// <summary>
        /// 分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public List<phome_enewsclass> GetSonClassByIDFromCache(int id, string strTableName)
        {
            return GetModelAllByCache().Where(m => m.bclassid == id && m.tbname == strTableName).ToList();
        }

        
        /// <summary>
        /// 得到路径
        /// </summary>
        /// <param name="currentClassParentID"></param>
        /// <param name="arrClassName"></param>
        public void GetClassPathFromCache(int currentClassID, ref List<string> arrClassName)
        {
            phome_enewsclass fModel = GetModelFromCache(currentClassID);
            if (fModel != null)
            {
                int pid = Format.DataConvertToInt(fModel.bclassid);
                arrClassName.Insert(0, fModel.classname);
                GetClassPathFromCache(pid, ref arrClassName);
            }
        }

   
        /// <summary>
        /// 得到父类路径
        /// </summary>
        /// <param name="CurrentID"></param>
        /// <returns></returns>
        private void GetClassFatherNode(int CurrentID, int Index, ref List<phome_enewsclass> classNodePath)
        {
            phome_enewsclass fModel = GetModelFromCache(CurrentID);
            if (fModel != null && fModel.bclassid != 0 && Index < 10)
            {
                classNodePath.Insert(0, fModel);
                Index++;
                GetClassFatherNode(Format.DataConvertToInt(fModel.bclassid), Index, ref classNodePath);
            }
        }


        /// <summary>
        /// 得到当前分类下全部子项(包括子项的子项)
        /// </summary>
        /// <param name="CurrentID"></param>
        /// <param name="arrSonNodes"></param>
        public void GetClassSonNode(int CurrentID, ref List<phome_enewsclass> arrSonNodes)
        {
            List<phome_enewsclass> sonNodes = GetSonClassByIDFromCache(CurrentID);
            if (sonNodes.Count() > 0)
            {
                foreach (phome_enewsclass sonNode in sonNodes)
                {
                    arrSonNodes.Add(sonNode);
                    int sonClassId = sonNode.classid;
                    GetClassSonNode(sonClassId, ref arrSonNodes);
                }
            }
        }

        public string GetClassPath(int currentClassID, string sperator)
        {
            sperator = string.IsNullOrEmpty(sperator) ? ">>" : sperator;
            List<string> arrClassName = new List<string>();

            GetClassPathFromCache(currentClassID, ref arrClassName);

            StringBuilder strPath = new StringBuilder();
            if (arrClassName.Count() > 0)
            {
                for (int i = 0; i < arrClassName.Count(); i++)
                {
                    strPath.AppendFormat("{0}{1}", arrClassName[i], sperator);
                }
            }
            //得到路径
            string classPath = strPath.ToString();
            if (classPath.EndsWith(sperator))
            {
                classPath = classPath.Substring(0, classPath.Length - 2);
            }

            return classPath;
        }

        public Dictionary<int, string> GetClassPath(int currentClassID)
        {
            Dictionary<int, string> arrClassPath = new Dictionary<int, string>();
            GetClassPathFromCache(currentClassID, ref arrClassPath);
            return arrClassPath;
        }
        private void GetClassPathFromCache(int currentClassID, ref Dictionary<int, string> arrClassPath)
        {
            phome_enewsclass fModel = GetModelFromCache(currentClassID);
            if (fModel != null)
            {
                int pid = Format.DataConvertToInt(fModel.bclassid);

                arrClassPath.Add(currentClassID, fModel.classname);
                GetClassPathFromCache(pid, ref arrClassPath);


            }
        }


        public int ExistsSonNode(int id)
        {
            return GetModelAllByCache().Where(m => m.bclassid == id).Count();
        }

        public int DeleteAndSonNode(int id)
        {
            int intR = dal.DeleteAndSonNode(id);
            RemoveCache();
            return intR;
        }

      
    }
}

