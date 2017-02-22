using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LL.Common;
using LL.IDAL.Popedom;
using Project.Common;
using LL.Model.Popedom;
using LL.Common.Cache;
namespace LL.BLL.Popedom
{
    public class BLLPopedomFunInAdminRole
    {
         IPopedomFunInAdminRole dal = DALFactory.DataAccess.CreateDALPopedomFunInAdminRole();
        /// <summary>
        /// 是否功能源相同
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public bool Exist(  int FunID,int AdminID)
        {
            return dal.Exist(FunID,AdminID);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(PopedomFunInAdminRole model)
        {

             int intR= dal.Add(model);
            RemoveCache();
            return intR;


        }

        /// <summary>
        /// 个性
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(PopedomFunInAdminRole model)
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
            int intR= dal.Delete(id);
            RemoveCache();
                return intR;


        }

        /// <summary>
        /// 得到model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PopedomFunInAdminRole GetModel(int id)
        {
            return dal.GetModel(id);

        }

        /// <summary>
        /// 得到所有功能信息
        /// </summary>
        /// <returns></returns>
        public List<PopedomFunInAdminRole> GetModelAll()
        {
            return dal.GetModelAll();
        }



        public List<PopedomFunInAdminRole> SelectFunByRoleFromCache(int RoleID)
        {
            return GetModelAll().Where(m => m.PopedomRoleID == RoleID).ToList();
        }


        #region   与缓存有关的
        public List<PopedomFunInAdminRole> GetModelAllByCache()
        {
            if (CacheManager.GetCache(BLLPopedomFun.Key_FunAdminInRole) != null)
            {
                List<PopedomFunInAdminRole> list = (List<PopedomFunInAdminRole>)CacheManager.GetCache(BLLPopedomFun.Key_FunAdminInRole);

                return list;
            }
            else
            {
                List<PopedomFunInAdminRole> list = GetModelAll();
                CacheManager.SaveCache(BLLPopedomFun.Key_FunAdminInRole, list);
                return list;
            }
        }

        public void RemoveCache()
        {
            BLLPopedomFun.ClearPopedomCache();
        }

        #endregion


        /// <summary>
        /// 批量个性角色ID
        /// </summary>
        /// <param name="AdminRoleID"></param>
        /// <param name="arrStrFunIDS"></param>
        /// <returns></returns>

        public int EditFunInAdminRole(int AdminRoleID, string[] arrStrFunIDS)
        {

            int intR = 0;

            List<PopedomFunInAdminRole> arrEditFunInAdminRole = new List<PopedomFunInAdminRole>();

            PopedomFunInAdminRole  funModel;

            foreach (string strFID in arrStrFunIDS)
            {
                int FunID = Format.DataConvertToInt(strFID);
                if (FunID>0)
                {

                    funModel=new PopedomFunInAdminRole();
                    funModel.PopedomRoleID=AdminRoleID;
                    funModel.PopedomFunID=FunID;
                    arrEditFunInAdminRole.Add(funModel);
                } 
            }


            intR = dal.EditFunInAdminRole(AdminRoleID, arrEditFunInAdminRole);
            RemoveCache();
            return intR;

        }
    }
}
