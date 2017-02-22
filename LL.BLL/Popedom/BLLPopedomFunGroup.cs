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
    public class BLLPopedomFunGroup
    {

        IPopedomGroup dal = DALFactory.DataAccess.CreateDALPopedomGroup();

        /// <summary>
        /// 是否功能源相同
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public bool Exist(int ID, string FunGrounpName)
        {


            return dal.Exist(ID, FunGrounpName);


        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(PopedomGroup model)
        {

            int intR = dal.Add(model);
            RemoveCache();
            return intR;


        }

        /// <summary>
        /// 个性
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(PopedomGroup model)
        {

            int intR = dal.Update(model);
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
            int intR = dal.Delete(id);
            RemoveCache();
            return intR;

        }

        /// <summary>
        /// 得到model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PopedomGroup GetModel(int id)
        {
            return dal.GetModel(id);

        }

        /// <summary>
        /// 得到所有功能信息
        /// </summary>
        /// <returns></returns>
        public List<PopedomGroup> GetModelAll()
        {


            List<PopedomGroup> arr = dal.GetModelAll();
            if (arr != null && arr.Count > 1)
            {
                return arr.OrderBy(m => m.Order).ToList();
            }
            else
            {
                return arr;
            }
           
                  
          
        }



        #region   与缓存有关的


        public List<PopedomGroup> GetModelAllByCache()
        {
            if (CacheManager.GetCache(BLLPopedomFun.Key_PopedomGroup) != null)
            {
                List<PopedomGroup> list = (List<PopedomGroup>)CacheManager.GetCache(BLLPopedomFun.Key_PopedomGroup);

                return list;
            }
            else
            {
                List<PopedomGroup> list =GetModelAll();
                CacheManager.SaveCache(BLLPopedomFun.Key_PopedomGroup, list);
                return list;
            }
        }


        public void RemoveCache()
        {
            BLLPopedomFun.ClearPopedomCache();
        }

       
        #endregion
        public PopedomGroup GetModelByCache(int id)
        {
            return GetModelAllByCache().Where(m => m.ID == id).FirstOrDefault();
        }
     
    }
}
