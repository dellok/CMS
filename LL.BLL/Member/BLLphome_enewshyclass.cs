using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;

using LL.DALFactory;
using LL.IDAL.Member;
using LL.Model.Member;
namespace LL.BLL.Member
{
	/// <summary>
	/// 好友分类
	/// </summary>
	public partial class BLLphome_enewshyclass
	{
		private readonly Iphome_enewshyclass dal=DataAccess.Createphome_enewshyclass();
		public BLLphome_enewshyclass()
		{}
		#region  Method


        public bool ExistsClassName(string cname,int userid)
        {

            return ExistsClassName(cname,userid,0);
        
        }
        public bool ExistsClassName(string cname,int userid,int id)
        {
            return dal.ExistisClassName(cname,userid,id);

        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(phome_enewshyclass model)
		{
		  return 	dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(int cid,string cname)
		{
			return dal.Update(cid,cname);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int id)
		{
			
			return dal.Delete(id);
		}
        public int Delete(int id,int userid)
        {

            return dal.Delete(id,userid);
        }
	
		public phome_enewshyclass GetModel(int id)
		{
			
			return dal.GetModel(id,0);
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
		public List<phome_enewshyclass> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<phome_enewshyclass> DataTableToList(DataTable dt)
		{
			List<phome_enewshyclass> modelList = new List<phome_enewshyclass>();
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


		public DataSet GetList(int PageSize,int PageIndex,string strWhere,string orderyb)
		{
			return dal.GetList(PageSize,PageIndex,strWhere,orderyb);
		}

		#endregion  Method

        public List<phome_enewshyclass> GetListByUserID(int userid)
        {

            string where = string.Format(" userid={0} ",userid);

          return   GetModelList(where);

        }
    }
}

