using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;
using LL.Model;
using LL.DALFactory;
using LL.IDAL.Member;
using LL.Model.Member;
namespace LL.BLL
{
	/// <summary>
	/// phome_enewsspacestyle
	/// </summary>
	public partial class BLLphome_enewsspacestyle
	{
		private readonly Iphome_enewsspacestyle dal=DataAccess.Createphome_enewsspacestyle();
		public BLLphome_enewsspacestyle()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(phome_enewsspacestyle model)
		{
		return 	dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(phome_enewsspacestyle model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int id)
		{
			
			return dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public phome_enewsspacestyle GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<phome_enewsspacestyle> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<phome_enewsspacestyle> DataTableToList(DataTable dt)
		{
			List<phome_enewsspacestyle> modelList = new List<phome_enewsspacestyle>();
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

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

