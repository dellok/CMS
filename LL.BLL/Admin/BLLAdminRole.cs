using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.Admin;

using LL.DALFactory;
using LL.Common;
using LL.Model.Admin;
using LL.Common.Cache;
namespace LL.BLL.Admin
{
    public class BLLAdminRole
    {


        IAdminRole dal = DataAccess.CreateDALAdminRole();


        /// <summary>
        /// id>0 为修改时判断
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool Exists(int ID, string RoleName)
        {
            return dal.Exists(ID, RoleName);
        }
        /// <summary>
        /// 添加是判断  角色名是否存在
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool Exists(string LoginName)
        {
            return this.Exists(0, LoginName);
        }


        /// <summary>
        /// 增加一条用户角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(AdminRole model)
        {
            ///更新缓存
            int intR = dal.Add(model);
            ///更新缓存
            RemoveCache();
            return intR;
        }
   


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(AdminRole model)
        {


         int intR= dal.Update(model);
           ///更新缓存
         RemoveCache();

           return intR;

        }

        public int Delete(int id)
        {

        int intR= dal.Delete(id);
            ///更新缓存
            RemoveCache();

            return intR;


        }
        public AdminRole GetModel(int id)
        {

            return dal.GetModel(id);
        }



        /// <summary>
        ///角色名称
        /// </summary>
        /// <param name="AdminRoleID"></param>
        /// <returns></returns>
        public  static  string  GetRoleName(int AdminRoleID)
        {
            BLLAdminRole bll = new BLLAdminRole();
            string roleName = "没有分配角色";

            if (AdminRoleID > 0)
            {

                AdminRole roleMode = bll.GetModelAllByCache().Where(m => m.ID == AdminRoleID).FirstOrDefault();

                if (roleMode != null)
                {

                    roleName = roleMode.RoleName;
                }
            }
            return roleName;
        }

        /// <summary>
        /// 得到全部的admin 角色
        /// </summary>
        /// <returns></returns>
        public List<AdminRole> GetModelAll()
        {
            return dal.GetModelAll();
        }

        #region   与缓存有关的
        public List<AdminRole> GetModelAllByCache()
        {
            if (CacheManager.GetCache(Key_Cache) != null)
            {
                List<AdminRole> list = (List<AdminRole>)CacheManager.GetCache(Key_Cache);

              

                    return list;
              
            
            }
            else
            {
                List<AdminRole> list = GetModelAll();
                CacheManager.SaveCache(Key_Cache, list);
                return list;
            }
        }

        public string Key_Cache { get { return this.GetType().Name; } }
        void RemoveCache()
        {
            CacheManager.Remove(Key_Cache);
        }

        #endregion
    }
}
