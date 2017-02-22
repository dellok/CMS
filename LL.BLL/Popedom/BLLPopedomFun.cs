using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LL.Common;
using LL.IDAL.Popedom;
using LL.Model.Popedom;
using LL.Common.Cache;
namespace LL.BLL.Popedom
{

  
    public class BLLPopedomFun
    {

        public const string Key_PopedomFun = "Key_PopedomFun";
        public const string Key_PopedomGroup = "pg";
        public const string Key_FunAdminInRole = "AdminRole";

       
        IPopedomFun dal = DALFactory.DataAccess.CreateDALPopedomFun();

        /// <summary>
        /// 是否功能源相同
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public bool Exist(int ID, string Url)
        {
            return dal.Exist(ID, Url);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(PopedomFun model)
        {
           int  intR= dal.Add(model);
            RemoveCache();
            return intR;
        }

        /// <summary>
        /// 个性
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(PopedomFun model)
        {

            int intR= dal.Update(model);
            RemoveCache();
            return intR;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
           int  intR= dal.Delete(id);
            RemoveCache();
            return intR;
        }

        /// <summary>
        /// 得到model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PopedomFun GetModel(int id)
        {
            return dal.GetModel(id);

        }

        /// <summary>
        /// 得到所有功能信息
        /// </summary>
        /// <returns></returns>
        public List<PopedomFun> GetModelAll()
        {

            return dal.GetModelAll();
        }


     #region   与缓存有关的
        public List<PopedomFun> GetModelAllByCache()
        {


            if (CacheManager.GetCache(Key_PopedomFun) != null)
            {
                List<PopedomFun> list = (List<PopedomFun>)CacheManager.GetCache(Key_PopedomFun);

                return list;
            }
            else
            {
                List<PopedomFun> list = GetModelAll();
                CacheManager.SaveCache(Key_PopedomFun, list);
                return list;
            }
        }


        public   void RemoveCache()
        {
            ClearPopedomCache();
        }

        #endregion   
        #region 从缓存中取


     


        ///// <summary>
        ///// 取出功能组下面的权限列表
        ///// </summary>
        ///// <param name="PopedomFunID"></param>
        ///// <returns></returns>
        public List<PopedomFun> SelectByGroupFromCache(int PopedomFunID)
        {
            List<PopedomFun> arr = GetModelAllByCache();
            return arr.Where(m => m.PopedomGroupID==PopedomFunID).ToList();
        }
        #endregion


        public System.Data.DataSet GetList(int PageIndex, int PageSize, string where,string orderby)
        {

            return dal.GetList( PageIndex,  PageSize,  where, orderby);
        }

        public System.Data.DataSet GetList(int PageIndex, int PageSize, string where)
        {
            return GetList(PageIndex, PageSize, where, "");
        }

        /// <summary>
        /// 清除权限相关的缓存
        /// </summary>
     public     static void ClearPopedomCache()
        {
            CacheManager.Remove(Key_FunAdminInRole);
            CacheManager.Remove(Key_PopedomGroup);
            CacheManager.Remove(Key_PopedomFun);
        }
    }
}
