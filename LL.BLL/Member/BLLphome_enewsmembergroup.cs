using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using LL.Model.Member;
using LL.IDAL.Member;
using LL.Common.Cache;
using LL.Common;
namespace LL.BLL.Member
{

    public class BLLphome_enewsmembergroup
    {

        private readonly Iphome_enewsmembergroup dal = LL.DALFactory.DataAccess.CreateMemberGroup();


        public int Add(phome_enewsmembergroup groupmodel)
        {
            int intR = dal.Add(groupmodel);
            RemoveCache();
            return intR;
        }

        public int Update(phome_enewsmembergroup groupmodel)
        {
            int intR = dal.Update(groupmodel);
            RemoveCache();
            return intR;
        }

        public int Delete(int groupid)
        {
            int intR = dal.Delete(groupid);
            RemoveCache();
            return intR;
        }



        /// <summary>
        /// 得到组名
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public    string GetGroupName(int groupid)
        {

 
            phome_enewsmembergroup groupModel = GetModelFromCache(groupid);

            if (groupModel != null)
            {

                return groupModel.groupname;
            }
            else
            {
                return "未知会员组";

            }

        }
        #region 缓存
        /// <summary>
        /// 得到group 对像从  groupid
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public phome_enewsmembergroup GetModel(int groupid)
        {



            return dal.GetModel(groupid);
        }
        public phome_enewsmembergroup GetModelFromCache(int groupid)
        {
            return GetAllListByCache().Where(m => m.groupid == groupid).FirstOrDefault();
        }
      

       
        #endregion




        /// <summary>
        /// 得到会员组权限值
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public   int GetMemberGroupLevelValue(int gid)
        {
            int groupLevel=0;
            phome_enewsmembergroup mGroup = GetModelFromCache(gid);
            if (mGroup!=null)
            {
                groupLevel=mGroup.level;
            }

            return groupLevel;

        }




        #region 所有数据缓存
        /// <summary>
        /// 得到全部信息
        /// </summary>
        /// <returns></returns>
        public List<phome_enewsmembergroup> GetAllListByCache()
        {
            if (CacheManager.GetCache(Key_Cache) != null)
            {
                List<phome_enewsmembergroup> list = (List<phome_enewsmembergroup>)CacheManager.GetCache(Key_Cache);

                return list;
            }
            else
            {
                List<phome_enewsmembergroup> list = dal.GetAllList();
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
