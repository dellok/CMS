using System;
using System.Data;
using System.Collections.Generic;
using LL.Model.Temp;
using LL.DALFactory;
using LL.IDAL.Temp;
using LL.Common.Cache;
using System.Linq;
namespace LL.BLL.Temp
{
	/// <summary>
	/// 栏目及相应路径
	/// </summary>
	public partial class BLLTempItem
	{
		private readonly ITempItem dal=DataAccess.CreateTempItem();
		public BLLTempItem()
		{}
		#region  Method

		

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LL.Model.Temp.TempItem model)
		{
			int intR= dal.Add(model);
            RemoveCache();
            return intR;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(LL.Model.Temp.TempItem model)
		{
			int intR= dal.Update(model);
            RemoveCache();
            return intR;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int ID)
		{
           
			int intR= dal.Delete(ID);
            RemoveCache();
            return intR;
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Temp.TempItem GetModel(int ID)
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

        public  List<TempItem> GetModelAll()
        {
            return dal.GetModelAll();
        }

        #region   与缓存有关的
        public List<TempItem> GetModelAllByCache()
        {
            if (CacheManager.GetCache(Key_Cache) != null)
            {
                List<TempItem> list = (List<TempItem>)CacheManager.GetCache(Key_Cache);

                return list;
            }
            else
            {
                List<TempItem> list = GetModelAll();
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
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		

		#endregion  Method

        public bool ExistsName(string name)
        {

            return dal.ExistsName(name, 0);
        }
        /// <summary>
        /// 修改判断是否重名
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsName(string name, int id)
        {

            return dal.ExistsName(name,id);
        }

        public  TempItem GetModelByCache(int tid)
        {
            List<TempItem>  arrTemp=GetModelAllByCache();

            if (arrTemp.Count > 0)
            {

                return arrTemp.Where(m => m.ID == tid).FirstOrDefault();
            }
            else
            {

                return null;
            }
        }
    }
}

