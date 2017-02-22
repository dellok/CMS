using System;
using System.Data;
using System.Collections.Generic;

using LL.Model;
using LL.DALFactory;
using LL.IDAL;
using LL.IDAL.Member;
using LL.Model.Member;
namespace LL.BLL
{
	
	public partial class BLLphome_enewsgbookclass
	{
		private readonly Iphome_enewsgbookclass dal=DataAccess.Createphome_enewsgbookclass();
		public BLLphome_enewsgbookclass()
		{}
		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(phome_enewsgbookclass model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(phome_enewsgbookclass model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int bid)
		{
			
			return dal.Delete(bid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int DeleteList(string bidlist )
		{
			return dal.DeleteList(bidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public phome_enewsgbookclass GetModel(int bid)
		{
			
			return dal.GetModel(bid);
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
		public List<phome_enewsgbookclass> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<phome_enewsgbookclass> DataTableToList(DataTable dt)
		{
			List<phome_enewsgbookclass> modelList = new List<phome_enewsgbookclass>();
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

