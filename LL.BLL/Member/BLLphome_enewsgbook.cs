using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;
using LL.DALFactory;
using LL.IDAL.Member;
using LL.Model.Member;
namespace LL.BLL.Member
{
	
	public partial class BLLphome_enewsgbook
	{
		private readonly Iphome_enewsgbook dal=DataAccess.Createphome_enewsgbook();
		public BLLphome_enewsgbook()
		{}
		#region  Method

		

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(phome_enewsgbook model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(phome_enewsgbook model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int lyid)
		{
			
			return dal.Delete(lyid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  DeleteList(string lyidlist )
		{
			return dal.DeleteList(lyidlist,"" );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public phome_enewsgbook GetModel(int lyid)
		{
			
			return dal.GetModel(lyid);
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
		public List<phome_enewsgbook> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<phome_enewsgbook> DataTableToList(DataTable dt)
		{
			List<phome_enewsgbook> modelList = new List<phome_enewsgbook>();
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
        public System.Data.DataSet GetList(int PageIndex, int PageSize, string strSearch, string searchType)
        {

            string field = "gbtext";

            switch (searchType)
            {
                case "1":
                    field = "gbtext";
                    break;
                case "2":
                    field = "retext";
                    break;

                case "3":
                    field = "uname";
                    break;
                case "4":
                    field = "userid";
                    break;
                case "5":
                    field = "ip";
                    break;

            }
            return dal.GetList(PageIndex, PageSize, strSearch, field);
        }

	}
}

