using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.Admin;

using LL.DALFactory;
using LL.Model.Admin;
using LL.Common.Cache;
namespace LL.BLL.Admin
{
    public class BLLAdminUser
    {

        IAdminUser dal = DataAccess.CreateDALAdminUser();

        /// <summary>
        /// id>0 为修改时判断
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool ExistsLoginName(int ID, string LoginName)
        {


            return dal.ExistsLoginName(ID, LoginName);


        }
        /// <summary>
        /// 添加是判断  角色名是否存在
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool ExistsLoginName(string LoginName)
        {
            return this.ExistsLoginName(0, LoginName);
        }


        public int Add(AdminUser model)
        {
            return dal.Add(model);

        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(AdminUser model)
        {


            return dal.Update(model);

        }

        public int Delete(int id)
        {

            return dal.Delete(id);


        }
        public AdminUser GetModel(int id)
        {

            return dal.GetModel(id);
        }

        public AdminUser GetModel(string LoginName, string Password)
        {

            return dal.GetModelByNameAndPwd(LoginName, Password);
        }





        public int SetAdminChecked(int id, bool isChecked)
        {
            return dal.SetAdminChecked(id, isChecked);
        }


        #region 所有数据缓存
        /// <summary>
        /// 得到全部信息
        /// </summary>
        /// <returns></returns>
        public List<AdminUser> GetModelAllByCache()
        {
            if (CacheManager.GetCache(Key_Cache) != null)
            {
                List<AdminUser> list = (List<AdminUser>)CacheManager.GetCache(Key_Cache);

                return list;
            }
            else
            {
                List<AdminUser> list = dal.GetModelAll();
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

        public System.Data.DataSet GetList(int PageIndex, int PageSize, string where)
        {
            return GetList(PageIndex, PageSize, where, "");
        }

        public int UpdatePwd(int uid, string pwd)
        {

            if (string.IsNullOrEmpty(pwd))
            {
                return 0;
            }
            else
            {
                return dal.UpdatePwd(uid, pwd);
            }
        }

        public System.Data.DataSet GetList(int PageIndex, int PageSize, string where, string orderby)
        {
            return dal.GetList(PageIndex, PageSize, where, orderby);
        }
    }
}
